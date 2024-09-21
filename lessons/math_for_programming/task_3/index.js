function Encode() {
    var text_input = document.getElementById("text");
    var encodingType = document.getElementById('select').value; 
    var encodingKey = document.getElementById('select').value; 

    if (encodingType == 1) {

    }
    if (encodingType == 2) {
    }
    if (encodingType == 3) {
        text_input.value = text_input.value.split('').reverse().join('');
    }
}