var firstName = document.getElementById("firstName").value;
var lastName = document.getElementById("lastName").value;
var birthDate = document.getElementById("birthDate").value;
var username = document.getElementById("username").value;
var password = document.getElementById("password").value;
var phone = document.getElementById("phone").value;
var email = document.getElementById("email").value;
var city = document.getElementById("city").value;
var question1 = document.getElementById("question1").value;
var question2 = document.getElementById("question2").value;
var answer1 = document.getElementById("answer1").value;
var answer2 = document.getElementById("answer2").value;

var english = /^[A-Za-z]*$/;
var hebrew = /^[\u0590-\u05fe]*$/;
var usernamecheck = /^[A-Z][!-~][^ ]*$/;
var passwordcheck = /^(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9\s])(?!.*(.)\1\1)[!-~]{6,12}$/;
var phonecheck = /^0[57]([\d]{0,1})([-]{0,1})\d{7}$/;
var emailcheck = /^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$/;

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
document.getElementById("submit").addEventListener("mouseover", check);


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

function checkinputbirthDate() {
    birthDate = document.getElementById("birthDate").value;
    if (!birthDate) {
        displayError("אנא הזן תאריך לידה", "birthDate");
    } else displayError("", "birthDate");
}

function checkemail() {
    email = document.getElementById("email").value;
    if (emailcheck.test(email) == true) {
        displayError("", "email");
    } else displayError("יש להזין אימייל תקני", "email")
}

function checkusername() {
    username = document.getElementById("username").value;
    if (usernamecheck.test(username) == true) {
        console.log(usernamecheck.test(username));
        displayError("", "username");
    } else displayError("על שם המשתמש להתחיל באות אנגלית גדולה, להיות לפחות 2 תווים ולהכיל אותיות אנגליות, סימנים ומספרים בלבד ללא רווחים.", "username");
}

function checkpassword() {
    password = document.getElementById("password").value;
    if (passwordcheck.test(password) == true) {
        console.log(passwordcheck.test(password));
        displayError("", "password");
    } else displayError(" על הסיסמה להיות בין 6-12 תווים, להכיל אותיות אנגליות/מספרים/מיוחדים, אות גודלה וחובה אחד מכל אחד לפחות ולא להכיל את אותה אות 3 פעמים", "password");
}

function checkphone() {
    phone = document.getElementById("phone").value;
    if (phonecheck.test(phone) == true) {
        displayError("", "phone");
    } else displayError("מספר טלפון צריך להתחיל בקידומת 05 או 07 ולהכיל מקף אחרי הקידומת", "phone");
}

function checkgender() {
    if (!document.getElementById("male").checked && !document.getElementById("female").checked && !document.getElementById("other").checked) {
        displayError("יש להזין מין", "gender");
    } else displayError("", "gender");
}
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

function validateAll() {
    checkinputfname();
    checkinputlname();
    checkinputbirthDate();
    checkemail();
    checkusername();
    checkpassword();
    checkphone();
    checkquestion();

    var hasnoErrors = true;
    var errorElements = document.querySelectorAll('div.error');
    console.log(errorElements);
    for (var i = 0; i < errorElements.length; i++) {
        if (errorElements[i].innerHTML !== '') {
            hasnoErrors = false;
            console.log(errorElements[i].innerHTML);
        }
    } 
    console.log("hasnoErrors: " + hasnoErrors);
    return hasnoErrors;   
}
function displayError(error, id) {
    check = id + "Error";
    document.getElementById(check).innerHTML = error;
}
