
function licen(obj) {
    var code = obj.value;
    if (obj.value.length == 12)
        obj.value = code.substr(0, 8) + '0' + code.substr(8);
}



function fontZoom(zoomId, size) {
    document.getElementById(zoomId).style.fontSize = size + "px";
}

function fontZoomArray(zoomIdArray, size) {
    for (var i = 0; i < zoomIdArray.length; i++) {
        fontZoom(zoomIdArray[i], size);
    }
}
function externallinks() {
    if (!document.getElementsByTagName) return;
    var anchors = document.getElementsByTagName("a");
    for (var i = 0; i < anchors.length; i++) {
        var anchor = anchors[i];
        if (anchor.getAttribute("href") &&
       anchor.getAttribute("rel") == "external")
            anchor.target = "_blank";
    }
}

function TabSearch() {
    if (event.keyCode == 13) {
        go();
    }
}
function opwin(keywords, type, appPath) {
    window.open(appPath  + "result.aspx?key=" + escape(keywords) + "&selectstr=" + type);
}

function go(appPath) {

    var key = document.getElementById("txtwords").value;
    key = key.replace(/</g, "");
    key = key.replace(/>/g, "");
    var index = document.getElementById("searchtype").selectedIndex;
    var type = document.getElementById("searchtype").options[index].value;
    if (key == null || key.length == 0) {
        alert("�����������ؼ���");
        return false;
    }
    else if (type.indexOf('content') != -1 && key.length < 2) {
        alert("������2���������ַ�");
        return;
    }
    opwin(key, type, appPath);
}

function initArray() {
    this.length = initArray.arguments.length
    for (var i = 0; i < this.length; i++)
        this[i + 1] = initArray.arguments[i]
}

function today() {
    today = new Date();

    var d = new initArray(
     "������",
     "����һ",
     "���ڶ�",
     "������",
     "������",
     "������",
     "������");

    document.write(
	 "<img src=images/ebschedule_18.gif width=18 height=18 align=absmiddle hspace=3>",
     "<font style='font-size:11px;font-family:Verdana'>",
     today.getYear(),"��",
     today.getMonth() + 1, "��",
     today.getDate(), "��&nbsp;",
     d[today.getDay() + 1],
     "</font>");
}

function goSubSite() {
    var urlPattern = "shfclawyer.com";
    var subDirectory = "shfclawyer";
    var currentUrl = window.location.href;
    var indexOfShfc = currentUrl.indexOf(urlPattern);

    if (indexOfShfc > -1) {
        var splitIndex = indexOfShfc + shfcUrlPattern.length;
        var newUrl = currentUrl.substring(0, splitIndex) + "/" + subDirectory + currentUrl.substring(splitIndex, currentUrl.length);
        alert(newUrl);
        window.navigate(newUrl);
    }

}