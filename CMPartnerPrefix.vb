Imports System.Data
Imports System.Data.SqlClient
Public Class CMPartnerPrefix
    Private m_ConnStr As String
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_Partner_Prefix_Id As Integer
    Public Property Partner_Prefix_Id As Integer
        Get
            Return m_Partner_Prefix_Id
        End Get
        Set(value As Integer)
            m_Partner_Prefix_Id = value
        End Set
    End Property
    Private m_PARTNER_BUSINESS_ID As Integer
    Public Property PARTNER_BUSINESS_ID As Integer
        Get
            Return m_PARTNER_BUSINESS_ID
        End Get
        Set(value As Integer)
            m_PARTNER_BUSINESS_ID = value
        End Set
    End Property
    Private m_Partner_Prefix__Name As String
    Public Property Partner_Prefix__Name As String
        Get
            Return m_Partner_Prefix__Name
        End Get
        Set(value As String)
            m_Partner_Prefix__Name = value
        End Set
    End Property
    Private m_Updated_By As String
    Public Property Updated_By As String
        Get
            Return m_Updated_By
        End Get
        Set(value As String)
            m_Updated_By = value
        End Set
    End Property
    Private m_Updated_Date As Date
    Public Property Updated_Date As Date
        Get
            Return m_Updated_Date
        End Get
        Set(value As Date)
            m_Updated_Date = value
        End Set
    End Property
    Private m_Partner_Prefix__Flg As Integer
    Public Property Partner_Prefix__Flg As Integer
        Get
            Return m_Partner_Prefix__Flg
        End Get
        Set(value As Integer)
            m_Partner_Prefix__Flg = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As Boolean
        Dim bComplete As Boolean = False
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM tbl_partner_prefix" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("Partner_Prefix_Id") = Me.Partner_Prefix_Id
                            dr("PARTNER_BUSINESS_ID") = Me.PARTNER_BUSINESS_ID
                            dr("Partner_Prefix__Name") = Me.Partner_Prefix__Name
                            dr("Updated_By") = Me.Updated_By
                            dr("Updated_Date") = Me.Updated_Date
                            dr("Partner_Prefix__Flg") = Me.Partner_Prefix__Flg
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
    Public Function GetData(pSQLWhere As String) As List(Of CMPartnerPrefix)
        Dim lst As New List(Of CMPartnerPrefix)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CMPartnerPrefix
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM tbl_partner_prefix" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CMPartnerPrefix(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Partner_Prefix_Id"))) = False Then
                        row.Partner_Prefix_Id = rd.GetInt32(rd.GetOrdinal("Partner_Prefix_Id"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_BUSINESS_ID"))) = False Then
                        row.PARTNER_BUSINESS_ID = rd.GetInt32(rd.GetOrdinal("PARTNER_BUSINESS_ID"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Partner_Prefix__Name"))) = False Then
                        row.Partner_Prefix__Name = rd.GetString(rd.GetOrdinal("Partner_Prefix__Name")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Updated_By"))) = False Then
                        row.Updated_By = rd.GetString(rd.GetOrdinal("Updated_By")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Updated_Date"))) = False Then
                        row.Updated_Date = CDate(rd.GetValue(rd.GetOrdinal("Updated_Date")))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Partner_Prefix__Flg"))) = False Then
                        row.Partner_Prefix__Flg = rd.GetInt32(rd.GetOrdinal("Partner_Prefix__Flg"))
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
End Class