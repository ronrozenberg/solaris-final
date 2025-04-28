<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Stats.aspx.cs" Inherits="solaris_final.Stats" %>
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

        .tags{
            font-size: 3rem;
            text-align:center;
        }

        .numbers{
            font-size: 6rem;
            text-align:center;
        }

        .statsholder{
            margin-top: 5vh;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<body>
    <h1>דף סטטיסטיקות</h1>
    <div class="statsholder">
        <p class="tags">סה"כ כניסות</p>
        <div class="numbers" id="counter" runat="server"></div>
        <p class="tags">כניסות מחוברים</p>
        <div class="numbers" id="counterloggedin" runat="server"></div>
        <p class="tags">אונליין</p>
        <div class="numbers" id="onlinec" runat="server"></div>
    </div>
</body>
</asp:Content>
