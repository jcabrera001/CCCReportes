<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Formularios/General.Master" CodeBehind="FrmGenBoletasSupervisoresCCC.aspx.vb" Inherits="CCCReportes.FrmGenBoletasSupervisoresCCC" %>
<%@ Register assembly="DevExpress.XtraReports.v19.2.Web.WebForms, Version=19.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v19.2, Version=19.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 7px;
        }
        .auto-style6 {
            width: 7px;
            height: 23px;
        }
        .auto-style7 {
            height: 23px;
        }
        .auto-style13 {
            width: 87px;
            height: 27px;
        }
        .auto-style14 {
            width: 215px;
            height: 27px;
        }
        .auto-style9 {
            width: 87px;
            height: 7px;
        }
        .auto-style10 {
            width: 215px;
            height: 7px;
        }
        .auto-style11 {
            width: 87px;
            height: 23px;
        }
        .auto-style12 {
            width: 215px;
            height: 23px;
        }
    .auto-style8 {
        width: 263px;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:71%;">
        <tr>
            <td class="auto-style7"><strong style="text-align: center">Ingreso de Parametros:</strong>
                <br />
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="@ZafraID:"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <dx:ASPxTextBox ID="txtZafraID" runat="server" Width="170px">
                            </dx:ASPxTextBox>
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
                        <td class="auto-style5">&nbsp;</td>
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
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style12">
                            <asp:Button ID="btnImprimirReporte" runat="server" Text="Imprimir" Width="169px" Enabled="False" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5"><strong>Formato:</strong></td>
                        <td class="auto-style6">
                            <asp:RadioButtonList ID="rbFormat" runat="server" RepeatDirection="Horizontal" Width="164px">
                                <asp:ListItem Text="Excel" Value="Excel" />
                                <asp:ListItem Text="PDF" Value="PDF" Selected="True" />
                            </asp:RadioButtonList>
                            <asp:Button ID="btnExportarReporte" runat="server" Text="Exportar Reporte..." Width="168px" Enabled="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <div id="dvReport">
                    <CR:CrystalReportViewer 
                        ID="CrystalReportViewer1" 
                        runat="server" AutoDataBind="True" 
                        EnableDatabaseLogonPrompt="False" 
                        GroupTreeImagesFolderUrl="false" 
                        Height="50px" 
                        ToolbarImagesFolderUrl="false" 
                        ToolPanelWidth="200px" 
                        Width="350px" 
                        EnableParameterPrompt="False" 
                        ToolPanelView="None" SeparatePages="True"
                      />
                </div>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
