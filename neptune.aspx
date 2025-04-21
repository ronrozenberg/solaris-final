<%@ Page Title="" Language="C#" MasterPageFile="~/Planets.Master" AutoEventWireup="true" CodeBehind="neptune.aspx.cs" Inherits="solaris_final.neptune" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="planetbig"><img src="images/neptune-big.jpg" height="1000"></div>
        <div class="para">
            <h1 id="pagetitle" class="rubik-font">נפטון</h1>
            <p class="rubik-font">
              נפטון (בלועזית: Neptune; השם העברי: רַהַב) הוא כוכב הלכת השמיני במערכת השמש. הוא הקטן והמרוחק בין ארבעת ענקי הגזים והוא מסווג בתת-הקטגוריה של ענק קרח, עקב היותו מכוסה בשכבת מים וקרח. נפטון, הקרוי על שמו של נפטון, אל הים במיתולוגיה הרומית, נמצא בתהודה מסלולית עם כוכב הלכת הננסי פלוטו.
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
                  <td>4,498,252,900 ק"מ</td>
                </tr>
                <tr>
                  <td>קוטר:</td>
                  <td>49,528 ק"מ</td>
                </tr>
            </table>
            </div>
            <div>
            <img src="images/uranusdiagram.png" id="chartimage">
            </div>
            <h1 class="rubik-font" id="title-header"><a href="home.aspx">חזרה ⮎</a></h1>
        </div>
</asp:Content>
