Imports DevExpress.XtraMap
Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms

Namespace SqlGeometry

    Public Partial Class Form1
        Inherits System.Windows.Forms.Form

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Const filePath As String = "..\..\Data\SQLG.mdf"

        Private Shared fullFilePath As String = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, SqlGeometry.Form1.filePath))

        Private connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=" & SqlGeometry.Form1.fullFilePath & ";Database=SqlGeometryDB;Integrated Security=True;MultipleActiveResultSets=True"

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim adapter As DevExpress.XtraMap.SqlGeometryDataAdapter = New DevExpress.XtraMap.SqlGeometryDataAdapter() With {.ConnectionString = Me.connectionString, .SqlText = "SELECT TOP 1000 [id], [GeomCol1],[TextCol] FROM [dbo].[DemoTable]", .SpatialDataMember = "GeomCol1"}
            Dim layer As DevExpress.XtraMap.VectorItemsLayer = New DevExpress.XtraMap.VectorItemsLayer() With {.Data = adapter, .ShapeTitlesPattern = "{TextCol}"}
            AddHandler layer.DataLoaded, AddressOf Me.layer_DataLoaded
            Me.mapControl1.Layers.Add(layer)
            Me.mapControl1.MapEditor.ShowEditorPanel = True
            AddHandler Me.mapControl1.MapEditor.MapItemEdited, AddressOf Me.MapEditor_MapItemEdited
        End Sub

        Private Sub layer_DataLoaded(ByVal sender As Object, ByVal e As DevExpress.XtraMap.DataLoadedEventArgs)
            Me.mapControl1.ZoomToFitLayerItems()
        End Sub

        Private Sub MapEditor_MapItemEdited(ByVal sender As Object, ByVal e As DevExpress.XtraMap.MapItemEditedEventArgs)
            For Each path As DevExpress.XtraMap.MapPath In e.Items
                Dim id As Integer = System.Convert.ToInt32(path.Attributes(CStr(("id"))).Value)
                Dim modified As String = path.ExportToWkt().ToString()
                path.Attributes(CStr(("TextCol"))).Value = "Australia" & " " & System.DateTime.Now.Second.ToString()
                Using cn As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection() With {.ConnectionString = Me.connectionString}
                    cn.Open()
                    ' For more information about SRID parameters, see https://docs.microsoft.com/en-us/sql/t-sql/spatial-geography/stsrid-geography-data-type?view=sql-server-ver15
                    Dim updatecmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand("UPDATE DemoTable SET GeomCol1 = geometry::STGeomFromText('" & modified & "', 4326 ) WHERE id = " & id.ToString(), cn)
                    updatecmd.ExecuteNonQuery()
                    Dim updateattr As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand("UPDATE DemoTable SET TextCol = '" & path.Attributes(CStr(("TextCol"))).Value.ToString() & "' WHERE id =" & id.ToString(), cn)
                    updateattr.ExecuteNonQuery()
                End Using
            Next
        End Sub
    End Class
End Namespace
