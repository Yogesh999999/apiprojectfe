<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jsfetch.aspx.cs" Inherits="month3.jsfetch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
    <script>
        const url = "https://localhost:7264/api/Users"

        fetch(url)
            .then(response => {
                if (!response.ok) {
                    throw new Error("network error")
                }

                return response.json();
            })
            .then(data => {
                console.log("data received", data)
            })
            .catch(error => {
                console.error('There was a problem with the fetch operation:', error); 
            });
    </script>
</body>
</html>
