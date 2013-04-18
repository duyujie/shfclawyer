<%@ Page Language="c#" Inherits="com.hujun64.admin.site_update" CodeFile="site_update.aspx.cs"
    ValidateRequest="false" EnableViewStateMac="false" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>��վ����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta name="robots" content="noindex,follow" />
</head>
<body>
    <form id="FormSiteUpdate" method="post" runat="server">
    
    <table border="1" align="center" width="600" cellpadding="0" cellspacing="0" id="TableSiteUpdate">
        <tr>
            <td colspan="2" align="center">
                <br />
                <h3>
                    ��վ���ݸ���
                </h3>
                <br />
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:DropDownList ID="DropDownlistUpdateSite" runat="server" />
                <asp:Button ID="ButtonRefreshSite" runat="server" Text="���ɾ�̬ҳ��" ForeColor="Red" OnClick="refreshSite_Click"
                   ></asp:Button>
               
            </td>
           
        </tr>
         <tr>
            <td align="left">               
                <asp:Button ID="ButtonRefreshCache" runat="server" Text="ˢ����վ����" ForeColor="Red" OnClick="refreshCache_Click"
                   ></asp:Button>
               
            </td>
           
        </tr>      
        <tr>
            <td align="left">
                
                <asp:Button ID="ButtonIndexUpdate" runat="server" Text="�ؽ���ѯ����" ForeColor="Red" OnClick="updateIndex_Click"
                   ></asp:Button>
               
            </td>
           </tr><tr>
            <td align="left">
                
                <asp:Button ID="ButtonSyncMirror" runat="server" Text="ͬ��������վ" ForeColor="Red" OnClick="ButtonSyncMirror_Click"
                   ></asp:Button>
               
            </td>
           
        </tr>
        </tr><tr>
            <td align="left">
                
                <asp:Button ID="ButtonTest" runat="server" Text="���ܲ���" ForeColor="Red" OnClick="ButtonTest_Click"
                   ></asp:Button>
               
            </td>
           
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="MSG" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <p>
                    ˵����<br />
                    <font face="����">1. �����ܽ���Ժ�̨������Ķ����������ݽ��м�ʱ���£�</font><br />
                    <font face="����">2. ����漰�����½϶࣬��Ҫ�ϳ�ʱ��ȴ��������ĵȺ�</font><br />
                    <font face="����" color="red">3. <b>���·�����վ</b> ��ˢ��������վ�����ݣ���Ҫ�ϳ�ʱ��ȴ��������ĵȺ�</font>
                </p>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <br />
                <h3>
                    �ϴ��ļ�</h3>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:FileUpload ID="myFile" runat="server" name="myFile" size="80" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <font color="red">������Ŀ¼</font>
                <input type="text" id="destFilepath" runat="server" name="destFilepath" size="75"
                    maxlength="200" value="~\uploads\" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <input type="button" value="�� ��" onserverclick="UploadFile" runat="server" id="uploadButton"
                    name="uploadButton" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="MSG_File" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table cellpadding="0" cellspacing="0" border="1">
                    <tr>
                        <td colspan="2">
                            <b>�ļ�����</b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            �ļ��� :
                        </td>
                        <td>
                            <asp:Label ID="fname" Text="" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            �ļ����� :
                        </td>
                        <td>
                            <asp:Label ID="fenc" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            �ļ���С :(in bytes)
                        </td>
                        <td>
                            <asp:Label ID="fsize" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <font color="red">�ͻ���Ϣ�ļ�·��</font>
                <input type="text" id="ClientFilePath" runat="server" name="ClientFilePath" size="75"
                    maxlength="200" value="~\uploads\client.csv" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button Text="����ͻ���Ϣ" OnClick="ImportClientInfo" runat="server" ID="ImportClientInfoButton"
                    name="ImportClientInfoButton"  />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="LabelImport" runat="server"></asp:Label>
            </td>
        </tr>
        <%--<tr>
            <td colspan="2">
            <br />
                 <asp:Button text="���ɾ�ID��html" onclick="CreateOldHtml" runat="server" id="createOldHtmlButton"
                    name="createOldHtmlButton"  OnClientClick="this.disabled=true;this.form.submit();" UseSubmitBehavior="False"/>
            </td>
        </tr>--%>
    </table>
    </form>
</body>
</html>
