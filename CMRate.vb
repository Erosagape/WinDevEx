Imports System.Data
Imports System.Data.SqlClient
Public Class CMRate
    Private m_ConnStr As String
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_rate_id As Integer
    Public Property rate_id As Integer
        Get
            Return m_rate_id
        End Get
        Set(value As Integer)
            m_rate_id = value
        End Set
    End Property
    Private m_rate_code As String
    Public Property rate_code As String
        Get
            Return m_rate_code
        End Get
        Set(value As String)
            m_rate_code = value
        End Set
    End Property
    Private m_rate_name As String
    Public Property rate_name As String
        Get
            Return m_rate_name
        End Get
        Set(value As String)
            m_rate_name = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As Boolean
        Dim bComplete As Boolean = False
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM tbl_m_rate" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("rate_id") = Me.rate_id
                            dr("rate_code") = Me.rate_code
                            dr("rate_name") = Me.rate_name
                            If dr.RowState = DataRowState.Detached Then dt.Rows.Add(dr)
                            da.Update(dt)
                            bComplete = True
                        End Using
                    End Using
                End Using
            Catch ex As Exception
            End Try
        End Using
        Return bComplete
    End Function
    Public Function GetData(pSQLWhere As String) As List(Of CMRate)
        Dim lst As New List(Of CMRate)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CMRate
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM tbl_m_rate" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CMRate(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("rate_id"))) = False Then
                        row.rate_id = rd.GetInt32(rd.GetOrdinal("rate_id"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("rate_code"))) = False Then
                        row.rate_code = rd.GetString(rd.GetOrdinal("rate_code")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("rate_name"))) = False Then
                        row.rate_name = rd.GetString(rd.GetOrdinal("rate_name")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
End Class
