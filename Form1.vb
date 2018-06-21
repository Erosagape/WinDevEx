Public Class FVender
    Sub New()
        InitializeComponent()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'initialize form
        SetDataSource()
    End Sub
    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        'when use click value in grid
        DisplayRow(e.RowHandle)
    End Sub
    Private Sub txtSearchCode_EditValueChanged(sender As Object, e As EventArgs) Handles txtSearchCode.EditValueChanged
        'when user selected value from drop down then load selected data
        If Not txtSearchCode.EditValue Is Nothing Then
            LoadData()
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'change to add mode
        SwitchMode(True)
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'when save button click then call save data and refresh data source
        If SaveData() Then
            'if on add mode then return to edit mode
            If txtSearchCode.Visible = False Then
                txtVenderCode.Tag = txtVenderCode.EditValue
                SetDataSource()
                txtVenderCode.EditValue = txtVenderCode.Tag
                SearchData()
            Else
                txtSearchCode.Tag = txtSearchCode.EditValue
                SetDataSource()
                txtSearchCode.EditValue =txtSearchCode.Tag 
                LoadData()
            End If
        End If
    End Sub
    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        'when user use mouse to change row focus in grid
        DisplayRow(e.FocusedRowHandle)
    End Sub

    Private Sub txtVenderCode_Validated(sender As Object, e As EventArgs) Handles txtVenderCode.Validated
        'when user enter code then check existing
        SearchData()
    End Sub
    Private Sub SwitchMode(bAddNew As Boolean, Optional bChangeFocus As Boolean = True)
        'for change edit mode to add new mode
        If txtSearchCode.Visible = bAddNew Then
            txtVenderCode.Visible = bAddNew
            txtSearchCode.Visible = Not bAddNew
        End If
        If bAddNew Then
            txtVenderCode.EditValue = ""
            txtVenderName.EditValue = ""
            chkActive.Checked = True
            If bChangeFocus Then txtVenderCode.Focus()
        Else
            If bChangeFocus Then txtVenderName.Focus()
        End If
    End Sub
    Private Sub SetDataSource()
        'set datasource for controls
        txtSearchCode.Properties.DataSource = New CVender().GetTable()
        GridControl1.DataSource = txtSearchCode.Properties.DataSource
    End Sub
    Private Function SaveData() As Boolean
        'check validation
        If txtVenderCode.EditValue.ToString() = "" Then
            MessageBox.Show("Vender Code Must Be Enter")
            txtVenderCode.Focus()
            Return False
        End If
        'check validation
        If txtVenderName.EditValue.ToString() = "" Then
            MessageBox.Show("Vender Name Must Be Enter")
            txtVenderName.Focus()
            Return False
        End If
        'read data in form
        Dim data As New CVender
        data.FTVenderCode = txtVenderCode.Text
        data.FTVenderName = txtVenderName.Text
        data.FBActive = CInt(IIf(chkActive.Checked = True, 0, 9))
        'save to database
        Dim tResult As String = data.Update
        'display result
        MessageBox.Show(tResult)
        'check result
        Return CBool(IIf(tResult.Substring(0, 1) = "1", True, False))
    End Function
    Private Sub SearchData()
        'if user input data in add mode query existing first 
        If txtVenderCode.EditValue.ToString().TrimEnd() <> "" Then
            Dim vendid = New CVender().FindID(txtVenderCode.EditValue.ToString().TrimEnd())
            If vendid > 0 Then
                txtSearchCode.EditValue = ""
                txtSearchCode.EditValue = vendid
                If txtSearchCode.Visible = False Then
                    SwitchMode(False)
                End If
            End If
        End If
    End Sub
    Private Sub LoadData()
        'get data from current selected id
        Dim dr As DataRowView = TryCast(txtSearchCode.GetSelectedDataRow(), DataRowView)
        If Not dr Is Nothing Then
            txtVenderCode.EditValue = dr(1).ToString()
            txtVenderName.EditValue = dr(2).ToString()
            chkActive.Checked = CBool(dr(3).ToString() = "0")
        End If
    End Sub
    Private Sub DisplayRow(pIndex As Integer)
        If pIndex >= 0 Then
            'reset value and search id from grid
            If txtSearchCode.Visible = False Then
                SwitchMode(False, False)
            End If
            txtSearchCode.EditValue = ""
            txtSearchCode.EditValue = GridView1.GetRowCellDisplayText(pIndex, "Id")
        End If
    End Sub

    Private Sub FVender_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
