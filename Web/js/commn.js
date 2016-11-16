$(function () {
    //样式名为ghbs的表格隔行变色
    $.each($(".altrowstable").find("tr"), function (index, model) { $(model).addClass((index % 2 == 0 ? "evenrowcolor" : "oddrowcolor")); });

    //下拉文本框
    $(".xlg").click(function () {
        var _this = $(this).find("div");
        $(".xlg").find("div").not(_this).addClass("none");
        _this.toggleClass("none");
    });
    $.each($(".xlg"), function (index, model) { $(this).css("z-index", (999 - index)); });

    //树形菜单控制
    $(".ez_mainL > ul > li > a").click(function () {
        $(".ez_mainL ul li ul").not($(this).next()).slideUp();
        $(this).next().slideDown();
    });

    $(".contentUrl").click(function () {
        $("#pl").attr("src", $(this).attr("url"));
    });

    //修改密码-弹框
    $("#upPwdBtn").click(function () {
        layer.open({
            type: 1,
            title: false,
            area: ['800px', '400px'],
            shadeClose: true,
            content: $('#upPwd'),
            end: function () {
                $("#input_password").val("");
                $("#input_password1").val("");
                $("#input_password2").val("");
            }
        });
    });

    //修改密码-保存
    $("#changePwd").click(function () {
        if ($.trim($("#input_password").val()) == "")
        {
            layer.tips("请输入原密码", $("#input_password"), { tips: [4, '#0FA6D8'] });
            return false;
        }
        if ($.trim($("#input_password1").val()) == "") {
            layer.tips("请输入新密码", $("#input_password1"), { tips: [4, '#0FA6D8'] });
            return false;
        }
        if ($.trim($("#input_password2").val()) == "") {
            layer.tips("请重复输入新密码", $("#input_password2"), { tips: [4, '#0FA6D8'] });
            return false;
        }
        if ($("#input_password1").val() != $("#input_password2").val()) {
            layer.tips("两次输入密码不一致，请重新输入", $("#input_password2"), { tips: [4, '#0FA6D8'] });
            return false;
        }
        var loading = layer.load(0, { shade: [0.1] });
        runws("updatePwd", { oPwd: $("#input_password").val(), userPwd: $("#input_password2").val() }, function (data) {
            layer.close(loading);
            if (data.d == true) {
                layer.msg('修改成功，请重新登陆', { icon: 6 }, function () { location.href = "/Logout.aspx"; });
            }
            else {
                layer.msg('修改失败，原密码不正确', { icon: 5 });
            }
        });
    });

});