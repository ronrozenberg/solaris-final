<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="solaris_final.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="adminbody">
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
     </div>
</asp:Content>

