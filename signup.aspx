<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="solaris_final.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<style>body {font-family: "Rubik", sans-serif; color:white;}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<body class="registration-form">
    <h1 id="title">דף הרשמה</h1>
    <form novalidate>
        <div class="field-group">
            <h2 class="fieldstag">שם פרטי:</h2>
            <input type="text" class="text-input" id="firstName">
            <div class="error" id="firstNameError"></div>
            <style>.error {color: gold;}</style>
        </div>

        <div class="field-group">
            <h2 class="fieldstag">שם משפחה:</h2>
            <input type="text" class="text-input" id="lastName">
            <div class="error" id="lastNameError"></div>
        </div>
        
        <div class="field-group">
            <h2 class="fieldstag">עיר:</h2>
            <input type="text" class="text-input" id="city">
        </div>

        <div class="field-group">
            <h2 class="fieldstag">תאריך לידה:</h2>
            <input type="date" class="text-input" id="birthDate">
            <div class="error" id="birthDateError"></div>
        </div>
        <div class="field-group">
            <h2 class="fieldstag">אימייל:</h2>
            <input type="text" class="text-input" id="email">
            <div class="error" id="emailError"></div>
        </div>
        <div class="field-group">
            <h2 class="fieldstag">שם משתמש:</h2>
            <input type="text" class="text-input" id="username">
            <div class="error" id="usernameError" runat="server"></div>
        </div>

        <div class="field-group">
            <h2 class="fieldstag">סיסמה:</h2>
            <input type="password" class="text-input" id="password">
            <div class="error" id="passwordError"></div>
        </div>

        <div class="field-group">
            <h2 class="fieldstag">טלפון:</h2>
            <input type="text" class="text-input" id="phone">
            <div class="error" id="phoneError"></div>
        </div>

        <div class="field-group">
            <h2 class="fieldstag">מין:</h2>
            <div class="radio-group">
                <input type="radio" id="male" name="gender" value="male">
                <label for="male">גבר</label>
                <input type="radio" id="female" name="gender" value="female">
                <label for="female">אישה</label>
                <input type="radio" id="other" name="gender" value="other">
                <label for="other">אחר</label>
            </div>
            <div class="error" id="genderError"></div>
        </div>

        <div class="field-group">
            <h2 class="fieldstag">שאלת שחזור חשבון #1:</h2>
            <select id="question1">
                <option value="">בחר שאלה</option>
                <option value="מה היה השם של הכלב הראשון שלך?">מה היה השם של הכלב הראשון שלך?</option>
                <option value="איך קוראים לאבא שלך?">איך קוראים לאבא שלך?</option>
                <option value="מה הפרי האהוב עליך?">מה הפרי האהוב עליך?</option>
            </select>
            <div class="error" id="question1Error"></div>
        </div>

        <div class="field-group">
            <h2 class="fieldstag">תשובה:</h2>
            <input type="text" class="text-input" id="answer1">
            <div class="error" id="answer1Error"></div>
        </div>

        <div class="field-group">
            <h2 class="fieldstag">שאלת שחזור חשבון #2:</h2>
            <select id="question2">
                <option value="">בחר שאלה</option>
                <option value="באיזה בית ספר למדת?">באיזה בית ספר למדת?</option>
                <option value="מה השם של סבא שלך?">מה השם של סבא שלך?</option>
                <option value="האם אביתר המורה הכי טוב?">האם אביתר המורה הכי טוב?</option>
            </select>
            <div class="error" id="question2Error"></div>
        </div>

        <div class="field-group">
            <h2 class="fieldstag">תשובה:</h2>
            <input type="text" class="text-input" id="answer2">
            <div class="error" id="answer2Error"></div>
        </div>

        <button id="submit">שליחה</button>
        <button type="reset" id="reset">ניקוי</button>
    </form>
</body>
<script src="signup.js"></script>
</asp:Content>
