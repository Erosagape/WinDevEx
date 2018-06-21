Imports System.Configuration

Public Class FMPartner
    Friend conn As String = ConfigurationManager.ConnectionStrings("JSB_ERPDBConnectionString").ConnectionString
    Private Sub FMPartner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'JSB_ERPDBDataSet.Tbl_Partner' table. You can move, or remove it, as needed.
        SetDataSource()
    End Sub
    Private Sub SetDataSource()
        'set datasource for controls
        GridControl1.DataSource = New CMPartner(conn).GetData("")
    End Sub
End Class