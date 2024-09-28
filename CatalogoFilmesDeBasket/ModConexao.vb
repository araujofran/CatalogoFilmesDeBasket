Imports System.Data.SqlClient

Module ModConexao
    Public conexao As New SqlConnection("Server =DESKTOP-5MV4H0C\SQLFRANCISCO; DataBase = sistema_baskete; Integrated Security = SSPI ")

    Sub abrir()

        If conexao.State = 0 Then
            conexao.Open()
        End If

    End Sub
    Sub fechar()

        If conexao.State = 1 Then
            conexao.Close()
        End If

    End Sub

    Public usuario As String





End Module
