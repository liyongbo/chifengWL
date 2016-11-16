<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="web.Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=11;IE=10;IE=9;IE=8;" />
    <title>物流管理平台</title>
    <link href="/css/PublicStyle.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/js/jquery/json2.js" type="text/javascript"></script>
    <script>document.write("<script type=\"text/javascript\" src=\"/js/commn.js?" + Math.random() + "\"><\/script>"); </script>
    <script src="/js/Plug/layer/layer.js" type="text/javascript"></script>
</head>
<body>
    <!--#include file ="/inc/header.inc"-->
    <!--#include file ="/inc/leftTree.inc"-->
    <div class="ez_mainR ov">
        <div class="ez_InfoBox">
           <iframe id="pl" name="proList" src="/Control/IndexControl.aspx" width="100%" height="600" frameborder="no" border="0" marginwidth="0" marginheight="0" scrolling="no" allowtransparency="yes"></iframe>
        </div>
    </div>

    <div class="mydiv none" id="upPwd">
    <div class="ez_Tbox">
        <div class="ez_InfoTit" id="pwd_title">修改登录密码</div>
        <div class="closd"></div>
        
        <table class="altrowstable" id="alternatecolor">
            <tr>
            	<td id="pwd_username">用户名：</td>
            	<td><input name="username" value="<%=BLL.Base.Host.Instance.UserName %>" readonly  class="inputTxt" disabled="disabled"/></td>
            </tr>
           	<tr>
            	<td id="pwd_password">原密码：</td>
            	<td><input type="password" name="password"  id="input_password" class="inputTxt" placeholder＝"请输入原密码"/></td>
            </tr>
            <tr>
            	<td id="pwd_password1">新密码：</td>
            	<td><input  type="password" name="password1" id="input_password1" class="inputTxt" placeholder＝"请输入新密码"/></td>
            </tr>
            <tr>
            	<td id="pwd_password2">重复新密码：</td>
            	<td><input  type="password" name="password2"  id="input_password2" class="inputTxt" placeholder＝"请重复输入新密码"/></td>
            </tr>
        </table>

        <br />
        <div class="ez_TBtn" style="text-align:center">
            <button type="button" class="ez_btn1" id="changePwd" style="width:110px;margin-right:20px;">保存</button>
        </div>
     	
    </div>

</div>
</body>
</html>
