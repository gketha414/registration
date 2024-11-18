$(document).ready(function () {
    var patientData = {}
    //  $("#PatientDemographicsViewModel_EmployerZip").jqxMaskedInput({mask: '#####-####' });
    /* Mask for Zip code */
    //Inputmask("9{2}[-]9{2}[-]9{4}", {
    //    placeholder: "-",
    //    greedy: false
    //}).mask('#PatientDemographicsViewModel_EmployerZip');
    //   $("#PatientDemographicsViewModel_SSN").mask("99999-9999"); //SSN Mask
    $('#PatientDemographicsViewModel_SSN').unmask().maskSSN('999-99-9999', { maskedChar: 'X', maskedCharsLength: 5 });

    //   $('#PatientDemographicsViewModel_Home_Phone').maskSSN('(999) 999-9999');

    $('#PatientDemographicsViewModel_Home_Phone').usPhoneFormat({
        format: '(xxx) xxx-xxxx',
    });

    $('#PatientDemographicsViewModel_Cell_Phone').usPhoneFormat({
        format: '(xxx) xxx-xxxx',
    });

    $('#PatientDemographicsViewModel_EmployerPhone').usPhoneFormat({
        format: '(xxx) xxx-xxxx',
    });

    $('#PatientDemographicsViewModel_EmployerZip').usPhoneFormat({
        format: 'xxxxx-xxxx',
    });
    $('#SpouseInformation_Home_Phone').usPhoneFormat({
        format: '(xxx) xxx-xxxx',
    });
    $('#MinorInformation_HomePhone').usPhoneFormat({
        format: '(xxx) xxx-xxxx',
    });

    //     $("#PatientDemographicsViewModel_EmployerZip").inputmask("xx-xxxxxxxx");
    // $('#PatientDemographicsViewModel.ZipCode').mask("?99999-9999");
    //     $('input[name="PatientDemographicsViewModel.ZipCode"]').mask('S0S 0S0');


    //$('#Email').on('blur', function () {
    //    if (!IsEmail($('#Email').val())) {
    //        $('#invalid_email').show();
    //        $("#submitBtn").prop("disabled", true);
    //    } else {
    //        $('#invalid_email').hide();
    //        $("#submitBtn").prop("disabled", false);
    //    }
    //});

    //function IsEmail(email) {
    //    var regex = /^([a-zA-Z0-9_\.\-\+])+\@@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2, 4})+$/;
    //    if (!regex.test(email)) {
    //        return false;
    //    } else {
    //        return true;
    //    }
    //}

    var navListItems = $('div.setup-panel div a'),
        allWells = $('.setup-content'),
        allNextBtn = $('.nextBtn');

    allWells.hide();

    navListItems.click(function (e) {
        e.preventDefault();
        var $target = $($(this).attr('href')),
            $item = $(this);
        if ($target.selector === "#step7") {
            // document.getElementById('saveButtonForm').style = "display:block";

        } else {
            //  document.getElementById('saveButtonForm').style = "display:none";
        }
        if (!$item.hasClass('disabled')) {
            navListItems.removeClass('btn-success').addClass('btn-default');
            $item.addClass('btn-success');
            allWells.hide();
            $target.show();
            $target.find('input:eq(0)').focus();
        }
    });

    allNextBtn.click(function () {
        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
            curInputs = curStep.find("input[type='text'],input[type='url']"),
            isValid = true;

        $(".form-group").removeClass("has-error");
        //for (var i = 0; i < curInputs.length; i++) {
        //    if (!curInputs[i].validity.valid) {
        //        isValid = false;
        //        $(curInputs[i]).closest(".form-group").addClass("has-error");
        //    }
        //}

        // if (isValid) nextStepWizard.removeAttr('disabled').trigger('click');
    });

    $('div.setup-panel div a.btn-success').trigger('click');

    //$('input[type=radio][name=PatientDemographicsViewModel.HospitalService]').change(function () {
    //    if (this.value == 'allot') {
    //        // ...
    //    }
    //    else if (this.value == 'transfer') {
    //        // ...
    //    }
    //});
    //$('#PatientDemographicsViewModel_HospitalService').change(function () {
    //    alert('Radio Box has been changed!'); divHSOther
    //}); $('#divHSOther').show();
    $("input[type=radio][name='PatientDemographicsViewModel.HospitalService']").on('change', function () {
        switch ($(this).val()) {
            case 'Other':
                $('#divHSOther').show();
                break;
            default:
                $('#divHSOther').hide();
                break;
        }
    });

    if ($("#guarantor option:selected").val() === '4') {
        //   canSubmit = false;
        $('#divGuarNameIfOther').show();
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
        //  errorMessages = errorMessages + "<ul><li>" + "Race" + " field is required.</li></ul>";
    } else {
        $('#divGuarNameIfOther').hide();
    }

    $("#guarantor").change(function () {
        if ($("#guarantor option:selected").val() !== '0') {
            $("#guarantor").css({ "background-color": "" });
        }
        if ($("#guarantor option:selected").val() === '4') {
            $('#divGuarNameIfOther').show();
        }
        else {
            $('#divGuarNameIfOther').hide();
        }
    });

    $("input[type=radio][name='PatientDemographicsViewModel.ResponsiblePartyID']").on('change', function () {
        switch ($(this).val()) {
            case 'Other':
                $('#divGuarNameIfOther').show();
                break;
            default:
                $('#divGuarNameIfOther').hide();
                break;
        }
    });

    $("input[type=radio][name='PatientDemographicsViewModel.ResponsiblePartyID']").on('change', function () {
        switch ($(this).val()) {
            case '4':
                $('#divGuarNameIfOther').show();
                break;
            default:
                $('#divGuarNameIfOther').hide();
                break;
        }
    });
});


