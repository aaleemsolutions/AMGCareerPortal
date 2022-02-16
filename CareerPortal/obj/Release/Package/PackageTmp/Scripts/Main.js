function AskYesOrNo(title = "Are you sure?", msg = "You won't be able to revert this!") {

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

function ReloadJobListTable() {
    $('#JobListDataTable').DataTable().ajax.reload();
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
            debugger;
            $("#btnSaveEducationData").attr("disabled", "disabled")
            var getformvalue = $('#CandidateWizardForm')[0];
            if (getformvalue == undefined) {

                getformvalue = $('#form0')[0];
            }
            console.log(getformvalue);


            var valdata = new FormData(getformvalue);

            //to get alert popup   
            //var fileUpload = $("#UserImage").get(0);
            //var files = fileUpload.files;

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

            if (getformvalue == undefined) {

                getformvalue = $('#form0')[0];

            }

            var valdata = new FormData(getformvalue);


            valdata.append("JobDutiesDescription", $("#JobDutiesDescription").val());

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
                        $(".RichTextJobDescription").summernote('reset');

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
            heading: heading,// 'Danger',
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

                    /*$("#JobDutiesEditor .ql-editor").html(data.data.JobDuties);*/

                    console.log(data.data);
                    $("#CndExperienceViewModel_JobDuties").summernote("code", data.data.JobDuties);



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
        beforeSend: function () {
            $("#JobDetailLoader").show();
        },
        success: function (data) {

            if (data != undefined && data != "") {
                $("#JobDetailLoader").hide();
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

function ShowShortListModal(JobId, CandId) {


    var options = {
        "backdrop": "static",
        keyboard: true
    };

    $.ajax({
        url: "/Recruiter/Shortlisting/Shortlist_Cand/",
        type: "GET",
        data: { "JobApplyId": JobId, "CandId": CandId },
        success: function (data) {

            if (data != undefined && data != "") {

                $('#ShortlistModalBody').html(data);
                $('#ShortlistModalParent').modal(options);
                $('#ShortlistModalParent').modal('show');




            }

        }, beforeSend: function () {
            $("#PostLoader").show();

        }, complete: function () {

            $("#PostLoader").hide();
        },
        error: function () {
            alert("Content load failed.");
        }
    });




}

function ApplyForJob(JobId, IsAppliedByCv) {

    $.ajax({
        url: "/CandidatePortal/Candidatejob/ApplyForJob",
        type: "GET",
        //processData: false,
        //contentType: false,
        data: { "JobId": JobId, "AppliedByCv": IsAppliedByCv },
        success: function (data) {

            if (data.IsSuccess) {
                ShowToaster(1, "Applied Successfully", "Applied!");
                $('#staticBackdrop').modal('hide');
            } else {
                $(".ApplyJobError").html(data.msg)
            }

        },
        complete: function (data) {

        }
    });


}

function addNewJob() {


    if (1 == 1) {


        var getformvalue = $('#FormNewJob')[0];

        var valdata = new FormData(getformvalue);


        valdata.append("JobDescription", $("#RichTextJobDescription .ql-editor").html());



        $.ajax({
            url: "/Recruiter/AllJobs/CreateJobs",
            type: "POST",
            dataType: 'json',
            processData: false,
            contentType: false,
            data: valdata,
            success: function (data) {



            },
            complete: function (data) {

            }
        });






    } else {

    }

}


function validateShortListForm() {


    var isvalid = true;





    var InterviewDate = $("#InterviewDate").val();
    var InterviewTiming = $("#InterviewTiming").val();
    var IsEmailSend = $("#isEmailSend").is('checked');
    var isJobFormSend = $("#isJobFormSend").is('checked');
    var ShortListId = $("#ShortListId").val();

    if (isNaN(InterviewDate) == false || InterviewDate == "") {
        $(".ErrorSH_InterviewDate").html("Interview date is required")
        isvalid = false;
        return isvalid;
    } else {
        $(".ErrorSH_InterviewDate").html("")
        isvalid = true;
    }
    if (InterviewTiming < 1 || InterviewTiming < 1) {
        $(".ErrorSH_InterviewTiming").html("Please select slots")
        isvalid = false;

        return isvalid;

    } else {
        $(".ErrorSH_InterviewTiming").html("")
        isvalid = true;
    }

    if (ShortListId > 0) {
        ShowToaster(0, "Selectedt candidate already shortlist", "Already Shortlist");
        isvalid = false;

        return isvalid;

    }





    return isvalid;
}

function ShortlistCandidate() {


    if (1 == 1) {


        var getformvalue = $('#CandShortListCand')[0];

        var valdata = new FormData(getformvalue);





        $.ajax({
            url: "/Recruiter/Shortlisting/Shortlist_Cand",
            type: "POST",
            dataType: 'json',
            processData: false,
            contentType: false,
            data: valdata,
            success: function (data) {
                if (data.status == true) {
                    ShowToaster(1, "Candidate Shortlist Successfully ", "Shortlist Successfully");
                    $('#ShortlistModalParent').modal('hide');
                } else {
                    ShowToaster(0, data.message, "Error");
                    $('#ShortlistModalParent').modal('hide');
                }


            },
            complete: function (data) {

            }
        });






    } else {

    }

}

function EditNewJob(JobId) {
    if (1 == 1) {
        $.ajax({
            url: "/Recruiter/AllJobs/CreateJobs",
            type: "GET",
            data: { "Id": JobId },
            success: function (data) {


            }
        });
    }

}

function DeleteNewJob(JobId) {
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
                url: "/Recruiter/AllJobs/DeleteJob",
                type: "POST",
                data: { "JobId": JobId },
                success: function (data) {

                    if (data == true) {
                        ReloadJobListTable();

                        ShowToaster(0, "Job deleted.", "Deleted!");

                    } else {
                        ShowToaster(0, "Error While deleting Records please contact I.T", "Error!");
                    }

                }
            });
        }
    });








}


