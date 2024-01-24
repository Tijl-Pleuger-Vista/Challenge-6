function btnTheme(){
    document.querySelectorAll("#theme").forEach(theme => {
        _theme = theme.classList.value
        console.log(_theme)
        if (_theme == "moon") {
            theme.classList.replace("moon", "sun")
        }
        else if (_theme == "sun") {
            theme.classList.replace("sun", "moon")
        }
    })
}

fetch('https://raw.githubusercontent.com/Tijl-Pleuger-Vista/project-6/main/app/assets/json/test.json')
    .then((response) => response.json())
    .then((json) => {
        box.innerHTML +=
                `
                <ul>
                    <li>${json.category_subcategory[0].examples}</li>
                    <li>${json.category_subcategory[0].level}</li>
                    <li>${json.category_subcategory[0].problem}</li>

                    <li>${json.category_subcategory[0].resources}</li>
                    <li>${json.category_subcategory[0].risk}</li>
                    <li>${json.category_subcategory[0].solution}</li>

                    <li>${json.category_subcategory[0].summary}</li>
                    <li>${json.category_subcategory[0].title}</li>
                    <li>${json.category_subcategory[0].xp}</li>
                </ul
                
                `
        console.log(json)
    });
