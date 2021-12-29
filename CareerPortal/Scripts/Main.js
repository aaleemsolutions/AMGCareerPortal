function AskYesOrNo(title = "Are you sure?",msg =  "You won't be able to revert this!" ) {

    swal({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3f51b5',
        cancelButtonColor: '#ff4081',
        confirmButtonText: 'Great ',
        buttons: {
            cancel: {
                text: "Cancel",
                value: false,
                visible: true,
                className: "btn btn-danger",
                closeModal: true,
            },
            confirm: {
                text: "OK",
                value: true,
                visible: true,
                className: "btn btn-primary",
                closeModal: true
            }
        }
    }).then(function (result) { alert(result); return result; });

}

function ReloadAjaxTable() {
    $('#order-listing').DataTable().ajax.reload();
}

function ReloadExperienceAjaxTable() {
    $('#CndExpDataTable').DataTable().ajax.reload();
}

function validateCndQualification(CurrentformIndex) {


    var isvalid = true;

    if (CurrentformIndex == 1) {



        var InstituteName = $("#CndQualificationViewModel_InstitutionName").val();
        var DegreeId = $("#CndQualificationViewModel_DegreeId").val();

        var Specialization = $("#CndQualificationViewModel_Specialization").val();

        var fromMonth = $("#CndQualificationViewModel_DgrFrmMonth").val();
        var fromyear = $("#CndQualificationViewModel_DgrFrmYear").val();
        var toMonth = $("#CndQualificationViewModel_DgrToMonth").val();
        var toYear = $("#CndQualificationViewModel_DgrToYear").val();
        var ResultType = $("#CndQualificationViewModel_ResultType").val();
        var ResultValue = $("#CndQualificationViewModel_ResultValue").val();
        var isprogress = $("#CndQualificationViewModel_isOngoing").is(':checked');

        //For Errors
        var ErrorInstituteName = $("#ErrorInstitutionName").val();
        var ErrorDegreeId = $("#ErrorDegree").val();
        var ErrorSpecialization = $("#ErrorSpecialization").val();
        var ErrorFromDate = $("#ErrorFromDate").val();
        var ErrorToDate = $("#ErrorToDate").val();
        var ErrorResultType = $("#ErrorResultType").val();



        if (isNaN(InstituteName) == false || InstituteName == "") {
            $("#ErrorInstitutionName").html("Institue name is required.")
            isvalid = false;
            return isvalid;
        } else {
            $("#ErrorInstitutionName").html("")
            isvalid = true;
        }

        if (DegreeId < 1 || DegreeId < 1) {
            $("#ErrorDegree").html("Please select degree")
            isvalid = false;

            return isvalid;

        } else {
            $("#ErrorDegree").html("")
            isvalid = true;
        }
        if (isNaN(Specialization) == false || Specialization == "") {
            $("#ErrorSpecialization").html("Specialization name is required.")
            isvalid = false;
            return isvalid;
        } else {
            $("#ErrorSpecialization").html("")
            isvalid = true;
        }


        if (fromMonth < 1 || fromyear < 1) {
            $("#ErrorFromDate").html("From Date is required.")
            isvalid = false;

            return isvalid;

        } else {
            $("#ErrorFromDate").html("")
            isvalid = true;
        }

        if (isprogress == false) {

            if (toMonth < 1 || toYear < 1) {
                $("#ErrorToDate").html("To Date is required.")
                isvalid = false;

                return isvalid;

            } else {
                $("#ErrorToDate").html("")
                isvalid = true;
            }

            if (ResultType == "0") {
                $("#ErrorResultType").html("Please enter select result type.")
                isvalid = false;

                return isvalid;
            } else {
                $("#ErrorResultType").html("")
                isvalid = true;
            }

            if (ResultValue == undefined || ResultValue == "") {
                $("#ErrorResultType").html("Please enter result marks")
                isvalid = false;

                return isvalid;
            } else {
                $("#ErrorResultType").html("")
                isvalid = true;
            }


            if (ResultValue != "") {
                if (ResultType.toUpperCase() == "Perecentage".toUpperCase() && parseInt(ResultValue) > 100) {
                    $("#ErrorResultType").html("Percentage could not be more than 100%")
                    isvalid = false;

                    return isvalid;
                } else if (ResultType.toUpperCase() == "Cgpa".toUpperCase() && parseInt(ResultValue) > 4) {
                    $("#ErrorResultType").html("CGPA could not be greter than 4")
                    isvalid = false;

                    return isvalid;
                } else {
                    $("#ErrorResultType").html("")
                }
            }


        } else {
            $("#ErrorToDate").html("")
            $("#ErrorResultType").html("")
            isvalid = true;
        }






    }



    return isvalid;
}

