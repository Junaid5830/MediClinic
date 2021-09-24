$(function () {

    $('body').on('keydown', 'input', function (e) {

        //console.log(this.value);

        if (e.which === 32 && this.value === '') {
            return false;
        }

    });

});