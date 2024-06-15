
var professionCommonArray = ['Software Engineer', 'Teacher', 'Mechanic', 'Business', 'You tuber' ];
document.getElementById('form').addEventListener('submit', function (event)
{
    event.preventDefault();
    const form = document.getElementById('form');
    var formData = {
        name : form.elements['name'].value,
        email : form.elements['email'].value,
        phone : form.elements['phone-number'].value,
        dob : form.elements['dob'].value,
        age : form.elements['age'].value,
        gender: form.elements['gender'].value,
        qualification: [],
        profession: form.elements['profession'].value,
        otherProfession: form.elements['other-profession'].value
    }
    var checkboxes = form.querySelectorAll('input[name="qualification"]:checked');
    checkboxes.forEach(function(checkbox) {
        formData.qualification.push(checkbox.value);
    });
    if(validateFormData(formData)){
       alert('resigerted successfully');
       if(formData.otherProfession.length > 0){
        changeProfessionList();
       }
       console.log(formData);
       form.reset();
         const otherProfession = document.getElementById('other-profession');
         otherProfession.style.display = 'none';
    };
});

function getAge(){
    var today = new Date();
    var birthDate = new Date(document.getElementById('dob').value);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    document.getElementById('age').value = age;
}

function validateFormData(formData){
    var errorItems = [];
    var errors = [];
    const errorContainer = document.getElementById('error');
    if(formData.name.length == 0){
        errorItems.push('Name');
    }
    if(formData.email.length == 0){
        errorItems.push('Email');
    }
    if(formData.phone.length == 0){
        errorItems.push('Phone Number');
    }
    if(formData.age.length == 0){
        errorItems.push('Age');
    }
    if(formData.gender.length == 0){
        errorItems.push('Gender');
    }
    if(formData.qualification.length == 0){
        errorItems.push('Qualification');
    }
    if(formData.profession.length == 0 && formData.otherProfession.length == 0){
        errorItems.push('Profession');
    }
    if(errorItems.length > 0){
        var errorString = '';
        errorItems.forEach(function(item){
            errorString += item + ', ';
        });
        errorString = errorString.substring(0, errorString.length - 2);
       errors.push(errorString);
    }
    if( formData.phone.length > 0  && formData.phone.length != 10){        
        errors.push('Phone number should be of 10 digits.');
    }

    if(errors.length == 0){
        errorContainer.innerHTML = '';
        return true;
    }
    else{
        errorContainer.innerHTML = '';
        errors.forEach(function(error){
            var errorItem = document.createElement('li');
            errorItem.textContent = error;
            errorContainer.appendChild(errorItem);
        });
        return false;
    }
}
    
document.getElementById('profession')
.addEventListener('click',addProfessionOption(professionCommonArray));

function addProfessionOption(professionArray){
    var arraySelect = document.getElementById('profession');
       arraySelect.innerHTML = '<option value="" disabled selected>Select the profession</option>';
    professionArray.forEach(function(element) {
        var option = document.createElement('option');
        option.value = element;
        option.textContent = element;
        arraySelect.appendChild(option);
    });
     var option = document.createElement('option');
        option.value = 'Other';
        option.textContent = 'Other';
        arraySelect.appendChild(option);
}

document.getElementById('profession').addEventListener('change',()=>{
    const profession =  document.getElementById('profession');
    const otherProfession = document.getElementById('other-profession');
    if(profession.value == 'Other'){
       otherProfession.style.display = 'flex';
       otherProfession.style.flexDirection = 'column';
       otherProfession.style.rowGap = '0.2rem'
    }
    else{
        otherProfession.style.display = 'none';
    }
});

function changeProfessionList(){
   const newProfession = document.getElementById('new-profession').value;
   professionCommonArray.push(newProfession);
   addProfessionOption(professionCommonArray);
}

function getMaxDate(){
    var dateInput = document.getElementById('dob');
    var today = new Date();
    var year = today.getFullYear();
    var month = String(today.getMonth() + 1).padStart(2, '0');
    var day = String(today.getDate()).padStart(2, '0');
    var maxDate = `${year}-${month}-${day}`;
    dateInput.setAttribute('max', maxDate);

}