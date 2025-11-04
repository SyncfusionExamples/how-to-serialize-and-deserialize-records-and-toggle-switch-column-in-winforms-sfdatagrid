using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.DataGrid.Styles;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Interactivity;

namespace SfDataGridDemo
{
    public class GridToggleButtonCellRenderer : GridCellRendererBase
    {
        private Rectangle toggleBounds;
        private SfDataGrid dataGrid;
        private bool isToggled;

        public GridToggleButtonCellRenderer()
        {

        }

        public GridToggleButtonCellRenderer(SfDataGrid dataGrid)
        {
            this.dataGrid = dataGrid;
        }

        protected override void OnRender(Graphics graphics, Rectangle cellRect, string cellValue, CellStyleInfo cellStyle, DataColumnBase column, RowColumnIndex rowColumnIndex)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            object value = cellValue;
            isToggled = value != null && Convert.ToBoolean(value);

            int toggleWidth = 65;
            int toggleHeight = 25;
            int circleSize = 20;
            int padding = 4;
            int x = cellRect.X + (cellRect.Width - toggleWidth) / 2;
            int y = cellRect.Y + (cellRect.Height - toggleHeight) / 2;

            toggleBounds = new Rectangle(x, y, toggleWidth, toggleHeight);

            Rectangle circleBounds = new Rectangle(
                isToggled ? (x + toggleWidth - circleSize - padding - 3) : (x + padding),
                y + padding,
                circleSize,
                circleSize
            );


            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(toggleBounds.X, toggleBounds.Y, toggleHeight, toggleHeight, 90, 180);
                path.AddArc(toggleBounds.Right - toggleHeight, toggleBounds.Y, toggleHeight, toggleHeight, -90, 180);
                path.CloseFigure();

                using (SolidBrush brush = new SolidBrush(isToggled ? Color.RoyalBlue : Color.White))
                {
                    graphics.FillPath(brush, path);
                    // Draw outer border around the toggle switch
                    using (GraphicsPath borderPath = new GraphicsPath())
                    {
                        borderPath.AddArc(toggleBounds.X, toggleBounds.Y, toggleHeight, toggleHeight, 90, 180);
                        borderPath.AddArc(toggleBounds.Right - toggleHeight, toggleBounds.Y, toggleHeight, toggleHeight, -90, 180);
                        borderPath.CloseFigure();

                        using (Pen borderPen = new Pen(Color.Gray, 2))
                        {
                            if (!isToggled)
                                graphics.DrawPath(borderPen, borderPath);
                        }
                    }
                }
            }

            SolidBrush textBrush;

            using (Font font = new Font("Arial", 9, FontStyle.Bold))
            {
                string text = isToggled ? "ON" : "OFF";
                textBrush = isToggled ? new SolidBrush(Color.White) : new SolidBrush(Color.Gray);
                SizeF textSize = graphics.MeasureString(text, font);
                PointF textPosition = new PointF(
                    isToggled ? (toggleBounds.X + 5) : (toggleBounds.Right - textSize.Width - 5),
                    toggleBounds.Y + (toggleBounds.Height - textSize.Height) / 2
                );

                graphics.DrawString(text, font, textBrush, textPosition);
            }

            if (isToggled)
                graphics.FillEllipse(new SolidBrush(Color.White), circleBounds);
            else
                graphics.FillEllipse(new SolidBrush(Color.Gray), circleBounds);

        }

        protected override void OnMouseUp(DataColumnBase dataColumn, RowColumnIndex rowColumnIndex, MouseEventArgs e)
        {
            var record = dataGrid.GetRecordAtRowIndex(rowColumnIndex.RowIndex);
            var provider = dataGrid.View.GetPropertyAccessProvider();
            var value = provider.GetValue(record, dataColumn.GridColumn.MappingName);
            bool toggleValue = value != null && (bool)value;

            provider.SetValue(record, dataColumn.GridColumn.MappingName, !toggleValue);

            this.TableControl.Invalidate();
        }
    }
}
