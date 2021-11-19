<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="CCCReportes._Default" %>

<%@ Register assembly="DevExpress.Web.v16.1, Version=16.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
            width: 331px;
        }
        .auto-style2 {
            width: 331px;
        }
        .auto-style3 {
            width: 328px;
        }
        .auto-style4 {
            width: 339px;
        }
        .auto-style5 {
            height: 21px;
            width: 101px;
        }
        .auto-style15 {
            height: 21px;
        }
        .auto-style14 {
            height: 6px;
        }
        .auto-style10 {
            height: 19px;
            width: 101px;
        }
        .auto-style11 {
            height: 19px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style1"><strong>Control de Cosecha de Caña</strong></td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Reportes</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <dx:ASPxButton ID="CmdVolver" runat="server" Text="Volver al sistema" Theme="Metropolis" Visible="False">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <table style="width: 100%; height: 135px;">
                        <tr>
                            <td class="auto-style1" colspan="3"><strong>Acceso al sistema</strong></td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Usuario</td>
                            <td class="auto-style1">
                                <dx:ASPxTextBox ID="TxtUsuario" runat="server" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                            <td class="auto-style1"></td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Contraseña</td>
                            <td>
                                <dx:ASPxTextBox ID="TxtContrasena" runat="server" Password="True" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style5">Base de datos</td>
                            <td class="auto-style15">
                                <dx:ASPxComboBox ID="CmbBDD" runat="server" SelectedIndex="0">
                                    <Items>
                                        <dx:ListEditItem Selected="True" Text="Base de datos Real" Value="AMIGOWEB\AMIGOWEB" />
                                        <dx:ListEditItem Text="Base de datos de Pruebas" Value="CCCPruebas" />
                                    </Items>
                                </dx:ASPxComboBox>
                            </td>
                            <td class="auto-style15"></td>
                        </tr>
                        <tr>
                            <td class="auto-style14" colspan="2">
                                <dx:ASPxLabel ID="LblErrores" runat="server" ForeColor="Red" Text="* Línea de errores" Visible="False">
                                </dx:ASPxLabel>
                            </td>
                            <td class="auto-style14"></td>
                        </tr>
                        <tr>
                            <td class="auto-style10"></td>
                            <td class="auto-style11">
                                <dx:ASPxButton ID="CmdIngresar" runat="server" style="height: 21px" Text="Ingresar" Theme="Aqua">
                                </dx:ASPxButton>
                            </td>
                            <td class="auto-style11"></td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Formularios/FrmGenPrincipalCCC.aspx" Visible="False">Ver los reportes del sistema</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    </form>
</body>
</html>
