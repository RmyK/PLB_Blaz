function displaymessage(msg) {
    if (confirm(msg)) {
        return true;
    }
    else {
        return false;
    }
}

function getdata(dotNetObject) {
    let val = Math.random() * 100;
    dotNetObject.invokeMethodAsync('AddText', val.toString());
}

function changecolor(element,color) {
    element.style.backgroundColor = color;
}

function setTodoLabel(currentLabel) {
    let result;
    let newlabel = prompt("Saisir le label du Todo :", currentLabel);
    if (newlabel == null || newlabel == "") {
        result = currentLabel;
    }
    else {
        result = newlabel;
    }
    return newlabel;
}