﻿Imports System.Data
Imports System.Data.SqlClient
Public Class CMPartnerAttachment
    Private m_ConnStr As String
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
        ClearData()
    End Sub
    Private Sub ClearData()
        m_FileID = 0
        m_FileName = ""
        m_PARTNER_ID = 0
    End Sub
    Private m_PARTNER_ID As Long
    Public Property PARTNER_ID As Long
        Get
            Return m_PARTNER_ID
        End Get
        Set(value As Long)
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
                            Try
                                If da.Update(dt) > 0 Then
                                    bComplete = True
                                End If
                            Catch e As Exception
                                MessageBox.Show(e.Message)
                            End Try
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
                        row.PARTNER_ID = CLng(rd.GetValue(rd.GetOrdinal("PARTNER_ID")))
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
    Public Function IsValid() As String
        Dim msg As String = ""
        Try
            Using cn As New SqlConnection(m_ConnStr)
                cn.Open()
                Using rd As SqlDataReader = New SqlCommand("sp_columns 'tbl_partner_attachment'", cn).ExecuteReader
                    While rd.Read
                        Select Case rd("COLUMN_NAME").ToString()
                            Case "FileName"
                                If m_FileName.Length > CInt(rd("PRECISION")) Then
                                    msg &= "FileName ระบุได้แค่ " & CInt(rd("PRECISION")) & " ตัวอักษร" & vbCrLf
                                End If
                        End Select
                    End While
                End Using
            End Using
        Catch ex As Exception
            msg = ex.Message
        End Try
        Return msg
    End Function
End Class