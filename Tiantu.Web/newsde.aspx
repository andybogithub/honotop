<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="newsde.aspx.cs" Inherits="newsde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        navon(5);
    </script>
    
    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">天图物流</a></span> > <span><a href="news.aspx">新闻中心</a>
                </span>> <span><a href="newsde.aspx">新闻中心详情</a></span>
            </div>
        </div>
    </div>
    <!--/header-->


    <div class="container">
        <div class="wp">
            <div class="news">
                <div class="l newsnav">
                    <div class="title">
                        <p>
                            NEWS<br />
                            <span>新闻中心</span>
                        </p>
                    </div>
                    <div class="navmain">
                        <ul>
                            <asp:Literal ID="lblNav" runat="server"></asp:Literal>
                        </ul>
                    </div>
                </div>
                <div class="l newsdemain">
                    <div class="title">
                        <h5><%=pageModel.TITLE %></h5>
                        <span>发布时间：<%=pageModel.PUBDATE.ToString("yyyy-MM-dd") %></span>
                    </div>
                    <%=pageModel.CONTENTS %>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

