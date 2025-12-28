<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page.aspx.cs" Inherits="month3.page" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Read Params</title>
</head>
<body>

    <h2>Received Parameters</h2>
    <p id="output"></p>

    <script>
        const params = new URLSearchParams(window.location.search);

        const userId = params.get("id");
        const name = params.get("name");

        document.getElementById("output").innerHTML =
            `User ID: ${userId}<br>Name: ${name}`;
    </script>

</body>
</html>

















<%--<!DOCTYPE html>
<html>
<body>

<script>
    const params = new URLSearchParams({
        userId: 5,
        name: "Alice"
    });

    fetch(`https://jsonplaceholder.typicode.com/posts?${params}`)
        .then(response => response.json())
        .then(data => console.log(data));
</script>

</body>
</html>--%>
