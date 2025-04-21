<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="solaris_final.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<style>body {font-family: "Rubik", sans-serif; color:white;}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
    <h1 id="title">דף כניסה</h1>
    <form class="registration-form" novalidate>
        <div class="field-group">
            <h2 class="fieldstag">שם משתמש:</h2>
            <input type="text" class="text-input" id="username" required>
            <div class="error" id="usernameError"></div>
        </div>

        <div class="field-group">
            <h2 class="fieldstag">סיסמה:</h2>
            <input type="password" class="text-input" id="password" required>
            <div class="error" id="passwordError"></div>
        </div>


        <button type="submit" id="submit">כניסה</button>
    </form>
    <script>
        document.getElementById('registerForm').addEventListener('submit', function(e) {
            e.preventDefault();
            let isValid = true;
            clearErrors();

            // Validate username
            const username = document.getElementById('username');
            if (!username.value.trim()) {
                showError('username', 'שדה חובה');
                isValid = false;
            } else if (!/^[a-zA-Z0-9_]{3,20}$/.test(username.value.trim())) {
                showError('username', 'שם משתמש חייב להכיל 3-20 תווים באנגלית, מספרים או _');
                isValid = false;
            }

            // Validate password
            const password = document.getElementById('password');
            if (!password.value) {
                showError('password', 'שדה חובה');
                isValid = false;
            } else if (!/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/.test(password.value)) {
                showError('password', 'סיסמה חייבת להכיל לפחות 8 תווים, אות אחת ומספר אחד');
                isValid = false;
            }
        });

        function showError(fieldId, message) {
            const errorDiv = document.getElementById(fieldId + 'Error');
            const field = document.getElementById(fieldId);
            if (errorDiv && field) {
                errorDiv.textContent = message;
                field.classList.add('input-error');
            }
        }

        function clearErrors() {
            const errorDivs = document.querySelectorAll('.error');
            const inputs = document.querySelectorAll('.text-input, select');
            
            errorDivs.forEach(div => div.textContent = '');
            inputs.forEach(input => input.classList.remove('input-error'));
        }

        // Real-time validation for password
        document.getElementById('password').addEventListener('input', function(e) {
            const password = e.target.value;
            if (password && !/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/.test(password)) {
                showError('password', 'סיסמה חייבת להכיל לפחות 8 תווים, אות אחת ומספר אחד');
            } else {
                clearErrors();
            }
        });
    </script>
</body>
</asp:Content>
