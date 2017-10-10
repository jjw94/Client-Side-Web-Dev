var errMes;

//Store form information
function store(){
    if(window.localStorage){
	window.localStorage.setItem(this.id, this.value);
    }
    else{
	SetCookie(this.id, this.value);
    }
}

var movingDiv;
//Slide in action
function slideIn(which){
    movingDiv = document.getElementById(which);
    if(parseInt(movingDiv.style.top) < 0){
	movingDiv.style.top = parseInt(movingDiv.style.top) + 1 + 'px';
	setTimeout(function(){slideIn(which);}, 5);
    }
}

//Create the form when the user hits the last question
var form;
var formDiv;
var formExists = false;
function createForm(){
    //Div that contains the form
    formDiv = document.createElement('div');
    form = document.createElement('form');
    form.setAttribute('name', 'form');
    
    //h3: the name of the chosen item
    var hThree = document.createElement('h3');
    hThree.appendChild(document.createTextNode(res[chosen][0]));
    
    //img: the img of the chosen item
    var img = document.createElement('img');
    img.setAttribute('src', 'media/' + res[chosen][1]);
    
    //Input: the name which the order is going to be placed
    var name = document.createTextNode('Your Name: ');
    var ninput = document.createElement('input');
    ninput.setAttribute('id', 'name');
    ninput.onchange = store;
    
    //Input: the email which the order is going to be placed
    var email = document.createTextNode('Your Email: ');
    var einput = document.createElement('input');
    einput.setAttribute('id', 'email');
    einput.onchange = store;
    
    var nextLine = document.createElement('br');
    
    //Button: clicked when the user is ready to place order
    var button = document.createElement('input');
    button.setAttribute('type', 'button');
    button.setAttribute('value', 'Order Now!');
    button.onclick = submitForm;
    
    //Button: clicked when the user  wants to clear inputs
    var clear = document.createElement('input');
    clear.setAttribute('type', 'button');
    clear.setAttribute('value', 'Clear inputs');
    clear.onclick = clearInput;
    
    //Store name
    if(GetCookie('name') !== null){
	ninput.value = GetCookie('name'); //CHECK THIS
    }
    else if(window.localStorage.getItem('name') !== null){
	ninput.value = window.localStorage.getItem('name');
    }
    
    //Store email
    if(GetCookie('email') !== null){
	einput.value = GetCookie('email'); //CHECK THIS
    }
    else if(window.localStorage.getItem('email') !== null){
	einput.value = window.localStorage.getItem('email');
    }
    
    //Append all of the components that were created above
    form.appendChild(hThree);
    form.appendChild(nextLine);
    
    form.appendChild(img);
    form.appendChild(nextLine.cloneNode(true));
    
    form.appendChild(name);
    form.appendChild(ninput);
    form.appendChild(nextLine.cloneNode(true));
    
    form.appendChild(email);
    form.appendChild(einput);
    form.appendChild(nextLine.cloneNode(true));
    
    form.appendChild(button);
    form.appendChild(clear);
    
    formDiv.appendChild(form);
    
    document.getElementById('rightcolumn').appendChild(formDiv);
    
    formExists = true;
    
    slideIn('rightcolumn');
}

//Create div that contains the form
function clearForm(){
    form.parentNode.remove(this.parentNode);
    movingDiv.style.top = '-500px';
    formExists = false;
}

//Check the info the user entered and 'submit form'
function submitForm(){
    //Check inputs
    var letters = /^[A-Za-z ]+$/;
    var address = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    
    var userName = document.forms['form']['name'].value;
    var emailAddress = document.forms['form']['email'].value;
    
    //Show errors
    if((userName == "") || (emailAddress == "")){
	showError('Please fill in both your name and email before submitting');
    }
    else if(!(userName.match(letters))){
	showError('Name can only contain alphabets. Check Again.');
    }
    else if(!(emailAddress.match(address))){
	showError('Your Email Address is invalid. Check Again.');
    }
    else{
	var errorDiv = document.getElementById('error');
	while(errorDiv.firstChild){
	    errorDiv.removeChild(errorDiv.firstChild);
	}
	alert('Thank you! Your order has been placed!');
    }
}

//Clears all cookies and localStorage
function clearInput(){
    if(window.localStorage){
	localStorage.clear();
    }
    else{
	DeleteCookie('name');
	DeleteCookie('email');
    }
    
    //Clear textbox
    document.forms['form']['name'].value = '';
    document.forms['form']['email'].value = '';
}