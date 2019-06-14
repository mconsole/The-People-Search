﻿var searchData;
var _houst;
var data;

var usStates = [
    { name: 'ALABAMA', abbreviation: 'AL' },
    { name: 'ALASKA', abbreviation: 'AK' },
    { name: 'AMERICAN SAMOA', abbreviation: 'AS' },
    { name: 'ARIZONA', abbreviation: 'AZ' },
    { name: 'ARKANSAS', abbreviation: 'AR' },
    { name: 'CALIFORNIA', abbreviation: 'CA' },
    { name: 'COLORADO', abbreviation: 'CO' },
    { name: 'CONNECTICUT', abbreviation: 'CT' },
    { name: 'DELAWARE', abbreviation: 'DE' },
    { name: 'DISTRICT OF COLUMBIA', abbreviation: 'DC' },
    { name: 'FEDERATED STATES OF MICRONESIA', abbreviation: 'FM' },
    { name: 'FLORIDA', abbreviation: 'FL' },
    { name: 'GEORGIA', abbreviation: 'GA' },
    { name: 'GUAM', abbreviation: 'GU' },
    { name: 'HAWAII', abbreviation: 'HI' },
    { name: 'IDAHO', abbreviation: 'ID' },
    { name: 'ILLINOIS', abbreviation: 'IL' },
    { name: 'INDIANA', abbreviation: 'IN' },
    { name: 'IOWA', abbreviation: 'IA' },
    { name: 'KANSAS', abbreviation: 'KS' },
    { name: 'KENTUCKY', abbreviation: 'KY' },
    { name: 'LOUISIANA', abbreviation: 'LA' },
    { name: 'MAINE', abbreviation: 'ME' },
    { name: 'MARSHALL ISLANDS', abbreviation: 'MH' },
    { name: 'MARYLAND', abbreviation: 'MD' },
    { name: 'MASSACHUSETTS', abbreviation: 'MA' },
    { name: 'MICHIGAN', abbreviation: 'MI' },
    { name: 'MINNESOTA', abbreviation: 'MN' },
    { name: 'MISSISSIPPI', abbreviation: 'MS' },
    { name: 'MISSOURI', abbreviation: 'MO' },
    { name: 'MONTANA', abbreviation: 'MT' },
    { name: 'NEBRASKA', abbreviation: 'NE' },
    { name: 'NEVADA', abbreviation: 'NV' },
    { name: 'NEW HAMPSHIRE', abbreviation: 'NH' },
    { name: 'NEW JERSEY', abbreviation: 'NJ' },
    { name: 'NEW MEXICO', abbreviation: 'NM' },
    { name: 'NEW YORK', abbreviation: 'NY' },
    { name: 'NORTH CAROLINA', abbreviation: 'NC' },
    { name: 'NORTH DAKOTA', abbreviation: 'ND' },
    { name: 'NORTHERN MARIANA ISLANDS', abbreviation: 'MP' },
    { name: 'OHIO', abbreviation: 'OH' },
    { name: 'OKLAHOMA', abbreviation: 'OK' },
    { name: 'OREGON', abbreviation: 'OR' },
    { name: 'PALAU', abbreviation: 'PW' },
    { name: 'PENNSYLVANIA', abbreviation: 'PA' },
    { name: 'PUERTO RICO', abbreviation: 'PR' },
    { name: 'RHODE ISLAND', abbreviation: 'RI' },
    { name: 'SOUTH CAROLINA', abbreviation: 'SC' },
    { name: 'SOUTH DAKOTA', abbreviation: 'SD' },
    { name: 'TENNESSEE', abbreviation: 'TN' },
    { name: 'TEXAS', abbreviation: 'TX' },
    { name: 'UTAH', abbreviation: 'UT' },
    { name: 'VERMONT', abbreviation: 'VT' },
    { name: 'VIRGIN ISLANDS', abbreviation: 'VI' },
    { name: 'VIRGINIA', abbreviation: 'VA' },
    { name: 'WASHINGTON', abbreviation: 'WA' },
    { name: 'WEST VIRGINIA', abbreviation: 'WV' },
    { name: 'WISCONSIN', abbreviation: 'WI' },
    { name: 'WYOMING', abbreviation: 'WY' }
];

