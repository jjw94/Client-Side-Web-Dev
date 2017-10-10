var chosen = "default";
var counter = 0;

//Goes through the individual arrays and sets <option> of <select>
function createOptions(select, div){
    var question;
    var option;
    
    //Create h3 that contains the question
    question = document.createElement('h3');
    var q = document.createTextNode(obj[chosen][0]);
    question.appendChild(q);
    div.appendChild(question);
    
    //Create option that contains the text '--SELECT ONE--' as the first option in the select
    option = document.createElement('option');
    var selectOne = document.createTextNode('--SELECT ONE--');
    option.appendChild(selectOne);
    select.appendChild(option);
    
    //Fill select option with answer choices from the chosen array
    for(var i = 1; i < obj[chosen].length; i++){
        option = document.createElement('option');
	var text = document.createTextNode(obj[chosen][i]);
	option.appendChild(text);
	select.appendChild(option);
    }
}

//The general method that creates the dropdown menu
function createNext(){
    //If it's not the first question, get the name of the next array
    if(counter !== 0){
	chosen = this.value;
    }
    
    //If an answer is changed of a previous question, delete options from previous choice
    if((counter !== 0) && (this.parentNode.firstChild !== this.parentNode.parentNode.lastChild.lastChild)){
	while(this.parentNode.parentNode.lastChild !== this.parentNode){
	    this.parentNode.parentNode.removeChild(this.parentNode.parentNode.lastChild);
	    if(formExists){
		clearForm();
	    }
	}
    }
    
    //If an answer is changed at the very last select menu, clear previous form
    if((counter != 0) && (formExists)){
	clearForm();
    }
    
    //Create an element
    var div = document.createElement('div');
    var select  = document.createElement('select');
    
    //If it's the last question
    if((counter !== 0) && (chosen == this[0].value)){
	showError(chosen + ' is not a valid choice');
	if(formExists){
	    clearForm();
	}
    }
    else if(obj[chosen] == undefined){
	createForm();
    }
    else{
	//Go through the array and display the choices
	createOptions(select, div);
	select.onchange = createNext;
	div.appendChild(select);
	
	//Printing div with select to page
	document.getElementById('leftcolumn').appendChild(div);
	
	//Just so then we know if it's not the first question
	counter++;
    }
}

//Show error message at the top
function showError(mes){
    var errorDiv = document.getElementById('error');
    
    //If an error already exists
    while(errorDiv.firstChild){
	errorDiv.removeChild(errorDiv.firstChild);
    }
    errMes = document.createTextNode(mes);
    errorDiv.appendChild(errMes);
}