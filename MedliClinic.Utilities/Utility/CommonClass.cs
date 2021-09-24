using MediClinic.Models.DTOs.DMESuppliesDto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedliClinic.Utilities.Utility
{
    public class CommonClass
    {
        public async Task<string> GetData(string ICDName)
        {
            try
            {
                var tokenEndpoint = "http://icd10api.com/?s=" + ICDName + "&desc=short&r=json";

                var client = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Get, tokenEndpoint);

                //call the API
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var prettyJson = JValue.Parse(content).ToString(Formatting.Indented);
                    var dtoData = JsonConvert.DeserializeObject<ICDDto>(content);
                    return prettyJson;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
