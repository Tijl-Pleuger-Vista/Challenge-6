// fetch(`https://api.my-ip.io/v2/ip.json	`)
// .then(userData => userData.json())
// .then(userData => {
// data.innerHTML +=
// `
// <p>Response. . . . . . . . . . . . . : ${userData.success}</p>
// <p>Address type. . . . . . . . . . . : ${userData.type}</p>
// <p>IPv4 Address. . . . . . . . . . . : ${userData.ip}</p>
// <br>
// <p>User Location</p>
// <p>User time zone. . . . . . . . . . : ${userData.timeZone}</p>
// <p>User region . . . . . . . . . . . : ${userData.region}</p>
// <p>User city . . . . . . . . . . . . : ${userData.city}</p>
// <p>Country code. . . . . . . . . . . : ${userData.country.code}</p>
// <p>Country name. . . . . . . . . . . : ${userData.country.name}</p>
// <br>
// <p>User location . . . . . . . . . . : ${userData.location.lat} - ${userData.location.lon}</p>
// <br>
// <p>User autonomous system number (ASN)</p>
// <p>Name. . . . . . . . . . . . . . . : ${userData.asn.name}</p>
// <p>Number. . . . . . . . . . . . . . : ${userData.asn.number}</p>
// <p>Network . . . . . . . . . . . . . : ${userData.asn.network}</p>
// `
// })

window.addEventListener("keydown", function(event) {
    letter = event.key;

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

    // if(letter == "A") {log.innerHTML += letter}
    // if(letter == "B") {log.innerHTML += letter}
    // if(letter == "C") {log.innerHTML += letter}
    // if(letter == "D") {log.innerHTML += letter}
    // if(letter == "E") {log.innerHTML += letter}
    // if(letter == "F") {log.innerHTML += letter}
    // if(letter == "G") {log.innerHTML += letter}
    // if(letter == "H") {log.innerHTML += letter}
    // if(letter == "I") {log.innerHTML += letter}
    // if(letter == "J") {log.innerHTML += letter}
    // if(letter == "K") {log.innerHTML += letter}
    // if(letter == "L") {log.innerHTML += letter}
    // if(letter == "M") {log.innerHTML += letter}
    // if(letter == "N") {log.innerHTML += letter}
    // if(letter == "O") {log.innerHTML += letter}
    // if(letter == "P") {log.innerHTML += letter}
    // if(letter == "Q") {log.innerHTML += letter}
    // if(letter == "R") {log.innerHTML += letter}
    // if(letter == "S") {log.innerHTML += letter}
    // if(letter == "T") {log.innerHTML += letter}
    // if(letter == "U") {log.innerHTML += letter}
    // if(letter == "V") {log.innerHTML += letter}
    // if(letter == "W") {log.innerHTML += letter}
    // if(letter == "X") {log.innerHTML += letter}
    // if(letter == "Y") {log.innerHTML += letter}
    // if(letter == "Z") {log.innerHTML += letter}
    
    if(letter == "Backspace") {
        var backspace=document.getElementById("log").innerText;
        backspace = backspace.substring(0, backspace.length - 1);
        log.innerHTML = backspace;
    }

    if(letter == "Enter") {
        const search = document.getElementById("log").innerText;
        searchTerminal(search)
        const box = document.getElementById('log');
        const el = document.querySelector('.underscore');
        el.classList.replace("underscore","blank");
        box.setAttribute('id', 'logged');
        terminal.innerHTML +=
        `
        <div class="row">
        <p style="margin-right: 8px;">PS C:/Users/admin></p><p class="code" id="log"></p><p class="underscore">_</p>
        </div>
        `
    }

});

