﻿var alllogin_type = 0; //0帐号 1email 手机 2快速注册(目前弹出用)
var errors = false;
function custtomlogin(obFormID) {
    initlogin(obFormID, false);
}
//快速登录
function custtomlogin(obFormID,isback) {
    initlogin(obFormID, isback);
}
function initlogin(obFormID, isbackcurrentapage, bakfun) {
    var obform = $('#' + obFormID);

    $(obform).validate({
        debug: true,
        rules: {
            username: {
                required: true
            },
            password: {
                required: true
            }
        },
        messages: {
            username: {
                required: "请输入用户名"
            },
            password: {
                required: "请输入密码"
            }
        },
        errorPlacement: function (error, element) {
            if (error.text().length > 0) {
                layer.tips(error.text(), element, {
                    tips: [4, '#0FA6D8'],//还可配置颜色
                    tipsMore: true //多个
                });
            }
        },
        success: function (label) {

        },
        submitHandler: function (form) {

            var apram = $(form).serializeArray();
            //快速登录
            var obpram = { login_username: "", login_pwd: "", login_formurl: "" };

                for (var i = 0; i < apram.length; i++) {

                    switch (apram[i].name) {       
                        case "username":
                            obpram.login_username = apram[i].value;
                            break;
                        case "password":
                            obpram.login_pwd = apram[i].value;
                            break;      
                    }
                }
                
                if (isbackcurrentapage) {
                    obpram.login_formurl = location.href;
                } else {
                    obpram.login_formurl = GetLoginUrl("ru");
                }

                obpram.login_type = 0;

                var loadi = layer.load(0, { shade: [0.1] });

                runws("LoginUser", obpram, function (rz) {
                    layer.close(loadi);
                    var msg = rz.d;

                    if (msg.Success) {
                        $("#requesttips").hide();
                        if (bakfun == null || bakfun == undefined) {

                            if (obpram.login_formurl != null && obpram.login_formurl != undefined && obpram.login_formurl != "") {
                                location.href = obpram.login_formurl;
                            }
                            else {
                                layer.msg('登陆成功', { icon: 6 }, function () { location.href = msg.Message; });
                            }
                        } else
                            bakfun(msg.Data);
                    }
                    else {
                        layer.tips("登录发生错误:" + msg.Message, $("#username"),{
                            tips: [4, '#0FA6D8']
                        });
                    }


                });

            $("#btnLoginUser").attr("disabled", "disabled");

        }

    });


}


//获取url?号后的参数
function GetLoginUrl(ParamName) {
    return document.location.search.substr(1).replace(ParamName + "=", "");
}

function GetLogin_Type(semailmobile) {

    if (alllogin_type == 0) {
        return alllogin_type;
    }
    else {
        var mobile = /^0{0,1}(13[0-9]|15[0-9]|18[0-9]|14[0-9])[0-9]{8}$/;
        var email = /^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/;

        if (email.test(semailmobile)) {
            alllogin_type = 1;
        }
        else if (mobile.test(semailmobile)) {
            alllogin_type = 2;
        }
        else {
            alllogin_type = 0;
        }

    }
    return alllogin_type;
}
function GetReg_Type(semailmobile) {

    if (alllogin_type == 0) {
        return 1;
    }
    else {
        var mobile = /^0{0,1}(13[0-9]|15[0-9]|18[0-9]|14[0-9])[0-9]{8}$/;
        var email = /^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/;

        if (email.test(semailmobile)) {
            return 0;
        }
        else if (mobile.test(semailmobile)) {
            return 2;
        }
        else {
            return 1;
        }

    }
    return 1;
}


$(function () {
    custtomlogin("form1");
    $("#username").focus();
    $("#loginBtn").click(function () { $("#form1").submit(); });
    $("#password").keyup(function (e) {
        if (e.keyCode == 13) {
            $("#form1").submit();
        }
    });
});

  


