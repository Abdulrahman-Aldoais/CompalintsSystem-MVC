    $('#myTable tbody').on('click', '.del-row', function () {
    $(this).closest('tr').remove();
})

$(".add-row").click(function() {
    $('#myTable tbody').append('<tr><td>Cell 1</td><td>Cell 2</td><td class="text-center"><a class="del-row" href="javascript:void(0);"><i class="fas fa-trash" style="font-size: 20px;"></i></a></td></tr>')
    });