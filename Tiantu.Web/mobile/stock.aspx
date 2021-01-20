<%@ Page Title="" Language="C#" MasterPageFile="~/mobile/MobileUI.master" AutoEventWireup="true" CodeFile="stock.aspx.cs" Inherits="mobile_stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="stockWap">
        <div class="title cl">
            <a href="stock.aspx">
                <h3>股票信息</h3>
            </a>
        </div>
        <div class="newstop cl">
            <ul>
                <li><a href="report.aspx">定期报告</a></li>
                <li><a href="company.aspx">公司公告</a></li>
                <li class="on"><a href="stock.aspx">股票信息</a></li>
                <li><a href="instructions.aspx">招股说明书</a></li>
            </ul>
        </div>
        <div class="main">
            <div class="video">
                <div id="a1" style="margin: 0 auto; width: 100%;"></div>

                <script type="text/javascript" src="ckplayer/ckplayer.js" charset="utf-8"></script>
                <script type="text/javascript">
                    var flashvars = {
                        p: 1,
                        e: 1
                    };
                    var video = ['ckplayer/tiantu.mp4'];
                    var support = ['all'];
                    CKobject.embedHTML5('a1', 'ckplayer_a1', 300, 220, video, flashvars, support);
                </script>
            </div>
            <div class="abstock">
                  <%=pageModel.CONTENTS %>
            </div>
        </div>
    </div>
</asp:Content>

