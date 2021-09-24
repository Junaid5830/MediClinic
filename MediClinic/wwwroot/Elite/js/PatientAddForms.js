 

$(function () {

    $('#ssn').inputmask({ mask: '999-99-9999', greedy: false, skipOptionalPartCharacter: "", "clearIncomplete": true });
 
    $('.phoneno').inputmask({ mask: '1 (999) 999-9999', greedy: false, skipOptionalPartCharacter: "", "clearIncomplete": true });
   
    $('.fax').inputmask({ mask: '(999) 999-9999', greedy: false, skipOptionalPartCharacter: "", "clearIncomplete": true });
    $('.vitalBloodPressure').inputmask("999/99");
    $('.vitalHeight').inputmask("9'99\"");
    $('.vitalTemprature').inputmask("999 °F");
    $('.vitalOxygenSaturation').inputmask("99 %");
    $('.vitalWeight').inputmask("999 lbs");
    $('.vitalRespiration').inputmask("99 per/min");
    $('.vitalPulse').inputmask("99 per/min");


});

//function FeatureImplementation() {
//    new PNotify({
//        title: 'Alert!',
//        text: "This feature will be implemented in next module.",
//        delay: 2000,
//        type: 'success'
//    });
//}

/*For avaid space*/
//$("#btn-form").on("click", function () {

//    for (var i = 0; i < val; i++) {
//        var newInput = $('<input>');
//        $('#newDiv').append(newInput);
//    alert(val);

//})();
//var val = $("#form_append").val();
//alert(val);
var isEditInfoBtn = false;
var isEditPhoneBtn = false;
var isEditEmergencyBtn = false;
var isEditIdAndSignatureBtn = false;
var isEditClaimInfoBtn = false;
var isEditVehicleBtn = false;
var isEditSecondaryInsuranceBtn = false;
var isEditTertiaryInsuranceBtn = false;
var isEditPIBtn = false;
var isEditCollectionBtn = false;
//document.addEventListener("DOMContentLoaded", function () {
//    $('.preloader-background').delay(400).fadeOut('slow');

//    $('.preloader-wrapper')
//        .delay(400)
//        .fadeOut();
//});
//$(".checkmark").hide();
function ElectronicPassword(id) {
    debugger;
    var x = document.getElementsByClassName(id);
    for (var i = 0; i < x.length; i++) {
        if (x[i].type === "password") {
            x[i].type = "text";
        } else {
            x[i].type = "password";
        }
    }

}
function AvoidSpace(event) { 
    var k = event ? event.which : window.event.keyCode;
    if (k == 32) return false;
}
//$("#Address").on("keypress", function (e) {
//    debugger;
//    if (e.which === 32 && !this.value.length)
//        e.preventDefault();
//});
$(function () {

    $('body').on('keydown', 'input', function (e) {

        //console.log(this.value);

        if (e.which === 32 && this.value === '') {
            return false;
        }

    });

});

var globalValue = "";
var PatientTeratmentValue = "";
var PatientEmploymentStatusValue = "";
var EmploymentTitleValue = "";
var SignatureIdTypeValue = "";

var isInfoButtonClick = false;
var isPhoneButtonClick = false;
var isEmergencyButtonClick = false;
var isSignatureButtonClick = false;
var isCastTypeButtonClick = false;
var isClaimInfoButtonClick = false;
var isVehicleButtonClick = false;
var isSecondaryButtonClick = false;
var isTertiaryButtonClick = false;
var isPIButtonClick = false;
var isCollectionButtonClick = false;
function onRelatedFacilityCreateToDoSuccess(data) {

    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Data Saved successfully',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });
        $('.related_Facility').val('');
        var TypeIdlist = $(".Related_facility");
        TypeIdlist.append($('<option></option>').val(data.relatedFacilityId).text(data.relatedFacility));
    }
}
function AjaxBegin()
{
    $("button").attr("disabled", true); 
} 
function AjaxComplete() {
    $("button").attr("disabled", false);
} 
$(document).ready(function () {
    $('ul.customtab li.nav-item a').click(function () {
        $(".right-side-toggle").click();
    });
    var drEvent = $('.dropify').dropify();

    drEvent.on('dropify.afterClear', function (event, element) {
        debugger;
        var data = event.target;
        var ImagePath = data.classList[1];
        if (ImagePath == "forPatient") {
            $("#HidenProfilePic").val(null);
        }
        else if (ImagePath == "forPatientSignature") {
            $("#HidenSignaturePic").val(null);
        }
        else if (ImagePath == "forDMESupplyEquipment") {
            $('#hiddenDMESupEquipImage').val(null);
        }

    });
    $("input[type=file]").change(function (event) {
        debugger;
        var data = event.target;
        var ImagePath = data.classList[1];
        if (ImagePath == "forPatient") {
            $("#HidenProfilePic").val(null);
        }
        else if (ImagePath == "forPatientSignature") {
            $("#HidenSignaturePic").val(null);
        }
        else if (ImagePath == "forDMESupplyEquipment") {
            $("#hiddenDMESupEquipImage").val(null);
        }
    });


    $(".fc-listMonth-button").html('<i class="material-icons">menu</i>');
    $(".fc-calMonth-button").html('<i class="material-icons">apps</i>');

    //if ($("input:radio[name=yes]") === 1) {
    //    debugger;
    //    $('#secondary_add').show();
    //}   
    var Signdata = "";
    $('.nav-dropdown-trigger').dropdown({
        inDuration: 300,
        outDuration: 225,
        constrainWidth: true, // Does not change width of dropdown to that of the activator
        hover: true, // Activate on hover
        gutter: 1, // Spacing from edge
        coverTrigger: true, // Displays dropdown below the button
        alignment: 'right', // Displays dropdown with edge aligned to the left of button
        stopPropagation: false // Stops event propagation
    }
    );

    $('.action').click(function (e) {
        e.stopPropagation();
    });

    $("a.waves-cyan").hover(function () {

        $(".sidenav-dark.sidenav-main > .sidenav").removeClass("overflowVisible");

    });
    $("a.waves-cyan[data-target='nav-dropdown']").hover(function () {

        $(".sidenav-dark.sidenav-main > .sidenav").addClass("overflowVisible");

    });


});
//For side out on Add Button START
$(document).ready(function () {

    $("#emergaddresscheck").change(function () {
        if ($("#emergaddresscheck").is(":checked")) {
            var infoadd1 = $(".paientAddressLine1").val();
            var infoadd2 = $(".paientAddressLine2").val();
            var infoadd3 = $(".paientAddressLine3").val();
            var infoZipCode = $('#info_Zip').val();
            var infoCityCode = $('#info_city').val();
            var infoStateCode = $('#info_state').val();
            var infoCountryCode = $('#info_country').val();
            debugger;
            $(".emergncyAddressLine1").val(infoadd1);
            $(".emergncyAddressLine2").val(infoadd2);
            $(".emergncyAddressLine3").val(infoadd3);
            $('.emergncyZipCode').val(infoZipCode);
            $('.emergncyCity').val(infoCityCode);
            $('#emergency_state').val(infoStateCode);
            $('#emergency_country').val(infoCountryCode);
        }

        else {
            $(".emergncyAddressLine1").val("");
            $(".emergncyAddressLine2").val("");
            $(".emergncyAddressLine3").val("");

            $('.emergncyZipCode').val("");
            $('.emergncyCity').val("");
            $('#emergency_state').val("");
            $('#emergency_country').val("");
        }
    });


    //$(".dropbody li").first().on("click", function (event) {
    //    //$('table tbody tr th input').prop('checked', true);

    //    $("table tbody tr").has("th input:not(:checked)").hide();
    //    event.stopPropagation();
    //});
    //$(".dropbody li").last().on("click", function (event) {
    //    //$('table tbody tr th input').prop('checked', false);

    //    $("table tbody tr").has("th input:checked").hide();
    //    event.stopPropagation();
    //});

    $(".sideout").click(function () {
        $("body").addClass("sidebarflow");

        $(".nav-collapsible .navbar-toggler").trigger("click");
        $("#main").css("padding-right", "340px");

    });
    $(".form-add-btn").on('click', function () {
        debugger;
        $(".sidenav-trigger").attr("disabled", true);
        //$("ul.tab-demo li a").attr("disabled", true);

    });
    $(".sidenav-close").click(function () {
        $(".sidenav-trigger").removeAttr("disabled");
        $("#main").toggleClass("main-full");
        $(".brand-logo2").addClass("brand-logo");
        $(".brand-logo").show();
        $(".sidenav-main.nav-collapsible, .navbar .nav-collapsible")
            .addClass("nav-expanded")
            .addClass("nav-lock")
            .removeClass("nav-collapsed");
        $(".nav-collapsed .brand-sidebar .navbar-toggler").css("visibility", "hidden");
        $(".brand-sidebar .logo-wrapper a.navbar-toggler").css("position", "absolute");
        $(".sideBarCollapseIcon").css("margin-left", "0px");
        $(".sideBarCollapseIcon").css("margin-top", "0px");
        $(".sidenav-dark").css("background-color", "white");
        $(".ps__thumb-x, .ps__thumb-y").css("background-color", "#aaa");
        $(".firstNavBarList").css("margin-left", "260px");
        $(".sidenav-dark.sidenav-main .sidenav li > a > i").css("color", "black");

        $("#slide-out > li.close > a")
            .parent()
            .addClass("open")
            .removeClass("close");

        setTimeout(function () {
            if ($(".collapsible .open").children().length > 1) {
                $(".collapsible").collapsible("open", $(".collapsible .open").index());
            }
        }, 100);
        $("#main").css("padding-right", "0px");
        if (screen.width <= 1550) {
            $(".header-2").show();
            $(".heading-1").hide();
        }

    });
   

    $('.select-all').click(function () {

        $('table tbody tr th input').prop('checked', this.checked);
    });
    //$(".input-field").addClass("col s12 pl-0");

});


$(document).ready(function () {

    var navwidht = $('.navbar-width').width();
    if (navwidht <= 930) {
        $('.heading-1').hide();
        $('.header-2').show();
    }
    else {
        $('.heading-1').show();
    }
    $('.datepicker').datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "c-100:c+10",
        showButtonPanel: true,
        dateFormat: "mm/dd/yy",
        minDate: '01/01/1920',
        maxDate: new Date()
    });
    // $('.datepicker').mask("99/99/9999");
    $('#PolicyStartDate, #PolicyEndDate').datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "c-100:c+10",
        showButtonPanel: true,
        beforeShow: customRange,
        dateFormat: "mm/dd/yy"
    });

});
function customRange(input) {

    if (input.id == 'PolicyEndDate') {
        var minDate = new Date($('#PolicyStartDate').val());
        minDate.setDate(minDate.getDate() + 1)

        return {
            minDate: minDate

        };
    }

    return {}

}
function customRange(input) {

    if (input.id == 'PolicyEndDate') {
        var minDate = new Date($('#PolicyStartDate').val());
        minDate.setDate(minDate.getDate() + 1)

        return {
            minDate: minDate

        };
    }

    return {}

}
//function getBrowserName() {
//    var name = "Unknown";
//    if (navigator.userAgent.indexOf("MSIE") !== -1) {
//        name = "MSIE";
//    }
//    else if (navigator.userAgent.indexOf("Firefox") !== -1) {
//        name = "Firefox";
//    }
//    else if (navigator.userAgent.indexOf("Opera") !== -1) {
//        name = "Opera";
//    }
//    else if (navigator.userAgent.indexOf("Chrome") !== -1) {
//        name = "Chrome";
//    }
//    else if (navigator.userAgent.indexOf("Safari") !== -1) {
//        name = "Safari";
//    }
//    return name;
//}
//function setCSSforBrowser(browserName) {
//    if (browserName === "MSIE") {
//        document.getElementById("linkCss").href = "../../app-assets/css/custom/BrowserDefault.css";
//    }
//    else if (browserName === "Firefox") {
//        document.getElementById("linkCss").href = '../../app-assets/css/custom/BrowserDefault.css';
//    }
//    else if (browserName === "Safari") {
//        document.getElementById("linkCss").href = '../../app-assets/css/custom/Safari.css';
//    }
//    else if (browserName === "Opera") {
//        document.getElementById("linkCss").href = '../../app-assets/css/custom/BrowserDefault.css';
//    }
//    else if (browserName === "Chrome") {
//        document.getElementById("linkCss").href = '../../app-assets/css/custom/BrowserDefault.css';
//    }
//    else { //we have an unsupported browser so use the firefox styling hoping that it works				

//        //document.getElementById("linkCss").href = 'javascript:void(0)';
//    }
//}
//var browserName = getBrowserName();
//setCSSforBrowser(browserName);

function onCreatePatientTreatment(data) { 
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {

        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.patientTreatmentStatusNew').val('');
        $('.patientTreatmentStatusNew').removeClass('valid');

        var treatmentSelectList = $('.patientTreatmentStatusCombo');
        treatmentSelectList.append($('<option></option>').val(data.patientTreatmentId).text(data.patientTreatmentStatus1));
    }
};
function onCreatePatientlegal(data) { 
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });
        $('.patientLegalStatusNew').val('');
        $('.patientLegalStatusNew').removeClass('valid');

        var legalStatusSelectList = $('.patientLegalStatusCombo');
        legalStatusSelectList.append($('<option></option>').val(data.patientLegalId).text(data.patientLegalStatus1));
    }
}
function onCreateEmpStatus(data) { 
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.SignIdType').val('');
        $('.SignIdType').removeClass('valid');

        var statusSelectList = $('.empStatusComboPatientInfo');

        statusSelectList.append($('<option></option>').val(data.employmentStatusId).text(data.employmentStatus1));
    }
}
function onCreateProviderName(data) { 
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.SignIdType').val('');
        $('.SignIdType').removeClass('valid');

        var providerSelectList = $('.secondaryInsuranceProviderCombo');
        providerSelectList.append($('<option></option>').val(data.providerId).text(data.providerName));

        var VehilceproviderSelectList = $('.VehicleInsuranceProvider');
        VehilceproviderSelectList.append($('<option></option>').val(data.providerId).text(data.providerName));

        var tSelectList = $('.TProviderNameCombo');
        tSelectList.append($('<option></option>').val(data.providerId).text(data.providerName));

    }
}

function onCreateTProviderName(data) { 
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.SignIdType').val('');
        $('.SignIdType').removeClass('valid');

        var providerSelectList = $('.TProviderNameCombo');
        providerSelectList.append($('<option></option>').val(data.providerId).text(data.providerName));

        var secSelectList = $('.secondaryInsuranceProviderCombo');
        secSelectList.append($('<option></option>').val(data.providerId).text(data.providerName));

    }
}
function onCreateToDoEmergency(data) {
    AjaxComplete();
    

    var isErrorMessage = data.isError;
    if (isErrorMessage) {
        new PNotify({
            title: 'Error!',
            text: 'Please provide patient info first',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });
    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });
    }
};
function onCreateGroupNumber(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.SignIdType').val('');
        $('.SignIdType').removeClass('valid');

        var providerSelectList = $('.providerGroupNumber');
        providerSelectList.append($('<option></option>').val(data.groupId).text(data.groupName));

        var tSelectList = $('.TGroupNumberCombo');
        tSelectList.append($('<option></option>').val(data.groupId).text(data.groupName));

    }
}

function onCreateTGroupNumber(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.SignIdType').val('');
        $('.SignIdType').removeClass('valid');

        var TSelectList = $('.TGroupNumberCombo');
        TSelectList.append($('<option></option>').val(data.groupId).text(data.groupName));

        var providerSelectList = $('.providerGroupNumber');
        providerSelectList.append($('<option></option>').val(data.groupId).text(data.groupName));

    }
}

function onCreateIdTpye(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {

        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.SignIdType').val('');
        $('.SignIdType').removeClass('valid');

        var TypeIdlist = $(".SignatureTypeId");
        TypeIdlist.append($('<option></option>').val(data.typeId).text(data.typeName));
    }
};
function onCreateEmpList(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.SignIdType').val('');
        $('.SignIdType').removeClass('valid');

        var titleSelectList = $('.employmentTitlePatientInfo');
        titleSelectList.append($('<option></option>').val(data.employmentTitleId).text(data.employmentTitle1));
    }
};
function onCreateLangList(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        debugger;
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.SignIdType').val('');
        $('.SignIdType').removeClass('valid');
        //var select = $("#multilanguage");
        //select.children().remove();
        //select.append($("<option>").val(data.languageId).text(data.languageName));
        //$('#multilanguage').empty();
        //$.each(data, function (i, item) {
        //    // replace 'item.Value' and 'item.Text' from corresponding list properties into model class
        //    $('#multilanguage').append('<option value="' + item.Value + '"> ' + item.Text + ' </option>');
        //});
        var languageSelectList = $('#multilanguage');
        languageSelectList.append($('<option value ="' + data.languageId + '">' + data.languageName + '</option>'));
    }
};

function onCreateRelationShip(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.SignIdType').val('');
        $('.SignIdType').removeClass('valid');

        var titleSelectList = $('.emergncyRelationShip');
        titleSelectList.append($('<option></option>').val(data.relationshipId).text(data.relationshipName));
    }
};

function onCreatePatientRoleIncident(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.addpatientRoleIncident').val('');
        $('.addpatientRoleIncident').removeClass('valid');
        var IncidentList = $('.incidentRole');
        IncidentList.append($('<option></option>').val(data.patientIncidentRoleId).text(data.patientRoleInIncident));
    }
}
function onCreatePatientIncidentReport(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.incidentReportStatusadd').val('');
        $('.incidentReportStatusadd').removeClass('valid');
        var IncidentReportList = $('.incidentReport');
        IncidentReportList.append($('<option></option>').val(data.incidentReportId).text(data.incidentReportStatus1));
    }
}
function onCreatePatientnf2(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 3000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.addPatientnf2').val('');
        $('.addPatientnf2').removeClass('valid');
        var nf2List = $('.nf2list');
        nf2List.append($('<option></option>').val(data.nf2Id).text(data.nf2Status1));
    }
}
function onCreatePatientclaimstatus(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.addClaimStatusInfo').val('');
        $('.addClaimStatusInfo').removeClass('valid');
        var claimstatusList = $('.claimlist');
        claimstatusList.append($('<option></option>').val(data.claimStatusId).text(data.claimStatus1));
    }
}
function onCreatePILegalInfo(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.addlegalStatus').val('');
        $('.addlegalStatus').removeClass('valid');

        var statusSelectList = $('.PatientLegalStatusCombo');
        statusSelectList.append($('<option></option>').val(data.legalStatusId).text(data.legalStatus));

    }
}

