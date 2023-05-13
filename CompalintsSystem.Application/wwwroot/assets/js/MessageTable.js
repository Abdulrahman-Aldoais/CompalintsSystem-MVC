////$(document).ready(function(){
////    $('#MessageTable').DataTable({
////        processing: true,
////        ordering: true,
////        paging: true,
////        searching: true,
////        ajax:
////        {
////            "url": "Support_Messages/GetMessages",
////            "type": "POST",
////            "dataType": "JSON",
////        },


////        columns:
////            [
////                { data: "Id" },
////                { data: "Title" },
////                { data: "Email" },
////                { data: "Date" },
////                { data: "UserId" },

////            ]

////    });
////});

$(document).ready(function (){
    $('#MessageTable').DataTable({
        processing: true,
        serverSide: true,
        ajax:{
            url:"/Support_Messages/LoadData",
            type: "POST",
            dataType: "JSON",
            dataSrc: function (json) {
                for (var i = 0, ien = json.data.length; i < ien; i++) {
                    json.data[i][0] = '<a href="/message/' + json.data[i][0] + '>View message</a>';
                }
                return json.data;
            },
            'Content-Type': 'application/json',
        },
        columns:
            [
                { data: "id" },
                { data: "title" },
                { data: "email" },
                { data: "date" },
                { data: "userId" },
                {data: "id"}
                

            ],
       /* columnDefs: [
            {
                // For Responsive
                orderable: true,
                searchable: true,
                responsivePriority: 2,
                targets: 6,
                render: function(data) {

                    return render("<div class='dropdown'> <button type='button' class='btn dropdown - toggle hide - arrow p - 0' data-bs-toggle='dropdown'>< i class='bx bx-dots-vertical-rounded' ></i > </button > <div class='dropdown-menu'> <a class='dropdown-item' asp-controller='Support_Messages' asp-action='Details' asp-Route-id='" + data.id + "' > <i class='bx bx-info-circle bx-xs'></i> عر ض</a > <a class='dropdown-item' asp-controller='Support_Messages' asp-action='Delete' asp-Route-id='" + data.id + "' > <i class='bx bx-trash me-1'></i> حذف</a > </div > </div>").texr;
                    
                }
            },
        ]*/
    
        
    
    });
});

