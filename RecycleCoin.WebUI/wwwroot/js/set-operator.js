function search() {
    var input, filter, tr;
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

function selectUser(selRow) {
    document.getElementById("userId").value = selRow.cells[0].innerHTML;
}

function selectRole(selTag) {
    var x = selTag.options[selTag.selectedIndex].value;
    document.getElementById("roleId").value = x;
}