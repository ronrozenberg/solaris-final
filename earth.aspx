<%@ Page Title="" Language="C#" MasterPageFile="~/Planets.Master" AutoEventWireup="true" CodeBehind="earth.aspx.cs" Inherits="solaris_final.earth" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="planetbig"><img src="images/earth-big.jpg" height="1000"></div>
        <div class="para">
            <h1 id="pagetitle" class="rubik-font">כדור הארץ</h1>
            <p class="rubik-font">
              כדור הארץ (או ארץ; מכונה גם "העולם") הוא כוכב הלכת השלישי במערכת השמש, החמישי בגודלו במערכת, והגדול מבין ארבעת כוכבי הלכת הארציים. על פי הערכות מדעיות, הוא נוצר לפני כ-4.54 מיליארד שנים וכ-20–30 מיליון שנים לאחר מכן רכש את הלוויין הטבעי היחיד סביבו, הירח. כמיליארד שנים לאחר היווצרותו הופיעו בו התאים החיים הראשונים. כדור הארץ הוא גרם השמיים היחיד שידוע על קיום חיים בו.
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
                  <td>149,598,023 ק"מ</td>
                </tr>
                <tr>
                  <td>קוטר:</td>
                  <td>12,742 ק"מ</td>
                </tr>
            </table>
            </div>
            <div>
            <img src="images/world-map-continents-oceans.png" id="chartimage">
            </div>
            <h1 class="rubik-font" id="title-header"><a href="home.aspx">חזרה ⮎</a></h1>
        </div>
</asp:Content>