function validateCndExperience(CurrentformIndex) {


    var isvalid = true;

    if (CurrentformIndex == 2) {


        var FreshNoExperience = $("#ChkCndNoExperience").is(':checked');
        var CompanyName = $("#CndExperienceCmpName").val();
        var Designation = $("#CndExperienceDesgination").val();
        var Location = $("#CndExperienceLocation").val();

        var fromMonth = $("#CndExperienceFrmMonth").val();
        var fromyear = $("#CndExperienceFrmYear").val();
        var toMonth = $("#CndExperienceToMonth").val();
        var toYear = $("#CndExperienceToYear").val();
        var isprogress = $("#ChkCndExperiencePresent").is(':checked');
        

        var CurrentSalary = $("#CndExperienceViewModel_CurrentSalary").val();
        var ReasonForLeaving = $("#CndExperienceViewModel_ReasonForLeaving").val();

        var JobDuties = $("#JobDutiesEditor .ql-editor").html();

        if (FreshNoExperience == false) {
            if (isNaN(CompanyName) == false || CompanyName == "") {
                $("#ErrorCndExperienceCmpName").html("Company name is required")
                isvalid = false;
                return isvalid;
            } else {
                $("#ErrorCndExperienceCmpName").html("")
                isvalid = true;
            }




            if (isNaN(Designation) == false || Designation == "") {
                $("#ErrorCndExperienceDesgination").html("Designation is required.")
                isvalid = false;
                return isvalid;
            } else {
                $("#ErrorCndExperienceDesgination").html("")
                isvalid = true;
            }


            if (isNaN(Location) == false || Location == "") {
                $("#ErrorCndExperienceLocation").html("Location is required.")
                isvalid = false;
                return isvalid;
            } else {
                $("#ErrorCndExperienceLocation").html("")
                isvalid = true;
            }


            if (fromMonth < 1 || fromyear < 1) {
                $("#ErrorCndExperienceFromDate").html("From Date is required.")
                isvalid = false;

                return isvalid;

            } else {
                $("#ErrorCndExperienceFromDate").html("")
                isvalid = true;
            }

            if (isprogress == false) {

                if (toMonth < 1 || toYear < 1) {
                    $("#ErrorCndExperienceToDate").html("To Date is required.")
                    isvalid = false;

                    return isvalid;

                } else {
                    $("#ErrorCndExperienceToDate").html("")
                    isvalid = true;
                }



            } else {
                $("#ErrorCndExperienceToDate").html("")

                isvalid = true;
            }


            if (CurrentSalary == "0" || CurrentSalary == "") {
                $("#ErrorCndExperienceSalary").html("Salary is required.")
                isvalid = false;
                return isvalid;
            } else {
                $("#ErrorCndExperienceSalary").html("")
                isvalid = true;
            }


            if (isNaN(ReasonForLeaving) == false || ReasonForLeaving == "") {
                $("#ErrorCndExperienceLeaving").html("Reason for leaving is required.")
                isvalid = false;
                return isvalid;
            } else {
                $("#ErrorCndExperienceLeaving").html("")
                isvalid = true;
            }

            if (JobDuties == "<p><br></p>") {
                $("#ErrorCndExperienceJobDuties").html("Job Duties is required.")
                isvalid = false;
                return isvalid;
            } else {
                $("#ErrorCndExperienceJobDuties").html("")
                isvalid = true;
            }
        } else {
            isvalid = true;
        }

        




    }



    return isvalid;
}