//function PatientToMinorDropdownSelect() {
//    const value = document.getElementById('guarantor').value;
//    $('#choosegurantor').prop('disabled', false);  // Enable the dropdown
//    $('#choosegurantor').val(value);               // Set the value
//    $('#choosegurantor').prop('disabled', true);
//    document.getElementById("MinorInformation_MontherMinorInformation_ResponsiblePartyID").value = value;


//    if (value === '1') {
//        $('#divMinorMother').show();
//        $('#divMinorFather').hide();
//    }
//    else if (value === '2') {
//        $('#divMinorMother').hide();
//        $('#divMinorFather').show();
//    }
//    else if (value === '3') {
//        $('#divMinorMother').show();
//        $('#divMinorFather').show();
//    }
//    else {
//        $('#divMinorMother').hide();
//        $('#divMinorFather').hide();
//    }

//}
let PersonId = 0;
let UpateIdSpouse = 0;
let fatherId = 0;
let motherId = 0;
let emergencyId1 = 0;
let emergencyId2 = 0;
let emergencyId3 = 0;
let insuranceId1 = 0;
let insuranceId2 = 0;
let insuranceId3 = 0;
let accidentUpdateId = 0;
function onResponsiblePartyChange() {

    $('#divMinorFather input[type="text"], #divMinorFather input[type="tel"], #divMinorFather select').val('');
    $('#divMinorFather select').prop('selectedIndex', 0);


    $('#divMinorMother input[type="text"], #divMinorMother input[type="tel"], #divMinorMother select').val('');
    $('#divMinorMother select').prop('selectedIndex', 0);
}

//Step 1 Validation
function onPatientClick() {
    var canUserSubmit = validatePatientData();

    if (canUserSubmit) {
        PhoneNoClean();
        var PatientData = document.getElementById('patient');
        var formData = new FormData(PatientData);
        var updateId = PersonId;
        formData.append('updateId', updateId);
        var submitPatientDataUrl = document.getElementById("Url1").value;



        $.ajax({
            url: submitPatientDataUrl,
            type: 'POST',
            data: formData,
            contentType: false,  // Required for FormData
            processData: false,  // Required for FormData
            dataType: 'json',
            success: function (response) {
                if (response > 0) {
                    PersonId = response;
                    $('#patient').hide();
                    $('#spouse').show();
                    enableNextStep('spouse');
                }
            },
            error: function (xhr, status, error) {
                console.log('Error: ' + error);
            }
        });

    }
}
function onSpouseClick() {

    var notMarried = $("#notmarried").is(":checked");
    if (notMarried) {
        $('#spouse').hide();
        $('#minor').show();
        enableNextStep('minor');

    }
    var canUserSubmit = validateSpouseData();
    if (canUserSubmit) {
        var spouseData = document.getElementById('spouse');

        var formData = new FormData(spouseData);
        var updateId = PersonId;

        formData.append('personId', updateId);
        formData.append('updateId', UpateIdSpouse);
        var submitSpouseDataUrl = document.getElementById("Url2").value;

        $.ajax({
            url: submitSpouseDataUrl,
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            dataType: 'json',
            success: function (response) {
                console.log(response);
                UpateIdSpouse = response;
                $('#spouse').hide();
                $('#minor').show();
                enableNextStep('minor');
            },
            error: function (xhr, status, error) {
                console.log('Error: ' + error);
            }
        });


    }
}

function onMinorClick() {

    var notMinor = $("#notMinor").is(":checked");
    if (notMinor) {
        $('#minor').hide();
        $('#emergency').show();
        enableNextStep('emergency');
    }
    var canUserSubmit = validateMinorData();
    if (canUserSubmit) {

        var minorData = document.getElementById('minor');
        var formData = new FormData(minorData);

        formData.append('personId', PersonId);
        formData.append('fatherId', fatherId);
        formData.append('motherId', motherId);
        var submitMinorDataUrl = document.getElementById("Url3").value;

        $.ajax({
            url: submitMinorDataUrl,
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            dataType: 'json',
            success: function (response) {
                debugger;
                console.log(response);
                fatherId = response.FatherId;
                motherId = response.MotherId;
                $('#minor').hide();
                $('#emergency').show();
                enableNextStep('emergency');
            },
            error: function (xhr, status, error) {
                console.log('Error: ' + error);
            }
        });

    }
}

function onEmergencyClick() {

    var emergecny = $("#emergecny").is(":checked");
    if (emergecny) {
        $('#emergency').hide();
        $('#insurance').show();
        enableNextStep('insurance');
    }
    var canUserSubmit = validateEmergencyData();
    if (canUserSubmit) {
        var emergencyData = document.getElementById('emergency');
        var formData = new FormData(emergencyData);
        formData.append('personId', PersonId);
        formData.append('emgId1', emergencyId1);
        formData.append('emgId2', emergencyId2);
        formData.append('emgId3', emergencyId3);
        var submitEmergencyDataUrl = document.getElementById("Url4").value;


        $.ajax({
            url: submitEmergencyDataUrl,
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            dataType: 'json',
            success: function (response) {
                console.log(response);
                emergencyId1 = response.EmergencyContactOneEmergContactID;
                emergencyId2 = response.EmergencyContactTwoEmergContactID;
                emergencyId3 = response.EmergencyContactThreeEmergContactID;
                $('#emergency').hide();
                $('#insurance').show();
                enableNextStep('insurance');
            },
            error: function (xhr, status, error) {
                console.log('Error: ' + error);
            }
        });

    }
}

