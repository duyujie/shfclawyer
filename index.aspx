﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="com.hujun64.index"
    CodeFileBaseClass="com.hujun64.PageBase" %>

<%@ Register TagPrefix="uc1" TagName="header" Src="ascx/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top" Src="ascx/top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="right" Src="ascx/right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="ascx/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="track" Src="ascx/track.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="Author" content="上海律师胡珺 shfclawyer.com" />
    <meta name="keywords" content="<%= pageMeta.keywords+" "%>" />
    <meta name="description" content="<%=pageMeta.description+" "%>" />
    <title>
        <%=pageMeta.title + " "%>
    </title>
    <style type="text/css" media="all">
        .d1111
        {
            width: 280px;
            height: auto;
            overflow: hidden;
            border: #ff9900 2px solid;
            background-color: #FFFFFF;
            position: relative;
        }
        .loading
        {
            width: 280px;
            border: #666666 2px solid;
            background-color: #ffffff;
            color: #FFCC00;
            font-size: 12px;
            height: 179px;
            text-align: center;
            padding-top: 30px;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-weight: bold;
        }
        .d2
        {
            width: 100%;
            height: 176px;
            overflow: hidden;
        }
        .num_list
        {
            position: absolute;
            width: 100%;
            left: 0px;
            bottom: -1px;
            background-color: #cccccc;
            color: #000000;
            font-size: 12px;
            padding: 4px 0px;
            height: 40px;
            overflow: hidden;
        }
        .num_list span
        {
            display: inline-block;
            height: 16px;
            padding-left: 6px;
        }
        img
        {
            border: 0px;
        }
        #fade_focus ul
        {
            display: none;
        }
        .button
        {
            position: absolute;
            z-index: 1000; /*right*/
            left: 2px;
            bottom: 2px;
            font-size: 13px;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
        }
        .b1, .b2
        {
            background-color: #666666;
            display: block;
            float: left;
            padding: 2px 6px;
            margin-right: 3px;
            color: #FFFFFF;
            text-decoration: none;
            cursor: pointer;
        }
        .b2
        {
            color: #FFCC33;
            background-color: #ff9900;
        }
        .fade_focus li
        {
            list-style-type: none;
        }
    </style>
    <script language="javascript" type="text/javascript">

        var s = function () {
            var interv = 2000; //切换间隔时间
            var interv2 = 40; //切换速速
            var opac1 = 70; //文字背景的透明度
            var source = "fade_focus" //焦点轮换图片容器的id名称
            //获取对象
            function getTag(tag, obj) { if (obj == null) { return document.getElementsByTagName(tag) } else { return obj.getElementsByTagName(tag) } }
            function getid(id) { return document.getElementById(id) };
            var opac = 0, j = 0, t = 63, num, scton = 0, timer, timer2, timer3; var id = getid(source); id.removeChild(getTag("div", id)[0]); var li = getTag("li", id); var div = document.createElement("div"); var title = document.createElement("div"); var span = document.createElement("span"); var button = document.createElement("div"); button.className = "button"; for (var i = 0; i < li.length; i++) { var a = document.createElement("a"); a.innerHTML = i + 1; a.onclick = function () { clearTimeout(timer); clearTimeout(timer2); clearTimeout(timer3); j = parseInt(this.innerHTML) - 1; scton = 0; t = 63; opac = 0; fadeon(); }; a.className = "b1"; a.onmouseover = function () { this.className = "b2" }; a.onmouseout = function () { this.className = "b1"; sc(j) }; button.appendChild(a); }
            //控制图层透明度
            function alpha(obj, n) { if (document.all) { obj.style.filter = "alpha(opacity=" + n + ")"; } else { obj.style.opacity = (n / 100); } }
            //控制焦点按钮
            function sc(n) { for (var i = 0; i < li.length; i++) { button.childNodes[i].className = "b1" }; button.childNodes[n].className = "b2"; }
            title.className = "num_list"; title.appendChild(span); alpha(title, opac1); id.className = "d1111"; div.className = "d2"; id.appendChild(div); id.appendChild(title); id.appendChild(button);
            //渐显
            var fadeon = function () { opac += 5; div.innerHTML = li[j].innerHTML; span.innerHTML = getTag("img", li[j])[0].alt; alpha(div, opac); if (scton == 0) { sc(j); num = -2; scrolltxt(); scton = 1 }; if (opac < 100) { timer = setTimeout(fadeon, interv2) } else { timer2 = setTimeout(fadeout, interv); }; }
            //渐隐
            var fadeout = function () { opac -= 5; div.innerHTML = li[j].innerHTML; alpha(div, opac); if (scton == 0) { num = 2; scrolltxt(); scton = 1 }; if (opac > 0) { timer = setTimeout(fadeout, interv2) } else { if (j < li.length - 1) { j++ } else { j = 0 }; fadeon() }; }
            //滚动文字
            var scrolltxt = function () { t += num; span.style.marginTop = t + "px"; if (num < 0 && t > 3) { timer3 = setTimeout(scrolltxt, interv2) } else if (num > 0 && t < 62) { timer3 = setTimeout(scrolltxt, interv2) } else { scton = 0 } };
            fadeon();
        }
        //初始化
        //window.onload=s;
    </script>
    <script language="javascript" type="text/javascript" src="js/huan.js"></script>
    <uc1:header ID="header1" runat="server"></uc1:header>
