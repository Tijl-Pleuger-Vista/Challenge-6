let displayExperience = document.getElementById("displayExperience");
let displayLevel = document.getElementById("displayLevel");

let displayLoginLogout = document.getElementById("displayLoginLogout");

let countExperience = 0;
let experience = 0
let level = 0

displayLevel.innerHTML = "lvl " + level;
displayExperience.innerHTML = countExperience + "%"; 

var root = document.querySelector(':root');
root.style.setProperty('--experience', 471);

import { initializeApp } from "https://www.gstatic.com/firebasejs/10.8.1/firebase-app.js";
import { getDatabase, set, ref, get, child } from "https://www.gstatic.com/firebasejs/10.8.1/firebase-database.js";
import { getAuth, createUserWithEmailAndPassword, signInWithEmailAndPassword } from "https://www.gstatic.com/firebasejs/10.8.1/firebase-auth.js";

const firebaseConfig = {
  apiKey: "AIzaSyCqm-YZF8LyrBd3t-pmtG6vzbtD7hpkPWg",
  authDomain: "vista-400927.firebaseapp.com",
  databaseURL: "https://vista-400927-default-rtdb.europe-west1.firebasedatabase.app",
  projectId: "vista-400927",
  storageBucket: "vista-400927.appspot.com",
  messagingSenderId: "958008839817",
  appId: "1:958008839817:web:d16140eaca542134128058",
  measurementId: "G-B448GJXJ9H"
};

const app = initializeApp(firebaseConfig);

const db = getDatabase();
const auth = getAuth(app);
const dbref = ref(db);

let usernameRegister = document.getElementById('usernameRegister');
let userEmailRegister = document.getElementById('emailRegister');
let userPasswordRegister = document.getElementById('passwordRegister');

let userEmailLogin = document.getElementById('emailLogin');
let userPasswordLogin = document.getElementById('passwordLogin');

let registerUser = evt => {
    evt.preventDefault();
    createUserWithEmailAndPassword(auth, userEmailRegister.value, userPasswordRegister.value)
    .then((credentials)=>{
        set(ref(db, 'UserAuthList/' + credentials.user.uid),{
            username: usernameRegister.value,
            exp: 0,
            level: 0,
        });
        localStorage.setItem("user-password", userPasswordRegister.value);
        localStorage.setItem("user-email", userEmailRegister.value);
        setTimeout(registerUserCompleted(auth, userEmailRegister.value, userPasswordRegister.value), 2000);
    })
    .catch((error)=>{

        console.log(error.code);
        console.log(error.message);
    })
}

let registerUserCompleted = evt => {
    signInWithEmailAndPassword(auth, userEmailRegister.value, userPasswordRegister.value)
    .then((credentials)=>{
        get(child(dbref, 'UserAuthList/' + credentials.user.uid)).then((snapshot)=>{
           if(snapshot.exists){
                localStorage.setItem("user-info", JSON.stringify({
                    username: snapshot.val().username,
                    exp: snapshot.val().exp,
                    level: snapshot.val().level
                }))
                localStorage.setItem("user-creds", JSON.stringify(credentials.user));
                loginUserCompleted()
           }
        })
        localStorage.setItem("user-password", userPasswordRegister.value)
    })
    .catch((error)=>{

        console.log(error.code);
        console.log(error.message);
    })
}

let loginUser = evt => {
    evt.preventDefault();
    signInWithEmailAndPassword(auth, userEmailLogin.value, userPasswordLogin.value)
    .then((credentials)=>{
        get(child(dbref, 'UserAuthList/' + credentials.user.uid)).then((snapshot)=>{
           if(snapshot.exists){
                localStorage.setItem("user-info", JSON.stringify({
                    username: snapshot.val().username,
                    exp: snapshot.val().exp,
                    level: snapshot.val().level
                }))
                localStorage.setItem("user-creds", JSON.stringify(credentials.user));
                loginUserCompleted()
           }
        })
        localStorage.setItem("user-password", userPasswordLogin.value)
    })
    .catch((error)=>{

        console.log(error.code);
        console.log(error.message);
    })
}

function loginUserCompleted(){
    let userCreds = JSON.parse(localStorage.getItem("user-creds"));
    let userInfo = JSON.parse(localStorage.getItem("user-info"));

    displayLevel.innerHTML = "lvl " + userInfo.level
    setInterval(() => {
        if(countExperience == userInfo.exp){
            clearInterval();
        }else{
            countExperience += 1;
            displayExperience.innerHTML = countExperience + "%"; 
        }
    },20 );
    displayLoginLogout.innerHTML = '<h2><button onclick="userLogoutOpen()">Logout</button></h2>'

    displayUsername.innerHTML = userInfo.username;
    var userExperience = 471 - userInfo.exp - userInfo.exp
    root.style.setProperty('--experience', userExperience);

    userLoginClose();
}

registerForm.addEventListener('submit', registerUser)
loginForm.addEventListener('submit', loginUser)
window.addEventListener("load", checkUserReconnect);

function checkUserReconnect(){
    if(localStorage.getItem("user-creds")){
        let userCreds = JSON.parse(localStorage.getItem("user-creds"));
        let userPass = (localStorage.getItem("user-password"));
        checkUserReconnectLogin(auth, userCreds, userPass)
    }
}

function checkUserReconnectLogin(auth, userCreds, userPass) {
    signInWithEmailAndPassword(auth, userCreds.email, userPass)
    .then((credentials)=>{
        get(child(dbref, 'UserAuthList/' + credentials.user.uid)).then((snapshot)=>{
           if(snapshot.exists){
                localStorage.setItem("user-info", JSON.stringify({
                    username: snapshot.val().username,
                    exp: snapshot.val().exp,
                    level: snapshot.val().level
                }))
                localStorage.setItem("user-creds", JSON.stringify(credentials.user));
                loginUserCompleted()
           }
        })
    })
    .catch((error)=>{

        console.log(error.code);
        console.log(error.message);
    })
}