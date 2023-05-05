var dataTable;

$(document).ready(() => {

    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#TaiKhoan').DataTable({
        "ajax": { url: '/Admin/HomeManagerTaiKhoan/GetAll' },
        "columns": [
            { data: 'accountNumber', "width": "20%" },
            { data: 'balance', "width": "15%" },
            { data: 'applicationUser.name', "width": "15%" },
            { data: 'accountType.name', "width": "20%" },        
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group " role="group">
                        <a class="btn btn-secondary btn-fw" href="/admin/HomeManagerTaiKhoan/upsert?id=${data}">
                            <i class="mdi mdi-table-edit"></i> Edit
                        </a>
                        <a class="btn btn-danger btn-fw">
                            <i class="mdi mdi-folder-lock"></i> Lock
                        </a>
                    </div>
                    `
                },
                "width": "30%"
            },
        ]
    });
}



