let countExperience = 0;
let experience = 0
let level = 0



var root = document.querySelector(':root');
root.style.setProperty('--experience', 471);

let checkJson = JSON.parse(localStorage.getItem("json"));

let checkData = JSON.parse(localStorage.getItem("data"));

var amount = checkData.amount
var total = checkData.total
console.log(checkData)
var amount = amount * 10
var total = total * 10

var calcpre = 100 - ((100 * amount) / total);
var calc = Math.round(calcpre)
document.getElementById("meow").innerHTML = `<a href="${checkJson.init.href}">Click here to learn more</a>`

var userExperience = 471 - calc - calc
root.style.setProperty('--experience', userExperience);

displayExperience.innerHTML = calc + "%";
document.getElementById('perc').style.width = calc + "%"
// setInterval(() => {
//     if(countExperience == calc){
//         clearInterval();
//     }else{
//         countExperience += 1;
//         displayExperience.innerHTML = countExperience + "%"; 
//     }
// },20 );

if (calc <= 40) {
    document.getElementById("performance").innerHTML = `<div class="weak">Weak</div>`
} else if (calc <= 70){
    document.getElementById("performance").innerHTML = `<div class="strong">Strong</div>`
} else if (calc <= 100){
    document.getElementById("performance").innerHTML = `<div class="very-strong">Very strong</div>`
}
