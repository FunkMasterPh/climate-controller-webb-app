var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "order": [[0, 'desc']],
        "ajax": {
            "url":"/User/DHT11Reading/GetAllForDataTable"
        },
        "columns": [
            { "data": "timeOfReading","render": $.fn.dataTable.render.moment('YYYY-MM-DDTHH:mm:ss.SSSS', 'YYYY-MM-DD HH:mm:ss'), "width": "15%"},
            { "data": "humidityValue", "width": "15%" },
            { "data": "tempValue", "width": "15%" },
            { "data": "humidityUpperThreshold", "width": "15%" },
            { "data": "humidityLowerThreshold", "width": "15%" },

        ]
    });
}