<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jour.aspx.cs" Inherits="Web_GZJL.RJZC.Jour" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>  <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

    <style type="text/css">
        .auto-style1 {
            width: 150px;
            height: 2px;
        }
        .auto-style2 {
            height: 2px;
        }
        .auto-style3 {
            height: 85px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
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
                                        <td class="moren" width="96%">
                                            当前位置：<a href="../Main.aspx">首页</a>&gt;<span style="color: #1F65AE"><%=t1 %></span>&gt;<span style="color: #1F65AE"><%=t0 %></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                       
                        <tr>
                            <td align="center">
                                <table style="width: 100%">
                                    <tr>
                                    <td style="width: 10px"></td>
                                        <td align="left">
                                        <br />
                                            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="500">
                                            </asp:ScriptManager>
                                            <%--   <table id="Table2" cellspacing="0" cellpadding="0" border="0" width="41%">
                                            <tr align="center" style="height: 40px">
                                                <td>
                                                    <h2>
                                                       耦合剂名称</h2>
                                                </td>
                                            </tr>
                                        </table>--%>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <table cellpadding="0" cellspacing="0" class="td2" style="border-collapse: collapse">
                                                          <tr>
                                                            <td class="auto-style3">


                                                                        <table  cellpadding="0"   cellspacing="0"  border="1px solid #6C9EC1" class="td2" style=" width:100%; border:1px;border-color: #6C9EC1; border-collapse:collapse; border-spacing:4px; height:50px;  ">
                                                                    <tr  style="text-align:center ;">
                                                                        <td class="auto-style1">&nbsp;</td>
                                                                          <td class="auto-style2"  >
                                                                              &nbsp;</td>
                                                                           <td class="auto-style1">&nbsp;</td>
                                                                           <td width="179" class="auto-style2">
                                                                               &nbsp;</td>
                                                                    
                                                                      </tr>
                                                                          <tr style="text-align:center;">
                                                                       
                                                                          <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >姓名</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="txt_pname" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                       
                                                                                <td  style="width:150px;">
                                                                                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="btn_find_Click" ToolTip="查询信息">&nbsp;&nbsp;查询</asp:LinkButton>
                                                                              </td>
                                                                          <td width="179" >

                                                                              &nbsp;</td>
                                                                                 
                                                                          </tr>
                                                                          
                                                                          </tr>
                                                                      <tr  style="text-align:center;"> 
                                                              <td  style="width:150px;">
                                                                  &nbsp;</td>
                                                                           <td width="179">
                                                                               &nbsp;</td>
                                                          <td  align="center" width="59" style="border:none">
                                                                            &nbsp;</td>
                                                          <td align="center" width="59" style="border:none">
                                                                            &nbsp;</td>
                                                     </tr>
                                                                    </table>

                                                            </td>
                                                        </tr>
                                                     
                                                        <tr style="height:135px;">
                                                        
                                                            <td>
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                    CellPadding="2" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                                                                    OnRowUpdating="GridView1_RowUpdating" BorderStyle="None" CellSpacing="1" CssClass="quanbu"
                                                                    OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                                                    <Columns>

                                                                        <asp:TemplateField HeaderText="用户名">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_jg" runat="server" Text='<%# Bind("JCName") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_jg" runat="server" Text='<%# Bind("JCName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="姓名 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_xm" runat="server" Text='<%# Bind("usrname") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_xm" runat="server" Text='<%# Bind("usrname") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                          <asp:TemplateField HeaderText="菜单">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_sj" runat="server" Text='<%# Bind("shouji") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_sj" runat="server" Text='<%# Bind("shouji") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="具体动作">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_pass" runat="server" Text='<%# Bind("pass") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_sj" runat="server" Text='<%# Bind("pass") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>


                                                                          <asp:TemplateField HeaderText="IP">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_zw" runat="server" Text='<%# Bind("usrzhiwu") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_zw" runat="server" Text='<%# Bind("usrzhiwu") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderText="创建时间">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_role" runat="server" Text='<%# Bind("PeoRole") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_xm" runat="server" Text='<%# Bind("PeoRole") %>'></asp:Label>
                                                                            </ItemTemplate>
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
