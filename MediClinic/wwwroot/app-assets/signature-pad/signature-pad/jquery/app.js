
    var wrapper1 = document.getElementById("signature-pad1"),
        clearButton1 = wrapper1.querySelector("[data-action=clear]"),
        saveButton1 = wrapper1.querySelector("[data-action=save]"),
        canvas1 = wrapper1.querySelector("canvas"),
        signaturePad1;

    function resizeCanvas() {
        var ratio = Math.max(window.devicePixelRatio || 1, 1);

        canvas1.width = canvas1.offsetWidth * ratio;
        canvas1.height = canvas1.offsetHeight * ratio;
        canvas1.getContext("2d").scale(ratio, ratio);
    }
    window.onresize = resizeCanvas;
    resizeCanvas();
    signaturePad1 = new SignaturePad(canvas1);
    clearButton1.addEventListener("click", function (event) {
        signaturePad1.clear();
        $("button[data-action=save]").html('Add Signature')
        $("button[data-action=save]").addClass('btn-info')
        $("button[data-action=save]").prop('disabled', false);
        jQuery("#signature1").val('')
        jQuery("#signed_date1").val('')
        jQuery("#signed_ip1").val('')
        jQuery("#signed_date1_txt").text('')
        jQuery("#signed_ip1_txt").text('')
        jQuery("#signed_cont1").addClass("hidden")
    });
    saveButton1.addEventListener("click", function (event) {
        if (signaturePad1.isEmpty()) {
            //alert("Please provide signature first.");
        } else {

            var loading_txt = jQuery(this).data("loading");
            var complete_txt = 'Signature Added';
            var $this = jQuery(this);
            $this.html(loading_txt)
            $this.prop('disabled', true);

            //jQuery.post("http://mediclinic.imedhealth.us/SignatureImages", {data: signaturePad1.toDataURL()}, function (data) {

            //    data_arr = JSON.parse(data);


            //    jQuery("#signature1").val(data_arr["signature"])
            //    jQuery("#signed_date1").val(data_arr["signed"])
            //    jQuery("#signed_ip1").val(data_arr["signed_ip"])
            //    jQuery("#signed_date1_txt").text(data_arr["signed"])
            //    jQuery("#signed_ip1_txt").text(data_arr["signed_ip"])
            //    jQuery("#signed_cont1").removeClass("hidden")

            //    $("button[data-action=save]").removeClass('btn-info') 
            //    $("#error").addClass("hidden");
            //    $this.html(complete_txt)
            //    $this.prop('disabled', false);

            //})
        }
    });









