<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="responsibility.aspx.cs" Inherits="responsibility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">天图物流</a></span> > <span><a href="about.aspx">关于天图</a></span>
                > <span><a href="responsibility.aspx">社会责任</a></span>
            </div>
        </div>
    </div>
    <!--/header-->

    <div class="responsibility">
        <div class="wp">
            <div class="responmain cl">
                <div class="l aboutnav">
                    <ul>
                        <li><a href="about.aspx">董事长致辞</a></li>
                        <li><a href="develop.aspx">发展历程</a></li>
                        <li><a href="management.aspx">管理层</a></li>
                        <li><a href="culture.aspx">企业文化</a></li>
                        <li class="on"><a href="responsibility.aspx">社会责任</a></li>
                        <li><a href="honor.aspx">荣誉与资质</a></li>
                    </ul>
                </div>
                <div class="l responpic">
                    <div class="pic_1">
                        <img src="/style/images/about/respon_1.png"></div>
                    <div class="respon_1">
                        <p>以不断增加员工收入努力、提高福利待遇和永续就业为己任，<br />
                            努力改善员工的生产环境和生产条件。</p>
                    </div>
                    <div class="respon_2">
                        <p>不断丰富服务与产品，想客户所想、<br />
                            解客户之急、补行业之需，为客户连通世界。</p>
                    </div>
                    <div class="respon_3">
                        <p>
                            关注农民工、残疾人、孤寡老人等弱势群体救助。<br />
                            支援社区建设、支持健康、人文关怀、文化与艺术等。
                            <br />
                            城市建设项目的建设，帮助社区改善公共环境，为社区
                        </p>
                    </div>
                    <div class="respon_4">
                        <p>大力推动校企合作，创造更多实习及就业机会。<br />
                            帮扶中国边远农村，促进农产品流通交易。</p>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

