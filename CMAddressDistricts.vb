Imports System.Data
Imports System.Data.SqlClient
Public Class CMAddressDistricts
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
    Private m_DistrictsThai As String
    Public Property DistrictsThai As String
        Get
            Return m_DistrictsThai
        End Get
        Set(value As String)
            m_DistrictsThai = value
        End Set
    End Property
    Private m_DistrictsEnglish As String
    Public Property DistrictsEnglish As String
        Get
            Return m_DistrictsEnglish
        End Get
        Set(value As String)
            m_DistrictsEnglish = value
        End Set
    End Property
    Private m_ProvinceId As Integer
    Public Property ProvinceId As Integer
        Get
            Return m_ProvinceId
        End Get
        Set(value As Integer)
            m_ProvinceId = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As Boolean
        Dim bComplete As Boolean = False
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Address_Districts" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("Id") = Me.Id
                            dr("Code") = Me.Code
                            dr("DistrictsThai") = Me.DistrictsThai
                            dr("DistrictsEnglish") = Me.DistrictsEnglish
                            dr("ProvinceId") = Me.ProvinceId
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
    Public Function GetData(pSQLWhere As String) As List(Of CMAddressDistricts)
        Dim lst As New List(Of CMAddressDistricts)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CMAddressDistricts
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Address_Districts" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CMAddressDistricts(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Id"))) = False Then
                        row.Id = rd.GetInt32(rd.GetOrdinal("Id"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Code"))) = False Then
                        row.Code = rd.GetInt32(rd.GetOrdinal("Code"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DistrictsThai"))) = False Then
                        row.DistrictsThai = rd.GetString(rd.GetOrdinal("DistrictsThai")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("DistrictsEnglish"))) = False Then
                        row.DistrictsEnglish = rd.GetString(rd.GetOrdinal("DistrictsEnglish")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ProvinceId"))) = False Then
                        row.ProvinceId = rd.GetInt32(rd.GetOrdinal("ProvinceId"))
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
End Class