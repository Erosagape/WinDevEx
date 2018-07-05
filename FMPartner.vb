Imports System.Configuration

Public Class FMPartner
    Friend conn As String = ConfigurationManager.ConnectionStrings("JSB_ERPDBConnectionString").ConnectionString
    Private Sub FMPartner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'JSB_ERPDBDataSet.Tbl_Partner' table. You can move, or remove it, as needed.
        SetDataSource()
        'set datasource for combos
        SetCboPartnerType()
        SetCboBranch()
        SetCboSource()
        SetCboCountry()
        SetCboPaymentType()
        SetCboCurrency()
        SetCboProvince()

    End Sub
    Private Sub SetDataSource()
        'set datasource for controls
        GridControl1.DataSource = New CMPartner(conn).GetData(" WHERE PARTNER_TYPE_ID=2 ")
    End Sub

    Private Sub SetCboPartnerType()
        cboPARTNER_BUSINESS_TYPE_ID.Properties.DataSource = New CMPartnerBusinessType(conn).GetData("")
        cboPARTNER_BUSINESS_TYPE_ID.Properties.DisplayMember = "PARTNER_BUSINESS_NAME"
        cboPARTNER_BUSINESS_TYPE_ID.Properties.ValueMember = "PARTNER_BUSINESS_ID"
    End Sub
    Private Sub SetCboBranch()
        cboPARTNER_BRANCH.Properties.Items.Add("สำนักงานใหญ่")
        cboPARTNER_BRANCH.Properties.Items.Add("สาขา")
    End Sub
    Private Sub SetCboSource()
        cboPARTNER_SOURCE.Properties.Items.Add("DOMESTIC")
        cboPARTNER_SOURCE.Properties.Items.Add("EXPORT")
    End Sub
    Private Sub SetCboCountry()
        cboPARTNER_COUNTRY_ID.Properties.DataSource = New CMAddressCountry(conn).GetData("")
        cboPARTNER_COUNTRY_ID.Properties.DisplayMember = "COUNTRY_NAME"
        cboPARTNER_COUNTRY_ID.Properties.ValueMember = "COUNTRY_ID"
    End Sub
    Private Sub SetCboPaymentType()
        Dim ds = From a In New CMPaymentType(conn).GetData("")
                 Select a.payment_id, a.payment_name

        cboPARTNER_PAYMENT_CONDITION.Properties.DataSource = ds
        cboPARTNER_PAYMENT_CONDITION.Properties.DisplayMember = "payment_name"
        cboPARTNER_PAYMENT_CONDITION.Properties.ValueMember = "payment_id"
    End Sub
    Private Sub SetCboCurrency()
        Dim ds = From a In New CMRate(conn).GetData("")
                 Select a.rate_id, a.rate_code, a.rate_name

        cboPARTNER_CURRATE_ID.Properties.DataSource = ds
        cboPARTNER_CURRATE_ID.Properties.DisplayMember = "rate_code"
        cboPARTNER_CURRATE_ID.Properties.ValueMember = "rate_id"
    End Sub
    Private Sub SetCboProvince()
        Dim ds = From a In New CMAddressProvinces(conn).GetData("")
                 Select a.Id, a.ProvincesThai

        cboPARTNER_ADDR_PROVINCE.Properties.DataSource = ds
        cboPARTNER_ADDR_PROVINCE.Properties.DisplayMember = "ProvincesThai"
        cboPARTNER_ADDR_PROVINCE.Properties.ValueMember = "Id"
    End Sub
    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click

    End Sub

    Private Sub FMPartner_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub PanelControl1_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl1.Paint

    End Sub

    Private Sub cboPARTNER_ADDR_PROVINCE_Validated(sender As Object, e As EventArgs) Handles cboPARTNER_ADDR_PROVINCE.Validated
        If cboPARTNER_ADDR_PROVINCE.EditValue Is Nothing Then Exit Sub
        Dim ds = From a In New CMAddressDistricts(conn).GetData(" WHERE ProvinceId=" & cboPARTNER_ADDR_PROVINCE.EditValue.ToString())
                 Select a.Id, a.DistrictsThai, a.DistrictsEnglish

        cboPARTNER_ADDRESS_AMPHOE.Properties.DataSource = ds
        cboPARTNER_ADDRESS_AMPHOE.Properties.DisplayMember = "DistrictsThai"
        cboPARTNER_ADDRESS_AMPHOE.Properties.ValueMember = "Id"
        cboPARTNER_ADDRESS_AMPHOE.EditValue = Nothing
        cboPARTNER_ADDRESS_DISTRICT.EditValue = Nothing
    End Sub

    Private Sub cboPARTNER_ADDRESS_AMPHOE_Validated(sender As Object, e As EventArgs) Handles cboPARTNER_ADDRESS_AMPHOE.Validated
        If cboPARTNER_ADDRESS_AMPHOE.EditValue Is Nothing Then Exit Sub
        Dim ds = From a In New CMAddressSubDistricts(conn).GetData(" WHERE DistrictId=" & cboPARTNER_ADDRESS_AMPHOE.EditValue.ToString())
                 Select a.Id, a.SubdistrictsThai, a.SubdistrictsEnglish

        cboPARTNER_ADDRESS_DISTRICT.Properties.DataSource = ds
        cboPARTNER_ADDRESS_DISTRICT.Properties.DisplayMember = "SubdistrictsThai"
        cboPARTNER_ADDRESS_DISTRICT.Properties.ValueMember = "Id"
        cboPARTNER_ADDRESS_DISTRICT.EditValue = Nothing
    End Sub
End Class