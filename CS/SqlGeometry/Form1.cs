using DevExpress.XtraMap;
using System.IO;
using System.Windows.Forms;

namespace SqlGeometry {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        #region #SqlGeometryDataAdapter
        const string filePath = "..\\..\\Data\\SQLG.mdf";
        
        private void Form1_Load(object sender, System.EventArgs e) {
            string fullFilePath = Path.GetFullPath(Path.Combine(Application.StartupPath, filePath));
            SqlGeometryDataAdapter adapter = new SqlGeometryDataAdapter() {
                ConnectionString = "Data Source=(local);AttachDbFileName=" + fullFilePath + 
                    ";Database=SqlGeometryDB;Integrated Security=True;MultipleActiveResultSets=True",
                SqlText = "SELECT TOP 1000 [GeomCol1],[TextCol] FROM [dbo].[DemoTable]",
                SpatialDataMember = "GeomCol1"
            };
            VectorItemsLayer layer = new VectorItemsLayer() {
                Data = adapter,
                ShapeTitlesPattern = "{TextCol}"
            };
            layer.DataLoaded += layer_DataLoaded;
            mapControl1.Layers.Add(layer);
        }
        #endregion #SqlGeometryDataAdapter

        void layer_DataLoaded(object sender, DataLoadedEventArgs e) {
            mapControl1.ZoomToFitLayerItems();
        }
    }
}
