Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class Report
    Dim LogInfo As CrystalDecisions.Shared.ConnectionInfo
    Public Sub Connectar(ByVal Server As String, ByVal DataBase As String, ByVal User As String, ByVal Password As String)
        LogInfo = New CrystalDecisions.Shared.ConnectionInfo
        LogInfo.ServerName = Server
        LogInfo.DatabaseName = DataBase
        LogInfo.UserID = User
        LogInfo.Password = Password

    End Sub
    Public Sub LogonRPT(ByRef Report As ReportDocument)
        Try
            Dim CrTableLogonInfos As New TableLogOnInfos
            Dim CrTableLogonInfo As New TableLogOnInfo
            Dim CrConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table

            CrConnectionInfo = LogInfo
            CrTables = Report.Database.Tables
            For Each CrTable In CrTables
                CrTableLogonInfo = CrTable.LogOnInfo
                CrTableLogonInfo.ConnectionInfo = CrConnectionInfo
                CrTable.ApplyLogOnInfo(CrTableLogonInfo)
            Next
            Report.VerifyDatabase()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "LogonRPT")
        End Try
    End Sub
End Class
