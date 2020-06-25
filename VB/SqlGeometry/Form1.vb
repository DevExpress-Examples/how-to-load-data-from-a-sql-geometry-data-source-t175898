Imports DevExpress.XtraMap
Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms

Namespace SqlGeometry
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Const filePath As String = "..\..\Data\SQLG.mdf"
		Private Shared fullFilePath As String = Path.GetFullPath(Path.Combine(Application.StartupPath, filePath))
		Private connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=" & fullFilePath & ";Database=SqlGeometryDB;Integrated Security=True;MultipleActiveResultSets=True"
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
			Dim adapter As New SqlGeometryDataAdapter() With {
				.ConnectionString = connectionString,
				.SqlText = "SELECT TOP 1000 [id], [GeomCol1],[TextCol] FROM [dbo].[DemoTable]",
				.SpatialDataMember = "GeomCol1"
			}
			Dim layer As New VectorItemsLayer() With {
				.Data = adapter,
				.ShapeTitlesPattern = "{TextCol}"
			}
			AddHandler layer.DataLoaded, AddressOf layer_DataLoaded
			mapControl1.Layers.Add(layer)
			mapControl1.MapEditor.ShowEditorPanel = True
			AddHandler mapControl1.MapEditor.MapItemEdited, AddressOf MapEditor_MapItemEdited
		End Sub

		Private Sub layer_DataLoaded(ByVal sender As Object, ByVal e As DataLoadedEventArgs)
			mapControl1.ZoomToFitLayerItems()
		End Sub

		Private Sub MapEditor_MapItemEdited(ByVal sender As Object, ByVal e As MapItemEditedEventArgs)
			For Each path As MapPath In e.Items
				Dim id As Integer = Convert.ToInt32(path.Attributes("id").Value)
				Dim modified As String = path.ExportToWkt().ToString()
				path.Attributes("TextCol").Value = "Australia" & " " & DateTime.Now.Second.ToString()

				Using cn As New SqlConnection() With {.ConnectionString = connectionString}
					cn.Open()
					' For more information about SRID parameters, see https://docs.microsoft.com/en-us/sql/t-sql/spatial-geography/stsrid-geography-data-type?view=sql-server-ver15
					Dim updatecmd As New SqlCommand("UPDATE DemoTable SET GeomCol1 = geometry::STGeomFromText('" & modified & "', 4326 ) WHERE id = " & id.ToString(), cn)
					updatecmd.ExecuteNonQuery()

					Dim updateattr As New SqlCommand("UPDATE DemoTable SET TextCol = '" & path.Attributes("TextCol").Value.ToString() & "' WHERE id =" & id.ToString(), cn)
					updateattr.ExecuteNonQuery()
				End Using
			Next path
		End Sub

	End Class
End Namespace