function wait(ms) {
    var start = new Date().getTime();
    var end = start;
    while (end < start + ms) {
        end = new Date().getTime();
    }
}

function DownloadCandidateResume(filename, UserId) {

    if (UserId != undefined && UserId != "") {
        location.href = "/CandidatePortal/Candidatejob/DownloadCandidateCv?filename=" + filename + "&UserId=" + UserId;
    } else {
        location.href = "/CandidatePortal/Candidatejob/DownloadCandidateCv?filename=" + filename;
    }

}

function loadBarChart(data, title = "JobData", subtext = "Artistic Milliners") {
    //var BarDBData = data;
    var BarDBData = data;

    //var BarDBData = JSON.parse('{"name":["ERP Developer","TEST"],"test":[5,10]}');

    const result = {}
    const arr = BarDBData;

    arr.forEach(row => {
        for (let i in row) {
            if (result[i]) {
                result[i].push(row[i])
            } else {
                result[i] = [row[i]]
            }
        }
    })
    console.log(result)

    console.log(BarDBData);

    var chartDom = document.getElementById('BarChart');

    var myChart = echarts.init(chartDom);

    var option;

    option = {
        title: {
            text: title,
            subtext: subtext
        },
        tooltip: {
            trigger: 'axis'
        },

        toolbox: {
            show: true,
            feature: {
                dataView: { show: true, readOnly: false },
                magicType: { show: true, type: ['line', 'bar'] },

                saveAsImage: { show: true }
            }
        },
        calculable: true,
        xAxis: [
            {
                type: 'category',
                // prettier-ignore
                //data: ["ERP Developer", "Software Engineer"],
                data: result.name,
                axisLabel: { interval: 0, rotate: 30 }
            }
        ],
        yAxis: [
            {
                type: 'value'

            }
        ],
        dataZoom: [
            {
                show: true,
                start: 04,
                end: 100
            },
            {
                type: 'inside',
                start: 44,
                end: 100
            },
            {
                show: true,
                yAxisIndex: 0,
                filterMode: 'empty',
                width: 30,
                height: '80%',
                showDataShadow: false,
                left: '93%'
            }
        ],
        series: [
            {
                name: result.name,
                type: 'bar',
                data: result.value,
                //data: [2.0, 4.9, 4, 9, 4],
                itemStyle: {
                    color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
                        { offset: 0, color: '#83bff6' },
                        { offset: 0.5, color: '#188df0' },
                        { offset: 1, color: '#188df0' }
                    ])
                },
                markPoint: {
                    data: [
                        { type: 'max', name: 'Max' },
                        { type: 'min', name: 'Min' }
                    ]
                }

            }
        ]
    };

    option && myChart.setOption(option);


    myChart.on('click', function (params) {

        swal({
            title: params.name,
            text: 'Do you want open ' + params.name + ' Records?',
            icon: 'info',
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
                    text: "Yes",
                    value: true,
                    visible: true,
                    className: "btn btn-primary",
                    closeModal: true
                }
            }
        }).then(function (result) {
            if (result) {

                if (params.name == "Not assign") {
                    location.href = "/Recruiter/AllJobs?search=" + encodeURIComponent("");
                }
                location.href = "/Recruiter/AllJobs?search=" + encodeURIComponent(params.name);
            }
        });

    });

}

function loadJobBarAjaxdata(GetBarChartData) {

    $.ajax({
        url: "/Recruiter/AllJobs/GetBarChartData",
        data: { "BarDataType": GetBarChartData },
        dataType: 'json',
        success: function (data) {
            var json = data;
            if (GetBarChartData.toUpperCase() == "Candidate".toUpperCase()) {
                loadBarChart(data, "Candidate wise Jobs");
            }
            else {
                loadBarChart(data, "Open Jobs");
            }

        }
    });
}

