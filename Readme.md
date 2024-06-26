<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128576592/14.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T175898)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/SqlGeometry/Form1.cs) (VB: [Form1.vb](./VB/SqlGeometry/Form1.vb))**
<!-- default file list end -->
# How to load data from a SQL Geometry data source


This example demonstrates how to load data to a vector layer from a SQL Geometry data source.


<h3>Description</h3>

To load data from the SQL Geometry data source, do the following.<br />1. Create a <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapSqlGeometryDataAdaptertopic">SqlGeometryDataAdapter</a>&nbsp;object.<br />2. Specify its <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapSqlGeometryDataAdapter_ConnectionStringtopic">ConnectionString</a>, <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapSqlGeometryDataAdapter_SqlTexttopic">SqlText</a>&nbsp;and <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapSqlGeometryDataAdapter_SpatialDataMembertopic">SpatialDataMember</a>&nbsp;properties.<br />3. Assign this object to the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapVectorItemsLayer_Datatopic">VectorItemsLayer.Data</a>&nbsp;property.<br /><br />Note that all data table fields loaded from the database will be provided as attributes for each <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapSqlGeometryItemtopic">SqlGeometryItem</a>&nbsp;object generated using <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapSqlGeometryDataAdaptertopic">SqlGeometryDataAdapter</a>.

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-load-data-from-a-sql-geometry-data-source-t175898&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-load-data-from-a-sql-geometry-data-source-t175898&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
