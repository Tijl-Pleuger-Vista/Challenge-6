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

// function btnScroll(classId){
//     var currentActive = document.getElementsByClassName("active-true");
//     currentActive[0].classList.replace("active-true", "active-false");
//     console.log(classId)
//     document.getElementById(classId).classList.add("visible")
//     classId.classList.replace("active-false", "active-true")
// }

function btnScroll(classId) {
    _classId = "section" + classId;
    document.querySelectorAll(".active-true").forEach(_classId=>{
        _classId.classList.replace("active-true", "active-false")
    });
    document.getElementById(_classId).classList.replace("active-false", "active-true");
}























// fetch('https://raw.githubusercontent.com/Tijl-Pleuger-Vista/project-6/main/app/assets/json/test.json')
//     .then((response) => response.json())
//     .then((json) => {
//         box.innerHTML +=
//                 `
//                 <ul>
//                     <strong>Title</strong>
//                     <li>${json.category_subcategory[0].title}</li>

//                     <li>${json.category_subcategory[0].examples}</li>
//                     <li>${json.category_subcategory[0].level}</li>
//                     <li>${json.category_subcategory[0].problem}</li>

//                     <li>${json.category_subcategory[0].resources}</li>
//                     <li>${json.category_subcategory[0].risk}</li>
//                     <li>${json.category_subcategory[0].solution}</li>

//                     <li>${json.category_subcategory[0].summary}</li>
//                     <li>${json.category_subcategory[0].xp}</li>
//                 </ul
                
//                 `
//         console.log(json)
//     });
