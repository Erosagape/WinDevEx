Imports System.Configuration
Imports DevExpress.XtraGrid.Views.Base

Public Class FMSupplier
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
        NewData()
    End Sub
    Private Sub SetDataSource()
        'set datasource for controls
        GridControl1.DataSource = New CMPartner(conn).GetData(" WHERE PARTNER_TYPE_ID=2 " & CStr(IIf(chkIncludeCancel.Checked, "", "AND ISNULL(PARTNER_FLG,0)<>9")))
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
    End Sub

    Private Sub cboPARTNER_ADDRESS_AMPHOE_Validated(sender As Object, e As EventArgs) Handles cboPARTNER_ADDRESS_AMPHOE.Validated

    End Sub

    Private Sub cboPARTNER_BUSINESS_TYPE_ID_Validated(sender As Object, e As EventArgs) Handles cboPARTNER_BUSINESS_TYPE_ID.Validated

    End Sub

    Private Sub cmdBrowseFile_Click(sender As Object, e As EventArgs) Handles cmdBrowseFile.Click
        If dlg.ShowDialog = DialogResult.OK Then
            txtPARTNER_ATTACHMENT_FILENAME.Text = New System.IO.FileInfo(dlg.FileName).Name
        End If
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        NewData()
    End Sub
    Private Sub NewData()
        Dim ds = New CMPartner(conn)
        Me.txtPARTNER_ID.EditValue = Nothing
        LoadData(ds)
    End Sub
    Private Sub Savedata()
        Try
            Dim data As New CMPartner(conn)
            If txtPARTNER_ID.EditValue Is Nothing Then
                data.AddNew(6, Now.AddYears(543).ToString("yy"), "2" & Me.cboPARTNER_BUSINESS_TYPE_ID.EditValue.ToString)
            Else
                data = data.GetData(" WHERE PARTNER_ID=" & txtPARTNER_ID.EditValue.ToString()).FirstOrDefault
            End If
            data.PARTNER_TYPE_ID = 2
            data.PARTNER_CODE = Me.txtPARTNER_CODE.EditValue.ToString
            data.PARTNER_TAX = Me.txtPARTNER_TAX.EditValue.ToString
            data.PARTNER_BUSINESS_TYPE_ID = CInt(Me.cboPARTNER_BUSINESS_TYPE_ID.EditValue)
            data.PARTNER_BRANCH = CInt(txtPARTNER_BRANCH.EditValue)
            data.PARTNER_SOURCE = Me.cboPARTNER_SOURCE.SelectedIndex
            data.PARTNER_COUNTRY_ID = CInt(Me.cboPARTNER_COUNTRY_ID.EditValue)
            data.PARTNER_PAYTYPE_ID = CInt(Me.cboPARTNER_PAYMENT_CONDITION.EditValue)
            data.PARTNER_CURRATE_ID = CInt(Me.cboPARTNER_CURRATE_ID.EditValue)
            data.PARTNER_CREDIT_DAYS = CInt(Me.txtPARTNER_CREDIT_DAY.EditValue)
            data.PARTNER_DEFAULT_VAT_TYPE = CInt(Me.txtPARTNER_DEFAULT_VAT_TYPE.EditValue)
            data.Partner_Prefix_Id = CInt(Me.cboPARTNER_PREFIX.EditValue)
            data.PARTNER_NAME_1 = Me.txtPARTNER_NAME1.EditValue.ToString()
            data.PARTNER_NAME_2 = Me.txtPARTNER_NAME2.EditValue.ToString()
            data.PARTNER_NAME_3 = Me.txtPARTNER_NAME3.EditValue.ToString()
            data.PARTNER_ADDRESS_DOC = Me.txtPARTNER_ADDRESS_DOC.EditValue.ToString
            data.PARTNER_CONTACT_1 = Me.txtPARTNER_CONTACT1.EditValue.ToString
            data.PhoneNo = Me.txtPARTNER_PHONENO.EditValue.ToString
            data.PARTNER_EMAIL = Me.txtPARTNER_EMAIL.EditValue.ToString
            data.PARTNER_URL = Me.txtPARTNER_WEBSITE.EditValue.ToString
            data.FirstCreditAmount = CInt(Me.txtPARTNER_FIRSTCREDITAMOUNT.EditValue)
            data.PARTNER_FLG = CInt(Me.optFLG.EditValue)
            If data.SaveData() Then
                data.PARTNER_ADDRESS.Address_Name = Me.txtPARTNER_ADDRESS_DOC.EditValue.ToString
                data.PARTNER_ADDRESS.Address_Province = Me.cboPARTNER_ADDR_PROVINCE.EditValue.ToString
                data.PARTNER_ADDRESS.Address_Amphoe = Me.cboPARTNER_ADDRESS_AMPHOE.EditValue.ToString
                data.PARTNER_ADDRESS.Address_District = Me.cboPARTNER_ADDRESS_DISTRICT.EditValue.ToString
                data.PARTNER_ADDRESS.Address_Zipcode = Me.txtPARTNER_ADDRESS_ZIPCODE.EditValue.ToString
                data.PARTNER_ADDRESS.Address_Remark1 = Me.txtPARTNER_REMARK1.EditValue.ToString
                data.PARTNER_ADDRESS.Address_Remark2 = Me.txtPARTNER_REMARK2.EditValue.ToString
                data.PARTNER_ADDRESS.PARTNER_ID = data.PARTNER_ID
                data.PARTNER_ADDRESS.SaveData(" WHERE PARTNER_ID=" & data.PARTNER_ID)
                data.PARTNER_ATTACHMENT.FileName = Me.txtPARTNER_ATTACHMENT_FILENAME.EditValue.ToString
                data.PARTNER_ATTACHMENT.PARTNER_ID = data.PARTNER_ID
                data.PARTNER_ATTACHMENT.SaveData(" WHERE PARTNER_ID=" & data.PARTNER_ID)

                MessageBox.Show("Save Complete")
                SetDataSource()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadData(data As CMPartner)
        Me.txtPARTNER_CODE.EditValue = data.PARTNER_CODE.ToString
        Me.txtPARTNER_TAX.EditValue = data.PARTNER_TAX.ToString
        Me.cboPARTNER_BUSINESS_TYPE_ID.EditValue = Nothing
        Me.cboPARTNER_BUSINESS_TYPE_ID.EditValue = data.PARTNER_BUSINESS_TYPE_ID
        Me.cboPARTNER_BRANCH.SelectedIndex = data.PARTNER_BRANCH
        Me.txtPARTNER_BRANCH.EditValue = data.PARTNER_BRANCH
        Me.cboPARTNER_SOURCE.SelectedIndex = data.PARTNER_SOURCE
        Me.cboPARTNER_COUNTRY_ID.EditValue = data.PARTNER_COUNTRY_ID
        Me.cboPARTNER_PAYMENT_CONDITION.EditValue = data.PARTNER_PAYTYPE_ID
        Me.cboPARTNER_CURRATE_ID.EditValue = data.PARTNER_CURRATE_ID
        Me.txtPARTNER_CREDIT_DAY.EditValue = data.PARTNER_CREDIT_DAYS
        Me.txtPARTNER_DEFAULT_VAT_TYPE.EditValue = data.PARTNER_DEFAULT_VAT_TYPE
        Me.cboPARTNER_PREFIX.EditValue = data.Partner_Prefix_Id
        Me.txtPARTNER_NAME1.EditValue = data.PARTNER_NAME_1.ToString
        Me.txtPARTNER_NAME2.EditValue = data.PARTNER_NAME_2.ToString
        Me.txtPARTNER_NAME3.EditValue = data.PARTNER_NAME_3.ToString
        Me.txtPARTNER_ADDRESS_DOC.Text = data.PARTNER_ADDRESS_DOC
        cboPARTNER_ADDR_PROVINCE.EditValue = Nothing
        Me.cboPARTNER_ADDR_PROVINCE.EditValue = CInt(0 & data.PARTNER_ADDRESS.Address_Province)
        cboPARTNER_ADDRESS_AMPHOE.EditValue = Nothing
        Me.cboPARTNER_ADDRESS_AMPHOE.EditValue = CInt(0 & data.PARTNER_ADDRESS.Address_Amphoe)
        cboPARTNER_ADDRESS_DISTRICT.EditValue = Nothing
        Me.cboPARTNER_ADDRESS_DISTRICT.EditValue = CInt(0 & data.PARTNER_ADDRESS.Address_District)
        Me.txtPARTNER_ADDRESS_ZIPCODE.EditValue = data.PARTNER_ADDRESS.Address_Zipcode.ToString
        Me.txtPARTNER_CONTACT1.EditValue = data.PARTNER_CONTACT_1.ToString
        Me.txtPARTNER_PHONENO.EditValue = data.PhoneNo.ToString
        Me.txtPARTNER_EMAIL.EditValue = data.PARTNER_EMAIL.ToString
        Me.txtPARTNER_WEBSITE.EditValue = data.PARTNER_URL.ToString
        Me.txtPARTNER_FIRSTCREDITAMOUNT.EditValue = data.FirstCreditAmount
        Me.txtPARTNER_REMARK1.EditValue = data.PARTNER_ADDRESS.Address_Remark1.ToString
        Me.txtPARTNER_REMARK2.EditValue = data.PARTNER_ADDRESS.Address_Remark2.ToString
        Me.txtPARTNER_ATTACHMENT_FILENAME.EditValue = data.PARTNER_ATTACHMENT.FileName.ToString
        Me.optFLG.SelectedIndex = data.PARTNER_FLG

    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        DisplayRow(e.RowHandle)
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        DisplayRow(e.FocusedRowHandle)
    End Sub
    Private Sub DisplayRow(pIndex As Integer)
        If pIndex >= 0 Then
            txtPARTNER_ID.EditValue = Nothing
            txtPARTNER_ID.EditValue = GridView1.GetRowCellDisplayText(pIndex, "PARTNER_ID")
        End If
    End Sub

    Private Sub txtPARTNER_ID_EditValueChanged(sender As Object, e As EventArgs) Handles txtPARTNER_ID.EditValueChanged
        If Not txtPARTNER_ID.EditValue Is Nothing Then
            If CLng(txtPARTNER_ID.EditValue) > 0 Then
                LoadData(New CMPartner(conn).GetData(" WHERE PARTNER_ID=" & txtPARTNER_ID.EditValue.ToString()).FirstOrDefault)
            End If
        End If
    End Sub

    Private Sub chkIncludeCancel_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncludeCancel.CheckedChanged
        SetDataSource()
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Savedata()
    End Sub

    Private Sub cboPARTNER_ADDR_PROVINCE_EditValueChanged(sender As Object, e As EventArgs) Handles cboPARTNER_ADDR_PROVINCE.EditValueChanged
        If cboPARTNER_ADDR_PROVINCE.EditValue Is Nothing Then Exit Sub
        Dim ds = From a In New CMAddressDistricts(conn).GetData(" WHERE ProvinceId=" & cboPARTNER_ADDR_PROVINCE.EditValue.ToString())
                 Select a.Id, a.DistrictsThai, a.DistrictsEnglish

        cboPARTNER_ADDRESS_AMPHOE.Properties.DataSource = ds
        cboPARTNER_ADDRESS_AMPHOE.Properties.DisplayMember = "DistrictsThai"
        cboPARTNER_ADDRESS_AMPHOE.Properties.ValueMember = "Id"
        cboPARTNER_ADDRESS_AMPHOE.EditValue = Nothing
        cboPARTNER_ADDRESS_DISTRICT.EditValue = Nothing

    End Sub

    Private Sub cboPARTNER_BUSINESS_TYPE_ID_EditValueChanged(sender As Object, e As EventArgs) Handles cboPARTNER_BUSINESS_TYPE_ID.EditValueChanged
        If cboPARTNER_BUSINESS_TYPE_ID.EditValue Is Nothing Then Exit Sub
        Dim ds = From a In New CMPartnerPrefix(conn).GetData(" WHERE PARTNER_BUSINESS_ID=" & cboPARTNER_BUSINESS_TYPE_ID.EditValue.ToString())
                 Select a.Partner_Prefix_Id, a.Partner_Prefix__Name
        cboPARTNER_PREFIX.Properties.DataSource = ds
        cboPARTNER_PREFIX.Properties.DisplayMember = "Partner_Prefix__Name"
        cboPARTNER_PREFIX.Properties.ValueMember = "Partner_Prefix_Id"
        cboPARTNER_PREFIX.EditValue = Nothing
    End Sub

    Private Sub cboPARTNER_ADDRESS_AMPHOE_EditValueChanged(sender As Object, e As EventArgs) Handles cboPARTNER_ADDRESS_AMPHOE.EditValueChanged
        If cboPARTNER_ADDRESS_AMPHOE.EditValue Is Nothing Then Exit Sub
        Dim ds = From a In New CMAddressSubDistricts(conn).GetData(" WHERE DistrictId=" & cboPARTNER_ADDRESS_AMPHOE.EditValue.ToString())
                 Select a.Id, a.SubdistrictsThai, a.SubdistrictsEnglish

        cboPARTNER_ADDRESS_DISTRICT.Properties.DataSource = ds
        cboPARTNER_ADDRESS_DISTRICT.Properties.DisplayMember = "SubdistrictsThai"
        cboPARTNER_ADDRESS_DISTRICT.Properties.ValueMember = "Id"
        cboPARTNER_ADDRESS_DISTRICT.EditValue = Nothing
    End Sub

    Private Sub cboPARTNER_ADDRESS_DISTRICT_EditValueChanged(sender As Object, e As EventArgs) Handles cboPARTNER_ADDRESS_DISTRICT.EditValueChanged

    End Sub
End Class