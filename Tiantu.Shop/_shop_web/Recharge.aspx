<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="Recharge.aspx.cs" Inherits="_shop_web_Recharge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        

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
                            <strong><i>*</i> 输入充值卡号：</strong>
                            <div class="input">
                                <asp:TextBox ID="txtCode" runat="server" MaxLength="11"></asp:TextBox>
                                <i class="ui"></i>
                            </div>
                        </div>                       

                        <div class="regSubmit">
                            <asp:Button ID="btnRecharge" runat="server" Text="充值" OnClick="btnRecharge_Click"/>
                        </div>

                    </div>


                </div>
            </form>


        </div>
    </div>



</asp:Content>