function onInsuranceClick() {

    var insuranceCheckBox = $("#insuranceCheckBox").is(":checked");
    if (insuranceCheckBox) {
        $('#insurance').hide();
        $('#accident').show();
        enableNextStep('accident');
    }
    var canUserSubmit = validateInsuranceData();
    if (canUserSubmit) {

        var insuranceData = document.getElementById('insurance');
        var formData = new FormData(insuranceData);
        formData.append('personId', PersonId);
        formData.append('insId1', insuranceId1);
        formData.append('insId2', insuranceId2);
        formData.append('insId3', insuranceId3);
        var submitInsuranceDataUrl = document.getElementById("Url5").value;



        $.ajax({
            url: submitInsuranceDataUrl,
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            dataType: 'json',
            success: function (response) {
                console.log(response);
                insuranceId1 = response.InsId1;
                insuranceId2 = response.InsId2;
                insuranceId3 = response.InsId3;
                $('#insurance').hide();
                $('#accident').show();
                enableNextStep('accident');
            },
            error: function (xhr, status, error) {
                console.log('Error: ' + error);
            }
        });

    }
}
function onAccidentClick() {
    var canUserSubmit = validateAccidentData();
    if (canUserSubmit) {
        var accidentData = document.getElementById('accident');
        var formData = new FormData(accidentData);
        formData.append('personId', PersonId);
        formData.append('updateId', accidentUpdateId);
        var submitAccidentDataUrl = document.getElementById("Url6").value;
        $.ajax({
            url: submitAccidentDataUrl,
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            dataType: 'json',
            success: function (response) {
                console.log(response);
                accidentUpdateId = response;
            },
            error: function (xhr, status, error) {
                console.log('Error: ' + error);
            }
        });
        $('#accident').hide();
        // document.getElementById('saveButtonForm').style = "display:block";

        $('#step7').show();
        enableNextStep('step7');
        InsertValue();

    }
}
//Step 6 Validation
function validateAccidentData() {


    var selectedHSVal = "";
    var accidentCheckbox = $("#AccidentCheckBox").is(":checked");
    if (accidentCheckbox) {
        return true;
    }
    var selected = $("input[type='radio'][name='AccidentDetail.AccidentTypeID']:checked");
    if (selected.length > 0) {
        selectedHSVal = selected.val();
        // alert(selectedVal)
    }
    var canSubmit = true;
    var $errorDiv = $("#accidentErrors");
    $errorDiv.hide();
    var errorMessages = '';

    // Validate InsRank

    var LocationInput = $("#AccidentDetail_Location").val().trim();
    if (LocationInput === '') {
        canSubmit = false;
        $("#AccidentDetail_Location").css({ "background-color": "pink" });
        errorMessages += "<ul><li>InsRank field is required.</li></ul>";
    } else {
        $("#AccidentDetail_Location").css({ "background-color": "" });
    }



    var AccidentDate = $("#AccidentDetail_DateOfAccident").val().trim();
    if (AccidentDate === '') {
        canSubmit = false;
        $("#AccidentDetail_DateOfAccident").css({ "background-color": "pink" });
        errorMessages += "<ul><li>Policy Number field is required.</li></ul>";
    } else {
        $("#AccidentDetail_DateOfAccident").css({ "background-color": "" });
    }
    var AccidentTime = $("#AccidentDetail_TimeOfAccident").val().trim();
    if (AccidentTime === '') {
        canSubmit = false;
        $("#AccidentDetail_TimeOfAccident").css({ "background-color": "pink" });
        errorMessages += "<ul><li>AccidentTime Number field is required.</li></ul>";
    } else {
        $("#AccidentDetail_TimeOfAccident").css({ "background-color": "" });
    }

    if ($("input[name='AccidentDetail.AccidentTypeID']:checked").val() === undefined) {
        canSubmit = false;
        $("#divac").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" }); divHSOther
        errorMessages = errorMessages + "<ul><li>" + "AccidentTypeID" + " field is required.</li></ul>";
    } else {
        $("#divac").css({ "background-color": "" });
        if (selectedHSVal === "Other") {
            canSubmit = false;
            $("#AccidentDetail_AccidentTypeID").css({ "background-color": "pink" });
            //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" }); divHSOther
            errorMessages = errorMessages + "<ul><li>" + "AccidentTypeID" + " field is required.</li></ul>";
        } else {
            $("#AccidentDetail_AccidentTypeID").css({ "background-color": "" });
        }
    }


    // Display errors if any
    if (errorMessages.length > 0) {
        $errorDiv.show();
        $errorDiv.html("Validation Error(s): <br />" + errorMessages);
    }

    return canSubmit;
}
//Step 5 Validation
function validateInsuranceData() {

    var canSubmit = true;
    var $errorDiv = $("#insuranceErrors");
    $errorDiv.hide();
    var errorMessages = '';
    var insuranceCheckBox = $("#insuranceCheckBox").is(":checked");
    if (insuranceCheckBox) {
        return true;
    }



    // Validate InsRank
    var InsRank1 = $("#InsuranceInformation_InsuranceOne_InsRank").val().trim();
    var InsRank2 = $("#InsuranceInformation_InsuranceTwo_InsRank").val().trim();
    var InsRank2 = $("#InsuranceInformation_InsuranceThree_InsRank").val().trim();
    if (InsRank1 === '0' && InsRank2 === '0' && InsRank3 === '0') {
        canSubmit = false;
        $("#InsuranceInformation_InsuranceOne_InsRank").css({ "background-color": "pink" });
        $("#InsuranceInformation_InsuranceTwo_InsRank").css({ "background-color": "pink" });
        $("#InsuranceInformation_InsuranceThree_InsRank").css({ "background-color": "pink" });
        errorMessages += "<ul><li>InsRank field is required.</li></ul>";
    } else {
        $("#InsuranceInformation_InsuranceOne_InsRank").css({ "background-color": "" });
        $("#InsuranceInformation_InsuranceTwo_InsRank").css({ "background-color": "" });
        $("#InsuranceInformation_InsuranceThree_InsRank").css({ "background-color": "" });
    }


    // Validate Policy NUMBER
    var PolicyNUMBER1 = $("#InsuranceInformation_InsuranceOne_Policy_Number").val().trim();
    var PolicyNUMBER2 = $("#InsuranceInformation_InsuranceOne_Policy_Number").val().trim();
    var PolicyNUMBER3 = $("#InsuranceInformation_InsuranceOne_Policy_Number").val().trim();
    if (PolicyNUMBER1 === '' && PolicyNUMBER2 === '' && PolicyNUMBER3 === '') {
        canSubmit = false;
        $("#InsuranceInformation_InsuranceOne_Policy_Number").css({ "background-color": "pink" });
        $("#InsuranceInformation_InsuranceTwo_Policy_Number").css({ "background-color": "pink" });
        $("#InsuranceInformation_InsuranceThree_Policy_Number").css({ "background-color": "pink" });
        errorMessages += "<ul><li>Policy Number field is required.</li><li>Policy Number field is required.</li><li>Policy Number field is required.</li></ul>";
    } else {
        $("#InsuranceInformation_InsuranceOne_Policy_Number").css({ "background-color": "" });
        $("#InsuranceInformation_InsuranceTwo_Policy_Number").css({ "background-color": "" });
        $("#InsuranceInformation_InsuranceThree_Policy_Number").css({ "background-color": "" });
    }


    // Display errors if any
    if (errorMessages.length > 0) {
        $errorDiv.show();
        $errorDiv.html("Validation Error(s): <br />" + errorMessages);
    }

    return canSubmit;
}
//Step 4 Validation
function validateEmergencyData() {

    var canSubmit = true;
    var $errorDiv = $("#emergencyErrors");
    $errorDiv.hide();
    var errorMessages = '';
    var emergecny = $("#chkEmergecny").is(":checked");
    if (emergecny) {
        return true;
    }

    // Validate First Name
    var EmergencyContact = $("#EmergencyContact_EmergencyContactOne_Nearest_Relative_Name").val().trim();
    if (EmergencyContact === '') {
        canSubmit = false;
        $("#EmergencyContact_EmergencyContactOne_Nearest_Relative_Name").css({ "background-color": "pink" });
        errorMessages += "<ul><li> Name field is required.</li></ul>";
    } else {
        $("#EmergencyContact_EmergencyContactOne_Nearest_Relative_Name").css({ "background-color": "" });
    }


    // Display errors if any
    if (errorMessages.length > 0) {
        $errorDiv.show();
        $errorDiv.html("Validation Error(s): <br />" + errorMessages);
    }

    return canSubmit;
}
//Step 3 Validation
function validateMinorData() {

    var canSubmit = true;
    var $errorDiv = $("#minorErrors");
    $errorDiv.hide();
    var errorMessages = '';
    var notMinor = $("#notMinor").is(":checked");
    if (notMinor) {
        return true;
    }

    if ($('#divMinorMother').is(':visible')) {
        // The div is visible

        // Validate First Name
        var minorFirstName = $("#MinorInformation_MontherMinorInformation_First_Name").val().trim();
        if (minorFirstName === '') {
            canSubmit = false;
            $("#MinorInformation_MontherMinorInformation_First_Name").css({ "background-color": "pink" });
            errorMessages += "<ul><li>First Name field is required.</li></ul>";
        } else {
            $("#MinorInformation_MontherMinorInformation_First_Name").css({ "background-color": "" });
        }

        // Validate Last Name
        var minorLastName = $("#MinorInformation_MontherMinorInformation_Last_Name").val().trim();
        if (minorLastName === '') {
            canSubmit = false;
            $("#MinorInformation_MontherMinorInformation_Last_Name").css({ "background-color": "pink" });
            errorMessages += "<ul><li>Last Name field is required.</li></ul>";
        } else {
            $("#MinorInformation_MontherMinorInformation_Last_Name").css({ "background-color": "" });
        }

        // Validate Birth Date
        var minorBirthDate = $("#MinorInformation_MontherMinorInformation_Dob").val().trim();
        if (minorBirthDate === '') {
            canSubmit = false;
            $("#MinorInformation_MontherMinorInformation_Dob").css({ "background-color": "pink" });
            errorMessages += "<ul><li>Birth Date field is required.</li></ul>";
        } else {
            $("#MinorInformation_MontherMinorInformation_Dob").css({ "background-color": "" });
        }
        var minormaRace = $("#minor-mother-race option:selected").val();
        if (minormaRace === '0') {
            canSubmit = false;
            $("#minor-mother-race").css({ "background-color": "pink" });
            errorMessages += "<ul><li>Race field is required.</li></ul>";
        } else {
            $("#minor-mother-race").css({ "background-color": "" });
        }

        // Validate Marital Status

        if ($("#minor-mother-marital-status option:selected").val() === "") {
            canSubmit = false;
            $("#minor-mother-marital-status").css({ "background-color": "pink" });
            errorMessages = errorMessages + "<ul><li>" + "Marital Status" + " field is required.</li></ul>";
        } else {
            $("#minor-mother-marital-status").css({ "background-color": "" });
        }

        // Validate Home Phone
        if ($("#MinorInformation_MontherMinorInformation_HomePhone").val() === "") {
            canSubmit = false;
            $("#MinorInformation_MontherMinorInformation_HomePhone").css({ "background-color": "pink" });
            errorMessages = errorMessages + "<ul><li>" + "Home Phone" + " field is required.</li></ul>";
        } else {
            $("#MinorInformation_MontherMinorInformation_HomePhone").css({ "background-color": "" });
        }
    }

    if ($('#divMinorFather').is(':visible')) {
        var minorFirstName = $("#MinorInformation_FatherMinorInformation_First_Name").val().trim();
        if (minorFirstName === '') {
            canSubmit = false;
            $("#MinorInformation_FatherMinorInformation_First_Name").css({ "background-color": "pink" });
            errorMessages += "<ul><li>First Name field is required.</li></ul>";
        } else {
            $("#MinorInformation_FatherMinorInformation_First_Name").css({ "background-color": "" });
        }

        // Validate Last Name
        var minorLastName = $("#MinorInformation_FatherMinorInformation_Last_Name").val().trim();
        if (minorLastName === '') {
            canSubmit = false;
            $("#MinorInformation_FatherMinorInformation_Last_Name").css({ "background-color": "pink" });
            errorMessages += "<ul><li>Last Name field is required.</li></ul>";
        } else {
            $("#MinorInformation_FatherMinorInformation_Last_Name").css({ "background-color": "" });
        }

        // Validate Birth Date
        var minorBirthDate = $("#MinorInformation_FatherMinorInformation_Dob").val().trim();
        if (minorBirthDate === '') {
            canSubmit = false;
            $("#MinorInformation_FatherMinorInformation_Dob").css({ "background-color": "pink" });
            errorMessages += "<ul><li>Birth Date field is required.</li></ul>";
        } else {
            $("#MinorInformation_FatherMinorInformation_Dob").css({ "background-color": "" });
        }
        var minorfaRace = $("#minor-father-race option:selected").val();
        if (minorfaRace === '0') {
            canSubmit = false;
            $("#minor-father-race").css({ "background-color": "pink" });
            errorMessages += "<ul><li>Race field is required.</li></ul>";
        } else {
            $("#minor-father-race").css({ "background-color": "" });
        }

        // Validate Marital Status

        if ($("#minor-father-marital-status option:selected").val() === "") {
            canSubmit = false;
            $("#minor-father-marital-status").css({ "background-color": "pink" });
            errorMessages = errorMessages + "<ul><li>" + "Marital Status" + " field is required.</li></ul>";
        } else {
            $("#minor-father-marital-status").css({ "background-color": "" });
        }

        // Validate Home Phone
        if ($("#MinorInformation_FatherMinorInformation_HomePhone").val() === "") {
            canSubmit = false;
            $("#MinorInformation_FatherMinorInformation_HomePhone").css({ "background-color": "pink" });
            errorMessages = errorMessages + "<ul><li>" + "Home Phone" + " field is required.</li></ul>";
        } else {
            $("#MinorInformation_FatherMinorInformation_HomePhone").css({ "background-color": "" });
        }
    }
    // Display errors if any
    if (errorMessages.length > 0) {
        $errorDiv.show();
        $errorDiv.html("Validation Error(s): <br />" + errorMessages);
    }

    return canSubmit;
}
//Step 2 Validation
function validateSpouseData() {

    var canSubmit = true;
    var $errorDiv = $("#spouseErrors");
    $errorDiv.hide();
    var errorMessages = '';
    // Check if the 'Not Married' checkbox is checked
    var notMarried = $("#notmarried").is(":checked");
    if (notMarried) {
        return true;
    }
    // Validate First Name
    var spouseFirstName = $("#SpouseInformation_First_Name").val().trim();
    if (spouseFirstName === '') {
        canSubmit = false;
        $("#SpouseInformation_First_Name").css({ "background-color": "pink" });
        errorMessages += "<ul><li>First Name field is required.</li></ul>";
    } else {
        $("#SpouseInformation_First_Name").css({ "background-color": "" });
    }

    // Validate Last Name
    var spouseLastName = $("#SpouseInformation_Last_Name").val().trim();
    if (spouseLastName === '') {
        canSubmit = false;
        $("#SpouseInformation_Last_Name").css({ "background-color": "pink" });
        errorMessages += "<ul><li>Last Name field is required.</li></ul>";
    } else {
        $("#SpouseInformation_Last_Name").css({ "background-color": "" });
    }

    // Validate Birth Date
    var spouseBirthDate = $("#SpouseInformation_BirthDate").val().trim();
    if (spouseBirthDate === '') {
        canSubmit = false;
        $("#SpouseInformation_BirthDate").css({ "background-color": "pink" });
        errorMessages += "<ul><li>Birth Date field is required.</li></ul>";
    } else {
        $("#SpouseInformation_BirthDate").css({ "background-color": "" });
    }
    var spouseRace = $("#spouse-race option:selected").val();
    if (spouseRace === '0') {
        canSubmit = false;
        $("#spouse-race").css({ "background-color": "pink" });
        errorMessages += "<ul><li>Race field is required.</li></ul>";
    } else {
        $("#spouse-race").css({ "background-color": "" });
    }

    // Validate Marital Status
    if ($("#spouse-status option:selected").val() === "") {
        canSubmit = false;
        $("#spouse-status").css({ "background-color": "pink" });
        errorMessages = errorMessages + "<ul><li>" + "Marital Status" + " field is required.</li></ul>";
    } else {
        $("#spouse-status").css({ "background-color": "" });
    }

    // Validate Home Phone
    if ($("#SpouseInformation_Home_Phone").val() === "") {
        canSubmit = false;
        $("#SpouseInformation_Home_Phone").css({ "background-color": "pink" });
        errorMessages = errorMessages + "<ul><li>" + "Home Phone" + " field is required.</li></ul>";
    } else {
        $("#SpouseInformation_Home_Phone").css({ "background-color": "" });
    }
    // Display errors if any
    if (errorMessages.length > 0) {
        $errorDiv.show();
        $errorDiv.html("Validation Error(s): <br />" + errorMessages);
    }

    return canSubmit;
}