function loadPieChart(data, text = "Jobs Data Categories", subtext = "Artistic Milliners") {

    var PieChartData = data;

    var chartDom1 = document.getElementById('pieCharts');
    var myChart1 = echarts.init(chartDom1);
    var option;

    option = {
        title: {
            text: text,
            subtext: subtext,
            left: 'center'
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        legend: {
            orient: 'vertical',
            left: 'left'

        },
        toolbox: {
            show: true,
            feature: {
                mark: { show: true },

                magicType: {
                    show: true,
                    type: ['pie', 'funnel'],
                    option: {
                        funnel: {
                            x: '25%',
                            width: '50%',
                            funnelAlign: 'center',
                            max: 1548
                        }
                    }
                },
                restore: { show: true },
                saveAsImage: { show: true }
            }
        },
        series: [
            {
                name: text,
                type: 'pie',
                radius: '50%',
                //data: [
                //    { value: 1048, name: 'Search Engine' },
                //    { value: 735, name: 'Direct' },
                //    { value: 580, name: 'Email' },
                //    { value: 484, name: 'Union Ads' },
                //    { value: 300, name: 'Video Ads' }
                //],
                data: PieChartData,

                emphasis: {
                    itemStyle: {
                        shadowBlur: 10,
                        shadowOffsetX: 0,
                        shadowColor: 'rgba(0, 0, 0, 0.5)',
                        label: {
                            show: true, position: 'center',
                            formatter: function (params) {
                                return params.value + '%\n'
                            }
                        }
                    }
                }
            }
        ]
    };

    option && myChart1.setOption(option);

    myChart1.on('click', function (params) {

        swal({
            title: params.name,
            text: 'Do you want open ' + params.name + ' Records?',
            icon: 'info',
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
                    text: "Yes",
                    value: true,
                    visible: true,
                    className: "btn btn-primary",
                    closeModal: true
                }
            }
        }).then(function (result) {
            if (result) {

                if (params.name == "Not assign") {
                    location.href = "/Recruiter/AllJobs?search=" + encodeURIComponent("");
                }
                location.href = "/Recruiter/AllJobs?search=" + encodeURIComponent(params.name);
            }
        });

    });

}

function loadJobPieaAjaxdata(PieType) {
    $.ajax({
        url: "/Recruiter/AllJobs/GetJobPieCharts",
        data: { "PieType": PieType },
        success: function (data) {

            if (PieType.toUpperCase() == "Department".toUpperCase()) {
                loadPieChart(data, "Department wise Jobs");
            } else if (PieType.toUpperCase() == "Division".toUpperCase()) {
                loadPieChart(data, "Division wise Jobs");
            }
            else if (PieType.toUpperCase() == "Category".toUpperCase()) {
                loadPieChart(data, "Category wise Jobs");
            }

        }
    });
}

function getUrlVars() {
    var vars = {};
    var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
        vars[key] = value;
    });
    return vars;

}



function DeleteCand_Dependants(Id, row) {
    if (Id != 0)

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
                if (Id != 0) {
                    $.ajax({
                        url: "/Recruiter/CandidateForm/DeleteCand_Dependants",
                        type: "POST",
                        data: { "Dependand_Id": Id },
                        success: function (data) {

                            if (data == true) {

                                ShowToaster(0, "Dependant Deleted.", "Deleted!");
                                $(row).remove();

                            } else {
                                ShowToaster(0, "Error While deleting Records please contact I.T", "Error!");
                            }

                        }
                    });
                } else {
                    $(row).remove();
                }

            }
        });
    else
        $(row).remove();









}


function UnMaskingInput() {
}



function ValidateAddPanelEmployee() {


    var isvalid = true;

    var EmployeeId = $("#DrpHREmployee").val();


    if (EmployeeId < 1) {
        $(".panelEmployeeError").html("Kindly select Employee")
        isvalid = false;
        return isvalid;
    } else {
        $(".panelEmployeeError").html("")
        isvalid = true;
    }



    return isvalid;
}

function FillDepartmentonUnitType(UnitType) {
    var ddlDepartment = $("#DrpHRDepartment");
    $.ajax({
        url: "/Recruiter/HRPanel/FillDepartmentOnUnit",
        type: "GET",
        data: { "UnitType": UnitType },
        beforeSend: function () {
            $('#PostLoaderHRPerson').show();
        },
        success: function (data) {
            ddlDepartment.empty();
            //ddlDepartment.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(data, function () {
                
                ddlDepartment.append($("<option></option>").val(this['Value']).html(this['Text']));
            });

        }, complete: function (data) {

            $('#PostLoaderHRPerson').hide();
        }
    });
}


