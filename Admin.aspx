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
        <div class="adminbuttons">
        <br />
        <label for="Columns">Sort by Column:</label> &nbsp &nbsp 
         <select id="Columns" runat="server">
            <option value="Id">userId</option>
            <option value="fname">firstName</option>
            <option value="lname">lastName</option>
            <option value="username">userName</option>
            <option value="admin">Admin</option>
            <option value="date">Birthday</option>
            <option value="city">City</option>
        </select>           &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp 
        <input type="radio" id="ASC" name="order" value="ASC" checked/>
        <label for="ASC">ASC</label>         &nbsp &nbsp
        <input type="radio" id="DESC" name="order" value="DESC" />
        <label for="DESC">DESC</label>      <br /> <br />
        <input type="button" value="Sort" name="btnSort" id="btnSort" runat="server" onserverclick="Click_Sort" />
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