$('.stepwizard-step a').on('click', function (event) {

    if ($(this).hasClass('disableButton')) {
        event.preventDefault();
        return false;
    }
});


function enableNextStep(stepId) {
    $('.stepwizard-step a').addClass('btn-default').removeClass('btn-success').prop('disabled', true);
    $(`.stepwizard-step a[href="#${stepId}"]`).removeClass('btn-default').addClass('btn-success').prop('disabled', false);
    $(`.stepwizard-step a[href="#${stepId}"]`).removeClass('disableButton').prop('disabled', false);
}

function validatePatientData() {

    // alert($("input[type=radio][name='PatientDemographicsViewModel.ResponsiblePartyID']").val())
    var selectedHSVal = "";
    var selected = $("input[type='radio'][name='PatientDemographicsViewModel.HospitalService']:checked");
    if (selected.length > 0) {
        selectedHSVal = selected.val();
        // alert(selectedVal)
    }
    var selectedRespPartyVal = "";
    var selectedres = $("input[type='radio'][name='PatientDemographicsViewModel.ResponsiblePartyID']:checked");
    if (selectedres.length > 0) {
        selectedRespPartyVal = selectedres.val();
        // alert(selectedVal)
    }
    var canSubmit = true;
    var $errorDiv = $("#step1Errors");
    $errorDiv.hide();
    var errorMessages = '';
    if ($("#hospitalId option:selected").val() === '0') {
        canSubmit = false;
        $("#hospitalId").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
        errorMessages = errorMessages + "<ul><li>" + "Location For Service" + " field is required.</li></ul>";
    } else {
        $("#hospitalId").css({ "background-color": "" });
    }

    if ($("input[name='PatientDemographicsViewModel.HospitalService']:checked").val() === undefined) {
        canSubmit = false;
        $("#divHS").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" }); divHSOther
        errorMessages = errorMessages + "<ul><li>" + "Service You Are Registering For" + " field is required.</li></ul>";
    } else {
        $("#divHS").css({ "background-color": "" });
        if (selectedHSVal === "Other" && $("#PatientDemographicsViewModel_HospitalServiceOther").val() === '') {
            canSubmit = false;
            $("#PatientDemographicsViewModel_HospitalServiceOther").css({ "background-color": "pink" });
            //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" }); divHSOther
            errorMessages = errorMessages + "<ul><li>" + "Service You Are Registering For Other" + " field is required.</li></ul>";
        } else {
            $("#PatientDemographicsViewModel_HospitalServiceOther").css({ "background-color": "" });
        }
    }

    //  if ($("input[name='PatientDemographicsViewModel.ResponsiblePartyID']:checked").val() === undefined) {

    //      canSubmit = false;
    ////  $("#PatientDemographics").css({"background-color": "pink" });
    //          //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" }); divHSOther
    //  errorMessages = errorMessages + "<ul><li>" + "Who is Guarantor or Responsible Party for this patient" + " field is required.</li></ul>";
    //      } else {
    //       $("#PatientDemographics").css({ "background-color": "" });
    if ($("#guarantor option:selected").val() === "4" && $("#PatientDemographicsViewModel_GuarNameIfOther").val() === '') {
        canSubmit = false;
        $("#PatientDemographicsViewModel_GuarNameIfOther").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" }); divHSOther
        errorMessages = errorMessages + "<ul><li>" + "Who is Guarantor or Responsible Party for this patient For Other" + " field is required.</li></ul>";
    } else {
        $("#PatientDemographicsViewModel_GuarNameIfOther").css({ "background-color": "" });
    }
    //  }

    if ($("#PatientDemographicsViewModel_PrimaryCarePhys").val() === '') {
        canSubmit = false;
        $("#PatientDemographicsViewModel_PrimaryCarePhys").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
        errorMessages = errorMessages + "<ul><li>" + "Primary Care Physician" + " field is required.</li></ul>";
    } else {
        $("#PatientDemographicsViewModel_PrimaryCarePhys").css({ "background-color": "" });
    }

    if ($("#PatientDemographicsViewModel_First_Name").val() === '') {
        canSubmit = false;
        $("#PatientDemographicsViewModel_First_Name").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
        errorMessages = errorMessages + "<ul><li>" + "Legal First Name" + " field is required.</li></ul>";
    } else {
        $("#PatientDemographicsViewModel_First_Name").css({ "background-color": "" });
    }

    if ($("#PatientDemographicsViewModel_Last_Name").val() === '') {
        canSubmit = false;
        $("#PatientDemographicsViewModel_Last_Name").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
        errorMessages = errorMessages + "<ul><li>" + "Legal Last Name" + " field is required.</li></ul>";
    } else {
        $("#PatientDemographicsViewModel_Last_Name").css({ "background-color": "" });
    }

    if ($("input[name='PatientDemographicsViewModel.Gender']:checked").val() === undefined) {
        canSubmit = false;
        $("#divGender").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" }); divHSOther
        errorMessages = errorMessages + "<ul><li>" + "Gender" + " field is required.</li></ul>";
    } else {
        $("#divGender").css({ "background-color": "" });

    }

    if ($("#PatientDemographicsViewModel_BirthDate").val() === '') {
        canSubmit = false;
        $("#PatientDemographicsViewModel_BirthDate").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
        errorMessages = errorMessages + "<ul><li>" + "Date Of Birth" + " field is required.</li></ul>";
    } else {
        $("#PatientDemographicsViewModel_BirthDate").css({ "background-color": "" });
    }

    if ($("#ethincity option:selected").val() === '0') {
        canSubmit = false;
        $("#ethincity").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
        errorMessages = errorMessages + "<ul><li>" + "Ethincity" + " field is required.</li></ul>";
    } else {
        $("#ethincity").css({ "background-color": "" });
    }

    if ($("#race option:selected").val() === '0') {
        canSubmit = false;
        $("#race").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
        errorMessages = errorMessages + "<ul><li>" + "Race" + " field is required.</li></ul>";
    } else {
        $("#race").css({ "background-color": "" });
    }

    if ($("#maritalstatus option:selected").val() === '0') {
        canSubmit = false;
        $("#maritalstatus").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
        errorMessages = errorMessages + "<ul><li>" + "Marital Status" + " field is required.</li></ul>";
    } else {
        $("#maritalstatus").css({ "background-color": "" });
    }

    if ($("#guarantor option:selected").val() === '0') {
        canSubmit = false;
        $("#guarantor").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
        errorMessages = errorMessages + "<ul><li>" + "Marital Status" + " field is required.</li></ul>";
    } else {
        $("#guarantor").css({ "background-color": "" });

        if ($("#guarantor option:selected").val() === '4') {
            $('#divGuarNameIfOther').show();
        } else {
            $('#divGuarNameIfOther').hide();
        }
    }

    var testing = $("#PatientDemographicsViewModel_Home_Phone").val();

    if ($("#PatientDemographicsViewModel_Home_Phone").val() === "") {
        canSubmit = false;
        $("#PatientDemographicsViewModel_Home_Phone").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
        errorMessages = errorMessages + "<ul><li>" + "Preferred Phone" + " field is required.</li></ul>";
    } else {
        $("#PatientDemographicsViewModel_Home_Phone").css({ "background-color": "" });
    }

    if ($("#PatientDemographicsViewModel_Email_Address").val() === '') {
        canSubmit = false;
        $("#PatientDemographicsViewModel_Email_Address").css({ "background-color": "pink" });
        //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
        errorMessages = errorMessages + "<ul><li>" + "Email Address" + " field is required.</li></ul>";
    } else {
        $("#PatientDemographicsViewModel_Email_Address").css({ "background-color": "" });
        if (!isValidEmailAddress($("#PatientDemographicsViewModel_Email_Address").val())) {
            canSubmit = false;
            $("#PatientDemographicsViewModel_Email_Address").css({ "background-color": "pink" });
            //      $("#divWaivedReason").css({"box-shadow": "inset 0 0 0 .0625rem #de1c24" });
            errorMessages = errorMessages + "<ul><li>" + "Email Address" + " is not valid.</li></ul>";
        } else {
            $("#PatientDemographicsViewModel_Email_Address").css({ "background-color": "" });
        }
    }

    //  $("#PatientDemographicsViewModel_BirthDate").change(function () {
    //      var dob = $("#PatientDemographicsViewModel_BirthDate").val();
    //      var age = calculateAge(dob);
    //   $("#Age").val(age);
    if ($("#PatientDemographicsViewModel_Age").val()) {
        if (Number($("#PatientDemographicsViewModel_Age").val()) < 18) {
            $('#divMinor').show();

            // $('#minor').show();
        } else {
            $('#divMinor').hide();
            $("#notMinor").prop("checked", true);
            //   $('#minor').hide();
        }
    }

    $("#notMinor").change(function () {
        if (this.checked) {
            $('#divMinorMother').hide();
            $('#divMinorFather').hide();
            $('#chooseGurantor').hide();
        }
        else {

            $('#chooseGurantor').show();
            PatientToMinorDropdownSelect();
        }
    });

    $("#chkEmergecny").change(function () {
        if (this.checked) {
            //   $('#divEmergency').hide();
            $('#divSpouseEmergency').hide();
            $('#divEmergencyOne').hide();
            $('#divEmergencyTwo').hide();
            $('#divEmergencyThree').hide();
            $('#EmergencyAddBtn').hide();
        }
        else {
            //  $('#divEmergency').show();
            $('#divSpouseEmergency').show();
            $('#divEmergencyOne').show();
            $('#EmergencyAddBtn').show();

        }
    });

    $("#spouseemergency").change(function () {
        if (this.checked) {
            $('#EmergencyContact_EmergencyContactOne_Nearest_Relative_Name').val($('#SpouseInformation_Last_Name').val() + ", " + $('#SpouseInformation_First_Name').val());
            $('#EmergencyContact_EmergencyContactOne_Relationship').val('Spouse')
            $('#EmergencyContact_EmergencyContactOne_Address1').val($('#SpouseInformation_Address1').val())
            $('#EmergencyContact_EmergencyContactOne_Address2').val($('#SpouseInformation_Address2').val())
            $('#EmergencyContact_EmergencyContactOne_City').val($('#SpouseInformation_City').val())
            $('#emergencycontactonestate').val($('#spousestate').val())
            $('#EmergencyContact_EmergencyContactOne_ZipCode').val($('#SpouseInformation_ZipCode').val())
            $('#EmergencyContact_EmergencyContactOne_Contact_Phone').val($('#SpouseInformation_Home_Phone').val())
        }
        else {
            $('#EmergencyContact_EmergencyContactOne_Nearest_Relative_Name').val('');
            $('#EmergencyContact_EmergencyContactOne_Relationship').val('')
            $('#EmergencyContact_EmergencyContactOne_Address1').val('')
            $('#EmergencyContact_EmergencyContactOne_Address2').val('')
            $('#EmergencyContact_EmergencyContactOne_City').val('')
            $('#emergencycontactonestate').val('')
            $('#EmergencyContact_EmergencyContactOne_ZipCode').val('')
            $('#EmergencyContact_EmergencyContactOne_Contact_Phone').val('')
        }
    });

    $("#insuranceCheckBox").change(function () {
        if (this.checked) {
            $('#InsuranceOnePremium').hide();
            $('#InsuranceTwoPremium').hide();
            $('#InsuranceThreePremium').hide();
        }
        else {

            $('#InsuranceOnePremium').show();

        }
    })

    $("#chooseGurantor").change(function () {
        if ($("#chooseGurantor option:selected").val() === '1') {
            $('#divMinorMother').show();
            $('#divMinorFather').hide();
        }
        else if ($("#chooseGurantor option:selected").val() === '2') {
            $('#divMinorMother').hide();
            $('#divMinorFather').show();
        }
        else if ($("#chooseGurantor option:selected").val() === '3') {
            $('#divMinorMother').show();
            $('#divMinorFather').show();
        }
        else {
            $('#divMinorMother').hide();
            $('#divMinorFather').hide();
        }
    });

    $("#AccidentCheckBox").change(function () {
        if (this.checked) {
            $('#AccidentBody').hide();

        }
        else {

            $('#AccidentBody').show();

        }
    })


    //});


    if (errorMessages.length > 0) {
        $errorDiv.show();
        $errorDiv.html("Validation Error(s): <br />" + errorMessages);
    }
    return canSubmit;
}


