$("#listNXB").autocomplete({
    source: function (req, res) {
        $.ajax({
            url: "/api/danh-sach-nxb",
            dataType: "json",
            success: function(data) {
                res(data);
            }
        });
    },
    select: function (event, ui) {
        event.preventDefault();
        $("#IdNXB").val(ui.item.value);
    },
    focus: function (event, ui) {
        event.preventDefault();
        $("#listNXB").val(ui.item.label);
    }
});

$("#listDaiLy").autocomplete({
    source: function (req, res) {
        $.ajax({
            url: "/api/danh-sach-dai-ly",
            dataType: "json",
            success: function (data) {
                res(data);
            }
        });
    },
    select: function (event, ui) {
        event.preventDefault();
        $('#IdDaiLy').val(ui.item.value);
    },
    focus: function (event, ui) {
        event.preventDefault();
        $("#listDaiLy").val(ui.item.label);
    }
});

$("#listSach").autocomplete({
    source: function (req, res) {
        $.ajax({
            url: "/api/danh-sach-sach",
            dataType: "json",
            success: function (data) {
                res(data);
            }
        });
    },
    select: function (event, ui) {
        event.preventDefault(); 
        $('#ctPhieuNhap_IdSach').val(ui.item.value);
        $('#ctPhieuXuat_IdSach').val(ui.item.value);
    },
    focus: function (event, ui) {
        event.preventDefault();
        $("#listSach").val(ui.item.label);
    }
});