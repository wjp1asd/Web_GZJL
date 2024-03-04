<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="people.aspx.cs" Inherits="Web_GZJL.admin.people" %>

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
                                                            <td>


                                                                        <table  cellpadding="0"   cellspacing="0"  border="1px solid #6C9EC1" class="td2" style=" width:100%; border:1px;border-color: #6C9EC1; border-collapse:collapse; border-spacing:4px; height:50px;  ">
                                                                    <tr  style="text-align:center ;">
                                                                        <td class="auto-style1"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;" >机构名称</label></td>
                                                                          <td class="auto-style2"  >
                               <asp:DropDownList ID="DropDownList1" runat="server"    width=" 185px"    height=" 22px" style="margin-left: 0px">
                                                                    </asp:DropDownList>
                                                                        </td>
                                                                           <td class="auto-style1"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >所属职位</label></td>
                                                                           <td width="179" class="auto-style2">
                                                                             <asp:DropDownList ID="ddl_zhiwu" runat="server"     width=" 185px"    height=" 22px" OnSelectedIndexChanged="ddl_zhiwu_SelectedIndexChanged">
                                                                        <asp:ListItem Text="***请选择职务***" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="主任" Value="主任"></asp:ListItem>                                                                    
                                                                        <asp:ListItem Text="检验员" Value="检验员"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                        </td>
                                                                    
                                                                      </tr>
                                                                          <tr style="text-align:center;">
                                                                       
                                                                          <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >姓名</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="txt_pname" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                       
                                                                                <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >手机</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="txt_Tel" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                 
                                                                          </tr>
                                                                             <tr style="text-align:center;">
                                                                       
                                                                          <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >办公电话</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="txt_phone" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                       
                                                                                <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >邮箱</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="txt_email" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                 
                                                                          </tr>
                                                                      <tr  style="text-align:center;"> 
                                                              <td  style="width:150px;">
                                                                  <label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-left: 5px;" >所属角色</label>

                                                              </td>
                                                                           <td width="179">
                                                                             <asp:DropDownList ID="DropDownList2" runat="server"     width=" 185px"    height=" 22px" OnSelectedIndexChanged="ddl_zhiwu_SelectedIndexChanged">
                                                                        <asp:ListItem Text="***请选择角色***" Value=""></asp:ListItem>
                                                                      
                                                                    </asp:DropDownList>
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
                                                     
                                                        <tr style="height:135px;">
                                                        
                                                            <td>
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                    CellPadding="2" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                                                                    OnRowUpdating="GridView1_RowUpdating" BorderStyle="None" CellSpacing="1" CssClass="quanbu"
                                                                    OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                                                    <Columns>
                                               <%--                           <asp:BoundField DataField="Id" HeaderText="id" Visible="false"  ItemStyle-CssClass ="hidden" HeaderStyle-CssClass="hidden" />--%>

                                                                        <asp:TemplateField HeaderText="机构单位 ">
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
                                                                        <asp:TemplateField HeaderText="职位 ">
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
                                                                        <asp:TemplateField HeaderText="角色 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_role" runat="server" Text='<%# Bind("PeoRole") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_js" runat="server" Text='<%# Bind("PeoRole") %>'></asp:Label>
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
                                                                          <asp:TemplateField HeaderText="手机 ">
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
                                                                         <asp:TemplateField HeaderText="密码 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_pass" runat="server" Text='<%# Bind("pass") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_mm" runat="server" Text='<%# Bind("pass") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                          <asp:TemplateField HeaderText="办公电话 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_dh" runat="server" Text='<%# Bind("bangongdh") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_dh" runat="server" Text='<%# Bind("bangongdh") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="邮箱 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_Eml" runat="server" Text='<%# Bind("Pemail") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_eml" runat="server" Text='<%# Bind("Pemail") %>'></asp:Label>
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
                                                                                    CssClass="a2" Text="删除" OnClientClick=" return confirm('确认删除此人员吗')"></asp:LinkButton>
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
