
    function toastsuccess(message,position)
        {
            if (position === null || position === '') {

        toastr.success(message, 'Success', toastr.options.positionClass = 'toast-top-right');
            }
            else {
        toastr.success(message, 'Success', toastr.options.positionClass = position);
            }

        }
        function toasterror(message,position) {
            if (position === null || position === '') {

        toastr.error(message, 'Error', toastr.options.positionClass = 'toast-top-right');
            }
            else {
        toastr.error(message, 'Error', toastr.options.positionClass = position);
            }
        }
  