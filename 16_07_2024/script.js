const targetWord = "apple"; 
let currentRow = 0;

function createBoard() {
    const board = document.getElementById('board');
    for (let i = 0; i < 6; i++) { 
        for (let j = 0; j < 5; j++) { 
            const cell = document.createElement('div');
            cell.classList.add('cell');
            cell.setAttribute('id', `cell-${i}-${j}`);
            board.appendChild(cell);
        }
    }
}

function submitGuess() {
    const guessInput = document.getElementById('guess-input');
    const guess = guessInput.value.toLowerCase();
    if (guess.length !== 5) {
        showMessage("Guess must be a 5-letter word!");
        return;
    }

    for (let i = 0; i < 5; i++) {
        const cell = document.getElementById(`cell-${currentRow}-${i}`);
        cell.textContent = guess[i];

        if (guess[i] === targetWord[i]) {
            cell.classList.add('correct');
        } else if (targetWord.includes(guess[i])) {
            cell.classList.add('present');
        } else {
            cell.classList.add('absent');
        }
    }

    currentRow++;
    guessInput.value = '';

    if (guess === targetWord) {
        showMessage("Congratulations! You guessed the word!");
    } else if (currentRow === 6) {
        showMessage(`Game Over! The word was ${targetWord}.`);
    }
}

function showMessage(message) {
    const messageElement = document.getElementById('message');
    messageElement.textContent = message;
}

window.onload = () => {
    createBoard();
};
