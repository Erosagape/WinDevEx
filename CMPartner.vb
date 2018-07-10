Imports System.Data.SqlClient
Public Class CMPartner
    Private m_PARTNER_ADDRESS As CMPartnerAddress
    Public Property PARTNER_ADDRESS As CMPartnerAddress
        Get
            Return m_PARTNER_ADDRESS
        End Get
        Set(value As CMPartnerAddress)
            m_PARTNER_ADDRESS = value
        End Set
    End Property
    Private m_PARTNER_ATTACHMENT As CMPartnerAttachment
    Public Property PARTNER_ATTACHMENT As CMPartnerAttachment
        Get
            Return m_PARTNER_ATTACHMENT
        End Get
        Set(value As CMPartnerAttachment)
            m_PARTNER_ATTACHMENT = value
        End Set
    End Property
    Private m_ConnStr As String
    Public Sub New(pConnStr As String)
        m_ConnStr = pConnStr
        ClearData()
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
    Private m_PARTNER_CODE As String
    Public Property PARTNER_CODE As String
        Get
            Return m_PARTNER_CODE
        End Get
        Set(value As String)
            m_PARTNER_CODE = value
        End Set
    End Property
    Private m_PARTNER_TYPE_ID As Integer
    Public Property PARTNER_TYPE_ID As Integer
        Get
            Return m_PARTNER_TYPE_ID
        End Get
        Set(value As Integer)
            m_PARTNER_TYPE_ID = value
        End Set
    End Property
    Private m_Partner_Prefix_Id As Integer
    Public Property Partner_Prefix_Id As Integer
        Get
            Return m_Partner_Prefix_Id
        End Get
        Set(value As Integer)
            m_Partner_Prefix_Id = value
        End Set
    End Property
    Private m_PARTNER_NAME_1 As String
    Public Property PARTNER_NAME_1 As String
        Get
            Return m_PARTNER_NAME_1
        End Get
        Set(value As String)
            m_PARTNER_NAME_1 = value
        End Set
    End Property
    Private m_PARTNER_NAME_2 As String
    Public Property PARTNER_NAME_2 As String
        Get
            Return m_PARTNER_NAME_2
        End Get
        Set(value As String)
            m_PARTNER_NAME_2 = value
        End Set
    End Property
    Private m_PARTNER_NAME_3 As String
    Public Property PARTNER_NAME_3 As String
        Get
            Return m_PARTNER_NAME_3
        End Get
        Set(value As String)
            m_PARTNER_NAME_3 = value
        End Set
    End Property
    Private m_PARTNER_BUSINESS_TYPE_ID As Integer
    Public Property PARTNER_BUSINESS_TYPE_ID As Integer
        Get
            Return m_PARTNER_BUSINESS_TYPE_ID
        End Get
        Set(value As Integer)
            m_PARTNER_BUSINESS_TYPE_ID = value
        End Set
    End Property
    Private m_PARTNER_INFORMATION As String
    Public Property PARTNER_INFORMATION As String
        Get
            Return m_PARTNER_INFORMATION
        End Get
        Set(value As String)
            m_PARTNER_INFORMATION = value
        End Set
    End Property
    Private m_PARTNER_CONTACT_1 As String
    Public Property PARTNER_CONTACT_1 As String
        Get
            Return m_PARTNER_CONTACT_1
        End Get
        Set(value As String)
            m_PARTNER_CONTACT_1 = value
        End Set
    End Property
    Private m_PARTNER_CONTACT_2 As String
    Public Property PARTNER_CONTACT_2 As String
        Get
            Return m_PARTNER_CONTACT_2
        End Get
        Set(value As String)
            m_PARTNER_CONTACT_2 = value
        End Set
    End Property
    Private m_PARTNER_TAX As String
    Public Property PARTNER_TAX As String
        Get
            Return m_PARTNER_TAX
        End Get
        Set(value As String)
            m_PARTNER_TAX = value
        End Set
    End Property
    Private m_PARTNER_SOURCE As Integer
    Public Property PARTNER_SOURCE As Integer
        Get
            Return m_PARTNER_SOURCE
        End Get
        Set(value As Integer)
            m_PARTNER_SOURCE = value
        End Set
    End Property
    Private m_PARTNER_DEFAULT_CREDIT As Integer
    Public Property PARTNER_DEFAULT_CREDIT As Integer
        Get
            Return m_PARTNER_DEFAULT_CREDIT
        End Get
        Set(value As Integer)
            m_PARTNER_DEFAULT_CREDIT = value
        End Set
    End Property
    Private m_PARTNER_DEFAULT_VAT_TYPE As Integer
    Public Property PARTNER_DEFAULT_VAT_TYPE As Integer
        Get
            Return m_PARTNER_DEFAULT_VAT_TYPE
        End Get
        Set(value As Integer)
            m_PARTNER_DEFAULT_VAT_TYPE = value
        End Set
    End Property
    Private m_PARTNER_BRANCH As Integer
    Public Property PARTNER_BRANCH As Integer
        Get
            Return m_PARTNER_BRANCH
        End Get
        Set(value As Integer)
            m_PARTNER_BRANCH = value
        End Set
    End Property
    Private m_PARTNER_AC_CODE_NO As Integer
    Public Property PARTNER_AC_CODE_NO As Integer
        Get
            Return m_PARTNER_AC_CODE_NO
        End Get
        Set(value As Integer)
            m_PARTNER_AC_CODE_NO = value
        End Set
    End Property
    Private m_PARTNER_ADDRESS_DOC As String
    Public Property PARTNER_ADDRESS_DOC As String
        Get
            Return m_PARTNER_ADDRESS_DOC
        End Get
        Set(value As String)
            m_PARTNER_ADDRESS_DOC = value
        End Set
    End Property
    Private m_PARTNER_REGIS_DATE As Date
    Public Property PARTNER_REGIS_DATE As Date
        Get
            Return m_PARTNER_REGIS_DATE
        End Get
        Set(value As Date)
            m_PARTNER_REGIS_DATE = value
        End Set
    End Property
    Private m_PARTNER_REGIS_BY As String
    Public Property PARTNER_REGIS_BY As String
        Get
            Return m_PARTNER_REGIS_BY
        End Get
        Set(value As String)
            m_PARTNER_REGIS_BY = value
        End Set
    End Property
    Private m_PARTNER_PROFILE_PIC As String
    Public Property PARTNER_PROFILE_PIC As String
        Get
            Return m_PARTNER_PROFILE_PIC
        End Get
        Set(value As String)
            m_PARTNER_PROFILE_PIC = value
        End Set
    End Property
    Private m_PhoneNo As String
    Public Property PhoneNo As String
        Get
            Return m_PhoneNo
        End Get
        Set(value As String)
            m_PhoneNo = value
        End Set
    End Property
    Private m_MobileNo As String
    Public Property MobileNo As String
        Get
            Return m_MobileNo
        End Get
        Set(value As String)
            m_MobileNo = value
        End Set
    End Property
    Private m_Attach_Pic1 As String
    Public Property Attach_Pic1 As String
        Get
            Return m_Attach_Pic1
        End Get
        Set(value As String)
            m_Attach_Pic1 = value
        End Set
    End Property
    Private m_Attach_Pic2 As String
    Public Property Attach_Pic2 As String
        Get
            Return m_Attach_Pic2
        End Get
        Set(value As String)
            m_Attach_Pic2 = value
        End Set
    End Property
    Private m_Attach_Pic3 As String
    Public Property Attach_Pic3 As String
        Get
            Return m_Attach_Pic3
        End Get
        Set(value As String)
            m_Attach_Pic3 = value
        End Set
    End Property
    Private m_Attach_Pic4 As String
    Public Property Attach_Pic4 As String
        Get
            Return m_Attach_Pic4
        End Get
        Set(value As String)
            m_Attach_Pic4 = value
        End Set
    End Property
    Private m_Attach_Pic5 As String
    Public Property Attach_Pic5 As String
        Get
            Return m_Attach_Pic5
        End Get
        Set(value As String)
            m_Attach_Pic5 = value
        End Set
    End Property
    Private m_Attach_Pic6 As String
    Public Property Attach_Pic6 As String
        Get
            Return m_Attach_Pic6
        End Get
        Set(value As String)
            m_Attach_Pic6 = value
        End Set
    End Property
    Private m_PartnerApproveBy As String
    Public Property PartnerApproveBy As String
        Get
            Return m_PartnerApproveBy
        End Get
        Set(value As String)
            m_PartnerApproveBy = value
        End Set
    End Property
    Private m_PartnerApproveDate As Date
    Public Property PartnerApproveDate As Date
        Get
            Return m_PartnerApproveDate
        End Get
        Set(value As Date)
            m_PartnerApproveDate = value
        End Set
    End Property
    Private m_FirstCreditAmount As Integer
    Public Property FirstCreditAmount As Integer
        Get
            Return m_FirstCreditAmount
        End Get
        Set(value As Integer)
            m_FirstCreditAmount = value
        End Set
    End Property
    Private m_SaleCondition As String
    Public Property SaleCondition As String
        Get
            Return m_SaleCondition
        End Get
        Set(value As String)
            m_SaleCondition = value
        End Set
    End Property
    Private m_PaymentChannel As String
    Public Property PaymentChannel As String
        Get
            Return m_PaymentChannel
        End Get
        Set(value As String)
            m_PaymentChannel = value
        End Set
    End Property
    Private m_UPDATED_BY As String
    Public Property UPDATED_BY As String
        Get
            Return m_UPDATED_BY
        End Get
        Set(value As String)
            m_UPDATED_BY = value
        End Set
    End Property
    Private m_UPDATED_DATE As Date
    Public Property UPDATED_DATE As Date
        Get
            Return m_UPDATED_DATE
        End Get
        Set(value As Date)
            m_UPDATED_DATE = value
        End Set
    End Property
    Private m_PARTNER_FLG As Integer
    Public Property PARTNER_FLG As Integer
        Get
            Return m_PARTNER_FLG
        End Get
        Set(value As Integer)
            m_PARTNER_FLG = value
        End Set
    End Property
    Private m_PARTNER_COUNTRY_ID As Integer
    Public Property PARTNER_COUNTRY_ID As Integer
        Get
            Return m_PARTNER_COUNTRY_ID
        End Get
        Set(value As Integer)
            m_PARTNER_COUNTRY_ID = value
        End Set
    End Property
    Private m_PARTNER_CURRATE_ID As Integer
    Public Property PARTNER_CURRATE_ID As Integer
        Get
            Return m_PARTNER_CURRATE_ID
        End Get
        Set(value As Integer)
            m_PARTNER_CURRATE_ID = value
        End Set
    End Property
    Private m_PARTNER_PAYTYPE_ID As Integer
    Public Property PARTNER_PAYTYPE_ID As Integer
        Get
            Return m_PARTNER_PAYTYPE_ID
        End Get
        Set(value As Integer)
            m_PARTNER_PAYTYPE_ID = value
        End Set
    End Property
    Private m_PARTNER_CREDIT_DAYS As Integer
    Public Property PARTNER_CREDIT_DAYS As Integer
        Get
            Return m_PARTNER_CREDIT_DAYS
        End Get
        Set(value As Integer)
            m_PARTNER_CREDIT_DAYS = value
        End Set
    End Property
    Private m_PARTNER_URL As String
    Public Property PARTNER_URL As String
        Get
            Return m_PARTNER_URL
        End Get
        Set(value As String)
            m_PARTNER_URL = value
        End Set
    End Property
    Private m_PARTNER_EMAIL As String
    Public Property PARTNER_EMAIL As String
        Get
            Return m_PARTNER_EMAIL
        End Get
        Set(value As String)
            m_PARTNER_EMAIL = value
        End Set
    End Property
    Public Function AddNew(pRunCount As Integer, pRunning As String, pType As String) As CMPartner
        Dim pReturn As Long = 0
        'ClearData()

        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()
                Dim pFormat As String = pType & pRunning & StrDup(pRunCount, "_")
