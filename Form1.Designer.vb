<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FVender
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BarDockingMenuItem1 = New DevExpress.XtraBars.BarDockingMenuItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFTVenderCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFTVenderName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFBActive = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtVenderName = New DevExpress.XtraEditors.TextEdit()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSearchCode = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtVenderCode = New DevExpress.XtraEditors.TextEdit()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.chkActive = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVenderName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSearchCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVenderCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarDockingMenuItem1
        '
        Me.BarDockingMenuItem1.Caption = "BarDockingMenuItem1"
        Me.BarDockingMenuItem1.Id = 0
        Me.BarDockingMenuItem1.Name = "BarDockingMenuItem1"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "BarSubItem1"
        Me.BarSubItem1.Id = 1
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.DataMember = "Query"
        Me.GridControl1.Location = New System.Drawing.Point(12, 103)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(509, 177)
        Me.GridControl1.TabIndex = 6
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colId, Me.colFTVenderCode, Me.colFTVenderName, Me.colFBActive})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'colId
        '
        Me.colId.FieldName = "Id"
        Me.colId.Name = "colId"
        Me.colId.Visible = True
        Me.colId.VisibleIndex = 0
        '
        'colFTVenderCode
        '
        Me.colFTVenderCode.FieldName = "FTVenderCode"
        Me.colFTVenderCode.Name = "colFTVenderCode"
        Me.colFTVenderCode.Visible = True
        Me.colFTVenderCode.VisibleIndex = 1
        '
        'colFTVenderName
        '
        Me.colFTVenderName.FieldName = "FTVenderName"
        Me.colFTVenderName.Name = "colFTVenderName"
        Me.colFTVenderName.Visible = True
        Me.colFTVenderName.VisibleIndex = 2
        '
        'colFBActive
        '
        Me.colFBActive.FieldName = "FBActive"
        Me.colFBActive.Name = "colFBActive"
        Me.colFBActive.Visible = True
        Me.colFBActive.VisibleIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Vender Code"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(13, 39)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Vender Name"
        '
        'txtVenderName
        '
        Me.txtVenderName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVenderName.Location = New System.Drawing.Point(92, 39)
        Me.txtVenderName.Name = "txtVenderName"
        Me.txtVenderName.Size = New System.Drawing.Size(429, 20)
        Me.txtVenderName.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(446, 74)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "&Save"
        '
        'txtSearchCode
        '
        Me.txtSearchCode.Location = New System.Drawing.Point(92, 13)
        Me.txtSearchCode.Name = "txtSearchCode"
        Me.txtSearchCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtSearchCode.Properties.DisplayMember = "FTVenderCode"
        Me.txtSearchCode.Properties.NullText = ""
        Me.txtSearchCode.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.txtSearchCode.Properties.ValueMember = "Id"
        Me.txtSearchCode.Size = New System.Drawing.Size(100, 20)
        Me.txtSearchCode.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowAutoFilterRow = True
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'txtVenderCode
        '
        Me.txtVenderCode.Location = New System.Drawing.Point(92, 13)
        Me.txtVenderCode.Name = "txtVenderCode"
        Me.txtVenderCode.Size = New System.Drawing.Size(82, 20)
        Me.txtVenderCode.TabIndex = 1
        Me.txtVenderCode.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 74)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "&Add"
        '
        'chkActive
        '
        Me.chkActive.EditValue = True
        Me.chkActive.Location = New System.Drawing.Point(198, 13)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Properties.Caption = "Active"
        Me.chkActive.Size = New System.Drawing.Size(75, 19)
        Me.chkActive.TabIndex = 3
        '
        'FVender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 292)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtVenderCode)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtVenderName)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.txtSearchCode)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FVender"
        Me.Text = "Vender Maintenance"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVenderName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSearchCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVenderCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarDockingMenuItem1 As DevExpress.XtraBars.BarDockingMenuItem
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtVenderName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFTVenderCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFTVenderName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFBActive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtSearchCode As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtVenderCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkActive As DevExpress.XtraEditors.CheckEdit
End Class
