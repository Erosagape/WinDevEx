Imports System.Configuration
Imports System.Data.SqlClient
Public Class CFunction
    Implements IDisposable
    Private Property MasterConnection As SqlConnection
    Public Property LogResult As String
    Private Sub IDisposable_Dispose() Implements IDisposable.Dispose
        If Not MasterConnection Is Nothing Then
            If MasterConnection.State = ConnectionState.Open Then
                MasterConnection.Close()

            End If
        End If
    End Sub
    Private Function ConnectMaster() As Boolean
        Try
            If Not MasterConnection Is Nothing Then
                If MasterConnection.State = ConnectionState.Open Then
                    MasterConnection.Close()
                End If
            End If
            Dim strConn As String = ConfigurationManager.ConnectionStrings("DevExDemoConn").ConnectionString
            MasterConnection = New SqlConnection(strConn)
            MasterConnection.Open()
            Return MasterConnection.State = ConnectionState.Open
            LogResult = "OK"
        Catch ex As Exception
            LogResult = ex.Message
            Return False
        End Try
    End Function
    Public Sub RunSQLData_Master(ptSQL As String)
        If ConnectMaster() = True Then
            Try
                Dim comm As New SqlCommand(ptSQL, MasterConnection)
                comm.CommandType = CommandType.Text
                comm.ExecuteNonQuery()
                LogResult = ""
            Catch ex As Exception
                LogResult = ex.Message
            End Try
        End If
    End Sub
    Public Function GetSQLData_Master(ptSQL As String) As DataTable
        Dim dt As New DataTable
        If ConnectMaster() = True Then
            Try
                Dim da As New SqlDataAdapter(ptSQL, MasterConnection)
                Dim cb As New SqlCommandBuilder(da)
                da.Fill(dt)
                LogResult = dt.Rows.Count.ToString()
            Catch ex As Exception
                LogResult = ex.Message
            End Try
        End If
        Return dt
    End Function
End Class