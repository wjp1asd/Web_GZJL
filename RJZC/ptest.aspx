<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ptest.aspx.cs" Inherits="Web_GZJL.RJZC.ptest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
         <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

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
                                    <td style="width: 10px">&nbsp;</td>
                                        <td align="left">
                                        <br />
                                            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="500">
                                            </asp:ScriptManager>
                                    
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate> 
                                                             
                                                    <table cellpadding="0" cellspacing="0" class="td2" style="border-collapse: collapse">
                                                          <tr>
                                                            <td>
                                                                      <table  cellpadding="0"   cellspacing="0"  border="1px solid #6C9EC1" class="td2" style=" width:100%; border:1px;border-color: #6C9EC1; border-collapse:collapse; border-spacing:4px; height:50px;  ">
                                                                    <tr height="2px"  style="text-align:center ;">
                                                                        <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >任务单号</label></td>
                                                                          <td   style="border-right:none">
                                                                            <asp:TextBox ID="txt_copi" runat="server" Width="180px" MaxLength="50"      margin-left=" 5px"></asp:TextBox>
                                                                        </td>
                                                                           <td style="border:none"></td>
                                                                         <td style="border:none"></td>
                                                                         <td style="border:none"></td> 
                                                                          <td style="border: 1px solid #6c9ec1; border-left:none;border-right:none;"></td>
                                                                         <td style=" border : 1px solid #6c9ec1;border-left:0"  ></td> 
                                                                          </tr>
                                                                      <tr> 
                                                           <td style="border:none"></td>
                                                                         <td style="border:none"></td>
                                                                         <td style="border:none"></td> 
                                                                         <td style="border:none"></td>
                                                                         <td style="border:none"></td> 
                                                                        
                                                                             
                                                          <td align="center" width="59" style="border:none">
                                                                            <asp:LinkButton ID="LinkButton3" runat="server" ToolTip="查询信息" OnClick="btn_find_Click">&nbsp;&nbsp;查询</asp:LinkButton>
                                                                        </td>
                                                     </tr>
                                                                    </table>

                                                            </td>
                                                        </tr>
                                                     
                                                        <tr style="height:135px;">
                                                        
                                                            <td>
                                                                       <asp:GridView ID="GridView1" runat="server" CausesValidation="false" AutoGenerateColumns="False" BorderWidth="0px"
                                                                    CellPadding="2" OnRowCancelingEdit="GridView1_RowCancelingEdit"  
                                                                    BorderStyle="None" CellSpacing="1" CssClass="quanbu"
                                                                   KeyFieldName="Id" AllowSorting="true" PageSize="20" GridLines="None" DataKeyNames="id">
                                                                    <Columns>
                                                                     
                                                                       
         
                                                                      <asp:BoundField DataField="Id" HeaderText="id" Visible="false"  ItemStyle-CssClass ="hidden" HeaderStyle-CssClass="hidden" />
                                                                                       <asp:TemplateField HeaderText="任务单号 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_uscn" runat="server" Text='<%# Bind("RWNo") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_uc" runat="server" Text='<%# Bind("RWNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                 
                                                                             <asp:TemplateField HeaderText="分编号 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_na" runat="server" Text='<%# Bind("FNo") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_mc" runat="server" Text='<%# Bind("FNo") %>'></asp:Label>
                                                                           
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="耦合剂名称 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_th" runat="server" Text='<%# Bind("Oname") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_th" runat="server" Text='<%# Bind("Oname") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="测厚仪编号 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_fh" runat="server" Text='<%# Bind("ChNo") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_fh" runat="server" Text='<%# Bind("ChNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                      

                                                                            <asp:TemplateField HeaderText="表面状况 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_uscn" runat="server" Text='<%# Bind("Surface") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_uc" runat="server" Text='<%# Bind("Surface") %>'></asp:Label>
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
