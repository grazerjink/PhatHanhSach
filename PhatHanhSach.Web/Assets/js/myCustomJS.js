var listTagNXB = $(".nxb").toArray();
var listCodeNXB = [];
listTagNXB.forEach(it => {
    listCodeNXB.push(it.innerHTML);
})
$("#listNXB").autocomplete({
    source: listCodeNXB
});