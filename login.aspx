<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="solaris_final.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<style>body {font-family: "Rubik", sans-serif; color:white;}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body class="registration-form">
    <h1 id="title">דף כניסה</h1>
    <form>
        <div class="field-group">
            <h2 class="fieldstag">שם משתמש:</h2>
            <input type="text" class="text-input" name="userName" id="userName" runat="server">
            <div class="error" id="usernameError" runat="server"></div>
            <style>.error {color: gold;}</style>
        </div>

        <div class="field-group">
            <h2 class="fieldstag">סיסמה:</h2>
            <input type="password" class="text-input" name="password" id="password" runat="server">
            <div class="error" id="passwordError" runat="server"></div>
        </div>

        <button type="button" runat="server" id="submit" onserverclick="btnClick">כניסה</button>
    </form>
</body>
<script src="login.js"></script>
</asp:Content>
