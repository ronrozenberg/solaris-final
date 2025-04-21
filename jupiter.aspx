<%@ Page Title="" Language="C#" MasterPageFile="~/Planets.Master" AutoEventWireup="true" CodeBehind="jupiter.aspx.cs" Inherits="solaris_final.jupiter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="planetbig"><img src="images/jupiter-huge.jpg" height="1000"></div>
<div class="para">
    <h1 id="pagetitle" class="rubik-font">צדק</h1>
    <p class="rubik-font">
      צֶדֶק (בלועזית: Jupiter, יופיטר) הוא כוכב הלכת החמישי במרחקו מהשמש, וכוכב הלכת הגדול ביותר במערכת השמש. צדק הוא ענק גזים ומרבית מסתו היא מימן והליום. בדומה לכוכבי לכת גזיים אחרים במערכת השמש, לצדק יש מערכת טבעות ומערכת ירחים.
    </p>
    <div>
    <table class="rubik-font">
        <tr>
          <th>מידע כללי</th>
        </tr>
        <tr>
          <td>סוג עצם:</td>
          <td>כוכב לכת</td>
        </tr>
        <tr>
          <td>סוג כוכב:</td>
          <td>ענק גזים</td>
        </tr>
        <tr>
          <td>מרחק ממוצע מהשמש:</td>
          <td>778,340,821 ק"מ</td>
        </tr>
        <tr>
          <td>קוטר:</td>
          <td>142,984 ק"מ</td>
        </tr>
    </table>
    </div>
    <div>
    <img src="images/jupitermoons.png" id="chartimage">
    </div>
    <h1 class="rubik-font" id="title-header"><a href="home.aspx">חזרה ⮎</a></h1>
</div>
</asp:Content>
