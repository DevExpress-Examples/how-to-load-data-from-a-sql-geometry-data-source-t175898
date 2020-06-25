using DevExpress.XtraMap;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SqlGeometry {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        const string filePath = "..\\..\\Data\\SQLG.mdf";
        static string fullFilePath = Path.GetFullPath(Path.Combine(Application.StartupPath, filePath));
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=" + fullFilePath + ";Database=SqlGeometryDB;Integrated Security=True;MultipleActiveResultSets=True";
        private void Form1_Load(object sender, System.EventArgs e) {
            SqlGeometryDataAdapter adapter = new SqlGeometryDataAdapter() {
                ConnectionString = connectionString,
                SqlText = "SELECT TOP 1000 [id], [GeomCol1],[TextCol] FROM [dbo].[DemoTable]",
                SpatialDataMember = "GeomCol1"
            };
            VectorItemsLayer layer = new VectorItemsLayer() {
                Data = adapter,
                ShapeTitlesPattern = "{TextCol}"
            };
            layer.DataLoaded += layer_DataLoaded;
            mapControl1.Layers.Add(layer);
            mapControl1.MapEditor.ShowEditorPanel = true;
            mapControl1.MapEditor.MapItemEdited += MapEditor_MapItemEdited;
        }

        void layer_DataLoaded(object sender, DataLoadedEventArgs e) {
            mapControl1.ZoomToFitLayerItems();
        }

        private void MapEditor_MapItemEdited(object sender, MapItemEditedEventArgs e) {
            foreach (MapPath path in e.Items) {
                int id = Convert.ToInt32(path.Attributes["id"].Value);
                string modified = path.ExportToWkt().ToString();
                path.Attributes["TextCol"].Value = "Australia" + " " + DateTime.Now.Second.ToString();

                using (SqlConnection cn = new SqlConnection() { ConnectionString = connectionString }) {
                    cn.Open();
                    // For more information about SRID parameters, see https://docs.microsoft.com/en-us/sql/t-sql/spatial-geography/stsrid-geography-data-type?view=sql-server-ver15
                    SqlCommand updatecmd = new SqlCommand("UPDATE DemoTable SET GeomCol1 = geometry::STGeomFromText('" + modified + "', 4326 ) WHERE id = " + id.ToString(), cn);
                    updatecmd.ExecuteNonQuery();

                    SqlCommand updateattr = new SqlCommand("UPDATE DemoTable SET TextCol = '" + path.Attributes["TextCol"].Value.ToString() + "' WHERE id =" + id.ToString(), cn);
                    updateattr.ExecuteNonQuery();
                }
            }
        }

    }
}