function calculateAge(birthDate) {
    var today = new Date();
    var birthDate = new Date(birthDate);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}

function PhoneNoClean() {
    var patientPhoneValue = $('#PatientDemographicsViewModel_Home_Phone').val();
    var cleanedPatientPhone = patientPhoneValue.replace(/\D/g, ''); // Remove non-numeric characters
    $('#PatientDemographicsViewModel_Home_Phone').val(cleanedPatientPhone); // Set cleaned value back to input field



}

function submitInformation() {
    PhoneNoClean();
    // Ensure #myForm is the correct ID of the form element
    var formElement = document.getElementById('myForm');

    // Check if formElement is valid
    if (formElement) {
        var formData = new FormData(formElement);

        $.ajax({
            url: '/PreRegistration/SubmitECRespiratoryProtectionForm',
            type: 'POST',
            data: formData,
            contentType: false, // Required for FormData
            processData: false, // Required for FormData
            dataType: 'json',
            success: function (response) {
                if (response.error) {
                    $('#responseMessage').html('<div class="error">' + response.error + '</div>');
                } else {
                    $('#responseMessage').html('<div class="success">Form submitted successfully!</div>');
                    alert('Form submitted successfully!');
                    window.location.reload();
                }
            },
            error: function (xhr, status, error) {
                $('#responseMessage').html('<div class="error">An error occurred: ' + error + '</div>');
            }
        });
    } else {
        console.error("Form element not found. Please check the ID.");
    }
    ``


}

function isValidEmailAddress(emailAddress) {
    var pattern = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
    return pattern.test(emailAddress);
}

