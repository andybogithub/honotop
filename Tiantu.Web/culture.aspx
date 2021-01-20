<%@ Page Title="" Language="C#" MasterPageFile="~/MainUI.master" AutoEventWireup="true" CodeFile="culture.aspx.cs" Inherits="culture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        navon(1);
    </script>

    <div class="tab">
        <div class="wp cl">
            <div class="curr">
                <span><a href="index.aspx">天图物流</a></span> > <span><a href="about.aspx">关于天图</a></span>
                > <span><a href="culture.aspx">企业文化</a></span>
            </div>
        </div>
    </div>

    <div class="culture">
        <div class="wp">
            <div class="culturemain cl">
                <div class="l aboutnav">
                    <ul>
                        <li><a href="about.aspx">董事长致辞</a></li>
                        <li><a href="develop.aspx">发展历程</a></li>
                        <li><a href="management.aspx">管理层</a></li>
                        <li class="on"><a href="culture.aspx">企业文化</a></li>
                        <li><a href="responsibility.aspx">社会责任</a></li>
						<li><a href="honor.aspx">荣誉与资质</a></li>
                    </ul>
                </div>
                <div class="r culpic">
                    <p>“知天应命、顺势而为。怀敬畏之心，有所为有所不为。了解大势，关注环境。”</p>
                    <p>“树立公司与个人的诚信与声誉。关爱员工，创造良好的内部环境。团结伙伴、敬重对手、融和诚信。”</p>
                    <p>“树立信念，传递思想。激励同仁，自强不息。”</p>
                    <p>“保持饥渴感，永不自足。笃志好学，志存高远。以目标为导向，不断挑战新境界。”</p>
                    <p><span>此谓，</span></p>
                    <img src="/style/images/about/cul_2.png" />
                </div>

            </div>
        </div>
    </div>


</asp:Content>

