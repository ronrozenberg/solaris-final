<%@ Page Title="" Language="C#" MasterPageFile="~/Planets.Master" AutoEventWireup="true" CodeBehind="uranus.aspx.cs" Inherits="solaris_final.uranus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="planetbig"><img src="images/uranus-big.jpg" height="1000"></div>
<div class="para">
    <h1 id="pagetitle" class="rubik-font">אורנוס</h1>
    <p class="rubik-font">
      אוּרָנוּס (בלועזית: Uranus ; השם העברי: אוֹרוֹן) הוא כוכב הלכת השביעי במרחקו מן השמש, והוא מצוי במרחק ממוצע של 19.1914 יחידות אסטרונומיות ממנה. נמנה עם ארבעת ענקי הגזים ומסווג בתת-הקטגוריה "ענק קרח". מורכב בעיקר ממימן ומהליום, ובמרכזו ליבה מותכת של ברזל וסיליקטים, המוקפת בשכבה עבה של קרח, מתאן ואמוניה. מעבר לשכבות המוצקות משתרעת האטמוספירה העבה, המורכבת ממימן ומהליום.
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
          <td>2,870,972,220 ק"מ</td>
        </tr>
        <tr>
          <td>קוטר:</td>
          <td>51,118 ק"מ</td>
        </tr>
    </table>
    </div>
    <div>
    <img src="images/uranusdiagram.png" id="chartimage">
    </div>
    <h1 class="rubik-font" id="title-header"><a href="home.aspx">חזרה ⮎</a></h1>
</div>
</asp:Content>
