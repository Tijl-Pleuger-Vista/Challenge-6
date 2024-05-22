var theme = 0

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

function userLogoutOpen(){
    localStorage.removeItem("user-info");
    localStorage.removeItem("user-email");
    localStorage.removeItem("user-password");
    localStorage.removeItem("user-creds");
    window.location.href = '../index.html';
}