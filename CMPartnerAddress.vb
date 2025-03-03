﻿Imports System.Data
Imports System.Data.SqlClient
Public Class CMPartnerAddress
    Private m_ConnStr As String
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
        ClearData()
    End Sub
    Private Sub ClearData()
        m_AddressType = ""
        m_Address_Amphoe = ""
        m_Address_Contact1 = ""
        m_Address_Contact2 = ""
        m_Address_District = ""
        m_Address_ID = 0
        m_Address_Maps = ""
        m_Address_Name = ""
        m_Address_Province = ""
        m_Address_Remark1 = ""
        m_Address_Remark2 = ""
        m_Address_Zipcode = ""
        m_Domestic = ""
        m_LastUpdate = Date.MinValue
        m_PARTNER_ID = 0
        m_RecordStatus = ""
        m_UpdateBy = ""
    End Sub
    Private m_Address_ID As Integer
    Public Property Address_ID As Integer
        Get
            Return m_Address_ID
        End Get
        Set(value As Integer)
            m_Address_ID = value
        End Set
    End Property
    Private m_PARTNER_ID As Long
    Public Property PARTNER_ID As Long
        Get
            Return m_PARTNER_ID
        End Get
        Set(value As Long)
            m_PARTNER_ID = value
        End Set
    End Property
    Private m_Domestic As String
    Public Property Domestic As String
        Get
            Return m_Domestic
        End Get
        Set(value As String)
            m_Domestic = value
        End Set
    End Property
    Private m_Address_Name As String
    Public Property Address_Name As String
        Get
            Return m_Address_Name
        End Get
        Set(value As String)
            m_Address_Name = value
        End Set
    End Property
    Private m_Address_Province As String
    Public Property Address_Province As String
        Get
            Return m_Address_Province
        End Get
        Set(value As String)
            m_Address_Province = value
        End Set
    End Property
    Private m_Address_District As String
    Public Property Address_District As String
        Get
            Return m_Address_District
        End Get
        Set(value As String)
            m_Address_District = value
        End Set
    End Property
    Private m_Address_Amphoe As String
    Public Property Address_Amphoe As String
        Get
            Return m_Address_Amphoe
        End Get
        Set(value As String)
            m_Address_Amphoe = value
        End Set
    End Property
    Private m_Address_Zipcode As String
    Public Property Address_Zipcode As String
        Get
            Return m_Address_Zipcode
        End Get
        Set(value As String)
            m_Address_Zipcode = value
        End Set
    End Property
    Private m_Address_Maps As String
    Public Property Address_Maps As String
        Get
            Return m_Address_Maps
        End Get
        Set(value As String)
            m_Address_Maps = value
        End Set
    End Property
    Private m_Address_Contact1 As String
    Public Property Address_Contact1 As String
        Get
            Return m_Address_Contact1
        End Get
        Set(value As String)
            m_Address_Contact1 = value
        End Set
    End Property
    Private m_Address_Contact2 As String
    Public Property Address_Contact2 As String
        Get
            Return m_Address_Contact2
        End Get
        Set(value As String)
            m_Address_Contact2 = value
        End Set
    End Property
    Private m_Address_Remark1 As String
    Public Property Address_Remark1 As String
        Get
            Return m_Address_Remark1
        End Get
        Set(value As String)
            m_Address_Remark1 = value
        End Set
    End Property
    Private m_Address_Remark2 As String
    Public Property Address_Remark2 As String
        Get
            Return m_Address_Remark2
        End Get
        Set(value As String)
            m_Address_Remark2 = value
        End Set
    End Property
    Private m_AddressType As String
    Public Property AddressType As String
        Get
            Return m_AddressType
        End Get
        Set(value As String)
            m_AddressType = value
        End Set
    End Property
    Private m_UpdateBy As String
    Public Property UpdateBy As String
        Get
            Return m_UpdateBy
        End Get
        Set(value As String)
            m_UpdateBy = value
        End Set
    End Property
    Private m_LastUpdate As Date
    Public Property LastUpdate As Date
        Get
            Return m_LastUpdate
        End Get
        Set(value As Date)
            m_LastUpdate = value
        End Set
    End Property
    Private m_RecordStatus As String
    Public Property RecordStatus As String
        Get
            Return m_RecordStatus
        End Get
        Set(value As String)
            m_RecordStatus = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As Boolean
        Dim bComplete As Boolean = False
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM tbl_partner_address" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            'dr("Address_ID") = Me.Address_ID
                            dr("PARTNER_ID") = Me.PARTNER_ID
                            dr("Domestic") = Me.Domestic
                            dr("Address_Name") = Me.Address_Name
                            dr("Address_Province") = Me.Address_Province
                            dr("Address_District") = Me.Address_District
                            dr("Address_Amphoe") = Me.Address_Amphoe
                            dr("Address_Zipcode") = Me.Address_Zipcode
                            dr("Address_Maps") = Me.Address_Maps
                            dr("Address_Contact1") = Me.Address_Contact1
                            dr("Address_Contact2") = Me.Address_Contact2
                            dr("Address_Remark1") = Me.Address_Remark1
                            dr("Address_Remark2") = Me.Address_Remark2
                            dr("AddressType") = Me.AddressType
                            dr("UpdateBy") = Me.UpdateBy
                            dr("LastUpdate") = Today.Date
                            dr("RecordStatus") = Me.RecordStatus
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
    Public Function GetData(pSQLWhere As String) As List(Of CMPartnerAddress)
        Dim lst As New List(Of CMPartnerAddress)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CMPartnerAddress
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM tbl_partner_address" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CMPartnerAddress(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address_ID"))) = False Then
                        row.Address_ID = CInt(rd.GetInt64(rd.GetOrdinal("Address_ID")))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_ID"))) = False Then
                        row.PARTNER_ID = CLng(rd.GetValue(rd.GetOrdinal("PARTNER_ID")))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Domestic"))) = False Then
                        row.Domestic = rd.GetString(rd.GetOrdinal("Domestic")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address_Name"))) = False Then
                        row.Address_Name = rd.GetString(rd.GetOrdinal("Address_Name")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address_Province"))) = False Then
                        row.Address_Province = rd.GetString(rd.GetOrdinal("Address_Province")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address_District"))) = False Then
                        row.Address_District = rd.GetString(rd.GetOrdinal("Address_District")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address_Amphoe"))) = False Then
                        row.Address_Amphoe = rd.GetString(rd.GetOrdinal("Address_Amphoe")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address_Zipcode"))) = False Then
                        row.Address_Zipcode = rd.GetString(rd.GetOrdinal("Address_Zipcode")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address_Maps"))) = False Then
                        row.Address_Maps = rd.GetString(rd.GetOrdinal("Address_Maps")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address_Contact1"))) = False Then
                        row.Address_Contact1 = rd.GetString(rd.GetOrdinal("Address_Contact1")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address_Contact2"))) = False Then
                        row.Address_Contact2 = rd.GetString(rd.GetOrdinal("Address_Contact2")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address_Remark1"))) = False Then
                        row.Address_Remark1 = rd.GetString(rd.GetOrdinal("Address_Remark1")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Address_Remark2"))) = False Then
                        row.Address_Remark2 = rd.GetString(rd.GetOrdinal("Address_Remark2")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("AddressType"))) = False Then
                        row.AddressType = rd.GetString(rd.GetOrdinal("AddressType")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UpdateBy"))) = False Then
                        row.UpdateBy = rd.GetString(rd.GetOrdinal("UpdateBy")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("LastUpdate"))) = False Then
                        row.LastUpdate = CDate(rd.GetValue(rd.GetOrdinal("LastUpdate")))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("RecordStatus"))) = False Then
                        row.RecordStatus = rd.GetString(rd.GetOrdinal("RecordStatus")).ToString()
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
                Using rd As SqlDataReader = New SqlCommand("sp_columns 'tbl_partner_address'", cn).ExecuteReader
                    While rd.Read
                        Select Case rd("COLUMN_NAME").ToString()
                            Case "Domestic"
                                If m_Domestic.Length > CInt(rd("PRECISION")) Then
                                    msg &= "Address.Domestic ระบุได้แค่ " & CInt(rd("PRECISION")) & " ตัวอักษร" & vbCrLf
                                End If
                            Case "Address_Name"
                                If m_Address_Name.Length > CInt(rd("PRECISION")) Then
                                    msg &= "Address.Address_Name ระบุได้แค่ " & CInt(rd("PRECISION")) & " ตัวอักษร" & vbCrLf
                                End If
                            Case "Address_Zipcode"
                                If m_Address_Zipcode.Length > CInt(rd("PRECISION")) Then
                                    msg &= "Address.ZipCode ระบุได้แค่ " & CInt(rd("PRECISION")) & " ตัวอักษร" & vbCrLf
                                End If
                            Case "Address_Contact1"
                                If m_Address_Contact1.Length > CInt(rd("PRECISION")) Then
                                    msg &= "Address.Contact1 ระบุได้แค่ " & CInt(rd("PRECISION")) & " ตัวอักษร" & vbCrLf
                                End If
                            Case "Address_Contact2"
                                If m_Address_Contact2.Length > CInt(rd("PRECISION")) Then
                                    msg &= "Address.Contact2 ระบุได้แค่ " & CInt(rd("PRECISION")) & " ตัวอักษร" & vbCrLf
                                End If
                            Case "Address_Remark1"
                                If m_Address_Remark1.Length > CInt(rd("PRECISION")) Then
                                    msg &= "Address.Remark1 ระบุได้แค่ " & CInt(rd("PRECISION")) & " ตัวอักษร" & vbCrLf
                                End If
                            Case "Address_Remark2"
                                If m_Address_Remark2.Length > CInt(rd("PRECISION")) Then
                                    msg &= "Address.Remark2 ระบุได้แค่ " & CInt(rd("PRECISION")) & " ตัวอักษร" & vbCrLf
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