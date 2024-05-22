import { player, antagonist } from './Fighter.js'
import { background } from './Sprite.js';

let gameScope = () => {
        const canvas = document.querySelector('canvas');
        const c = canvas.getContext('2d');
        const init = document.getElementById('init');
        const btn0 = document.getElementById('displayButtonAplha');
        const btn1 = document.getElementById('displayButtonBeta');
        const btn2 = document.getElementById('displayButtonCharlie');
        const btn3 = document.getElementById('displayButtonDelta');
        const flex = document.getElementById('flex');

        var displayQuestion = document.getElementById('question');
        var i = -1
        var amount = 0 
        var root = document.querySelector(':root');

        let checkJson = JSON.parse(localStorage.getItem("json"));

        document.getElementById("displayTitle").innerHTML = checkJson.init.title;
        document.getElementById("displayStart").innerHTML = checkJson.init.start;
        document.getElementById("displayAuthor").innerHTML = checkJson.init.author;
        document.getElementById("displayPlayerName").innerHTML = checkJson.init.player;
        document.getElementById("displayAntagonistName").innerHTML = checkJson.init.antagonist;
        document.getElementById("displayDescription").innerHTML = checkJson.init.description;

        document.title = checkJson.init.name
        var skip = checkJson.init.skip

        root.style.setProperty('--player-min', `${checkJson.colors.player.min}`);
        root.style.setProperty('--player-max', `${checkJson.colors.player.max}`);
        root.style.setProperty('--antagonist-min', `${checkJson.colors.antagonist.min}`);
        root.style.setProperty('--antagonist-max', `${checkJson.colors.antagonist.max}`);

    function startGame() {
        document.getElementById('menu').style.display = "none";
        c.fillRect(0, 0, canvas.width, canvas.height);
        setTimeout(() => {
            animate();
            document.getElementById('hud').style.display = "flex";
        }, 10)
    }

    function nextQuestion(checkJson){
        var length = checkJson.questions.length
        var length = length - 1
        i++
            if (length < i){

                const jsonData = { 
                    "amount": amount, 
                    "total": checkJson.questions.length,
                  };

                  localStorage.setItem("data", JSON.stringify(jsonData));
                    window.location.href = "post-game.html";

            }
            if (i < checkJson.questions.length){
                displayQuestion.innerHTML =  checkJson.questions[i].question
                var buttonLength = checkJson.questions[i].button.length

                btn0.classList.remove("active");
                btn1.classList.remove("active");
                btn2.classList.remove("active");
                btn3.classList.remove("active");
                flex.classList.remove("flex-1");
                flex.classList.remove("flex-2");
                flex.classList.remove("flex-3");
                flex.classList.remove("flex-4");

                switch (buttonLength) {
                    case 1:

                        btn0.classList.add("active");
                        flex.classList.add("flex-1");

                        btn0.innerHTML = checkJson.questions[i].button[0].text
                    break;
                    case 2:

                        btn0.classList.add("active");
                        btn1.classList.add("active");
                        flex.classList.add("flex-2");

                        btn0.innerHTML = checkJson.questions[i].button[0].text
                        btn1.innerHTML = checkJson.questions[i].button[1].text
                    break;
                    case 3:

                        btn0.classList.add("active");
                        btn1.classList.add("active");
                        btn2.classList.add("active");
                        flex.classList.add("flex-3");

                        btn0.innerHTML = checkJson.questions[i].button[0].text
                        btn1.innerHTML = checkJson.questions[i].button[1].text
                        btn2.innerHTML = checkJson.questions[i].button[2].text
                    break;
                    case 4:

                        btn0.classList.add("active");
                        btn1.classList.add("active");
                        btn2.classList.add("active");
                        btn3.classList.add("active");
                        flex.classList.add("flex-4");

                        btn0.innerHTML = checkJson.questions[i].button[0].text
                        btn1.innerHTML = checkJson.questions[i].button[1].text
                        btn2.innerHTML = checkJson.questions[i].button[2].text
                        btn3.innerHTML = checkJson.questions[i].button[3].text
                    break;
                }
            } 
        }

    function animate() {
        window.requestAnimationFrame(animate);
        background.update();
        update(player);
        update(antagonist);
        player.velocity.x = 0;
        antagonist.velocity.x = 0;
            if (!player.movement() && !player.isAttacking && !player.isTakingHit) {
                player.switchSprite('idle');
            }

            if (!antagonist.movement() && !antagonist.isAttacking && !antagonist.isTakingHit) {
                antagonist.switchSprite('idle')
            }
        player.attack(antagonist);
        antagonist.attack(player);
    }

    function update(fighter) {
        if (fighter.health > 0) {
            fighter.update();
        } else {
            fighter.animateFrames()
            fighter.draw();
        }
    }

    init.addEventListener("click", () => {
        document.getElementById('displayButtons').style.visibility = 'visible';
        startGame();
        nextQuestion(checkJson)
    });

    btn0.addEventListener("click", () => {answerCheck(0)});
    btn1.addEventListener("click", () => {answerCheck(1)});
    btn2.addEventListener("click", () => {answerCheck(2)});
    btn3.addEventListener("click", () => {answerCheck(3)});

    function answerCheck(check){

        var answer = checkJson.questions[i].answer

        if (answer == check){
            player.isAttacking = true;
            nextQuestion(checkJson)

        } else {
            antagonist.isAttacking = true;
            amount++
            if(skip == "true"){
                nextQuestion(checkJson) 
            }
        }
    }
}
gameScope();