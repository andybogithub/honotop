<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="reportde.aspx.cs" Inherits="reportde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="js/jquery.media.js"></script>

    <script type="text/javascript">
        $(function () {
            $('a.media').media({ width: 800, height: 800 });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        navon(4);
    </script>


    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">天图物流</a></span> > <span><a href="investors.aspx">投资者关系</a></span>
                > <span><a href="report.aspx">定期报告</a></span> > <span><a href="reportde.aspx">定期报告详情</a></span>
            </div>
        </div>
    </div>
    <!--/header-->


    <div class="container wp">
        <div class="instructions">
            <div class="insvesnav cl">
                <ul>
                    <li class="cont_1"><a href="report.aspx">定期报告</a></li>
                    <li class="cont_2"><a href="company.aspx">公司公告</a></li>
                    <li class="cont_3"><a href="stock.aspx">股票信息</a></li>
                    <li class="cont_4"><a href="instructions.aspx">招股说明书</a></li>
                </ul>
            </div>
            <div class="report cl">
                <div class="l reportnav">
                    <ul>
                        <asp:Literal ID="lblNav" runat="server"></asp:Literal>
                    </ul>
                </div>
                <div class="l reportmain">
                    <div class="typepdf">
                        <a class="media" href="<%=pageModel.PDFURL %>"></a>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

