var amount = window.innerHeight;
var theme = 0
function btnScroll (x){
    _amount = x * amount
    window.scrollTo({top: _amount, left: 0});
    if (x === 0){document.title = "Home - Leet handbook";}
    if (x === 1){document.title = "About Us - Leet handbook";}
    if (x === 2){document.title = "Handbook - Leet handbook";}
    if (x === 3){document.title = "Download - Leet handbook";}

}

function copyPhone(){
    navigator.clipboard.writeText ("045 523 2576"); 
}
function btnTheme(){
    var r = document.querySelector(':root');

    theme++
    if(theme === 1){
        r.style.setProperty('--filter', "rgba(46, 46, 46, 0.15)");
    }
    if(theme === 2){
        r.style.setProperty('--filter', "rgba(46, 46, 46, 0.25)");

    }
    if(theme === 3){
        r.style.setProperty('--filter', "rgba(46, 46, 46, 0.45)");
        r.style.setProperty('--txt', "#ffffff");

    }
    if(theme === 4){
        r.style.setProperty('--filter', "rgba(46, 46, 46, 0.65)");
    }
    if(theme === 5){
        theme = 0
        r.style.setProperty('--filter', "rgba(46, 46, 46, 0)");
        r.style.setProperty('--txt', "#000000");
    }
}


function userLoginOpen(){
    var r = document.querySelector('.login');
    r.style.setProperty('display', "flex");
    r.style.setProperty('visibility', "visible");

    document.getElementById('form-register').classList.add('not-visible');
    document.getElementById('form-register').classList.remove('visible');

    document.getElementById('form-login').classList.add('visible');
    document.getElementById('form-login').classList.remove('not-visible');
}
function userLoginClose(){
    var r = document.querySelector('.login');
    r.style.setProperty('display', "none");
    r.style.setProperty('visibility', "hidden");
}

function userLogoutOpen(){
    localStorage.removeItem("user-info");
    localStorage.removeItem("user-email");
    localStorage.removeItem("user-password");
    localStorage.removeItem("user-creds");
    // location.reload();
}

function openHandbook(){
    if(localStorage.getItem("user-creds")){
        window.location.href = 'handbook.html';
    }
    else{
        userLoginOpen()
    }
}

function divRegister(){
    document.getElementById('form-login').classList.add('not-visible');
    document.getElementById('form-login').classList.remove('visible');

    document.getElementById('form-register').classList.add('visible');
    document.getElementById('form-register').classList.remove('not-visible');
}
function divLogin(){
    document.getElementById('form-register').classList.add('not-visible');
    document.getElementById('form-register').classList.remove('visible');

    document.getElementById('form-login').classList.add('visible');
    document.getElementById('form-login').classList.remove('not-visible');
}