function addCandQualification(currentIndex, isNextButton = true) {
    var table = $('#order-listing').DataTable();

    if ((currentIndex == 1 && isNextButton == true && table.data().count() > 0)) {
        return true;
    } else {

        if (validateCndQualification(currentIndex)) {
            $("#btnSaveEducationData").attr("disabled", "disabled")
            var getformvalue = $('#CandidateWizardForm')[0];

            var valdata = new FormData(getformvalue);

            //to get alert popup   
            var fileUpload = $("#UserImage").get(0);
            var files = fileUpload.files;

            valdata.append("CandidateDescription", $("#quillExample1 .ql-editor").html());
            valdata.append("FormWizardSteps", currentIndex);
            valdata.append("DegreeName", $("#CndQualificationViewModel_DegreeId option:selected").text())

            $.ajax({
                url: "/CandidatePortal/CandidateDashboard/",
                type: "POST",
                dataType: 'json',
                processData: false,
                contentType: false,
                //contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: valdata,
                success: function (data) {
                    //IsValidate = data.Validateform
                    var test = data.Validateform;
                    if (test == true) {

                        ReloadAjaxTable();
                        ResetFields(currentIndex)
                        $("#btnSaveEducationData").html("Save and add more")

                        ShowToaster(1, "Qualification have been updated.", "Qualification");

                    }

                    return test;


                },
                complete: function (data) {
                    $("#btnSaveEducationData").removeAttr("disabled");
                    //A function to be called when the request finishes 
                    // (after success and error callbacks are executed). 
                }
            });






        } else {
            return false;
        }

    }

}

function addCandExperience(currentIndex, isNextButton = true) {
    var table = $('#CndExpDataTable').DataTable();

    if ((currentIndex == 2 && isNextButton == true && table.data().count() > 0)) {
        return true;
    } else {

        if (validateCndExperience(currentIndex)) {

            var getformvalue = $('#CandidateWizardForm')[0];

            var valdata = new FormData(getformvalue);


            valdata.append("JobDutiesDescription", $("#JobDutiesEditor .ql-editor").html());
            valdata.append("FormWizardSteps", currentIndex);


            $.ajax({
                url: "/CandidatePortal/CandidateDashboard/",
                type: "POST",
                dataType: 'json',
                processData: false,
                contentType: false,
                //contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: valdata,
                success: function (data) {
                    //IsValidate = data.Validateform
                    var test = data.Validateform;
                    if (test == true) {

                        ReloadExperienceAjaxTable();
                        ResetFields(currentIndex)
                        $("#btnSaveExperienceData").html("Save and add more")

                        ShowToaster(1, "Experince have been updated..", "Experience");


                    }

                    return test;


                }
            });






        } else {
            return false;
        }

    }

}

function ShowToaster(issuccess = 1, msg, heading) {

    //resetToastPosition();
    //$.toast({
    //    heading: successtype,
    //    text: msg,
    //    showHideTransition: 'slide',
    //    icon: successtype = "Danger"?"Error":"success",
    //    loaderBg: '#f96868',
    //    position: 'top-right'
    //})

    if (issuccess == 1) {
        resetToastPosition();
        $.toast({
            heading: heading,//'Success',
            text: msg,//'And these were just the basic demos! Scroll down to check further details on how to customize the output.',
            showHideTransition: 'slide',
            icon: 'success',
            loaderBg: '#f96868',
            position: 'top-right'
        })
    } else {
        resetToastPosition();
        $.toast({
            heading:heading,// 'Danger',
            text: msg,//'And these were just the basic demos! Scroll down to check further details on how to customize the output.',
            showHideTransition: 'slide',
            icon: 'error',
            loaderBg: '#f2a654',
            position: 'top-right'
        })
    }

}

