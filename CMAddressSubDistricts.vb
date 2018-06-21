Imports System.Data
Imports System.Data.SqlClient
Public Class CMAddressSubDistricts
    Private m_ConnStr As String
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_Id As Integer
    Public Property Id As Integer
        Get
            Return m_Id
        End Get
        Set(value As Integer)
            m_Id = value
        End Set
    End Property
    Private m_Code As Integer
    Public Property Code As Integer
        Get
            Return m_Code
        End Get
        Set(value As Integer)
            m_Code = value
        End Set
    End Property
    Private m_SubdistrictsThai As String
    Public Property SubdistrictsThai As String
        Get
            Return m_SubdistrictsThai
        End Get
        Set(value As String)
            m_SubdistrictsThai = value
        End Set
    End Property
    Private m_SubdistrictsEnglish As String
    Public Property SubdistrictsEnglish As String
        Get
            Return m_SubdistrictsEnglish
        End Get
        Set(value As String)
            m_SubdistrictsEnglish = value
        End Set
    End Property
    Private m_Latitude As Integer
    Public Property Latitude As Integer
        Get
            Return m_Latitude
        End Get
        Set(value As Integer)
            m_Latitude = value
        End Set
    End Property
    Private m_Longitude As Integer
    Public Property Longitude As Integer
        Get
            Return m_Longitude
        End Get
        Set(value As Integer)
            m_Longitude = value
        End Set
    End Property
    Private m_DistrictId As Integer
    Public Property DistrictId As Integer
        Get
            Return m_DistrictId
        End Get
        Set(value As Integer)
            m_DistrictId = value
        End Set
    End Property
    Private m_ZipCode As Integer
    Public Property ZipCode As Integer
        Get
            Return m_ZipCode
        End Get
        Set(value As Integer)
            m_ZipCode = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As Boolean
        Dim bComplete As Boolean = False
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Address_SubDistricts" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("Id") = Me.Id
                            dr("Code") = Me.Code
                            dr("SubdistrictsThai") = Me.SubdistrictsThai
                            dr("SubdistrictsEnglish") = Me.SubdistrictsEnglish
                            dr("Latitude") = Me.Latitude
                            dr("Longitude") = Me.Longitude
                            dr("DistrictId") = Me.DistrictId
                            dr("ZipCode") = Me.ZipCode
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
    Public Function GetData(pSQLWhere As String) As List(Of CMAddressSubDistricts)
        Dim lst As New List(Of CMAddressSubDistricts)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CMAddressSubDistricts
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Address_SubDistricts" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CMAddressSubDistricts(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Id"))) = False Then
                        row.Id = rd.GetInt32(rd.GetOrdinal("Id"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Code"))) = False Then
                        row.Code = rd.GetInt32(rd.GetOrdinal("Code"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SubdistrictsThai"))) = False Then
                        row.SubdistrictsThai = rd.GetString(rd.GetOrdinal("SubdistrictsThai")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SubdistrictsEnglish"))) = False Then
                        row.SubdistrictsEnglish = rd.GetString(rd.GetOrdinal("SubdistrictsEnglish")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Latitude"))) = False Then
                        row.Latitude = rd.GetDecimal(rd.GetOrdinal("Latitude"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Longitude"))) = False Then
                        row.Longitude = rd.GetDecimal(rd.GetOrdinal("Longitude"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DistrictId"))) = False Then
                        row.DistrictId = rd.GetInt32(rd.GetOrdinal("DistrictId"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ZipCode"))) = False Then
                        row.ZipCode = rd.GetInt32(rd.GetOrdinal("ZipCode"))
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
End Class