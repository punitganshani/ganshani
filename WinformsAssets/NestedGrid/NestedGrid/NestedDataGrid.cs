using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace NestedGrid
{
    public partial class NestedDataGrid : DataGridView
    {
        public NestedDataGrid()
        {
            InitializeComponent();
        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < this.Rows.Count; i++ )
            {
                for (int x = 0; x < this.Columns.Count; x++)
                    if (this.Columns[x].DataPropertyName.Contains("."))
                    {
                        string value = BindProperty(this.Rows[i].DataBoundItem,
                                     this.Columns[x].DataPropertyName);

                        this.Rows[i].Cells[x].Value = value;
                    }
            }

            base.OnDataBindingComplete(e);
        }

        //protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        //{
        //    // Find out whether the current DataPropertyName has '.' in it or not.
        //    if ((this.Rows[e.RowIndex].DataBoundItem != null) &&
        //        (this.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
        //    {
        //        e.Value = BindProperty(
        //            this.Rows[e.RowIndex].DataBoundItem,
        //            this.Columns[e.ColumnIndex].DataPropertyName
        //        );

        //        e.FormattingApplied = true;
        //    }

        //    //base.OnCellFormatting(e);
        //}

        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";

            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;
                string leftPropertyName;

                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                System.Type propertyType;
                PropertyInfo propertyInfo;

                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                if (propertyInfo != null)
                    retValue = propertyInfo.GetValue(property, null).ToString();
                else
                    retValue = string.Empty;
            }

            return retValue;
        }
    }
}
