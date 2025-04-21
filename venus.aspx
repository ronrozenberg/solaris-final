<%@ Page Title="" Language="C#" MasterPageFile="~/Planets.Master" AutoEventWireup="true" CodeBehind="venus.aspx.cs" Inherits="solaris_final.venus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="planetbig"><img src="images/venus.jpg" height="1000"></div>
        <div class="para">
            <h1 id="pagetitle" class="rubik-font">נוגה</h1>
            <p class="rubik-font">
              נוגה (באנגלית: Venus, ונוס) הוא כוכב הלכת השני במרחקו מהשמש (אחרי כוכב חמה). מסלולו של נוגה הוא הקרוב ביותר למסלול כדור הארץ (אם כי חמה הוא הקרוב ביותר לכדור הארץ רוב הזמן), וגודלו הוא הקרוב ביותר לגודל כדור הארץ. נוגה הוא כוכב לכת ארצי שהרכבו דומה להרכב כדור הארץ.
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
                  <td>כוכב לכת ארצי</td>
                </tr>
                <tr>
                  <td>מרחק ממוצע מהשמש:</td>
                  <td>108,208,926 ק"מ</td>
                </tr>
                <tr>
                  <td>קוטר:</td>
                  <td>12,100 ק"מ</td>
                </tr>
            </table>
            </div>
            <div>
            <img src="images/venuscomposition.png" id="chartimage">
            </div>
            <h1 class="rubik-font" id="title-header"><a href="home.aspx">חזרה ⮎</a></h1>
        </div>
</asp:Content>
