
$(document).ready(function () {


    $('#CustomSearchTextField').keyup(function () {

        oTable.search($(this).val()).draw();
    });

    var oTable = $('#TableWithFilter').DataTable({
        "sPaginationType": "full_numbers",

        "order": [[1, 'asc']],
        "language": {
            "loadingRecords":
                '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">جاري التحميل...</span> ',

            "lengthMenu": "أظهر _MENU_ مدخلات",
            "zeroRecords": "لم يعثر على أي بيانات",
            "info": "إظهار _START_ إلى _END_ من أصل _TOTAL_ مدخل",
            "search": "ابحث:",
            "searchPlaceholder": "بحث عن شكوى",
            "paginate": {
                "first": "الأول",
                "previous": "السابق",
                "next": "التالي",
                "last": "الأخير"
            },



        },
       
   
        "paging": true,
        "lengthChange": true,
        "processing": true,
        /*"searching": true,*/
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": false,
        "searching": true,
       
        //dom: '<"card-header flex-column flex-md-row"<"head-label text-center"><"dt-action-buttons text-end pt-3 pt-md-0"B>><"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6 d-flex justify-content-center justify-content-md-end"f>>t<"row"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>',


        displayLength: 4,
        initComplete: function () {
            this.api()
                .columns([1,2,3])
                .every(function () {
                    var column = this;
                    var select = $('<select><option value="">الكل</option></select>')
                        .appendTo($(column.header()).empty())
                        .on('change', function () {
                            var val = $.fn.dataTable.util.escapeRegex($(this).val());

                            column.search(val ? '^' + val + '$' : '', true, false).draw();
                        });

                    column
                        .data()
                        .unique()
                        .sort()
                        .each(function (d, j) {
                            select.append('<option >' + d + '</option>');
                        });
                });
        },

    });   //using Capital D, which is mandatory to retrieve "api" datatables' object, latest jquery Datatable









});