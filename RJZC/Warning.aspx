<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Warning.aspx.cs" Inherits="Web_GZJL.RJZC.Warning" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>预警设置</title>
    <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

    <style type="text/css">
        .auto-style2 {
            height: 1px;
        }
    </style>

</head>
<body bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">  

    <script language="javascript">        window.history.forward(1); </script>

    <form id="Form1" method="post" runat="server">
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
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0" class="td2" style="border-collapse: collapse">
                                                                    <tr>
                                                                        <td class="auto-style2">
                                                                            类型</td>
                                                                      
                                                                        <td class="auto-style2">
                                                                            参数</td>
                                                                        <td class="auto-style2">
                                                                            备注</td>
                                                                    </tr>
                                                                   
                                                                    <tr>
                                                                          <td width="179">
                                                                             <asp:DropDownList ID="type" runat="server"     width=" 185px"    height=" 22px" OnSelectedIndexChanged="ddl_zhiwu_SelectedIndexChanged">
                                                                        <asp:ListItem Text="***请选择类型***" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="原始壁厚" Value="原始壁厚"></asp:ListItem>                                                                    
                                                                        <asp:ListItem Text="检验数据" Value="检验数据"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                        </td>
                                                                      
                                                                        <td width="297" align="left">
                                                                            <asp:TextBox ID="times" runat="server" Width="297px" MaxLength="100"></asp:TextBox>
                                                                        </td>
                                                                        <td width="297" align="left">
                                                                            <asp:TextBox ID="ystandard" runat="server" MaxLength="100" Width="297px"></asp:TextBox>
                                                                        </td>
                                                                        <td align="center" width="59" style="border:1px solid black">
                                                                            <asp:LinkButton ID="btn_add"  runat="server" ToolTip="添加信息" OnClick="btn_add_Click">&nbsp;&nbsp;添加</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                     
                                                        <tr style="height:135px;">
                                                        
                                                            <td>
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                    CellPadding="2" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                                                                    OnRowUpdating="GridView1_RowUpdating" BorderStyle="None" CellSpacing="1" CssClass="quanbu"
                                                                    OnRowDeleting="GridView1_RowDeleting" Width="852px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                                                    <Columns>
   <asp:TemplateField HeaderText="ID">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_id" runat="server" Text='<%# Bind("ID") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_id" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="类型">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_type" runat="server" Text='<%# Bind("type") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_zcname" runat="server" Text='<%# Bind("type") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderText="参数">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_times" runat="server" Text='<%# Bind("times") %>' Width="290px" MaxLength="100"
                                                                                    Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_times" type="number" runat="server" Text='<%# Bind("times") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="备注">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_ystand" runat="server" Text='<%# Bind("ystandard") %>' Width="290px" MaxLength="100"
                                                                                    Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="300px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_yst" runat="server" Text='<%# Bind("ystandard") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                     
 
                                                                                        <asp:TemplateField HeaderText="编辑" ShowHeader="False">
            <EditItemTemplate>

                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" Width="150px"
                    CommandName="Update" Text="更新"></asp:LinkButton>
                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" Width="150px"
                    CommandName="Cancel" Text="取消"></asp:LinkButton>
            </EditItemTemplate>
   <ItemStyle HorizontalAlign="Left" Width="150px" />
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                    CommandName="Edit" Text="编辑"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="删除">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete"
                                                                                    CssClass="a2" Text="删除" OnClientClick=" return confirm('确认删除此预警吗')"></asp:LinkButton>
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

