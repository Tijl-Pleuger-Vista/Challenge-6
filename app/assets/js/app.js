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

fetch('https://server.com/data.json')
    .then((response) => response.json())
    .then((json) => console.log(json));