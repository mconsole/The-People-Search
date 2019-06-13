var searchData;
var _houst;

$(document).ready(function () {
    "use strict"

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