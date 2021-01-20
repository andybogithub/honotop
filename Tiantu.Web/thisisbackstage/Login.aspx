<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="webadmin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <title>天图物流后台管理系统</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="content/css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" href="content/css/matrix-login.css" />
    <link href="content/css/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,700,800' rel='stylesheet' type='text/css'/>
</head>
<body>
    <style type="text/css">


    </style>
    <div id="loginbox">
        <form id="loginform" class="form-vertical" runat="server">
            <div class="control-group normal_text">
                <h3>
                    天图物流后台管理系统
                </h3>
            </div>
            <div class="control-group">
                <div class="controls">
                    <div class="main_input_box">
                        <span class="add-on bg_lg"><i class="icon-user"></i></span>
                        <asp:TextBox runat="server" ID="txtUsername" placeholder="用户名" />
                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" ErrorMessage="*" ControlToValidate="txtUsername" runat="server" />
                    </div>
                </div>
            </div>

            <div class="control-group">
                <div class="controls">
                    <div class="main_input_box">
                        <span class="add-on bg_ly"><i class="icon-lock"></i></span>
                        <asp:TextBox runat="server" TextMode="Password" ID="txtUserpass" placeholder="密码" />
                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" ErrorMessage="*" ControlToValidate="txtUserpass" runat="server" />
                    </div>
                </div>
            </div>

            <div class="form-actions">
                <span class="pull-left">
                    <asp:CheckBox Text="记住我" ID="chkRemember" runat="server" Visible="false" />
                    <asp:Literal ID="lblLoginResult" runat="server" />
                </span>
                <span class="pull-right">

                    <asp:Button Text="登录" ID="btnLogin" runat="server" class="btn btn-success" OnClick="btnLogin_Click" />
                </span>
            </div>
        </form>

        <div style="margin-top:200px;float:right;"><a href="http://shop.honotop.com/_shop_admin/login.aspx" target="_blank" style="color:white;font-size:18px;">商城管理后台</a></div>
    </div>

    <script src="content/js/jquery.min.js"></script>
    <script src="content/js/matrix.login.js"></script>
</body>

</html>