function onCreatePILegalStatus(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.addlegalStatus').val('');
        $('.addlegalStatus').removeClass('valid');
    }
}
function onCreateAttorneyName(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.addlegalStatus').val('');
        $('.addlegalStatus').removeClass('valid');

        var statusSelectList = $('.attorneyNameCombo');
        statusSelectList.append($('<option></option>').val(data.attorneyId).text(data.attorneyName));

    }
}

function onCreatePatientInfoLegalStatus(data) {
    AjaxComplete();
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

        $('.addlegalStatus').val('');
        $('.addlegalStatus').removeClass('valid');

        var statusSelectList = $('.FirmNameCombo');
        statusSelectList.append($('<option></option>').val(data.firmId).text(data.firmName));

    }
}

function onCreatePatientCaseType(data) {
    AjaxComplete();
    new PNotify({
        title: 'Success!',
        text: 'Record Save',
        delay: 5000,
        type: 'success',
        addclass: 'pnotify-center'
    });

    $('.addNewCaseTypeClass').val('');
    $('.addNewCaseTypeClass').removeClass('valid');
    $('#NewList').html(data);

};

function onaddCreatePatientCaseType(data) {
    AjaxComplete();
    var isErrorMessage = data.isError;
    if (isErrorMessage) {
        new PNotify({
            title: 'Error!',
            text: 'Please provide patient info first',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });
    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });
    }
};
/*Provider Related Facilities*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="ProviderFacility();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="related-facility-right"><a class="sidenav-trigger sideout" data-target="related-facility-right">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }

    });

    //$("#providerRelatedFacility").combobox();


});
function ProviderFacility() {
    if (globalValue != "") {
        $(".related_Facility").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}
/*Auto Complete With Comobox*/
$(function () {
    //var addnew = '<li class="ui-menu-item" id="addnew"><div class="ui-menu-item-wrapper sidenav-trigger sideout form-add-btn"  href="javascript:void(0);" data-target="slide-out-right"><a class="sidenav-trigger sideout" data-target="slide-out-right">Add New</a></div></li>';
    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source")
                    //'open': function (e, ui) {
                    //    $(".ui-autocomplete").append(addnew);
                    //},
                    //response: function (event, ui) {
                    //    if (!ui.content.length) {
                    //        var noResult = { value: "", label: "No results found" };
                    //        ui.content.push(noResult);
                    //    }
                    //}
                });
            //.tooltip({
            //    classes: {
            //        "ui-tooltip": "ui-state-highlight"
            //    }
            //});

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {


            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;
            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {
                return;
            }

            // Remove invalid value
            this.input
                .val("")
                .attr("title", value + " didn't match any item");
            //.tooltip("open");
            this.element.val("");
            this._delay(function () {
                this.input.tooltip("close").attr("title", "");
            }, 2500);
            this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$(".combobox").combobox();


});
/*RelationShip*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="Relationship();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right26"><a class="sidenav-trigger sideout" data-target="slide-out-right26">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#comboboxRelation").combobox();


});
function Relationship() {
    if (globalValue != "") {
        $(".relationshipvalue").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}
/*Patient Legal Status*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="dropdownCheck();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right2"><a class="sidenav-trigger sideout" data-target="slide-out-right2">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: globalValue + " No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#patientLegal").combobox();


});
function dropdownCheck() {
    debugger;

    if (globalValue != "") {
        $(".patientLegalStatusNew").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Treatment Status*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="treaetmentStatus();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right"><a class="sidenav-trigger sideout" data-target="slide-out-right">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            PatientTeratmentValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#patientTreatment").combobox();


});
function treaetmentStatus() {
    debugger;

    if (PatientTeratmentValue != "") {
        $(".patient_treatmentStatus").val(PatientTeratmentValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Employment Status*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="EmploymentStatus();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right23"><a class="sidenav-trigger sideout" data-target="slide-out-right23">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            PatientEmploymentStatusValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#Employment_Status").combobox();


});
function EmploymentStatus() {
    debugger;
    if (PatientEmploymentStatusValue != "") {
        $(".employementStatus_val").val(PatientEmploymentStatusValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Employment Title*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="EmploymentTitle();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right24"><a class="sidenav-trigger sideout" data-target="slide-out-right24">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#Employment_Title").combobox();


});
function EmploymentTitle() {
    debugger;
    if (globalValue != "") {
        $(".employementTitleval").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Signature Id Typr*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="SignatureIdType();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right14"><a class="sidenav-trigger sideout" data-target="slide-out-right14">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#SignatureIdType").combobox();


});
function SignatureIdType() {
    if (globalValue != "") {
        $(".sign_IdType").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Role in the Incident*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientRoleIncident();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right5"><a class="sidenav-trigger sideout" data-target="slide-out-right5">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#Patient_RoleIncident").combobox();


});
function PatientRoleIncident() {
    if (globalValue != "") {
        $(".addpatientRoleIncident").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Incident Report*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientIncidentReport();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right6"><a class="sidenav-trigger sideout" data-target="slide-out-right6">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#Patient_incidentReport").combobox();


});
function PatientIncidentReport() {
    if (globalValue != "") {
        $(".incidentReportStatusadd").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient NF2 Status*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientNf2Status();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right7"><a class="sidenav-trigger sideout" data-target="slide-out-right7">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#Patient_nf2Status").combobox();


});
function PatientNf2Status() {
    if (globalValue != "") {
        $(".addPatientnf2").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Claim Status*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientClaimStatus();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right8"><a class="sidenav-trigger sideout" data-target="slide-out-right8">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#Patient_claimStatus").combobox();


});
function PatientClaimStatus() {
    if (globalValue != "") {
        $(".addClaimStatusInfo").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}
/*Patient Secondary Insurance Provider Name*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientProviderName();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right15"><a class="sidenav-trigger sideout" data-target="slide-out-right15">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#Patient_ProviderName").combobox();


});
function PatientProviderName() {
    if (globalValue != "") {
        $(".providerName").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Secondary Insurance Group Number*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientGroupName();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right16"><a class="sidenav-trigger sideout" data-target="slide-out-right16">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#Patient_GroupName").combobox();


});
function PatientGroupName() {
    if (globalValue != "") {
        $(".groupName").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Teritary Insurance Provider Name*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="TPatientProviderName();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right17"><a class="sidenav-trigger sideout" data-target="slide-out-right17">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#T_ProviderName").combobox();


});
function TPatientProviderName() {
    if (globalValue != "") {
        $(".TproviderName").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Teritary Insurance Group Number*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="TPatientGroupName();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right18"><a class="sidenav-trigger sideout" data-target="slide-out-right18">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#T_GroupName").combobox();


});
function TPatientGroupName() {
    if (globalValue != "") {
        $(".Teritary_groupNumber").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient P.I Legal Statu*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientPiLegalStatus();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right10"><a class="sidenav-trigger sideout" data-target="slide-out-right10">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#PI_legalStatus").combobox();


});
function PatientPiLegalStatus() {
    if (globalValue != "") {
        $(".pi_Legal").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Collection/Arbitration Firm Name*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientFirmNames();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right19"><a class="sidenav-trigger sideout" data-target="slide-out-right19">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#FirmName").combobox();


});
function PatientFirmNames() {
    if (globalValue != "") {
        $(".Firm_name").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Collection/Arbitration Attorney Name*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientAttoreyName();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right20"><a class="sidenav-trigger sideout" data-target="slide-out-right20">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#Patient_AttoneyName").combobox();


});
function PatientAttoreyName() {
    if (globalValue != "") {
        $(".attorney_name").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Personal Injury Attoreny*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PIAttoreyName();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right25"><a class="sidenav-trigger sideout" data-target="slide-out-right25">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#PI_AttoneyName").combobox();


});
function PIAttoreyName() {
    if (globalValue != "") {
        $(".attorney_name").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*PI Firm*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientPIFirmNames();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right27"><a class="sidenav-trigger sideout" data-target="slide-out-right27">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#PIFirmName").combobox();


});
function PatientPIFirmNames() {
    if (globalValue != "") {
        $(".Firm_name").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*PI Leading Attorney*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientPILeadingAttoreyName();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right28"><a class="sidenav-trigger sideout" data-target="slide-out-right29">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#PI_leadingAttorneyName").combobox();


});
function PatientPILeadingAttoreyName() {
    if (globalValue != "") {
        $(".leadingAttoney_name").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*PI Leading Paralegal Name*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientPiLeadingParalegalName();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right29"><a class="sidenav-trigger sideout" data-target="slide-out-right29">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#PI_leadingParalegalName").combobox();


});
function PatientPiLeadingParalegalName() {
    if (globalValue != "") {
        $(".leadingParalegal_name").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Collection/Arbitration Leading Attorney Name*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientLeadingAttoreyName();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right21"><a class="sidenav-trigger sideout" data-target="slide-out-right21">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#Patient_leadingAttorneyName").combobox();


});
function PatientLeadingAttoreyName() {
    if (globalValue != "") {
        $(".leadingAttoney_name").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Collection/Arbitration Leading Paralegal Name*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientLeadingParalegalName();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right22"><a class="sidenav-trigger sideout" data-target="slide-out-right22">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#Patinet_leadingParalegalName").combobox();


});
function PatientLeadingParalegalName() {
    if (globalValue != "") {
        $(".leadingParalegal_name").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/*Patient Collection/Arbitration Legal Status*/
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="PatientCollectionLegalInfo();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right11"><a class="sidenav-trigger sideout" data-target="slide-out-right11">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: "No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$("#Collection_LegalStatus").combobox();


});
function PatientCollectionLegalInfo() {
    if (globalValue != "") {
        $(".colletionlegal_status").val(globalValue);
    }
    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

/* Vehicle Insurance Provider */
$(function () {
    var addnew = '<li class="ui-menu-item" id="addnew" onClick="InsurandropdownCheck();"><div class="ui-menu-item-wrapper sidenav-trigger sideout"  href="javascript:void(0);" data-target="slide-out-right9"><a class="sidenav-trigger sideout" data-target="slide-out-right2">Add New</a></div></li>';

    $.widget("custom.combobox", {
        _create: function () {
            this.wrapper = $("<span>")
                .addClass("custom-combobox")
                .insertAfter(this.element);

            this.element.hide();
            this._createAutocomplete();
            this._createShowAllButton();
        },

        _createAutocomplete: function () {
            var selected = this.element.children(":selected"),
                value = selected.val() ? selected.text() : "";

            this.input = $("<input>")
                .appendTo(this.wrapper)
                .val(value)
                .attr("title", "")
                .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                .autocomplete({
                    delay: 0,
                    minLength: 0,
                    source: $.proxy(this, "_source"),
                    open: function (e, ui) {
                        $(".ui-autocomplete").append(addnew);
                    },

                    response: function (event, ui) {
                        if (!ui.content.length) {
                            var noResult = { value: "", label: " No results found" };
                            ui.content.push(noResult);
                        }
                    }
                })
                .tooltip({
                    classes: {
                        "ui-tooltip": "ui-state-highlight"
                    }
                });

            this._on(this.input, {
                autocompleteselect: function (event, ui) {
                    ui.item.option.selected = true;
                    this._trigger("select", event, {
                        item: ui.item.option
                    });
                },

                autocompletechange: "_removeIfInvalid"
            });
        },

        _createShowAllButton: function () {

            var input = this.input,
                wasOpen = false;

            $("<a>")
                .attr("tabIndex", -1)
                .attr("title", "Show All Items")

                .appendTo(this.wrapper)
                .button({
                    icons: {
                        primary: "ui-icon-triangle-1-s"
                    },
                    text: false
                })
                .removeClass("ui-corner-all")
                .addClass("custom-combobox-toggle ui-corner-right")
                .on("mousedown", function () {
                    wasOpen = input.autocomplete("widget").is(":visible");
                })
                .on("click", function () {
                    input.trigger("focus");

                    // Close if already visible
                    if (wasOpen) {
                        return;
                    }

                    // Pass empty string as value to search for, displaying all results
                    input.autocomplete("search", "");
                });
        },

        _source: function (request, response) {
            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
            response(this.element.children("option").map(function () {

                var text = $(this).text();
                if (this.value && (!request.term || matcher.test(text)))
                    return {
                        label: text,
                        value: text,
                        option: this
                    };
            }));
            globalValue = this.input.val();

        },

        _removeIfInvalid: function (event, ui) {

            // Selected an item, nothing to do
            if (ui.item) {
                return;
            }

            // Search for a match (case-insensitive)
            var value = this.input.val(),
                valueLowerCase = value.toLowerCase(),
                valid = false;


            this.element.children("option").each(function () {
                if ($(this).text().toLowerCase() === valueLowerCase) {
                    this.selected = valid = true;
                    return false;
                }
            });

            // Found a match, nothing to do
            if (valid) {

                return;
            }

            //Remove invalid value

            //this.input
            //    .val("")
            //    .attr("title", value + " didn't match any item");
            //.tooltip("open");

            //this.element.val("");
            //this._delay(function () {
            //    this.input.tooltip("close").attr("title", "");
            //}, 2500);
            //this.input.autocomplete("instance").term = "";
        },

        _destroy: function () {
            this.wrapper.remove();
            this.element.show();
        }
    });

    //$(".vehicleInsurance").combobox();


});
function InsurandropdownCheck() {

    if (globalValue != "") {
        $(".SignIdType").val(globalValue);
    }

    $(".nav-collapsible .navbar-toggler").trigger("click");
    $("#main").css("padding-right", "340px");

}

function onProviderCreate(data) {
    var form = $("#patientinfo").serializeArray();
    var formData = new FormData();
    formData.append("providerViewModel", form);

    //if ($("#provider-form").valid()) {
    $.ajax({

        type: "POST",
        url: '@Url.Action("Patientinfo", "PatientSide")',
        data: formData,
        contentType: false,
        processData: false,
        success: function (data) {
            debugger;
            var success = data.Success;
            new PNotify({
                title: 'Success!',
                text: success,
                delay: 5000,
                type: 'success',
                addclass: 'pnotify-center'
            });

            $('#PatientInfo_UserId').val(data);

        },
        error: function (result) {
            alert("Error");
        }
    });
}
function onCreateToDoSuccessPhone(data) {
    debugger;
    var isErrorMessage = data.isError;
    if (isErrorMessage) {
        new PNotify({
            title: 'Error!',
            text: 'Please provide patient info first',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });
    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });
    }

};


function onCreateLeadingAttorney(data) {
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });
        $(".addlegalStatus").val("");

        var statusSelectList = $('.leadingAttorneyName');
        statusSelectList.append($('<option></option>').val(data.leadingAttorneyId).text(data.leadingAttorneyName));

    }
}


function onCreateLeadingParalegal(data) {
    var msg = data.success;
    if (data.isError) {

        new PNotify({
            title: 'Error!',
            text: 'Can not Save, Already In Drop Down',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });

    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });
        $(".addlegalStatus").val("");

        var statusSelectList = $('.leadingParalegalNameCombo');
        statusSelectList.append($('<option></option>').val(data.leadingParalegalId).text(data.leadingParalegalName));

    }
}

function setTabValues() {

    var currentTab = $('#CurrentTabid').val();
    $('#PreviousToShowTabId').val(currentTab);
    $('#PreviousTabid').val(currentTab);
}


function clearForm(form) {

    form.find(':input').not(':button, :submit, :reset, :hidden, :checkbox, :radio').val('');
    form.find(':checkbox, :radio').prop('checked', false);
    $('input').removeClass('valid');
}


var isShow = false;
var isMoveNext = false;

