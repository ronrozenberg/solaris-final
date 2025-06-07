<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Stats.aspx.cs" Inherits="solaris_final.Stats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="stats">
    <h1>דף סטטיסטיקות</h1>
    <div class="statsholder">
        <p class="tags">סה"כ כניסות</p>
        <div class="numbers" id="counter" runat="server"></div>
        <p class="tags">כניסות מחוברים</p>
        <div class="numbers" id="counterloggedin" runat="server"></div>
        <p class="tags">אונליין</p>
        <div class="numbers" id="onlinec" runat="server"></div>
    </div>
</div>
</asp:Content>
