Imports System.Data
Imports System.Data.SqlClient
Public Class CMPaymentType
    Private m_ConnStr As String
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
    End Sub

    Private m_payment_id As Integer
    Public Property payment_id As Integer
        Get
            Return m_payment_id
        End Get
        Set(value As Integer)
            m_payment_id = value
        End Set
    End Property
    Private m_payment_code As String
    Public Property payment_code As String
        Get
            Return m_payment_code
        End Get
        Set(value As String)
            m_payment_code = value
        End Set
    End Property
    Private m_payment_name As String
    Public Property payment_name As String
        Get
            Return m_payment_name
        End Get
        Set(value As String)
            m_payment_name = value
        End Set
    End Property
    Private m_ac_code_no As Integer
    Public Property ac_code_no As Integer
        Get
            Return m_ac_code_no
        End Get
        Set(value As Integer)
            m_ac_code_no = value
        End Set
    End Property
    Private m_payment_type As Integer
    Public Property payment_type As Integer
        Get
            Return m_payment_type
        End Get
        Set(value As Integer)
            m_payment_type = value
        End Set
    End Property
    Private m_payment_flg As Integer
    Public Property payment_flg As Integer
        Get
            Return m_payment_flg
        End Get
        Set(value As Integer)
            m_payment_flg = value
        End Set
    End Property
    Private m_bankaccount_id As Integer
    Public Property bankaccount_id As Integer
        Get
            Return m_bankaccount_id
        End Get
        Set(value As Integer)
            m_bankaccount_id = value
        End Set
    End Property
    Private m_created_date As Date
    Public Property created_date As Date
        Get
            Return m_created_date
        End Get
        Set(value As Date)
            m_created_date = value
        End Set
    End Property
    Private m_created_by As String
    Public Property created_by As String
        Get
            Return m_created_by
        End Get
        Set(value As String)
            m_created_by = value
        End Set
    End Property
    Private m_update_date As Date
    Public Property update_date As Date
        Get
            Return m_update_date
        End Get
        Set(value As Date)
            m_update_date = value
        End Set
    End Property
    Private m_update_by As String
    Public Property update_by As String
        Get
            Return m_update_by
        End Get
        Set(value As String)
            m_update_by = value
        End Set
    End Property
    Public Function SaveData(pSQLWhere As String) As Boolean
        Dim bComplete As Boolean = False
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()

                Using da As New SqlDataAdapter("SELECT * FROM tbl_ac_m_payment" & pSQLWhere, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("payment_id") = Me.payment_id
                            dr("payment_code") = Me.payment_code
                            dr("payment_name") = Me.payment_name
                            dr("ac_code_no") = Me.ac_code_no
                            dr("payment_type") = Me.payment_type
                            dr("payment_flg") = Me.payment_flg
                            dr("bankaccount_id") = Me.bankaccount_id
                            dr("created_date") = Me.created_date
                            dr("created_by") = Me.created_by
                            dr("update_date") = Me.update_date
                            dr("update_by") = Me.update_by
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
    Public Function GetData(pSQLWhere As String) As List(Of CMPaymentType)
        Dim lst As New List(Of CMPaymentType)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CMPaymentType
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM tbl_ac_m_payment" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CMPaymentType(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("payment_id"))) = False Then
                        row.payment_id = rd.GetInt32(rd.GetOrdinal("payment_id"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("payment_code"))) = False Then
                        row.payment_code = rd.GetString(rd.GetOrdinal("payment_code")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("payment_name"))) = False Then
                        row.payment_name = rd.GetString(rd.GetOrdinal("payment_name")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("ac_code_no"))) = False Then
                        row.ac_code_no = rd.GetInt32(rd.GetOrdinal("ac_code_no"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("payment_type"))) = False Then
                        row.payment_type = rd.GetInt32(rd.GetOrdinal("payment_type"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("payment_flg"))) = False Then
                        row.payment_flg = rd.GetInt32(rd.GetOrdinal("payment_flg"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("bankaccount_id"))) = False Then
                        row.bankaccount_id = rd.GetInt32(rd.GetOrdinal("bankaccount_id"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("created_date"))) = False Then
                        row.created_date = CDate(rd.GetValue(rd.GetOrdinal("created_date")))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("created_by"))) = False Then
                        row.created_by = rd.GetString(rd.GetOrdinal("created_by")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("update_date"))) = False Then
                        row.update_date = CDate(rd.GetValue(rd.GetOrdinal("update_date")))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("update_by"))) = False Then
                        row.update_by = rd.GetString(rd.GetOrdinal("update_by")).ToString()
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
End Class