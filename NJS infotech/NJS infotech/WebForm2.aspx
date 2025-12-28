<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm2.aspx.vb" Inherits="NJS_infotech.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

        <div>
                <div>
        <h4>General form</h4>
        <form action="HtmlPage3.html" autocomplete="on" >
                
                <label for="n">Full name:</label>
                <input type="text" placeholder="name" id="n" autofocus /><br /><br />
                <label for="e">E-mail</label>
                <input type="email" placeholder="email" id="e"/><br /><br />
                <label for="p">Password:</label>
                <input type="password" placeholder="password" id="p" /><br /><br />
                <label >Gender:</label>
                <input type="radio" id="m" name="group" />
                <label for="m">Male</label>
                <input type="radio" id="j" name="group" />
                <label for="j">Female</label><br /><br />
                <label>Skills</label><br />
                <input type="checkbox" />
                <label>HTML</label><br />
                <input type="checkbox" />
                <label>CSS</label><br />
                <input type="checkbox" />
                <label>JAVA SCRIPT</label><br/>
                <label>Country:</label>
                <select>
                    <option disabled selected>select</option>
                    <option>INDIA</option>
                    <option>UK</option>
                    <option>AUSTRALIA</option>
                </select><br /><br />
                <label for="d">Date of birth</label>
                <input type="date" placeholder="date" id="d" max="2007-09-18"  /><br /><br />
                <input type="submit" value="Submit" />
                <input type="button" value="Reset" />
        </form>
    </div>
    <table id="tableid">
        <tr class="t1">
            <th class="h1">Name</th>
            <td class="d1">Yogesh</td>
        </tr>
        <tr class="t1">
            <th class="h1">Password</th>
            <td class="d1">********</td>
        </tr>
        <tr class="t1">
            <th class="h1">E-mail</th>
            <td class="d1">Yogesh@gmail.com</td>
        </tr>
        <tr class="t1">
            <th class="h1">Gender</th>
            <td class="d1">Male</td>
        </tr>
        <tr class="t1">
            <th class="h1">Skills</th>
            <td class="d1">Html,css</td>
        </tr>
        <tr class="t1">
            <th class="h1">Country</th>
            <td class="d1">India</td>
        </tr>
        <tr class="t1">
            <th class="h1">Date of birth</th>
            <td class="d1">09-08-2003</td>
        </tr>
    </table>
</body>
</html>
