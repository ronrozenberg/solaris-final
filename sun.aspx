<%@ Page Title="" Language="C#" MasterPageFile="~/Planets.Master" AutoEventWireup="true" CodeBehind="sun.aspx.cs" Inherits="solaris_final.sun" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="planetbig"><img src="images/sun-huge.jpg" height="1000"></div>
        <div class="para">
            <h1 id="pagetitle" class="rubik-font">השמש</h1>
            <p class="rubik-font">
                השֶּׁמֶשׁ היא כוכב מהסדרה הראשית מסוג G (ננס צהוב) שנמצא במרכז מערכת השמש. כדור הארץ וגופים נוספים הכוללים כוכבי לכת, כוכבי לכת ננסיים, כוכבי לכת מינוריים, אסטרואידים, שביטים ואבק בין־כוכבי, חגים סביב השמש במסלולים קבועים עקב כוח הכבידה שלה.
            </p>
            <div>
            <table class="rubik-font">
                <tr>
                  <th>מידע כללי</th>
                </tr>
                <tr>
                  <td>סוג עצם:</td>
                  <td>כוכב</td>
                </tr>
                <tr>
                  <td>סוג כוכב:</td>
                  <td>ננס צהוב</td>
                </tr>
                <tr>
                  <td>קוטר:</td>
                  <td>1,392,684 ק"מ</td>
                </tr>
            </table>
            </div>
            <div>
            <img src="images/solarlife.png" id="chartimage">
            </div>
            <h1 class="rubik-font" id="title-header"><a href="home.aspx">חזרה ⮎</a></h1>
        </div>
</asp:Content>
