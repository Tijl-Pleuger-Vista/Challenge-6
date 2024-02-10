var amount = window.innerHeight;
var theme = 0
function FuncScroll (x){
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
    theme++
    if(theme === 1){
        // 75
        document.querySelectorAll(".contrast-100").forEach(s => {
            s.classList.remove("contrast-100")
            s.classList.add("contrast-75")
            }
        )
    }
    if(theme === 2){
        // 50 
        document.querySelectorAll(".contrast-75").forEach(s => {
            s.classList.remove("contrast-75")
            s.classList.add("contrast-50")
            }
        )
        document.querySelectorAll(".light").forEach(s => {
            s.classList.remove("light")
            s.classList.add("dark")
            }
        )
    }
    if(theme === 3){
        // 25
        document.querySelectorAll(".contrast-50").forEach(s => {
            s.classList.remove("contrast-50")
            s.classList.add("contrast-25")
            }
        )
    }
    if(theme === 4){
        // reset
        document.querySelectorAll(".contrast-25").forEach(s => {
            s.classList.remove("contrast-25")
            s.classList.add("contrast-100")
            }
        )
        document.querySelectorAll(".dark").forEach(s => {
            s.classList.remove("dark")
            s.classList.add("light")
            }
        )
        theme = 0
    }
}