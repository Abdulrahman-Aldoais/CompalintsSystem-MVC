var connection = new SignalR.HubConnectionBuilder().withUrl("/notefy").build();
connection.on("ReceiveNotification", function (msg) {
    $("#notification-list").perpend(`
                            <div class="d-flex">
                            <div class="flex-grow-1">
                                <h6 class="mb-1">سعيد محمد صالح</h6>
                                <p class="mb-0">تقديم شكوى</p>
                                <small class="text-muted">منذ 3 ساعات</small>
                            </div>
                            <div class="dropdown-notifications-actions flex-shrink-0">
                                <a href="javascript:void(0)" class="dropdown-notifications-read">
                                    <span class="badge badge-dot"></span>
                                </a>
                                <a href="javascript:void(0)" class="dropdown-notifications-archive">
                                    <span class="bx bx-x"></span>
                                </a>
                            </div>
                        </div>`)
}); 
connection.start();