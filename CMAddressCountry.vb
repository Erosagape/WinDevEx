Imports System.Data
Imports System.Data.SqlClient
Public Class CMAddressCountry
    Private m_ConnStr As String
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_COUNTRY_ID As Integer
    Public Property COUNTRY_ID As Integer
        Get
            Return m_COUNTRY_ID
        End Get
        Set(value As Integer)
            m_COUNTRY_ID = value
        End Set
    End Property
    Private m_COUNTRY_NAME As String
    Public Property COUNTRY_NAME As String
        Get
            Return m_COUNTRY_NAME
        End Get
        Set(value As String)
            m_COUNTRY_NAME = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As Boolean
        Dim bComplete As Boolean = False
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Address_Country" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("COUNTRY_ID") = Me.COUNTRY_ID
                            dr("COUNTRY_NAME") = Me.COUNTRY_NAME
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
    Public Function GetData(pSQLWhere As String) As List(Of CMAddressCountry)
        Dim lst As New List(Of CMAddressCountry)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CMAddressCountry
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Address_Country" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CMAddressCountry(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("COUNTRY_ID"))) = False Then
                        row.COUNTRY_ID = CInt(rd.GetInt64(rd.GetOrdinal("COUNTRY_ID")))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("COUNTRY_NAME"))) = False Then
                        row.COUNTRY_NAME = rd.GetString(rd.GetOrdinal("COUNTRY_NAME")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
End Class