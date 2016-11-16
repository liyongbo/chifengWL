<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="web.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=11;IE=10;IE=9;IE=8;" />
    <title>物流平台</title>
    <link href="/css/PublicStyle.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/js/jquery/json2.js" type="text/javascript"></script>
    <script>document.write("<script type=\"text/javascript\" src=\"/js/commn.js?" + Math.random() + "\"><\/script>"); </script>
    <script src="/js/Plug/layer/layer.js" type="text/javascript"></script>
    <script src="/js/jquery/validate/jquery.validate.js" type="text/javascript"></script>
    <script src="/js/hy/hy.js" type="text/javascript"></script>
</head>

<body style="background: #267cb7;">
    <div class="wl_login">
        <h1 class="tit">物流平台</h1>
        <form id="form1">
            <div class="box">
                <ul>
                    <li>
                        <input type="text" class="wl_LogInput" id="username" name="username" autocomplete="off" maxlength="25" placeholder="用户名" /></li>
                    <li>
                        <input type="text" class="wl_LogInput" id="password" name="password" autocomplete="off" onfocus="this.type='password'" maxlength="25" placeholder="密码" /></li>
                    <li>
                        <input type="button" class="wl_LogBtn" id="loginBtn" name="loginBtn" value="登  录" /></li>
                </ul>
            </div>
        </form>
    </div>
</body>
</html>

