(function($) {
  'use strict';
  $(function() {
 
      
      
      $('#order-listing').DataTable({
          searching: false, paging: false, info: false,
       
          "ajax": {
              "url": "/CandidateDashboard/GetCandidateQualification/",
              "type": "POST",
              "datatype": "json"
              //"contentType": 'application/json'
              
      
              
          },
         
          "columnDefs":
              [{
                  "targets": [0],
                  "visible": false,
                  "searchable": false
              }
              ],
          "oLanguage": {
              "sEmptyTable": "No Education Detail Found.."
          },
          "columns": [
              { "data": "QualificationId", "autoWidth": true},
              { "data": "InstitutionName" ,"autoWidth": true},
              { 'data': 'Specialization' ,"autoWidth": true},
              { 'data': 'DegreeId', "autoWidth": true},
              { 'data': 'FromMonth' ,"autoWidth": true},
              { 'data': 'toMonth', "autoWidth": true},
              { 'data': 'ResultType' ,"autoWidth": true}
              
              ,{
                  "render": function (data, type, full, meta) { return '<a class="btn btn-info" type="button" onClick="UpdateQualification(1,' + full.QualificationId + ')">Edit</a> <a class="btn btn-info" type="button" onClick="UpdateQualification(0,' + full.QualificationId +')">Delete</a>'; }
              }
        

          ]


      });



      $('#CndExpDataTable').DataTable({
          searching: false, paging: false, info: false,

          "ajax": {
              "url": "/CandidateDashboard/GetCandidateExperience/",
              "type": "POST",
              "datatype": "json"
        


          },

          "columnDefs":
              [{
                  "targets": [0],
                  "visible": false,
                  "searchable": false
              }
              ],
          "oLanguage": {
              "sEmptyTable": "No Education Detail Found.."
          },
          "columns": [
              { "data": "ExperienceId", "autoWidth": true },
              { "data": "CompanyName", "autoWidth": true },
              { 'data': 'DesignationName', "autoWidth": true },
              { 'data': 'LocationName', "autoWidth": true },
              { 'data': 'FromMonth', "autoWidth": true },
              { 'data': 'toMonth', "autoWidth": true },
              { 'data': 'ReasonForLeaving', "autoWidth": true },
              { 'data': 'CurrentSalary', "autoWidth": true }

              , {
                  "render": function (data, type, full, meta) { return '<a class="btn btn-info" type="button" onClick="UpdateExperince(1,' + full.ExperienceId + ')">Edit</a> <a class="btn btn-info" type="button" onClick="UpdateExperince(0,' + full.ExperienceId + ')">Delete</a>'; }
              }


          ]


      });

  
  });
})(jQuery);