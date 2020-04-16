Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class FrmGenResCorteSemanalxSupervisor
    Inherits System.Web.UI.Page

    Public da As SqlDataAdapter = Nothing
    Public dtNombre, strUsuario, strPwd, strServer, strBd As String
    Public crystalReport As ReportDocument

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then

        'End If

        'Dim reportdocument As New ReportDocument()
        'Dim ruta As String = Server.MapPath("~/Reportes/CrystalReport1.rpt")
        'reportdocument.Load(ruta)
        'reportdocument.SetDatabaseLogon("rptuser", "SoloLectura2016!", "AMIGOWEB\AMIGOWEB", "CCC")
        'CrystalReportViewer1.ReportSource = reportdocument
    End Sub

    Public Sub EjemploUtilCRWeb()
        'Dim Documento As New ReportDocument()
        ' Se Crea un nuevo ReportDocument para el report
        'Dim Reporte As New DataSet()
        ' Se crea un nuevo DataSet para los datos
        'Reporte = ObtenerReporteCrystalReportWeb()

        ' Traemos los datos de la DB
        'Reporte.Tables(0).TableName = "ResCorteSemanalxSupervisor"
        'Dado que nuestro reporte usa un XSD debemos de dar el
        'nombre de la tabla

        'Documento.Load("Reportes/Resumen de Corte Semanal por Supervisor.rpt")
        'Documento.Load(Server.MapPath("/Reportes/Resumen de Corte Semanal por Supervisor.rpt"))
        'Documento.Load("~/Resumen de Corte Semanal por Supervisor.rpt")
        'Documento.Load("\\10.1.1.2\Reportes\CCC\Resumen de Corte Semanal por Supervisor.rpt")

        'Dim ruta As String = Server.MapPath("~/Reportes/CrystalReport1.rpt")
        'Documento.Load(ruta)

        'Documento.Load(Server.MapPath("\\10.1.1.2\Reportes\CCC\Resumen de Corte Semanal por Supervisor.rpt"))

        'Documento.Load("C:\inetpub\wwwroot\Web\CCCReportes\Reportes\Resumen de Corte Semanal por Supervisor.rpt")

        ' Asignamos la Ruta del reporte
        'Documento.SetDataSource(Reporte)
        'CrystalReportSource1.Report = Documento

        ' Asignamos el DataSet al DataSourse del ReportDocument
        'CRV1.ReportSource = Documento

        'Mostramos el Reporte
    End Sub

    Public Function GetReporte() As DataSet
        Dim PeliculaList As New DataSet()
        Using connection As New SqlConnection("Data Source=AMIGOWEB\AMIGOWEB;Initial Catalog=CCC;Persist Security Info=True;User ID=rptuser;Password=SoloLectura2016!")
            Dim comandoSql As New SqlCommand("spRptResumenCorteSemanalxSupervisor", connection)
            comandoSql.CommandType = CommandType.StoredProcedure

            Try
                If connection.State = ConnectionState.Closed Then
                    connection.Open()
                End If
                da = New SqlDataAdapter(comandoSql)
                da.SelectCommand.Parameters.Add("@ZafraID", SqlDbType.NVarChar).Value = "201701"
                da.SelectCommand.Parameters.Add("@PeriodoID", SqlDbType.NVarChar).Value = "2017S01"
                da.SelectCommand.Parameters.Add("@FrenteID", SqlDbType.Int).Value = 1

                da.Fill(PeliculaList)
            Catch ex As Exception
                Throw New Exception("Error al generar este reporte " + ex.Message, ex)
            Finally
                If connection IsNot Nothing Then
                    connection.Close()
                End If
            End Try
        End Using
        Return PeliculaList
    End Function

    Public Function ObtenerReporte() As DataSet
        Dim ds As New DataSet()
        Using connection As New SqlConnection("Data Source=AMIGOWEB\AMIGOWEB;Initial Catalog=CCC;Persist Security Info=True;User ID=rptuser;Password=SoloLectura2016!")
            'Dim comandoSql As New SqlCommand("spRptResumenCorteSemanalxSupervisor", connection)
            'comandoSql.CommandType = CommandType.StoredProcedure

            Try
                connection.Open()
                da = New SqlDataAdapter("spRptResumenCorteSemanalxSupervisor", connection)
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@ZafraID", SqlDbType.NVarChar).Value = "201701"
                da.SelectCommand.Parameters.Add("@PeriodoID", SqlDbType.NVarChar).Value = "2017S04"
                da.SelectCommand.Parameters.Add("@FrenteID", SqlDbType.Int).Value = 1
                dtNombre = "spRptResumentCorteSemanalxSupervisor;1"
                'dtNombre = "spRptResumenCorteSemanal;1"
                da.Fill(ds, dtNombre)
                'connection.Close()
            Catch ex As Exception
                Throw New Exception("Error al generar este reporte " + ex.Message, ex)
            Finally
                If connection IsNot Nothing Then
                    connection.Close()
                End If
            End Try
        End Using
        Return ds
    End Function

    Public Function ObtenerReporteCrystalReportWeb() As DataSet
        Dim ds As New DataSet
        Using connection As New SqlConnection("Data Source=AMIGOWEB\AMIGOWEB;Initial Catalog=CCC;Persist Security Info=True;User ID=rptuser;Password=SoloLectura2016!")
            'Dim comandoSql As New SqlCommand("spRptResumenCorteSemanalxSupervisor", connection)
            'comandoSql.CommandType = CommandType.StoredProcedure

            Try
                connection.Open()
                da = New SqlDataAdapter("spPruebasCrystalReportWeb", connection)
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                'da.SelectCommand.Parameters.Add("@ZafraID", SqlDbType.NVarChar).Value = "201701"
                'da.SelectCommand.Parameters.Add("@PeriodoID", SqlDbType.NVarChar).Value = "2017S03"
                'da.SelectCommand.Parameters.Add("@FrenteID", SqlDbType.Int).Value = 1
                dtNombre = "spPruebasCrystalReportWeb;1"
                da.Fill(ds, dtNombre)
                'connection.Close()
            Catch ex As Exception
                Throw New Exception("Error al generar este reporte " + ex.Message, ex)
            Finally
                If connection IsNot Nothing Then
                    connection.Close()
                End If
            End Try
        End Using
        Return ds
    End Function


    Public Function ProcesarReporteParametros1(crystalReport As ReportDocument) As ReportDocument
        '
        ' Creo el parametro y asigno el nombre
        '
        Dim ZafraID As New ParameterField()
        ZafraID.ParameterFieldName = "@ZafraID"
        Dim PeriodoID As New ParameterField()
        PeriodoID.ParameterFieldName = "@PeriodoID"
        Dim FrenteID As New ParameterField()
        FrenteID.ParameterFieldName = "@FrenteID"

        '
        ' creo el valor que se asignara al parametro
        '
        Dim discreteValueZafraID As New ParameterDiscreteValue()
        discreteValueZafraID.Value = "201701"
        ZafraID.CurrentValues.Add(discreteValueZafraID)

        Dim discreteValuePeriodoID As New ParameterDiscreteValue()
        discreteValuePeriodoID.Value = "2017S04"
        PeriodoID.CurrentValues.Add(discreteValuePeriodoID)

        Dim discreteValueFrenteID As New ParameterDiscreteValue()
        discreteValueFrenteID.Value = 1
        FrenteID.CurrentValues.Add(discreteValueFrenteID)

        '
        ' Asigno el paramametro a la coleccion
        '
        Dim paramFiels As New ParameterFields()
        paramFiels.Add(ZafraID)
        paramFiels.Add(PeriodoID)
        paramFiels.Add(FrenteID)


        '
        ' Creo la instancia del reporte
        '
        'Dim report As New CrystalReport2()

        '
        ' Cambio el path de la base de datos
        '
        'Dim rutadb As String = Path.Combine(Application.StartupPath, "TestDb.mdb")
        'report.DataSourceConnections(0).SetConnection("", rutadb, False)
        'report.DataSourceConnections(0).SetConnection("AMIGOWEB\AMIGOWEB", "CCC", "rptuser", "SoloLectura2016!")

        '
        ' Asigno el reporte a visor
        '
        'CrystalReportViewer1.PrintMode = CrystalDecisions.Web.PrintMode.Pdf
        'Dim exportOpts As CrystalDecisions.Shared.ExportOptions = New CrystalDecisions.Shared.ExportOptions()
        'Dim pdfOpts As New CrystalDecisions.Shared.PdfRtfWordFormatOptions
        'exportOpts.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
        'exportOpts.ExportFormatOptions = pdfOpts
        'CrystalReportSource1.ReportDocument.ExportToHttpResponse(exportOpts, Response, False, "Ticket")

        'CrystalReportViewer1.PDFOneClickPrinting = True

        'crystalReport = report
        CrystalReportViewer1.ReportSource = crystalReport
        '
        ' Asigno la coleccion de parametros al Crystal Viewer
        '
        CrystalReportViewer1.ParameterFieldInfo = paramFiels

        Return crystalReport
    End Function

    Public Function ProcesarReporteParametros2(crystalReport1 As ReportDocument) As ReportDocument
        Try
            Dim report As New Resumen_de_Corte_Semanal_por_Supervisor()

            crystalReport1 = report

            strUsuario = Session("UsuarioID")
            strPwd = Session("pwd")
            strServer = Session("BDD")
            strBd = "CCC"

            crystalReport1.SetDatabaseLogon(strUsuario, strPwd, strServer, strBd)

            'crystalReport1.SetDatabaseLogon("rptuser", "SoloLectura2016!", "AMIGOWEB\AMIGOWEB", "CCC")
            'CrystalReportViewer1.HasRefreshButton = True
            'CrystalReportViewer1.EnableParameterPrompt = True
            'CrystalReportViewer1.ReuseParameterValuesOnRefresh = True
            CrystalReportViewer1.HasPrintButton = False
            CrystalReportViewer1.HasExportButton = False
            crystalReport1.SetParameterValue(0, txtZafraID.Text)
            'crystalReport.SetParameterValue(1, "1")
            crystalReport1.SetParameterValue(1, txtPeriodoID.Text)
            'crystalReport.SetParameterValue(3, "10")
            crystalReport1.SetParameterValue(2, cbxFrenteID.SelectedItem.Value)

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

    Sub ProcesarReportePrueba()
        Dim Reporte As New DataSet()
        Dim reportdocument As New ReportDocument()

        ' Se crea un nuevo DataSet para los datos
        Reporte = ObtenerReporte()
        Dim ruta As String = Server.MapPath("~/Reportes/CrystalReport2.rpt")
        reportdocument.Load(ruta)
        reportdocument.SetDataSource(Reporte)
        reportdocument.SetDatabaseLogon("rptuser", "SoloLectura2016!", "AMIGOWEB\AMIGOWEB", "CCC")
        CrystalReportViewer1.ReportSource = reportdocument

        CrystalReportViewer1.DataBind()
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
                       "Distribuido_Corte_Semanal_x_Supervisor_" & txtPeriodoID.Text)

        'Dim Direccion As String = Server.MapPath("/ManuelOrtega.pdf")
        'crystalReport.ExportToDisk(formatType, Direccion)
        'ClientScript.RegisterStartupScript(Me.Page.[GetType](), "popupOpener", "var popup=window.open('/ManuelOrtega.pdf');popup.focus();", True)

        'Dim streamPDF As System.IO.Stream
        'streamPDF = crystalReport.ExportToStream(formatType)

        'Dim stream As System.IO.MemoryStream = DirectCast(crystalReport.ExportToStream(formatType), System.IO.MemoryStream)
        'Response.Buffer = False
        'Response.Clear()

        'Response.AddHeader("content-disposition", "attachment;filename=EjemploExportacion.pdf")
        'Response.ContentType = "application/pdf"

        'Response.BinaryWrite(stream.ToArray())

        'Response.[End]()
    End Sub

    Protected Sub btnProcesarReporte_Click(sender As Object, e As EventArgs) Handles btnProcesarReporte.Click
        crystalReport = New ReportDocument()
        crystalReport = ProcesarReporteParametros2(crystalReport)
    End Sub

    Protected Sub btnImprimirReporte_Click(sender As Object, e As EventArgs) Handles btnImprimirReporte.Click
        crystalReport = New ReportDocument()

        crystalReport = ProcesarReporteParametros2(crystalReport)
        crystalReport.PrintToPrinter(txtCantidadCopias.Value, False, 0, 0)

    End Sub
End Class