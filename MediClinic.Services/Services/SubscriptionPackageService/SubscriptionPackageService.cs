using AutoMapper;
using MediClinic.Models.DTOs;
using MediClinic.Models.DTOs.CommonDto;
using MediClinic.Models.EntityModels;
using MediClinic.Services.Interfaces.SubscriptionPackageInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedliClinic.Utilities.Utility;
using RestSharp;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Configuration;
using System.Net;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MediClinic.Services.Services.SubscriptionPackageService
{
    public class SubscriptionPackageService : ISubscriptionPackageService
    {
        private MediClinicContext _context;
        private IMapper _mapper;
        private readonly PayPalAuthOptions _options;
        public SubscriptionPackageService(MediClinicContext context, IMapper mapper, IOptions<PayPalAuthOptions> option)
        {
            _context = context;
            _mapper = mapper;
            _options = option.Value;
        }

        public async Task<ResponseDto<bool>> CreateSubScription(SubsriptionPackageDto subscriptionPackageDto)
        {
            try
            {
                if (ServicePointManager.SecurityProtocol != SecurityProtocolType.Tls12) ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // forced to modern day SSL protocols
                var client = new RestClient("https://api-m.sandbox.paypal.com/v1") { Encoding = Encoding.UTF8 };
                var authRequest = new RestRequest("oauth2/token", Method.POST) { RequestFormat = DataFormat.Json };
                client.Authenticator = new HttpBasicAuthenticator("AT11qPyO4TfVdghUg4sC6SzDPJJCoibwrHeoc3KXdxnPoCSRrCUCqm5OY_BjAngepDfx3VtvfDCI90T3", "ELAcr_e6rB4m0bx4EQXUg58zCO9YchhJJB-9nN9JR7KtBnvahMlC2p238h3Mu0IijiIYqPXbscpQ_NI-");
                authRequest.AddParameter("grant_type", "client_credentials");
                var authResponse = client.Execute(authRequest);
                var parsedObject = JObject.Parse(authResponse.Content);
                var popupJson = parsedObject["access_token"].ToString();
                var access_token = "Bearer " + popupJson;
                var info = new Product
                {
                    name = subscriptionPackageDto.PackageName,
                    description = subscriptionPackageDto.PackageDescriptin,
                    type = "Service",
                    category = "SOFTWARE",
                    image_url = "https://example.com/streaming.jpg",
                    home_url = "https://example.com/home"
                };
                var clientId = new RestClient("https://api.sandbox.paypal.com/v1/catalogs/products");
                var request = new RestRequest(Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(info);
                request.AddHeader("Authorization", access_token);
                var response = clientId.Execute(request);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in response.Content)
                {
                    stringBuilder.Append(item);
                }

                var data = JsonConvert.DeserializeObject<Root>(response.Content);
                var blist = new List<BillingCycle>();
                var plist = new PaymentPreferences();
                var taxes = new Taxes();
                var b = new BillingCycle();
                b.frequency = new Frequency();
                b.frequency.interval_unit = "MONTH";
                b.frequency.interval_count = 1;
                b.tenure_type = "TRIAL";
                b.sequence = 1;
                b.total_cycles = 1;
                b.pricing_scheme = new PricingScheme();
                b.pricing_scheme.fixed_price = new SetupFee();
                b.pricing_scheme.fixed_price.value = 20;
                b.pricing_scheme.fixed_price.currency_code = "USD";
                var c = new BillingCycle();
                c.frequency = new Frequency();
                c.frequency.interval_unit = "MONTH";
                c.frequency.interval_count = 1;
                c.tenure_type = "REGULAR";
                c.sequence = 2;
                c.total_cycles = 11;
                c.pricing_scheme = new PricingScheme();
                c.pricing_scheme.fixed_price = new SetupFee();
                c.pricing_scheme.fixed_price.value = (long)subscriptionPackageDto.PackagePrice;
                c.pricing_scheme.fixed_price.currency_code = "USD";
                blist.Add(b);
                blist.Add(c);
                plist.auto_bill_outstanding = true;
                plist.setup_fee = new SetupFee();
                plist.setup_fee.value = 10;
                plist.setup_fee.currency_code = "USD";
                plist.setup_fee_failure_action = "CONTINUE";
                plist.payment_failure_threshold = 3;
                taxes.percentage = 10;
                taxes.inclusive = false;
                var info2 = new CreatePlan
                {
                    product_id = data.id,
                    name = subscriptionPackageDto.PackageName,
                    description = subscriptionPackageDto.PackageDescriptin,
                    status = "ACTIVE",
                    billing_cycles = blist,
                    payment_preferences = plist,
                    taxes = taxes
                };

                var client2 = new RestClient("https://api.sandbox.paypal.com/v1/billing/plans");
                var request2 = new RestRequest(Method.POST);
                request2.RequestFormat = DataFormat.Json;
                request2.AddJsonBody(info2);
                request2.AddHeader("Authorization", access_token);
                request2.AddHeader("Content-Type", "application/json");
                var response2 = client2.Execute(request2);
                var parsedObject2 = JObject.Parse(response2.Content);
                var Plan_Id = parsedObject2["id"].ToString();
                var result = false;
                var mapper = _mapper.Map<SubsriptionPackageDto, SubscriptionPackages>(subscriptionPackageDto);
                mapper.isActive = true;
                mapper.Negitable = false;
                mapper.Plan_Id = Plan_Id;
                mapper.ProductId = data.id;
                var rec = await _context.SubscriptionPackages.AddAsync(mapper);
                await _context.SaveChangesAsync();
                if (!(rec is null))
                {
                    result = true;
                }
                var resp = new ResponseDto<bool>();
                resp.Data = result;
                return resp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<ResponseDto<List<SubsriptionPackageDto>>> SubscriptionPackageList()
        {
            var rec = await _context.SubscriptionPackages.Where(x=>x.isActive == true).ToListAsync();
            var response = new ResponseDto<List<SubsriptionPackageDto>>();
            response.Data = _mapper.Map<List<SubscriptionPackages>, List<SubsriptionPackageDto>>(rec);
            return response;
        }

        public async Task<ResponseDto<bool>> CreateTransaction(string TransactionId, long EmployeeId)
        {
            try
            {
                var result = false;
                PackageTransactions packageTransactions = new PackageTransactions();
                packageTransactions.EmployeeId = EmployeeId;
                packageTransactions.TransactionId = TransactionId;
                var rec = await _context.PackageTransactions.AddAsync(packageTransactions);
                await _context.SaveChangesAsync();
                if (!(rec is null))
                {

                    result = true;
                }
                var response = new ResponseDto<bool>();
                response.Data = result;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool UpdateTransactionForVerifcationCode(long EmpId, int Code)
        {
            var result = false;
            var rec = _context.PackageTransactions.FirstOrDefault(x => x.EmployeeId == EmpId);
            rec.CodeForVerification = Code;
            if (!(rec is null))
            {
                 _context.SaveChanges();
                result = true;    
            }
            return result;
        }

        public PackageTransactions GetRecByEmpId(long EmpId)
        {
            var rec = _context.PackageTransactions.FirstOrDefault(x => x.EmployeeId == EmpId);
            return rec;
        }

        public class Product
        {
            public string name { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public string category { get; set; }
            public string image_url { get; set; }
            public string home_url { get; set; }
        }
        public partial class CreatePlan
        {
            public string product_id { get; set; }

            public string name { get; set; }

            public string description { get; set; }

            public string status { get; set; }

            public List<BillingCycle> billing_cycles { get; set; }

            public PaymentPreferences payment_preferences { get; set; }

            public Taxes taxes { get; set; }
        }

        public partial class BillingCycle
        {
            public Frequency frequency { get; set; }

            public string tenure_type { get; set; }

            public long sequence { get; set; }

            public long total_cycles { get; set; }

            public PricingScheme pricing_scheme { get; set; }
        }

        public partial class Frequency
        {
            public string interval_unit { get; set; }

            public long interval_count { get; set; }
        }

        public partial class PricingScheme
        {
            public SetupFee fixed_price { get; set; }
        }

        public partial class SetupFee
        {
            public long value { get; set; }

            public string currency_code { get; set; }
        }

        public partial class PaymentPreferences
        {
            public bool auto_bill_outstanding { get; set; }

            public SetupFee setup_fee { get; set; }

            public string setup_fee_failure_action { get; set; }

            public long payment_failure_threshold { get; set; }
        }

        public partial class Taxes
        {
            public long percentage { get; set; }

            public bool inclusive { get; set; }
        }
        public class Roottable
        {
            public string href { get; set; }
            public string rel { get; set; }
            public string method { get; set; }
        }

        public class Root
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public DateTime create_time { get; set; }
            public List<Roottable> links { get; set; }
        }
        public class PayPalAuthOptions
        {
            public string PayPalClientId { get; set; }

            public string PayPalClientSecret { get; set; }
        }
    }
}
