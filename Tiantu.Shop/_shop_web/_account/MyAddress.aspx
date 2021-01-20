<%@ Page Title="" Language="C#" MasterPageFile="~/_shop_web/Share.master" AutoEventWireup="true" CodeFile="MyAddress.aspx.cs" Inherits="_shop_web__account_MyAddress" %>
<%@ Register TagPrefix="uc" TagName="top" Src="~/_shop_web/_account/Top.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="container wp">
        <div class="centerWrap">
          <uc:top ID="uctop" runat="server" />
           <div class="centerMainWrap centerAddressWrap">
					<div class="centerTitle"><strong>地址修改</strong></div>
					<div class="centerMain">
						<div class="tinote">您已保存 <b>
                            <asp:Literal Text="0" ID="lblAddressTotal" runat="server" /></b> 个收货地址</div>
						<div class="addressTable">
							<table border="0" cellspacing="0" cellpadding="0" class="table">
								<tr>
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
									    <td class="col_2"><%# Eval("username") %></td>
									    <td class="col_3"><%# Eval("city") %></td>
									    <td class="col_4"><%# Eval("addrs") %></td>
									    <td class="col_5"><%# Eval("zipcode") %></td>
									    <td class="col_6"><%# Eval("usertel") %></td>
									    <td class="col_7 operate">
										    <a class="modify" relid="<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("addressid").ToString()) %>">修改</a>
										    <a class="delete" relid="<%# Tiantu.DB.Common.SL.DESEncrypt(Eval("addressid").ToString()) %>">删除</a>
									    </td>
								    </tr>
                                    </ItemTemplate>
                                </asp:Repeater>							 
							</table>
						</div>
						<div class="addBtn"><a class="addnew">+ 新增收货地址</a></div>
					</div>
				</div>
			</div>
		</div>



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
         $(document).ready(function ()
         {
             

             $(".addnew").click(function ()
             {
                 var fullWidth = $(window).width();
                 var _x = (fullWidth - 700) / 2;
                 $("#popupAddress").css("left", _x + "px");
                 $("#popupAddress").show();
             });

             //修改
             $(".modify").click(function () {
                 var _addrno = $(this).attr("relid");
                 
                 var fullWidth = $(window).width();
                 var _x = (fullWidth - 700) / 2;
                 $("#popupAddress").css("left", _x + "px");
                 $("#popupAddress").show();

                 $.ajax({
                     type: "GET",
                     url: "/account/address/getinfo.html",
                     data: { addressid: _addrno },
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
             });

             //保存地址
             $("#btnSaveAddress").click(function () {

                 var btnTitle = $(this).text();
                 if (btnTitle == '保存')
                 {                   
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

                     $(this).text("保存中...");
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
                 }

             });


             //删除地址
             $(".delete").click(function () {
                 if (window.confirm('确认要删除吗?') == true) {
                     var _addrno = $(this).attr("relid");
                     $.ajax({
                         type: "POST",
                         url: "/account/address/delete.html",
                         data: { addressid: _addrno },
                         dataType: "json",
                         success: function (responseText) {
                             document.location.reload();
                         }
                     });
                 }
             });

         });

     

      

        </script>
</asp:Content>

