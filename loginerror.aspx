<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="loginerror.aspx.cs" Inherits="solaris_final.loginerror" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
        body{
             background-color:#442069;
             font-family:'Rubik', sans-serif;
        }

        #error{
            font-size: 5rem;
            color:lightgoldenrodyellow;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <h1 id="error">בעיה בתהחברות!</h1>
    </body>
</asp:Content>
