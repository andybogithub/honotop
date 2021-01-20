<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="_shop_web_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--登录-->
    <div class="registerWap">
        <style>
            body { background: #f0f0f0; }
        </style>
        <div class="wp cl">

            <div class="regTit">
                <h3><i class="ui"></i>手机注册</h3>

            </div>

            <form runat="server">
                <!--注册表单-->
                <div class="regMainWap regFormMain cl">
                    <div class="l regForm">
                        <div class="item cl phone">
                            <strong><i>*</i> 手机号码：</strong>
                            <div class="input">
                                <asp:TextBox ID="txtPhone" runat="server" MaxLength="11"></asp:TextBox>
                                <i class="ui"></i>
                            </div>
                            <div class="tips">请输入手机号码，将作为您以后的登录方式</div>
                        </div>

                        <div class="item cl password">
                            <strong><i>*</i> 请输入密码：</strong>
                            <div class="input">
                                <asp:TextBox ID="txtUserPass" runat="server"></asp:TextBox>
                                <i class="ui"></i>
                            </div>
                            <div class="tips error">请输入密码，6-20位数。</div>
                        </div>

                        <div class="agree">
                            <input type="checkbox" />我已阅读并同意《<a href="#">天图商城用户注册协议</a>》
                        </div>
                        <div class="regSubmit">
                            <asp:Button ID="btRegister" runat="server" Text="立即注册" OnClick="btRegister_Click" />
                            <%--<input type="button" value="立即注册" onclick="$('.regFormMain').hide(); $('.regSuccMain').show();" />--%>
                        </div>

                    </div>


                </div>
            </form>


            <!--注册表单-->
            <div class="regMainWap regSuccMain" style="display: none;">
                <h3>恭喜您，注册成功!</h3>
                <span>已成功注册天图物流商城的普通会员。</span>

                <p><a href="/">马上开始体验>></a></p>
            </div>

        </div>
    </div>



</asp:Content>

