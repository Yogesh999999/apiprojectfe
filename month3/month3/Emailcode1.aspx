<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Emailcode1.aspx.cs" Inherits="month3.Emailcode1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Send Email</h2>

            <input type="email" id="txtTo" placeholder="To Email" /><br />
            <br />
            <input type="text" id="txtSubject" placeholder="Subject" /><br />
            <br />
            <textarea id="txtBody" placeholder="Message"></textarea><br />
            <br />

            <button type="button" onclick="sendEmail()">Send Email</button>
        </div>
    </form>

    <script>
         function sendEmail() {

            var emailData = {
                toEmail: document.getElementById("txtTo").value,
                subject: document.getElementById("txtSubject").value,
                body: document.getElementById("txtBody").value
            };

            $.ajax({
                type: "POST",
                url: "Emailcode1.aspx/SendMail",
                data: JSON.stringify(emailData),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert(response.d); 
                },
                error: function () {
                    alert("AJAX call failed");
                }
            });
        }
    </script>
</body>
</html>
