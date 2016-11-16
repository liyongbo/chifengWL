<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DestControl.aspx.cs" Inherits="web.Control.DestControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>物流平台</title>
    <link href="/css/PublicStyle.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/js/jquery/json2.js" type="text/javascript"></script>
    <script src="/js/pages.js" type="text/javascript"></script>
    <script>document.write("<script type=\"text/javascript\" src=\"/js/commn.js?" + Math.random() + "\"><\/script>"); </script>

</head>

<body>
    <div class="ez_InfoTit">目的地信息</div>
    <div class="ez_khtab">
        <div class="ez_searchTop ">
            <input placeholder="请输入您要搜索的目的地或车主" />
            <input type="button" value="搜索" class="ez_btn1" style="width: 75px; height: 34px; text-align: center; background: #267cb7; color: #fff;" />
        </div>
        <div class="ez_khoper w3">
            <button type="submit" class="ez_btn1" id="newBtn" style="width: 75px;">新增</button>
        </div>
        <table class="altrowstable" id="alternatecolor">
            <tr>
                <th>目的地</th>
                <th>车主姓名</th>
                <th>联系方式</th>
                <th>用户名</th>
                <th>密码</th>
                <th>年龄</th>
                <th>性别</th>
                <th>家庭住址</th>
                <th>紧急联系方式</th>
                <th>开户行</th>
                <th>银行账号</th>
                <th>备注</th>
                <th>操作</th>
            </tr>
            <%if (destList != null && destList.Count > 0)
                {
                    for (int i = 0; i < destList.Count; i++)
                    {
            %>
            <tr>
                <td><%=destList[i].destName %></td>
                <td><%=destList[i].ownname %></td>
                <td><%=destList[i].tel %></td>
                <td><%=destList[i].username %></td>
                <td><%=destList[i].userpassword %></td>
                <td><%=destList[i].age %></td>
                <td><%=destList[i].sex == 1 ? "男" : "女" %></td>
                <td><%=destList[i].address %></td>
                <td><%=destList[i].emergency %></td>
                <td><%=destList[i].bank %></td>
                <td><%=destList[i].bankcard %></td>
                <td title="<%=destList[i].comment %>"><%=Tools.Utils.GetSubString(destList[i].comment, 10, "...") %></td>
                <td><a href="javascript:showPop();">修改</a> | <a href="#">删除</a></td>
            </tr>
            <%
                    }
                } %>
        </table>

        <p class="Accord">每页显示 <%=pagesize %> 条，共 <%=rCount % pagesize > 0 ? (rCount / pagesize + 1) : (rCount / pagesize)%> 页，总计 <%=rCount %> 条</p>

    </div>
</body>
</html>
<script type="text/javascript">
    $(function () {
        $(".ez_khtab").append(new pages(0, 0, 0, 0, 0, "inline", "checked", "unable", <%=5%>,<%=pageindex%>, null, <%=rCount%pagesize>0?(rCount/pagesize +1):rCount/pagesize %>,<%=rCount%>, "DestControl.aspx?p=").init());
        //新增目的地信息-弹框
        $("#newBtn").click(function () {
            window.parent.layer.open({
                type:0,
                title: false,
                area: ['90%', 'auto'],
                shadeClose: true,
                btn:false,
                content: $('#popDiv').html(),
                success: function(layero, index){
                    initEvent();
                }
            });
        });

        function initEvent(){
            //修改保存
            var $ = window.parent.$;
            var layer = window.parent.layer;
            $("#btn_save").click(function(){
                if ($.trim($("#box_dest").val()) == "")
                {
                    layer.tips("请输入目的地", $("#box_dest"), { tips: [4, '#0FA6D8'] });
                    return false;
                }
                if ($.trim($("#box_carname").val()) == "")
                {
                    layer.tips("请输入车主姓名", $("#box_carname"), { tips: [4, '#0FA6D8'] });
                    return false;
                }
                if ($.trim($("#box_tel").val()) == "")
                {
                    layer.tips("请输入联系方式", $("#box_tel"), { tips: [4, '#0FA6D8'] });
                    return false;
                }
                if ($.trim($("#box_username").val()) == "")
                {
                    layer.tips("请输入用户名", $("#box_username"), { tips: [4, '#0FA6D8'] });
                    return false;
                }
                if ($.trim($("#box_password").val()) == "")
                {
                    layer.tips("请输入密码", $("#box_password"), { tips: [4, '#0FA6D8'] });
                    return false;
                }
                if ($.trim($("#box_age").val()) == "")
                {
                    layer.tips("请输入年龄", $("#box_age"), { tips: [4, '#0FA6D8'] });
                    return false;
                }
                if ($.trim($("#box_address").val()) == "")
                {
                    layer.tips("请输入家庭住址", $("#box_address"), { tips: [4, '#0FA6D8'] });
                    return false;
                }
                if ($.trim($("#box_emergency").val()) == "")
                {
                    layer.tips("请输入紧急联系方式", $("#box_emergency"), { tips: [4, '#0FA6D8'] });
                    return false;
                }
                if($("#box_bank").val() == 0)
                {
                    layer.tips("请选择开户行", $("#box_bank"), { tips: [4, '#0FA6D8'] });
                    return false;
                }
                if ($.trim($("#box_bankcard").val()) == "")
                {
                    layer.tips("请输入银行账号", $("#box_bankcard"), { tips: [4, '#0FA6D8'] });
                    return false;
                }
                var loading = layer.load(0, { shade: [0.1] });
                var param = {
                    box_dest : $("#box_dest").val(),
                    box_carname : $("#box_carname").val(),
                    box_tel : $("#box_tel").val(),
                    box_username : $("#box_username").val(),
                    box_password : $("#box_password").val(),
                    box_age : $("#box_age").val(),
                    box_address : $("#box_address").val(),
                    box_emergency : $("#box_emergency").val(),
                    box_bank : $("#box_bank").val(),
                    box_bankcard : $("#box_bankcard").val(),
                    box_comment : $("#box_comment").val(),
                    destid : $(this).attr("destid")
                };

                runws("updateDest",param,function(data){
                    
                });
            });
        }

    });
