//═════════════════════════════════════════════════════════════════════════════════════════════
function ToastrAlert(Asunto, Mensaje, clase) {
    switch (clase) {
        case "Succ":
            toastr.options = { "closeButton": true, "debug": false, "newestOnTop": false, "progressBar": true, "preventDuplicates": true, "positionClass": "toast-top-center", "onclick": null, "showDuration": "2000", "hideDuration": "1000", "timeOut": "0", "extendedTimeOut": "1000", "showEasing": "swing", "hideEasing": "linear", "showMethod": "show", "hideMethod": "hide" };
            toastr.success(Mensaje, Asunto); break;
        case "War":
            toastr.options = { "closeButton": true, "debug": false, "newestOnTop": false, "progressBar": true, "preventDuplicates": true, "positionClass": "toast-bottom-right", "onclick": null, "showDuration": "2000", "hideDuration": "1000", "timeOut": "5000", "extendedTimeOut": "1000", "showEasing": "swing", "hideEasing": "linear", "showMethod": "show", "hideMethod": "hide" };
            toastr.warning(Mensaje, Asunto); break;
        case "Inf":
            toastr.options = { "closeButton": true, "debug": false, "newestOnTop": false, "progressBar": true, "preventDuplicates": true, "positionClass": "toast-top-right", "onclick": null, "showDuration": "2000", "hideDuration": "1000", "timeOut": "5000", "extendedTimeOut": "1000", "showEasing": "swing", "hideEasing": "linear", "showMethod": "show", "hideMethod": "hide" };
            toastr.info(Mensaje, Asunto); break;
        case "Err":
            toastr.options = { "closeButton": true, "debug": false, "newestOnTop": false, "progressBar": true, "preventDuplicates": true, "positionClass": "toast-bottom-center", "onclick": null, "showDuration": "2000", "hideDuration": "1000", "timeOut": "0", "extendedTimeOut": "1000", "showEasing": "swing", "hideEasing": "linear", "showMethod": "show", "hideMethod": "hide" };
            toastr.error(Mensaje, Asunto); break;
    }

 //<input type="radio" name="positions" value="toast-top-right"  />
 //<input type="radio" name="positions" value="toast-bottom-right" />
 //<input type="radio" name="positions" value="toast-bottom-left" />
 //<input type="radio" name="positions" value="toast-top-left" />
 //<input type="radio" name="positions" value="toast-top-full-width" />
 //<input type="radio" name="positions" value="toast-bottom-full-width" />
 //<input type="radio" name="positions" value="toast-top-center" />
}
//═════════════════════════════════════════════════════════════════════════════════════════════

function NotificaLoad(Menasje) {

    if (Menasje !== null) {
        ToastrAlert("Biblioteca TRAVEL", Menasje, "Inf");
    }
    
}

