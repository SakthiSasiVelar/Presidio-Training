document.getElementById('product-form').addEventListener('submit', (e) =>{
    console.log(new FormData(e.target).get('id'));
    e.preventDefault();

    const id = document.getElementById('id').value;
    const name = document.getElementById('name').value;
    const price = document.getElementById('price').value;
    const quantity = document.getElementById('quantity').value;


    if(isValid(id , name , price , quantity)){
        const table = document.getElementById('product-table').getElementsByTagName('tbody')[0];
        const newRow = table.insertRow();
        const cell1 = newRow.insertCell(0);
        const cell2 = newRow.insertCell(1);
        const cell3 = newRow.insertCell(2);
        const cell4 = newRow.insertCell(3);
        cell1.innerHTML = id;
        cell2.innerHTML = name;
        cell3.innerHTML = '$'+price;
        cell4.innerHTML = quantity;
        document.getElementById('product-form').reset();
    }   
});

function isValid(id , name , price , quantity){
   if(id === ""){
      const input = document.getElementById('id');
      input.style.border = '1px solid red';
      input.style.outline = '1px solid red'; 
      const errorContainer = document.getElementById('error-container');
      errorContainer.innerHTML = "Please enter an id";
      errorContainer.style.color = 'red';
      return false;
   }
   return true;

}


document.getElementById('id').addEventListener('input' , ()=> {
     if(document.getElementById('id').value !== ""){
         const errorContainer = document.getElementById('error-container');
         errorContainer.innerHTML = "";
         const input = document.getElementById('id');
         input.style.border = '1px solid lightgreen';
         input.style.outline = '1px solid lightgreen'; 
     }else{
        const input = document.getElementById('id');
        input.style.border =  'none';
         input.style.outline = '1px solid black'; 
     }

})