$('#myStartDate').datetimepicker({
    format: 'DD / MM / YYYY',
    ignoreReadonly: true,
    allowInputToggle: true
});

$('#myEndDate').datetimepicker({
    format: 'DD / MM / YYYY',
    ignoreReadonly: true,
    allowInputToggle: true
});

$("#myStartDate").on("dp.change", function (e) {
    $('#myEndDate').data("DateTimePicker").minDate(e.date);
});      

var ctx = document.getElementById("revenueChart");
var myChart = new Chart(ctx, {
    type: "bar",
    data: {
        labels: [],
        datasets: []
    },
    options: {
        responsive: true
    }
});

$("#btnThongKe").off().click(function () {
    var startDate = $("#NgayBatDau").val().trim();
    var endDate = $("#NgayKetThuc").val().trim();
    if (startDate !== undefined && endDate !== undefined)
    {
        $.ajax({
            url: "/thong-ke/doanh-thu/",
            type: "POST",
            data: {
                startDate: startDate,
                endDate: endDate
            },
            dataType: "json",
            success: function (res) {
                var data = {
                    labels: res.DanhSachTieuDe,
                    datasets: [
                        {
                            label: "Tổng chi",
                            backgroundColor: "#FF5252",
                            data: res.DanhSachChi,
                            stack: 1
                        },
                        {
                            label: "Tổng thu",
                            backgroundColor: "#03A9F4",
                            data: res.DanhSachThu,
                            stack: 2
                        },
                        {
                            label: "Lợi nhuận",
                            backgroundColor: "#009688",
                            data: res.DanhSachLoiNhuan,
                            stack: 3
                        }
                    ]
                };

                $("#TongTienChi").text(res.TongChi);
                $("#TongTienThu").text(res.TongThu);
                $("#TongLoiNhuan").text(res.TongLoiNhuan);

                myChart.data.labels = data.labels;
                myChart.data.datasets = data.datasets;
                myChart.update();
            }
        });
    }    
    else {
        alert("Chưa xác định thời gian thống kê.");
    }
});                