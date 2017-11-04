var $form = $('form');
var initialState = $form.serialize();

var $tinhTrang = $form.find("#IdTinhTrang");
var status = $tinhTrang.val();
if (status !== "1") {
    $('#TinhTrang').attr("disabled", "disabled");
    $tinhTrang.attr("disabled", "disabled");
    $(".acceptDay").removeClass("hidden");
    $(".amountPay").removeClass("hidden");
    $(".editable").attr("readonly", "readonly");
}
else {
    var changed = $(".changed").html();
    if (changed !== "True") {
        $('#btnUpdate').attr("disabled", "disabled");
    }
    else {
        $('#btnUpdate').removeAttr("disabled");
    }
    $(".acceptDay").addClass("hidden");
    $(".amountPay").addClass("hidden");
    $(".editable").removeAttr("readonly");
}

$('form').on('change input', function (e) {
    if (initialState === $(this).serialize()) {
        $('#btnUpdate').attr("disabled", "disabled");
    } else {
        $('#btnUpdate').removeAttr("disabled");
    }
    e.preventDefault();
});

$('#TinhTrang').on('change', function () {
    var newIdTinhTrang = $(this).val();
    $('#IdTinhTrang').val(newIdTinhTrang);
    if (newIdTinhTrang === "2") {
        $(".acceptDay").removeClass("hidden");
        $(".amountPay").removeClass("hidden");
    }
    else if (newIdTinhTrang === "3") {
        $(".acceptDay").removeClass("hidden");
        $(".amountPay").addClass("hidden");
    }
    else {
        $(".acceptDay").addClass("hidden");
        $(".amountPay").addClass("hidden");
    }

});

$('#myCreateDate').datetimepicker({
    format: 'DD / MM / YYYY',
    allowInputToggle: true
});

$('#myConfirmDate').datetimepicker({
    format: 'DD / MM / YYYY',
    allowInputToggle: true
});

$('#myStartDate').datetimepicker({
    format: 'DD / MM / YYYY',
    allowInputToggle: true
});

$('#myEndDate').datetimepicker({
    format: 'DD / MM / YYYY',
    allowInputToggle: true
});

$("#myStartDate").on("dp.change", function (e) {
    $('#myEndDate').data("DateTimePicker").minDate(e.date);
});

$('#myConfirmDate').data("DateTimePicker").minDate($("#NgayXacNhan").val());