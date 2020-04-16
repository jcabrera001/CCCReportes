Public Class General
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub CmdVolver_Click(sender As Object, e As EventArgs) Handles CmdVolver.Click
        Dim ObjUrl As New System.Uri("http://www.cahsa.hn")
        Dim ObjWebReq As System.Net.WebRequest
        Dim ObjResp As System.Net.WebResponse

        ObjWebReq = System.Net.WebRequest.Create(ObjUrl)
        Try
            ObjResp = ObjWebReq.GetResponse
            ObjResp.Close()
            ObjWebReq = Nothing

            Response.Redirect("http://www.cahsa.hn/CCC/Default.aspx")
        Catch ex As Exception
            Response.Redirect("http://amigoweb/CCC/Default.aspx")
        End Try
    End Sub
End Class