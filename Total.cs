using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using com.hujun64.util;

namespace com.hujun64
{
    /// <summary>
    /// Total ��ժҪ˵����
    /// </summary>
    public class Total
    {
        private Total()
        {
        }
        public static readonly bool IsMirrorSite = Convert.ToBoolean(ConfigurationManager.AppSettings["isMirrorSite"]);//�Ƿ�����վ
        public static readonly bool IsSyncMirror = Convert.ToBoolean(ConfigurationManager.AppSettings["isSyncMirror"]);//�Ƿ���Ҫͬ������
        public static readonly bool IsFullSiteurl = Convert.ToBoolean(ConfigurationManager.AppSettings["isFullSiteurl"]);//ҳ���е����ӵ�ַ�Ƿ���ȫ·��
        public static readonly bool IsCacheArticleContent = Convert.ToBoolean(ConfigurationManager.AppSettings["isCacheArticleContent"]);//�Ƿ񻺴���������
        public static readonly bool IsCacheGuestbookContent = Convert.ToBoolean(ConfigurationManager.AppSettings["isCacheGuestbookContent"]);//�Ƿ񻺴���ѯ����
        public static readonly bool IsStaticToHtml = Convert.ToBoolean(ConfigurationManager.AppSettings["isStaticToHtml"] == null ? "false" : ConfigurationManager.AppSettings["isStaticToHtml"]);//�Ƿ�̬��
       


        public static readonly string MonitorUrl = ConfigurationManager.AppSettings["monitorUrl"];//�����վ��ַ      
        public static readonly string SiteName = ConfigurationManager.AppSettings["sitename"];//��վ����             
        public static readonly string SiteUrl = ConfigurationManager.AppSettings["siteurl"];//��վ��ַ      
        public static readonly string[] SiteIpArray = ConfigurationManager.AppSettings["siteip"].Split(',');//��վIP��ַ
        public static readonly string Logo = ConfigurationManager.AppSettings["logo"];//��վLogo
        public static readonly string LinkLogo = ConfigurationManager.AppSettings["linklogo"];//��վ��������ͼ��
        public static readonly bool EnableCGW = Convert.ToBoolean(ConfigurationManager.AppSettings["enableCGW"]);//�Ƿ��������д��������
        public static readonly string Author = ConfigurationManager.AppSettings["author"];//��վ����
        public static readonly string Mobile = ConfigurationManager.AppSettings["mobile"];//�ֻ�
        public static readonly string Mobile2 = ConfigurationManager.AppSettings["mobile2"];//�ֻ�2
        public static readonly string Tel = ConfigurationManager.AppSettings["tel"];//�̻�
        public static readonly string Qq = ConfigurationManager.AppSettings["qq"];//QQ��
        public static readonly string Msn = ConfigurationManager.AppSettings["msn"];//MSN
        public static readonly string Email = ConfigurationManager.AppSettings["email"];//�ʼ�        
        public static readonly string Fax = ConfigurationManager.AppSettings["fax"];//����

        public static readonly string AddressWorkday = ConfigurationManager.AppSettings["addressWorkday"];//�����յ�ַ
        public static readonly string AddressWeekend = ConfigurationManager.AppSettings["addressWeekend"];//��ĩ��ַ
        public static readonly string NearbyWorkday = ConfigurationManager.AppSettings["nearbyWorkday"];//�����յ�ַ����
        public static readonly string NearbyWeekend = ConfigurationManager.AppSettings["nearbyWeekend"];//��ĩ��ַ����
        public static readonly string Office = ConfigurationManager.AppSettings["office"];//������
        public static readonly string OfficeUrl = ConfigurationManager.AppSettings["officeUrl"];//��������վ
        public static readonly string OfficeIntro = ConfigurationManager.AppSettings["officeIntro"];//����������
        public static readonly string Sn = ConfigurationManager.AppSettings["sn"];//ִҵ֤��
        public static readonly string Zipcode = ConfigurationManager.AppSettings["zipcode"];//�ʱ�
        public static readonly string Description = ConfigurationManager.AppSettings["description"];//��վ����
        public static readonly string Profile = ConfigurationManager.AppSettings["profile"];//��������
        public static readonly string FeeTitle = ConfigurationManager.AppSettings["feeTitle"];//��������
        public static readonly string PageMetaXml = ConfigurationManager.AppSettings["pageMetaXml"];//��������
        public static readonly int RefreshSleepTime = Convert.ToInt32(ConfigurationManager.AppSettings["refreshSleepTime"]);




