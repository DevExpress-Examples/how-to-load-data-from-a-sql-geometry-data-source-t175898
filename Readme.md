<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128576592/19.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T175898)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/SqlGeometry/Form1.cs) (VB: [Form1.vb](./VB/SqlGeometry/Form1.vb))**
<!-- default file list end -->

# How to load data from a SQL geometry data source

This example loads data to a vector layer from an SQL geometry data source. Once you edit vector layer items, changes are saved to the data source.



## Description

To load data from the SQL geometry data source, do the following:

1. Create an [SqlGeometryDataAdapter](https://docs.devexpress.com/WindowsForms/DevExpress.XtraMap.SqlGeometryDataAdapter) object.

2. Specify its [ConnectionString](https://docs.devexpress.com/WindowsForms/DevExpress.XtraMap.SqlGeometryDataAdapter.ConnectionString), [SqlText](https://docs.devexpress.com/WindowsForms/DevExpress.XtraMap.SqlGeometryDataAdapter.SqlText) and [SpatialDataMember](https://docs.devexpress.com/WindowsForms/DevExpress.XtraMap.SqlGeometryDataAdapter.SpatialDataMember) properties.

3. Assign this object to the [VectorItemsLayer.Data](https://docs.devexpress.com/WindowsForms/DevExpress.XtraMap.VectorItemsLayer.Data) property. Note that all data table fields loaded from the database are stored as attributes for each generated [SqlGeometryItem](https://docs.devexpress.com/WindowsForms/DevExpress.XtraMap.SqlGeometryItem?p=netframework) object.

In this example, you can use the [Map Editor](https://docs.devexpress.com/WindowsForms/120215/controls-and-libraries/map-control/end-user-features/map-editor?p=netframework) to edit shapes. To save changes, call corresponding SQL commands in the [MapEditor.MapItemEdited](https://docs.devexpress.com/WindowsForms/DevExpress.XtraMap.MapEditor.MapItemEdited?p=netframework) event handler.
