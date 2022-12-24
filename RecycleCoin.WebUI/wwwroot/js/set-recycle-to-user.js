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

    function submit_form() {
        document.getElementById('myform').submit();
    }

    let trs = document.querySelectorAll("#myTBody > tr");
    let currentTr1;
    for (i = 0; i < trs.length; i++) {
        let currentTr = trs[i];
        currentTr.addEventListener('click', function (e) {
            if (currentTr1) {
                currentTr1.classList.toggle("focusedTr");
            }
            currentTr1 = currentTr;
            currentTr1.className = "focusedTr";
        })
    }
