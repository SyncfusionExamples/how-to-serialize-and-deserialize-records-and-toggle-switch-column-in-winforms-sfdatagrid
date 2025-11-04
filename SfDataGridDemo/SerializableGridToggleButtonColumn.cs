using Syncfusion.WinForms.DataGrid.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo
{
    [DataContract(Name = "GridToggleButtonColumn")]
    public class SerializableGridToggleButtonColumn : SerializableGridColumn
    {
        public SerializableGridToggleButtonColumn()
        {

        }
    }
}
