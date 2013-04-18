<%@ Control Language="C#" AutoEventWireup="true" Inherits="com.hujun64.track" CodeFile="track.ascx.cs" %>
<%@ OutputCache Duration="60000" VaryByParam="*" Shared="True" %>
<!--本站自定义的访客跟踪代码!-->
<script type="text/javascript">
    document.write(unescape("%3Cscript src='<%=statUrl %>" + document.referrer
                     + "' type='text/javascript'%3E%3C/script%3E"));

</script>

<!--CNZZ的跟踪代码!-->
<div class="DivContainer">
    <script type="text/javascript" src="http://s17.cnzz.com/stat.php?id=3880266&web_id=3880266&show=pic"
        language="JavaScript"></script>
</div>