        public static readonly string AdminMail = ConfigurationManager.AppSettings["adminmail"];//վ������
        public static readonly string AdminMailUser = ConfigurationManager.AppSettings["mailuser"];//վ�������¼�û�
        public static readonly string AdminMailPasswd = ConfigurationManager.AppSettings["mailpasswd"];//վ�������¼����
        public static readonly string SmtpServerHost = ConfigurationManager.AppSettings["smtpServerHost"];
        public static readonly int SmtpServerPort = Convert.ToInt32(ConfigurationManager.AppSettings["smtpServerPort"]);
        public static readonly bool SmtpServerEnableSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["smtpServerEnableSSL"]);
        public static readonly string Copyright = ConfigurationManager.AppSettings["copyright"];//��Ȩ
        public static readonly string Title = ConfigurationManager.AppSettings["title"];//����
        public static readonly string Keywords = ConfigurationManager.AppSettings["keywords"];//�����ؼ���

        public static string PhysicalRootPath = ConfigurationManager.AppSettings["physicalRootPath"];//����Ŀ¼����·��
        public static readonly string Sitemap = ConfigurationManager.AppSettings["Sitemap"];//Sitemap
        public static readonly string BeianUrl = ConfigurationManager.AppSettings["beianUrl"];//�����ٷ���վ��ַ
        public static readonly string BeianNumber = ConfigurationManager.AppSettings["beianNumber"];//������
        public static readonly string CnzzWebsiteId = ConfigurationManager.AppSettings["cnzzWebsiteId"];//CNZZע��ID��
        public static readonly string AspxUrlOriginalLawyerSearch = ConfigurationManager.AppSettings["originalLawyerSearchUrl"];//��ʦ��������URL����


        //public static string DbConnectString = ConfigurationManager.AppSettings["dbConnectionString"];
        //public static string BackupDbConnectString = ConfigurationManager.AppSettings["backupDbConnectionString"];

        public static readonly string WebxmlUserId = ConfigurationManager.AppSettings["cn.com.webxml.www.userId"];//http://www.webxml.com.cn��ע���û���
        public static readonly string SmsUsername = ConfigurationManager.AppSettings["smsUsername"];//���ŷ���ע���û���
        public static readonly string SmsPassword = ConfigurationManager.AppSettings["smsPassword"];//���ŷ�������

        public static readonly bool EnableWSProxy = Convert.ToBoolean(ConfigurationManager.AppSettings["enableWSProxy"]);//�Ƿ�����WebService�Ĵ��������
        public static readonly string WSProxyHost = ConfigurationManager.AppSettings["WSProxyHost"];//WebService�Ĵ��������
        public static readonly string WSProxyUserDomain = ConfigurationManager.AppSettings["WSProxyUserDomain"];//WebService�Ĵ���������û�
        public static readonly string WSProxyUserName = ConfigurationManager.AppSettings["WSProxyUserName"];//WebService�Ĵ���������û�
        public static readonly string WSProxyPassword = ConfigurationManager.AppSettings["WSProxyPassword"];//WebService�Ĵ������������

