<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Etcp.aspx.cs" Inherits="Web_GZJL.RJZC.Etcp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
         <meta http-equiv="content-type" content="application/ms-excel; charset=UTF-8" />
    <link href="../css/css.css" type="text/css" rel="stylesheet" />

    <script language="JavaScript" src="../js/Divs.js" type="text/javascript"></script>

    <style type="text/css">
        .auto-style1 {
            width: 150px;
            height: 31px;
        }
        .auto-style2 {
            height: 31px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server"   enctype="multipart/form-data">
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
                                                              <asp:Panel ID="Panel1" runat="server" Width="100%">
                                                          
                                                    <table cellpadding="0" cellspacing="0" class="td2" style="border-collapse: collapse">
                                                          <tr>
                                                            <td>
                                                                      <table  cellpadding="0"   cellspacing="0"  border="1px solid #6C9EC1" class="td2" style=" width:100%; border:1px;border-color: #6C9EC1; border-collapse:collapse; border-spacing:4px; height:50px;  ">
                                                                    <tr height="2px"  style="text-align:center ;  border:1px solid #6C9EC1;">
                                                                        <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >管道/容器</label></td>
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
                                                                    CellPadding="2" OnRowCancelingEdit="GridView1_RowCancelingEdit"   OnSelectedIndexChanging="GridView1_SelectedIndexChanging"
                                                                    BorderStyle="None" CellSpacing="1" CssClass="quanbu"
                                                                   KeyFieldName="Id" AllowSorting="true" PageSize="20" GridLines="None" DataKeyNames="id">
                                                                    <Columns>
                                                                     
                                                                       
         
                                                                      <asp:BoundField DataField="Id" HeaderText="id" Visible="false"  ItemStyle-CssClass ="hidden" HeaderStyle-CssClass="hidden" />
                                                                                       <asp:TemplateField HeaderText="委托类别 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_uscn" runat="server" Text='<%# Bind("cptype") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_uc" runat="server" Text='<%# Bind("cptype") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                     <%--   <asp:TemplateField HeaderText="容器编号 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_mc" runat="server" Text='<%# Bind("NumBer") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_bh" runat="server" Text='<%# Bind("NumBer") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                             <asp:TemplateField HeaderText="名称 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_na" runat="server" Text='<%# Bind("ConName") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_mc" runat="server" Text='<%# Bind("ConName") %>'></asp:Label>
                                                                           
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
                                                                          <%--  <asp:TemplateField HeaderText="布点数量 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_bd" runat="server" Text='<%# Bind("BudianNum") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_bn" runat="server" Text='<%# Bind("BudianNum") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>

                                                                            <asp:TemplateField HeaderText="使用单位 ">
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txt_uscn" runat="server" Text='<%# Bind("YonghuName") %>' Width="170px"
                                                                                    MaxLength="50" Height="20px"></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="180px" />
                                                                            <HeaderStyle HorizontalAlign="Center" Width="180px" CssClass="dl" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl_uc" runat="server" Text='<%# Bind("YonghuName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                                       <asp:CommandField SelectText="检测" ShowCancelButton="False" ShowSelectButton="True">
                                                                    <HeaderStyle BorderColor="White" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                                                                        Width="100px" />
                                                                    <ItemStyle BorderColor="White" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                                                                        Width="100px" />
                                                                </asp:CommandField>                                 

                                                                       <%--  <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                                                    Text="检测" ToolTip="检测信息"></asp:LinkButton>--%>
                                                                              

                                                                    </Columns>
                                                                    <RowStyle CssClass="dan" />
                                                                    <HeaderStyle CssClass="biaoti" />
                                                                    <AlternatingRowStyle CssClass="suang" />
                                                                    <PagerStyle CssClass="biaoti" HorizontalAlign="Left" />
                                                                </asp:GridView>
                                                                              
                                                                          </td>
                                                         
                                                        </tr>
                                                      
                                                    </table>  </asp:Panel>
                                                           <asp:Panel ID="Panel2" runat="server" Width="100%"    Visible="false">
                                                                  <div  id="divimg"  runat ="server">
        <div> 
            <asp:Image ID="imgShow" runat="server"  Style="background:#FFF;width:100%;height:500px;"  />
        </div>
        <div><%-- <asp:FileUpload ID="fileSelect" runat="server" />    onchange="ExecBtnUpload(this)" 
            <asp:FileUpload ID="fileSelect" runat="server"  accept="image/*" onclick="btnUpload_Click(this)"   />-%> --%>  
             <asp:FileUpload ID="fileSelect"   runat="server" />
        </div>
        <div>
            <asp:Button ID="btnUpload" runat="server" Text="上传图片" OnClick="btnUpload_Click" />
               <asp:Label ID="labTipMsg" runat="server" Style="color: Red"></asp:Label>  
        </div>
    </div> 

                                                                                    <table  cellpadding="0"   cellspacing="0"  border="1px solid #6C9EC1" class="td2" style=" width:100%; border:1px;border-color: #6C9EC1; border-collapse:collapse; border-spacing:4px; height:50px;  ">
                                                                    <tr height="2px"  style="text-align:center ;">
                                                                        <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >任务单号</label></td>
                                                                          <td  >
                                                                            <asp:TextBox ID="RW_no" runat="server" Width="180px" MaxLength="50"      margin-left=" 5px"></asp:TextBox>
                                                                        </td>
                                                                           <td  style="width:150px;"><label  style="    font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >分编号</label></td>
                                                                           <td width="179">
                                                                            <asp:TextBox ID="RW_Fno" runat="server"  Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                    
                                                                     
                                                                       
                                                                          <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >名称</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="cp_name" runat="server" ReadOnly="true" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                        </tr>
                                                                          <tr style="text-align:center;">
                                                                                <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >耦合剂</label></td>
                                                                          <td width="179" >
                                                                                 <asp:DropDownList runat="server"  Width="180px"     id="ohj" AutoPostBack="true">
                            <asp:ListItem Text="text"   />  </asp:DropDownList>
                                                                            <%--  <asp:DropDownList runat="server" ID="oh">
                                                                              </asp:DropDownList>--%>
                                                                          <%-- <asp:TextBox ID="oh" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>--%>
                                                                        </td>
                                                                                     <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测厚仪编号</label></td>
                                                                          <td width="179" >
                                                                                 <asp:DropDownList runat="server"   Width="180px"    id="D_co" AutoPostBack="true" >
                            <asp:ListItem Text="text"   />  </asp:DropDownList>
                                                                            <%--<asp:TextBox ID="Ch_no" runat="server"  Width="180px" MaxLength="50" ></asp:TextBox>--%>
                                                                        </td>
                                                                                  <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >委托编号</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="WT_ID" runat="server"  ReadOnly="true"  Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                        <%--       <td style="border:none"></td>
                                                                         <td style="border:none"></td> --%>
                                                                          </tr>


   <tr style="text-align:center;">
                                                                                <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >表面状况</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="factp" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                     <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点编号1</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="cn1" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                  <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点厚度1</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="ch1" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                          </tr>

   <tr style="text-align:center;">
                                                                                <td class="auto-style1"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点编号2</label></td>
                                                                          <td width="179" class="auto-style2" >

                                                                            <asp:TextBox ID="cn2" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                     <td class="auto-style1"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点厚度2</label></td>
                                                                          <td width="179" class="auto-style2" >

                                                                            <asp:TextBox ID="ch2" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                  <td class="auto-style1"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点编号3</label></td>
                                                                          <td width="179" class="auto-style2" >

                                                                            <asp:TextBox ID="cn3" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                          </tr>

   <tr style="text-align:center;">
                                                                                <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点厚度3</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="ch3" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                     <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点编号4</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="cn4" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                  <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点厚度4</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="ch4" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                          </tr>

                                                                                           <tr style="text-align:center;">
                                                                                <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点编号5</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="cn5" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                     <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点厚度5</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="ch5" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                  <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点编号6</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="cn6" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                          </tr>


                                                                                           <tr style="text-align:center;">
                                                                                <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点厚度6</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="ch6" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                     <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点编号7</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="cn7" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                  <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点厚度7</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="ch7" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                          </tr>

                                                                                           <tr style="text-align:center;">
                                                                                <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点编号8</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="cn8" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                     <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点厚度8</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="ch8" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                  <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点编号9</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="cn9" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                          </tr>

                                                                                           <tr style="text-align:center;">
                                                                                <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点厚度9</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="ch9" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                     <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点编号10</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="cn10" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                  <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点厚度10</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="ch10" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                          </tr>

                                                                                           <tr style="text-align:center;">
                                                                                <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点编号11</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="cn11" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                     <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >测点厚度11</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="ch11" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                                 <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >管道/容器</label></td>
                                                                          <td width="179" >

                                                                            <asp:TextBox ID="cptp" runat="server" Width="180px" ReadOnly="true" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                                          </tr>


   <%--<tr style="text-align:center;">    <td  style="width:150px;"><label  style="     font-size:9px; line-height:31px;padding-top: 12px;margin-right: 5px;" >位图连接</label></td>
                                                                          <td  style="border-right:none">

                                                                            <asp:TextBox ID="TextBox24" runat="server" Width="180px" MaxLength="50" ></asp:TextBox>
                                                                        </td>
                                                           <td style="border: 1px solid #6c9ec1; border-left:none;border-right:none;"></td>
                                                                          <td style="border: 1px solid #6c9ec1; border-left:none;border-right:none;"></td>
                                                            <td style="border: 1px solid #6c9ec1; border-left:none;border-right:none;"></td>
                                                                         <td style=" border : 1px solid #6c9ec1;border-left:0"  ></td> 
                                                     </tr>--%>



                                                                      <tr> 
                                                           <td style="border:none"></td>
                                                                         <td style="border:none"></td>
                                                                         <td style="border:none"></td> 
                                                                        
                                                                           
                                                                         <td style="border:none"></td> 
                                                          <td  align="center" width="59" style="border:none">
                                                                            <asp:LinkButton ID="btn_add" runat="server" ToolTip="添加信息" OnClick="btn_JCadd_Click">&nbsp;&nbsp;添加</asp:LinkButton>
                                                                        </td>
                                                        
                                                                         <td style="border:none"></td> 
                                                     </tr>
                                                                    </table>
                                                              
                                                                                </asp:Panel>
                                                       
                                                </ContentTemplate>
                                        
                                                


                                                  <Triggers runat="server">     <asp:PostBackTrigger  runat="server" ControlID="btnUpload" />  
                                                       <asp:PostBackTrigger  runat="server" ControlID="btn_add" />  
                                                  </Triggers> 
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
       

      
 <%--   <div  id="divimg"  runat="server">
        <div> 
            <asp:Image ID="imgShow" runat="server"  Style="background:#FFF;width:120px;height:100px;"  />
        </div>
        <div>
            <asp:FileUpload ID="fileSelect" runat="server"  accept="image/*" onchange="ExecBtnUpload(this)"  />   
        </div><%-- style="display:none;"-%>
        <div>
            <asp:Button ID="btnUpload" runat="server" Text="上传图片" OnClick="btnUpload_Click" />
            <asp:Label ID="labTipMsg" runat="server" Style="color: Red"></asp:Label>  
        </div>
    </div>--%>
    </form>
</body>
</html>
<%-- <script>
     function ExecBtnUpload() {
         //模拟调用后台的上传图片方法（btnUpload_Click）
         window.document.getElementById('<%=btnUpload.ClientID %>').click();
         }
    </script>--%>
