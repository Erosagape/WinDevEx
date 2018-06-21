Public Class CVender
    'TABLE =TMVender
    'default field values
    Public id As Integer
    Public FTVenderCode As String
    Public FTVenderName As String
    Public FBActive As Integer
    Public Function FindID(pCode As String) As Integer
        'Function for search primarykey from code
        Using dt As DataTable = GetTable(" WHERE FTVenderCode='" & pCode.TrimEnd().ToUpper() & "'")
            If dt.Rows.Count > 0 Then
                Return CInt(dt.Rows(0)("Id").ToString())
            Else
                Return 0
            End If
        End Using
    End Function
    Public Function Update() As String
        'function for save to database        
        Dim sql As String
        'check existing first
        Dim rowID = FindID(FTVenderCode.TrimEnd)
        'if found then do update else do insert
        If rowID > 0 Then
            sql = "UPDATE TMVender"
            sql &= " SET FTVenderName='" & Me.FTVenderName.TrimEnd.ToUpper().Replace("'", "''") & "',"
            sql &= " FBActive=" & Me.FBActive & " "
            sql &= " WHERE Id=" & rowID & " "
        Else
            sql = "INSERT INTO TMVender(id,FTVenderCode,FTVenderName,FBActive) "
            sql &= " VALUES ((SELECT ISNULL(MAX(Id),0)+1 FROM TMVender),"
            sql &= "'" & Me.FTVenderCode.TrimEnd.ToUpper().Replace("'", "''") & "',"
            sql &= "'" & Me.FTVenderName.TrimEnd.ToUpper().Replace("'", "''") & "',"
            sql &= "" & Me.FBActive & ""
            sql &= " )"
        End If
        'run sql command
        Using app As New CFunction
            app.RunSQLData_Master(sql)
            'check error log
            If app.LogResult <> "" Then
                Return app.LogResult
            Else
                Return CStr(IIf(FindID(FTVenderCode) > 0, "1", "0")) & " Row Updated!"
            End If
        End Using
    End Function
    Public Function GetTable(Optional pSQLW As String = "") As DataTable
        'function for query data
        Using app As New CFunction
            Return app.GetSQLData_Master("SELECT * FROM TMVender " & pSQLW)
        End Using
    End Function
    Public Function GetData_All() As List(Of CVender)
        'function for return all data to array of class
        Dim rows As New List(Of CVender)
        Using data As DataTable = GetTable()
            For Each dr As DataRow In data.Rows
                Dim row As New CVender
                row.id = Convert.ToInt32(dr("id").ToString())
                row.FTVenderCode = dr("FTVenderCode").ToString().TrimEnd()
                row.FTVenderName = dr("FTVenderName").ToString().TrimEnd()
                row.FBActive = Convert.ToInt32(dr("FBActive".ToString()))
                rows.Add(row)
            Next
        End Using
        Return rows
    End Function
End Class