Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmGenDetPlaSupxRendAgrupadoxFrente
    Inherits System.Web.UI.Page

    Public da As SqlDataAdapter = Nothing
    Public dtNombre, strUsuario, strPwd, strServer, strBd As String

    Protected Sub btnImprimirReporte_Click(sender As Object, e As EventArgs) Handles btnImprimirReporte.Click
        crystalReport = New ReportDocument()

        crystalReport = ProcesarReporteParametros2(crystalReport)
        crystalReport.PrintToPrinter(txtCantidadCopias.Value, False, 0, 0)
    End Sub

    Protected Sub btnExportarReporte_Click(sender As Object, e As EventArgs) Handles btnExportarReporte.Click
        Dim crystalReport As New ReportDocument()
        crystalReport = ProcesarReporteParametros2(crystalReport)
        Dim formatType As ExportFormatType = ExportFormatType.NoFormat
        Select Case rbFormat.SelectedItem.Value
            Case "Word"
                formatType = ExportFormatType.WordForWindows
                Exit Select
            Case "PDF"
                formatType = ExportFormatType.PortableDocFormat
                Exit Select
            Case "Excel"
                formatType = ExportFormatType.Excel
                Exit Select
            Case "CSV"
                formatType = ExportFormatType.CharacterSeparatedValues
                Exit Select
        End Select
        crystalReport.ExportToHttpResponse(formatType,
                       Response,
                       False,
                       "Detalle de Planilla Supervisores x Rendimiento Agrupado x Frente_" & txtPeriodoID.Text)

        'Dim Direccion As String = Server.MapPath("/ManuelOrtega.pdf")
        'crystalReport.ExportToDisk(formatType, Direccion)
        'ClientScript.RegisterStartupScript(Me.Page.[GetType](), "popupOpener", "var popup=window.open('/ManuelOrtega.pdf');popup.focus();", True)
    End Sub

    Public crystalReport As ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function ProcesarReporteParametros2(crystalReport1 As ReportDocument) As ReportDocument
        Try
            Dim report As New Det_de_Planilla_Sup_Rend_Agrupado_x_Frente()

            crystalReport1 = report

            strUsuario = Session("UsuarioID")
            strPwd = Session("pwd")
            strServer = Session("BDD")
            strBd = "CCC"

            crystalReport1.SetDatabaseLogon(strUsuario, strPwd, strServer, strBd)

            'CrystalReportViewer1.HasRefreshButton = True
            'CrystalReportViewer1.EnableParameterPrompt = True
            'CrystalReportViewer1.ReuseParameterValuesOnRefresh = True
            CrystalReportViewer1.HasPrintButton = False
            CrystalReportViewer1.HasExportButton = False
            crystalReport1.SetParameterValue(0, txtZafraID.Text)
            crystalReport1.SetParameterValue(1, txtPeriodoID.Text)

            CrystalReportViewer1.ReportSource = crystalReport1

            'Habilitar boton de imprimir y exportar reporte
            btnExportarReporte.Enabled = True
            btnImprimirReporte.Enabled = True

            Return crystalReport1
        Catch ex As Exception
            Response.Write("<script type=""text/javascript"">alert(""Error: [" & ex.Message & "] | [" &
                                                                      ex.Source & "] | [" & ex.StackTrace & "] | [" & ex.TargetSite.ToString & "] "");</script")
            Return crystalReport1
        End Try
    End Function

    Protected Sub btnProcesarReporte_Click(sender As Object, e As EventArgs) Handles btnProcesarReporte.Click
        crystalReport = New ReportDocument()
        crystalReport = ProcesarReporteParametros2(crystalReport)
    End Sub
End Class