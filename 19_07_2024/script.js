
const words = ["example", "spelling", "javascript", "function", "programming"];
let currentWord = "";

function getRandomWord() {
    const randomIndex = Math.floor(Math.random() * words.length);
    return words[randomIndex];
}

function startGame() {
    currentWord = getRandomWord();
    document.getElementById("word-to-spell").innerText = currentWord;
}

function checkSpelling() {
    const userInput = document.getElementById("user-input").value;
    const resultMessage = document.getElementById("result-message");
    
    if (userInput === currentWord) {
        resultMessage.innerText = "Correct!";
        resultMessage.style.color = "green";
    } else {
        resultMessage.innerText = `Incorrect! The correct spelling is "${currentWord}".`;
        resultMessage.style.color = "red";
    }
    
    // Start a new game after 2 seconds
    setTimeout(() => {
        document.getElementById("user-input").value = "";
        resultMessage.innerText = "";
        startGame();
    }, 2000);
}

document.getElementById("check-button").addEventListener("click", checkSpelling);

window.onload = startGame;
