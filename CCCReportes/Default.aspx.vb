Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class _Default
    Inherits System.Web.UI.Page

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

    Protected Sub CmdIngresar_Click(sender As Object, e As EventArgs) Handles CmdIngresar.Click
        If Me.TxtUsuario.ToString.Length = 0 Then
            Me.TxtUsuario.Focus()
        End If

        If Me.TxtContrasena.ToString.Length = 0 Then
            Me.TxtContrasena.Focus()
        End If

        Dim ConnString As String = ""

        Dim rootWebConfig As System.Configuration.Configuration
        rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/CCCReportes")
        Dim ConnStrings As System.Configuration.ConnectionStringSettings
        ConnStrings = rootWebConfig.ConnectionStrings.ConnectionStrings("CCCConnectionString2")

        ConnString = ConnStrings.ConnectionString + "Data Source=" & Me.CmbBDD.Value.ToString.Trim & ";User ID=" & Me.TxtUsuario.Text.ToString.Trim & ";Password=" & Me.TxtContrasena.Text.ToString.Trim
        Dim objConn As New SqlConnection(ConnString)
        Dim Reader As SqlDataReader

        Try
            objConn.Open()
        Catch ex As Exception

            ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), UniqueID, "javascript:alert('" + ex.Message + "');", True)

            LblErrores.Text = "Fallo al acceder a la base de datos, contacte al administrador."
            LblErrores.Visible = True
        End Try

        Dim sSql As String = "Select A.Nombre, A.UsuarioID, A.EstaActivo, A.ZafraID, A.EsAdministrador, A.PerfilID, " +
            "IsNull(B.Descripcion,'') As PerfilDescrip From Usuarios A Left Join Perfiles B on A.PerfilID = B.PerfilID " +
            " Where A.UsuarioID ='" & Me.TxtUsuario.Text.Trim & "'"
        Dim objCmd As New SqlCommand(sSql, objConn)
        Try
            ''            objCmd.CommandTimeout = 
            Reader = objCmd.ExecuteReader()

            If Reader.HasRows Then
                Reader.Read()
                LblErrores.Text = ""
                LblErrores.Visible = False

                Session("BDD") = Me.CmbBDD.Value.ToString.Trim
                Session("Nombre") = Reader("Nombre")
                Session("UsuarioID") = Reader("UsuarioID")
                Session("CCCConnectionString") = ConnString
                Session("pwd") = TxtContrasena.Text
                'Session("EmpresaID") = Reader(3)
                Session("ZafraID") = Reader("ZafraID")
                'Session("EsAdministrador") = Reader(4)
                Session("PerfilID") = Reader("PerfilID")
                Session("PerfilDescrip") = Reader("PerfilDescrip")
                'Session("FrenteID") = 0
                Session("Timeout") = 0

                If Reader("EstaActivo") = 1 Then
                    LblErrores.Text = "Usuario inactivo."
                    LblErrores.Visible = True
                    Return
                End If
                'Response.Redirect("~/Formularios/FrmGenPrincipalCCC.aspx")
                Response.Redirect("~/Formularios/FrmGenPrincipalCCC.aspx")
                Return
            Else
                LblErrores.Text = "Usuario o contraseña no correctos, intente nuevamente."
                LblErrores.Visible = True
            End If
            objConn.Close()
        Catch ex As Exception
            LblErrores.Text = ex.Message
            Return
        End Try
    End Sub
End Class