ReQuery:
                Dim rd As SqlDataReader = New SqlCommand("SELECT ISNULL(MAX(PARTNER_ID),0) as t FROM tbl_partner WHERE PARTNER_ID Like '" & pFormat & "%'", cn).ExecuteReader()
                If rd.HasRows Then
                    rd.Read()
                    pReturn = CLng(rd.GetValue(0))
                End If
                rd.Close()
                If pReturn > 0 Then
                    pReturn = pReturn + 1
                Else
                    pReturn = CLng(pType & pRunning & 1.ToString(StrDup(pRunCount, "0")))
                End If
                If GetData(" WHERE PARTNER_ID=" & pReturn).Count() = 0 Then
                Else
                    GoTo ReQuery
                End If
                m_PARTNER_ID = pReturn
            Catch ex As Exception

            End Try
        End Using
        Return Me
    End Function
    Public Function SaveData() As Boolean
        Dim bComplete As Boolean = False
        Using cn As New SqlConnection(m_ConnStr)
            Try
                cn.Open()
                Using da As New SqlDataAdapter("SELECT * FROM tbl_partner WHERE PARTNER_ID=" & m_PARTNER_ID, cn)
                    Using cb As New SqlCommandBuilder(da)
                        Using dt As New DataTable
                            da.Fill(dt)
                            Dim dr As DataRow = dt.NewRow
                            If dt.Rows.Count > 0 Then dr = dt.Rows(0)
                            dr("PARTNER_ID") = Me.PARTNER_ID
                            dr("PARTNER_CODE") = Me.PARTNER_CODE
                            dr("PARTNER_TYPE_ID") = Me.PARTNER_TYPE_ID
                            dr("Partner_Prefix_Id") = Me.Partner_Prefix_Id
                            dr("PARTNER_NAME_1") = Me.PARTNER_NAME_1
                            dr("PARTNER_NAME_2") = Me.PARTNER_NAME_2
                            dr("PARTNER_NAME_3") = Me.PARTNER_NAME_3
                            dr("PARTNER_BUSINESS_TYPE_ID") = Me.PARTNER_BUSINESS_TYPE_ID
                            dr("PARTNER_INFORMATION") = Me.PARTNER_INFORMATION
                            dr("PARTNER_CONTACT_1") = Me.PARTNER_CONTACT_1
                            dr("PARTNER_CONTACT_2") = Me.PARTNER_CONTACT_2
                            dr("PARTNER_TAX") = Me.PARTNER_TAX
                            dr("PARTNER_SOURCE") = Me.PARTNER_SOURCE
                            dr("PARTNER_DEFAULT_CREDIT") = Me.PARTNER_DEFAULT_CREDIT
                            dr("PARTNER_DEFAULT_VAT_TYPE") = Me.PARTNER_DEFAULT_VAT_TYPE
                            dr("PARTNER_BRANCH") = Me.PARTNER_BRANCH
                            dr("PARTNER_AC_CODE_NO") = Me.PARTNER_AC_CODE_NO
                            dr("PARTNER_ADDRESS_DOC") = Me.PARTNER_ADDRESS_DOC
                            dr("PARTNER_REGIS_BY") = Me.PARTNER_REGIS_BY
                            dr("PARTNER_PROFILE_PIC") = Me.PARTNER_PROFILE_PIC
                            dr("PhoneNo") = Me.PhoneNo
                            dr("MobileNo") = Me.MobileNo
                            dr("Attach_Pic1") = Me.Attach_Pic1
                            dr("Attach_Pic2") = Me.Attach_Pic2
                            dr("Attach_Pic3") = Me.Attach_Pic3
                            dr("Attach_Pic4") = Me.Attach_Pic4
                            dr("Attach_Pic5") = Me.Attach_Pic5
                            dr("Attach_Pic6") = Me.Attach_Pic6
                            dr("PartnerApproveBy") = Me.PartnerApproveBy
                            dr("FirstCreditAmount") = Me.FirstCreditAmount
                            dr("SaleCondition") = Me.SaleCondition
                            dr("PaymentChannel") = Me.PaymentChannel
                            dr("UPDATED_BY") = Me.UPDATED_BY
                            dr("UPDATED_DATE") = Today.Date
                            dr("PARTNER_FLG") = Me.PARTNER_FLG
                            dr("PARTNER_COUNTRY_ID") = Me.PARTNER_COUNTRY_ID
                            dr("PARTNER_CURRATE_ID") = Me.PARTNER_CURRATE_ID
                            dr("PARTNER_PAYTYPE_ID") = Me.PARTNER_PAYTYPE_ID
                            dr("PARTNER_CREDIT_DAYS") = Me.PARTNER_CREDIT_DAYS
                            dr("PARTNER_URL") = Me.PARTNER_URL
                            dr("PARTNER_EMAIL") = Me.PARTNER_EMAIL
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
    Public Function GetData(pSQLWhere As String) As List(Of CMPartner)
        Dim lst As New List(Of CMPartner)
        Using cn As New SqlConnection(m_ConnStr)
            Dim row As CMPartner
            Try
                cn.Open()
                Dim rd As SqlDataReader = New SqlCommand("SELECT * FROM tbl_partner" & pSQLWhere, cn).ExecuteReader()
                While rd.Read()
                    row = New CMPartner(m_ConnStr)
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_ID"))) = False Then
                        row.PARTNER_ID = CLng(rd.GetValue(rd.GetOrdinal("PARTNER_ID")))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_CODE"))) = False Then
                        row.PARTNER_CODE = rd.GetString(rd.GetOrdinal("PARTNER_CODE")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_TYPE_ID"))) = False Then
                        row.PARTNER_TYPE_ID = rd.GetInt32(rd.GetOrdinal("PARTNER_TYPE_ID"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Partner_Prefix_Id"))) = False Then
                        row.Partner_Prefix_Id = rd.GetInt32(rd.GetOrdinal("Partner_Prefix_Id"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_NAME_1"))) = False Then
                        row.PARTNER_NAME_1 = rd.GetString(rd.GetOrdinal("PARTNER_NAME_1")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_NAME_2"))) = False Then
                        row.PARTNER_NAME_2 = rd.GetString(rd.GetOrdinal("PARTNER_NAME_2")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_NAME_3"))) = False Then
                        row.PARTNER_NAME_3 = rd.GetString(rd.GetOrdinal("PARTNER_NAME_3")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_BUSINESS_TYPE_ID"))) = False Then
                        row.PARTNER_BUSINESS_TYPE_ID = rd.GetInt32(rd.GetOrdinal("PARTNER_BUSINESS_TYPE_ID"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_INFORMATION"))) = False Then
                        row.PARTNER_INFORMATION = rd.GetString(rd.GetOrdinal("PARTNER_INFORMATION")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_CONTACT_1"))) = False Then
                        row.PARTNER_CONTACT_1 = rd.GetString(rd.GetOrdinal("PARTNER_CONTACT_1")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_CONTACT_2"))) = False Then
                        row.PARTNER_CONTACT_2 = rd.GetString(rd.GetOrdinal("PARTNER_CONTACT_2")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_TAX"))) = False Then
                        row.PARTNER_TAX = rd.GetString(rd.GetOrdinal("PARTNER_TAX")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_SOURCE"))) = False Then
                        row.PARTNER_SOURCE = rd.GetInt32(rd.GetOrdinal("PARTNER_SOURCE"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_DEFAULT_CREDIT"))) = False Then
                        row.PARTNER_DEFAULT_CREDIT = rd.GetInt32(rd.GetOrdinal("PARTNER_DEFAULT_CREDIT"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_DEFAULT_VAT_TYPE"))) = False Then
                        row.PARTNER_DEFAULT_VAT_TYPE = rd.GetInt32(rd.GetOrdinal("PARTNER_DEFAULT_VAT_TYPE"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_BRANCH"))) = False Then
                        row.PARTNER_BRANCH = rd.GetInt32(rd.GetOrdinal("PARTNER_BRANCH"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_AC_CODE_NO"))) = False Then
                        row.PARTNER_AC_CODE_NO = rd.GetInt32(rd.GetOrdinal("PARTNER_AC_CODE_NO"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_ADDRESS_DOC"))) = False Then
                        row.PARTNER_ADDRESS_DOC = rd.GetString(rd.GetOrdinal("PARTNER_ADDRESS_DOC")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_REGIS_DATE"))) = False Then
                        row.PARTNER_REGIS_DATE = CDate(rd.GetValue(rd.GetOrdinal("PARTNER_REGIS_DATE")))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_REGIS_BY"))) = False Then
                        row.PARTNER_REGIS_BY = rd.GetString(rd.GetOrdinal("PARTNER_REGIS_BY")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_PROFILE_PIC"))) = False Then
                        row.PARTNER_PROFILE_PIC = rd.GetString(rd.GetOrdinal("PARTNER_PROFILE_PIC")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PhoneNo"))) = False Then
                        row.PhoneNo = rd.GetString(rd.GetOrdinal("PhoneNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("MobileNo"))) = False Then
                        row.MobileNo = rd.GetString(rd.GetOrdinal("MobileNo")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Attach_Pic1"))) = False Then
                        row.Attach_Pic1 = rd.GetString(rd.GetOrdinal("Attach_Pic1")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Attach_Pic2"))) = False Then
                        row.Attach_Pic2 = rd.GetString(rd.GetOrdinal("Attach_Pic2")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Attach_Pic3"))) = False Then
                        row.Attach_Pic3 = rd.GetString(rd.GetOrdinal("Attach_Pic3")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Attach_Pic4"))) = False Then
                        row.Attach_Pic4 = rd.GetString(rd.GetOrdinal("Attach_Pic4")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Attach_Pic5"))) = False Then
                        row.Attach_Pic5 = rd.GetString(rd.GetOrdinal("Attach_Pic5")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("Attach_Pic6"))) = False Then
                        row.Attach_Pic6 = rd.GetString(rd.GetOrdinal("Attach_Pic6")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PartnerApproveBy"))) = False Then
                        row.PartnerApproveBy = rd.GetString(rd.GetOrdinal("PartnerApproveBy")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PartnerApproveDate"))) = False Then
                        row.PartnerApproveDate = CDate(rd.GetValue(rd.GetOrdinal("PartnerApproveDate")))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("FirstCreditAmount"))) = False Then
                        row.FirstCreditAmount = CInt(rd.GetDecimal(rd.GetOrdinal("FirstCreditAmount")))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("SaleCondition"))) = False Then
                        row.SaleCondition = rd.GetString(rd.GetOrdinal("SaleCondition")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PaymentChannel"))) = False Then
                        row.PaymentChannel = rd.GetString(rd.GetOrdinal("PaymentChannel")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UPDATED_BY"))) = False Then
                        row.UPDATED_BY = rd.GetString(rd.GetOrdinal("UPDATED_BY")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("UPDATED_DATE"))) = False Then
                        row.UPDATED_DATE = CDate(rd.GetValue(rd.GetOrdinal("UPDATED_DATE")))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_FLG"))) = False Then
                        row.PARTNER_FLG = rd.GetInt32(rd.GetOrdinal("PARTNER_FLG"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_COUNTRY_ID"))) = False Then
                        row.PARTNER_COUNTRY_ID = rd.GetInt32(rd.GetOrdinal("PARTNER_COUNTRY_ID"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_CURRATE_ID"))) = False Then
                        row.PARTNER_CURRATE_ID = rd.GetInt32(rd.GetOrdinal("PARTNER_CURRATE_ID"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_PAYTYPE_ID"))) = False Then
                        row.PARTNER_PAYTYPE_ID = rd.GetInt32(rd.GetOrdinal("PARTNER_PAYTYPE_ID"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_CREDIT_DAYS"))) = False Then
                        row.PARTNER_CREDIT_DAYS = rd.GetInt32(rd.GetOrdinal("PARTNER_CREDIT_DAYS"))
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_URL"))) = False Then
                        row.PARTNER_URL = rd.GetString(rd.GetOrdinal("PARTNER_URL")).ToString()
                    End If
                    If IsDBNull(rd.GetValue(rd.GetOrdinal("PARTNER_EMAIL"))) = False Then
                        row.PARTNER_EMAIL = rd.GetString(rd.GetOrdinal("PARTNER_EMAIL")).ToString()
                    End If
                    row.PARTNER_ADDRESS = New CMPartnerAddress(m_ConnStr).GetData(" WHERE PARTNER_ID=" & row.PARTNER_ID).FirstOrDefault
                    row.PARTNER_ATTACHMENT = New CMPartnerAttachment(m_ConnStr).GetData(" WHERE PARTNER_ID=" & row.PARTNER_ID).FirstOrDefault
                    If row.PARTNER_ADDRESS Is Nothing Then
                        row.PARTNER_ADDRESS = New CMPartnerAddress(m_ConnStr)
                    End If
                    If row.PARTNER_ATTACHMENT Is Nothing Then
                        row.PARTNER_ATTACHMENT = New CMPartnerAttachment(m_ConnStr)
                    End If
                    lst.Add(row)
                End While
            Catch ex As Exception
            End Try
        End Using
        Return lst
    End Function
    Private Sub ClearData()
        m_PARTNER_ID = 0
        m_Attach_Pic1 = ""
        m_Attach_Pic2 = ""
        m_Attach_Pic3 = ""
        m_Attach_Pic4 = ""
        m_Attach_Pic5 = ""
        m_Attach_Pic6 = ""
        m_FirstCreditAmount = 0
        m_MobileNo = ""
        m_PartnerApproveBy = ""
        m_PartnerApproveDate = Date.MinValue
        m_PARTNER_AC_CODE_NO = 0
        m_PARTNER_ADDRESS = New CMPartnerAddress(m_ConnStr)
        m_PARTNER_ADDRESS_DOC = ""
        m_PARTNER_ATTACHMENT = New CMPartnerAttachment(m_ConnStr)
        m_PARTNER_BRANCH = 0
        m_PARTNER_BUSINESS_TYPE_ID = 1
        m_PARTNER_CODE = ""
        m_PARTNER_CONTACT_1 = ""
        m_PARTNER_CONTACT_2 = ""
        m_PARTNER_COUNTRY_ID = -1
        m_PARTNER_CREDIT_DAYS = 0
        m_PARTNER_CURRATE_ID = -1
        m_PARTNER_DEFAULT_CREDIT = 0
        m_PARTNER_DEFAULT_VAT_TYPE = 0
        m_PARTNER_EMAIL = ""
        m_PARTNER_FLG = 0
        m_PARTNER_INFORMATION = ""
        m_PARTNER_NAME_1 = ""
        m_PARTNER_NAME_2 = ""
        m_PARTNER_NAME_3 = ""
        m_PARTNER_PAYTYPE_ID = -1
        m_Partner_Prefix_Id = -1
        m_PARTNER_PROFILE_PIC = ""
        m_PARTNER_REGIS_BY = ""
        m_PARTNER_REGIS_DATE = Date.MinValue
        m_PARTNER_SOURCE = -1
        m_PARTNER_TAX = ""
        m_PARTNER_TYPE_ID = -1
        m_PARTNER_URL = ""
        m_PaymentChannel = ""
        m_PhoneNo = ""
        m_SaleCondition = ""
        m_UPDATED_BY = ""
        m_UPDATED_DATE = Date.MinValue
    End Sub
End Class