$('.moveOrNot').click(function (event) {
    //var NextTabId = $(this).attr('id');
    debugger;
    var NextTabId = $(event.target).attr('href');
    var currentActive = $("a.moveOrNot.active").attr('href');
    var isNotificationShow = false;

    var form = "";
    //For patientInfo Tab
    if (currentActive == "#test1") {
        if (isEditInfoBtn) {
            isNotificationShow = true;
        }
        else if ($('#infoCancel_btn').attr('data-val') == "NewForm") {
            isNotificationShow = ValidatePatientInfo();
        }
        else {
            isNotificationShow = false;
        }
    }

    //For patientPhone Tab
    else if (currentActive == "#test2") {
        if (isEditPhoneBtn) {
            isNotificationShow = true;
        }
        else if ($('#phoneCancel_btn').attr('data-val') == "NewForm") {
            isNotificationShow = ValidatePatientPhone();
        }
        else {
            isNotificationShow = false;
        }
    }

    //For patientEmergency Tab
    else if (currentActive == "#test3") {

        if (isEditEmergencyBtn) {
            isNotificationShow = true;
        }
        else if ($('#emergenyCancel_btn').attr('data-val') == "NewForm") {
            isNotificationShow = ValidateEmergencyContact();
        }
        else {
            isNotificationShow = false;
        }
    }
    //For patientId & Signature Tab
    else if (currentActive == "#test4") {

        if (isEditIdAndSignatureBtn) {
            isNotificationShow = true;
        }
        else if ($('#emergenyCancel_btn').attr('data-val') == "NewForm") {
            isNotificationShow = ValidatePatientIdAndSignature();
        }
        else {
            isNotificationShow = false;
        }
    }

    else if (currentActive == "#test5") {
        isNotificationShow = ValidateCaseType();
    }

    //For Claim Info Tab
    else if (currentActive == "#test6") {

        if (isEditClaimInfoBtn) {
            isNotificationShow = true;
        }
        else if ($('#claimCancel_btn').attr('data-val') == "NewForm") {
            isNotificationShow = ValidateClaimInfo();
        }
        else {
            isNotificationShow = false;
        }
    }


    else if (currentActive == "#test7") {

        if (isEditVehicleBtn) {
            isNotificationShow = true;
        }
        else if ($('#vehicleCancel_btn').attr('data-val') == "NewForm") {
            isNotificationShow = ValidateVehicles();
        }
        else {
            isNotificationShow = false;
        }
    }

    //For Secondary Form tab
    else if (currentActive == "#test8") {

        if (isEditSecondaryInsuranceBtn) {
            isNotificationShow = true;
        }
        else if ($('#SecondaryCancel_btn').attr('data-val') == "NewForm") {
            isNotificationShow = ValidateSecondary();
        }
        else {
            isNotificationShow = false;
        }
    }

    //For Tertiary Form tab
    else if (currentActive == "#test9") {

        if (isEditTertiaryInsuranceBtn) {
            isNotificationShow = true;
        }
        else if ($('#teriteryCancel_btn').attr('data-val') == "NewForm") {
            isNotificationShow = ValidateTertiary();
        }
        else {
            isNotificationShow = false;
        }
    }

    //For PI Attorney Form tab
    else if (currentActive == "#test10") {

        if (isEditPIBtn) {
            isNotificationShow = true;
        }
        else if ($('#piCancel_btn').attr('data-val') == "NewForm") {
            isNotificationShow = ValidatePI();
        }
        else {
            isNotificationShow = false;
        }
    }

    //For Collection Attorney Tab
    else if (currentActive == "#test11") {

        if (isEditCollectionBtn) {
            isNotificationShow = true;
        }
        else if ($('#collectionCancel_btn').attr('data-val') == "NewForm") {
            isNotificationShow = ValidateCollection();
        }
        else {
            isNotificationShow = false;
        }
    }

    if (isNotificationShow == true) {


        swal({
            title: "Are you sure?",
            text: 'Do you want to save your data before you switch to different form?',
            buttons: {

                Save: {
                    text: "Save",
                    value: "Save"
                },
                Discard: {
                    text: "Discard!",
                    value: "Discard"
                },
                Cancel: {
                    text: "Cancel!",
                    value: "Cancel"
                }

            },
        }).then(function (response) {
            if (response == "Save") {

                //form = $('#patientinfo');
                //$("#patientinfo").valid();
                //$('#info_btn').trigger('click');
                if (currentActive == "#test1") {

                    if (NextTabId == "#test2") {
                        var validate = $("#patientinfo").valid();
                        if (validate) {
                            $('#info_btn').trigger('click');
                        }
                        if (validate) {
                            //if (isInfoButtonClick == false) {
                            //    $('#info_btn').trigger('click');
                            //}
                            $('a[href="#test1"]').removeClass('active');
                            $('a[href="#test2"]').addClass('active');
                            $('#test1').hide();
                            $('#test2').show();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }
                    }

                    else if (NextTabId == "#test3") {
                        var validate = $("#patientinfo").valid();
                        if (validate) {
                            $('#info_btn').trigger('click');
                        }
                        if (validate) {
                            //if (isInfoButtonClick == false) {
                            //    $('#info_btn').trigger('click');
                            //}
                            $('a[href="#test1"]').removeClass('active');
                            $('a[href="#test3"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').show();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test4") {
                        var validate = $("#patientinfo").valid();
                        if (validate) {
                            $('#info_btn').trigger('click');
                        }
                        if (validate) {
                            //if (isInfoButtonClick == false) {
                            //    $('#info_btn').trigger('click');
                            //}
                            $('a[href="#test1"]').removeClass('active');
                            $('a[href="#test4"]').addClass('active');
                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').show();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }
                    }

                    else if (NextTabId == "#test5") {
                        var validate = $("#patientinfo").valid();
                        if (validate) {
                            $('#info_btn').trigger('click');
                        }
                        if (validate) {
                            //if (isInfoButtonClick == false) {
                            //    $('#info_btn').trigger('click');
                            //}
                            $('a[href="#test1"]').removeClass('active');
                            $('a[href="#test5"]').addClass('active');
                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').show();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }
                    }

                    else if (NextTabId == "#test6") {
                        var validate = $("#patientinfo").valid();
                        if (validate) {
                            $('#info_btn').trigger('click');
                        }
                        if (validate) {
                            //if (isInfoButtonClick == false) {
                            //    $('#info_btn').trigger('click');
                            //}
                            $('a[href="#test1"]').removeClass('active');
                            $('a[href="#test6"]').addClass('active');
                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').show();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }
                    }

                    else if (NextTabId == "#test7") {
                        var validate = $("#patientinfo").valid();
                        if (validate) {
                            $('#info_btn').trigger('click');
                        }
                        if (validate) {
                            //if (isInfoButtonClick == false) {
                            //    $('#info_btn').trigger('click');
                            //}
                            $('a[href="#test1"]').removeClass('active');
                            $('a[href="#test7"]').addClass('active');
                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').show();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test8") {
                        var validate = $("#patientinfo").valid();
                        if (validate) {
                            $('#info_btn').trigger('click');
                        }
                        if (validate) {
                            //if (isInfoButtonClick == false) {
                            //    $('#info_btn').trigger('click');
                            //}
                            $('a[href="#test1"]').removeClass('active');
                            $('a[href="#test8"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').show();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test9") {
                        var validate = $("#patientinfo").valid();
                        if (validate) {
                            $('#info_btn').trigger('click');
                        }
                        if (validate) {
                            //if (isInfoButtonClick == false) {
                            //    $('#info_btn').trigger('click');
                            //}
                            $('a[href="#test1"]').removeClass('active');
                            $('a[href="#test9"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').show();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test10") {
                        var validate = $("#patientinfo").valid();
                        if (validate) {
                            $('#info_btn').trigger('click');
                        }
                        if (validate) {
                            //if (isInfoButtonClick == false) {
                            //    $('#info_btn').trigger('click');
                            //}
                            $('a[href="#test1"]').removeClass('active');
                            $('a[href="#test10"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').show();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test11") {
                        var validate = $("#patientinfo").valid();
                        if (validate) {
                            $('#info_btn').trigger('click');
                        }
                        if (validate) {
                            //if (isInfoButtonClick == false) {
                            //    $('#info_btn').trigger('click');
                            //}
                            $('a[href="#test1"]').removeClass('active');
                            $('a[href="#test11"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').show();
                        }

                    }


                }

                else if (currentActive == "#test2") {

                    if (NextTabId == "#test1") {
                        var phonevalidate = $("#patientPhoneNumberForm").valid();

                        if (phonevalidate) {
                            if (isPhoneButtonClick == false) {
                                $('#phone_btn').trigger('click');
                            }
                            $('a[href="#test2"]').removeClass('active');
                            $('a[href="#test1"]').addClass('active');

                            $('#test1').show();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test3") {
                        var phonevalidate = $("#patientPhoneNumberForm").valid();

                        if (phonevalidate) {
                            if (isPhoneButtonClick == false) {
                                $('#phone_btn').trigger('click');
                            }
                            $('a[href="#test2"]').removeClass('active');
                            $('a[href="#test3"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').show();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test4") {
                        var phonevalidate = $("#patientPhoneNumberForm").valid();

                        if (phonevalidate) {
                            if (isPhoneButtonClick == false) {
                                $('#phone_btn').trigger('click');
                            }
                            $('a[href="#test2"]').removeClass('active');
                            $('a[href="#test4"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').show();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test5") {
                        var phonevalidate = $("#patientPhoneNumberForm").valid();

                        if (phonevalidate) {
                            if (isPhoneButtonClick == false) {
                                $('#phone_btn').trigger('click');
                            }
                            $('a[href="#test2"]').removeClass('active');
                            $('a[href="#test5"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').show();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test6") {
                        var phonevalidate = $("#patientPhoneNumberForm").valid();

                        if (phonevalidate) {
                            if (isPhoneButtonClick == false) {
                                $('#phone_btn').trigger('click');
                            }
                            $('a[href="#test2"]').removeClass('active');
                            $('a[href="#test6"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').show();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test7") {
                        var phonevalidate = $("#patientPhoneNumberForm").valid();

                        if (phonevalidate) {
                            if (isPhoneButtonClick == false) {
                                $('#phone_btn').trigger('click');
                            }
                            $('a[href="#test2"]').removeClass('active');
                            $('a[href="#test7"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').show();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }
                    }

                    else if (NextTabId == "#test8") {
                        var phonevalidate = $("#patientPhoneNumberForm").valid();

                        if (phonevalidate) {
                            if (isPhoneButtonClick == false) {
                                $('#phone_btn').trigger('click');
                            }
                            $('a[href="#test2"]').removeClass('active');
                            $('a[href="#test8"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').show();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test9") {
                        var phonevalidate = $("#patientPhoneNumberForm").valid();

                        if (phonevalidate) {
                            if (isPhoneButtonClick == false) {
                                $('#phone_btn').trigger('click');
                            }
                            $('a[href="#test2"]').removeClass('active');
                            $('a[href="#test9"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').show();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test10") {
                        var phonevalidate = $("#patientPhoneNumberForm").valid();

                        if (phonevalidate) {
                            if (isPhoneButtonClick == false) {
                                $('#phone_btn').trigger('click');
                            }
                            $('a[href="#test2"]').removeClass('active');
                            $('a[href="#test10"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').show();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test11") {
                        var phonevalidate = $("#patientPhoneNumberForm").valid();

                        if (phonevalidate) {
                            if (isPhoneButtonClick == false) {
                                $('#phone_btn').trigger('click');
                            }
                            $('a[href="#test2"]').removeClass('active');
                            $('a[href="#test11"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').show();
                        }

                    }

                }

                else if (currentActive == "#test3") {

                    if (NextTabId == "#test1") {
                        var emergvalidate = $("#phoneForm").valid();

                        if (emergvalidate) {
                            if (isEmergencyButtonClick == false) {
                                $('#emerGcyBtn').trigger('click');
                            }
                            $('a[href="#test3"]').removeClass('active');
                            $('a[href="#test1"]').addClass('active');

                            $('#test1').show();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test2") {
                        var emergvalidate = $("#phoneForm").valid();

                        if (emergvalidate) {
                            if (isEmergencyButtonClick == false) {
                                $('#emerGcyBtn').trigger('click');
                            }
                            $('a[href="#test3"]').removeClass('active');
                            $('a[href="#test2"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').show();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test4") {
                        var emergvalidate = $("#phoneForm").valid();

                        if (emergvalidate) {
                            if (isEmergencyButtonClick == false) {
                                $('#emerGcyBtn').trigger('click');
                            }
                            $('a[href="#test3"]').removeClass('active');
                            $('a[href="#test4"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').show();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test5") {
                        var emergvalidate = $("#phoneForm").valid();

                        if (emergvalidate) {
                            if (isEmergencyButtonClick == false) {
                                $('#emerGcyBtn').trigger('click');
                            }
                            $('a[href="#test3"]').removeClass('active');
                            $('a[href="#test5"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').show();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test6") {
                        var validate = $("#phoneForm").valid();

                        if (validate) {
                            if (isEmergencyButtonClick == false) {
                                $('#emerGcyBtn').trigger('click');
                            }
                            $('a[href="#test3"]').removeClass('active');
                            $('a[href="#test6"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').show();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test7") {
                        var validate = $("#phoneForm").valid();

                        if (validate) {
                            if (isEmergencyButtonClick == false) {
                                $('#emerGcyBtn').trigger('click');
                            }
                            $('a[href="#test3"]').removeClass('active');
                            $('a[href="#test7"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').show();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test8") {
                        var validate = $("#phoneForm").valid();

                        if (validate) {
                            if (isEmergencyButtonClick == false) {
                                $('#emerGcyBtn').trigger('click');
                            }
                            $('a[href="#test3"]').removeClass('active');
                            $('a[href="#test8"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').show();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test9") {
                        var validate = $("#phoneForm").valid();

                        if (validate) {
                            if (isEmergencyButtonClick == false) {
                                $('#emerGcyBtn').trigger('click');
                            }
                            $('a[href="#test3"]').removeClass('active');
                            $('a[href="#test9"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').show();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test10") {
                        var validate = $("#phoneForm").valid();

                        if (validate) {
                            if (isEmergencyButtonClick == false) {
                                $('#emerGcyBtn').trigger('click');
                            }
                            $('a[href="#test3"]').removeClass('active');
                            $('a[href="#test10"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').show();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test11") {
                        var validate = $("#phoneForm").valid();

                        if (validate) {
                            if (isEmergencyButtonClick == false) {
                                $('#emerGcyBtn').trigger('click');
                            }
                            $('a[href="#test3"]').removeClass('active');
                            $('a[href="#test11"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').show();

                        }



                    }

                }

                else if (currentActive == "#test4") {

                    var SignValidate = $("#signatureform").valid();

                    if (NextTabId == "#test1") {
                        if (SignValidate) {
                            if (isSignatureButtonClick == false) {
                                $('#upload').trigger('click');
                            }
                            $('a[href="#test4"]').removeClass('active');
                            $('a[href="#test1"]').addClass('active');

                            $('#test1').show();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test2") {
                        if (SignValidate) {
                            if (isSignatureButtonClick == false) {
                                $('#upload').trigger('click');
                            }
                            $('a[href="#test4"]').removeClass('active');
                            $('a[href="#test2"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').show();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test3") {
                        if (SignValidate) {
                            if (isSignatureButtonClick == false) {
                                $('#upload').trigger('click');
                            }
                            $('a[href="#test4"]').removeClass('active');
                            $('a[href="#test3"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').show();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }


                    else if (NextTabId == "#test5") {
                        if (SignValidate) {

                            if (isSignatureButtonClick == false) {
                                $('#upload').trigger('click');
                            }
                            $('a[href="#test4"]').removeClass('active');
                            $('a[href="#test5"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').show();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test6") {
                        if (SignValidate) {
                            if (isSignatureButtonClick == false) {
                                $('#upload').trigger('click');
                            }
                            $('a[href="#test4"]').removeClass('active');
                            $('a[href="#test6"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').show();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test7") {
                        if (SignValidate) {
                            if (isSignatureButtonClick == false) {
                                $('#upload').trigger('click');
                            }
                            $('a[href="#test4"]').removeClass('active');
                            $('a[href="#test7"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').show();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test8") {
                        if (SignValidate) {
                            if (isSignatureButtonClick == false) {
                                $('#upload').trigger('click');
                            }
                            $('a[href="#test4"]').removeClass('active');
                            $('a[href="#test8"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').show();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test9") {
                        if (SignValidate) {
                            if (isSignatureButtonClick == false) {
                                $('#upload').trigger('click');
                            }
                            $('a[href="#test4"]').removeClass('active');
                            $('a[href="#test9"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').show();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test10") {
                        if (SignValidate) {
                            if (isSignatureButtonClick == false) {
                                $('#upload').trigger('click');
                            }
                            $('a[href="#test4"]').removeClass('active');
                            $('a[href="#test10"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').show();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test11") {
                        if (SignValidate) {
                            if (isSignatureButtonClick == false) {
                                $('#upload').trigger('click');
                            }
                            $('a[href="#test4"]').removeClass('active');
                            $('a[href="#test11"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').show();
                        }

                    }

                }

                else if (currentActive == "#test5") {

                    var CaseValidate = $("#caseTypeFormId").valid();

                    if (NextTabId == "#test1") {
                        if (CaseValidate) {
                            if (isCastTypeButtonClick == false) {
                                $('#patientCaseType').trigger('click');
                            }
                            $('a[href="#test5"]').removeClass('active');
                            $('a[href="#test1"]').addClass('active');

                            $('#test1').show();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test2") {
                        if (CaseValidate) {
                            if (isCastTypeButtonClick == false) {
                                $('#patientCaseType').trigger('click');
                            }
                            $('a[href="#test5"]').removeClass('active');
                            $('a[href="#test2"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').show();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test3") {
                        if (CaseValidate) {
                            if (isCastTypeButtonClick == false) {
                                $('#patientCaseType').trigger('click');
                            }
                            $('a[href="#test5"]').removeClass('active');
                            $('a[href="#test3"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').show();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test4") {
                        if (CaseValidate) {
                            if (isCastTypeButtonClick == false) {
                                $('#patientCaseType').trigger('click');
                            }
                            $('a[href="#test5"]').removeClass('active');
                            $('a[href="#test4"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').show();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }


                    else if (NextTabId == "#test6") {
                        if (CaseValidate) {
                            if (isCastTypeButtonClick == false) {
                                $('#patientCaseType').trigger('click');
                            }
                            $('a[href="#test5"]').removeClass('active');
                            $('a[href="#test6"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').show();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test7") {
                        if (CaseValidate) {
                            if (isCastTypeButtonClick == false) {
                                $('#patientCaseType').trigger('click');
                            }
                            $('a[href="#test5"]').removeClass('active');
                            $('a[href="#test7"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').show();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test8") {
                        if (CaseValidate) {
                            if (isCastTypeButtonClick == false) {
                                $('#patientCaseType').trigger('click');
                            }
                            $('a[href="#test5"]').removeClass('active');
                            $('a[href="#test8"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').show();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test9") {
                        if (CaseValidate) {
                            if (isCastTypeButtonClick == false) {
                                $('#patientCaseType').trigger('click');
                            }
                            $('a[href="#test5"]').removeClass('active');
                            $('a[href="#test9"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').show();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test10") {
                        if (CaseValidate) {
                            if (isCastTypeButtonClick == false) {
                                $('#patientCaseType').trigger('click');
                            }
                            $('a[href="#test5"]').removeClass('active');
                            $('a[href="#test10"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').show();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test11") {
                        if (CaseValidate) {
                            if (isCastTypeButtonClick == false) {
                                $('#patientCaseType').trigger('click');
                            }
                            $('a[href="#test5"]').removeClass('active');
                            $('a[href="#test11"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').show();
                        }

                    }
                }

                else if (currentActive == "#test6") {

                    var ClaimValidate = $("#patientClaimForm").valid();
                    $('#btnPatientClaimInfo').trigger('click');

                    if (NextTabId == "#test1") {
                        if (ClaimValidate) {

                            $('a[href="#test6"]').removeClass('active');
                            $('a[href="#test1"]').addClass('active');

                            $('#test1').show();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test2") {
                        if (ClaimValidate) {
                            $('a[href="#test6"]').removeClass('active');
                            $('a[href="#test2"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').show();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test3") {
                        if (ClaimValidate) {
                            $('a[href="#test6"]').removeClass('active');
                            $('a[href="#test3"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').show();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test4") {
                        if (ClaimValidate) {
                            $('a[href="#test6"]').removeClass('active');
                            $('a[href="#test4"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').show();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test5") {
                        if (ClaimValidate) {
                            $('a[href="#test6"]').removeClass('active');
                            $('a[href="#test5"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').show();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }


                    else if (NextTabId == "#test7") {
                        if (ClaimValidate) {
                            $('a[href="#test6"]').removeClass('active');
                            $('a[href="#test7"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').show();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test8") {
                        if (ClaimValidate) {
                            $('a[href="#test6"]').removeClass('active');
                            $('a[href="#test8"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').show();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test9") {
                        if (ClaimValidate) {
                            $('a[href="#test6"]').removeClass('active');
                            $('a[href="#test9"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').show();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test10") {
                        if (ClaimValidate) {
                            $('a[href="#test6"]').removeClass('active');
                            $('a[href="#test10"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').show();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test11") {
                        if (ClaimValidate) {
                            $('a[href="#test6"]').removeClass('active');
                            $('a[href="#test11"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').show();
                        }

                    }
                }

                else if (currentActive == "#test7") {
                    // var VehicleValidate = $("#patientVehicleForm").valid();

                    var VehicleValidate = isNotificationShow;


                    if (NextTabId == "#test1") {
                        if (VehicleValidate) {
                            if (isVehicleButtonClick == false) {
                                $('#Vehiclebtn').trigger('click');
                            }
                            $('a[href="#test7"]').removeClass('active');
                            $('a[href="#test1"]').addClass('active');

                            $('#test1').show();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test2") {
                        if (VehicleValidate) {
                            if (isVehicleButtonClick == false) {
                                $('#Vehiclebtn').trigger('click');
                            }
                            $('a[href="#test7"]').removeClass('active');
                            $('a[href="#test2"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').show();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test3") {
                        if (VehicleValidate) {
                            if (isVehicleButtonClick == false) {
                                $('#Vehiclebtn').trigger('click');
                            }
                            $('a[href="#test7"]').removeClass('active');
                            $('a[href="#test3"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').show();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test4") {
                        if (VehicleValidate) {
                            if (isVehicleButtonClick == false) {
                                $('#Vehiclebtn').trigger('click');
                            }
                            $('a[href="#test7"]').removeClass('active');
                            $('a[href="#test4"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').show();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test5") {
                        if (VehicleValidate) {
                            if (isVehicleButtonClick == false) {
                                $('#Vehiclebtn').trigger('click');
                            }
                            $('a[href="#test7"]').removeClass('active');
                            $('a[href="#test5"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').show();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test6") {
                        if (VehicleValidate) {
                            if (isVehicleButtonClick == false) {
                                $('#Vehiclebtn').trigger('click');
                            }
                            $('a[href="#test7"]').removeClass('active');
                            $('a[href="#test6"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').show();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }
                    }


                    else if (NextTabId == "#test8") {
                        if (VehicleValidate) {
                            if (isVehicleButtonClick == false) {
                                $('#Vehiclebtn').trigger('click');
                            }
                            $('a[href="#test7"]').removeClass('active');
                            $('a[href="#test8"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').show();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test9") {
                        if (VehicleValidate) {
                            if (isVehicleButtonClick == false) {
                                $('#Vehiclebtn').trigger('click');
                            }
                            $('a[href="#test7"]').removeClass('active');
                            $('a[href="#test9"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').show();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test10") {
                        if (VehicleValidate) {
                            if (isVehicleButtonClick == false) {
                                $('#Vehiclebtn').trigger('click');
                            }
                            $('a[href="#test7"]').removeClass('active');
                            $('a[href="#test10"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').show();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test11") {
                        if (VehicleValidate) {
                            if (isVehicleButtonClick == false) {
                                $('#Vehiclebtn').trigger('click');
                            }
                            $('a[href="#test7"]').removeClass('active');
                            $('a[href="#test11"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').show();
                        }

                    }
                }

                else if (currentActive == "#test8") {
                    var SecondaryValidate = $("#PatientSecondaryInsuranceForm").valid();

                    if (NextTabId == "#test1") {
                        if (SecondaryValidate) {
                            if (isSecondaryButtonClick == false) {
                                $('#btnPatientSecondary').trigger('click');
                            }
                            $('a[href="#test8"]').removeClass('active');
                            $('a[href="#test1"]').addClass('active');

                            $('#test1').show();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test2") {
                        if (SecondaryValidate) {
                            if (isSecondaryButtonClick == false) {
                                $('#btnPatientSecondary').trigger('click');
                            }
                            $('a[href="#test8"]').removeClass('active');
                            $('a[href="#test2"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').show();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test3") {
                        if (SecondaryValidate) {
                            if (isSecondaryButtonClick == false) {
                                $('#btnPatientSecondary').trigger('click');
                            }
                            $('a[href="#test8"]').removeClass('active');
                            $('a[href="#test3"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').show();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test4") {
                        if (SecondaryValidate) {
                            if (isSecondaryButtonClick == false) {
                                $('#btnPatientSecondary').trigger('click');
                            }
                            $('a[href="#test8"]').removeClass('active');
                            $('a[href="#test4"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').show();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test5") {
                        if (SecondaryValidate) {
                            if (isSecondaryButtonClick == false) {
                                $('#btnPatientSecondary').trigger('click');
                            }
                            $('a[href="#test8"]').removeClass('active');
                            $('a[href="#test5"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').show();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test6") {
                        if (SecondaryValidate) {
                            if (isSecondaryButtonClick == false) {
                                $('#btnPatientSecondary').trigger('click');
                            }
                            $('a[href="#test8"]').removeClass('active');
                            $('a[href="#test6"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').show();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test7") {
                        if (SecondaryValidate) {
                            if (isSecondaryButtonClick == false) {
                                $('#btnPatientSecondary').trigger('click');
                            }
                            $('a[href="#test8"]').removeClass('active');
                            $('a[href="#test7"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').show();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }



                    else if (NextTabId == "#test9") {
                        if (SecondaryValidate) {
                            if (isSecondaryButtonClick == false) {
                                $('#btnPatientSecondary').trigger('click');
                            }

                            $('a[href="#test8"]').removeClass('active');
                            $('a[href="#test9"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').show();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test10") {
                        if (SecondaryValidate) {
                            if (isSecondaryButtonClick == false) {
                                $('#btnPatientSecondary').trigger('click');
                            }
                            $('a[href="#test8"]').removeClass('active');
                            $('a[href="#test10"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').show();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test11") {
                        if (SecondaryValidate) {
                            if (isSecondaryButtonClick == false) {
                                $('#btnPatientSecondary').trigger('click');
                            }
                            $('a[href="#test8"]').removeClass('active');
                            $('a[href="#test11"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').show();
                        }

                    }
                }

                else if (currentActive == "#test9") {
                    var TeritareyValide = $("#patientTeritaryInsurance").valid();


                    if (NextTabId == "#test1") {
                        if (TeritareyValide) {
                            if (isTertiaryButtonClick == false) {
                                $('#btnPatientTerit').trigger('click');
                            }
                            $('a[href="#test9"]').removeClass('active');
                            $('a[href="#test1"]').addClass('active');

                            $('#test1').show();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test2") {
                        if (TeritareyValide) {
                            if (isTertiaryButtonClick == false) {
                                $('#btnPatientTerit').trigger('click');
                            }
                            $('a[href="#test9"]').removeClass('active');
                            $('a[href="#test2"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').show();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test3") {
                        if (TeritareyValide) {
                            if (isTertiaryButtonClick == false) {
                                $('#btnPatientTerit').trigger('click');
                            }
                            $('a[href="#test9"]').removeClass('active');
                            $('a[href="#test3"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').show();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test4") {
                        if (TeritareyValide) {
                            if (isTertiaryButtonClick == false) {
                                $('#btnPatientTerit').trigger('click');
                            }
                            $('a[href="#test9"]').removeClass('active');
                            $('a[href="#test4"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').show();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test5") {
                        if (TeritareyValide) {
                            if (isTertiaryButtonClick == false) {
                                $('#btnPatientTerit').trigger('click');
                            }
                            $('a[href="#test9"]').removeClass('active');
                            $('a[href="#test5"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').show();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test6") {
                        if (TeritareyValide) {
                            if (isTertiaryButtonClick == false) {
                                $('#btnPatientTerit').trigger('click');
                            }
                            $('a[href="#test9"]').removeClass('active');
                            $('a[href="#test6"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').show();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test7") {
                        if (TeritareyValide) {
                            if (isTertiaryButtonClick == false) {
                                $('#btnPatientTerit').trigger('click');
                            }
                            $('a[href="#test9"]').removeClass('active');
                            $('a[href="#test7"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').show();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test8") {
                        if (TeritareyValide) {
                            if (isTertiaryButtonClick == false) {
                                $('#btnPatientTerit').trigger('click');
                            }
                            $('a[href="#test9"]').removeClass('active');
                            $('a[href="#test8"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').show();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }


                    else if (NextTabId == "#test10") {
                        if (TeritareyValide) {
                            if (isTertiaryButtonClick == false) {
                                $('#btnPatientTerit').trigger('click');
                            }
                            $('a[href="#test9"]').removeClass('active');
                            $('a[href="#test10"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').show();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test11") {
                        if (TeritareyValide) {
                            if (isTertiaryButtonClick == false) {
                                $('#btnPatientTerit').trigger('click');
                            }
                            $('a[href="#test9"]').removeClass('active');
                            $('a[href="#test11"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').show();
                        }

                    }
                }

                else if (currentActive == "#test10") {
                    var PIValidate = $("#patientPersonalInjuryForm").valid();
                    if (PIValidate) {
                        $('#btnPatientPI').trigger('click');
                    }

                    if (NextTabId == "#test1") {
                        if (PIValidate) {
                            //if (isPIButtonClick == false) {
                            //}
                            //$('#btnPatientPI').trigger('click');

                            $('a[href="#test10"]').removeClass('active');
                            $('a[href="#test1"]').addClass('active');

                            $('#test1').show();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test2") {
                        if (PIValidate) {
                            //if (isPIButtonClick == false) {
                            //    $('#btnPatientPI').trigger('click');
                            //}
                            $('a[href="#test10"]').removeClass('active');
                            $('a[href="#test2"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').show();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test3") {
                        if (PIValidate) {
                            //if (isPIButtonClick == false) {
                            //    $('#btnPatientPI').trigger('click');
                            //}
                            $('a[href="#test10"]').removeClass('active');
                            $('a[href="#test3"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').show();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test4") {
                        if (PIValidate) {
                            //if (isPIButtonClick == false) {
                            //    $('#btnPatientPI').trigger('click');
                            //}
                            $('a[href="#test10"]').removeClass('active');
                            $('a[href="#test4"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').show();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test5") {
                        if (PIValidate) {
                            //if (isPIButtonClick == false) {
                            //    $('#btnPatientPI').trigger('click');
                            //}
                            $('a[href="#test10"]').removeClass('active');
                            $('a[href="#test5"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').show();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test6") {
                        if (PIValidate) {
                            //if (isPIButtonClick == false) {
                            //    $('#btnPatientPI').trigger('click');
                            //}
                            $('a[href="#test10"]').removeClass('active');
                            $('a[href="#test6"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').show();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test7") {
                        if (PIValidate) {
                            //if (isPIButtonClick == false) {
                            //    $('#btnPatientPI').trigger('click');
                            //}
                            $('a[href="#test10"]').removeClass('active');
                            $('a[href="#test7"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').show();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test8") {
                        if (PIValidate) {
                            //if (isPIButtonClick == false) {
                            //    $('#btnPatientPI').trigger('click');
                            //}
                            $('a[href="#test10"]').removeClass('active');
                            $('a[href="#test8"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').show();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test9") {
                        if (PIValidate) {
                            //if (isPIButtonClick == false) {
                            //    $('#btnPatientPI').trigger('click');
                            //}
                            $('a[href="#test10"]').removeClass('active');
                            $('a[href="#test9"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').show();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }


                    else if (NextTabId == "#test11") {
                        if (PIValidate) {
                            //if (isPIButtonClick == false) {
                            //    $('#btnPatientPI').trigger('click');
                            //}
                            $('a[href="#test10"]').removeClass('active');
                            $('a[href="#test11"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').show();
                        }

                    }
                }

                else if (currentActive == "#test11") {

                    var ArbitrationValidate = $("#patientArbitrationAttorneyForm").valid();
                    if (ArbitrationValidate) {
                        $('#btnPatientCollection').trigger('click');
                    }

                    if (NextTabId == "#test1") {
                        if (ArbitrationValidate) {
                            //if (isCollectionButtonClick == false) {
                            //    $('#btnPatientCollection').trigger('click');
                            //}
                            $('a[href="#test11"]').removeClass('active');
                            $('a[href="#test1"]').addClass('active');

                            $('#test1').show();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test2") {
                        if (ArbitrationValidate) {
                            //if (isCollectionButtonClick == false) {
                            //    $('#btnPatientCollection').trigger('click');
                            //}
                            $('a[href="#test11"]').removeClass('active');
                            $('a[href="#test2"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').show();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test3") {
                        if (ArbitrationValidate) {
                            //if (isCollectionButtonClick == false) {
                            //    $('#btnPatientCollection').trigger('click');
                            //}
                            $('a[href="#test11"]').removeClass('active');
                            $('a[href="#test3"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').show();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test4") {
                        if (ArbitrationValidate) {
                            //if (isCollectionButtonClick == false) {
                            //    $('#btnPatientCollection').trigger('click');
                            //}
                            $('a[href="#test11"]').removeClass('active');
                            $('a[href="#test4"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').show();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test5") {
                        if (ArbitrationValidate) {
                            //if (isCollectionButtonClick == false) {
                            //    $('#btnPatientCollection').trigger('click');
                            //}
                            $('a[href="#test11"]').removeClass('active');
                            $('a[href="#test5"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').show();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test6") {
                        if (ArbitrationValidate) {
                            //if (isCollectionButtonClick == false) {
                            //    $('#btnPatientCollection').trigger('click');
                            //}
                            $('a[href="#test11"]').removeClass('active');
                            $('a[href="#test6"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').show();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test7") {
                        if (ArbitrationValidate) {
                            //if (isCollectionButtonClick == false) {
                            //    $('#btnPatientCollection').trigger('click');
                            //}
                            $('a[href="#test11"]').removeClass('active');
                            $('a[href="#test7"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').show();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test8") {
                        if (ArbitrationValidate) {
                            //if (isCollectionButtonClick == false) {
                            //    $('#btnPatientCollection').trigger('click');
                            //}
                            $('a[href="#test11"]').removeClass('active');
                            $('a[href="#test8"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').show();
                            $('#test9').hide();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test9") {
                        if (ArbitrationValidate) {
                            //if (isCollectionButtonClick == false) {
                            //    $('#btnPatientCollection').trigger('click');
                            //}
                            $('a[href="#test11"]').removeClass('active');
                            $('a[href="#test9"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').show();
                            $('#test10').hide();
                            $('#test11').hide();
                        }

                    }

                    else if (NextTabId == "#test10") {
                        if (ArbitrationValidate) {
                            //if (isCollectionButtonClick == false) {
                            //    $('#btnPatientCollection').trigger('click');
                            //}
                            $('a[href="#test11"]').removeClass('active');
                            $('a[href="#test10"]').addClass('active');

                            $('#test1').hide();
                            $('#test2').hide();
                            $('#test3').hide();
                            $('#test4').hide();
                            $('#test5').hide();
                            $('#test6').hide();
                            $('#test7').hide();
                            $('#test8').hide();
                            $('#test9').hide();
                            $('#test10').show();
                            $('#test11').hide();
                        }

                    }

                }


            }
            else if (response == "Discard") {
                if (currentActive == "#test1") {
                    form = $('#patientinfo');
                    //clearFields(form);
                    populatePreviousFromWhenDiscard("patientinfo");
                    if (NextTabId == "#test1") {
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }


                }

                else if (currentActive == "#test2") {

                    form = $('#patientPhoneNumberForm');
                    //clearFields(form);
                    populatePreviousFromWhenDiscard("patientPhoneNumber");

                    if (NextTabId == "#test1") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }

                }

                else if (currentActive == "#test3") {
                    form = $('#phoneForm');
                    //clearFields(form);
                    populatePreviousFromWhenDiscard("phoneEmergencyForm");

                    if (NextTabId == "#test1") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }

                }

                else if (currentActive == "#test4") {
                    form = $('#signatureform');
                    clearFields(form);
                    //populatePreviousFromWhenDiscard("signatureform");
                    if (NextTabId == "#test1") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }

                }

                else if (currentActive == "#test5") {
                    form = $('#caseTypeFormId');
                    clearFields(form);

                    if (NextTabId == "#test1") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }

                else if (currentActive == "#test6") {
                    form = $('#patientClaimForm');
                    //clearFields(form);
                    populatePreviousFromWhenDiscard("patientClaimForm");
                    if (NextTabId == "#test1") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }

                else if (currentActive == "#test7") {
                    form = $('#patientVehicleForm');
                    //clearFields(form);
                    populatePreviousFromWhenDiscard("patientVehicleForm");
                    if (NextTabId == "#test1") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }

                else if (currentActive == "#test8") {
                    form = $('#PatientSecondaryInsuranceForm');
                    //clearFields(form);
                    populatePreviousFromWhenDiscard("patientSecondaryForm");

                    if (NextTabId == "#test1") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }

                else if (currentActive == "#test9") {
                    form = $('#patientTeritaryInsurance');
                    //clearFields(form);
                    populatePreviousFromWhenDiscard("patientTertiaryForm");
                    if (NextTabId == "#test1") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }

                else if (currentActive == "#test10") {
                    form = $('#patientPersonalInjuryForm');
                    //clearFields(form);
                    populatePreviousFromWhenDiscard("PersonalInjuryForm");

                    if (NextTabId == "#test1") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }

                else if (currentActive == "#test11") {
                    form = $('#patientArbitrationAttorneyForm');
                    //clearFields(form);
                    populatePreviousFromWhenDiscard("ArbitrationAttorneyForm");
                    if (NextTabId == "#test1") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }
            }

            else if (response == "Cancel") {
                debugger;

                if (currentActive == "#test1") {

                    if (NextTabId == "#test1") {
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test1"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }


                }

                else if (currentActive == "#test2") {

                    if (NextTabId == "#test1") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test2"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }

                }

                else if (currentActive == "#test3") {

                    if (NextTabId == "#test1") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test3"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }

                }

                else if (currentActive == "#test4") {

                    if (NextTabId == "#test1") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test4"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }

                }

                else if (currentActive == "#test5") {

                    if (NextTabId == "#test1") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test5"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }

                else if (currentActive == "#test6") {

                    if (NextTabId == "#test1") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test6"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }

                else if (currentActive == "#test7") {

                    if (NextTabId == "#test1") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test7"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }

                else if (currentActive == "#test8") {

                    if (NextTabId == "#test1") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test8"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }

                else if (currentActive == "#test9") {

                    if (NextTabId == "#test1") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test9"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }

                else if (currentActive == "#test10") {

                    if (NextTabId == "#test1") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test10"]').removeClass('active');
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }

                else if (currentActive == "#test11") {

                    if (NextTabId == "#test1") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test1"]').addClass('active');

                        $('#test1').show();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test2") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test2"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').show();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test3") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test3"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').show();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test4") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test4"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').show();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test5") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test5"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').show();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test6") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test6"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').show();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test7") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test7"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').show();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test8") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test8"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').show();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test9") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test9"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').show();
                        $('#test10').hide();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test10") {
                        $('a[href="#test11"]').removeClass('active');
                        $('a[href="#test10"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').show();
                        $('#test11').hide();
                    }

                    else if (NextTabId == "#test11") {
                        $('a[href="#test11"]').addClass('active');

                        $('#test1').hide();
                        $('#test2').hide();
                        $('#test3').hide();
                        $('#test4').hide();
                        $('#test5').hide();
                        $('#test6').hide();
                        $('#test7').hide();
                        $('#test8').hide();
                        $('#test9').hide();
                        $('#test10').hide();
                        $('#test11').show();
                    }
                }
            }
        });
    }

    else {

        if (currentActive == "#test1") {

            if (NextTabId == "#test1") {
                $('a[href="#test1"]').addClass('active');

                $('#test1').show();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test2") {
                $('a[href="#test1"]').removeClass('active');
                $('a[href="#test2"]').addClass('active');

                $('#test1').hide();
                $('#test2').show();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test3") {
                $('a[href="#test1"]').removeClass('active');
                $('a[href="#test3"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').show();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test4") {
                $('a[href="#test1"]').removeClass('active');
                $('a[href="#test4"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').show();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test5") {
                $('a[href="#test1"]').removeClass('active');
                $('a[href="#test5"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').show();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test6") {
                $('a[href="#test1"]').removeClass('active');
                $('a[href="#test6"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').show();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test7") {
                $('a[href="#test1"]').removeClass('active');
                $('a[href="#test7"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').show();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test8") {
                $('a[href="#test1"]').removeClass('active');
                $('a[href="#test8"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').show();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test9") {
                $('a[href="#test1"]').removeClass('active');
                $('a[href="#test9"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').show();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test10") {
                $('a[href="#test1"]').removeClass('active');
                $('a[href="#test10"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').show();
                $('#test11').hide();
            }

            else if (NextTabId == "#test11") {
                $('a[href="#test1"]').removeClass('active');
                $('a[href="#test11"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').show();
            }


        }

        else if (currentActive == "#test2") {

            if (NextTabId == "#test1") {
                $('a[href="#test2"]').removeClass('active');
                $('a[href="#test1"]').addClass('active');

                $('#test1').show();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test2") {
                $('a[href="#test2"]').addClass('active');

                $('#test1').hide();
                $('#test2').show();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test3") {
                $('a[href="#test2"]').removeClass('active');
                $('a[href="#test3"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').show();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test4") {
                $('a[href="#test2"]').removeClass('active');
                $('a[href="#test4"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').show();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test5") {
                $('a[href="#test2"]').removeClass('active');
                $('a[href="#test5"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').show();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test6") {
                $('a[href="#test2"]').removeClass('active');
                $('a[href="#test6"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').show();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test7") {
                $('a[href="#test2"]').removeClass('active');
                $('a[href="#test7"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').show();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test8") {
                $('a[href="#test2"]').removeClass('active');
                $('a[href="#test8"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').show();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test9") {
                $('a[href="#test2"]').removeClass('active');
                $('a[href="#test9"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').show();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test10") {
                $('a[href="#test2"]').removeClass('active');
                $('a[href="#test10"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').show();
                $('#test11').hide();
            }

            else if (NextTabId == "#test11") {
                $('a[href="#test2"]').removeClass('active');
                $('a[href="#test11"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').show();
            }

        }

        else if (currentActive == "#test3") {

            if (NextTabId == "#test1") {
                $('a[href="#test3"]').removeClass('active');
                $('a[href="#test1"]').addClass('active');

                $('#test1').show();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test2") {
                $('a[href="#test3"]').removeClass('active');
                $('a[href="#test2"]').addClass('active');

                $('#test1').hide();
                $('#test2').show();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test3") {
                $('a[href="#test3"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').show();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test4") {
                $('a[href="#test3"]').removeClass('active');
                $('a[href="#test4"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').show();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test5") {
                $('a[href="#test3"]').removeClass('active');
                $('a[href="#test5"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').show();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test6") {
                $('a[href="#test3"]').removeClass('active');
                $('a[href="#test6"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').show();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test7") {
                $('a[href="#test3"]').removeClass('active');
                $('a[href="#test7"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').show();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test8") {
                $('a[href="#test3"]').removeClass('active');
                $('a[href="#test8"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').show();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test9") {
                $('a[href="#test3"]').removeClass('active');
                $('a[href="#test9"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').show();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test10") {
                $('a[href="#test3"]').removeClass('active');
                $('a[href="#test10"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').show();
                $('#test11').hide();
            }

            else if (NextTabId == "#test11") {
                $('a[href="#test3"]').removeClass('active');
                $('a[href="#test11"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').show();
            }

        }

        else if (currentActive == "#test4") {

            if (NextTabId == "#test1") {
                $('a[href="#test4"]').removeClass('active');
                $('a[href="#test1"]').addClass('active');

                $('#test1').show();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test2") {
                $('a[href="#test4"]').removeClass('active');
                $('a[href="#test2"]').addClass('active');

                $('#test1').hide();
                $('#test2').show();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test3") {
                $('a[href="#test4"]').removeClass('active');
                $('a[href="#test3"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').show();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test4") {
                $('a[href="#test4"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').show();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test5") {
                $('a[href="#test4"]').removeClass('active');
                $('a[href="#test5"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').show();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test6") {
                $('a[href="#test4"]').removeClass('active');
                $('a[href="#test6"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').show();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test7") {
                $('a[href="#test4"]').removeClass('active');
                $('a[href="#test7"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').show();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test8") {
                $('a[href="#test4"]').removeClass('active');
                $('a[href="#test8"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').show();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test9") {
                $('a[href="#test4"]').removeClass('active');
                $('a[href="#test9"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').show();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test10") {
                $('a[href="#test4"]').removeClass('active');
                $('a[href="#test10"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').show();
                $('#test11').hide();
            }

            else if (NextTabId == "#test11") {
                $('a[href="#test4"]').removeClass('active');
                $('a[href="#test11"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').show();
            }

        }

        else if (currentActive == "#test5") {

            if (NextTabId == "#test1") {
                $('a[href="#test5"]').removeClass('active');
                $('a[href="#test1"]').addClass('active');

                $('#test1').show();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test2") {
                $('a[href="#test5"]').removeClass('active');
                $('a[href="#test2"]').addClass('active');

                $('#test1').hide();
                $('#test2').show();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test3") {
                $('a[href="#test5"]').removeClass('active');
                $('a[href="#test3"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').show();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test4") {
                $('a[href="#test5"]').removeClass('active');
                $('a[href="#test4"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').show();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test5") {
                $('a[href="#test5"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').show();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test6") {
                $('a[href="#test5"]').removeClass('active');
                $('a[href="#test6"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').show();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test7") {
                $('a[href="#test5"]').removeClass('active');
                $('a[href="#test7"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').show();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test8") {
                $('a[href="#test5"]').removeClass('active');
                $('a[href="#test8"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').show();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test9") {
                $('a[href="#test5"]').removeClass('active');
                $('a[href="#test9"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').show();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test10") {
                $('a[href="#test5"]').removeClass('active');
                $('a[href="#test10"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').show();
                $('#test11').hide();
            }

            else if (NextTabId == "#test11") {
                $('a[href="#test5"]').removeClass('active');
                $('a[href="#test11"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').show();
            }
        }

        else if (currentActive == "#test6") {

            if (NextTabId == "#test1") {
                $('a[href="#test6"]').removeClass('active');
                $('a[href="#test1"]').addClass('active');

                $('#test1').show();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test2") {
                $('a[href="#test6"]').removeClass('active');
                $('a[href="#test2"]').addClass('active');

                $('#test1').hide();
                $('#test2').show();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test3") {
                $('a[href="#test6"]').removeClass('active');
                $('a[href="#test3"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').show();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test4") {
                $('a[href="#test6"]').removeClass('active');
                $('a[href="#test4"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').show();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test5") {
                $('a[href="#test6"]').removeClass('active');
                $('a[href="#test5"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').show();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test6") {
                $('a[href="#test6"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').show();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test7") {
                $('a[href="#test6"]').removeClass('active');
                $('a[href="#test7"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').show();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test8") {
                $('a[href="#test6"]').removeClass('active');
                $('a[href="#test8"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').show();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test9") {
                $('a[href="#test6"]').removeClass('active');
                $('a[href="#test9"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').show();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test10") {
                $('a[href="#test6"]').removeClass('active');
                $('a[href="#test10"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').show();
                $('#test11').hide();
            }

            else if (NextTabId == "#test11") {
                $('a[href="#test6"]').removeClass('active');
                $('a[href="#test11"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').show();
            }
        }

        else if (currentActive == "#test7") {

            if (NextTabId == "#test1") {
                $('a[href="#test7"]').removeClass('active');
                $('a[href="#test1"]').addClass('active');

                $('#test1').show();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test2") {
                $('a[href="#test7"]').removeClass('active');
                $('a[href="#test2"]').addClass('active');

                $('#test1').hide();
                $('#test2').show();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test3") {
                $('a[href="#test7"]').removeClass('active');
                $('a[href="#test3"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').show();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test4") {
                $('a[href="#test7"]').removeClass('active');
                $('a[href="#test4"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').show();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test5") {
                $('a[href="#test7"]').removeClass('active');
                $('a[href="#test5"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').show();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test6") {
                $('a[href="#test7"]').removeClass('active');
                $('a[href="#test6"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').show();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test7") {
                $('a[href="#test7"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').show();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test8") {
                $('a[href="#test7"]').removeClass('active');
                $('a[href="#test8"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').show();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test9") {
                $('a[href="#test7"]').removeClass('active');
                $('a[href="#test9"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').show();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test10") {
                $('a[href="#test7"]').removeClass('active');
                $('a[href="#test10"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').show();
                $('#test11').hide();
            }

            else if (NextTabId == "#test11") {
                $('a[href="#test7"]').removeClass('active');
                $('a[href="#test11"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').show();
            }
        }

        else if (currentActive == "#test8") {

            if (NextTabId == "#test1") {
                $('a[href="#test8"]').removeClass('active');
                $('a[href="#test1"]').addClass('active');

                $('#test1').show();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test2") {
                $('a[href="#test8"]').removeClass('active');
                $('a[href="#test2"]').addClass('active');

                $('#test1').hide();
                $('#test2').show();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test3") {
                $('a[href="#test8"]').removeClass('active');
                $('a[href="#test3"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').show();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test4") {
                $('a[href="#test8"]').removeClass('active');
                $('a[href="#test4"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').show();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test5") {
                $('a[href="#test8"]').removeClass('active');
                $('a[href="#test5"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').show();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test6") {
                $('a[href="#test8"]').removeClass('active');
                $('a[href="#test6"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').show();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test7") {
                $('a[href="#test8"]').removeClass('active');
                $('a[href="#test7"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').show();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test8") {
                $('a[href="#test8"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').show();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test9") {
                $('a[href="#test8"]').removeClass('active');
                $('a[href="#test9"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').show();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test10") {
                $('a[href="#test8"]').removeClass('active');
                $('a[href="#test10"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').show();
                $('#test11').hide();
            }

            else if (NextTabId == "#test11") {
                $('a[href="#test8"]').removeClass('active');
                $('a[href="#test11"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').show();
            }
        }

        else if (currentActive == "#test9") {

            if (NextTabId == "#test1") {
                $('a[href="#test9"]').removeClass('active');
                $('a[href="#test1"]').addClass('active');

                $('#test1').show();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test2") {
                $('a[href="#test9"]').removeClass('active');
                $('a[href="#test2"]').addClass('active');

                $('#test1').hide();
                $('#test2').show();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test3") {
                $('a[href="#test9"]').removeClass('active');
                $('a[href="#test3"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').show();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test4") {
                $('a[href="#test9"]').removeClass('active');
                $('a[href="#test4"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').show();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test5") {
                $('a[href="#test9"]').removeClass('active');
                $('a[href="#test5"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').show();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test6") {
                $('a[href="#test9"]').removeClass('active');
                $('a[href="#test6"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').show();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test7") {
                $('a[href="#test9"]').removeClass('active');
                $('a[href="#test7"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').show();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test8") {
                $('a[href="#test9"]').removeClass('active');
                $('a[href="#test8"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').show();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test9") {
                $('a[href="#test9"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').show();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test10") {
                $('a[href="#test9"]').removeClass('active');
                $('a[href="#test10"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').show();
                $('#test11').hide();
            }

            else if (NextTabId == "#test11") {
                $('a[href="#test9"]').removeClass('active');
                $('a[href="#test11"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').show();
            }
        }

        else if (currentActive == "#test10") {

            if (NextTabId == "#test1") {
                $('a[href="#test10"]').removeClass('active');
                $('a[href="#test1"]').addClass('active');

                $('#test1').show();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test2") {
                $('a[href="#test10"]').removeClass('active');
                $('a[href="#test2"]').addClass('active');

                $('#test1').hide();
                $('#test2').show();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test3") {
                $('a[href="#test10"]').removeClass('active');
                $('a[href="#test3"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').show();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test4") {
                $('a[href="#test10"]').removeClass('active');
                $('a[href="#test4"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').show();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test5") {
                $('a[href="#test10"]').removeClass('active');
                $('a[href="#test5"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').show();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test6") {
                $('a[href="#test10"]').removeClass('active');
                $('a[href="#test6"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').show();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test7") {
                $('a[href="#test10"]').removeClass('active');
                $('a[href="#test7"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').show();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test8") {
                $('a[href="#test10"]').removeClass('active');
                $('a[href="#test8"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').show();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test9") {
                $('a[href="#test10"]').removeClass('active');
                $('a[href="#test9"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').show();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test10") {
                $('a[href="#test10"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').show();
                $('#test11').hide();
            }

            else if (NextTabId == "#test11") {
                $('a[href="#test10"]').removeClass('active');
                $('a[href="#test11"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').show();
            }
        }

        else if (currentActive == "#test11") {

            if (NextTabId == "#test1") {
                $('a[href="#test11"]').removeClass('active');
                $('a[href="#test1"]').addClass('active');

                $('#test1').show();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test2") {
                $('a[href="#test11"]').removeClass('active');
                $('a[href="#test2"]').addClass('active');

                $('#test1').hide();
                $('#test2').show();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test3") {
                $('a[href="#test11"]').removeClass('active');
                $('a[href="#test3"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').show();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test4") {
                $('a[href="#test11"]').removeClass('active');
                $('a[href="#test4"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').show();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test5") {
                $('a[href="#test11"]').removeClass('active');
                $('a[href="#test5"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').show();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test6") {
                $('a[href="#test11"]').removeClass('active');
                $('a[href="#test6"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').show();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test7") {
                $('a[href="#test11"]').removeClass('active');
                $('a[href="#test7"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').show();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test8") {
                $('a[href="#test11"]').removeClass('active');
                $('a[href="#test8"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').show();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test9") {
                $('a[href="#test11"]').removeClass('active');
                $('a[href="#test9"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').show();
                $('#test10').hide();
                $('#test11').hide();
            }

            else if (NextTabId == "#test10") {
                $('a[href="#test11"]').removeClass('active');
                $('a[href="#test10"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').show();
                $('#test11').hide();
            }

            else if (NextTabId == "#test11") {
                $('a[href="#test11"]').addClass('active');

                $('#test1').hide();
                $('#test2').hide();
                $('#test3').hide();
                $('#test4').hide();
                $('#test5').hide();
                $('#test6').hide();
                $('#test7').hide();
                $('#test8').hide();
                $('#test9').hide();
                $('#test10').hide();
                $('#test11').show();
            }
        }


    }




    return false;
});

function clearFields(form) {
    debugger;
    form.find(':input').not(':hidden').val('');
    form.find(':checkbox, :radio').prop('checked', false);

}

//function sleep(delay) {
//    debugger;
//    var start = new Date().getTime();
//    if (isMoveNext == true) {
//        while (new Date().getTime() < start + delay);
//    }
//}



function ValidatePatientInfo() {
    var pre = $('.patientPrefix').val();
    var suf = $('.patientSuffix').val();
    var firstName = $('.patientFirstName').val();
    var mid = $('.patientMiddleName').val();
    var lastName = $('.patientLastName').val();
    var gender = $('.patientGender').val();
    var dob = $('.patientDOB').val();
    var marital = $('.patientMaritalStatus').val();
    var address = $('.paientAddressLine1').val();
    var userId = $('.paientUserId').val();
    var email = $('.paientEmail').val();
    var pass = $('.paientPassword').val();
    var conPass = $('.paientConPassword').val();
    var zip = $('.paientZipCode').val();
    //var city = $('.paientCity').val();
    //var state = $('.paientState').val();
    //var country = $('.paientCountry').val();
    //var country = $('.patientTreatmentStatusCombo').val();
    //var country = $('.patientTreatmentStatusCombo').val();

    var isValid = false;

    if (pre && suf && firstName && lastName && gender && dob && marital && address && userId && email && pass && conPass && zip) {
        isValid = true;
    }

    return isValid;
}

function ValidatePatientPhone() {
    var mob = $('#mobile_num').val();
    //var emergency = $('#emergency_number').val();

    var isValid = false;

    if (mob) {
        isValid = true;
    }

    return isValid;
}

function ValidateEmergencyContact() {
    var firstName = $('.emergncyFirstName').val();
    var lastName = $('.emergncyLastName').val();
    var relationship = $('.emergncyRelationShip').val();
    var addressline1 = $('.emergncyAddressLine1').val();
    var zipCode = $('.emergncyZipCode').val();
    //var city = $('.emergncyCity').val();

    var isValid = false;

    if (firstName && lastName && relationship && addressline1 && zipCode) {
        isValid = true;
    }

    return isValid;
}

function ValidatePatientIdAndSignature() {
    //var passport = $('.signaturePassportNumber').val();
    //var typeId = $('#SignatureTypeId').val();
    //var signatureIdNum = $('.SignatureIdNumber').val();
    var pass = $('.SignaturePasswordFeild').val();
    var Confirmpass = $('.SignatureConfirmPasswordFeild').val();

    var isValid = false;

    if (pass && Confirmpass) {
        isValid = true;
    }

    return isValid;
}

function ValidateCaseType() {
    var isValid = false;

    if (!$("input[name='patientCaseTypeBasicDto.CaseTypeName']:checked").val()) {
    }
    else {
        isValid = true;
    }
    return isValid;
}

function ValidateClaimInfo() {
    var InsuranceProvider = $('.primaryInsuranceProvider').val();
    var InsuranceAddress = $('.primaryInsuranceAddress').val();
    var adjusterEmail = $('.climInfoAdjusterEmail').val();
    var adjusterName = $('.ClaimInfoadjusterName').val();
    var email = $('.claimInfoEmail').val();
    var nf2Date = $('.nf2FilledDateInput').val();

    var isValid = false;

    if (InsuranceProvider && InsuranceAddress && adjusterEmail && adjusterName && email) {
        isValid = true;
    }

    return isValid;
}

function ValidateVehicles() {
    var isValid = true;
    debugger;
    var Vehicledata = $('#newDiv').find('.VehicleInfoInput')
    for (var i = 0; i < Vehicledata.length; i++) {
        if (Vehicledata[i].value == "") {
            //$('#spanVehicleInfo-' + i).html('Vehicle Info is Required');
            isValid = false;
        }
    }

    var licensePlatedata = $('#newDiv').find('.LicensePlateNumberInput')
    for (var i = 0; i < licensePlatedata.length; i++) {
        if (licensePlatedata[i].value == "") {
            //$('#spanLicensePlateNumber-' + i).html('License Plate Number is Required');
            isValid = false;
        }
    }
    var registrationStatedata = $('#newDiv').find('.entityRegistrationStateInput')
    for (var i = 0; i < registrationStatedata.length; i++) {
        if (registrationStatedata[i].value == "") {
            // $('#spanentityRegistrationState-' + i).html('Registration state is Required');
            isValid = false;
        }
    }
    if (Vehicledata.length == 0 || licensePlatedata.length == 0 || registrationStatedata.length == 0) {
        isValid = false;
    }

    return isValid;
}

function ValidateSecondary() {
    var InsuranceProvider = $('.secondaryInsuranceProviderCombo').val();
    var InsuranceAddress = $('.SecondaryAddressLine1').val();
    var InsuranceZipCode = $('.SecondaryZipCode').val();
    //var InsuranceCity = $('.SecondaryCity').val();
    //var InsuranceState = $('.SecondaryState').val();
    //var InsuranceCountry = $('.SecondaryCountry').val();

    var isValid = false;

    if (InsuranceProvider && InsuranceAddress && InsuranceZipCode) {
        isValid = true;
    }

    return isValid;
}

function ValidateTertiary() {
    var InsuranceProvider = $('.TProviderNameCombo').val();
    var InsuranceAddress = $('.TertiaryAddressLine1').val();
    var InsuranceZipCode = $('.TertiaryZipCode').val();
    //var InsuranceCity = $('.TertiaryCity').val();
    //var InsuranceState = $('.TertiaryState').val();
    //var InsuranceCountry = $('.TertiaryCountry').val();
    var phone = $('.TertiaryPhone').val();

    var isValid = false;

    if (InsuranceProvider && InsuranceAddress && InsuranceZipCode && phone) {
        isValid = true;
    }

    return isValid;
}

function ValidatePI() {
    var InAddress = $('.PIAddressLine1').val();
    var InZipCode = $('.PIZipCode').val();
    var email = $('.PIEmail').val();
    var phone = $('.PILeadingParalegalName').val();

    var isValid = false;

    if (InAddress && InZipCode && email && phone) {
        isValid = true;
    }

    return isValid;
}

function ValidateCollection() {
    var firmName = $('.FirmNameCombo').val();
    var InAddress = $('.CollectionAddressLine1').val();
    var InZipCode = $('.CollectionZipCode').val();

    var email = $('.CollectionEmail').val();
    var leadingName = $('.leadingParalegalNameCombo').val();
    var leadingPhone = $('#CollectionLeadingParalegalPhone').val();

    var isValid = false;

    if (firmName && InAddress && InZipCode && email && leadingName && leadingPhone) {
        isValid = true;
    }

    return isValid;
}


$(document).ready(function () {
    //var LanguageAppend = $("#multilanguage");
    //LanguageAppend.append($('<option>abcds</option>'));
    //$('#PreviousTabid').val('test1');
    //$('#PreviousToShowTabId').val('test1');
    //$('.modal').modal();

    //$('.modal').modal({
    //    dismissible: true
    //});

});

$('#comboboxRelation').change(function () {
    debugger
    $("#comboboxRelation option:selected").val() == "" ? $("#comboboxRelation_err").text("Relationship is required.") : $("#comboboxRelation_err").text("");
});
$('#PIFirmName').change(function () {
    debugger
    $("#PIFirmName option:selected").val() == "" ? $("#PIFirmName_err").text("Firm Name is required.") : $("#PIFirmName_err").text("");
});
$('#PI_leadingParalegalName').change(function () {
    debugger
    $("#PI_leadingParalegalName option:selected").val() == "" ? $("#PileadingParalegalName_err").text("Leading Paralegal Name is required.") : $("#PileadingParalegalName_err").text("");
});
$('#PI_legalStatus').change(function () {
    debugger
    $("#PI_legalStatus option:selected").val() == "" ? $("#pilegal_err").text("Legal status is required.") : $("#pilegal_err").text("");
});
$('#T_ProviderName').change(function () {
    debugger
    $("#T_ProviderName option:selected").val() == "" ? $("#teriteryInsuranceProvider_err").text("Provider Name is required.") : $("#teriteryInsuranceProvider_err").text("");
});
$('#FirmName').change(function () {
    debugger
    $("#FirmName option:selected").val() == "" ? $("#legalInfoFirmName_err").text("Firm Name is required.") : $("#legalInfoFirmName_err").text("");
});
$('#Patinet_leadingParalegalName').change(function () {
    debugger
    $("#Patinet_leadingParalegalName option:selected").val() == "" ? $("#leadingParalegalName_err").text("Leading Paralegal Name is required.") : $("#leadingParalegalName_err").text("");
});
$(document).ready(function () {
    //window.onclick = function (event) {
    //    // For patient info Form
    //    if (window.location.pathname == "/patientsideElite/patientinfo" || window.location.pathname == "/PatientSideElite/PatientInfo") {

    //        var genderComboVal = $('#gender').select2().val();
    //        var martialStatus = $('#maritalStatus').select2().val();
    //        var patientTreatmentStatus = $('#patientTreatment').select2().val();
    //        var patientLegal = $('#patientLegal').select2().val();
    //        var firmName = $('.FirmNameCombo').select2().val();
    //        var leadingParalegalNameCombo = $('.leadingParalegalNameCombo').select2().val();
    //        var secondaryProviderNameCombo = $('.secondaryInsuranceProviderCombo').select2().val();
    //        var nf2ComboVal = $('#Patient_nf2Status').select2().val();
    //        var CaseType = $("#Patient_caseType").select2().val();
    //        var piLegal = $("#PI_legalStatus").select2().val();
    //        var PiFirmName = $("#PIFirmName").select2().val();
    //        var paralegal = $("#PI_leadingParalegalName").select2().val();
    //        var firmComboVal = $('.FirmNameCombo').select2().val();
    //        var leadingParalegalName = $('.leadingParalegalNameCombo').select2().val();
    //        var webPage = $(".webPageUrl").select2().val();
    //        var SecwebPage = $(".SecwebPageUrl").select2().val();
    //        var piwebPage = $(".PiwebPageUrl").select2().val();
    //        var colwebPage = $(".ColwebPageUrl").select2().val();
    //        if (colwebPage) {
    //            $("#Colweb_err").html("");
    //        }
    //        if (webPage) {
    //            $("#web_err").html("");
    //        }
    //        if (SecwebPage) {
    //            $("#secweb_err").html("");
    //        }
    //        if (piwebPage) {
    //            $("#Piweb_err").html("");
    //        }
    //        if (firmComboVal) {
    //            $("#legalInfoFirmName_err").html("");
    //        }
    //        if (leadingParalegalName) {
    //            $("#leadingParalegalName_err").html("");
    //        }
    //        if (PiFirmName) {
    //            $("#PIFirmName_err").html("");
    //        }
    //        if (paralegal) {
    //            $("#PileadingParalegalName_err").html("");
    //        }
    //        if (genderComboVal) {
    //            $("#gender_err").html("");
    //        }

    //        if (martialStatus) {
    //            $("#combobox5_err").html("");
    //        }

    //        if (patientTreatmentStatus) {
    //            $("#combobox_err").html("");
    //        }

    //        if (patientLegal) {
    //            $("#combobox2_err").html("");
    //        }
    //        if (nf2ComboVal) {
    //            $("#nf2_err").html("");
    //        }
    //        if (CaseType) {
    //            $("#casetype_err").html("");
    //        }
    //        if (piLegal) {
    //            $("#pilegal_err").html("");
    //        }
    //        //For phone number form
    //        var mobNumber = $('#mobile_num').val();
    //        var emergencyNumber = $('#emergency_number').val();

    //        if (mobNumber) {
    //            $("#errmsg_mobile").html("");
    //        }

    //        if (emergencyNumber) {
    //            $("#errmsg_emerg").html("");
    //        }



    //        //Emergency Contact Form

    //        var patientLegal = $('#comboboxRelation').val();
    //        if (patientLegal) {
    //            $("#comboboxRelation_err").html("");
    //        }
    //        // Collection Form
    //        if (firmName) {
    //            $("#legalInfoFirmName_err").html("");
    //        }
    //        if (leadingParalegalNameCombo) {
    //            $("#leadingParalegalName_err").html("");
    //        }

    //        // Secondary Form
    //        if (secondaryProviderNameCombo) {
    //            $("#secondaryInsuranceProvider_err").html("");
    //        }
    //    }

    //    // For Provider Info Form
    //    if (window.location.pathname == "/Provider/ProviderEliteAdd" || window.location.pathname == "/Provider/ProviderEliteAdd") {

    //        //if (!event.target.matches('#providerInfoBtn')) {

    //        var speciality = $('#providerSpeciality').select2('data');
    //        var providerTitle = $('#providerTitle').select2('data');
    //        var providerSuffix = $('#providerSuffix').select2('data');
    //        var providerTerm = $('#providerTerm').select2('data');
    //        var providerScannedDoc = $('#providerScannedDoc').select2('data');
    //        var providerRelatedFacility = $('#providerRelatedFacility').select2('data');
    //        var providerUidType = $('#providerUidType').select2('data');
    //        var providerStatus = $('#providerStatus').select2('data');

    //        if (speciality) {
    //            $("#providerSpecialityError").html("");
    //        }
    //        if (providerTitle) {
    //            $("#providerTitleError").html("");
    //        }
    //        if (providerSuffix) {
    //            $("#providerSuffixError").html("");
    //        }
    //        if (providerTerm) {
    //            $("#providerTermError").html("");
    //        }
    //        if (providerScannedDoc) {
    //            $("#providerScanDocError").html("");
    //        }
    //        if (providerRelatedFacility) {
    //            $("#providerRelatedFacilityError").html("");
    //        }
    //        if (providerUidType) {
    //            $("#providerUidTypeError").html("");
    //        }
    //        if (providerStatus) {
    //            $("#providerStatusError").html("");
    //        }

    //        if ($("input:radio[name='ElectrnoicSign']:checked").val()) {
    //            $('#isAddElectronicSign').html("");
    //        }
    //    }
    //}


    //PatientInfo Form

    $(document).on('click', '#info_btn', function (e) {
        debugger;
        var isRequireFieldSettingsValid = true;

        $('#patientinfo *').filter(':input.req-field').each(function () {
       
            var valueSelected = $(this).val();
            var dataVal = $(this).attr('data-val');
            if (dataVal == "True" && valueSelected =="") {
                isRequireFieldSettingsValid = false;
            }
        });

        var Selectlanguage = [];
        $('#multilanguage :selected').each(function (i, selected) {
            Selectlanguage.push($(selected).val());
        });

        //var genderComboVal = $('#gender').val();
        //var martialStatus = $('#maritalStatus').val();
        //var isRequireMaritalStatus = $('#maritalStatus').attr('data-val');
        //var zipCode = $('#info_Zip').val();
        //var isRequireZipCode = $('#info_Zip').attr('data-val');

        //var patientTreatmentStatus = $('#patientTreatment').val();
        //var isRequireTreatmentStatus = $('#patientTreatment').attr('data-val');

        //var patientLegal = $('#patientLegal').val();
        //var isRequirepatientLegal = $('#patientLegal').attr('data-val');


        //if (genderComboVal == "") {
        //    $("#gender_err").html("Select Gender");
        //}
        //else {
        //    $("#gender_err").html("");
        //}

        //if (martialStatus == "") {
        //    $("#combobox5_err").html("Select Marital Status");
        //}
        //else {
        //    $("#combobox5_err").html("");
        //}

        //if (zipCode == "") {
        //    $("#err_infozip").html("Select Marital Status");
        //}
        //else {
        //    $("#err_infozip").html("");
        //}


        //if (patientTreatmentStatus == "") {
        //    $("#combobox_err").html("Select treatment status");
        //}
        //else {
        //    $("#combobox_err").html("");
        //}
        //if (patientLegal == "") {
        //    $("#combobox2_err").html("Select legal status");
        //}
        //else {
        //    $("#combobox2_err").html("");
        //}
        var isValidForm = $("#patientinfo").valid();

        e.preventDefault();
 
        if (!isRequireFieldSettingsValid) {
            swal({
                title: "Are you sure?",
                text: 'Do you want to save without provide required fields?',
                buttons: {

                    Save: {
                        text: "Continue",
                        value: "Continue"
                    },
                    Cancel: {
                        text: "Cancel!",
                        value: "Cancel"
                    }
                },
            }).then(function (response) {
                if (response == "Continue") {

                    if (isValidForm) {
                        savePatientInfoForm(Selectlanguage);
                    }

                }
                else if (response == "Cancel") {
                    e.preventDefault();
                    return false;
                }
            })
        }
        else {
            savePatientInfoForm(Selectlanguage);
        }

    })

    function savePatientInfoForm(Selectlanguage) {
        isInfoButtonClick = true;
        //$('#info_btn').attr('disabled', true);
        debugger;
        $("#patientinfo").ajaxSubmit({ 
            data: { language: Selectlanguage },
            success: function (response) {
                //$('#info_btn').attr('disabled', false);
                $('#info_btn .waves-ripple').remove();
            },
            error: function (response) {
                console.log('error');
                $('#info_btn').attr('disabled', false);
            },
            complete: function (xhr) {
                debugger;


                //$('#info_btn').attr('disabled', false);
                //$('#info_btn .waves-ripple').remove();

                onCreatePatientInfo(xhr.responseJSON);

            }
        });
    }

    //Patient PhoneNummber Form

    $(document).on('click', '#phone_btn', function (e) {
        debugger;

        var isValidPhoneForm = $('#patientPhoneNumberForm').valid();
        e.preventDefault();

        if (isValidPhoneForm) {

            isPhoneButtonClick = true;
            $('#phone_btn').attr('disabled', true);

            $('#patientPhoneNumberForm').ajaxSubmit({

                success: function (response) {
                    //disablePatientPhoneFields();
                    //$('#phone_btn').attr('disabled', false);
                    //$('#phone_btn .waves-ripple').remove(); 
                },
                error: function (response) {
                    console.log(response);
                    //$('#phone_btn').attr('disabled', false);
                },
                complete: function (xhr) {
                    disablePatientPhoneFields();
                    //$('#phone_btn').attr('disabled', false);
                    //$('#phone_btn .waves-ripple').remove(); 

                    onCreateToDoSuccessPhone(xhr.responseJSON);
                    // console.log(xhr.responseText);
                }
            });
        }
    });


    // Patient Emergency Form
    $(document).on('click', '#emerGcyBtn', function (e) {
        debugger;
        var patientLegal = $('#comboboxRelation').val();

        if (patientLegal == null) {
            $("#comboboxRelation_err").html("Select Relationship");
        }
        else {
            $("#comboboxRelation_err").html("");
        }

        var isValidEmergencyForm = $('#phoneForm').valid();
        e.preventDefault();

        if (isValidEmergencyForm) {
            if (!(patientLegal == "")) {
                isEmergencyButtonClick = true;
                $('#emerGcyBtn').attr('disabled', true);
                $('#phoneForm').ajaxSubmit({

                    success: function (response) {
                        debugger;
                    },
                    error: function (response) {
                    },
                    complete: function (xhr) {
                        debugger;
                        disablePatientEmergencyFields();
                        onCreateToDoEmergency(xhr.responseJSON);

                    }
                });
            }

        }

    })


    $('.caseTypeRadio').click(function () {
        debugger;
        $("#caseTypeRadio_error").html("");
    })


    $('#caseTypeFormId').on('submit', function (e) {
        var isValid = false;

        if (!$("input[name='patientCaseTypeBasicDto.CaseTypeName']:checked").val()) {
            $("#caseTypeRadio_error").html("Select Any Case Type");
        }
        else {
            $("#caseTypeRadio_error").html("");
            isValid = true;
        }

        e.preventDefault();

        if ($(this).valid()) {
            if ((isValid)) {
                isCastTypeButtonClick = true;
                $(this).ajaxSubmit({

                    success: function (response) {
                    },
                    complete: function (xhr) {

                        onaddCreatePatientCaseType(xhr.responseJSON);
                        // console.log(xhr.responseText);
                    }
                });
            }

        }
    });

    //For dynamically added forms in vehicle forms
    $('#newDiv').click(function () {

        var Vehicledata = $('#newDiv').find('.VehicleInfoInput')
        for (var i = 0; i < Vehicledata.length; i++) {

            if (Vehicledata[i].value != "") {
                $('#spanVehicleInfo-' + i).html('');
            }
        }

        var licensePlatedata = $('#newDiv').find('.LicensePlateNumberInput')
        for (var i = 0; i < licensePlatedata.length; i++) {

            if (licensePlatedata[i].value != "") {
                $('#spanLicensePlateNumber-' + i).html('');
            }
        }
        var registrationStatedata = $('#newDiv').find('.entityRegistrationStateInput')
        for (var i = 0; i < registrationStatedata.length; i++) {


            if (registrationStatedata[i].value != "") {
                $('#spanentityRegistrationState-' + i).html('');
            }
        }
    });

    $(document).on('submit', '#patientVehicleForm', function (e) {
        debugger;
        var isValid = true;

        var Vehicledata = $('#newDiv').find('.VehicleInfoInput');
        for (var i = 0; i < Vehicledata.length; i++) {
            var vehicleInfoInput = Vehicledata[i];
            var ifNotValidateRequired = vehicleInfoInput.attributes[1].value;

            if (Vehicledata[i].value == "") {
                if (ifNotValidateRequired != 'goWithoutValidateThis') {
                    $('#spanVehicleInfo-' + i).html('Vehicle Info is Required');
                    isValid = false;
                }
            }
        }

        var licensePlatedata = $('#newDiv').find('.LicensePlateNumberInput');
        for (var i = 0; i < licensePlatedata.length; i++) {
            var vehiclePlateInput = licensePlatedata[i];
            var ifNotValidateRequired = vehiclePlateInput.attributes[1].value;

            if (licensePlatedata[i].value == "") {
                if (ifNotValidateRequired != "goWithoutValidateThis") {
                    $('#spanLicensePlateNumber-' + i).html('License Plate Number is Required');
                    isValid = false;
                }
            }
        }
        var registrationStatedata = $('#newDiv').find('.entityRegistrationStateInput');
        for (var i = 0; i < registrationStatedata.length; i++) {
            var vehicleStateInput = registrationStatedata[i];
            var ifNotValidateRequired = vehicleStateInput.attributes[1].value;

            if (registrationStatedata[i].value == "") {
                if (ifNotValidateRequired != "goWithoutValidateThis") {
                    $('#spanentityRegistrationState-' + i).html('Registration state is Required');
                    isValid = false;
                }

            }
        }

        e.preventDefault();

        if ($(this).valid()) {
            if (isValid) {
                isVehicleButtonClick = true;
                //$('#Vehiclebtn').attr('disabled', true);
                $(this).ajaxSubmit({

                    success: function (response) {
                        //$('#Vehiclebtn').attr('disabled', false);
                        //$('#Vehiclebtn .waves-ripple').remove(); 
                    },
                    error: function (response) {
                        //$('#Vehiclebtn').attr('disabled', false);
                    },
                    complete: function (xhr) {
                        disablePatientvehicleFields();

                        //$('#Vehiclebtn').attr('disabled', false);
                        //$('#Vehiclebtn .waves-ripple').remove(); 
                        onCreateToDoVehicle(xhr.responseJSON);
                        // console.log(xhr.responseText);
                    }
                });
            }

        }

    })

    //$('#patientinfo').on('#patientinfo', function (e) {
    //    debugger;

    //    var Selectlanguage = [];
    //    $('#multilanguage :selected').each(function (i, selected) {
    //        Selectlanguage.push($(selected).val());
    //    });

    //    var genderComboVal = $('#gender').val();
    //    var martialStatus = $('#maritalStatus').val();
    //    var patientTreatmentStatus = $('#patientTreatment').val();
    //    var patientLegal = $('#patientLegal').val();

    //    if (genderComboVal == "") {
    //        $("#gender_err").html("Select Gender");
    //    }
    //    else {
    //        $("#gender_err").html("");
    //    }

    //    if (martialStatus == "") {
    //        $("#combobox5_err").html("Select Marital Status");
    //    }
    //    else {
    //        $("#combobox5_err").html("");
    //    }

    //    if (patientTreatmentStatus == "") {
    //        $("#combobox_err").html("Select treatment status");
    //    }
    //    else {
    //        $("#combobox_err").html("");
    //    }
    //    if (patientLegal == "") {
    //        $("#combobox2_err").html("Select legal status");
    //    }
    //    else {
    //        $("#combobox2_err").html("");
    //    }


    //    e.preventDefault();

    //    if ($(this).valid()) {

    //        if (!(genderComboVal == "" || martialStatus == "" || patientTreatmentStatus == "" || patientLegal == "")) {
    //            isInfoButtonClick = true;
    //            //$('#info_btn').attr('disabled', true);
    //            debugger;
    //            $(this).ajaxSubmit({

    //                data: { language: Selectlanguage },
    //                success: function (response) {
    //                    //$('#info_btn').attr('disabled', false);
    //                    //$('#info_btn .waves-ripple').remove(); 
    //                },
    //                error: function (response) {
    //                    console.log('error');
    //                    //$('#info_btn').attr('disabled', false);
    //                },
    //                complete: function (xhr) {
    //                    disablePatientInfoFields();

    //                    //$('#info_btn').attr('disabled', false);
    //                    //$('#info_btn .waves-ripple').remove(); 

    //                    onCreatePatientInfo(xhr.responseJSON);

    //                }
    //            });
    //        }

    //    }

    //})




    $('#patientArbitrationAttorneyForm').on('submit', function (e) {

        debugger;
        var firmComboVal = $('.FirmNameComboCollection').val();
        var leadingParalegalName = $('.leadingParalegalNameComboCollection').val();


        if (!(firmComboVal)) {
            $("#legalInfoFirmName_err").html("Select Firm Name");
        }
        else {
            $("#legalInfoFirmName_err").html("");
        }

        if (!(leadingParalegalName)) {
            $("#leadingParalegalName_err").html("Select Leading Paralegal Name");
        }
        else {
            $("#leadingParalegalName_err").html("");
        }

        e.preventDefault();

        if ($(this).valid()) {
            if (!(firmComboVal == "" || leadingParalegalName == "")) {
                debugger;
                isCollectionButtonClick = true;
                //$('#btnPatientCollection').attr('disabled', true);
                $(this).ajaxSubmit({

                    success: function (response) {
                        //$('#btnPatientCollection').attr('disabled', false); 
                        //$('#btnPatientCollection .waves-ripple').remove(); 
                    },
                    error: function (response) {
                        //$('#upload').attr('disabled', false);
                    },
                    complete: function (xhr) {
                        disablePatientCollectionFields();

                        //$('#btnPatientCollection').attr('disabled', false);
                        //$('#btnPatientCollection .waves-ripple').remove(); 
                        onCreateToDocollection(xhr.responseJSON);

                    }
                });
            }

        }
    });

    //$('#patientArbitrationAttorneyForm').on('submit', function (e) {

    //});

    $("#patientTeritaryInsurance").on('submit', function (e) {
        debugger;
        e.preventDefault();

        var providerNameVal = $('.TProviderNameCombo').val();

        if (!(providerNameVal)) {
            $("#teriteryInsuranceProvider_err").html("Select Provider Name");

        }
        else {
            $("#teriteryInsuranceProvider_err").html("");

        }
        if ($(this).valid()) {
            if (!(providerNameVal == null || providerNameVal == "")) {
                isTertiaryButtonClick = true;
                //$('#btnPatientTerit').attr('disabled', true);
                if ((this).isValid()) {

                }
                $(this).ajaxSubmit({

                    success: function (response) {
                        //$('#btnPatientTerit').attr('disabled', false);
                        //$('#btnPatientTerit .waves-ripple').remove(); 

                    },
                    error: function (response) {
                        //$('#btnPatientTerit').attr('disabled', false);
                    },
                    complete: function (xhr) {
                        disablePatientTertiaryyFields();

                        //$('#btnPatientTerit').attr('disabled', false);
                        //$('#btnPatientTerit .waves-ripple').remove(); 

                        onCreateToDotertiary(xhr.responseJSON);

                    }
                });
            } }
       

    });

    //$('#patientTeritaryInsurance').on('submit', function (e) {

    //});
    function onCreateToDotertiary(data) {
        debugger;
        var isErrorMessage = data.isError;

        if (isErrorMessage) {
            new PNotify({
                title: 'Error!',
                text: 'Please provide patient info first',
                delay: 5000,
                type: 'error',
                addclass: 'pnotify-center'
            });
        }
        else {
            new PNotify({
                title: 'Success!',
                text: 'Record Save',
                delay: 5000,
                type: 'success',
                addclass: 'pnotify-center'
            });
        }
    };

    $("#PatientSecondaryInsuranceForm").on('submit', function (e) {

        debugger;
        var providerNameVal = $('.secondaryInsuranceProviderCombo').val();

        if (providerNameVal == "" || providerNameVal == null) {
            $("#secondaryInsuranceProvider_err").html("Select Provider Name");
            e.preventDefault();
        }
        else {
            $("#secondaryInsuranceProvider_err").html("");
        }
        var valid = $(this).valid();

        

            if (!(providerNameVal == "")) {
                isSecondaryButtonClick = true;
                //$('#btnPatientSecondary').attr('disabled', true);
                if ($(this).valid()) {
                    $(this).ajaxSubmit({

                        success: function (response) {
                            //$('#btnPatientSecondary').attr('disabled', false);
                            //$('#btnPatientSecondary .waves-ripple').remove(); 
                        },
                        error: function (response) {
                            //$$('#btnPatientSecondary').attr('disabled', false);
                        },
                        complete: function (xhr) {
                            disablePatientsecondaryFields();

                            //$('#btnPatientSecondary').attr('disabled', false);
                            //$('#btnPatientSecondary .waves-ripple').remove(); 
                            onCreateToDoSecondary(xhr.responseJSON);

                        }
                    });
                }
                
        }
    });

    //$('#PatientSecondaryInsuranceForm').on('submit', function (e) {

    //});

    function onCreateToDoSecondary(data) {
        debugger;
        var isErrorMessage = false;
        if (data) {
            isErrorMessage = data.isError;
        }

        if (isErrorMessage) {
            new PNotify({
                title: 'Error!',
                text: 'Please provide patient info first',
                delay: 5000,
                type: 'error',
                addclass: 'pnotify-center'
            });
        }
        else {
            new PNotify({
                title: 'Success!',
                text: 'Record Save',
                delay: 5000,
                type: 'success',
                addclass: 'pnotify-center'
            });
        }
    }


    function onCreatePatientInfo(data) {
        debugger;
        var msg = data.success;
        if (data.isError) {

            new PNotify({
                title: 'Error!',
                text: msg,
                delay: 5000,
                type: 'error',
                addclass: 'pnotify-center'
            });

        }
        else {
            disablePatientInfoFields();
            new PNotify({
                title: 'Success!',
                text: 'Record Saved',
                delay: 5000,
                type: 'success',
                addclass: 'pnotify-center'
            });

        }

    }

    function onCreateToDoSuccessId(data) {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });

    }


});
$(document).ready(function () {
    $('#IncidentReportStatus_Form').on('submit', function (e) {
        e.preventDefault();
        if ($(this).valid()) {
            $(this).ajaxSubmit({
                success: function (response) {
                },
                complete: function (xhr) {
                    onCreateToIncidentReportStatus_Form(xhr.responseJSON);
                    //console.log(xhr.responseText);
                }
            });
        }
    });
    function onCreateToIncidentReportStatus_Form(data) {
        location.reload();
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });
        $("input").val("");


    };
    //function IncidenetGetList() {
    //    debugger;
    //    var url = "../Setting/GetIncidentList";
    //    $.get(url).done(function (data) {
    //        if (data === false) {
    //            $("#incidentReport_list").html('<p>Something went wrong</p>');
    //        } else {
    //            $("#incidentReport_list").html(data);
    //        }
    //        return data;
    //    });

    //    //;
    //    //$.get(url, null, function (data) {

    //    //}); 
    //    //$.ajax({

    //    //    type: 'GET',


    //    //    success: function (data) {

    //    //        alert("Load was performed.");
    //    //    }
    //    //});
    //    //$.get('@Url.Action("GetIncidentList","Setting")', function (data) {

    //    //});

    //}

});


//$("#maritalStatus").on('change',function () {
//    debugger;
//    var curVal = $(this).val();
//    $("#maritalStatus").combobox("autocomplete", curVal);
//});
//$(document).on("change", "#maritalStatus", function () {
//    alert($(this).find("option:selected").text());
//});
$('#patientPersonalInjuryForm').on('submit', function (e) {

    debugger;
    var legal = $("#PI_legalStatus").val();
    var PiFirmName = $("#PIFirmName").val();
    var paralegal = $("#PI_leadingParalegalName").val();
    if (!(legal)) {
        $("#pilegal_err").html("Select Legal Status");
    }
    else {
        $("#pilegal_err").html("");
    }
    if (!(PiFirmName)) {
        $("#PIFirmName_err").html("Select Firm Name");
    }
    else {
        $("#PIFirmName_err").html("");
    }
    if (!(paralegal)) {
        $("#PileadingParalegalName_err").html("Select Leading Paralegal Name");
    }
    else {
        $("#PileadingParalegalName_err").html("");
    }
    e.preventDefault();
    if ($(this).valid()) {
        if (!(legal == "" || PiFirmName == "" || paralegal == "")) {
            isPIButtonClick = true;
            //$('#btnPatientPI').attr('disabled', true);
            $(this).ajaxSubmit({
                success: function (response) {
                    //$('#btnPatientPI').attr('disabled', false);
                    //$('#btnPatientPI .waves-ripple').remove(); 

                },
                error: function (response) {
                    //$('#btnPatientPI').attr('disabled', false);
                },
                complete: function (xhr) {
                    disablePatientPIFields();

                    //$('#btnPatientPI').attr('disabled', false);
                    //$('#btnPatientPI .waves-ripple').remove(); 
                    onCreateToDoPI(xhr.responseJSON);
                    //console.log(xhr.responseText);
                }
            });
        }

    }
})

//$('#patientPersonalInjuryForm').on('submit', function (e) {

//});
function onCreateToDoPI(data) {
    var isErrorMessage = data.isError;

    if (isErrorMessage) {
        new PNotify({
            title: 'Error!',
            text: 'Please provide patient info first',
            delay: 5000,
            type: 'error',
            addclass: 'pnotify-center'
        });
    }
    else {
        new PNotify({
            title: 'Success!',
            text: 'Record Save',
            delay: 5000,
            type: 'success',
            addclass: 'pnotify-center'
        });
    }
};
$('#ClaimStatus_Form').on('submit', function (e) {
    e.preventDefault();
    if ($(this).valid()) {
        $(this).ajaxSubmit({

            success: function (response) {

            },
            complete: function (xhr) {
                onCreateToIncidentReportStatus_Form(xhr.responseJSON);
                //console.log(xhr.responseText);
            }
        });
    }
});
function onCreateToIncidentReportStatus_Form(data) {
    location.reload();
    new PNotify({
        title: 'Success!',
        text: 'Record Save',
        delay: 5000,
        type: 'success',
        addclass: 'pnotify-center'
    });
    $("input").val("");



}

$(document).ready(function () {

   
    //function onCreateEmail(data) {
    //    var isErrorMessage = data.isError;

    //    if (isErrorMessage) {
    //        new PNotify({
    //            title: 'Error!',
    //            text: 'Please provide patient info first',
    //            delay: 5000,
    //            type: 'error',
    //            addclass: 'pnotify-center'
    //        });
    //    }
    //    else {
    //        new PNotify({
    //            title: 'Success!',
    //            text: 'Record Save',
    //            delay: 5000,
    //            type: 'success',
    //            addclass: 'pnotify-center'
    //        });
    //    }
    //};


});

$(document).on('click', '.patientEditBtn', function () {
    debugger;
    var btnFrom = $(this).attr('data-val');

    if (btnFrom == 'InfoForm') {
        isEditInfoBtn = true;
        enablePatientInfoFields();
    }
    else if (btnFrom == 'phoneForm') {
        isEditPhoneBtn = true;
        enablePatientPhoneFields();
    }
    else if (btnFrom == 'emergencyForm') {
        isEditEmergencyBtn = true;
        enablePatientEmergencyFields();
    }
    else if (btnFrom == 'signatureForm') {
        isEditIdAndSignatureBtn = true;
        enablePatientSignatureFields();
    }
    else if (btnFrom == 'claimForm') {
        isEditClaimInfoBtn = true;
        enablePatientClaimFields();
    }
    else if (btnFrom == 'secondaryForm') {
        isEditSecondaryInsuranceBtn = true;
        enablePatientsecondaryFields();
    }
    else if (btnFrom == 'tertiaryForm') {
        isEditTertiaryInsuranceBtn = true;
        enablePatientTertiaryFields();
    }
    else if (btnFrom == 'PIForm') {
        isEditPIBtn = true;
        enablePatientPIFields();
    }
    else if (btnFrom == 'CollectionForm') {
        isEditCollectionBtn = true;
        enablePatientCollectionFields();
    }
    else if (btnFrom == 'vehicleForm') {
        isEditVehicleBtn = true;
        enablePatientvehicleFields();
    }

    $(".sidenav-trigger").attr("disabled", false);
})

//$('.patientEditBtn').on('click', function () {

//});

//For PatientInfo form
function enablePatientInfoFields() {
    debugger
    var modalClass = $('.EmailDiv');
    modalClass.removeClass('importEmailToModal');

    $(".infoDropDListBeforeEditDisabled").attr("disabled", false);
    $(".patientselect_tab .custom-combobox-input").autocomplete("option", { disabled: false });
    $("#showPalette").spectrum("enable");

    $('#multilanguage').prop('disabled', false);
    $(".form-add-btn").removeClass("disabled");

    $('.patientInfoTxtField').attr('disabled', false);
    $('.patientID').attr('disabled', 'disabled');
    $('#info_btn').attr("disabled", false);
}
function disablePatientInfoFields() {
    debugger

    var modalClass = $('.EmailDiv');
    modalClass.addClass('importEmailToModal');

    $(".infoDropDListBeforeEditDisabled").attr("disabled", true);
    $(".patientselect_tab .custom-combobox-input").autocomplete("option", { disabled: true });
    $("#showPalette").spectrum("disable");

    $('#multilanguage').prop('disabled', true);
    $('.patientInfoTxtField').attr('disabled', true);
    $(".sidenav-trigger").attr("disabled", true);
    $(".form-add-btn").addClass("disabled");

    $('#info_btn').attr("disabled", true);
    isEditInfoBtn = false;
}
function emptyPatientInfoFields() {
    $(".infoDropDListBeforeEditDisabled").closest(".ui-widget").find("input, button").val("");
    $('.patientInfoTxtField').val("");
}


//For Phone form
function enablePatientPhoneFields() {

    var modalClass = $('.phoneDiv');
    modalClass.removeClass('numberModalDiv');

    $('.patientPhoneTxtField').attr('disabled', false);
    $('#phone_btn').attr("disabled", false);
}
function disablePatientPhoneFields() {

    var modalClass = $('.phoneDiv');
    modalClass.addClass('numberModalDiv');

    $('.patientPhoneTxtField').attr('disabled', true);
    $(".sidenav-trigger").attr("disabled", true);
    $('#phone_btn').attr("disabled", true);
    isEditPhoneBtn = false;
}
function emptyPatientPhoneFields() {
    $('.patientPhoneTxtField').val("");
    $('.checkFirst').prop('checked', true);
}


//For emergency form
function enablePatientEmergencyFields() {

    var modalClass = $('.phoneDiv');
    modalClass.removeClass('numberModalDiv');

    var modalClass = $('.EmailDiv');
    modalClass.removeClass('importEmailToModal');


    $(".emergencyDropDListBeforeEditDisabled").attr("disabled", false);
   
    $(".form-add-btn").removeClass("disabled");

    $('.patientEmergencyTxtField').attr('disabled', false);
    $('#emerGcyBtn').attr("disabled", false);
}
function disablePatientEmergencyFields() {

    var modalClass = $('.phoneDiv');
    modalClass.addClass('numberModalDiv');

    var modalClass = $('.EmailDiv');
    modalClass.addClass('importEmailToModal');

    $(".emergencyDropDListBeforeEditDisabled").attr("disabled", true);
    //$(".emeregencySelect_tab .custom-combobox-input").autocomplete("option", { disabled: true });

    $('.patientEmergencyTxtField').attr('disabled', true);
    $(".form-add-btn").addClass("disabled");
    $('#emerGcyBtn').attr("disabled", true);
    isEditEmergencyBtn = false;
}
function emptyPatientEmergencyFields() {
    $(".emergencyDropDListBeforeEditDisabled").closest(".ui-widget").find("input, button").val("");
    $('.patientEmergencyTxtField').val("");
    $('.checkFirst').prop('checked', true);
}



function disablePatientSignatureFields() {
    debugger
    $('.signatureDropDListBeforeEditDisable').attr("disabled", true);
    $(".signatueSelect_tab .custom-combobox-input").autocomplete("option", { disabled: true });
    $("#files").attr("disabled", true);
    $(".dropify-wrapper").addClass("disabled");
    $("#sigCanvas").css('pointer-events', 'none');
    $("button[data-action=save]").prop('disabled', true);
    $("button[data-action=clear]").prop('disabled', true);
    $('.patientSignatureTxtField').attr('disabled', true);
    $(".sidenav-trigger").attr("disabled", true);
    $('#cameraIcon').attr('onClick', '#');
    $(".form-add-btn").addClass("disabled");
    $('.patientSigFormSub').attr("disabled", true);
    isEditIdAndSignatureBtn = false;
}


//For signature form
function enablePatientSignatureFields() {
    debugger
    $('.signatureDropDListBeforeEditDisable').attr("disabled", false);
    $(".signatueSelect_tab .custom-combobox-input").autocomplete("option", { disabled: false });
    $("#files").removeAttr("disabled");
    $(".dropify-wrapper").removeClass("disabled");
    $("#sigCanvas").css('pointer-events', 'all');
    $("button[data-action=save]").prop('disabled', false);
    $("button[data-action=clear]").prop('disabled', false);
    $('.patientSignatureTxtField').attr('disabled', false);
    $('#cameraIcon').attr('onClick', 'OpenImageSection()');
    $(".form-add-btn").removeClass("disabled");

    $('.patientSigFormSub').attr("disabled", false);
}

function emptyPatientSignatureFields() {
    $(".signatureDropDListBeforeEditDisabled").closest(".ui-widget").find("input, button").val("");
    $('.patientSignatureTxtField').val("");
    $('.checkFirst').prop('checked', true);
}


//For claim info form
function enablePatientClaimFields() {

    var modalClass = $('.phoneDiv');
    modalClass.removeClass('numberModalDiv');

    var modalClass = $('.EmailDiv');
    modalClass.removeClass('importEmailToModal');

    $(".claimDropDListBeforeEditDisabled").attr("disabled", false);
    $(".claimSelect_tab .custom-combobox-input").autocomplete("option", { disabled: false });
    $("#webPageOnNextTab").attr("disabled", false);
    $('.patientClaimInfoTxtField').attr('disabled', false);
    $('#webPageOnNextTab').attr('onClick', 'openUrlOnTab()');
    $(".sidenav-trigger").attr("disabled", false);
    $(".form-add-btn").removeClass("disabled");

    $('#btnPatientClaimInfo').attr("disabled", false);
}
function disablePatientClaimFields() {

    var modalClass = $('.phoneDiv');
    modalClass.addClass('numberModalDiv');

    var modalClass = $('.EmailDiv');
    modalClass.addClass('importEmailToModal');

    //$(".claimDropDListBeforeEditDisabled").closest(".ui-widget").find("input, button").prop("disabled", true);
    $(".claimDropDListBeforeEditDisabled").attr("disabled", true);
    $(".claimSelect_tab .custom-combobox-input").autocomplete("option", { disabled: true });
    $("#webPageOnNextTab").attr("disabled", true);

    $('.patientClaimInfoTxtField').attr('disabled', true);
    $(".sidenav-trigger").attr("disabled", true);
    $('#webPageOnNextTab').attr('onClick', '#');
    $(".form-add-btn").addClass("disabled");

    $('#btnPatientClaimInfo').attr("disabled", true);
    isEditClaimInfoBtn = false;
}
function emptyPatientClaimFields() {
    $(".claimDropDListBeforeEditDisabled").closest(".ui-widget").find("input, button").val("");
    $('.patientClaimInfoTxtField').val("");
    $('.checkFirst').prop('checked', true);
}


//For vehicle form
function enablePatientvehicleFields() {
    //$(".vehicleDropDListBeforeEditDisabled").closest(".ui-widget").find("input, button").prop("disabled", false);
    $(".vehicleDropDListBeforeEditDisabled").attr("disabled", false);
    $(".vehicle .custom-combobox-input").autocomplete("option", { disabled: false });

    $('.patientvehicleInfoTxtField').attr('disabled', false);
    $('#Vehiclebtn').attr("disabled", false);
    $('.forHideBtnVehicle').hide();
    $('.forShowBtnVehicle').show();
    $(".form-add-btn").removeClass("disabled");

    $('.vehicleCreateBtn').prop('disabled', false);
}
function disablePatientvehicleFields() {
    $(".vehicleDropDListBeforeEditDisabled").attr("disabled", true);
    $(".vehicle .custom-combobox-input").autocomplete("option", { disabled: true });

    $('.patientvehicleInfoTxtField').attr('disabled', true);
    $('#Vehiclebtn').attr("disabled", true);
    $('.forHideBtnVehicle').show();
    $('.forShowBtnVehicle').hide();
    $(".form-add-btn").addClass("disabled");

    $('.vehicleCreateBtn').prop('disabled', true);

    isEditVehicleBtn = false;
}
function emptyPatientvehicleFields() {
    $(".vehicleDropDListBeforeEditDisabled").closest(".ui-widget").find("input, button").val("");
    $('.patientvehicleInfoTxtField').val("");
}


//For secondary form
function enablePatientsecondaryFields() {

    var modalClass = $('.phoneDiv');
    modalClass.removeClass('numberModalDiv');

    var modalClass = $('.EmailDiv');
    modalClass.removeClass('importEmailToModal');

    $(".secondaryDropDListBeforeEditDisabled").attr("disabled", false);
    $(".secondarySelect_tab .custom-combobox-input").autocomplete("option", { disabled: false });
    $("#secondaryWebPageOnNextTab").attr("disabled", false);
    $(".form-add-btn").removeClass("disabled");

    $('.patientsecondaryTxtField').attr('disabled', false);
    $('#secondaryWebPageOnNextTab').attr('onClick', 'openSecUrlOnTab()');
    $(".sidenav-trigger").attr("disabled", false);
    $('#btnPatientSecondary').attr("disabled", false);
}
function disablePatientsecondaryFields() {

    var modalClass = $('.phoneDiv');
    modalClass.addClass('numberModalDiv');

    var modalClass = $('.EmailDiv');
    modalClass.addClass('importEmailToModal');

    $(".secondaryDropDListBeforeEditDisabled").attr("disabled", true);
    $(".secondarySelect_tab .custom-combobox-input").autocomplete("option", { disabled: true });
    $("#secondaryWebPageOnNextTab").attr("disabled", true);
    $(".form-add-btn").addClass("disabled");

    $('.patientsecondaryTxtField').attr('disabled', true);
    $(".sidenav-trigger").attr("disabled", true);
    $('#secondaryWebPageOnNextTab').attr('onClick', '#');
    $('#btnPatientSecondary').attr("disabled", true);
    isEditSecondaryInsuranceBtn = false;
}
function emptyPatientsecondaryFields() {
    $(".secondaryDropDListBeforeEditDisabled").closest(".ui-widget").find("input, button").val("");
    $('.patientsecondaryTxtField').val("");
}



//For tertiary form
function enablePatientTertiaryFields() {

    var modalClass = $('.phoneDiv');
    modalClass.removeClass('numberModalDiv');

    var modalClass = $('.EmailDiv');
    modalClass.removeClass('importEmailToModal');

    $(".TertiaryDropDListBeforeEditDisabled").attr("disabled", false);
    $(".tertierySelect_tab .custom-combobox-input").autocomplete("option", { disabled: false });
    $(".form-add-btn").removeClass("disabled");

    $('.patientTertiaryTxtField').attr('disabled', false);
    $(".sidenav-trigger").attr("disabled", false);
    $('#btnPatientTerit').attr("disabled", false);
}
function disablePatientTertiaryyFields() {

    var modalClass = $('.phoneDiv');
    modalClass.addClass('numberModalDiv');

    var modalClass = $('.EmailDiv');
    modalClass.addClass('importEmailToModal');

    $(".TertiaryDropDListBeforeEditDisabled").attr("disabled", true);
    $(".tertierySelect_tab .custom-combobox-input").autocomplete("option", { disabled: true });
    $(".form-add-btn").addClass("disabled");

    $('.patientTertiaryTxtField').attr('disabled', true);
    $(".sidenav-trigger").attr("disabled", true);
    $('#btnPatientTerit').attr("disabled", true);
    isEditTertiaryInsuranceBtn = false;
}
function emptyPatientTertiaryFields() {
    $(".TertiaryDropDListBeforeEditDisabled").closest(".ui-widget").find("input, button").val("");
    $('.patientTertiaryTxtField').val("");
}


//For PI Attorney form
function enablePatientPIFields() {

    var modalClass = $('.phoneDiv');
    modalClass.removeClass('numberModalDiv');

    var modalClass = $('.EmailDiv');
    modalClass.removeClass('importEmailToModal');

    $(".PIDropDListBeforeEditDisabled").attr("disabled", false);
    $(".piSelect_tab .custom-combobox-input").autocomplete("option", { disabled: false });
    $("#PIattorneyWebBtn").attr("disabled", false);
    $(".form-add-btn").removeClass("disabled");

    $('.patientPITxtField').attr('disabled', false);
    $('#PIattorneyWebBtn').attr('onClick', 'openPiUrlOnTab()');
    $(".sidenav-trigger").attr("disabled", false);
    $('#btnPatientPI').attr("disabled", false);
}
function disablePatientPIFields() {

    var modalClass = $('.phoneDiv');
    modalClass.addClass('numberModalDiv');

    var modalClass = $('.EmailDiv');
    modalClass.addClass('importEmailToModal');

    $(".PIDropDListBeforeEditDisabled").attr("disabled", true);
    $(".piSelect_tab .custom-combobox-input").autocomplete("option", { disabled: true });
    $("#PIattorneyWebBtn").attr("disabled", true);
    $(".form-add-btn").addClass("disabled");

    $('.patientPITxtField').attr('disabled', true);
    $(".sidenav-trigger").attr("disabled", true);
    $('#PIattorneyWebBtn').attr('onClick', '#');
    $('#btnPatientPI').attr("disabled", true);
    isEditPIBtn = false;
}
function emptyPatientPIFields() {
    $(".PIDropDListBeforeEditDisabled").closest(".ui-widget").find("input, button").val("");
    $('.patientPITxtField').val("");
}


//For Collection Attorney form
function enablePatientCollectionFields() {

    var modalClass = $('.phoneDiv');
    modalClass.removeClass('numberModalDiv');

    var modalClass = $('.EmailDiv');
    modalClass.removeClass('importEmailToModal');

    $(".CollectionDropDListBeforeEditDisabled").attr("disabled", false);
    $(".collectionSelect_tab .custom-combobox-input").autocomplete("option", { disabled: false });
    $("#collectionFormWebsite").attr("disabled", false);
    $(".form-add-btn").removeClass("disabled");

    $('.patientCollectionTxtField').attr('disabled', false);
    $('#collectionFormWebsite').attr('onClick', 'openColUrlOnTab()');
    $(".sidenav-trigger").attr("disabled", false);
    $('#btnPatientCollection').attr("disabled", false);

}
function disablePatientCollectionFields() {

    var modalClass = $('.phoneDiv');
    modalClass.addClass('numberModalDiv');

    var modalClass = $('.EmailDiv');
    modalClass.addClass('importEmailToModal');

    $(".CollectionDropDListBeforeEditDisabled").attr("disabled", true);
    $(".collectionSelect_tab .custom-combobox-input").autocomplete("option", { disabled: true });
    $("#collectionFormWebsite").attr("disabled", true);
    $(".form-add-btn").addClass("disabled");

    $('.patientCollectionTxtField').attr('disabled', true);
    $(".sidenav-trigger").attr("disabled", true);
    $('#collectionFormWebsite').attr('onClick', '#');
    $('#btnPatientCollection').attr("disabled", true);
    isEditCollectionBtn = false;
}
function emptyPatientCollectionFields() {
    $(".CollectionDropDListBeforeEditDisabled").closest(".ui-widget").find("input, button").val("");
    $('.patientCollectionTxtField').val("");
}
$(document).ready(function () {
    $('.select2').select2();
    $('#multilanguage')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });


    $('#Employment_Status')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right2\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });

    $('#Employment_Title')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right3\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    
    $('#patientTreatment')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right4\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#patientLegal')
        .select2()
        .on('select2:open', () => { 
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right5\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#comboboxRelation')
        .select2()
        .on('select2:open', () => { 
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right6\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#SignatureIdType')
        .select2()
        .on('select2:open', () => { 
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right7\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#Patient_RoleIncident')
        .select2()
        .on('select2:open', () => { 
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right8\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#Patient_incidentReport')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right9\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#Patient_nf2Status')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right10\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#Patient_claimStatus')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right11\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#Patient_ProviderName')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right12\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#Patient_ProviderName')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right13\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#T_ProviderName')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right14\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#T_GroupName')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right15\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#PIFirmName')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right21\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#PI_AttoneyName')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right22\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#PI_leadingAttorneyName')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right23\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#PI_leadingParalegalName')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right24\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#PI_legalStatus')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right25\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#FirmName')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right16\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#Patient_AttoneyName')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right17\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#Patient_leadingAttorneyName')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right18\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#Patinet_leadingParalegalName')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right19\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
    $('#Collection_LegalStatus')
        .select2()
        .on('select2:open', () => {
            $(".select2-results:not(:has(a))").append('<a class="sideout" href="javascript:void(0);" onclick="ToggleSideBar(\'slide-out-right20\')" style="padding: 6px;height: 20px;display: inline-table;">Add New</a>');
        });
   // $("#multilanguage").append('<option value="add-new">Ad New</option>').trigger('change');
});