        public static readonly int ExpiresNewArticle = Convert.ToInt32(ConfigurationManager.AppSettings["expiresNewArticle"]);
        public static readonly int ExpiresNewGuestbook = Convert.ToInt32(ConfigurationManager.AppSettings["expiresNewGuestbook"]);
        public static readonly int ExpiresLog = Convert.ToInt32(ConfigurationManager.AppSettings["expiresLog"]);
        public static readonly double TimerInterval = Convert.ToDouble(ConfigurationManager.AppSettings["timerInterval"]);//����
        public static readonly string[] RefreshSiteHoursArray = ConfigurationManager.AppSettings["refreshSiteHours"].Split(',');





        public static readonly string ErrorPage = "~/error.aspx";


        public static readonly string AspxUrlIndex = "index.aspx";
        public static readonly string AspxUrlShowdetail = "news_show.aspx";
        public static readonly string AspxUrlGuestbook = "guestbook.aspx";
        public static readonly string AspxUrlGuestAsk = "guestask.aspx";
        public static readonly string AspxUrlBuilding = "building.aspx";
        public static readonly string AspxUrlIntro = "intro.aspx";
        public static readonly string AspxUrlFee = "fee.aspx";
        public static readonly string AspxUrlModule = "listitem.aspx";
        public static readonly string AspxUrlBigClass = "listclass.aspx";
        public static readonly string AspxUrlSmallClass = "listclass.aspx";
        public static readonly string AspxUrlSearch = "result.aspx";
        public static readonly string AspxUrlLinkAll = "linkall.aspx";
        public static readonly string AspxUrlLinkApp = "linkapp.aspx";
        public static readonly string AspxUrlFrameFlzx = "frame_flzx.aspx";
        public static readonly string AspxUrlFrameTodaytips = "frame_todaytips.aspx";
        public static readonly string AspxUrlFrameHeader = "frame_header.aspx";
        public static readonly string AspxUrlFrameFooter = "frame_footer.aspx";
        public static readonly string AspxUrlFrameDropdownMenu = "dropdown_menu.aspx";
        public static readonly string AspxUrlAsyncTask = "asynctask.aspx";
        public static readonly string AspxUrlWebService = "webservice.aspx";
        public static readonly string AspxUrlStat = "stat.aspx";
        public static readonly string AspxUrlStatClick = "statclick.aspx";
        public static readonly string AspxUrlCnzzStat = ConfigurationManager.AppSettings["cnzzServer"] + "/stat.php?id=" + CnzzWebsiteId + "&web_id=" + CnzzWebsiteId + "&show=pic";
        public static readonly string AspxUrlSearchGoogle = "http://www.google.com/search?hl=zh-CN&newwindow=1&safe=strict&q=site:" + UtilHtml.GetSite(SiteUrl);
        public static readonly string AspxUrlSearchBaidu = "http://www.baidu.com/s?wd=site:" + UtilHtml.GetSite(SiteUrl);


        public static readonly string HtmlUrlIndex = UtilHtml.ReplaceAspxWithHtml(AspxUrlIndex);
        public static readonly string HtmlUrlShowdetail = UtilHtml.ReplaceAspxWithHtml(AspxUrlShowdetail);
        public static readonly string HtmlUrlGuestbook = UtilHtml.ReplaceAspxWithHtml(AspxUrlGuestbook);
        public static readonly string HtmlUrlGuestAsk = UtilHtml.ReplaceAspxWithHtml(AspxUrlGuestAsk);
        public static readonly string HtmlUrlBuilding = UtilHtml.ReplaceAspxWithHtml(AspxUrlBuilding);
        public static readonly string HtmlUrlIntro = UtilHtml.ReplaceAspxWithHtml(AspxUrlIntro);
        public static readonly string HtmlUrlFee = UtilHtml.ReplaceAspxWithHtml(AspxUrlFee);
        public static readonly string HtmlUrlModule = UtilHtml.ReplaceAspxWithHtml(AspxUrlModule);
        public static readonly string HtmlUrlBigClass = UtilHtml.ReplaceAspxWithHtml(AspxUrlBigClass);
        public static readonly string HtmlUrlSmallClass = UtilHtml.ReplaceAspxWithHtml(AspxUrlSmallClass);
        public static readonly string HtmlUrlSearch = UtilHtml.ReplaceAspxWithHtml(AspxUrlSearch);
        public static readonly string HtmlUrlLinkAll = UtilHtml.ReplaceAspxWithHtml(AspxUrlLinkAll);
        public static readonly string HtmlUrlLinkApp = UtilHtml.ReplaceAspxWithHtml(AspxUrlLinkApp);
        public static readonly string HtmlUrlFrameFlax = UtilHtml.ReplaceAspxWithHtml(AspxUrlFrameFlzx);
        public static readonly string HtmlUrlFrameTodaytips = UtilHtml.ReplaceAspxWithHtml(AspxUrlFrameTodaytips);
        public static readonly string HtmlUrlAsyncTask = UtilHtml.ReplaceAspxWithHtml(AspxUrlAsyncTask);
        public static readonly string HtmlUrlWebService = UtilHtml.ReplaceAspxWithHtml(AspxUrlWebService);
        public static readonly string HtmlUrlStat = UtilHtml.ReplaceAspxWithHtml(AspxUrlStat);
        public static readonly string HtmlUrlStatClick = UtilHtml.ReplaceAspxWithHtml(AspxUrlStatClick);