var interestChoices = [
    { name: 'Sports' },
    { name: 'Cooking' },
    { name: 'Reading' },
    { name: 'Videogames' },
    { name: 'Art' }
];

$(document).ready(function () {
    "use strict"

    //populate state select list with options
    for (var i = 0; i < usStates.length; i++) {
        var option = document.createElement("option");
        option.text = usStates[i].abbreviation;
        option.value = usStates[i].abbreviation;
        $("#inputState").append(option);
    }

    for (var i = 0; i < interestChoices.length; i++) {
        var option = document.createElement("option");
        option.text = interestChoices[i].name;
        option.value = interestChoices[i].name;
        $("#interestsInput").append(option);
    }

    //button click event for search button
    $("#searchClickFrame").click(function () {

        var query = $("#userSearchInput").val();

        $.ajax({
            url: "http://localhost:54693/api/users/getallbytermvw?query=" + query,
            success: function (result) {
                searchData = result;

                $("#userList").empty();

                $.each(result, function (index, value) {

                    var html = '<div class="card"><img src="Content/Images/default-user.png" alt="' + searchData[index].firstName + '" style="width:100%"><h1>' + searchData[index].firstName + ' ' + searchData[index].lastName + '</h1><p class="title">' + 'Age: ' + searchData[index].age + '</p><p>' + 'Interests: ' + searchData[index].interests.replace(',', ', ') + '</p></div>';

                    $("#userList").append(html);
                });
            }
        });
    });

    






});

//event to clear form inputs on add user button click
$("#addNewUserBtn").click(function () {
    $("#firstNameInput").val('');
    $("#lastNameInput").val('');
    $("#addressInput").val('');
    $("#inputCity").val('');
    $("#inputState").prop('selectedIndex', -1);
    $("#interestsInput").prop('selectedIndex', -1);
    $("#inputZip").val('');
    $("#ageInput").val('');
});

//ajax POST event for submitting new users and their location
function submitNewUserData() {
    if ($("#firstNameInput").val() && $("#lastNameInput").val() && $("#addressInput").val() && $("#inputCity").val() && $("#inputZip").val() && $("#ageInput").val()) {
        data = {
            streetAddr: $("#addressInput").val(),
            cityName: $("#inputCity").val(),
            stateName: $("#inputState option:selected").text(),
            zipCode: $("#inputZip").val(),
            countryName: $("#inputState option:selected").text(),
            createdDtTime: new Date().toLocaleString()
        }

        submitLocationInfo(data);
    }  
}

function submitLocationInfo(locationData) {
    $.ajax({
        type: "POST",
        url: "http://localhost:54693/api/locations/addnewlocation",
        data: locationData,
        success: function (result) {
            submitUserInfo(result, status);
        }
    });
}

function submitUserInfo(data, status) {
    var interests = $("#interestsInput").val();
    var interestString = "";

    for (var i = 0; i < interests.length; i++) {
        if (i == 0) {
            interestString += interests[i];
        } else {
            interestString += ", " + interests[i];
        }
    }

    var userData = {
        firstName: $("#firstNameInput").val(),
        lastName: $("#lastNameInput").val(),
        age: $("#ageInput").val(),
        addressId: data,
        interests: interestString,
        userImage: "",
        createdDtTime: new Date().toLocaleString()
    }

    $.ajax({
        type: "POST",
        url: "http://localhost:54693/api/users/addnewuser",
        data: userData,
        success: function () {
            alert("User Added Successfully!");

            $('#addUserForm').modal('hide');
        }
    });
}