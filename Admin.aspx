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
        h2 {
                text-align: center;
        }
        #filter{
            width:80%;
            margin-left:10%;
            margin-right:10%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>דף משתמשים</h1>
    
    <br />
    <div>
        <h2>חיפוש טקסט</h2>
        <input type="text" name="filter" id="filter" />
        <br /> <br /> 
        <div class="adminbuttons">
        <input type="button" class="sqlbuttons" value="Filter" name="btnFilter1" id="btnFilter1" runat="server" onserverclick="Click_Filter1" />
        &nbsp &nbsp &nbsp &nbsp
        <input type="button" class="sqlbuttons" value="Delete" name="btnDelete" id="Button1" runat="server" onserverclick="Delete" />
        &nbsp &nbsp &nbsp &nbsp
        <input type="button" class="sqlbuttons" value="Edit" name="btnEdit" id="btnEdit" runat="server"  onserverclick="Edit"/> 
        &nbsp &nbsp &nbsp &nbsp
        <input type="button" class="sqlbuttons" value="Add" name="btnAdd" id="btnAdd" runat="server"  onserverclick="Add"/> 
        &nbsp &nbsp &nbsp &nbsp
        <input type="button" class="sqlbuttons" value="Change to Admin" name="btnAdmin" id="btnAdmin" runat="server"  onserverclick="ChangeToadmin"/> 
        &nbsp &nbsp &nbsp &nbsp
        <input type="button" class="sqlbuttons" value="Change to User" name="btnUser" id="btnUser" runat="server"  onserverclick="ChangeToUser"/> 
        <br /> <br />
        </div>
    </div>
    <div runat="server" id="tableDiv">

    </div>
    
    <div runat="server" id="message">
        
    </div>
    <div runat="server" id="message1">

    </div>
</asp:Content>

