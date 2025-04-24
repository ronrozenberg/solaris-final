//הגדרת אלמנטים
var firstName = document.getElementById("firstName").value;
var lastName = document.getElementById("lastName").value;
var birthDate = document.getElementById("birthDate").value;
var username = document.getElementById("username").value;
var password = document.getElementById("password").value;
var phone = document.getElementById("phone").value;
var email = document.getElementById("email").value;
var city = document.getElementById("city").value;
//שאלות שחזור
var question1 = document.getElementById("question1").value;
var question2 = document.getElementById("question2").value;
var answer1 = document.getElementById("answer1").value;
var answer2 = document.getElementById("answer2").value;

//בדיקות regex עברית אנגלית
var english = /^[A-Za-z]*$/;
var hebrew = /^[\u0590-\u05fe]*$/;
//בודק אם מתחיל באות גדולה, ומכיל איזשהי אות אנגלית/מספר/תו מיוחד
var usernamecheck = /^[A-Z][!-~][^ ]*$/;
//בודק אם מכיל אות גדולה, מספר ותו מיוחד, האם אות חוקית והאם בין 6-12 תווים ואין 3 אותיות חוזרות
var passwordcheck = /^(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9\s])(?!.*(.)\1\1)[!-~]{6,12}$/;
// בדיקת מספר טלפון
var phonecheck = /^0[57]([\d]{0,1})([-]{0,1})\d{7}$/;
//בדיקת email
var emailcheck = /^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$/;

//עדכוני המשתנים לפי פעולות
document.getElementById("firstName").addEventListener("click", checkinputfname);
document.getElementById("firstName").addEventListener("input", checkinputfname);
document.getElementById("lastName").addEventListener("click", checkinputlname);
document.getElementById("lastName").addEventListener("input", checkinputlname);
document.getElementById("birthDate").addEventListener("click", checkinputbirthDate);
document.getElementById("birthDate").addEventListener("input", checkinputbirthDate);
document.getElementById("email").addEventListener("click", checkemail);
document.getElementById("email").addEventListener("input", checkemail);
document.getElementById("username").addEventListener("click", checkusername);
document.getElementById("username").addEventListener("input", checkusername);
document.getElementById("password").addEventListener("click", checkpassword);
document.getElementById("password").addEventListener("input", checkpassword);
document.getElementById("phone").addEventListener("click", checkphone);
document.getElementById("phone").addEventListener("input", checkphone);
document.getElementById("question1").addEventListener("input", checkquestion);
document.getElementById("question2").addEventListener("input", checkquestion);
document.getElementById("answer1").addEventListener("click", checkquestion);
document.getElementById("answer2").addEventListener("click", checkquestion);
document.getElementById("answer1").addEventListener("input", checkquestion);
document.getElementById("answer2").addEventListener("input", checkquestion);


//שם פרטי
function checkinputfname() {
    firstName = document.getElementById("firstName").value;
    if (firstName == "") {
        displayError("אנא הזן שם פרטי", "firstName");
    }
    if (firstName !== "") {
        if (english.test(firstName) == true) {
            if (firstName.length < 2 || firstName.length > 20) displayError("נא להזין שם בין 2-20 תווים", "firstName"); else displayError("", "firstName");
        } else if (hebrew.test(firstName) == true) {
            if (firstName.length < 2 || firstName.length > 20) displayError("נא להזין שם בין 2-20 תווים", "firstName"); else displayError("", "firstName");
        } else if (english.test(firstName) == false) displayError("נא להזין שם בעברית או באנגלית", "firstName");
    }
}

//שם משפחה
function checkinputlname() {
    lastName = document.getElementById("lastName").value;
    if (lastName == "") {
        displayError("אנא הזן שם משפחה", "lastName");
    }
    if (lastName !== "") {
        if (english.test(lastName) == true) {
            if (lastName.length < 2 || lastName.length > 20) displayError("נא להזין שם בין 2-20 תווים", "lastName"); else displayError("", "lastName");
        } else if (hebrew.test(lastName) == true) {
            if (lastName.length < 2 || lastName.length > 20) displayError("נא להזין שם בין 2-20 תווים", "lastName"); else displayError("", "lastName");
        } else if (english.test(lastName) == false) displayError("נא להזין שם בעברית או באנגלית", "lastName");
    }
}

//תאריך לידה
function checkinputbirthDate() {
    birthDate = document.getElementById("birthDate").value;
    if (!birthDate) {
        displayError("אנא הזן תאריך לידה", "birthDate");
    } else displayError("", "birthDate");
}

//אימייל
function checkemail() {
    email = document.getElementById("email").value;
    if (emailcheck.test(email) == true) {
        displayError("", "email");
    } else displayError("יש להזין אימייל תקני", "email")
}

//שם משתמש
function checkusername() {
    username = document.getElementById("username").value;
    if (usernamecheck.test(username) == true) {
        console.log(usernamecheck.test(username));
        displayError("", "username");
    } else displayError("על שם המשתמש להתחיל באות אנגלית גדולה, להיות לפחות 2 תווים ולהכיל אותיות אנגליות, סימנים ומספרים בלבד ללא רווחים.", "username");
}

//סיסמה
function checkpassword() {
    password = document.getElementById("password").value;
    if (passwordcheck.test(password) == true) {
        console.log(passwordcheck.test(password));
        displayError("", "password");
    } else displayError(" על הסיסמה להיות בין 6-12 תווים, להכיל אותיות אנגליות/מספרים/מיוחדים, אות גודלה וחובה אחד מכל אחד לפחות ולא להכיל את אותה אות 3 פעמים", "password");
}

//טלפון
function checkphone() {
    phone = document.getElementById("phone").value;
    if (phonecheck.test(phone) == true) {
        displayError("", "phone");
    } else displayError("מספר טלפון צריך להתחיל בקידומת 05 או 07 ולהכיל מקף אחרי הקידומת", "phone");
}

//האם לפחות אופציה אחת לחוצה במין
function checkgender() {
    if (!document.getElementById("male").checked && !document.getElementById("female").checked && !document.getElementById("other").checked) {
        displayError("יש להזין מין", "gender");
    } else displayError("", "gender");
}
//האם לפחות לשאלה אחת יש תשובה
function checkquestion() {
    question1 = document.getElementById("question1").value;
    question2 = document.getElementById("question2").value;
    answer1 = document.getElementById("answer1").value;
    answer2 = document.getElementById("answer2").value;
    pair1Complete = question1 !== "" && answer1 !== "";
    pair2Complete = question2 !== "" && answer2 !== "";

    if (!pair1Complete && !pair2Complete) {
        displayError("יש לבחור ולענות על לפחות שאלה אחת", "question1");
    }

    if (pair1Complete || pair2Complete) {
        displayError("", "question1");
        displayError("", "question2");
        displayError("", "answer1");
        displayError("", "answer2");
    }

    if (question1 !== "" && answer1 == "") {
        displayError("יש להזין תשובה לשאלה זו", "answer1");
    }

    if (question1 == "" && answer1 !== "") {
        displayError("יש לבחור שאלה", "question1");
    }

    if (question2 !== "" && answer2 == "") {
        displayError("יש להזין תשובה לשאלה זו", "answer2");
    }

    if (question2 == "" && answer2 !== "") {
        displayError("יש לבחור שאלה", "question2Error");
    }

}
//פונקציית הדפסת בעייה
function displayError(error, id) {
    check = id + "Error";
    console.log(document.getElementById(check).innerHTML);
    document.getElementById(check).innerHTML = error;
}
