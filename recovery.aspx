<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="recovery.aspx.cs" Inherits="solaris_final.recovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<style>body {font-family: "Rubik", sans-serif; color:white;}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<body class="registration-form">
   <h1 id="title">שחזור סיסמה</h1>
   
   <form novalidate method="post" action="recovery.aspx">
       
       <div class="field-group">
           <h2 class="fieldstag">שם משתמש:</h2>
           <input type="text" class="text-input" id="username" name="username" required>
           <div class="error" id="usernameError"></div>
       </div>
       
       <div class="field-group">
           <h2 class="fieldstag">בחר שאלת אבטחה:</h2>
           <select id="securityQuestion" name="securityQuestion" class="text-input" required>
               <option value="">בחר שאלה</option>
               <option value="מה היה השם של הכלב הראשון שלך?">מה היה השם של הכלב הראשון שלך?</option>
               <option value="איך קוראים לאבא שלך?">איך קוראים לאבא שלך?</option>
               <option value="מה הפרי האהוב עליך?">מה הפרי האהוב עליך?</option>
               <option value="באיזה בית ספר למדת?">באיזה בית ספר למדת?</option>
               <option value="מה השם של סבא שלך?">מה השם של סבא שלך?</option>
               <option value="האם אביתר המורה הכי טוב?">האם אביתר המורה הכי טוב?</option>
           </select>
           <div class="error" id="questionError"></div>
       </div>

       <div class="field-group">
           <h2 class="fieldstag">תשובה:</h2>
           <input type="text" class="text-input" id="answer" name="answer" required>
           <div class="error" id="answerError"></div>
       </div>
       
       <div class="error" id="recoveryError" runat="server"></div>
       <div class="success" id="recoverySuccess" runat="server"></div>
       
       <button type="submit" id="submit">שחזר סיסמה</button>
       <button type="reset" id="reset">נקה</button>
   </form>

</body>
</asp:Content>