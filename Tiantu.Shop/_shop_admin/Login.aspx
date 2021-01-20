<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="admin_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>天图物流有限公司 </title>

    <link href="style/css/bootstrap.min.css" rel="stylesheet" />
    <link href="style/css/font-awesome.min.css" rel="stylesheet" />
    <link href="style/css/metisMenu.css" rel="stylesheet" />
    <link href="style/css/style.css" rel="stylesheet" />



</head>
<body class="fixed-left" style="font-family:微软雅黑;background:#FFF;">

    <asp:Panel ID="PanelError" runat="server" Visible="false">
        <div class="alert alert-danger text-center">
            <a class="close" data-dismiss="alert">&times;
            </a>
            <strong>提示：</strong>
            <asp:Literal ID="lblLoginResult" runat="server" />，请重试!
        </div>
    </asp:Panel>

    <div class="container">
        <div class="row">
            <div class="locksreen-col text-center">
                <h3>
                    <img src="/style/images/logo.png" height="32" /> 天图物流商城管理中心</h3>
                <br />
                <form runat="server" id="aspNetForm" class="m-t" role="form">
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtUserName" placeholder="登录账号" MaxLength="12" CssClass="form-control" required="" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtUserPass" placeholder="登录密码" MaxLength="16" CssClass="form-control" required="" TextMode="Password" />
                    </div>
                    <asp:Button Text="登录" ID="btnLogin" CssClass="btn btn-theme btn-block" runat="server" OnClick="btnLogin_Click" />
                    <br />
                    <br />
                    <p>天图物流 &copy; <%=DateTime.Now.Year %> </p>
                </form>
            </div>
        </div>
    </div>
    <!-- Plugins  -->



    <script src="style/js/jquery.min.js"></script>
    <script src="style/js/bootstrap.min.js"></script>
    <script src="style/js/jquery.slimscroll.js"></script>
    <script src="style/js/metisMenu.js"></script>
    <script src="style/js/app.js"></script>
</body>
</html>
