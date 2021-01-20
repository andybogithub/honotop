<%@ Page Title="" Language="C#" MasterPageFile="~/em/MobileEnUI.master" AutoEventWireup="true" CodeFile="stock.aspx.cs" Inherits="em_stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="stockWap">
        <div class="title cl">
            <a href="stock.aspx">
                <h3>Stock information</h3>
            </a>
        </div>
        <div class="newstop cl">
            <ul>
                <li><a href="report.aspx">Periodical reports</a></li>
                <li><a href="company.aspx">Company announcement</a></li>
                <li class="on"><a href="stock.aspx">Stock information</a></li>
                <li><a href="instructions.aspx">Prospectus</a></li>
            </ul>
        </div>
        <div class="main">
            <div class="video">
                <div id="a1" style="margin: 0 auto; width: 100%;"></div>

                <script type="text/javascript" src="/mobile/ckplayer/ckplayer.js" charset="utf-8"></script>
                <script type="text/javascript">
                    var flashvars = {
                        p: 1,
                        e: 1
                    };
                    var video = ['/mobile/ckplayer/tiantu.mp4'];
                    var support = ['all'];
                    CKobject.embedHTML5('a1', 'ckplayer_a1', 300, 220, video, flashvars, support);
                </script>
            </div>
            <div class="abstock">
                  <%=pageModel.CONTENTS_EN %>
            </div>
        </div>
    </div>
</asp:Content>

