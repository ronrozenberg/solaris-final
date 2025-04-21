<%@ Page Title="" Language="C#" MasterPageFile="~/Planets.Master" AutoEventWireup="true" CodeBehind="mercury.aspx.cs" Inherits="solaris_final.mercury" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="planetbig"><img src="images/mercury-huge.jpg" height="1000"></div>
        <div class="para">
            <h1 id="pagetitle" class="rubik-font">כוכב חמה</h1>
            <p class="rubik-font">
              כוכב־חמה (באנגלית: Mercury, מרקורי) הוא כוכב הלכת הקרוב ביותר לשמש והקטן ביותר במערכת השמש. כוכב-חמה הוא כוכב סלעי ואין לו ירחים.
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
                  <td>57,909,176 ק"מ</td>
                </tr>
                <tr>
                  <td>קוטר:</td>
                  <td>4,878 ק"מ</td>
                </tr>
            </table>
            </div>
            <div>
            <img src="images/Messenger.jpg" id="chartimage">
            </div>
            <h1 class="rubik-font" id="title-header"><a href="home.aspx">חזרה ⮎</a></h1>
        </div>
</asp:Content>
