Imports System.Data
Imports System.Data.SqlClient
Public Class CMPartnerType
    Private m_ConnStr As String
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_PARTNER_TYPE_ID As Integer
    Public Property PARTNER_TYPE_ID As Integer
        Get
            Return m_PARTNER_TYPE_ID
        End Get
        Set(value As Integer)
            m_PARTNER_TYPE_ID = value
        End Set
    End Property
    Private m_PARTNER_TYPE_NAME As String
    Public Property PARTNER_TYPE_NAME As String
        Get
            Return m_PARTNER_TYPE_NAME
        End Get
        Set(value As String)
            m_PARTNER_TYPE_NAME = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As Boolean
        Dim bComplete As Boolean = False
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM tbl_partner_type" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("PARTNER_TYPE_ID") = Me.PARTNER_TYPE_ID
                            dr("PARTNER_TYPE_NAME") = Me.PARTNER_TYPE_NAME
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
    Public Function GetData(pSQLWhere As String) As List(Of CMPartnerType)
        Dim lst As New List(Of CMPartnerType)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CMPartnerType
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM tbl_partner_type" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CMPartnerType(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_TYPE_ID"))) = False Then
                        row.PARTNER_TYPE_ID = rd.GetInt32(rd.GetOrdinal("PARTNER_TYPE_ID"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_TYPE_NAME"))) = False Then
                        row.PARTNER_TYPE_NAME = rd.GetString(rd.GetOrdinal("PARTNER_TYPE_NAME")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
End Class