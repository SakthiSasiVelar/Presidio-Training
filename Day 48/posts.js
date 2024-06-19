async function getPosts(){
    const response = await fetch('https://fakestoreapi.com/products');
    const data = await response.json();

     document.getElementsByClassName('data-container')[0].style.display = 'flex';

    data.forEach((item) => {     
        const card = document.createElement('div');
        const title = document.createElement('h2');
            title.id = 'title';
            title.textContent = item.title;

            const img = document.createElement('img');
            img.id = 'image';
            img.src = item.image;
            img.alt = item.title;

            const price = document.createElement('h4');
            price.id = 'price';
            price.textContent = 'Price : ' + item.price;

            card.appendChild(title);
            card.appendChild(img);
            card.appendChild(price);

            card.style.display = 'flex';
            card.style.flexDirection = 'column';
            card.style.gap = '1rem';
            card.style.border = '1px solid black';
            card.style.padding = '1rem';
            card.style.alignItems = 'center';
            card.style.flexBasis = '400px';
            card.style.flexGrow = '1';


        document.getElementsByClassName('data-container')[0].appendChild(card);
    });
}


async function hidePosts(){
     document.getElementsByClassName('data-container')[0].style.display = 'none';
}


