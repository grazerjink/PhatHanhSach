var listTagNXB = $(".nxb").toArray();
var listCodeNXB = [];
listTagNXB.forEach(it => {
    listCodeNXB.push(it.innerHTML);
})
$("#listNXB").autocomplete({
    source: listCodeNXB
});

var listTagDaiLy = $(".daiLy").toArray();
var listCodeDaiLy = [];
listTagDaiLy.forEach(it => {
    listCodeDaiLy.push(it.innerHTML);
})
$("#listDaiLy").autocomplete({
    source: listCodeDaiLy
});

var listTagSach = $(".sach").toArray();
var listCodeSach = [];
listTagSach.forEach(it => {
    listCodeSach.push(it.innerHTML);
})
$("#listSach").autocomplete({
    source: listCodeSach
});