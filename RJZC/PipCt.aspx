<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PipCt.aspx.cs" Inherits="Web_GZJL.RJZC.PipCt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title> <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

    <style type="text/css">
        .auto-style1 {
            width: 1164px;
        }
        .auto-style2 {
            width: 150px;
            height: 31px;
        }
        .auto-style3 {
            height: 31px;
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
                                                            <td class="auto-style1">


                                                                        <table  cellpadding="0"   cellspacing="0"  border="1px solid #6C9EC1" class="td2" style=" width:100%; border:1px;border-color: #6C9EC1; border-collapse:collapse; border-spacing:4px; height:50px;  ">
                                                                    <tr height="2px"  style="text-align:center ;">
                                                                        <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测厚仪编号</label></td>
                                                                          <td class="auto-style2" >
                                                                            <asp:TextBox ID="txt_hbh" runat="server" Width="180px" MaxLength="50"   ></asp:TextBox>
                                                                        </td>
                                                                           <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测厚仪精度</label></td>
                                                                           <td width="179">
                                                                            <asp:TextBox ID="txt_hjd" runat="server"  Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                    
                                                                      </tr>
                                                                          <tr style="text-align:center;">
                                                                       
                                                                          <td class="auto-style2"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >Mac</label></td>
                                                                          <td width="179" class="auto-style3" >

                                                                            <asp:TextBox ID="txt_Mac" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                       
                                                                                <td class="auto-style2"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >状态</label></td>
                                                                          <td width="179" class="auto-style3" >

                                                                            <asp:TextBox ID="txt_st" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                 
                                                                          </tr>
                                                                       <tr style="text-align:center;">
                                                                       
                                                                          <td class="auto-style2"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >型号</label></td>
                                                                          <td width="179" class="auto-style3" >

                                                                            <asp:TextBox ID="txt_model" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                       
                                                                               <td class="auto-style2"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >仪器号</label></td>
                                                                          <td width="179" class="auto-style3" >

                                                                            <asp:TextBox ID="txt_instr" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                 
                                                                          </tr>
                                                                            <tr style="text-align:center;">

                                                                                    <td class="auto-style2"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >到期时间</label></td>
                                                                          <td width="179" class="auto-style3" >

                                                                            <asp:TextBox ID="txt_end" TextMode="Date"  runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                               <td class="auto-style2"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >上次检验时间</label></td>
                                                                          <td width="179" class="auto-style3" >

                                                                            <asp:TextBox ID="txt_lastime" TextMode="Date"  runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                              
                                                                        </td>
                                                                             
                                                                            </tr>
   <tr style="text-align:center;">     <td width="150px" align="center" valign="middle" CssClass="a1">
                                                                    <asp:DropDownList ID="type" runat="server"    CssClass="a1" width=" 185px"    height=" 22px">
                                                                        <asp:ListItem Text="***请选择机构***" Value=""></asp:ListItem>
                                                                       
                                                                    </asp:DropDownList>
                                                                        </td>


          <td align="center" style="border:none" width="59">
                                                                                    <asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click" ToolTip="添加信息">&nbsp;&nbsp;添加</asp:LinkButton>
                                                                                </td>
                                                                                <td align="center" style="border:none" width="59">
                                                                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btn_find_Click" ToolTip="查询信息">&nbsp;&nbsp;查询</asp:LinkButton>
                                                                                </td>
   </tr>

                                                                    </table>

                                                            </td>
                                                        </tr>
                                                     
                                                        <tr style="height:135px;">
                                                        
                                                            <td class="auto-style1">
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                                    CellPadding="2" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                                                                    OnRowUpdating="GridView1_RowUpdating" BorderStyle="None" CellSpacing="1" CssClass="quanbu"
                                                                    OnRowDeleting="GridView1_RowDeleting" Height="200px" Width="1119px">
                                                                    <Columns>
                                                                         <asp:TemplateField HeaderText="机构名称 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_org" runat="server" Text='<%# Bind("Org") %>' Width="70px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_or" runat="server" Text='<%# Bind("Org") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="测厚仪编号 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_no" runat="server" Text='<%# Bind("Sbnumber") %>' Width="70px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_yb" runat="server" Text='<%# Bind("Sbnumber") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="型号" >
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_modelNum" runat="server" Text='<%# Bind("modelNum") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                             <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="model" runat="server" Text='<%# Bind("modelNum") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="测厚仪精度 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_jd" runat="server" Text='<%# Bind("Sbjingdu") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_yj" runat="server" Text='<%# Bind("Sbjingdu") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                          <asp:TemplateField HeaderText="MAC ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_mc" runat="server" Text='<%# Bind("Mac") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_mc" runat="server" Text='<%# Bind("Mac") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                          <asp:TemplateField HeaderText="仪器编号" >
                                                                              <EditItemTemplate>
                                                                                  <asp:TextBox ID="txt_instNum" runat="server" Text='<%# Bind("instrumentNum") %>'></asp:TextBox>
                                                                              </EditItemTemplate>
                                                                               <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                              <ItemTemplate>
                                                                                  <asp:Label ID="instrument" runat="server" Text='<%# Bind("instrumentNum") %>'></asp:Label>
                                                                              </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="上次校验时间" SortExpression="lastVeri">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_last" runat="server" Text='<%# Bind("lastVeri") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                             <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="last"  type="Date" runat="server" Text='<%# Bind("lastVeri") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="校验到期时间">

                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_end" runat="server" Text='<%# Bind("veriExpire") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                             <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="end" type="Date" runat="server" Text='<%# Bind("veriExpire") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                          <asp:TemplateField HeaderText="状态 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_zt" runat="server" Text='<%# Bind("State") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_st" runat="server" Text='<%# Bind("State") %>'></asp:Label>
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
                                                                                    CssClass="a2" Text="删除" OnClientClick=" return confirm('确认删除此测厚仪吗')"></asp:LinkButton>
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
