// JavaScript Document
var s=function(){
var interv=2000; //切换间隔时间
var interv2=40; //切换速速
var opac1=70; //文字背景的透明度
var source="fade_focus" //焦点轮换图片容器的id名称
//获取对象
function getTag(tag,obj){if(obj==null){return document.getElementsByTagName(tag)}else{return obj.getElementsByTagName(tag)}}
function getid(id){return document.getElementById(id)};
var opac=0,j=0,t=63,num,scton=0,timer,timer2,timer3;var id=getid(source);id.removeChild(getTag("div",id)[0]);var li=getTag("li",id);var div=document.createElement("div");var title=document.createElement("div");var span=document.createElement("span");var button=document.createElement("div");button.className="button";for(var i=0;i<li.length;i++){var a=document.createElement("a");a.innerHTML=i+1;a.onclick=function(){clearTimeout(timer);clearTimeout(timer2);clearTimeout(timer3);j=parseInt(this.innerHTML)-1;scton=0;t=63;opac=0;fadeon();};a.className="b1";a.onmouseover=function(){this.className="b2"};a.onmouseout=function(){this.className="b1";sc(j)};button.appendChild(a);}
//控制图层透明度
function alpha(obj,n){if(document.all){obj.style.filter="alpha(opacity="+n+")";}else{obj.style.opacity=(n/100);}}
//控制焦点按钮
function sc(n){for(var i=0;i<li.length;i++){button.childNodes[i].className="b1"};button.childNodes[n].className="b2";}
title.className="num_list";title.appendChild(span);alpha(title,opac1);id.className="d1111";div.className="d2";id.appendChild(div);id.appendChild(title);id.appendChild(button);
//渐显
var fadeon=function(){opac+=5;div.innerHTML=li[j].innerHTML;span.innerHTML=getTag("img",li[j])[0].alt;alpha(div,opac);if(scton==0){sc(j);num=-2;scrolltxt();scton=1};if(opac<100){timer=setTimeout(fadeon,interv2)}else{timer2=setTimeout(fadeout,interv);};}
//渐隐
var fadeout=function(){opac-=5;div.innerHTML=li[j].innerHTML;alpha(div,opac);if(scton==0){num=2;scrolltxt();scton=1};if(opac>0){timer=setTimeout(fadeout,interv2)}else{if(j<li.length-1){j++}else{j=0};fadeon()};}
//滚动文字
var scrolltxt=function(){t+=num;span.style.marginTop=t+"px";if(num<0&&t>3){timer3=setTimeout(scrolltxt,interv2)}else if(num>0&&t<62){timer3=setTimeout(scrolltxt,interv2)}else{scton=0}};
fadeon();
}
//初始化
//window.onload=s;

function showdivs(divname){ 
var div3 = document.getElementById(divname); //将要弹出的层
var div4 = document.getElementById("toplistdivs"); //将要弹出的层
div3.style.display="block"; 
div4.style.width="100%";
div4.style.height="32";
div4.style.display="block";
//div3初始状态是不可见的，设置可为可见 
//window.event代表事件状态，如事件发生的元素，键盘状态，鼠标位置和鼠标按钮状. 
//clientX是鼠标指针位置相对于窗口客户区域的 x 坐标，其中客户区域不包括窗口自身的控件和滚动条。 
//div3.style.left=event.clientX+10; //鼠标目前在X轴上的位置，加10是为了向右边移动10个px方便看到内容 
//div3.style.top=event.clientY+5; 
div3.style.position="absolute"; //必须指定这个属性，否则div3层无法跟着鼠标动

//var div2 =document.getElementById('div2'); 
//div3.innerText=div2.innerHTML; 
} 
//关闭层div3的显示 
function closediv(divname){ 
var div3 = document.getElementById(divname); 
var div4 = document.getElementById("toplistdivs");
div4.style.display="none"; 
div3.style.display="none"; 

}

function winshow(pagename,w,h){
  window.open(pagename,null,"width="+w+",height="+h);
}

function showdiv(names,m,n){
  for (var i=1;i<=n;i++){
    document.getElementById(names+i).style.display="none";
  }
  document.getElementById(names+m).style.display="";
}
