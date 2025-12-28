<%@ Page Language="vb" AutoEventWireup="false"CodeBehind="WebForm1.aspx.vb" Inherits="NJS_infotech.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NJS INFOTECH</title>
    <style>
/*        p {
            background-color:red;
            color:aquamarine

        }*/
        h1{
            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            font-size:200px;
            border:10px solid black;
                
        }
        #body{
/*            background-image: url(export/imm.jpg);
            background-repeat:no-repeat;
            background-size:100% 100%;*/
        }
        table,th,td{
            border:1px solid black;
            padding:10px
        }
        .first{
            float:left;
            width:50%;
            color:antiquewhite
        }
        .sec{
            float:left;
            width:20%;
            color:aquamarine
        }
/*        @media(max-width:500px){
            .first.sec.thir{
                width:100%
            }
        }*/
    </style>
</head>
<body id="body"> 
        <div>
            <h1> hello this is yogesh   ji</h1>
            <p>oiii this is not valid</p>
            <a href="">hello</a>
            <img src="/Solution items/IMG_1566.JPG">
            <a href="https://www.w3schools.com/html/tryit.asp?filename=tryhtml_links_image" ><img src="export/imm.jpg"/></a>
            <a href="#4" >go to 4</a>
            <h1 style="background-image:"export/imm.jpg;" >heljkjlo </h1>
            <h1> hello </h1>
            <h1> hello </h1>
            <h1 id="4"> hello </h1>
            <h1> hello </h1>
            <img src="" alt="" usemap="#hop"/>
            <map name="hop" >
                <area />
            </map>
            <table style="width:100%" >
                <colgroup>
                    <col span="1" style="background-color:red;" />
                    <col span="1" style="background-color:plum;" />
                    <col span="1" style="background-color:yellow;" />


                </colgroup>
                <tr>
                    <th>
                        name
                    </th>
                        <th>
                            address
                        </th>
                        <th>
                            phoneno
                        </th>
                </tr>
                <tr>
                    <td>
                        yogesh
                    </td>
                    <td>
                        madipakkam
                    </td>
                    <td>
                        8610208397
                    </td>
                </tr>
                 <tr>
     <td>
         yogesh
     </td>
     <td>
         madipakkam
     </td>
     <td>
         8610208397
     </td>
 </tr>
                 <tr>
     <td>
         yogesh
     </td>
     <td>
         madipakkam
     </td>
     <td>
         8610208397
     </td>
 </tr>
            </table>
            <p>wow</p>
            <ol>
                <li>hi</li>
                <li>hi</li>
                <li>hi</li>
            </ol>
            <ul>
                <li>kk</li>
                <li>kk</li>
                <li>kk</li>                
            </ul>
        </div>
    <p id="pid"></p>
    <button onclick="fu()">click </button>
    <button onclick="del()" >delete</button>
    <script>
        function fu() {
            document.getElementById("pid").innerHTML = "this is something"
            console.log(a)
        }
        function del() {
            document.getElementById("pid").innerHTML = ""

        }
    </script>
    <address>
        hello this is yogesh
    </address>
    <h1 style="font-size:10vw" >
        font size
    </h1>
    <p class="first">hey you</p>
    <p class="sec">hey you</p>
    <p class="thir" >hey you</p><br />


    <h3>Travel booking form</h3>

    <form action="HtmlPage1.html" autocomplete="on" method="get" target="_self">
        <fieldset>
            <legend>Form</legend>/
        <input type="radio" id="r1"/>
        <label for="r1" >Name</label>
        <input type="checkbox" id="c1" />
        <label for="c1" >male</label>
        <input type="submit" value="submit" />
        <label for="i1">name</label>
            <input type="password" placeholder="should be private"/>
        <select id="i1" size="5">
            <option>yogesh</option>
            <option>kk</option>
            <option>vary</option>
        </select>
            <input list="form" />
           <datalist id="form">
                <option>h</option>
                <option>j</option>
                <option>k</option>
            </datalist>

            </fieldset>
        
    </form>


</body>
</html>
