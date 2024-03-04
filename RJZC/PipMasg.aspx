<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PipMasg.aspx.cs" Inherits="Web_GZJL.RJZC.PipMasg" %>

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
                                    <td style="width: 10px"></td>
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
                                                                        <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >管件名称</label></td>
                                                                           <td width="179">
                                                                            <asp:TextBox ID="TextBox4" runat="server"  Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                        <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;" >管件编号</label></td>
                                                                          <td  >
                                                                            <asp:TextBox ID="txt_lbmc" runat="server" Width="180px" MaxLength="50" CssClass="txt"></asp:TextBox>
                                                                        </td>
                                                                         <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >管道名称</label></td>
                                                                           <td width="179">
                                                                            <asp:TextBox ID="txt_lbmcbz" runat="server"  Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>  
                                                                     
                                                                        </tr>
                                                                     <tr height="2px" style="text-align:center;">
                                                                        <td   style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >管道级别</label></td>
                                                                             <td width="179" >
                                                                            <asp:TextBox ID="txt_man" runat="server" Width="180px" MaxLength="100"></asp:TextBox>
                                                                        </td> 
                                                                          <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >管道材质</label></td>
                                                                           <td width="179">
                                                                            <asp:TextBox ID="txt_tel" runat="server"  Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                          <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >筒体厚度</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="txt_ema" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                        </tr>
                                                                          <tr style="text-align:center;">
                                                                                <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >封头厚度</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="TextBox3" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                     <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >布点数量</label></td>
                                                                          <td width="179" >
                                                                     <asp:DropDownList ID="bdsl" runat="server"    CssClass="a1" width=" 185px"    height=" 22px"> 
                                                                        <asp:ListItem Text="***请选择数量***" Value=""></asp:ListItem>
                                                                        <asp:ListItem Text="变径管（9）" Value="9"></asp:ListItem>                                                                    
                                                                        <asp:ListItem Text="弯头（11）" Value="11"></asp:ListItem>
                                                                                                                                       
                                                                        <asp:ListItem Text="三通（13）" Value="13"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                          
                                                                        </td>
                                                                                  <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >使用单位</label></td>
                                                                          <td width="179" >
                                                                     <asp:DropDownList ID="orgname" runat="server"    CssClass="a1" width=" 185px"    height=" 22px"> 
                                                                       
                                                                    </asp:DropDownList>
                                                                        
                                                                         
                                                                        </td>
                                                                          </tr>
                                                                      <tr style="text-align:center;"> 
                                                        
                                                                       <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >管道规格</label></td>
                                                                           <td width="179">
                                                                            <asp:TextBox ID="TextBox2" runat="server"  Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                        </td>  <td  align="center" width="59" style="border:none">
                                                                              <asp:LinkButton ID="LinkButton5" runat="server" ToolTip="委托信息" OnClick="btn_WT_Click">&nbsp;&nbsp;委托</asp:LinkButton>
                                                                      
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
                                                                    OnRowDeleting="GridView1_RowDeleting" Width="1182px">
                                                                    <Columns>
                                                                             <asp:TemplateField  HeaderText="全选" >
                                                                            <HeaderTemplate><%--OnCheckedChanged="chkAll_CheckedChanged" --%>
                                                                                <asp:CheckBox  runat="server"  ID="chkAll" AutoPostBack="true" onclick="SetAll(this)"  Text="全选"/>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox runat="server" ID="chkItem" /> 
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                             <asp:TemplateField HeaderText="管件ID ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_na1" runat="server" Text='<%# Bind("ID") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_nm1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                              <asp:TemplateField HeaderText="管道名称 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_na" runat="server" Text='<%# Bind("ConName") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_nm" runat="server" Text='<%# Bind("ConName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                             <asp:TemplateField HeaderText="管件名称">
  <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_gj" runat="server" Text='<%# Bind("GuanJianNum") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
 <ItemTemplate>
                                                                                <asp:Label ID="lbl_gj" runat="server" Text='<%# Bind("GuanJianNum") %>'></asp:Label>
                                                                            </ItemTemplate>

                                                                             </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="管件编号 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_mc" runat="server" Text='<%# Bind("NumBer") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_pn" runat="server" Text='<%# Bind("NumBer") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                           <asp:TemplateField HeaderText="管道规格 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_gz" runat="server" Text='<%# Bind("GuandaoType") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_gg" runat="server" Text='<%# Bind("GuandaoType") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="管道级别 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_jb" runat="server" Text='<%# Bind("GudandaoJibie") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_jb" runat="server" Text='<%# Bind("GudandaoJibie") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="管道材质 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_cz" runat="server" Text='<%# Bind("Guandaocaizhi") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_cz" runat="server" Text='<%# Bind("Guandaocaizhi") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="筒体厚度 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_th" runat="server" Text='<%# Bind("JiantiHoudu") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_th" runat="server" Text='<%# Bind("JiantiHoudu") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="封头厚度 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_fh" runat="server" Text='<%# Bind("FengtouHoudu") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_fh" runat="server" Text='<%# Bind("FengtouHoudu") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="布点数量 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_bd" runat="server" Text='<%# Bind("BudianNum") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_bne" runat="server" Text='<%# Bind("BudianNum") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                                                                                                    <asp:TemplateField HeaderText="使用单位 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_uscn" runat="server" Text='<%# Bind("YonghuName") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_ud" runat="server" Text='<%# Bind("YonghuName") %>'></asp:Label>
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
                                                                                    CssClass="a2" Text="删除" OnClientClick=" return confirm('确认删除此管道吗')"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="50px" CssClass="dl" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="二维码" ShowHeader="False">
                                                                           
                                                                             <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                              <asp:Image ID="Image" runat="server" ImageUrl='<%# Eval("Image") %>' Width="50px" Height="50px" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                           <asp:TemplateField HeaderText="下载物料">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton5" runat="server" 
                                                                                    CssClass="a2" Text="下载物料"   CommandArgument='<%# Eval("ID") + "|" + Eval("NumBer") + "|" + Eval("ConName") %>'  OnClick="LinkButton5_Click"></asp:LinkButton>
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
                                            
                                          
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>+
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
     
   
</body>
</html>
<script type="text/javascript">
    function SetAll(obj) {
        var chk = document.getElementById("<%=this.GridView1.ClientID%>").getElementsByTagName("input");
        for (var i = 0; i < chk.length; i++) {
            if (chk[i].id = "chkItem") {
                if (chk[i].disabled == false) {
                    chk[i].checked = obj.checked;
                }
            }
        }
    }
    </script>       