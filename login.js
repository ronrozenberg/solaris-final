
document.getElementById("userName").addEventListener("click", checkusername);
document.getElementById("userName").addEventListener("input", checkusername);
document.getElementById("password").addEventListener("click", checkpassword);
document.getElementById("password").addEventListener("input", checkpassword);
//בודק אם מתחיל באות גדולה, ומכיל איזשהי אות אנגלית/מספר/תו מיוחד
var usernamecheck = /^[A-Z][!-~][^ ]*$/;
//בודק אם מכיל אות גדולה, מספר ותו מיוחד, האם אות חוקית והאם בין 6-12 תווים ואין 3 אותיות חוזרות
var passwordcheck = /^(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9\s])(?!.*(.)\1\1)[!-~]{6,12}$/;

//פונקציית הדפסת בעייה
function displayError(error, id) {
    check = id + "Error";
    console.log(document.getElementById(check).innerHTML);
    document.getElementById(check).innerHTML = error;
}

//שם משתמש
function checkusername() {
    var username = document.getElementById("userName").value;
    if (usernamecheck.test(username) == true) {
        console.log(usernamecheck.test(username));
        displayError("", "userName");
    } else displayError("על שם המשתמש להתחיל באות אנגלית גדולה, להיות לפחות 2 תווים ולהכיל אותיות אנגליות, סימנים ומספרים בלבד ללא רווחים.", "userName");
}

//סיסמה
function checkpassword() {
    password = document.getElementById("password").value;
    if (passwordcheck.test(password) == true) {
        console.log(passwordcheck.test(password));
        displayError("", "password");
    } else displayError(" על הסיסמה להיות בין 6-12 תווים, להכיל אותיות אנגליות/מספרים/מיוחדים, אות גודלה וחובה אחד מכל אחד לפחות ולא להכיל את אותה אות 3 פעמים", "password");
}