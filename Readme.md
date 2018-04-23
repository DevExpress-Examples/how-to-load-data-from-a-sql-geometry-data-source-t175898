# How to load data from a SQL Geometry data source


This example demonstrates how to load data to a vector layer from a SQL Geometry data source.


<h3>Description</h3>

To load data from the SQL Geometry data source, do the following.<br />1. Create a <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapSqlGeometryDataAdaptertopic">SqlGeometryDataAdapter</a>&nbsp;object.<br />2. Specify its <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapSqlGeometryDataAdapter_ConnectionStringtopic">ConnectionString</a>, <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapSqlGeometryDataAdapter_SqlTexttopic">SqlText</a>&nbsp;and <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapSqlGeometryDataAdapter_SpatialDataMembertopic">SpatialDataMember</a>&nbsp;properties.<br />3. Assign this object to the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapVectorItemsLayer_Datatopic">VectorItemsLayer.Data</a>&nbsp;property.<br /><br />Note that all data table fields loaded from the database will be provided as attributes for each <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapSqlGeometryItemtopic">SqlGeometryItem</a>&nbsp;object generated using <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapSqlGeometryDataAdaptertopic">SqlGeometryDataAdapter</a>.

<br/>


