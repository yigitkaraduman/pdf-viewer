function convertBase64() {

    var file = document.getElementById("file-selector").files[0];
    if (file == undefined)
        addAlert('Please select a file!')
    
    if (file.type != 'text/plain') {
        addAlert('Only accepts .txt file!');
        return;
    }

    if (file) {
        var reader = new FileReader();
        reader.readAsText(file, "UTF-8");
        reader.onload = function (evt) {
            var b64 = evt.target.result;

            if (isBase64(b64) == false) {
                addAlert('Content is not in base64 format!');
                return;
            }

            const element = document.getElementById("pdf-result"); 
            if (element != null) {
                element.remove();
            }

            // Embed the PDF into the HTML page and show it to the user
            var obj = document.createElement('object');
            obj.id = 'pdf-result';
            obj.style.width = '100%';
            obj.style.height = '500px';
            obj.style.marginTop = '1.5rem';
            obj.style.marginBottom = '1.5rem';
            obj.style.float = 'left';
            //obj.style.border = '10px solid grey';
            obj.type = 'application/pdf';
            obj.data = 'data:application/pdf;base64,' + b64;

            document.getElementById("alerts").innerHTML = "";

            var parent = document.getElementsByClassName('pdfview');
            parent[0].insertBefore(obj, parent.lastChild);

            window.scrollTo(0, document.body.scrollHeight)

        }
            reader.onerror = function (evt) {
            console.log("error reading file!");
        }
    }
}

function isBase64(str) {
    if (str === '' || str.trim() === '') { return false; }
    try {
        return btoa(atob(str)) == str;
    } catch (err) {
        return false;
    }
}

function addAlert(message) {
    document.getElementById("alerts").innerHTML = "";
    $('#alerts').append(
        '<div class="alert alert-danger alert-dismissible fade show mt-4">' +
        '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close">' +
        '</button>' + message + '</div>');
}
