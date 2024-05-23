localStorage.removeItem("json");

function caseCheck(check){
    switch (check) {
        case 0:
            var fetchJson = "https://raw.githubusercontent.com/Tijl-Pleuger-Vista/Challenge-6/main/static/json/en.json"
            wait(fetchJson)
        break;
        case 1:
            var fetchJson = "https://raw.githubusercontent.com/Tijl-Pleuger-Vista/Challenge-6/main/static/json/nl.json"
            wait(fetchJson)
        break;
        default:
    }
}

async function wait(fetchJson) {
    var checkJson = await fetch(fetchJson)
    var checkJson = await checkJson.json();
    localStorage.setItem("json", JSON.stringify(checkJson));
    window.location.href = "game.html";
}
