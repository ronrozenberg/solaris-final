<%@ Page Title="" Language="C#" MasterPageFile="~/Planets.Master" AutoEventWireup="true" CodeBehind="mars.aspx.cs" Inherits="solaris_final.mars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="planetbig"><img src="images/mars-big.png" height="1000"></div>
        <div class="para">
            <h1 id="pagetitle" class="rubik-font">מאדים</h1>
            <p class="rubik-font">
              מאדים (בלטינית: Mars, בתעתיק מדויק: מַארס) הוא כוכב הלכת הרביעי במערכת השמש. מסלולו הוא השני הקרוב ביותר למסלול כדור הארץ (אחרי נוגה) והוא כוכב הלכת השני הקטן ביותר, גדול רק מכוכב חמה. צבע פניו של מאדים אדמדם בשל ריבוי תחמוצות ברזל בקרקעו, ומכאן שמו העברי והכינוי "כוכב הלכת האדום". סמלו מייצג את המגן והחנית של האל מרס: עיגול עם חץ.
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
                  <td>227,936,637 ק"מ</td>
                </tr>
                <tr>
                  <td>קוטר:</td>
                  <td>6,721 ק"מ</td>
                </tr>
            </table>
            </div>
            <div>
            <img src="images/Mars,_Earth_size_comparison.jpg" id="chartimage">
            </div>
            <h1 class="rubik-font" id="title-header"><a href="home.aspx">חזרה ⮎</a></h1>
        </div>

</asp:Content>
