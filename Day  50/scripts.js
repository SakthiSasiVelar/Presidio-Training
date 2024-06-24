let currentPage = 1;
const quotesPerPage = 5;

document.addEventListener('DOMContentLoaded', () => {
    fetchQuotes();
    document.getElementById('prev-page').addEventListener('click', () => changePage(-1));
    document.getElementById('next-page').addEventListener('click', () => changePage(1));
});

var quotes;

function fetchQuotes() {
    fetch('https://dummyjson.com/quotes')
        .then(response => response.json())
        .then(data => {
            quotes = data.quotes;
            displayQuotes(quotes)
})
        .catch(error => console.error('Error fetching quotes:', error));
}

function displayQuotes(quotes) {
    const quotesContainer = document.getElementById('quotes-container');
    quotesContainer.innerHTML = '';

    const start = (currentPage - 1) * quotesPerPage;
    const end = start + quotesPerPage;
    const paginatedQuotes = quotes.slice(start, end);

    paginatedQuotes.forEach(quote => {
        const quoteElement = document.createElement('div');
        quoteElement.classList.add('quote');
        quoteElement.innerHTML = `<p>${quote.quote}</p><p><strong>- ${quote.author}</strong></p>`;
        quotesContainer.appendChild(quoteElement);
    });

    document.getElementById('prev-page').disabled = currentPage === 1;
    document.getElementById('next-page').disabled = end >= quotes.length;
}

function changePage(direction) {
    currentPage += direction;
    displayQuotes(quotes);
}


document.getElementById('search-input').addEventListener('input',()=>{
    if(document.getElementById('search-input').value === '') {
       fetchQuotes();
    }
})

document.getElementById('sort-select').addEventListener('change',()=>{
    sortQuotes();
})

function sortQuotes(){
    const sortOption = document.getElementById('sort-select').value;
    if (sortOption === 'atoz') {
        quotes.sort((a, b) => a.author.localeCompare(b.author));
    } else if (sortOption === 'ztoa') {
        quotes.sort((a, b) => b.author.localeCompare(a.author));
    }
    displayQuotes(quotes);
}

function search(){
    let searchValue = document.getElementById('search-input').value;
    fetch('https://dummyjson.com/quotes')
        .then(response => response.json())
        .then(data => {           
            let filteredQuotes = data.quotes.filter(quote => quote.author.toLowerCase() === searchValue.toLowerCase());
            quotes = filteredQuotes;
            displayQuotes(filteredQuotes);
        })
        .catch(err => console.error(err))
}