function UpdateQualification(isupdate, Qualificationid) {
    if (isupdate == 1) {



        $.ajax({
            url: "/CandidatePortal/CandidateDashboard/GetCndQualificationById/",
            type: "POST",
            data: { "Qualificationid": Qualificationid },
            success: function (data) {

                if (data.data != undefined && data.data != "") {



                    $("#CndQualificationViewModel_id").val(data.data.QualificationId)
                    $("#CndQualificationViewModel_InstitutionName").val(data.data.InstitutionName)
                    $("#CndQualificationViewModel_Specialization").val(data.data.Specialization)
                    $("#CndQualificationViewModel_DegreeId").val(data.data.DegreeId)

                    $("#CndQualificationViewModel_DgrFrmMonth").val(data.data.FromMonth)
                    $("#CndQualificationViewModel_DgrFrmYear").val(data.data.fromYear)
                    $("#CndQualificationViewModel_DgrToMonth").val(data.data.ToMonth)
                    $("#CndQualificationViewModel_DgrToYear").val(data.data.ToYear)
                    $("#CndQualificationViewModel_ResultType").val(data.data.ResultType)
                    $("#CndQualificationViewModel_ResultValue").val(data.data.ResultValue)

                    if (data.data.IsOnGoing == true) {
                        $("#CndQualificationViewModel_isOngoing").prop("checked", true)

                        $("#CndQualificationViewModel_DgrToMonth").attr("disabled", "disabled");
                        $("#CndQualificationViewModel_DgrToYear").attr("disabled", "disabled");
                        $("#CndQualificationViewModel_ResultType").attr("disabled", "disabled");
                        $("#CndQualificationViewModel_ResultValue").attr("disabled", "disabled");


                    } else {
                        $("#CndQualificationViewModel_isOngoing").prop("checked", false)


                        $("#CndQualificationViewModel_DgrToMonth").removeAttr("disabled");
                        $("#CndQualificationViewModel_DgrToYear").removeAttr("disabled");
                        $("#CndQualificationViewModel_ResultType").removeAttr("disabled");
                        $("#CndQualificationViewModel_ResultValue").removeAttr("disabled");
                    }
                    //$("#CndQualificationViewModel_isOngoing").val(data.data.IsOnGoing)
                    
                    $("#btnSaveEducationData").html("Update Records")

                }

            }
        });


    } else {

        swal({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3f51b5',
            cancelButtonColor: '#ff4081',
            confirmButtonText: 'Great ',
            buttons: {
                cancel: {
                    text: "Cancel",
                    value: false,
                    visible: true,
                    className: "btn btn-danger",
                    closeModal: true,
                },
                confirm: {
                    text: "OK",
                    value: true,
                    visible: true,
                    className: "btn btn-primary",
                    closeModal: true
                }
            }
        }).then(function (result) {
            if (result) {

                $.ajax({
                    url: "/CandidatePortal/CandidateDashboard/DeleteQualification/",
                    type: "POST",
                    data: { "Id": Qualificationid },
                    success: function (data) {

                        if (data == true) {
                            ReloadAjaxTable();

                            ShowToaster(0, "Qualification Deleted", "Qualification");

                        } else {
                            ShowToaster(0, "Error While updating Records please contact I.T", "Qualification");
                        }

                    }
                });
            }
        });

  

     
      

    }

}

