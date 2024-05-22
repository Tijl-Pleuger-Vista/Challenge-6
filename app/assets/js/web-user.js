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
// import { getAnalytics } from "https://www.gstatic.com/firebasejs/10.8.1/firebase-analytics.js";

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
// const analytics = getAnalytics(app);
const db = getDatabase();
const auth = getAuth(app);
const dbref = ref(db);

window.addEventListener("load", checkUserReconnect);

function checkUserReconnect(){
    if(localStorage.getItem("user-creds")){
        let userCreds = JSON.parse(localStorage.getItem("user-creds"));
        let userPass = (localStorage.getItem("user-password"));
        checkUserReconnectLogin(auth, userCreds, userPass)
    }
    else{
        userLogoutOpen();
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
}