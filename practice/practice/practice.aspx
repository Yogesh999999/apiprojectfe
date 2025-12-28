<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="practice.aspx.cs" Inherits="practice.practice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.7.1/jquery.js" integrity="sha512-+k1pnlgt4F1H8L7t3z95o3/KO+o78INEcXTbnoJQ/F2VqDVhWoaiVml/OEHv9HsVgxUaVW+IbiZPUJQfF/YxZw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdn.datatables.net/2.3.5/css/dataTables.dataTables.min.css" />
    <script src="https://cdn.datatables.net/2.3.5/js/dataTables.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 50px; box-shadow: 5px 10px 18px #888888;">
            <div style="background-color: black;" class="card-header">
                <h1 style="color: red; text-align: center">USER FORM</h1>

            </div>
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
                    <input placeholder="Date of  Birth" id="pdob" class="input form-control" type="date" required />
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
                        <option>Html</option>
                        <option>Css</option>
                        <option>Javascript</option>
                        <option>React</option>
                    </select>

                </div>

            </div>




        </div>

        <div id="buttonid">
            <button id="submitid" type="button" class="btn btn-success">Submit</button>
        </div>

        <table id="tableid">
            <thead>
                <tr>
                    <th>name</th>
                    <th>Last Name</th>
                    <th>Email</th>
                    <th>Phone</th>
                    <th>DOB</th>
                    <%--<th>Created at</th>
                    <th>country</th>
                    <th>state</th>
                    <th>district</th>
                    <th>skills</th>
                    <th>Edit</th>
                    <th>Delete</th>--%>
                </tr>
            </thead>
            <tbody></tbody>

        </table>

    </form>
    <script>
        $(document).ready(function () {

            let table = $("#tableid").DataTable();

            let name = $("#nameinput").val()
            let lastname = $("#plname").val()
            let email = $("#pemail").val()
            let phonenumber = $("#pphone").val()
            let dob = $("#pdob").val()
            let country = $("#countryid").val()
            let state = $("#stateid").val()
            let district = $("#districtid").val()

            $("#submitid").on("click", function () {
                debugger
                let name = $("#nameinput").val()
                let lastname = $("#plname").val()
                let email = $("#pemail").val()
                let phonenumber = $("#pphone").val()
                let dob = $("#pdob").val()
                let country = $("#countryid").val()
                let state = $("#stateid").val()
                let district = $("#districtid").val()

                let totaldata = {
                    name: name,
                    lastname: lastname,
                    email: email,
                    phonenumber: phonenumber,
                    dob: dob,
                    //country: country,
                    //state: state,
                    //district: district
                }

                function automatic() {
                    $.ajax({
                        type: "post",
                        url: "practice.aspx/Auto",
                        data: JSON.stringify(totaldata),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            alert("success" + response.d)
                        },
                        error: function (xhr, status, error) {
                            alert("error" + error)
                        }
                    })
                }

                automatic();

               
            })

            function sec() {
                $.ajax({
                    type: "post",
                    url: "practice.aspx/Retriving",
                    data: {},
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (response) {
                        let d = response.d;
                        table.clear();
                        table.order([]);
                        $.each(response.d, function (i, user) {
                            table.row.add([
                                user.name1,
                                user.lastname1,
                                user.email1,
                                user.phone1,
                                user.date1
                            ]).draw()
                        })
                    },
                    error: function (xhr, status, error) {
                        alert("error")
                    }


                })
            }

            sec();

            function countryfun() {
                $.ajax({
                    type: "post",
                    data: {},
                    url:"practice.aspx/Country",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8;",
                    success: function (response) {
                        let valu = response.d;
                        let country1 = $("#countryid")
                        country1.empty().append(new Option("select country", ""))

                        $.each(valu, function (i, c) {
                            country1.append(new Option(c.country,c.cid))
                        });

                    },
                    error: function (xhr, status, error) {
                        alert("error")
                    }
                })
            }

            countryfun();

            $("#countryid").change(function () {
                alert("hi")
                let countryid = $("#countryid").val();
                let state = $("#stateid")
                let district = $("#districtid")
                state.empty().append(new Option("select state", ""))
                district.empty().append(new Option("select district", ""))
                debugger
                $.ajax({
                    type: "post",
                    data: JSON.stringify({ country: countryid }),
                    url: "practice.aspx/Statepop",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    success: function (response) {
                        debugger
                        let total = response.d

                        $.each(total, function (i, user) {
                            state.append(new Option(user.state,user.sid))
                        })

                    }, error: function (xhr, status, error) {
                        alert("error" + error)
                    }

                })

                

            })

        })
    </script>
</body>
</html>
