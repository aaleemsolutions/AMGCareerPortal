(function ($) {
    'use strict';


    function validateCandidateForm(CurrentformIndex) {


        var isvalid = true;

        if (CurrentformIndex == 0) {

            //var firstname = $("#ErrorFirstname").val();
            //var lastname = $("#ErrorLastName").val();
            //var fathername = $("#ErrorFathersName").val();
            //var cnic = $("#ErrorCNIC").val();
            //var candidateAddress = $("#ErrorCandidateAddress").val();

            var firstname = $("#FirstName").val();
            var lastname = $("#LastName").val();
            var fathername = $("#FathersName").val();
            var cnic = $("#CNIC").val();
            var candidateAddress = $("#CandidateAddress").val();

            if (isNaN(firstname) == false || firstname == "") {
                $("#ErrorFirstname").html("First name is required")
                isvalid = false;
                return isvalid;
            } else {
                $("#ErrorFirstname").html("")
                isvalid = true;
            }

            if (isNaN(lastname) == false || lastname == "") {
                $("#ErrorLastName").html("Last name is required")
                isvalid = false;

                return isvalid;

            } else {
                $("#ErrorLastName").html("")
                isvalid = true;
            }

            if (isNaN(fathername) == false || fathername == "") {
                $("#ErrorFathersName").html("Father name is required")
                isvalid = false;
                return isvalid;

            } else {
                $("#ErrorFathersName").html("")
                isvalid = true;
            }

            if (cnic == "") {
                $("#ErrorCNIC").html("CNIC is required")
                isvalid = false;
                return isvalid;
            } else {

                $("#ErrorCNIC").html("")
                isvalid = true;
            }

            if (isNaN(candidateAddress) == false || candidateAddress == "") {
                $("#ErrorCandidateAddress").html("Candidate address is required")
                isvalid = false;
                return isvalid;
            } else {
                $("#ErrorCandidateAddress").html("")
                isvalid = true;
            }



        } else if (CurrentformIndex == 2) {

        }



        return isvalid;
    }

    




    var form = $("#CandidateWizardForm");
    form.children("div").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "slideLeft",
  
        onStepChanging: function (event, currentIndex, newIndex) {
            //form.validate().settings.ignore = ":disabled,:hidden";
            var IsValidate = true;


            if (currentIndex == 0) {


                if (validateCandidateForm(currentIndex)) {
                    var getformvalue = $('#CandidateWizardForm')[0];

                    var valdata = new FormData(getformvalue);

                    //to get alert popup   
                    var fileUpload = $("#UserImage").get(0);
                    var files = fileUpload.files;

                    valdata.append("CandidateDescription", $("#quillExample1 .ql-editor").html());
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
                            return test;


                        }
                    });




                } else { return false }


            } else if (currentIndex == 1) {
                 
                if (newIndex>currentIndex) {
                    return addCandQualification(currentIndex);
                } else {
                    return true;
                }

            } else if (currentIndex == 2) {

                if (newIndex > currentIndex) {
                    return addCandExperience(currentIndex);
                } else {
                    return true;
                }

            }

            return IsValidate;



        },
        onFinishing: function (event, currentIndex) {
            form.validate().settings.ignore = ":disabled";
            return form.valid();
        },
        onFinished: function (event, currentIndex) {
            alert("Submitted!");
        },
              
        enableFinishButton: true,
        autoFocus: true,
        saveState: true
    });

    var validationForm = $("#example-validation-form");

    validationForm.val({
        errorPlacement: function errorPlacement(error, element) {
            element.before(error);
        },
        rules: {
            confirm: {
                equalTo: "#password"
            }
        }
    });
    validationForm.children("div").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        onStepChanging: function (event, currentIndex, newIndex) {
            validationForm.val({
                ignore: [":disabled", ":hidden"]
            })
            return validationForm.val();
        },
        onFinishing: function (event, currentIndex) {
            validationForm.val({
                ignore: [':disabled']
            })
            return validationForm.val();
        },
        onFinished: function (event, currentIndex) {
            alert("Submitted!");
        }
    });
    var verticalForm = $("#example-vertical-wizard");
    verticalForm.children("div").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        stepsOrientation: "vertical",
        enableFinishButton: true,
        onFinished: function (event, currentIndex) {
            alert("Submitted!");
        }
    });


    $('#CandidateWizardForm ul  li').removeClass("disabled").attr("aria-disabled", "false");
})(jQuery);
