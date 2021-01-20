<%@ Page Title="" Language="C#" MasterPageFile="~/en/MainEnUI.master" AutoEventWireup="true" CodeFile="culture.aspx.cs" Inherits="en_culture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        navon(1);
    </script>

    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">TIANTU LOGISTICS</a></span> > <span><a href="about.aspx">About Tiantu</a></span>
                > <span><a href="culture.aspx">Entrepreneurship</a></span>
            </div>
        </div>
    </div>

    <div class="culture">
        <div class="wp">
            <div class="culturemain cl">
                <div class="l aboutnav">
                    <ul>
                        <li><a href="about.aspx">Chairman’s Message</a></li>
                        <li><a href="develop.aspx">Enterprise Milestone</a></li>
                        <li><a href="management.aspx">Management Team</a></li>
                        <li class="on"><a href="culture.aspx">Entrepreneurship</a></li>
                        <li><a href="responsibility.aspx">Social Responsibility</a></li>
                        <li><a href="honor.aspx">Honor and Qualification</a></li>
                    </ul>
                </div>
                <div class="r culpic">
                    <p>To respect; morality differentiation between "good" (or right) and "bad" (or wrong)</p>
                    <p>To cherish; integrity  between employees, business partners and even competitors</p>
                    <p>To self-improve; embrace a willing to learn attitude and keep up the pace of progress</p>
                    <p>To innovate; application of better solutions that meet new requirements, inarticulated needs, or existing market needs</p>               
                    <img src="/style/images/en/cul_2.png" />
                </div>

            </div>
        </div>
    </div>


</asp:Content>

