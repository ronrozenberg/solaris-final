<%@ Page Title="" Language="C#" MasterPageFile="~/Planets.Master" AutoEventWireup="true" CodeBehind="saturn.aspx.cs" Inherits="solaris_final.saturn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="planetbig"><img src="images/saturn-huge.jpg" height="1000"></div>
    <div class="para">
        <h1 id="pagetitle" class="rubik-font">שבתאי</h1>
        <p class="rubik-font">
          שַׁבְּתַאי (בלועזית: Saturn, סטורן) הוא כוכב הלכת השישי במרחקו מהשמש והשני בסדרת כוכבי הלכת הגזיים. את שבתאי מקיפות טבעות פלנטריות בשם טבעות שבתאי, שמכילות בעיקר קרח ואבק.
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
              <td>1,426,725,413 ק"מ</td>
            </tr>
            <tr>
              <td>קוטר:</td>
              <td>120,500 ק"מ</td>
            </tr>
        </table>
        </div>
        <div>
        <img src="images/saturndiagram.png" id="chartimage">
        </div>
        <h1 class="rubik-font" id="title-header"><a href="home.aspx">חזרה ⮎</a></h1>
    </div>
</body>
</asp:Content>