</script>

<div class="mydiv none" id="popDiv">
    <div class="ez_Tboxdiv">
        <div class="ez_InfoTit">新增目的地信息</div>
        <table class="altrowstable">
            <tr>
                <th id="header_dest">目的地</th>
                <th id="header_carname">车主姓名</th>
                <th id="header_tel">联系方式</th>
                <th id="header_username">用户名</th>
                <th id="header_password">密码</th>
                <th id="header_age">年龄</th>
                <th id="header_gender">性别</th>
            </tr>
            <tr>
                <td>
                    <input type="text" name="dest" class="wl_Input" id="box_dest" placeholder="必填" /></td>
                <td>
                    <input type="text" name="carname" class="wl_Input" id="box_carname" placeholder="必填" /></td>
                <td>
                    <input type="text" name="tel" class="wl_Input" id="box_tel" placeholder="必填" /></td>
                <td>
                    <input type="text" name="username" class="wl_Input" id="box_username" placeholder="必填" /></td>
                <td>
                    <input type="text" name="password" class="wl_Input" id="box_password" placeholder="必填" /></td>
                <td>
                    <input type="text" name="age" class="wl_Input" id="box_age" placeholder="必填" /></td>

                <td>
                    <label style="float: left; width: 100%;">
                        <input type="radio" name="gender" id="box_gender1" value="1" checked="checked" />
                        男&nbsp;&nbsp;
                        <input type="radio" name="gender" id="box_gender2" value="0" />
                        女
                    </label>
                </td>

            </tr>
        </table>
        <br />
        <br />
        <br />
        <table class="altrowstable">
            <tr>
                <th id="header_address">家庭住址</th>
                <th id="header_emergency">紧急联系方式</th>
                <th id="header_bank">开户行</th>
                <th id="header_bankcard">银行账号</th>
                <th id="header_comment">备注</th>
            </tr>
            <tr>
                <td>
                    <input type="text" name="address" class="wl_Input" id="box_address" placeholder="必填" /></td>
                <td>
                    <input type="text" name="emergency" class="wl_Input" id="box_emergency" placeholder="必填" /></td>
                <td>
                    <select name="bank" id="box_bank">
                        <option value="0">请选择...</option>
                    </select>&nbsp;
                	<a href="javascript:void(0)" onclick="createBank()">新建银行</a>
                </td>
                <td>
                    <input type="text" name="bankcard" class="wl_Input" id="box_bankcard" placeholder="必填" /></td>
                <td>
                    <input type="text" name="comment" class="wl_Input" id="box_comment" placeholder="选填" /></td>
            </tr>
        </table>

        <div class="ez_TBtn" style="text-align: center">
            <button type="button" id="btn_save" class="ez_btn1" style="width: 110px; margin-right: 20px;" destid="">保存</button>
        </div>
    </div>
</div>
