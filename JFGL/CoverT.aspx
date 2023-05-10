<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoverT.aspx.cs" Inherits="Web_GZJL.JFGL.CoverT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />

      <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1"   method="post"   runat="server">
     <div>
        <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
            <tr>
                <td >
                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="zhong">
                                <table border="0" cellpadding="0" cellspacing="0" height="27" width="60%">
                                    <tr>
                                        <td align="right" height="21" width="3%">
                                            <img height="13" src="../img/left_2.gif" width="16" />
                                        </td>
                                        <td width="1%">
                                            &nbsp;
                                        </td>
                                        <td class="moren" width="96%" >
                                           当前位置：<a href="../Main.aspx">首页</a>&gt;<span style="color: #000 #1F65AE"><%=t1 %></span>&gt;<span style="color: #1F65AE"><%=t0 %></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                       
                        <tr  style="height:135px;">
                            <td align="center">
                                <table style="width: 100%">
                                    <tr>
                                    <td style="width: 10px"></td>
                                        <td align="left">
                                        <br />
                                            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="500">
                                            </asp:ScriptManager>
                                    
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <table   cellpadding="0" cellspacing="0" class="td2" style="border-collapse: collapse; ">
                                                          <tr>
                                                            <td>
                                                              <%--  <table cellpadding="0" cellspacing="0" class="td2" style="border-collapse: collapse">
                                                                    <tr height="2px">
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                   
                                                                    <tr>
                                                                        <td width="179" align="left">
                                                                            <asp:TextBox ID="txt_cna" runat="server" Width="180px" MaxLength="50"></asp:TextBox>
                                                                        </td>
                                                                        <td width="1px"></td>
                                                                        <td width="299" align="left">
                                                                            <asp:TextBox ID="txt_adres" runat="server" Width="297px" MaxLength="100"></asp:TextBox>
                                                                        </td>

                                                                              <td width="1px"></td>
                                                                        <td width="179" align="left">
                                                                            <asp:TextBox ID="txt_man" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                                                                        </td>     
                                                                                                                                                      <td width="1px"></td>
                                                                        <td width="179" align="left">
                                                                            <asp:TextBox ID="txt_tel" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                                                                        </td>
                                                                                                                                                      <td width="1px"></td>
                                                                        <td width="179" align="left">
                                                                            <asp:TextBox ID="txt_ema" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                                                                        </td>

                                                                        
                                                                              <td width="1px"></td>

                                                                        <td align="center" width="59" style="border:1px solid black">
                                                                            <asp:LinkButton ID="btn_add" runat="server" ToolTip="添加信息" OnClick="btn_add_Click">&nbsp;&nbsp;添加</asp:LinkButton>
                                                                        </td>
                                                                    </tr>border-collapse: collapse ; 
                                                                </table>--%>
                                                                <table  cellpadding="0"   cellspacing="0"  border="1px solid #6C9EC1" class="td2" style=" width:100%; border:1px;border-color: #6C9EC1; border-collapse:collapse; border-spacing:4px; height:50px;  ">
                                                                    <tr height="2px"  style="text-align:center ;">
                                                                        <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >单位名称</label></td>
                                                                          <td  >
                                                                            <asp:TextBox ID="txt_cna" runat="server" Width="180px" MaxLength="50"      margin-left=" 5px"></asp:TextBox>
                                                                        </td>
                                                                          <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >单位地址</label></td>
                                                                         <td   style="border-right:none"><%--1px solid #cde1ec--%>
                                                                            <asp:TextBox ID="txt_adres" runat="server" Width="260px" MaxLength="100"></asp:TextBox>
                                                                        </td>
                                                                          <td style=" border-right : 1px solid #cde1ec;border-left:0"  ></td>
                <td style=" border-left:0"  ></td>
                                                                        </tr>
                                                                     <tr height="2px" style="text-align:center;">
                                                                        <td   style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >联系人</label></td>
                                                                             <td width="179" >
                                                                            <asp:TextBox ID="txt_man" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                                                                        </td> 
                                                                          <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >联系电话</label></td>
                                                                           <td width="179">
                                                                            <asp:TextBox ID="txt_tel" runat="server" Width="260px" MaxLength="100"></asp:TextBox>
                                                                        </td>
                                                                          <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >单位邮件</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="txt_ema" runat="server" Width="178px" MaxLength="100"></asp:TextBox>
                                                                        </td>
                                                                        </tr>
                                                                      <tr> 
                                                           <td style="border:none">
                                                                        </td> <td style="border:none">
                                                                        </td> <td style="border:none">
                                                                        </td> <td style="border:none">
                                                                        </td>
                                                          <td  align="center" width="59" style="border:none">
                                                                            <asp:LinkButton ID="btn_add" runat="server" ToolTip="添加信息" OnClick="btn_add_Click">&nbsp;&nbsp;添加</asp:LinkButton>
                                                                        </td>
                                                          <td align="center" width="59" style="border:none">
                                                                            <asp:LinkButton ID="LinkButton3" runat="server" ToolTip="查询信息" OnClick="btn_find_Click">&nbsp;&nbsp;查询</asp:LinkButton>
                                                                        </td>
                                                     </tr>
                                                                    </table>

                                                            </td>
                                                             
                                                        </tr>
                                                   
                                                        <tr style="height:135px">
                                                        
                                                            <td>
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                    CellPadding="2" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                                                                    OnRowUpdating="GridView1_RowUpdating" BorderStyle="None" CellSpacing="1" CssClass="quanbu"
                                                                    OnRowDeleting="GridView1_RowDeleting">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="单位名称 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_mc" runat="server" Text='<%# Bind("Orgname") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_cn" runat="server" Text='<%# Bind("Orgname") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="单位地址">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_bz" runat="server" Text='<%# Bind("Orgadd") %>' Width="290px" MaxLength="100"
                                                                                    Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Orgadd") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="联系人">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_peo" runat="server" Text='<%# Bind("Orguser") %>' Width="170px" MaxLength="100"
                                                                                    Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Orguser") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="联系电话">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_pho" runat="server" Text='<%# Bind("Orgtel") %>' Width="170px" MaxLength="100"
                                                                                    Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Orgtel") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="邮件">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_ill" runat="server" Text='<%# Bind("Emaill") %>' Width="170px" MaxLength="100"
                                                                                    Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Emaill") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>





                                                                        <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                                                                            <EditItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                                                    Text="保存" ToolTip="保存编辑"></asp:LinkButton>
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                    Text="取消" ToolTip="取消编辑"></asp:LinkButton>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                                                                                    Text="编辑" ToolTip="编辑信息"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="删除">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                    CssClass="a2" Text="删除" OnClientClick=" return confirm('确认删除此用户吗')"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="dl" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <RowStyle CssClass="dan" />
                                                                    <HeaderStyle CssClass="biaoti" />
                                                                    <AlternatingRowStyle CssClass="suang" />
                                                                    <PagerStyle CssClass="biaoti" HorizontalAlign="Left" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                      
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
<script>
 







</script>
