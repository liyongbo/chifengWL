var indNum = 0;

//ͼƬ�ϴ�Ԥ��    IE�������˾���
function previewImage(file)
{
    var input=$(file).parent().find("input");
    var span=$(file).parent().parent().find("span");
    span.append(input);
    var img=$(file).parent().parent().find("img");

    var li=$("<li style=\"position: relative;\">");
    li.append(img);
    li.append(span);

    var MAXWIDTH  = 1.1;
    var MAXHEIGHT = 1.1;
    var div = document.getElementById('preview'+indNum);
    if (file.files && file.files[0])
    {

        div.innerHTML ='<img id=imghead'+indNum+'>';
        var img = document.getElementById('imghead'+indNum);
        img.onload = function(){
            var rect = clacImgZoomParam(MAXWIDTH, MAXHEIGHT, img.offsetWidth, img.offsetHeight);
            img.width  =  rect.width;
            img.height =  rect.height;
//                 img.style.marginLeft = rect.left+'px';
            img.style.marginTop = rect.top+'px';
        }
        var reader = new FileReader();
        reader.onload = function(evt){img.src = evt.target.result;}
        reader.readAsDataURL(file.files[0]);
        $("#preview"+indNum).removeAttr("id");
        li.attr("id","preview"+(indNum+1));
        $(".G_csdwbox ul").append(li);
        indNum++;
    }
    else //����IE
    {
        var sFilter='filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale,src="';
        file.select();
        var src = document.selection.createRange().text;
        div.innerHTML = '<img id=imghead>';
        var img = document.getElementById('imghead');
        img.filters.item('DXImageTransform.Microsoft.AlphaImageLoader').src = src;
        var rect = clacImgZoomParam(MAXWIDTH, MAXHEIGHT, img.offsetWidth, img.offsetHeight);
        status =('rect:'+rect.top+','+rect.left+','+rect.width+','+rect.height);
        div.innerHTML = "<div id=divhead style='width:"+rect.width+"px;height:"+rect.height+"px;margin-top:"+rect.top+"px;"+sFilter+src+"\"'></div>";

    }

}
function clacImgZoomParam( maxWidth, maxHeight, width, height ){
    var param = {top:0, left:0, width:width, height:height};
    if( width>maxWidth || height>maxHeight )
    {
        rateWidth = width / maxWidth;
        rateHeight = height / maxHeight;

        if( rateWidth > rateHeight )
        {
            param.width =  maxWidth;
            param.height = Math.round(height / rateWidth);
        }else
        {
            param.width = Math.round(width / rateHeight);
            param.height = maxHeight;
        }
    }

    param.left = Math.round((maxWidth - param.width) / 2);
    param.top = Math.round((maxHeight - param.height) / 2);
    return param;
}