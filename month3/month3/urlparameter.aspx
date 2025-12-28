<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="urlparameter.aspx.cs" Inherits="month3.urlparameter" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Send Params</title>
</head>
<body>

  <h2>Send Parameters</h2>
    <label>Name</label>
    <input type="text" id="nameid" />
    <label>ID</label>
    <input type="number" id="numid"/>

  <button onclick="sendParams()">Submit</button>

  <script>
      function sendParams() {
          debugger
          let id = document.getElementById("numid").value
          let name = document.getElementById("nameid").value
          let url = new URL("page.aspx", window.location.origin)

          url.searchParams.append("name", name)
          url.searchParams.append("id", id)

          window.location.href = url.toString();
    }
  </script>

</body>
</html>

using System;
using System.Net.Http;
using System.Web.Services;

namespace month3
{
    public partial class apiproject : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient();

        [WebMethod]
        public static string GetApiData()
        {
            string url = "https://localhost:44382/api/TotalContext";
            try
            {
                
                string response = client.GetStringAsync(url).Result;
                return response; 
            }
            catch (Exception ex)
            {
                return "{\"error\":\"" + ex.Message + "\"}";
            }
        }
    }
}