function FillEmployeeOnDepartment(DepartmentId, UnitType) {
    var ddlEmployee = $("#DrpHREmployee");
    $.ajax({
        url: "/Recruiter/HRPanel/FillEmployeeOnDepartment",
        type: "GET",
        data: { "DepartmentId": DepartmentId, "UnitType": UnitType },
        beforeSend: function () {
            $('#PostLoaderHRPerson').show();
        },
        success: function (data) {
            ddlEmployee.empty();
            //ddlDepartment.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(data, function () {
              
                ddlEmployee.append($("<option></option>").val(this['Value']).html(this['Text']));
            });

        }, complete: function (data) {

            $('#PostLoaderHRPerson').hide();
        }
    });
}
function FillEmployeeDetailOnEmp(EmployeeId, UnitType) {

    $.ajax({
        url: "/Recruiter/HRPanel/FillEmployeeDetailOnEmployeeDrp",
        type: "GET",
        data: { "EmployeeId": EmployeeId, "UnitType": UnitType },
        beforeSend: function () {
            $('#PostLoaderHRPerson').show();
        },
        success: function (data) {
            $("#InterviewPerson_Email").val(data.Email);
            $("#InterviewPerson_MobileNo").val(data.Mobile);
        }, complete: function (data) {

            $('#PostLoaderHRPerson').hide();
        }
    });
}

function AddUpdatePanelEmployee() {


    var getformvalue = $('#HRAddUpdatePanelEmpoyee')[0];
    var UnitTypeValue = $("#DrpHRUnitType").val();
    var valdata = new FormData(getformvalue);
    valdata.append("UnitType", UnitTypeValue);
    $.ajax({
        url: "/Recruiter/HRPanel/AddUpdatePanelEmployee",
        type: "POST",
        dataType: 'json',
        processData: false,
        contentType: false,
        data: valdata,
        beforeSend: function () {
            $('#PostLoaderHRPerson').show();
        },
        success: function (data) {
            if (data.status == true) {
                ShowToaster(1, data.message, data.title);
                ReloadPanelEmployee();
            } else {
                ShowToaster(0, data.message, "Error");

            }

            $("#btnaddPanelEmployee").html("Add Employee In Panel")
            getformvalue.reset();
            $("#DrpHRUnitType").val(0)
            $("#InterviewPerson_Id").val(0)
            
            var ddlDepartment = $("#DrpHRDepartment");
            var ddlEmployee = $("#DrpHREmployee");
            var ddlUnitType = $("#DrpHRUnitType");
            
            ddlDepartment.empty();
            ddlEmployee.empty();
            
        },
        complete: function (data) {
            $('#PostLoaderHRPerson').hide();
        }
    });



}

function DeletePanelPerson(PersonId) {

 
    $.ajax({
        url: "/Recruiter/HRPanel/DeletePanelEmployee",
        
        dataType: 'json',
        
        data: { "panelEmployeeId": PersonId },
        beforeSend: function () {
            $('#PostLoaderHRPerson').show();
        },
        success: function (data) {
            ShowToaster(1, data.message, data.title);
            ReloadPanelEmployee();
        },
        complete: function (data) {
            $('#PostLoaderHRPerson').hide();
        }
    });



}


