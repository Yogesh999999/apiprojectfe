<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page2.aspx.cs" Inherits="month3.page2" %>

<!DOCTYPE html>
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
</html>

