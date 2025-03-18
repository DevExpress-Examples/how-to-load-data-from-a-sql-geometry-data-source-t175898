Imports DevExpress.XtraMap
Imports System.IO
Imports System.Windows.Forms

Namespace SqlGeometry

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

#Region "#SqlGeometryDataAdapter"
        Const filePath As String = "..\..\Data\SQLG.mdf"

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim fullFilePath As String = Path.GetFullPath(Path.Combine(Application.StartupPath, filePath))
            Dim adapter As SqlGeometryDataAdapter = New SqlGeometryDataAdapter() With {.ConnectionString = "Data Source=(local);AttachDbFileName=" & fullFilePath & ";Database=SqlGeometryDB;Integrated Security=True;MultipleActiveResultSets=True", .SqlText = "SELECT TOP 1000 [GeomCol1],[TextCol] FROM [dbo].[DemoTable]", .SpatialDataMember = "GeomCol1"}
            Dim layer As VectorItemsLayer = New VectorItemsLayer() With {.Data = adapter, .ShapeTitlesPattern = "{TextCol}"}
            AddHandler layer.DataLoaded, AddressOf layer_DataLoaded
            mapControl1.Layers.Add(layer)
        End Sub

#End Region  ' #SqlGeometryDataAdapter
        Private Sub layer_DataLoaded(ByVal sender As Object, ByVal e As DataLoadedEventArgs)
            mapControl1.ZoomToFitLayerItems()
        End Sub
    End Class
End Namespace
