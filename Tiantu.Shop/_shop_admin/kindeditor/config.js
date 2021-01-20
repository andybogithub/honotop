 
 KindEditor.ready(function (K)
{
    K.create('.KE', {
        uploadJson: '/_shop_admin/kindeditor/net/upload_json.ashx',
        filterMode: false,
        //pasteType: 1,    //0:禁止粘贴, 1:纯文本粘贴, 2:HTML粘贴
        items: [
                   'source', '|', 'clearhtml', '|', 'fontsize', 'bold', 'italic', 'underline', 'strikethrough', 'lineheight', 'justifyleft', 'justifycenter', 'justifyright', '|', 'removeformat', '|', 'image', 'multiimage',
                   'flash', 'media', '|', 'table', 'hr', 'baidumap', 'pagebreak',
                   'anchor', 'link', 'unlink','|','fullscreen'
        ]
    }); 
});