        public static readonly List<string> ServerIpList = HardwareInfo.GetIpAddress();
        public static bool IsDefinedServer = false;
        public static string CurrentSiteUrl = null;
        public static string CurrentSiteRootUrl = null;//���ܴ�����Ŀ¼
        public static string ApplicationPath = null;
        public static string SiteId = null;

        public static readonly string HttpHeaderUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 2.0.50727)";

        public static readonly string HtmlPath = "html";
        public static readonly string IndexPath = "~/index";


        public static string CGWFileapth = "cgw/cgw.txt";


        public static readonly System.Text.Encoding EncodingDefault = Encoding.GetEncoding("gb2312");





        public static readonly int CookieExpiresDays = 365;
        public static readonly string IdFormatString = "000000";

        public static readonly int PageSizeDefault = 20;
        public static readonly int PageSizeGuestbook = 20;
        public static readonly int PageSizeListitem = 20;

        public static readonly int MaxSmsMsgSize = 70; //����������������
        public static readonly int MaxSmsMobileSize = 100; //Ⱥ���ֻ���Ŀ����

        public static readonly int MaxSearchResultSize = 50; //���������¼������

        public static readonly int MaxRowsIndexImageArticle = 4;
        public static readonly int MaxRowsIndexAllArticle = 10;
        public static readonly int MaxRowsIndexHot = 10;
        public static readonly int MaxRowsListClass = 8;
        public static readonly int MaxRowsIndexFlzx = 10;
        public static readonly int MaxRowsIndexSszz = 5;
        public static readonly int MaxRowsIndexSszzIndex = 8;
        public static readonly int MaxRowsIndexBasj = 5;
        public static readonly int MaxRowsIndexFee = 5;
        public static readonly int MaxRowsIndexIntro = 10;
        public static readonly int MaxRowsIndexPfzs = 8;
        public static readonly int MaxRowsIndexCyws = 5;


        public static readonly string ImgModuleTitleUrl = "<img src=\"images/titleno.JPG\" style=\"border-style: none; vertical-align: middle;width:20px;height:18px;\"/>";
        public static readonly string ImgModuleTitleGreenUrl = "<img src=\"images/arr7.gif\"/>";
        public static readonly string ImgMoreUrl = "images/more.gif";
        public static readonly string ImgNewUrl = "images/new1.gif";
        public static readonly string ImgProfileUrl = "images/profile.gif";
        public static readonly string ImgWriteGuestbookUrl = "images/reg.gif";
        public static readonly string ImgAddressWorkdayUrl = "images/hl_address.jpg";
        public static readonly string ImgAddressWeekendUrl = "images/sq_address.jpg";


        public static readonly string BannerFocusUrl = UtilHtml.BuildHref(AspxUrlIntro, UtilHtml.GetFullImageUrl(@"images/banner_focus.gif", "��ע����Ⱥ��άȨ��www.hujun64.com �Ϻ����B��ʦά������Ȩ�棡", "580px", "60px"), Title);
        public static readonly string BannerHorseUrl = UtilHtml.BuildHref(AspxUrlIntro, UtilHtml.GetFullImageUrl(@"images/banner_horse.gif", "������ף������ɡ�www.hujun64.com �Ϻ����B��ʦά������Ȩ�棡", "580px", "60px"), Title);
        public static readonly string BannerCommonaltyUrl = UtilHtml.BuildHref(AspxUrlIntro, UtilHtml.GetFullImageUrl(@"images/banner_commonalty.gif", "�ܰ���֮�У���������ʦ�� www.hujun64.com �Ϻ����B��ʦά������Ȩ�棡", "580px", "60px"), Title);
        public static readonly string BannerProfessionalUrl = UtilHtml.BuildHref(AspxUrlIntro, UtilHtml.GetFullImageUrl(@"images/banner_professional.gif", "��Ϊרҵ������׿Խ������ʦרע������������ www.hujun64.com �Ϻ����B��ʦά������Ȩ�棡", "580px", "60px"), Title);
        public static readonly string BannerNoMatterUrl = UtilHtml.BuildHref(AspxUrlIntro, UtilHtml.GetFullImageUrl(@"images/banner_nomatter.gif", "���²����£����²����¡�www.hujun64.com �Ϻ����B��ʦά������Ȩ�棡", "580px", "60px"), Title);
        public static readonly string BannerHireUrl = UtilHtml.BuildHref(AspxUrlIntro, UtilHtml.GetFullImageUrl(@"images/banner_hirelawyer.gif", "Ƹ����ʦ�������������ģ�άȨ���跨�ɡ�www.hujun64.com �Ϻ����B��ʦά������Ȩ�棡", "580px", "60px"), Title);
        public static readonly string BannerRespectUrl = UtilHtml.BuildHref(AspxUrlIntro, UtilHtml.GetFullImageUrl(@"images/banner_respect.gif", "����ʦ֮ҵ��������֮�¡�������֮��������֮����www.hujun64.com �Ϻ����B��ʦά������Ȩ�棡", "580px", "60px"), Title);
        public static readonly string BannerObjectUrl = UtilHtml.BuildHref(AspxUrlIntro, UtilHtml.GetFullImageUrl(@"images/banner_object_blue.gif", "��ά��ί���˵ĺϷ�����Ϊ��ְ���Թ��ί���˵ķ��ɷ���ΪĿ�ꡣwww.hujun64.com �Ϻ����B��ʦά������Ȩ�棡", "580px", "60px"), Title);




        public static readonly string SplitMyLocation = " -> ";
        public static readonly string SplitTitle = "-";
        public static readonly string PrefixArticleId = "A";
        public static readonly string PrefixGuestbookId = "G";
        public static readonly string PrefixLinkId = "L";
        public static readonly string PrefixVisitId = "V";
        public static readonly string PrefixClientId = "C";
        public static readonly string PrefixArticlePictureId = "P";
        public static readonly string PrefixCgwWordsId = "CGW";

        public static readonly string DivIdContent = "articleContent";
        public static readonly string DivDefaultClassContent = "defaultContent";
        public static readonly string DivDefinedClassContent = "definedContent";

        public static readonly string ModuleNameIndex = "��ҳ";
        public static readonly string ModuleNameFzrd = "�����ȵ�";
        public static readonly string ModuleNameJdal = "���䰸��";
        public static readonly string ModuleNameSyfg = "ʵ�÷���";
        public static readonly string ModuleNameGrsb = "�������";
        public static readonly string ModuleNameSszz = "��������";
        public static readonly string ModuleNameBasj = "�참�ּ�";
        public static readonly string ModuleNameLsjs = "��ʦ����";
        public static readonly string ModuleNameCyws = "��������";
        public static readonly string ModuleNameFlzx = "������ѯ";
        public static readonly string ModuleNameFlzs = "����֪ʶ";
        public static readonly string ModuleNameSfbz = "�շѱ�׼";
        public static readonly string ModuleNameYqlj = "��������";
        public static readonly string ModuleNameSqyqlj = "������������";
        public static readonly string ModuleNameGywm = "��������";


        public static readonly string BigClassNameJjfc = "���÷�����";
        public static readonly string BigClassNameLhjc = "���̳���";
        public static readonly string BigClassNameRssh = "��������";
        public static readonly string BigClassNameGsld = "�����Ͷ���";

         
        public static readonly string ModuleNameXwkf = "���ſ���";
        public static readonly string ModuleNameTpxw = "ͼƬ����";
        public static readonly string ModuleNameFwmm = "��������";
        public static readonly string ModuleNameZldy = "���޵�Ѻ";
        public static readonly string ModuleNameLhjc = "���̳�";
        public static readonly string ModuleNameCqaz = "��Ǩ����";
        public static readonly string ModuleNameWygl = "��ҵ����";
        public static readonly string ModuleNameFwqs = "����Ȩ��";
        public static readonly string ModuleNameShpc = "���⳥"; 
        public static readonly string ModuleNameJskf = "���迪��";
        public static readonly string ModuleNameLsbw = "��ʦ����";

        public static List<string> IndexModuleClassIncludeBigClassNameList = new List<string>();

        public static readonly string BigClassNameYasf = "�԰�˵��";
        public static readonly string BigClassNameFlkt = "���ɿ���";
        public static readonly string BigClassNameFgjd = "������";

        public static readonly string ContactWorkdayArticleTitle = "��ϵ��ʽ";
        public static readonly string ContactWeekendArticleTitle = "��ϵ��ʽ����ĩ��";
        public static readonly string ByOriginal = "��վԭ��";
        public static readonly string LawyerHujun = "���B��ʦ";



        public static readonly string QueryStringModuleClassId = "module_id";
        public static readonly string QueryStringBigClassId = "big_id";
        public static readonly string QueryStringSmallClassId = "small_id";
        public static readonly string QueryStringArticleId = "nid";
        public static readonly string QueryStringDeletedArticleId = "dnid";
        public static readonly string QueryStringFeeId = "fid";
        public static readonly string QueryStringIntroId = "iid";
        public static readonly string QueryStringGuestbookId = "gid";
        public static readonly string QueryStringAction = "action";
        public static readonly string QueryStringRefreshType = "refreshType";
        public static readonly string QueryStringReferrer = "referrer";


        public static readonly string CONVERTING_CONFIG = "CONVERTING_CONFIG";

        static Total()
        {
            //Profile = Profile.Replace("�Ϻ�������ʦ", "<a href=\"http://www.shfclawyer.com\" title='�Ϻ�������ʦ' target=\"_blank\"><font color=\"blue\">�Ϻ�������ʦ</font></a>")
            //.Replace("�Ϻ���ʦ", "<a href=\"http://www.hujun64.com\" title='�Ϻ���ʦ' target=\"_blank\"><font color=\"blue\">�Ϻ���ʦ</font></a>");
            
            IndexModuleClassIncludeBigClassNameList.Add(ModuleNameFwmm);
            IndexModuleClassIncludeBigClassNameList.Add(ModuleNameZldy);
            IndexModuleClassIncludeBigClassNameList.Add(ModuleNameLhjc);
            IndexModuleClassIncludeBigClassNameList.Add(ModuleNameCqaz);
            IndexModuleClassIncludeBigClassNameList.Add(ModuleNameFwqs);
            //IndexModuleClassIncludeBigClassNameList.Add(ModuleNameShpc);    
            IndexModuleClassIncludeBigClassNameList.Add(ModuleNameWygl);           
            //IndexModuleClassIncludeBigClassNameList.Add(ModuleNameJskf);
        }
    }



}
