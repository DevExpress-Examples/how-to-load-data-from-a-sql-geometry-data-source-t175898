Imports DevExpress.XtraMap
Imports System.IO
Imports System.Windows.Forms

Namespace SqlGeometry
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        #Region "#SqlGeometryDataAdapter"
        Private Const filePath As String = "..\..\Data\SQLG.mdf"

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim fullFilePath As String = Path.GetFullPath(Path.Combine(Application.StartupPath, filePath))
            Dim adapter As New SqlGeometryDataAdapter() With {.ConnectionString = "Data Source=(local);AttachDbFileName=" & fullFilePath & ";Database=SqlGeometryDB;Integrated Security=True;MultipleActiveResultSets=True", .SqlText = "SELECT TOP 1000 [GeomCol1],[TextCol] FROM [dbo].[DemoTable]", .SpatialDataMember = "GeomCol1"}
            Dim layer As New VectorItemsLayer() With {.Data = adapter, .ShapeTitlesPattern = "{TextCol}"}
            AddHandler layer.DataLoaded, AddressOf layer_DataLoaded
            mapControl1.Layers.Add(layer)
        End Sub
        #End Region ' #SqlGeometryDataAdapter

        Private Sub layer_DataLoaded(ByVal sender As Object, ByVal e As DataLoadedEventArgs)
            mapControl1.ZoomToFitLayerItems()
        End Sub
    End Class
End Namespace
