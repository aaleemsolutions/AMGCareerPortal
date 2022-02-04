////function loadDatepickers() {
////    var date = new Date();
////    $('.pastdate').each(function () {
        
////        $(this).datepicker({
////            format: "dd-M-yyyy",
////            //enableOnReadonly: true,
////            //todayHighlight: true,
////            endDate: date
////        });
////    });
////}

(function ($) {
    var date = new Date();
    date.setDate(date.getDate() - 1);

  'use strict';
  if ($("#timepicker-example").length) {
    $('#timepicker-example').datetimepicker({
      format: 'LT'
    });
  }
  if ($(".color-picker").length) {
    $('.color-picker').asColorPicker();
  }
  if ($("#datepicker-popup").length) {
      $('#datepicker-popup').datepicker({
          format: "dd-M-yyyy",
      enableOnReadonly: true,
      //todayHighlight: true,
          startDate: date,
          autoclose: true
    });
  }
 
        $('.pastdate').datepicker({
            format: "dd-M-yyyy",
            //enableOnReadonly: true,
            //todayHighlight: true,
            endDate: date,
            autoclose: true
        });
 

    if ($(".datepicker").length) {
        $('.datepicker').datepicker({
            format: "dd-M-yyyy",
            autoclose: true
            //enableOnReadonly: true
            //todayHighlight: true
        });
    }

   
 
 
    if ($("#dobDate").length) {
        $('#dobDate').datepicker({
            format: "dd-M-yyyy",
            //enableOnReadonly: true,
            //todayHighlight: true,
            endDate: date,
            autoclose: true
        });
    }

    if ($(".datepickerfuture").length) {
        $('.datepickerfuture').datepicker({
            format: "dd-M-yyyy",
            enableOnReadonly: true,
            //todayHighlight: true,
            startDate: date,
            autoclose: true
        });
    }

  if ($("#inline-datepicker").length) {
    $('#inline-datepicker').datepicker({
      enableOnReadonly: true,
      todayHighlight: true,
    });
  }
  if ($(".datepicker-autoclose").length) {
    $('.datepicker-autoclose').datepicker({
      autoclose: true
    });
  }
  if ($('input[name="date-range"]').length) {
    $('input[name="date-range"]').daterangepicker();
  }
  if($('.input-daterange').length) {
    $('.input-daterange input').each(function() {
      $(this).datepicker('clearDates');
    });
    $('.input-daterange').datepicker({});
  }
})(jQuery);