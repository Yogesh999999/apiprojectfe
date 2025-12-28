<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="project9.aspx.cs" Inherits="projects.project9" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--bootstrap--%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" />
    <%--bootstrap ends here--%>


    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>


    <%--this is datatables cdn--%>
    <link rel="stylesheet" href="https://cdn.datatables.net/2.3.4/css/dataTables.dataTables.min.css" />
    <script src="https://cdn.datatables.net/2.3.4/js/dataTables.min.js"></script>
    <%--it end here--%>

    <%--//serach panes--%>
    <link rel="stylesheet" href="https://cdn.datatables.net/searchpanes/2.3.5/css/searchPanes.dataTables.min.css" />
    <script src="https://cdn.datatables.net/searchpanes/2.3.5/js/dataTables.searchPanes.min.js"></script>
    <%--it ends here--%>

    <%--search pane requires select--%>
    <link rel="stylesheet" href="https://cdn.datatables.net/select/3.1.3/css/select.dataTables.min.css" />
    <script src="https://cdn.datatables.net/select/3.1.3/js/dataTables.select.min.js"></script>
    <%--it ends here--%>

    <%--search builder--%>
    <link rel="stylesheet" href="https://cdn.datatables.net/searchbuilder/1.8.4/css/searchBuilder.dataTables.min.css" />
    <script src="https://cdn.datatables.net/searchbuilder/1.8.4/js/dataTables.searchBuilder.min.js"></script>
    <%--it ends here--%>

    <%--this is fontawesome cdn--%>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/7.0.1/css/all.min.css" integrity="sha512-2SwdPD6INVrV/lHTZbO2nodKhrnDdJK9/kg2XD1r9uGqPo1cUbujc+IYdlYdEErWNu69gVcYgdxlmVmzTWnetw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <%--it ends here--%>


    <%--this is sweetalert cdm--%>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <%--it ends here--%>

    <%--this is select2 cdn--%>
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>
    <%--it ends here--%>
    <style>
        td.details-control {
            background: url(https://www.datatables.net/examples/resources/details_open.png) no-repeat center;
            cursor: pointer
        }

        tr.shown td.details-control {
            background: url(https://www.datatables.net/examples/resources/details_close.png) no-repeat center center;
            cursor: pointer
        }

        .saveclass {
            visibility: hidden
        }

        tr.low-units {
            background-color: blue !important;
        }

        tr.medium-units {
            background-color: blueviolet !important;
        }

        tr.high-units {
            background-color: hotpink !important;
        }

        .carousel-inner img {
            width: 100%;
            height: 500px;
            object-fit: contain;
        }

        .carousel-control-prev-icon,
        .carousel-control-next-icon {
            background-color: black;
            background-size: 100% 100%;
            width: 40px;
            height: 40px;
        }
    </style>

</head>
<body>

    <div>
        <div style="margin: 50px; box-shadow: 5px 10px 18px #888888;"
            class="card">
            <div style="background-color: black;" class="card-header">
                <h1 style="color: red; text-align: center">USER FORM</h1>

            </div>
            <div class="card-body">
                <div id="totalid">



                    <div id="nameid">
                        <label for="nameinput" class="label">Name:</label>
                        <input placeholder="First name" id="nameinput" class="input form-control" type="text" required />
                    </div>

                    <div id="lname">
                        <label for="" class="label">Lastname:</label>
                        <input placeholder="Last Name" id="plname" class="input form-control" type="text" required />
                    </div>

                    <div id="lemail">
                        <label for="" class="label">Email:</label>
                        <input placeholder="Email" id="pemail" class="input form-control" type="email" required />
                    </div>

                    <div id="lphone">
                        <label for="" class="label">Phone Number:</label>
                        <input placeholder="Phone Number" id="pphone" class="input form-control" type="number" required />
                    </div>

                    <div id="ldob">
                        <label for="" class="label">Date of  Birth:</label>
                        <input placeholder="Date of  Birth" id="pdob" class="input form-control" max="2007-12-17" type="date" required />
                    </div>

                    <div>
                        <label>Country</label>
                        <select id="countryid" style="width: 100%">
                            <option></option>
                        </select>
                    </div>

                    <div>
                        <label>State</label>
                        <select id="stateid" style="width: 100%">
                            <option></option>
                        </select>
                    </div>

                    <div>
                        <label>district</label>
                        <select id="districtid" style="width: 100%">
                            <option></option>
                        </select>

                    </div>

                    <div>
                        <label>Skills</label>
                        <select id="skillsid" style="width: 100%" multiple="multiple">
                            <option value="Html">Html</option>
                            <option value="Css">Css</option>
                            <option value="Javascript">Javascript</option>
                            <option value="React">React</option>
                        </select>

                    </div>

                </div>




            </div>

            <div id="buttonid">
                <button id="submitid" type="button" class="btn btn-success">Submit</button>
            </div>


            <div class="modal fade" id="editModal" tabindex="-1" role="dialog" aria-labelledby="editModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="editModalLabel">Edit User</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div>
                                <label for="editName">Name:</label>
                                <input type="text" id="editName" class="form-control" />

                                <label for="editLastName">Last Name:</label>
                                <input type="text" id="editLastName" class="form-control" />

                                <label for="editEmail">Email:</label>
                                <input type="email" id="editEmail" class="form-control" />

                                <label for="editPhone">Phone:</label>
                                <input type="number" id="editPhone" class="form-control" />

                                <label for="editDob">Date of Birth:</label>
                                <input type="date" id="editDob" class="form-control" />

                                <%-- <label for="editSubmittedDateTime">Submitted:</label>
                                <input type="text" id="editSubmittedDateTime" class="form-control" readonly />--%>


                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary sav" id="saveChangesBtn">Save Changes</button>
                        </div>
                    </div>
                </div>
            </div>



            <div>

                <table id="tableid">
                    <thead>
                        <tr>
                            <th></th>
                            <th>name</th>
                            <th>Last Name</th>
                            <th>Email</th>
                            <th>Phone</th>
                            <th>DOB</th>
                            <th>Created at</th>
                            <th>country</th>
                            <th>state</th>
                            <th>district</th>
                            <th>skills</th>
                            <th>Edit</th>
                            <th>Delete</th>
                            <th>Units</th>
                        </tr>
                    </thead>
                    <tbody></tbody>

                </table>
            </div>

        </div>
    </div>

    <div id="demo" class="carousel slide d-none" data-ride="carousel" aria-hidden="true">
        <ul class="carousel-indicators"></ul>
        <div class="carousel-inner">
        </div>

        <a class="carousel-control-prev" href="#demo" role="button" data-slide="prev">
            <span class="fa fa-chevron-left fa-2x text-dark"></span>
        </a>

        <a class="carousel-control-next" href="#demo" role="button" data-slide="next">
            <span class="fa fa-chevron-right fa-2x text-dark"></span>
        </a>

    </div>

    <div class="modal fade" id="wikiModal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">

                <div class="modal-header">
                    <h5 class="modal-title" id="wikiTitle"></h5>
                    <button type="button" class="close" data-dismiss="modal">
                        <span>&times;</span>
                    </button>
                </div>

                <div class="modal-body p-0">
                    <iframe id="wikiFrame" src="" width="100%" height="600px" style="border: 0;"></iframe>
                </div>

            </div>
        </div>

        <pre id="apiResponse"></pre>

    </div>

    <script>



        $(document).ready(function () {

            $(document).on("click", ".saveclass", function () {
                debugger;

                let row = $(this).closest("tr");
                let input = row.find("input");
                let unitsValue = input.val();
                let userId = input.attr("id"); 

                console.log("Row:", row);
                console.log("Units Value:", unitsValue);

                if (unitsValue === "" || isNaN(unitsValue)) {
                    Swal.fire("Error", "Please enter a valid number!", "error");
                    return;
                }

                $.ajax({
                    type: "PATCH",   
                    url: `https://localhost:7264/api/Users/${userId}`,
                    contentType: "application/json",
                    data: JSON.stringify({
                        units: parseInt(unitsValue)
                    }),
                    success: function (response) {
                        debugger;

                        Swal.fire("Success", response.message || "Units updated!", "success");

                        updateRowColor(row, unitsValue);

                        $(row).find(".saveclass").css('visibility', 'hidden');
                    },
                    error: function (xhr) {
                        Swal.fire(
                            "Error",
                            xhr.responseText || "Failed to update units",
                            "error"
                        );

                        console.log("Status:", xhr.status);
                        console.log("Response:", xhr.responseText);
                    }
                });
            });

            
            $("#skillsid").select2({
                placeholder: "Select skills",
                allowClear: true
            });

            let userTable = $('#tableid').DataTable({
                orderable: false,
                columnDefs: [
                    {
                        className: 'details-control',
                        orderable: false,
                        data: null,
                        defaultContent: '',
                        targets: 0
                    },
                    {
                        visible: false,
                        targets: [7, 8, 9, 10]
                    }
                ],
                rowCallback: function (row, data, index) {
                    debugger
                    let inputHTML = data[13];

                    let tempDiv = document.createElement('div');
                    tempDiv.innerHTML = inputHTML;

                    let inputValue = tempDiv.querySelector('input').value;

                    console.log(inputValue);



                    $(row).removeClass('low-units medium-units high-units');
                    if (inputValue == "") {
                    }
                    else if (inputValue < 40) {
                        $(row).addClass('low-units');
                    } else if (inputValue >= 40 && inputValue <= 70) {
                        $(row).addClass('medium-units');
                    } else if (inputValue > 70) {
                        $(row).addClass('high-units');
                    }
                }

            });








            function automatic() {
                debugger
                //$.ajax({
                //    type: "GET",
                //    url: "https://localhost:7264/api/Users",
                //    data: '{}',
                //    contentType: "application/json; charset=utf-8",
                //    dataType: "json",
                //    success: function (response) {
                //        debugger
                //        userTable.clear();
                //        userTable.order([]);
                //        $.each(response, function (i, user) {
                //            debugger
                //            userTable.row.add([
                //                `<td></td>`,
                //                user.name,
                //                user.lastname,
                //                user.email,
                //                user.phone,
                //                user.dob,
                //                user.submitted,
                //                user.countryName,
                //                user.stateName,
                //                user.districtName,
                //                user.skills,
                //                `<i class="fas fa-edit edit-btn" data-id="${user.id}"></i>`,
                //                `<i class="fa-solid fa-trash delete-btn" data-id="${user.id}"></i>`,
                //                `<div class="input-group mb-3">
                //                <input type="number" class="form-control" id="${user.id}" min="0" max="100" value="${user.units}" placeholder="" oninput="if (this.value > 100) this.value = this.value.slice(0, -1);" aria-label="" aria-describedby="basic-addon2">
                //                <div class="input-group-append">
                //                    <button class="btn btn-success saveclass" style="" type="button">Save</button>
                //                </div>
                //            </div>`
                //            ]).draw();

                //            $(`#${user.id}`).on('input', function () {
                //                debugger
                //                let value = $(this).val();

                //                if (value !== "" && !isNaN(value)) {
                //                    $(this).closest('.input-group').find('.saveclass').css("visibility", "visible");
                //                } else {
                //                    $(this).closest('.input-group').find('.saveclass').css("visibility", "hidden");
                //                }
                //            });



                //        });
                //    },
                //    error: function (xhr, status, error) {
                //        console.error("XHR:", xhr);
                //        console.error("Status:", status);
                //        console.error("Error:", error);
                //        Swal.fire("Error loading countries: " + xhr.responseText);
                //    }
                //})


                fetch("https://localhost:7264/api/Users", {
                    method: "GET",
                    //headers: {
                    //    "Content-Type": "application/json; charset=utf-8"
                    //}
                })
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        return response.json();
                    })
                    .then(data => {
                        userTable.clear();
                        userTable.order([]);

                        data.forEach(user => {
                            userTable.row.add([
                                `<td></td>`,
                                user.name,
                                user.lastname,
                                user.email,
                                user.phone,
                                user.dob,
                                user.submitted,
                                user.countryName,
                                user.stateName,
                                user.districtName,
                                user.skills,
                                `<i class="fas fa-edit edit-btn" data-id="${user.id}"></i>`,
                                `<i class="fa-solid fa-trash delete-btn" data-id="${user.id}"></i>`,
                                `<div class="input-group mb-3">
                    <input type="number" class="form-control" id="${user.id}" min="0" max="100" value="${user.units}" placeholder="" oninput="if (this.value > 100) this.value = this.value.slice(0, -1);" aria-label="" aria-describedby="basic-addon2">
                    <div class="input-group-append">
                        <button class="btn btn-success saveclass" style="" type="button">Save</button>
                    </div>
                </div>`
                            ]).draw();

                            $(`#${user.id}`).on('input', function () {
                                let value = $(this).val();

                                if (value !== "" && !isNaN(value)) {
                                    $(this).closest('.input-group').find('.saveclass').css("visibility", "visible");
                                } else {
                                    $(this).closest('.input-group').find('.saveclass').css("visibility", "hidden");
                                }
                            });
                        });
                    })
                    .catch(error => {
                        console.error("Error fetching data:", error);
                        Swal.fire("Error loading users: " + error.message);
                    });


            }


            $(document).on("click", ".sav", function () {
                debugger;

                let id = $('#editModal').data('userid');
                let name = $('#editName').val();
                let lastname = $('#editLastName').val();
                let email = $('#editEmail').val();
                let phone = $('#editPhone').val();
                let dob = $('#editDob').val();

                

               
                    payload = {
                        id: id,
                        name: name,
                        lastname: lastname,
                        email: email,
                        phone: phone,
                        dob: dob
                    };

                $.ajax({
                    type: "PATCH", 
                    url: `https://localhost:7264/api/Users/${id}`,
                    data: JSON.stringify(payload),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        console.log(response);
                        automatic();

                            Swal.fire("Success", response, "success");
                            $('#editModal').modal('hide');
                       
                    },
                    error: function (xhr, status, error) {
                        Swal.fire("Error", "AJAX Error: " + error, "error");
                    }
                });
            });



            function updateRowColor(row, unitsValue) {
                debugger
                console.log("Row ", row);
                console.log("Units Value", unitsValue);
                unitsValue = parseInt(unitsValue);

                row.removeClass('low-units medium-units high-units');

                if (unitsValue < 40) {
                    row.addClass('low-units');
                } else if (unitsValue >= 40 && unitsValue <= 70) {
                    row.addClass('medium-units');
                } else {
                    row.addClass('high-units');
                }




                row.find('input[type="number"]').val(unitsValue);

            }


            automatic();

            $("#tableid tbody").on("click", ".details-control", function () {
                debugger
                let tablerow = $(this).closest("tr");
                let parentrow = userTable.row(tablerow);

                if (parentrow.child.isShown()) {
                    parentrow.child.hide();
                    tablerow.removeClass("shown");
                    return;
                }

                let data = parentrow.data();

                let html = `
                            <table class="table table-bordered" style="width:700px">
                                <tr>
                                <th>Country</th>
                                <td>${data[7]}</td>
                                </tr>
                                <tr>
                                <th>State</th>
                                <td>${data[8]}</td>
                                </tr>
                                <tr>
                                <th>District</th>
                                <td>${data[9]}</td>
                                </tr>
                            </table>
                             <table class="table table-bordered" style="width:700px">
                             <tr>
                             <th style="width:247px">Skills</th>
                             <td>${data[10]}</td>
                             </tr>

                         </table>
                        `;






                parentrow.child(html).show();
                tablerow.addClass("shown");

            })

            $.ajax({
                type: "GET",
                url: "https://localhost:7264/api/Users/proj_country",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    debugger
                    const countries = response;
                    const countryDropdown = $("#countryid");
                    countryDropdown.empty().append(new Option("Select Country", ""));


                    $.each(countries, function (i, c) {
                        countryDropdown.append(new Option(c.countryNames, c.countryId));
                    });
                    

                    console.log("Dropdown populated:", countries);
                },
                error: function (xhr, status, error) {
                    console.error("XHR object:", xhr);
                    console.error("Status:", status);
                    console.error("Error message:", error);

                    let responseText = xhr.responseText || "No response text";
                    console.log("Response Text:", responseText);

                    Swal.fire("Error loading countries: " + responseText);
                }

            });


            $("#countryid").change(function () {
                debugger
                const countryId = parseInt($(this).val()); 
                const stateDropdown = $("#stateid");
                const districtDropdown = $("#districtid");

                stateDropdown.empty().append(new Option("Select State", ""));
                districtDropdown.empty().append(new Option("Select District", ""));
                if (!countryId) return;

                $.ajax({
                    type: "GET",
                    url: `https://localhost:7264/api/Users/proj_state?countryId=${countryId}`,
                    data: JSON.stringify({ countryId: countryId }), 
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        debugger
                        const states = response;
                        $.each(states, function (i, s) {
                            stateDropdown.append(new Option(s.stateNames, s.stateId));
                        });
                    },
                    error: function (xhr) {
                        console.log("Error loading states:", xhr.responseText);
                    }
                });
            });



            $("#stateid").change(function () {
                debugger
                const stateId = $(this).val();
                const districtDropdown = $("#districtid");

                districtDropdown.empty().append(new Option("Select District", ""));
                if (!stateId) return;

                $.ajax({
                    type: "GET",
                    url: `https://localhost:7264/api/Users/proj_district?stateId=${stateId}`,
                    data: JSON.stringify({ stateId: stateId }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        debugger
                        const district = response;
                        $.each(district, function (i, d) {
                            districtDropdown.append(new Option(d.districtNames, d.districtId));
                        });
                    },
                    error: function (xhr, status, error) {
                        alert("Error loading districts: " + xhr.responseText);
                    }
                });
            });

            $("#submitid").click(function () {

                debugger
                const name = $("#nameinput").val().trim();
                const lastname = $("#plname").val().trim();
                const email = $("#pemail").val().trim();
                const phone = $("#pphone").val().trim();
                const dob = $("#pdob").val().trim();
                const countryid = $("#countryid").val().trim();
                const stateid = $("#stateid").val().trim();
                const districtid = $("#districtid").val().trim();

                const countryname = $("#countryid option:selected").text().trim();
                const statename = $("#stateid option:selected").text().trim();
                const districtname = $("#districtid option:selected").text().trim();
                const skills = $("#skillsid option:selected")
                    .map(function () {
                        return $(this).text();
                    })
                    .get()
                    .join(", ");

                console.log(skills);

                const submitted = new Date().toLocaleString();



                if (!name) {
                    Swal.fire({ icon: 'warning', title: 'Validation Error', text: 'Please enter your first name!' });
                    return;
                }

                if (!lastname) {
                    Swal.fire({ icon: 'warning', title: 'Validation Error', text: 'Please enter your last name!' });
                    return;
                }

                if (!email) {
                    Swal.fire({ icon: 'warning', title: 'Validation Error', text: 'Please enter your email!' });
                    return;
                }

                const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
                if (!emailPattern.test(email)) {
                    Swal.fire({ icon: 'error', title: 'Invalid Email', text: 'Please enter a valid email address!' });
                    return;
                }

                if (!phone) {
                    Swal.fire({ icon: 'warning', title: 'Validation Error', text: 'Please enter your phone number!' });
                    return;
                }

                if (phone.length > 10 || phone.length < 10) {
                    Swal.fire({ icon: 'error', title: 'Invalid Phone', text: 'Phone number must be between 10' });
                    return;
                }

                if (!dob) {
                    Swal.fire({ icon: 'warning', title: 'Validation Error', text: 'Please select your date of birth!' });
                    return;
                }

                const today = new Date().toISOString().split('T')[0];

                let d = new Date("2007-12-17");
                let newdob = new Date(dob)

                if (newdob > d) {
                    Swal.fire({ icon: 'error', title: 'Invalid DOB', text: 'You should be atleast 18 years old' });
                    return;
                }



                if (!countryid) {
                    Swal.fire({ icon: 'warning', title: 'Validation Error', text: 'Please select a country!' });
                    return;
                }

                if (!stateid) {
                    Swal.fire({ icon: 'warning', title: 'Validation Error', text: 'Please select a state!' });
                    return;
                }

                if (!districtid) {
                    Swal.fire({ icon: 'warning', title: 'Validation Error', text: 'Please select a district!' });
                    return;
                }

                if (!skills || skills.length === 0) {
                    Swal.fire({ icon: 'warning', title: 'Validation Error', text: 'Please select at least one skill' });
                    return;
                }

                const dataToSend = {
                    name: name,
                    lastname: lastname,
                    email: email,
                    phone: phone,
                    dob: dob,
                    skills: skills,
                    submitted: submitted,
                    countryid: countryid,
                    stateid: stateid,
                    districtid: districtid
                };

                $.ajax({
                    type: "POST",
                    url: "https://localhost:7264/api/Users",
                    data: JSON.stringify(dataToSend),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        debugger
                        automatic();
                        Swal.fire({
                            icon: "success",
                            title: "You have been submitted the form successfully"
                        })

                        $("#nameinput").val("");
                        $("#plname").val("");
                        $("#pemail").val("");
                        $("#pphone").val("");
                        $("#pdob").val("");
                        $("#countryid").val("");
                        $("#stateid").val("");
                        $("#districtid").val("");
                        $("#countryid").trigger("change");
                        $("#stateid").trigger("change");
                        $("#districtid").trigger("change");
                        $('#skillsid').val(null).trigger('change');

                    },
                    error: function (xhr, status, error) {
                        alert("Error inserting user data: " + error + xhr.responseText);
                    }

                });
            });

            $(document).on('click', '.edit-btn', function () {
                debugger
                let userId = $(this).data('id');

                console.log("Edit clicked, userId:", userId);

                $.ajax({
                    type: "GET",
                    url: `https://localhost:7264/api/Users/${userId}`,
                    data: JSON.stringify({ userId: userId }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        let user = response;

                        $('#editName').val(user.name);
                        $('#editLastName').val(user.lastname);
                        $('#editEmail').val(user.email);
                        $('#editPhone').val(user.phone);
                        $('#editDob').val(user.dob);

                        $('#editModal').data('userid', userId);

                        console.log("Stored userId:", $('#editModal').data('userid'));

                        $('#editModal').modal('show');
                    }
                });
            });




           
            $(document).on('click', '.delete-btn', function () {
                var row = $(this).closest('tr');
                var userId = $(this).data('id');

                if (!userId) {
                    Swal.fire("Error", "User ID is missing.", "error");
                    return;
                }

                Swal.fire({
                    title: 'Are you sure?',
                    text: "You are about to delete this user.",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonText: 'Yes, delete it!',
                    cancelButtonText: 'Cancel'
                }).then((result) => {
                    if (result.isConfirmed) {

                        $.ajax({
                            type: "DELETE",  
                            url: `https://localhost:7264/api/Users/${userId}`,
                            success: function () {

                                row.fadeOut(500, function () {
                                    $(this).remove();
                                });

                                automatic();

                                Swal.fire(
                                    'Deleted!',
                                    'The user has been deleted.',
                                    'success'
                                );
                            },
                            error: function (xhr) {
                                Swal.fire(
                                    'Error!',
                                    xhr.responseText || 'Failed to delete user.',
                                    'error'
                                );
                            }
                        });

                    }
                });
            });


            //let isFullUpdate =
            //    name &&
            //    lastname &&
            //    email &&
            //    phone &&
            //    dob;

            //let url, payload;

            //if (isFullUpdate) {
            //    url = "WebForm1.aspx/PutUser";

            //    payload = {
            //        id: id,
            //        name: name,
            //        lastname: lastname,
            //        email: email,
            //        phone: phone,
            //        dob: dob
            //    };
            //} else {
            //    url = "WebForm1.aspx/PatchUser";



        });



    </script>



</body>
</html>




