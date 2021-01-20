<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="newsde.aspx.cs" Inherits="en_newsde" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        navon(5);
    </script>
    
    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">TIANTU LOGISTICS</a></span> > <span><a href="news.aspx">News Center</a>
                </span>> <span><a href="newsde.aspx">News Detail</a></span>
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
                            News<br />
                            <span>Center</span>
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
                        <h5><%=pageModel.TITLE_EN %></h5>
                        <span><%=pageModel.PUBDATE.ToString("yyyy/MM/dd") %></span>
                    </div>
                    <%=pageModel.CONTENTS %>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

