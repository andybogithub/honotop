/// <reference path="kindeditor-all.js" />

KindEditor.ready(function (K)
{
    K.create('.KE', {
        uploadJson: '/webadmin/content/kindeditor/ashx/upload_json.ashx',
        filterMode: true,
        items: [
        'source', '|', 'clearhtml', '|', 'fontsize', 'bold', 'italic', 'underline', 'strikethrough', 'lineheight', 'justifyleft', 'justifycenter', 'justifyright', '|', 'removeformat', '|', 'image', 'multiimage',
        'flash', 'media', '|', 'table', 'hr', 'baidumap', 'pagebreak',
        'anchor', 'link', 'unlink', '|', 'preview', 'fullscreen'
        ]
    });

});

