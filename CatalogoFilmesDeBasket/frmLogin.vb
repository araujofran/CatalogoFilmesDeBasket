Imports System.Data.SqlClient

Public Class frmLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_login.Click

        Dim usuario As String = txt_usuario.Text
        Dim senha As String = txt_senha.Text

        If usuario = "" Or senha = "" Then

            MsgBox("Preencha os campos")

        Else

            Dim cmd As New SqlCommand("iniciarSessao", conexao)

            Try
                abrir()
                cmd.CommandType = 4
                With cmd.Parameters

                    .AddWithValue("@Nome", usuario)
                    .AddWithValue("@Senha", senha)
                    .Add("@Msg", SqlDbType.VarChar, 100).Direction = 2
                    cmd.ExecuteNonQuery()
                End With

                usuario = txt_usuario.Text

                Dim msg As String = cmd.Parameters("@Msg").Value

                MsgBox(msg, vbInformation)

                If (msg = "Dados incorretos") Then

                    txt_senha.Clear()
                    txt_usuario.Clear()
                    txt_usuario.Focus()
                Else
                    Dim frm As New frmPrincipal
                    Me.Hide()
                    frm.ShowDialog()
                End If

            Catch ex As Exception

                MsgBox(ex.Message)

            End Try

            conexao.Close()


        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_fechar_Click(sender As Object, e As EventArgs) Handles btn_fechar.Click
        Dim confirma = MsgBox("Deseja sair?", vbYesNo + vbExclamation, "Atenção!!!")
        If confirma = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txt_usuario_TextChanged(sender As Object, e As EventArgs) Handles txt_usuario.TextChanged

    End Sub
End Class