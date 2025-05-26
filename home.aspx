<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="solaris_final.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body class="homebody">
        <p id="knemida" class="rubik-font">קנה מידה: שנה = 12 שניות</p>
        <div class="solar-system-container">
            <div class="sun"><a href="sun.aspx"><img src="images/sun-small.png" alt="sun-small" height="75"></a></div>
            <div class="planet planet-1"><a href="mercury.aspx"><img src="images/mercury-small.jpg" alt="mercury" height="15"></a></div>
            <div class="planet planet-2"><a href="venus.aspx"><img src="images/venus.jpg" alt="venus" height="25"></a></div>
            <div class="planet planet-3"><a href="earth.aspx"><img src="images/earth-small.jpg" alt="earth" height="26"></a></div>
            <div class="planet planet-4"><a href="mars.aspx"><img src="images/mars-small.png" alt="mars" height="18"></a></div>
            <div class="planet planet-5"><a href="jupiter.aspx"><img src="images/jupiter-small.jpg" alt="jupiter" height="50"></a></div>
            <div class="planet planet-6"><a href="saturn.aspx"><img src="images/saturn-small.jpg" alt="saturn" height="50"></a></div>
            <div class="planet planet-7"><a href="uranus.aspx"><img src="images/uranus-small.jpg" alt="uranus" height="25"></a></div>
            <div class="planet planet-8"><a href="neptune.aspx"><img src="images/neptune-small.jpg" alt="neptune" height="40"></a></div>
        </div>
    </body>
</asp:Content>