function UpdateExperince(isupdate, ExperienceId) {
    if (isupdate == 1) {



        $.ajax({
            url: "/CandidatePortal/CandidateDashboard/GetCndExperienceById/",
            type: "POST",
            data: { "ExperinceID": ExperienceId },
            success: function (data) {

                if (data.data != undefined && data.data != "") {



                    $("#CndExperienceId").val(data.data.ExperienceId)
                    $("#CndExperienceCmpName").val(data.data.CompanyName);
                    $("#CndExperienceDesgination").val(data.data.DesignationName);
                    $("#CndExperienceLocation").val(data.data.LocationName);

                    $("#CndExperienceFrmMonth").val(data.data.FromMonth)
                    $("#CndExperienceFrmYear").val(data.data.fromYear)
                    $("#CndExperienceToMonth").val(data.data.ToMonth)
                    $("#CndExperienceToYear").val(data.data.ToYear)
                    $("#CndExperienceViewModel_CurrentSalary").val(data.data.CurrentSalary);
                    $("#CndExperienceViewModel_ReasonForLeaving").val(data.data.ReasonForLeaving);




                    $("#ChkCndExperiencePresent").prop("checked", data.data.IsPresent);
                    $("#ChkCndNoExperience").prop("checked", data.data.FreshGraduate);

                    $("#JobDutiesEditor .ql-editor").html(data.data.JobDuties);

          
                    if (data.data.IsPresent == true) {
                       
                        $("#CndExperienceToMonth").attr("disabled", "disabled");
                        $("#CndExperienceToYear").attr("disabled", "disabled");
                        


                    } else {
                        


                        $("#CndExperienceToMonth").removeAttr("disabled");
                        $("#CndExperienceToYear").removeAttr("disabled");
                      
                    }
                    //$("#CndQualificationViewModel_isOngoing").val(data.data.IsOnGoing)

                    $("#btnSaveExperienceData").html("Update Records")

                    
                }

            }
        });


     } else {



        swal({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3f51b5',
            cancelButtonColor: '#ff4081',
            confirmButtonText: 'Great ',
            buttons: {
                cancel: {
                    text: "Cancel",
                    value: false,
                    visible: true,
                    className: "btn btn-danger",
                    closeModal: true,
                },
                confirm: {
                    text: "OK",
                    value: true,
                    visible: true,
                    className: "btn btn-primary",
                    closeModal: true
                }
            }
        }).then(function (result) {
            
            if (result) {
                $.ajax({
                    url: "/CandidatePortal/CandidateDashboard/DeleteCandidateExperince/",
                    type: "POST",
                    data: { "Id": ExperienceId },
                    success: function (data) {



                        if (data == true) {
                            ReloadExperienceAjaxTable();
                            ShowToaster(0, "Experince Deleted", "Experince");
                        } else {
                            ShowToaster(0, "Error while deleting Records");
                        }

                    }
                });

            }

        });

       

    }

}

function ResetFields(FormcurrentIndex) {
    if (FormcurrentIndex == 110) {
        document.getElementById("CandidateWizardForm").reset();
    } else if (FormcurrentIndex == 1) {

        $("#CndQualificationViewModel_id").val(0)
        $("#CndQualificationViewModel_InstitutionName").val("")
        $("#CndQualificationViewModel_Specialization").val("")
        $("#CndQualificationViewModel_DegreeId").val("")

        $("#CndQualificationViewModel_DgrFrmMonth").val(0)
        $("#CndQualificationViewModel_DgrFrmYear").val(0)
        $("#CndQualificationViewModel_DgrToMonth").val(0)
        $("#CndQualificationViewModel_DgrToYear").val(0)
        $("#CndQualificationViewModel_ResultType").val(0)
        $("#CndQualificationViewModel_ResultValue").val("")
    } else if (FormcurrentIndex == 2) {
        $("#CndExperienceId").val(0)
        $("#CndExperienceCmpName").val("");
        $("#CndExperienceDesgination").val("");
        $("#CndExperienceLocation").val("");

        $("#CndExperienceFrmMonth").val(0);
        $("#CndExperienceFrmYear").val(0);
        $("#CndExperienceToMonth").val(0);
        $("#CndExperienceToYear").val(0);

        $("#CndExperienceViewModel_CurrentSalary").val("");
        $("#CndExperienceViewModel_ReasonForLeaving").val("");

        $("#ChkCndNoExperience").prop("checked", false)

        $("#JobDutiesEditor .ql-editor").html("");

    }

}

function ResendVerifyEmail() {
    $.ajax({
        url: "/Account/ResendVerifyAccountEmail/",
        type: "POST",
        success: function (data) {



            if (data == true) {
                
                ShowToaster(1, "Email has been re-send successfully.", "Email");
            } else {
                ShowToaster(0, "Error while sending email.");
            }

        }
    });
}