function searchTerminal (_search){
    let searchLength = _search.length;
    if(_search == "meow") {terminal.innerHTML += 
        `
        <br><p> I am not a cat</p><br>
        `
    }
    else if(_search == "log") {terminal.innerHTML += 
        `
        <br><p> put the userData response here</p><br>
        `
    }
    else if(_search == "download") {terminal.innerHTML += 
        `
        <br><p> download stuff</p><br>
        `
    }
    else if(_search == "ip") {terminal.innerHTML += 
        `
        <br><p> put the userData response here</p><br>
        `
    }
    else if(_search == "contact") {terminal.innerHTML += 
        `
        <br><p> put the userData response here</p><br>
        `
    }
    else if(_search == "cookies") {terminal.innerHTML += 
        `
        <br><p> put the userData response here</p><br>
        `
    }
    else if(_search == "tos") {terminal.innerHTML += 
        `
        <br><p> terms and conditions</p><br>
        `
    }
    else if(_search == "faq") {terminal.innerHTML += 
        `
        <br><p> terms and conditions</p><br>
        `
    }
    else if(_search == "romy") {terminal.innerHTML += 
        `
        <br>
        <p>██████╗░░█████╗░███╗░░░███╗██╗░░░██╗</p>
        <p>██╔══██╗██╔══██╗████╗░████║╚██╗░██╔╝</p>
        <p>██████╔╝██║░░██║██╔████╔██║░╚████╔╝░</p>
        <p>██╔══██╗██║░░██║██║╚██╔╝██║░░╚██╔╝░░</p>
        <p>██║░░██║╚█████╔╝██║░╚═╝░██║░░░██║░░░</p>
        <p>╚═╝░░╚═╝░╚════╝░╚═╝░░░░░╚═╝░░░╚═╝░░░</p>
        <br>
        <p>credit: tester</p>
        <br>
        `
    }
    else if(_search == "j") {terminal.innerHTML += 
        `
        <br>
        <p>░░█ █▀▀ █▀▀ █░█ ▄█ ░ █▀█</p>
        <p>█▄█ ██▄ ██▄ ▀▄▀ ░█ ▄ █▄█</p>
        <br>
        <p>credit: application</p>
        <br>
        `
    }
    else if(_search == "headbodyscript") {terminal.innerHTML += 
        `
        <br><br><p style="font-family: Dimitra;">HeadBodyScript</p><br>
        <p>credit: website</p>
        <br>
        `
    }
    else if(_search == "him") {terminal.innerHTML += 
        `
        <br>
        <p>██╗░░██╗██╗░░██╗██╗░░██╗██╗░░██╗░░██╗██╗██████╗░░█████╗░
        <p>╚██╗██╔╝╚██╗██╔╝╚██╗██╔╝╚██╗██╔╝░██╔╝██║╚════██╗██╔══██╗
        <p>░╚███╔╝░░╚███╔╝░░╚███╔╝░░╚███╔╝░██╔╝░██║░░███╔═╝██║░░██║
        <p>░██╔██╗░░██╔██╗░░██╔██╗░░██╔██╗░███████║██╔══╝░░██║░░██║
        <p>██╔╝╚██╗██╔╝╚██╗██╔╝╚██╗██╔╝╚██╗╚════██║███████╗╚█████╔╝
        <p>╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝░░░░░╚═╝╚══════╝░╚════╝░
        <br>
        <p>██████╗░██╗░░░░░░░██╗██╗███████╗███████╗██╗████████╗██╗░░██╗██╗░░██╗██╗░░██╗██╗░░██╗
        <p>██╔══██╗██║░░░░░░██╔╝██║╚════██║██╔════╝██║╚══██╔══╝╚██╗██╔╝╚██╗██╔╝╚██╗██╔╝╚██╗██╔╝
        <p>██████╦╝██║░░░░░██╔╝░██║░░███╔═╝█████╗░░██║░░░██║░░░░╚███╔╝░░╚███╔╝░░╚███╔╝░░╚███╔╝░
        <p>██╔══██╗██║░░░░░███████║██╔══╝░░██╔══╝░░██║░░░██║░░░░██╔██╗░░██╔██╗░░██╔██╗░░██╔██╗░
        <p>██████╦╝███████╗╚════██║███████╗███████╗██║░░░██║░░░██╔╝╚██╗██╔╝╚██╗██╔╝╚██╗██╔╝╚██╗
        <p>╚═════╝░╚══════╝░░░░░╚═╝╚══════╝╚══════╝╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝
        <br>
        <p>credit: security</p>
        <br>
        `
    }
    else if(_search == "tempo") {terminal.innerHTML += 
        `
        <br><br><p style="font-family: Dimitra;">user2</p><br>
        <p>credit: N/A</p>
        <br>
        `
    }
    else if(_search == "website") {terminal.innerHTML += 
        `
        <br><a href="https://aka.ms/PSWindows">>> Click here if you didn't get redirected www.Website.nl <i class="bi bi-box-arrow-up-right"></i></a><br><br>
        `
        window.open("https://www.w3schools.com")
    }
    else if(_search == "help") {terminal.innerHTML += 
        `
        <br><p>all commands: help, download, meow, ip, log, contact, website, headbodyscript, romy, j</p><br>
        `
    }
    else if (searchLength > 0) {
        terminal.innerHTML += 
        `
        <p class="error">${_search} : The term '${_search}' is not recognized as the name of a cmdlet, function, script file, or operable program. Check the</p>
        <p class="error">spelling of the name, or if a path was included, verify that the path is correct and try again.</p>
        <p class="error">At line:1 char:1</p>
        <p class="error">+ ${_search}</p>
        <p class="error">+ ~~</p>
        <p class="error">    + CategoryInfo          : ObjectNotFound: (${_search}:String) [], CommandNotFoundException</p>
        <p class="error">    + FullyQualifiedErrorId : CommandNotFoundException</p>
        <br>
        `
    }
}