</head>
<body class="index">
    <uc1:top ID="top" runat="server"></uc1:top>
    <!-- /nav -->
    <div class="w960 center clear mt1">
        <div class="pleft">
            <div class="bignews">
                <dl class="tbox">
                    <dt><strong><a href="listitem.aspx?class_name=律师博文与手记"><font color="blue">律师博文与手记</font></a></strong><span
                        class="more"><a href="listitem.aspx?class_name=律师博文与手记">更多</a></span></dt></dl>
                        <ul class="d1 ico2">
                <asp:Repeater runat="server" ID="RepeaterLsbw">
                    <ItemTemplate>
                        <li>
                            <a href="<%# Total.AspxUrlShowdetail %>?<%# Total.QueryStringArticleId
    %>=<%# Eval("id") %>" title="<%=pageMetaName %>：<%#Eval("title")%>" target="_blank">
                                <%#UtilHtml.NoImgTitleSubstring(Eval("id").ToString(),
    Eval("title").ToString(), (DateTime)Eval("addtime"))%>
                            </a>
                            <samp>
                                            <%# String.Format("{0:MM}-{1:dd}", Eval( "addtime"), Eval( "addtime"))%></samp>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                </ul>
            </div>
            <!-- /头条 -->
            <div class="flashnews">
                <!-- size: 280px * 192px -->
                <div id="fade_focus" class="flashnews">
                    <div>
                        Loading...<br />
                        <img src="images/loading.gif" width="200" height="100" alt="loading..." /></div>
                    <ul>
                        <asp:Repeater runat="server" ID="RepeaterArticlePicture">
                            <ItemTemplate>
                                <li><a href="<%# Total.AspxUrlShowdetail %>?<%# Total.QueryStringArticleId %>=<%# Eval("id")
    %>" title="<%=pageMetaName %>：<%#Eval("title")%>" target="_blank">
                                    <img src="<%#Eval("articlePicture.pic_url")%>" width="280px" height="250px" alt='<%#Eval("title") %>' />
                                </a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <script language="javascript" type="text/javascript">
                    s();
                </script>
            </div>
            <!-- /flashnews -->
            <div class="listbox">
                <dl class="tbox">
                    <dt><strong><a href="listitem.aspx?class_name=房屋买卖">房屋买卖</a></strong><span class="more"><a
                        href="listitem.aspx?class_name=房屋买卖">更多</a></span></dt>
                    <dd>
                        <ul class="d1 ico3">
                            <asp:Repeater runat="server" ID="RepeaterFwmm">
                                <ItemTemplate>
                                    <li><a href="<%# Total.AspxUrlShowdetail %>?<%# Total.QueryStringArticleId %>=<%# Eval("id")
    %>" title="<%=pageMetaName %>：<%#Eval("title")%>" target="_blank">
                                        <%#UtilHtml.ImgTitleSubstring(Eval("id").ToString(),
    Eval("title").ToString(), (DateTime)Eval("addtime"))%>
                                    </a>
                                        <samp>
                                            <%# String.Format("{0:MM}-{1:dd}", Eval( "addtime"), Eval( "addtime"))%></samp></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
                <dl class="tbox">
                    <dt><strong><a href="listitem.aspx?class_name=房屋权属">房屋权属</a></strong><span class="more"><a
                        href="listitem.aspx?class_name=房屋权属">更多</a></span></dt>
                    <dd>
                        <ul class="d1 ico3">
                            <asp:Repeater runat="server" ID="RepeaterFwqs">
                                <ItemTemplate>
                                    <li><a href="<%# Total.AspxUrlShowdetail %>?<%# Total.QueryStringArticleId %>=<%# Eval("id")
    %>" title="<%=pageMetaName %>：<%#Eval("title")%>" target="_blank">
                                        <%#UtilHtml.ImgTitleSubstring(Eval("id").ToString(),
    Eval("title").ToString(), (DateTime)Eval("addtime"))%>
                                    </a>
                                        <samp>
                                            <%# String.Format("{0:MM}-{1:dd}", Eval( "addtime"), Eval( "addtime"))%></samp></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
                <dl class="tbox">
                    <dt><strong><a href="listitem.aspx?class_name=离婚继承">离婚继承</a></strong><span class="more"><a
                        href="listitem.aspx?class_name=离婚继承">更多</a></span></dt>
                    <dd>
                        <ul class="d1 ico3">
                            <asp:Repeater runat="server" ID="RepeaterLhjc">
                                <ItemTemplate>
                                    <li><a href="<%# Total.AspxUrlShowdetail %>?<%# Total.QueryStringArticleId %>=<%# Eval("id")
    %>" title="<%=pageMetaName %>：<%#Eval("title")%>" target="_blank">
                                        <%#UtilHtml.ImgTitleSubstring(Eval("id").ToString(),
    Eval("title").ToString(), (DateTime)Eval("addtime"))%>
                                    </a>
                                        <samp>
                                            <%# String.Format("{0:MM}-{1:dd}", Eval( "addtime"), Eval( "addtime"))%></samp></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
                <dl class="tbox">
                    <dt><strong><a href="listitem.aspx?class_name=拆迁安置">拆迁安置</a></strong><span class="more"><a
                        href="listitem.aspx?class_name=拆迁安置">更多</a></span></dt>
                    <dd>
                        <ul class="d1 ico3">
                            <asp:Repeater runat="server" ID="RepeaterCqaz">
                                <ItemTemplate>
                                    <li><a href="<%# Total.AspxUrlShowdetail %>?<%# Total.QueryStringArticleId %>=<%# Eval("id")
    %>" title="<%=pageMetaName %>：<%#Eval("title")%>" target="_blank">
                                        <%#UtilHtml.ImgTitleSubstring(Eval("id").ToString(),
    Eval("title").ToString(), (DateTime)Eval("addtime"))%>
                                    </a>
                                        <samp>
                                            <%# String.Format("{0:MM}-{1:dd}", Eval( "addtime"), Eval( "addtime"))%></samp></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
                <a href="#">
                    <img src="images/quanmianfuwu.jpg" width="720px" alt="上海房产律师网 咨询热线 13636542941 网址 http://www.shfclawyer.com"></a>
                <dl class="tbox">
                    <dt><strong><a href="listitem.aspx?class_name=租赁抵押">租赁抵押</a></strong><span class="more"><a
                        href="listitem.aspx?class_name=租赁抵押">更多</a></span></dt>
                    <dd>
                        <ul class="d1 ico3">
                            <asp:Repeater runat="server" ID="RepeaterZldy">
                                <ItemTemplate>
                                    <li><a href="<%# Total.AspxUrlShowdetail %>?<%# Total.QueryStringArticleId %>=<%# Eval("id")
    %>" title="<%=pageMetaName %>：<%#Eval("title")%>" target="_blank">
                                        <%#UtilHtml.ImgTitleSubstring(Eval("id").ToString(),
    Eval("title").ToString(), (DateTime)Eval("addtime"))%>
                                    </a>
                                        <samp>
                                            <%# String.Format("{0:MM}-{1:dd}", Eval( "addtime"), Eval( "addtime"))%></samp></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
                <dl class="tbox">
                    <dt><strong><a href="listitem.aspx?class_name=物业管理">物业管理</a></strong> <span class="more">
                        <a href="listitem.aspx?class_name=物业管理">更多</a></span></dt>
                    <dd>
                        <ul class="d1 ico3">
                            <asp:Repeater runat="server" ID="RepeaterWygl">
                                <ItemTemplate>
                                    <li><a href="<%# Total.AspxUrlShowdetail %>?<%# Total.QueryStringArticleId %>=<%# Eval("id")
    %>" title="<%=pageMetaName %>：<%#Eval("title")%>" target="_blank">
                                        <%#UtilHtml.ImgTitleSubstring(Eval("id").ToString(),
    Eval("title").ToString(), (DateTime)Eval("addtime"))%>
                                    </a>
                                        <samp>
                                            <%# String.Format("{0:MM}-{1:dd}", Eval( "addtime"), Eval( "addtime"))%></samp></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
                <dl class="tbox">
                    <dt><strong><a href="listitem.aspx?class_name=诉讼知识">诉讼知识</a></strong><span class="more"><a
                        href="listitem.aspx?class_name=诉讼知识">更多</a></span></dt>
                    <dd>
                        <ul class="d1 ico3">
                            <asp:Repeater runat="server" ID="RepeaterSszz">
                                <ItemTemplate>
                                    <li><a href="<%# Total.AspxUrlShowdetail %>?<%# Total.QueryStringArticleId %>=<%# Eval("id")
    %>" title="<%=pageMetaName %>：<%#Eval("title")%>" target="_blank">
                                        <%#UtilHtml.ImgTitleSubstring(Eval("id").ToString(),
    Eval("title").ToString(), (DateTime)Eval("addtime"))%>
                                    </a>
                                        <samp>
                                            <%# String.Format("{0:MM}-{1:dd}", Eval( "addtime"), Eval( "addtime"))%></samp></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
                <dl class="tbox">
                    <dt><strong><a href="listitem.aspx?class_name=实用法规">实用法规</a></strong><span class="more"><a
                        href="listitem.aspx?class_name=实用法规">更多</a></span></dt>
                    <dd>
                        <ul class="d1 ico3">
                            <asp:Repeater runat="server" ID="RepeaterSyfg">
                                <ItemTemplate>
                                    <li><a href="<%# Total.AspxUrlShowdetail %>?<%# Total.QueryStringArticleId %>=<%# Eval("id")
    %>" title="<%=pageMetaName %>：<%#Eval("title")%>" target="_blank">
                                        <%#UtilHtml.ImgTitleSubstring(Eval("id").ToString(),
    Eval("title").ToString(), (DateTime)Eval("addtime"))%>
                                    </a>
                                        <samp>
                                            <%# String.Format("{0:MM}-{1:dd}", Eval( "addtime"), Eval( "addtime"))%></samp></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </dd>
                </dl>
            </div>
            <!-- /listbox -->
        </div>
        <uc1:right ID="right" runat="server"></uc1:right>
    </div>
    <uc1:footer ID="footer" runat="server" />
</body>
</html>
<script>

    var speed = 30
    var colee_left2 = document.getElementById("colee_left2");
    var colee_left1 = document.getElementById("colee_left1");
    var colee_left = document.getElementById("colee_left");
    colee_left2.innerHTML = colee_left1.innerHTML
    function Marquee3() {
        if (colee_left2.offsetWidth - colee_left.scrollLeft <= 0)
            colee_left.scrollLeft -= colee_left1.offsetWidth
        else {
            colee_left.scrollLeft++
        }
    }
    var MyMar3 = setInterval(Marquee3, speed)
    colee_left.onmouseover = function () { clearInterval(MyMar3) }
    colee_left.onmouseout = function () { MyMar3 = setInterval(Marquee3, speed) }

</script>
