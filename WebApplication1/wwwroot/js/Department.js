
$(document).ready(function () {
    $('#tableDepartment').DataTable({
        ajax: {
            url: 'https://localhost:7138/api/Department',
            type: 'GET',
            dataType: 'json',
            headers: {
                'Authorization': "Bearer " + sessionStorage.getItem("token"),
            },
        },
        columns: [
            { data: 'id', },
            { data: 'name', },
            { data: 'divisionId', },
            {
                data: null,
                "render": function (data, type, row, meta) {
                    return `<button type="button" class="btn btn-primary" onclick="detailsDepartment(${data.id})" data-bs-toggle="modal" data-bs-target="#detailModalDepartment">DETAILS</button>
                            <button type="button" class="btn btn-primary" onclick="editDepartment(${data.id})" data-bs-toggle="modal" data-bs-target="#editDepartment">EDIT</button>
                            <button type="button" class="btn btn-danger" onclick="deleteDepartment(${data.id})">DELETE</button>`;
                }
            }
        ],


    });
});


function detailsDepartment(id) {
    $.ajax({
        url: `https://localhost:7138/api/Department/${id}`,
        type: "GET"
    }).done((res) => {
        let temp = "";

        temp += `
        <input type="hidden" class="form-control" id="hideId" value="0" readonly/>
        <h5>id: </h5><input type="text" class="form-control" id="deptId" placeholder="${res.data.id}" value="${res.data.id}" readonly/>
        <h5>Nama: </h5><input type="text" class="form-control" id="deptName" placeholder="${res.data.name}" value="${res.data.name}" readonly/>
        <h5>Division ID: </h5><input type="text" class="form-control" id="deptName" placeholder="${res.data.divisionId}" value="${res.data.divisionId}"/>
        `;
        $("#detailData").html(temp);
        console.log(res.data.id);
    }).fail((err) => {
        console.log(err);
    })
}

function deleteDepartment(id) {
    var hapus = confirm("Yakin ingin menghapus?");

    if (hapus) {
        $.ajax({
            url: `https://localhost:7138/api/Department/?id=${id}`,
            type: 'DELETE',
            success: function (data) {
                Swal.fire(
                    'Good job!',
                    'Data berhasil dihapus!',
                    'success'
                ); setTimeout(function () {
                    location.reload();
                }, 3000);
            }
        });
    }
}


function addDepartment() {
    let data;
    let id = 0;
    let name = $('#addNameDepartment').val();
    let divisionId = $('#addDivisionId').val();

    data = {
        "id": id,
        "name": name,
        "divisionId" : divisionId,

    };

    $.ajax({
        url: 'https://localhost:7138/api/Department/',
        type: 'POST',
        data: JSON.stringify(data),
        dataType: 'json',
        headers: {
            'Content-Type': 'application/json'
        },
        success: function (datas) {
            Swal.fire(
                'Good job!',
                'Data Berhasil Ditambahkan!',
                'success'
            ); setTimeout(function () {
                location.reload();
            }, 3000);
        }
    });
}

function editDepartment(id) {
    $.ajax({
        url: `https://localhost:7138/api/Department/${id}`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        temp += `
            <input type="hidden" class="form-control" id="hideId" readonly placeholder="" value="0">
            <p>Id: </p><input type="text" class="form-control" id="deptId" placeholder="${res.data.id}" value="${res.data.id}">
            <p>Name: </p><input type="text" class="form-control" id="deptName" placeholder="${res.data.name}" value="${res.data.name}">
            <p>Division Id: </p><input type="text" class="form-control" id="DivId" placeholder="${res.data.divisionId}" value="${res.data.divisionId}">
            <button type= "button" class= "btn-primary" id= "editButton" onclick="saveDepartment(${res.data.id})">Save Changes</button>
            `;
        $("#editData").html(temp);
    }).fail((err) => {
        console.log(err);
    });
}

function saveDepartment(id) {
    var Id = id;
    var Name = $('#deptName').val();
    var DivisionId = $('#DivId').val();

    var res = { Id, Name, DivisionId };
    $.ajax({
        url: `https://localhost:7138/api/Department/`,
        type: "PUT",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(res),
        success: function () {
            Swal.fire(
                'Good job!',
                'Data Berhasil Diedit!',
                'success'
            ); setTimeout(function () {
                location.reload();
            }, 3000);
        },
        error: function () {

        }
    });
}

