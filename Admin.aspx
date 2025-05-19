<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="solaris_final.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        body{
            background-color:#442069;
            color:lightgoldenrodyellow;
            font-family:'Rubik', sans-serif;
        }

        h1{
            color:lightgoldenrodyellow;
        }

        table {
            border-collapse: collapse;
            width: 100%;
            max-width: 800px;
            margin: 20px auto;
        }
        th, td {
            padding: 8px;
            text-align: left;
        }
        th {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>דף משתמשים</h1>
    <table>
        <thead>
            <tr>
                <th>מספר</th>
                <th>שם משתמש</th>
                <th>סיסמה</th>
                <th>אדמין?</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>1</td>
                <td><%Response.Write(Session["username1"]); %></td>
                <td><%Response.Write(Session["password1"]);%></td>
                <td><%Response.Write(Session["isadmin1"]);%></td>
            </tr>
            <tr>
                <td>2</td>
                <td><%Response.Write(Session["username2"]); %></td>
                <td><%Response.Write(Session["password2"]);%></td>
                <td><%Response.Write(Session["isadmin2"]);%></td>
            </tr>
            <tr>
                <td>3</td>
                <td><%Response.Write(Session["username3"]); %></td>
                <td><%Response.Write(Session["password3"]);%></td>
                <td><%Response.Write(Session["isadmin3"]);%></td>
            </tr>
        </tbody>
    </table>
    <br />
        Enter Text to search name:
        <input type="text" name="filter" id="filter" />
        <br /> <br /> 
        <input type="button" value="Filter" name="btnFilter1" id="btnFilter1" runat="server" onserverclick="Click_Filter1" />
        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
        <input type="button" value="Delete" name="btnDelete" id="Button1" runat="server" onserverclick="Delete" />
        &nbsp &nbsp &nbsp &nbsp
        <input type="button" value="Edit" name="btnEdit" id="btnEdit" runat="server"  onserverclick="Edit"/> 
        &nbsp &nbsp &nbsp &nbsp
        <input type="button" value="Add" name="btnAdd" id="btnAdd" runat="server"  onserverclick="Add"/> 
        &nbsp &nbsp &nbsp &nbsp
        <input type="button" value="Change to Admin" name="btnAdmin" id="btnAdmin" runat="server"  onserverclick="ChangeToAdmin"/> 
        &nbsp &nbsp &nbsp &nbsp
        <input type="button" value="Change to User" name="btnUser" id="btnUser" runat="server"  onserverclick="ChangeToUser"/> 
        <br /> <br />
            
    </div>
    <div runat="server" id="tableDiv">

    </div>
    
    <div runat="server" id="message">
        
    </div>
    <div runat="server" id="message1">

    </div>
</asp:Content>

