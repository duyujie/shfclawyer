<%@ Page Language="c#" Inherits="com.hujun64.map" CodeFile="map.aspx.cs" CodeFileBaseClass="com.hujun64.PageBase"
    EnableViewState="false" %>

<%@ Register TagPrefix="uc1" TagName="header" Src="ascx/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top" Src="ascx/top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="right" Src="ascx/right.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="ascx/footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="track" Src="ascx/track.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<!--head区开始位置-->
<head id="Head1" runat="server">
    <meta http-equiv="Content-Language" content="zh-cn">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="keywords" content="地址：上海市恒丰路500号洲际商务16楼 - 近上海火车站（新客站）南广场 地铁1号线、地铁3、4号线" />
    <meta name="description" content="地址：上海市恒丰路500号洲际商务中心16楼 - 近天目西路，上海火车站（新客站）南广场 地铁线路：地铁1号线、地铁3、4号线—上海火车站（步行5分钟） 公交车线路： 13路、63路、64路、95路、104路、106路、109路、113路、223路、234路、301路、324路、506路、584路、768路、801路、802路、822路、837路、844路、845路、927路、930路、941路、 公交专线：隧道三线、机场四线、宝杨码头专线、南新专线、新川专线、新嘉专线、沪唐专线" />
    <link type="text/css" href="css/style.css" rel="stylesheet" />
    <uc1:header ID="header1" runat="server"></uc1:header>
    <title>
        <%="路线地图_" + Total.Title%></title>
</head>
<!--head区结束--位置-->
<body>
    <form id="bodyForm" runat="server">
    <div align="center">
        <table border="0" width="100%" id="table1" cellspacing="0" cellpadding="0">
            <uc1:top ID="top" runat="server"></uc1:top>
            <tr>
                <td background="images/Header2.jpg" style="background-repeat: repeat-x; background-position: top"
                    height="800" valign="top">
                    <div align="center">
                        <table border="0" cellpadding="0" cellspacing="0" width="950" id="table4" height="100%">
                            <tr>
                                <td valign="top" bgcolor="FFFFFF" id="TheLongLine" style="padding-top: 10px;">
                                    <div align="center">
                                        <table border="0" cellpadding="0" cellspacing="0" width="940" id="table10" height="100%">
                                            <tr>
                                                <td valign="top" style="padding-top: 10px;" align="left">
                                                    <table style="width: 100%" class="Content">
                                                        <tr>
                                                            <td class="ModuleTitle" height="40">
                                                                <strong>路线地图</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-top: 20px; background-image: url(Images/ShortLine.jpg); background-repeat: no-repeat;">
                                                                <br />
                                                                <strong>联系方式：</strong><br />
                                                                <span class="style1">
                                                                    <br />
                                                                </span>电 话：021－60561339 <span class="style1">
                                                                    <br />
                                                                </span>手 机：13636542941 <span class="style1">
                                                                    <br />
                                                                </span>邮 箱：hujun64@gmail.com <span class="style1">
                                                                    <br />
                                                                    <a name="#map"></a>
                                                                    <br />
                                                                </span><a name="#map"></a>
                                                                <img alt="" height="350" src="Images/map_yk.gif" width="450" /><br />
                                                                <br />
                                                                <img alt="" height="450" src="Images/building.jpg" width="300" /><br />
                                                                <h4>
                                                                    地址：上海市恒丰路500号洲际商务中心16楼 - 近天目西路，上海火车站（新客站）南广场
                                                                </h4>
                                                                <ul>
                                                                    <li><strong>自驾车：</strong>闸北区恒丰路500号，近天目西路口，洲际商务中心办公楼，地下停车库(10元/小时）</li>
                                                                    <li><strong>地铁线路：</strong>地铁1号线、地铁3、4号线—上海火车站（步行5分钟）</li>
                                                                    <li><strong>公交车线路：</strong>13路、63路、64路、95路、104路、106路、109路、<br />
                                                                        113路、223路、234路、301路、324路、506路、584路、768路、<br />
                                                                        801路、802路、822路、837路、844路、845路、927路、930路、941路、</li>
                                                                    <li><strong>公交专线：</strong>隧道三线、机场四线、宝杨码头专线、南新专线、新川专线、<br />
                                                                        新嘉专线、沪唐专线</li></ul>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="327" valign="top" style="padding-top: 10px;">
                                                    <uc1:right ID="right" runat="server"></uc1:right>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <uc1:footer ID="footer" runat="server" />
    </form>
</body>
</html>
