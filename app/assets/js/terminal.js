// document.onkeydown = checkKeycode;

// function checkKeycode(e) {
// var keycode;
// if (window.event) {
//     keycode = window.event.keyCode;
// }
// else if (e) keycode = e.which;

// var character = String.fromCharCode(keycode);
// var letterDiv = document.getElementById("letter1");
// letterDiv.innerHTML += character;
// }

// mew

// function onKeyPress(evt){
//     evt = (evt) ? evt : (window.event) ? event : null;
//     if (evt)
//     {
//       var charCode = (evt.charCode) ? evt.charCode :((evt.keyCode) ? evt.keyCode :((evt.which) ? evt.which : 0));
//       if (charCode == 13) 
//       letterDiv.innerHTML += charCode
//     }
//   }


// works
// document.addEventListener(
//     "keydown",
//     function(event) {
//       console.log(event.key);
//     },
//   );

window.addEventListener("keydown", function(event) {
    letter = event.key;
    // if(/[a-zA-Z]/.test(letter)) {
    //     // console.log(letter);
    //     log.innerHTML += letter

    // }

    if(letter == "a") {log.innerHTML += letter}
    if(letter == "b") {log.innerHTML += letter}
    if(letter == "c") {log.innerHTML += letter}
    if(letter == "d") {log.innerHTML += letter}
    if(letter == "e") {log.innerHTML += letter}
    if(letter == "f") {log.innerHTML += letter}
    if(letter == "g") {log.innerHTML += letter}
    if(letter == "h") {log.innerHTML += letter}
    if(letter == "i") {log.innerHTML += letter}
    if(letter == "j") {log.innerHTML += letter}
    if(letter == "k") {log.innerHTML += letter}
    if(letter == "l") {log.innerHTML += letter}
    if(letter == "m") {log.innerHTML += letter}
    if(letter == "n") {log.innerHTML += letter}
    if(letter == "o") {log.innerHTML += letter}
    if(letter == "p") {log.innerHTML += letter}
    if(letter == "q") {log.innerHTML += letter}
    if(letter == "r") {log.innerHTML += letter}
    if(letter == "s") {log.innerHTML += letter}
    if(letter == "t") {log.innerHTML += letter}
    if(letter == "u") {log.innerHTML += letter}
    if(letter == "v") {log.innerHTML += letter}
    if(letter == "w") {log.innerHTML += letter}
    if(letter == "x") {log.innerHTML += letter}
    if(letter == "y") {log.innerHTML += letter}
    if(letter == "z") {log.innerHTML += letter}


});