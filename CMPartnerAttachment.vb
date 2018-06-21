Imports System.Data
Imports System.Data.SqlClient
Public Class CMPartnerAttachment
    Private m_ConnStr As String
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_PARTNER_ID As Integer
    Public Property PARTNER_ID As Integer
        Get
            Return m_PARTNER_ID
        End Get
        Set(value As Integer)
            m_PARTNER_ID = value
        End Set
    End Property
    Private m_FileID As Integer
    Public Property FileID As Integer
        Get
            Return m_FileID
        End Get
        Set(value As Integer)
            m_FileID = value
        End Set
    End Property
    Private m_FileName As String
    Public Property FileName As String
        Get
            Return m_FileName
        End Get
        Set(value As String)
            m_FileName = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As Boolean
        Dim bComplete As Boolean = False
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM tbl_partner_attachment" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("PARTNER_ID") = Me.PARTNER_ID
                            dr("FileID") = Me.FileID
                            dr("FileName") = Me.FileName
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
    Public Function GetData(pSQLWhere As String) As List(Of CMPartnerAttachment)
        Dim lst As New List(Of CMPartnerAttachment)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CMPartnerAttachment
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM tbl_partner_attachment" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CMPartnerAttachment(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_ID"))) = False Then
                        row.PARTNER_ID = rd.GetInt32(rd.GetOrdinal("PARTNER_ID"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("FileID"))) = False Then
                        row.FileID = rd.GetInt32(rd.GetOrdinal("FileID"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("FileName"))) = False Then
                        row.FileName = rd.GetString(rd.GetOrdinal("FileName")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
End Class