Imports System.Data
Imports System.Data.SqlClient
Public Class CMAddressProvinces
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
    Private m_ProvincesThai As String
    Public Property ProvincesThai As String
        Get
            Return m_ProvincesThai
        End Get
        Set(value As String)
            m_ProvincesThai = value
        End Set
    End Property
    Private m_ProvincesEnglish As String
    Public Property ProvincesEnglish As String
        Get
            Return m_ProvincesEnglish
        End Get
        Set(value As String)
            m_ProvincesEnglish = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As Boolean
        Dim bComplete As Boolean = False
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM Address_Provinces" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("Id") = Me.Id
                            dr("Code") = Me.Code
                            dr("ProvincesThai") = Me.ProvincesThai
                            dr("ProvincesEnglish") = Me.ProvincesEnglish
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
    Public Function GetData(pSQLWhere As String) As List(Of CMAddressProvinces)
        Dim lst As New List(Of CMAddressProvinces)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CMAddressProvinces
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM Address_Provinces" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CMAddressProvinces(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Id"))) = False Then
                        row.Id = rd.GetInt32(rd.GetOrdinal("Id"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Code"))) = False Then
                        row.Code = rd.GetInt32(rd.GetOrdinal("Code"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ProvincesThai"))) = False Then
                        row.ProvincesThai = rd.GetString(rd.GetOrdinal("ProvincesThai")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ProvincesEnglish"))) = False Then
                        row.ProvincesEnglish = rd.GetString(rd.GetOrdinal("ProvincesEnglish")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
End Class