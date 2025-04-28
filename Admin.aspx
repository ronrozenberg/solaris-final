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
</asp:Content>

