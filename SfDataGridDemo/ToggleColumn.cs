using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo
{
    public class GridToggleButtonColumn : GridColumn
    {
        public GridToggleButtonColumn()
        {
            SetCellType("ToggleButton");
        }
    }
}
