<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="Carts.aspx.cs" Inherits="_shop_web_Carts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



   <form id="form-order">
        <div class="container wp">
        <div class="changeWrap proChangeWrap">
            <div class="formAddress">


                <div class="formTitle"><strong>收货地址</strong><a onclick="javascript:addAddress();" class="addBtn">+ 新增</a></div>
                <div class="formCon">
                    <table border="0" cellspacing="0" cellpadding="0" class="table">
                        <tr>
                            <th class="col_1">选择</th>
                            <th class="col_2">收货人</th>
                            <th class="col_3">所在地区</th>
                            <th class="col_4">街道地址</th>
                            <th class="col_5">邮编</th>
                            <th class="col_6">手机/电话</th>
                            <th class="col_7">操作</th>
                        </tr>
                        <asp:Repeater runat="server" ID="RepeaterAddressList">
                            <ItemTemplate>
                                <tr>
                                    <td class="col_1">
                                        <input type="radio" name="order_addressid" value="<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("addressid").ToString()) %>" <%# Convert.ToBoolean(Eval("IsDefaultAddress"))?"checked":"" %>></td>
                                    <td class="col_2"><%# Eval("username") %></td>
                                    <td class="col_3"><%# Eval("city") %></td>
                                    <td class="col_4"><%# Eval("addrs") %></td>
                                    <td class="col_5"><%# Eval("zipcode") %></td>
                                    <td class="col_6"><%# Eval("usertel") %></td>
                                    <td class="col_7 operate" style="text-align: left">
                                        <a onclick="javascript:editAddress('<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("addressid").ToString()) %>');">修改</a>
                                        <%# Convert.ToBoolean(Eval("IsDefaultAddress"))?"<span>默认地址</span>":"" %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        


            <div class="formProduct">
                <div class="formTitle"><strong>商品信息</strong></div>
                <div class="formCon">
                    <table border="0" cellspacing="0" cellpadding="0" class="table">
                        <tr>
                            <th class="col_1">商品名称</th>
                            <th class="col_2">单价</th>
                            <th class="col_3">数量</th>
                            <th class="col_4">小计</th>
                            <th>配送方式</th>
                            <th>保险费用</th>
                            <th>购买保险</th>
                            <th class="col_5">操作</th>
                        </tr>
                        <asp:Repeater runat="server" ID="RepeaterProductsList">
                            <ItemTemplate>
                                <tr>
                                    <td class="col_1">
                                        <div class="pic">
                                            <a href="/proDe/<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("productId").ToString()) %>.html"><img src="<%# Eval("ImageIcon") %>" onload="javascript:DrawImage(this, 60, 60)" /></a>
                                        </div>
                                        <div class="con"><%# Eval("productName") %></div>
                                    </td>
                                    <td class="col_2"><%# Eval("orderPoint") %> 元</td>
                                    <td class="col_3"> x <%# Eval("orderQty") %></td>
                                    <td class="col_4"> = <%# Convert.ToInt32(Eval("orderQty"))*Convert.ToInt32(Eval("orderPoint"))  %> 元</td>
                                    <td>
                                    <%# Eval("shipment") %>  
                                    </td>
                                    <td>
                                        <%# Convert.ToDouble(Eval("InsurancePrice")).ToString("N2") %> 元
                                    </td>
                                    <td>                                           
                                        <input type="checkbox" class="buyInsurance" <%# Convert.ToBoolean(Eval("IsInsurance"))?"checked":"" %>  <%# Convert.ToDouble(Eval("InsurancePrice"))==0?"disabled":"" %>   relid='<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("tempOrderId").ToString()) %>' price='<%# Convert.ToDouble(Eval("InsurancePrice")) %>'/>
                                    </td>
                                    <td class="col_5 operate">
                                        <a class="deleteItem" relid="<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("tempOrderId").ToString()) %>">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="formOrder">
                        <div class="orderL">
                            <p>
                                钱包余额：<asp:Literal Text="0" ID="lblUserPoints" runat="server" />
                            </p>
                            <p><a href="/products.html" class="btnBack">返回购买商品中心</a></p>
                        </div>
                        <div class="orderR">
                            <p>
                                <b>
                                    <asp:Literal Text="0" ID="lblTotalQty" runat="server" /></b> 件商品共：
                                 <b><asp:Literal Text="0" ID="lblTotalPoints" runat="server" /></b>
                              元
                            </p>
                            <p>
                                保险费用：
                                <b id="InsurancePriceAmount"><asp:Literal Text="0" runat="server"  ID="lblInsurancePrice"/></b> 元
                            </p>
                            <div class="buyBtn">
                                <asp:Literal  ID="lblExchangeNow" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   </form>




    <!--没有填写地址时弹出-->
    <div class="popupAddress" id="popupAddress" style="position:absolute;top:100px; width:700px; background:#FFF;padding:20px;border:1px solid #dcdcdc;">

        <form id="form-address">
            <h3 style="background:#f4f4f4;margin:0;padding:10px;margin-bottom:20px;">录入地址信息</h3>

             <div class="item cl">
                <div class="itemLeft"><i>*</i> 所 在 地 区：</div>
                <div class="itemRight">
                    <div class="textareaDiv">
                       <input type="text"   id="addrs_usercity"   name="usercity" ov="请选择/输入城市名称" class="city_input  inputFocus proCityQueryAll proCitySelAll" style="width: 418px;" placeholder="请选择或输入城市名或拼音" />
                    </div>
                </div>
            </div>


            <div class="item cl">
                <div class="itemLeft"><i>*</i> 街 道 地 址：</div>
                <div class="itemRight">
                    <div class="textareaDiv">
                        <textarea rows="2" cols="" id="addrs_address" name="address"></textarea>
                    </div>
                </div>
            </div>
            <div class="item cl">
                <div class="itemLeft"><i>*</i> 邮 政 编 码：</div>
                <div class="itemRight">
                    <div class="inputText">
                        <input type="text" id="addrs_zipcode" name="zipcode" />
                    </div>
                </div>
            </div>
            <div class="item cl">
                <div class="itemLeft"><i>*</i> 收货人姓名：</div>
                <div class="itemRight">
                    <div class="inputText">
                        <input type="text" id="addrs_username" name="username" />
                    </div>
                </div>
            </div>
            <div class="item cl">
                <div class="itemLeft"><i>*</i> 手机 / 电话：</div>
                <div class="itemRight">
                    <div class="inputText">
                        <input type="text" id="addrs_usertel" name="usertel" />
                    </div>
                    <div class="note">此处若填写电话，填写格式为：区号-电话号码-分机</div>
                </div>
            </div>
            <div class="item cl">
                <div class="itemRight">
                    <label>
                        <input type="checkbox" id="addrs_isdefault" name="isdefault" value="1" />设为默认地址</label>
                </div>
            </div>
            <div class="item cl">
                <div class="itemRight">
                    <div class="submitBtn">
                       <table>
                            <tr>
                                <td> <a id="btnSaveAddress">保存</a></td>
                                <td>&nbsp;</td>
                                <td> <a onclick="javascript:$('.popupAddress').hide();" style="background:#f4f4f4;color:#666;">取消</a></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <input type="hidden" name="addressid" id="addrs_addressid" value="0" />
        </form>

    </div>

         <!--弹出省省市-->
    <div class="provinceCityAll" style="display:none;">
        <div class="tabs clearfix">
            <ul class="">
                <li><a href="javascript:" class="current" tb="hotCityAll">热门城市</a></li>
                <li><a href="javascript:" tb="provinceAll">省份</a></li>
                <li><a href="javascript:" tb="cityAll" id="cityAll">城市</a></li>
                <li><a href="javascript:" tb="countyAll" id="countyAll">区县</a></li>
            </ul>
        </div>
        <div class="con">
            <div class="hotCityAll invis">
                <div class="pre"><a></a></div>
                <div class="list">
                    <ul>
                        <!-- 					<li><a href="javascript:"  class="current">南京</a></li> -->
                    </ul>
                </div>
                <div class="next"><a class="can"></a></div>
            </div>
            <div class="provinceAll invis">
                <div class="pre"><a></a></div>
                <div class="list">
                    <ul>
                        <!-- 					<li><a href="javascript:"  class="current">江西省</a></li> -->
                    </ul>
                </div>
                <div class="next"><a class="can"></a></div>
            </div>
            <div class="cityAll invis">
                <div class="pre"><a></a></div>
                <div class="list">
                    <ul>
                        <!-- 					<li><a href="javascript:"  class="current">南京</a></li> -->
                    </ul>
                </div>
                <div class="next"><a class="can"></a></div>
            </div>
            <div class="countyAll invis">
                <div class="pre"><a></a></div>
                <div class="list">
                    <ul>
                    </ul>
                </div>
                <div class="next"><a class="can"></a></div>
            </div>
        </div>
    </div>
    <script src="/js/city/js/jquery-1.6.2.min.js"></script>
    <script src="/js/city/js/city.js"></script>
    <link href="/js/city/css/cityLayout.css" rel="stylesheet" />


    <script type="text/javascript">
        //添加地址
        function addAddress() {
            var fullWidth = $(window).width();
            var _x = (fullWidth - 700) / 2;
            $("#popupAddress").css("left", _x + "px");
            $("#popupAddress").show();
        }

        //修改地址
        function editAddress(addrno) {
            if (addrno == null || addrno.length == 0) return;

            var fullWidth = $(window).width();
            var _x = (fullWidth - 700) / 2;
            $("#popupAddress").css("left", _x + "px");
            $("#popupAddress").show();

            $.ajax({
                type: "GET",
                url: "/account/address/getinfo.html",
                data: { addressid: addrno },
                dataType: "json",
                success: function (responseText) {
                    if (responseText != null && responseText.AddressId > 0) {
                        $("#addrs_addressid").val(responseText.AddressId);
                        $("#addrs_usercity").val(responseText.City);
                        $("#addrs_address").val(responseText.Addrs);
                        $("#addrs_zipcode").val(responseText.ZipCode);
                        $("#addrs_username").val(responseText.UserName);
                        $("#addrs_usertel").val(responseText.UserTel);
                        $("#addrs_isdefault").prop("checked", responseText.IsDefaultAddress);
                    }
                }
            });
        }

         
        $(document).ready(function () {

            //保存地址
            $("#btnSaveAddress").click(function () {

                var _usercity = $("#addrs_usercity").val();
                var _address = $("#addrs_address").val();
                var _zipcode = $("#addrs_zipcode").val();
                var _username = $("#addrs_username").val();
                var _usertel = $("#addrs_usertel").val();
                var _isdefault = $("#addrs_isdefault").val();

                var _errmsg = '';
                if (_usercity == null || $.trim(_usercity).length == 0) {
                    _errmsg = '请选择所在地区';
                } else if (_address == null || $.trim(_address).length == 0) {
                    _errmsg = '请输入街道地址';
                } else if (_zipcode == null || $.trim(_zipcode).length == 0) {
                    _errmsg = '请输入邮政编码';
                } else if (_username == null || $.trim(_username).length == 0) {
                    _errmsg = '请输入收货人姓名';
                } else if (_usertel == null || $.trim(_usertel).length == 0) {
                    _errmsg = '请输入手机/电话';
                }

                if (_errmsg.length > 0) {
                    alert(_errmsg);
                    return;
                }

                var _datafrom = $("#form-address").serialize();
                $.ajax({
                    type: "POST",
                    url: "/account/address/edit.html",
                    data: _datafrom,
                    dataType: "json",
                    success: function (responseText) {
                        if (responseText.errcode == 0) {
                            document.location.reload();
                        } else {
                            alert(responseText.errmsg);
                        }
                    }
                });
            });

            //买保险
            $(".buyInsurance").click(function (e) {
                var _tempid = $(this).attr("relid");
                var _checked = $(this).prop("checked");
                $.ajax({
                    type: "POST",
                    url: "/carts/buyInsurance.html",
                    data: { tempid: _tempid, status: _checked==true?1:0 },
                    dataType: "json",
                    success: function (responseText) {
                     
                        var _amountInsurance = 0.00;
                        //计算总保险费用
                        $(".buyInsurance:checked").each(function () {
                            _amountInsurance += parseFloat($(this).attr("price"));
                        });
                        $("#InsurancePriceAmount").text(_amountInsurance.toFixed(2));
                    }
                });
              
            });

            //删除商品
            $(".deleteItem").click(function () {
                if (window.confirm('确认要删除吗?') == true) {
                    var _tempid = $(this).attr("relid");
                    $.ajax({
                        type: "POST",
                        url: "/carts/remove.html",
                        data: { tempid: _tempid },
                        dataType: "json",
                        success: function (responseText) {
                             document.location.reload();
                            
                        }
                    });
                }
            });

            //立即购买
            $("#btnExchangeNow").click(function (e) {
                
                var _order_addressid = $("input[name=order_addressid]").val();
                if (_order_addressid == null) {
                    alert('请选择收货地址');
                    return false;
                }
                var _formdata = $("#form-order").serialize();

                $.ajax({
                    type: "POST",
                    url: "/carts/exchangeNow.html",
                    data: _formdata,
                    dataType: "json",
                    success: function (responseText) {
                        if (responseText.errcode == 0) {
                            var centerUrl = '/account/index.html';
                            document.location.href = centerUrl;
                        } else {
                            alert(responseText.errmsg);
                        }
                    }
                });

            });
        });


    </script>
</asp:Content>

