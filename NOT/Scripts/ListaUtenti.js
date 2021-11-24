$(document).ready(function () {
    $('#dtListaUtenti').DataTable({
        "order": [[2, "desc"]]
    });
    $('.dataTables_length').addClass('bs-select');
});