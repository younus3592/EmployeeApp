var employeeEditorApp = {
    openEmployeeEditorModel: function (employeeId) {


        $("#employees-modal").modal('show');

        $("[id^='employee-']").val("");


        if (employeeId) {

            $.ajax({
                url: "/Employee/GetEmployeeDetails",
                type: "GET",
                data: {
                    employeeId: employeeId
                },
                success: function (response) {

                    if (response) {

                        $("#employee-name").val(response.EmployeeName);
                        $("#employee-age").val(response.Age);
                        $("#employee-gender").val(response.Gender);
                        $("#employee-address").val(response.Address);
                        $("#employee-id").val(response.EmployeeID);
                    } 

                },
                error: function () {
                }
            }
            )
        }
    },
    saveEmployeeDetails: function () {
        
        var employeeObj = employeeEditorApp.PrepareEmployeeObj();


        $.ajax({
            url: "/Employee/SaveEmployee",
            type: "POST",
            data: {
                empObj: employeeObj
            },
            success: function (response) {


                if (employeeObj.EmployeeID) {
                    var $tr = $("#tbody-employees-list").find("#tr_" + employeeObj.EmployeeID);

                    $tr.replaceWith(response);
                }
                else {
                    $("#tbody-employees-list").prepend(response);
                }

                $("#employees-modal").modal('hide');

            },
            error: function () {

            }
        }
        )

    },
    PrepareEmployeeObj: function () {

        var employeeObj = {
            EmployeeID: $("#employee-id").val(),
            EmployeeName: $("#employee-name").val(),
            Age: $("#employee-age").val(),
            Gender: $("#employee-gender").val(),
            Address: $("#employee-address").val()
        };

        return employeeObj;
    },
    DeleteEmployee: function (employeeId) {

        $.ajax({
            url: "/Employee/DeleteEmployee",
            type: "POST",
            data: {
                employeeId: employeeId
            },
            success: function (response) {

                if (response) {
                    alert("Employee Deleted");
                    $("#tbody-employees-list").find("#tr_" + employeeId).remove();

                } else {
                    alert("Some error occured when deleting employee");
                }
               
            },
            error: function () {
                alert("Some error occured when deleting employee");
            }
        }
        )
    }
}

