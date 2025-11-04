using SfDataGridDemo;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SfDataGridDemo
{
    public partial class Form1 : Form
    {
        OrderInfoCollection _orderInfos;

        public Form1()
        {
            InitializeComponent();
            _orderInfos = new OrderInfoCollection();
            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.DataSource = _orderInfos.Orders;

            sfDataGrid1.CellRenderers.Add("ToggleButton", new GridToggleButtonCellRenderer(sfDataGrid1));
            sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "OrderID", HeaderText = "Order ID" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerName", HeaderText = "Customer Name", Width = 150 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Country", HeaderText = "Country" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ShipCity", HeaderText = "Ship City" });
            sfDataGrid1.Columns.Add(new GridToggleButtonColumn() { MappingName = "IsActive", HeaderText = "Is Active" });

            this.Load += OnFormLoading;
            this.FormClosing += OnFormClosing;

            sfDataGrid1.SerializationController = new SerializationControllerExt(this.sfDataGrid1);
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();

            using (var file = File.Create("DataGrid.xml"))
            {
                sfDataGrid1.Serialize(file);
            }
        }

        private void OnFormLoading(object sender, EventArgs e)
        {
            if (File.Exists("OrdersData.xml"))
            {
                _orderInfos.Orders = LoadData();
                sfDataGrid1.DataSource = _orderInfos.Orders;
            }

            if (File.Exists("DataGrid.xml"))
            {
                using (var file = File.Open("DataGrid.xml", FileMode.Open))
                {
                    sfDataGrid1.Deserialize(file);
                }
            }
        }

        private void SaveData()
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<OrderInfo>));
            using (var stream = File.Create("OrdersData.xml"))
            {
                serializer.Serialize(stream, _orderInfos.Orders);
            }
        }

        private List<OrderInfo> LoadData()
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<OrderInfo>));
            using (var stream = File.OpenRead("OrdersData.xml"))
            {
                return (List<OrderInfo>)serializer.Deserialize(stream);
            }
        }
    }

    public class SerializationControllerExt : SerializationController
    {
        public SerializationControllerExt(SfDataGrid grid) : base(grid) { }

        SerializableGridColumn serializableColumn = new SerializableGridColumn();

        // To serialize the GridToggleColumn
        protected override SerializableGridColumn GetSerializableGridColumn(GridColumn column)
        {
            if (column is GridToggleButtonColumn)
            {
                ;
                serializableColumn = new SerializableGridToggleButtonColumn();
                return serializableColumn;
            }

            return base.GetSerializableGridColumn(column);
        }

        // To Deserialize the GridToggleColumn
        protected override GridColumn GetGridColumn(SerializableGridColumn serializableColumn)
        {
            if (serializableColumn is SerializableGridToggleButtonColumn)
            {
                var toggleButtonColumn = new GridToggleButtonColumn();
                return toggleButtonColumn;
            }
            return base.GetGridColumn(serializableColumn);
        }

        // To add the SerializableGridToggleButtonColumn as a KnownTypes to serialize and deserialize
        public override Type[] KnownTypes()
        {
            return base.KnownTypes().Concat(new Type[] { typeof(SerializableGridToggleButtonColumn) }).ToArray();
        }
    }
}
