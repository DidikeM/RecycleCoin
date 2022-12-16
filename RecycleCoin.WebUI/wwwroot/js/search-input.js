function myFunction() {
    var input, filter, tr, txtValue;
    input = document.getElementById("myInput");

    filter = input.value.toUpperCase();

    tbody = document.getElementById("myTBody");
    tr = tbody.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        let doHas = false;
        let tds = tr[i].getElementsByTagName("td");
        for (let t = 0; t < tds.length; t++) {
            let td = tds[t];
            let content = td.textContent;
            if (content.toUpperCase().indexOf(filter) > -1) {
                doHas = true;
            }
        }

        if (doHas) {
            tr[i].style.display = "";
        } else {
            tr[i].style.display = "none";
        }
    }
}