function PanelEmployeesSelectDelete(isselect, PanelPersonId) {
    if (isselect == 1) {



        $.ajax({
            url: "/Recruiter/HRPanel/GetPanelEmployee/",
            data: { "panelEmployeeId": PanelPersonId },
            beforeSend: function () {
                $('#PostLoaderHRPerson').show();
            },

            success: function (data) {
                
                if (data.data != undefined && data.data != "") {

                    var ddlDepartment = $("#DrpHRDepartment");
                    var ddlEmployee = $("#DrpHREmployee");
                    var ddlUnitType = $("#DrpHRUnitType");
                    var txtEmail = $("#InterviewPerson_Email");
                    var txtMobile = $("#InterviewPerson_MobileNo");
                    var HiddenPPID = $("#InterviewPerson_Id");
                    ddlDepartment.empty();
                    ddlEmployee.empty();
                    $.each(data.DepartmentDrop, function (index, value) {
                        
                        //console.log(this);
                       ddlDepartment.append($("<option></option>").val(this['Value']).html(this['Text']));
                    });

                    
                
                    //ddlDepartment.empty().append('<option selected="selected" value="0">Please select</option>');
                    $.each(data.EmployeeDrop, function () {

                        ddlEmployee.append($("<option></option>").val(this['Value']).html(this['Text']));
                    });
                    console.log(data.data.DepartmentId)
                    ddlDepartment.val(data.data.DepartmentId);
                    ddlEmployee.val(data.data.EmployeeId);
                    ddlUnitType.val(data.data.UnitType);
                    txtEmail.val(data.data.Email);
                    txtMobile.val(data.data.Mobile);
                    HiddenPPID.val(data.data.HiddenPPId);

                    $("#btnaddPanelEmployee").html("Update Panel Employee")
                }

            }
             ,complete: function (data) {

                $('#PostLoaderHRPerson').hide();
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
            DeletePanelPerson(PanelPersonId);
            
        });

    }

}

function ReloadPanelEmployee() {
    $('#DataTableHRPanelEmployee').DataTable().ajax.reload();
}

function ReloadInterviewPanel() {
    $('#DtInterviewPanel').DataTable().ajax.reload();
}


function ValidatePanel() {


    var isvalid = true;

    var PanelName = $("#InterviewPanels_PanelName").val();
    var PanelEmployee = $("#BindPanelPerson").val();


    if (isNaN(PanelName) == false || PanelName == "") {
        $(".ErrorPanelName").html("Panel Name is required")
        isvalid = false;
        return isvalid;
    } else {
        $(".ErrorPanelName").html("")
        isvalid = true;
    }


    if (PanelEmployee < 1) {
        $(".ErrorPanelEmployees").html("Kindly select Employee")
        isvalid = false;
        return isvalid;
    } else {
        $(".ErrorPanelEmployees").html("")
        isvalid = true;
    }


    return isvalid;
}


function getPanel(PanelId) {

    $.ajax({
        url: "/Recruiter/HRPanel/getInterviewPanel/",
        data: { "panelId": PanelId },
        beforeSend: function () {
            $('#PostLoaderHRPerson').show();
        },

        success: function (data) {

            if (data.data != undefined && data.data != "") {

                var EmployeesDrpDown = $("#BindPanelPerson");
                var PanelName = $("#InterviewPanels_PanelName");
                var PanelId = $("#InterviewPanels_Id");
        
                console.log(data.Employees);

                EmployeesDrpDown.val(data.data.Employees).trigger('change');
                PanelName.val(data.data.PanelName);
                PanelId.val(data.data.PanelId);


                $("#btnPanel").html("Update Panel")
            }

        }
        , complete: function (data) {

            $('#PostLoaderHRPerson').hide();
        }
    });

}

function CreateUpdatePanel() {


    var getformvalue = $('#FormInterviewPanels')[0];

    var PanelPersonId = $("#BindPanelPerson").val();
   
    var valdata = new FormData(getformvalue);
    valdata.append("PanelPersonId", PanelPersonId);


    $.ajax({
        url: "/Recruiter/HRPanel/InterviewPanels",
        type: "POST",
        dataType: 'json',
        processData: false,
        contentType: false,
        data: valdata,
        beforeSend: function () {
            $('#PostLoaderHRPerson').show();
        },
        success: function (data) {
            if (data.status == true) {
                ShowToaster(1, data.message, data.title);
                ReloadInterviewPanel();
                getformvalue.reset();
                $('#BindPanelPerson').val(null).trigger('change');
                $("#InterviewPanels_Id").val(0);
                $("#btnPanel").html("Create Panel")
            } else {
                ShowToaster(0, data.message, "Error");

            }


            
 

        },
        complete: function (data) {
            $('#PostLoaderHRPerson').hide();
        }
    });



}


function deleteInterviewPanel(PanelId) {


    $.ajax({
        url: "/Recruiter/HRPanel/DeletePanel",

        dataType: 'json',

        data: { "panelId": PanelId },
        beforeSend: function () {
            $('#PostLoaderHRPerson').show();
        },
        success: function (data) {
            ShowToaster(1, data.message, data.title);
            ReloadInterviewPanel();
        },
        complete: function (data) {
            $('#PostLoaderHRPerson').hide();
        }
    });



}


$(document).ready(function () {
    $("#JobDetailLoader").hide();
    $("#DrpDepart").change(function () {

        var drpvalue = $("#DrpDepart option:selected").text();;
        $("#DepartmentName").val(drpvalue)

    });

    $("#DrpDesig").change(function () {

        var drpvalue = $("#DrpDesig option:selected").text();;
        $("#DesignationName").val(drpvalue)

    });

    $("#DrpDivision").change(function () {

        var drpvalue = $("#DrpDivision option:selected").text();;
        $("#DivisionName").val(drpvalue)

    });

    $("#DrpCategory").change(function () {

        var drpvalue = $("#DrpCategory option:selected").text();;
        $("#CategoryName").val(drpvalue)

    });

    $("#DrpPieType").change(function () {

        var drpvalue = $("#DrpPieType").val();
        loadJobPieaAjaxdata(drpvalue);

    });

    $("#DrpBarType").change(function () {

        var drpvalue = $("#DrpBarType").val();
        loadJobBarAjaxdata(drpvalue);

    });


    $("#DrpHRUnitType").change(function () {
        $("#DrpHRDepartment").empty()
        $("#DrpHREmployee").empty()
        var UnitTypeValue = $("#DrpHRUnitType").val();
        FillDepartmentonUnitType(UnitTypeValue);
    });

    $("#DrpHRDepartment").change(function () {

        var DepartmentId = $("#DrpHRDepartment").val();
        var UnitTypeValue = $("#DrpHRUnitType").val();
        FillEmployeeOnDepartment(DepartmentId, UnitTypeValue);
    });

    $("#DrpHREmployee").change(function () {

        var EmployeeId = $("#DrpHREmployee").val();
        var UnitTypeValue = $("#DrpHRUnitType").val();
        FillEmployeeDetailOnEmp(EmployeeId, UnitTypeValue);
    });

    $("#Emailaddress").val("abdul.aleem@artisticmilliners.com");

    $("#Password").val("Test@123++");

    $('.CNICInputMask').inputmask('99999-9999999-9', { "clearIncomplete": true });

    $('.MobileNoMask').inputmask('9999-9999999', { "clearIncomplete": true });

    $('.validateTextOnly').inputmask({

        //alias: 'text',
        regex: "^[a-zA-Z ]*$"

    });
    //'€ 999.999.999,99', { numericInput: true }
    $('.txtSalaryInputMask').inputmask({

        rightAlign: false,
        'alias': 'decimal',
        'groupSeparator': ',',
        'autoGroup': true,
        'digits': 0,
        'digitsOptional': false,
        'placeholder': '0.00',
        autoUnmask: true
    });


    $('.validatenumeric').inputmask({

        alias: 'numeric',
        allowMinus: false,
        rightAlign: false,

    });



    $('.validateCurrency').inputmask({

        //alias: 'numeric',
        //allowMinus: false,
        rightAlign: false,
        'alias': 'decimal',
        'groupSeparator': ',',
        'autoGroup': true,
        'digits': 0,
        'digitsOptional': false,
        'placeholder': '0.00',
        autoUnmask: true

    });

    $('.validateemail').inputmask({

        alias: 'email',
        "clearIncomplete": true,
        autoUnmask: true

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

    $("#isJobFormSend").change(function () {
        if (this.checked) {


            $(".richtextJobButton").show()


        } else {
            $(".richtextJobButton").hide()

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

    $("#btnSaveEducationData").unbind().click(function () {
        addCandQualification(1, false);
        ReloadAjaxTable();
    });



    $(".JobDetail").unbind().click(function () {
        debugger;
        ShowJobDescription($(this).attr("value"));

    });

    $("#btnApplyJob").unbind().click(function () {


        var jobid = $("#JobIdentity").val();
        var appliedbyCv = $("input[type='radio'][name='AppliedByCv']:checked").val();
        ApplyForJob(jobid, appliedbyCv);

    });

    var table = $('#JobListDataTable').DataTable({

        "ajax": {
            "url": "/Recruiter/AllJobs/GetJobsDataTable/",
            "type": "POST",
            "datatype": "json",
            //"contentType": 'application/json'

            "dataSrc": function (json) {
                //Make your callback here.

                //ShowToaster(1, "Record Updated Successfully.", "Record Updated!");
                return json.data;
            }

        },
        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }
            ],
        "oLanguage": {
            "sEmptyTable": "No Job List Found.."
        },

        "columns": [
            //{
            //    "className": 'dt-control',
            //    "orderable": false,
            //    "data": null,
            //    "defaultContent": ''
            //},

            { "data": "JobId" },
            {
                //                "render": function (data, type, full, meta) { return '<a class="btn" type="" onClick="EditNewJob(' + full.JobId + ')"><span class="ti-pencil")></span></a> <a class="btn" type="button" onClick="DeleteNewJob(' + full.JobId + ')"><span class="ti-trash")></a>'; }
                "render": function (data, type, full, meta) { return '<a class="btn" type="" target="_blank" href="/Recruiter/AllJobs/ViewJobCandidates/?JobId=' + full.JobId + '"  title="View Cabdidates" ><span class="ti-eye")></span></a> <a class="btn" type=""  href="/Recruiter/AllJobs/CreateJobs/' + full.JobId + '"><span class="ti-pencil")></span></a> <a class="btn" type="button" onClick="DeleteNewJob(' + full.JobId + ')"><span class="ti-trash")></a>'; }
            },
            { "data": "JobTitle" },
            { "data": "JobLocation" },

            { "data": "PostedDate" },
            { "data": "NoOfVacancy" },
            { "data": "EmployementType" },
            { "data": "SalaryRange" },
            { "data": "NoOfAppliedCnd" },
            { "data": "Division" },
            { "data": "Category" },
            { "data": "Department" },
            { "data": "Designation" }




        ],
        "order": [[3, 'desc']],
        "initComplete": function () {
            var searchparam = decodeURIComponent(getUrlVars()['search']);

            if (searchparam != "undefined" && undefined != "") {

                this.api().search(searchparam).draw();
            }

        }
    });

    //Add event listener for opening and closing details
    $('#JobListDataTable tbody').on('click', 'td.dt-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        }
        else {
            // Open this row
            row.child(format(row.data())).show();
            tr.addClass('shown');
        }
    });

    function format(d) {
        // `d` is the original data object for the row
        return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
            '<tr>' +
            '<td>Description:</td>' +
            '</tr>' +
            '<tr>' +
            '<td>' + d.JobDescription + '</td>' +

            '</tr>' +


            '</table>';
    }


    //CV Bank List
    var table = $('#CvCandidateList').DataTable({
        stateSave: true,
        "pageLength": 100,
        "lengthMenu": [[10, 25, 50, 100, 500, -1], [10, 25, 50, 100, 500, "All"]],
        "ajax": {
            "url": "/Recruiter/cvBank/GetCVCandidate/",
            "type": "POST",
            "datatype": "json",
            //"contentType": 'application/json'

            "dataSrc": function (json) {
                //Make your callback here.

                //ShowToaster(1, "Record Updated Successfully.", "Record Updated!");
                return json.data;
            }

        },
        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }
            ],
        "oLanguage": {
            "sEmptyTable": "No List Found.."
        },

        "columns": [

            { "data": "CVID" },
            {
                //                "render": function (data, type, full, meta) { return '<a class="btn" type="" onClick="EditNewJob(' + full.JobId + ')"><span class="ti-pencil")></span></a> <a class="btn" type="button" onClick="DeleteNewJob(' + full.JobId + ')"><span class="ti-trash")></a>'; }
                "render": function (data, type, full, meta) { return '<a class="btn" type="" target="self" href="/Recruiter/cvBank/CvDetail/?CvId=' + full.CVID + '"  title="View Candidates" ><span class="ti-eye")></span></a>   '; }
            },
            { "data": "CandidateName" },
            { "data": "FatherHusbandName" },
            { "data": "DepartmentName" },
            { "data": "DesignationName" },
            { "data": "CategoryName" },
            { "data": "Gender" },
            { "data": "MaritalStatus" },
            { "data": "CNIC" },
            { "data": "CNICExpire" },
            { "data": "DOB" },
            { "data": "Mobile" },
            { "data": "Email" },
            { "data": "CurrentAddress" },
            { "data": "LastUpdateDate" }

        ],
        "order": [[3, 'desc']],
        "initComplete": function () {
            var searchparam = decodeURIComponent(getUrlVars()['search']);

            if (searchparam != "undefined" && undefined != "") {

                this.api().search(searchparam).draw();
            }

        }
    });

    $('#CvCandidateList tbody').on('click', 'tr', function () {
        $('#CvCandidateList tbody > tr').removeClass('focusedRow');
        $(this).addClass('focusedRow');
    });

    if (window.location.pathname.toString() == "/Recruiter/AllJobs") {
        $("#AllListedJobs ul li:nth-child(1)").removeClass("active");
        $("#AllListedJobs ul li:nth-child(3)").removeClass("active");
        $("#AllListedJobs ul li:nth-child(4)").removeClass("active");
        $("#AllListedJobs ul li:nth-child(5)").removeClass("active");
    }
    if (window.location.pathname.toString() == "/Recruiter/AllJobs/CreateJobs") {

        $("#AllListedJobs ul li:nth-child(5)").removeClass("active");
    }


    var tableDependants = $('#tableDependants')[0];

    $(tableDependants).delegate('.addDynamicRow', 'click', function () {
        var thisRow = $(this).closest('tr')[0];
        var newRow = $(thisRow).clone(true);
        $(newRow).find('input:hidden').val('0')
        newRow.insertAfter(thisRow).find('input:text').val('').find('input:date').val('');


        $('input[name^="Cand_Dependants"]').each(function () {
            var currenrow = $('#tableDependants tbody tr').length - 1;
            var oldname = $(this).attr('name');
            //var newname = $(this).attr('name').replace('[0]', '[' + currenrow + ']');
            var newname = oldname.substr(0, oldname.indexOf('[') + 1) + currenrow + oldname.substr(oldname.indexOf(']'), oldname.length);
            //alert($(this).attr('name'));
            $(newRow).find('input[name="' + $(this).attr('name') + '"]').attr('name', newname)
            //            alert($(this).attr('name'));



        });

        if ($(thisRow).find('.tblDplAction').find('.removeDynamicRow').length == 0) {
            $(newRow).find('.tblDplAction').append('<button type="button" class="btn btn-sm btn-danger removeDynamicRow">Delete Row</button>');
        }

        $(newRow).find('.pastdate').val('');
        $(newRow).find('.pastdate').datepicker({

            format: "dd-M-yyyy"
        });




    });

    $(tableDependants).delegate('.removeDynamicRow', 'click', function () {

        var dependantId = $(this).closest('tr').find('input[name$="Id"]').val();

        DeleteCand_Dependants(dependantId, $(this).closest('tr'));


    });


    $(".ShortlistCandidate").unbind().click(function () {

        ShowShortListModal($(this).attr("value"), $(this).closest('td').find('.CandUserId').val());

    });



    $("#btnSubmitShortlistCand").unbind().click(function () {
        if (validateShortListForm()) {
            ShortlistCandidate(1, false);

        }

    });


    $("#btnaddPanelEmployee").unbind().click(function () {
        if (ValidateAddPanelEmployee()) {
            AddUpdatePanelEmployee();

        }

    });


    

    var table = $('#DataTableHRPanelEmployee').DataTable({
     
        "pageLength": 100,
        "lengthMenu": [[10, 25, 50, 100, 500, -1], [10, 25, 50, 100, 500, "All"]],
        "ajax": {
            "url": "/Recruiter/HRPanel/DtgetPanelEmployees/",
            "type": "POST",
            "datatype": "json",
            "contentType": 'application/json',

            "dataSrc": function (json) {
                
              return json.data;
            }

        },
        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }
            ],
        "oLanguage": {
            "sEmptyTable": "No List Found.."
        },

        "columns": [

            { "data": "CustomTbId" }
            ,{ "data": "EmployeeName" }
            ,{ "data": "Designation_Name" }
            ,{ "data": "Department_Name" }
            ,{ "data": "BranchName" }
            ,{
                "render": function (data, type, full, meta) { return '<a class="btn" type="" href="#" onclick=PanelEmployeesSelectDelete(1,' + full.CustomTbId + ')><span class="ti-pencil"></span></a><a class="btn"   href="#" onclick=PanelEmployeesSelectDelete(0,' + full.CustomTbId +')><span class="ti-trash"></span></a>'; }
            }

        ]
        //,"order": [[2, 'desc']]
     
    });


    var table = $('#DtInterviewPanel').DataTable({

        "pageLength": 100,
        "lengthMenu": [[10, 25, 50, 100, 500, -1], [10, 25, 50, 100, 500, "All"]],
        "ajax": {
            "url": "/Recruiter/HRPanel/DtgetInterviewPanel/",
            "type": "POST",
            "datatype": "json",
            "contentType": 'application/json',

            "dataSrc": function (json) {

                return json.data;
            }

        },
        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }
            ],
        "oLanguage": {
            "sEmptyTable": "No List Found.."
        },

        "columns": [

            { "data": "PanelId" }
            , { "data": "PanelName" }
            , { "data": "Employees" }
            , {
                "render": function (data, type, full, meta) { return '<a class="btn" type="" href="#" onclick=getPanel(' + full.PanelId + ')><span class="ti-pencil"></span></a><a class="btn"   href="#" onclick=deleteInterviewPanel(' + full.PanelId + ')><span class="ti-trash"></span></a>'; }
            }

        ]
        //,"order": [[2, 'desc']]

    });



    var table = $('#InterviewListDataTable').DataTable({

        "ajax": {
            "url": "/Recruiter/Shortlisting/GetInterviewListDataTable/",
            "datatype": "json",
            "dataSrc": function (json) {
                return json.data;
            }
        },
        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }
            ],
        "oLanguage": {
            "sEmptyTable": "No Job List Found.."
        },

        "columns": [
    

            { "data": "HRShortlistId" },
            { "data": "CandidateName" },
            { "data": "PosTitle" },
            { "data": "InterviewDate" },
            { "data": "InterviewTime" },
            { "data": "InterviewStatus" },
          
            {
                "render": function (data, type, full, meta) { return '<a class="btn" type="" target="_blank" href="#"  title="View Candidates" ><span class="ti-eye")></span></a> <a class="btn" type=""  href="/Recruiter/AllJobs/CreateJobs/' + full.JobId + '"><span class="ti-pencil")></span></a> '; }
            }



        ],
        "initComplete": function () {
            var searchparam = decodeURIComponent(getUrlVars()['search']);

            if (searchparam != "undefined" && undefined != "") {

                this.api().search(searchparam).draw();
            }

        }
    });


    $("#btnPanel").unbind().click(function () {
        if (ValidatePanel()) {
            
            CreateUpdatePanel();
        }

    });


});