function ShowJobDescription(JobId) {
    

    var options = {
        "backdrop": "static",
        keyboard: true
    };

        $.ajax({
            url: "/CandidatePortal/Candidatejob/JObDetailPartial/",
            type: "GET",
            data: { "JobId": JobId },
            success: function (data) {

                if (data != undefined && data != "") {

                    $('#JobDescriptionModal').html(data);
                    $('#staticBackdrop').modal(options);
                    $('#staticBackdrop').modal('show');

                }

            },
            error: function () {
                alert("Content load failed.");
            }
        });




}



$(document).ready(function () {

    //$("#Emailaddress").val("abdul.aleem@artisticmilliners.com")
    //$("#Password").val("Test@123++")

    $('.CNICInputMask').inputmask('99999-9999999-9', { "clearIncomplete": true });


    $('.txtSalaryInputMask').inputmask({
        alias: 'numeric',
        allowMinus: false,
        digits: 2
        //max: 999.99
    });


    //Checkbox No Experince
    $("#ChkCndNoExperience").change(function () {
        if (this.checked) {
            $("#CndExperienceCmpName").attr("disabled", "disabled");
            $("#CndExperienceDesgination").attr("disabled", "disabled");
            $("#CndExperienceLocation").attr("disabled", "disabled");

            $("#CndExperienceFrmMonth").attr("disabled", "disabled");
            $("#CndExperienceFrmYear").attr("disabled", "disabled");
            $("#CndExperienceToMonth").attr("disabled", "disabled");
            $("#CndExperienceToYear").attr("disabled", "disabled");
            $("#ChkCndExperiencePresent").attr("disabled", "disabled");

            $("#CndExperienceViewModel_CurrentSalary").attr("disabled", "disabled");
            $("#CndExperienceViewModel_ReasonForLeaving").attr("disabled", "disabled");



        } else {

            $("#CndExperienceCmpName").removeAttr("disabled");
            $("#CndExperienceDesgination").removeAttr("disabled");
            $("#CndExperienceLocation").removeAttr("disabled");

            $("#CndExperienceFrmMonth").removeAttr("disabled");
            $("#CndExperienceFrmYear").removeAttr("disabled");
            $("#CndExperienceToMonth").removeAttr("disabled");
            $("#CndExperienceToYear").removeAttr("disabled");
            $("#ChkCndExperiencePresent").removeAttr("disabled");

            $("#CndExperienceViewModel_CurrentSalary").removeAttr("disabled");
            $("#CndExperienceViewModel_ReasonForLeaving").removeAttr("disabled");

        }
    });

    //Checkbox present Job
    $("#ChkCndExperiencePresent").change(function () {
        if (this.checked) {


            $("#CndExperienceToMonth").attr("disabled", "disabled");
            $("#CndExperienceToYear").attr("disabled", "disabled");


        } else {


            $("#CndExperienceToMonth").removeAttr("disabled");
            $("#CndExperienceToYear").removeAttr("disabled");

        }
    });


    //Experince Save add more button
    $("#btnSaveExperienceData").click(function () {
        addCandExperience(2, false);
        ReloadExperienceAjaxTable();
    });


    //Checkbox Qualification On going
    $("#CndQualificationViewModel_isOngoing").change(function () {
        if (this.checked) {


            $("#CndQualificationViewModel_DgrToMonth").attr("disabled", "disabled");
            $("#CndQualificationViewModel_DgrToYear").attr("disabled", "disabled");
            $("#CndQualificationViewModel_ResultType").attr("disabled", "disabled");
            $("#CndQualificationViewModel_ResultValue").attr("disabled", "disabled");

        } else {


            $("#CndQualificationViewModel_DgrToMonth").removeAttr("disabled");
            $("#CndQualificationViewModel_DgrToYear").removeAttr("disabled");
            $("#CndQualificationViewModel_ResultType").removeAttr("disabled");
            $("#CndQualificationViewModel_ResultValue").removeAttr("disabled");
        }
    });



    //Qualification add more button

    $("#btnSaveEducationData").click(function () {
        addCandQualification(1, false);
        ReloadAjaxTable();
    });
 


    $(".JobDetail").click(function () {
        
        ShowJobDescription($(this).attr("value"));
        
    });


});
