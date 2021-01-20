<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Top.ascx.cs" Inherits="_shop_web__account_Top" %>
<div class="centerInfo cl">

    <style>
        .buttoncz { background: #ffd800; height: 40px; line-height: 40px; text-align: center; width: 100px; display: block; color: #fff; font-size: 18px; }
    </style>


    <div class="l userInfo">

        <div class="pic">
      
                <img src="<%=UserIcon %>" onload="javascript:DrawImage(this, 120, 120)" /><span>编辑</span>
        </div>

        <div class="con">
            <h4><%=UserTel %><%=UserNickName %></h4>
            <p>
                <span></span>

                <a href="/recharge.html" class="buttoncz">充值</a>
                <%--<a href="/rule.html" class="btnJF" target="_blank">游戏规则</a>--%>
            </p>
        </div>
    </div>
    <div class="r centerMenu">
        <ul>
            <li>
                <a href="/account/orders.html">
                    <i class="icon-order">&#xe909;</i>
                    <p>我的订单</p>
                </a>
            </li>
            <li>
                <a href="/account/indiana.html">
                    <i class="icon-db">&#xe907;</i>
                    <p>我的夺宝</p>
                </a>
            </li>
            <li>
                <a href="/account/points.html">
                    <i class="icon-jf">&#xe908;</i>
                    <p>消费明细</p>
                </a>
            </li>
            <li>
                <a href="/account/address.html">
                    <i class="icon-address">&#xe90a;</i>
                    <p>地址修改</p>
                </a>
            </li>
        </ul>
    </div>
</div>
