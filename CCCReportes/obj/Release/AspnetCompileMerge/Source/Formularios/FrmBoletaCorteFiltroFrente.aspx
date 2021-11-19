<%@ Page MasterPageFile="~/Formularios/General.Master" Language="vb" AutoEventWireup="false" CodeBehind="FrmBoletaCorteFiltroFrente.aspx.vb" Inherits="CCCReportes.FrmBoletaCorteFiltroFrente" %>


<%@ Register assembly="DevExpress.XtraReports.v19.2.Web.WebForms, Version=19.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register assembly="DevExpress.Web.v19.2, Version=19.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    
        .btnEstilo{
            margin-top: 20px;
        }

    .auto-style7 {
        width: 263px;
        height: 182px;
    }
        .auto-style6 {
            width: 83px;
        }
        .auto-style13 {
            width: 47px;
            height: 27px;
        }
        .auto-style14 {
            width: 83px;
            height: 27px;
        }
        .auto-style9 {
            width: 47px;
            height: 7px;
        }
        .auto-style10 {
            width: 83px;
            height: 7px;
        }
        .auto-style11 {
            width: 47px;
            height: 21px;
        }
        .auto-style12 {
            width: 83px;
            height: 21px;
        }
    .auto-style8 {
        width: 263px;
    }
        .auto-style15 {
            width: 47px;
        }

         #Background
    {
        position: fixed; 
        top: 0px; 
        bottom: 0px; 
        left: 0px; 
        right: 0px; 
        overflow: hidden; 
        padding: 0; 
        margin: 0; 
        background-color: #F0F0F0; 
        filter: alpha(opacity=80); 
        opacity: 0.8; 
        z-index: 100000;
    }
        
    #Progress
    {
        position: fixed;
        top: 40%; 
        left: 40%; 
        height:20%; 
        width:20%; 
        z-index: 100001;  
        background-color: #FFFFFF; 
        border:1px solid Gray; 
        background-image: url('Imagenes/loading.gif'); 
        background-repeat: no-repeat; 
        background-position:center;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:71%;">
        <tr>
            <td class="auto-style7"><strong style="text-align: center">Ingreso de Parametros:</strong>                
                        <table style="width:157%;">
                            <tr>
                                <td class="auto-style15">
                                    <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="@ZafraID:"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <dx:ASPxTextBox ID="txtZafraID" runat="server" Width="170px">
                                    </dx:ASPxTextBox>
                                    <%--   <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="@PeriodoID:"></asp:Label>
                                </td>
                                <td class="auto-style14">
                                    <dx:ASPxTextBox ID="txtPeriodoID" runat="server" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">
                                    <asp:Label ID="Label5" runat="server" style="font-weight: 700" Text="@FrenteID:"></asp:Label>
                                </td>
                                <td class="auto-style6">
                                    <dx:ASPxComboBox ID="cmbFrente" runat="server"  DataSourceID="SqlDataSource1" TextFormatString="{0}">
                                        <Columns>
                                            <dx:ListBoxColumn Caption="FiltroID" FieldName="FrenteID"/>
                                            <dx:ListBoxColumn Caption="Nombre" FieldName="Descripcion" />
                                        </Columns>
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CCCConnectionString %>" SelectCommand="SELECT [FrenteID], [Descripcion] FROM [Frentes]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">&nbsp;</td>
                                <td class="auto-style6">
                                    <asp:Button ID="btnProcesarReporte" runat="server" Text="Procesar Reporte" Width="169px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9">
                                    <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Impresión:" Visible="False"></asp:Label>
                                </td>
                                <td class="auto-style10">
                                    <dx:ASPxSpinEdit ID="txtCantidadCopias" runat="server" MaxValue="30" MinValue="1" Number="1" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11"></td>
                                <td class="auto-style12">
                                    <asp:Button ID="btnExportarReporte" runat="server" Text="Exportar Reporte..." Width="167px" Enabled="False" />
                                    <br />
                                    <asp:Button CssClass="btnEstilo" ID="btnDescargar" runat="server" Text="Descargar Reporte" Width="167px" Enabled="false" />
                                    <br />
                                    <asp:Button ID="btnImprimirReporte" runat="server" Text="Imprimir" Width="169px" Enabled="False" Visible="False" />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15"><strong>Formato:</strong></td>
                                <td class="auto-style6">
                                    <asp:RadioButtonList ID="rbFormat" runat="server" RepeatDirection="Horizontal" Width="164px">
                                        <asp:ListItem Text="Excel" Value="Excel" />
                                        <asp:ListItem Text="PDF" Value="PDF" Selected="True" />
                                    </asp:RadioButtonList>
                                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" GroupTreeImagesFolderUrl="false" Height="50px" SeparatePages="True" ToolbarImagesFolderUrl="false" ToolPanelView="None" ToolPanelWidth="200px" Width="350px" />
                                </td>
                            </tr>
                        </table>
                <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                   <ProgressTemplate>--%><%--<div id="Background"></div>
                        <div id="Progress">
                           <h6> <p style="text-align:center"> <b>Generando Reporte, espere por favor... <br /></b> </p> </h6>
                        </div>     --%><%--</ProgressTemplate>
                </asp:UpdateProgress>--%><%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <div id="dvReport">
                </div>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                                    &nbsp;</td>
        </tr>
    </table>
</asp:Content>

