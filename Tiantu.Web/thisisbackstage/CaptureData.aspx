<%@ Page Title="" Language="C#" MasterPageFile="~/thisisbackstage/Webadmin.master" AutoEventWireup="true" CodeFile="CaptureData.aspx.cs" Inherits="thisisbackstage_capture_CaptureData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .btn_capture{
            background:#0094ff;
            color:#fff;
            text-align:center;
            width:150px;
            border:none;
            font-size:13px;
            height:34px;
            line-height:34px;
            padding:0 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div style="margin: 15px;"> 
      
        <div>
            <table>
                <tr>
                    <td style="vertical-align:middle;font-size:17px;">
                        采购页码：
                    </td>
                    <td  style="vertical-align:middle;font-size:17px;">
                        <asp:DropDownList runat="server" ID="ddlpageId">
                            <asp:ListItem Text="1" Value="0" />
                            <asp:ListItem Text="2" Value="1" />
                            <asp:ListItem Text="3" Value="2" />
                        </asp:DropDownList>
                    </td>
                    </tr>
                <tr>
                    <td></td>
                    <td>
                          <asp:Button CssClass="btn_capture" Text="开始采集数据" ID="btnStartCapture" runat="server" OnClick="btnStartCapture_Click" />
                    </td>
                </tr>
            </table>
          
        </div>

        <hr />
        <asp:PlaceHolder ID="PlaceHolderResult" runat="server" Visible="false">
            <h3>采集结果：</h3>
         <div style="background:#fff;margin-bottom:15px;">
            <asp:GridView runat="server" ID="gridView1">
        </asp:GridView>
       </div>
        </asp:PlaceHolder>
    </div>

<%--
    <table>
        <tr>
            <th>page</th>
            <td>
                <input type="text" value="0" name="page" />
            </td>
        </tr>




    </table>
    <div style="text-align: center">
        <button id="capture_button" value="开始采购" type="button"></button>
        <input type="hidden" name="method" value="capture" />
    </div>


    <script src="../js/jquery.min.js"></script>
    <script>
        $(function () {
            $('#capture_button').click(function () {
                var data = $('form').serialize();
                $.ajax({
                    type: "POST",
                    url: "CaptureData.aspx",
                    data: data,
                    dataType: "json",
                    success: function (response) {
                        console.log(response);
                    }
                });
            });
        });
    </script>--%>
</asp:Content>

