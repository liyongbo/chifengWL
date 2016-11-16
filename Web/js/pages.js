//u=0,更新，1不更新
//g=0,显示go，1不显示go
//up=0,显示上一页，1不显示上一页
//dw=0,显示下一页，1不显示下一页
//m=0,显示...,1不显示...
//d=默认样式
//c=当前页样式
//un=不可用样式
//n=显示页数个数
//cp=当前页
//data=数据名
//max_pages=总页数
//totalnum=总条数
//html=链接
var pages = function (u, g, up, dw, m, d, c, un, n, cp, data, max_pages,totalnum, html) {
    var _this = this;

    this.init = function () {
        return _this.GetPages();
    }

    this.GetPages = function () {

        if ($(".pages").length > 0) {
            $(".pages").remove();
        }
        var page = $('<div class="pages">');

        _this.numpages(page);


        return page;
    }
    this.numpages = function (obj) {

        var uppage1 = $('<a>')
        uppage1.attr("class", "inline turnPage");
        uppage1.text("< 上一页 ");
        if (up == 0) {
            uppage1.attr("href", "javascript:void(-1)");
            obj.append(uppage1);
        }
        if (max_pages <= n) {
            for (var i = 1; i <= max_pages; i++) {
                obj.append(_this.alink(i));
            }
        }
        else {
            var a = parseInt(n / 2);
            if (cp + a > max_pages) {
                if (m == 0)
                { obj.append(_this.spand()); }
                for (var i = max_pages - n + 1; i <= max_pages; i++) {
                    obj.append(_this.alink(i));
                }
            }
            else {
                if (cp - a > 0) {
                    if (m == 0 && cp - a > 1)
                    { obj.append(_this.spand()); }
                    for (var i = cp - a; i <= cp + a; i++) {
                        obj.append(_this.alink(i));
                    }
                    if (m == 0 && cp + a < max_pages)
                    { obj.append(_this.spand()); }
                } else {
                    for (var i = 1; i <= n; i++) {
                        obj.append(_this.alink(i));
                    }
                    if (m == 0)
                    { obj.append(_this.spand()); }
                }

            }
        }

        var uppage2 = $('<a>')
        uppage2.attr("class", "inline turnPage")
        uppage2.text("下一页 > ");
        if (dw == 0) {
            obj.append(uppage2);
        }
        if (g == 0) {
            obj.append(_this.gotopage());
        }
        if (u == 0) {
            if (cp - 1 > 0) {
                uppage1.attr("href", html + (cp - 1));
            }
            else {
                uppage1.attr("href", "javascript:void(-1)");
                uppage1.addClass(un);
            }

            if (cp + 1 > max_pages) {
                uppage2.attr("href", "javascript:void(-1)");
                uppage2.addClass(un);
            }
            else {
                uppage2.attr("href", html + (cp + 1));
            }
        }
        else {
            if (cp - 1 > 0) {
                uppage1.unbind("click").click(function () {
                    data(cp - 1);
                });
            }
            else {
                uppage1.attr("href", "javascript:void(-1)");
                uppage1.addClass(un);
            }

            if (cp + 1 > max_pages) {
                uppage2.attr("href", "javascript:void(-1)");
                uppage2.addClass(un);
            }
            else {
                uppage2.unbind("click").click(function () {
                    data(cp + 1);
                });
            }
        }
    }
    this.spand = function () {
        var span = $("<span>")
        span.attr("class", "inline f13");
        span.text("...");
        return span;
    }
    this.alink = function (i) {
        var a = $('<a>');
        a.attr("class", d);
        a.text(i);
        if (u > 0)
            a.unbind('click').click(function () {
                data(i);
            });
        else {
            a.attr("href", html + i)
        }
        if (i == cp)
            a.addClass(c);
        return a
    }
    this.gotopage = function () {
        var div = $('<div>');
        div.attr("class", "inline f13 mg_l10")
        var span = $('<span>');
        span.attr("class", "inline mg_r10 pagerfont")
        span.text(' 去第');
        var input = $('<input />');
        input.attr("type", "text");
        input.attr("class", "inpCom20 w40");
        input.val(cp); //onkeyup=""  ="" />'"
        input.bind("onkeyup", function () { this.value = this.value.replace(/\\D/g, '') });
        input.bind("onafterpaste", function () { this.value = this.value.replace(/\\D/g, '') });
        span.append(input);
        span.html(span.html() + '页');
        div.append(span);
        var aaa = $('<a class="numSumit inline">确定</a>')
        if (u > 0)
            aaa.unbind('click').click(function () {
                data(input.val());
            });
        else {
            div.find("input").unbind("blur").blur(function () {
                if ($(this).val() < 1)
                    $(this).val(1);
                if ($(this).val() > max_pages)
                    $(this).val(max_pages);
                aaa.attr("href", html + $(this).val())
            })
        }
        div.append(aaa);
        return div;

    }


}