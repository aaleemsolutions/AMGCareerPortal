(function($) {
  'use strict';
  if ($("#fileuploader").length) {
    $("#fileuploader").uploadFile({
        url: "/CandidatePortal/Candidatejob/UploadCandidateCv",
        multiple: false,
        maxFileCount: 1,
        fileName: "CandidateCvProfile",
        showDelete: true,
        showDownload: true,
         
        allowedTypes:"pdf",
        multiDragErrorStr: "Only 1 file is allowed",
        maxFileCountErrorStr: "Only 1 file is allowed",

        onLoad: function (obj) {
           
            $.ajax({
                cache: false,
                url: "/CandidatePortal/Candidatejob/GetCandidateCv",
                dataType: "json",
                success: function (data) {

                    if (data.name !=undefined) {
                        obj.createProgress(data.name, data.path, data.size);
                    }
                    

                    //debugger;
                    //for (var i = 0; i < data.length; i++) {
                    //    alert(data[i]["name"]);
                    //    obj.createProgress(data[i]["name"], data[i]["path"], data[i]["size"]);
                    //}
                }
            });
        },
    
        deleteCallback: function (data, pd) {
            for (var i = 0; i < data.length; i++) {
                $.ajax({
                    cache: false,
                    url: "/CandidatePortal/Candidatejob/DeleteCandidateCv",
                    dataType: "json",
                    success: function (data) {

                        ShowToaster(0, "CV Deleted", "CV Deleted");
                    }
                });
            }
            pd.statusbar.hide(); //You choice.

        },

        downloadCallback: function (filename, pd) {
 
            location.href = "/Candidatejob/DownloadCandidateCv?filename=" + filename;
        }


    });
  }
})(jQuery);