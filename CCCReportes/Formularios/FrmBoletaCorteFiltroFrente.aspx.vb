Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FrmBoletaCorteFiltroFrente
    Inherits System.Web.UI.Page

    Public da As SqlDataAdapter = Nothing
    Public dtNombre, strUsuario, strPwd, strServer, strBd As String
    Public crystalReport As ReportDocument


    Dim cr As New crBoletaCortero() 'BoletaCortero___filtro_FrenteCorte()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnImprimirReporte_Click(sender As Object, e As EventArgs) Handles btnImprimirReporte.Click
        crystalReport = New ReportDocument()

        crystalReport = ProcesarReporteParametros2(crystalReport)
        crystalReport.PrintToPrinter(txtCantidadCopias.Value, False, 0, 0)
    End Sub

    Protected Sub btnProcesarReporte_Click(sender As Object, e As EventArgs) Handles btnProcesarReporte.Click
        crystalReport = New ReportDocument()
        crystalReport = ProcesarReporteParametros2(crystalReport)
    End Sub

    Protected Sub btnExportarReporte_Click(sender As Object, e As EventArgs) Handles btnExportarReporte.Click
        Dim crystalReport As New ReportDocument()
        crystalReport = ProcesarReporteParametros2(crystalReport)
        Dim formatType As ExportFormatType = ExportFormatType.NoFormat
        Dim Adjunto As Boolean
        Adjunto = False
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
        crystalReport.ExportToHttpResponse(formatType, Response, Adjunto, "Boleta de Pago de Corteros_" & txtPeriodoID.Text)


    End Sub

    Public Function ProcesarReporteParametros2(crystalReport1 As ReportDocument) As ReportDocument
        Try
            Dim report As New crBoletaCortero()

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
            CrystalReportViewer1.HasExportButton = True
            crystalReport1.SetParameterValue(0, txtZafraID.Text)
            crystalReport1.SetParameterValue(1, txtPeriodoID.Text)
            crystalReport1.SetParameterValue(2, cmbFrente.Text)

            CrystalReportViewer1.ReportSource = crystalReport1

            'Habilitar boton de imprimir y exportar reporte
            btnExportarReporte.Enabled = True
            btnImprimirReporte.Enabled = True
            btnDescargar.Enabled = True

            Return crystalReport1
        Catch ex As Exception
            Response.Write("<script type=""text/javascript"">alert(""Error: [" & ex.Message & "] | [" &
            ex.Source & "] | [" & ex.StackTrace & "] | [" & ex.TargetSite.ToString & "] "");</script")
            Return crystalReport1
        End Try
    End Function
    Protected Sub btnDescargar_Click(sender As Object, e As EventArgs) Handles btnDescargar.Click
        InitReport()
        cr.ExportToDisk(ExportFormatType.PortableDocFormat, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString & "\Boleta de Pago de Corteros_" & txtPeriodoID.Text & ".pdf")
        Response.Write("<script type=""text/javascript"">alert(""Archivo creado exitosamente! "");</script")

    End Sub
    Private Function FormatoDocumento() As String
        Dim nombreReporte = "Reporte BoletaCorteros"
        Dim tipo As String
        'Select Case Integer.Parse(ddlTipos.SelectedValue)
        '    Case ExportFormatType.Excel
        '        tipo = “application/vnd.ms-excel”
        '        nombreReporte &= “.xls”
        '    Case ExportFormatType.RichText
        '        tipo = “application/rtf”
        '        nombreReporte &= “.rtf”
        '    Case ExportFormatType.WordForWindows
        '        tipo = “application/msword”
        '        nombreReporte &= “.doc”
        '    Case Else
        tipo = “application/pdf”
        nombreReporte &= “.pdf”
        'End Select
        Return tipo
    End Function
    Public Sub InitReport()

        Dim log As New Report
        log.Connectar("10.1.1.14\amigoweb", "CCC", Session("UsuarioID"), Session("pwd"))
        log.LogonRPT(cr)

        cr.SetParameterValue("@ZafraID", txtZafraID.Text)
        cr.SetParameterValue("@PeriodoID", txtPeriodoID.Text)
        cr.SetParameterValue("@frenteID", cmbFrente.Text)
    End Sub
End Class