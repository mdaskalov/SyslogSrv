using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using System.Text.RegularExpressions;
using System.Reflection;

namespace SyslogSrv
{
    public partial class Filter : Form
    {
        private AggregateBindingListView<LogLine> view;

        public Filter(AggregateBindingListView<LogLine> parentView)
        {
            InitializeComponent();
            view = parentView;
            view.RemoveFilter();
            filterProperty.SelectedIndex = 7;
        }

        /*
            if (highlightText.Text != "")
            {
                for (int i = 0; i < e.RowCount; i++)
                {
                    DataGridViewCell msg = lineSetDataGridView.Rows[e.RowIndex + i].Cells["messageColumn"];
                    if (msg.Value.ToString().Contains(highlightText.Text))
                        msg.Style.BackColor = Color.Red;
                }
            }
         */

        private void filterText_TextChanged(object sender, EventArgs e)
        {
            if (filterText.Text == "")
            {
                view.RemoveFilter();
                if (regularExpression.CheckState == CheckState.Indeterminate)
                    regularExpression.CheckState = CheckState.Checked;
            }
            else
            {
                string property = filterProperty.SelectedItem.ToString();
                string match = matchCase.Checked ? filterText.Text : filterText.Text.ToLower();
                Regex m = null;
                if (regularExpression.CheckState != CheckState.Unchecked)
                {
                    try
                    {
                        m = new Regex(filterText.Text, RegexOptions.Compiled);
                        regularExpression.CheckState = CheckState.Checked;
                    }
                    catch
                    {
                        regularExpression.CheckState = CheckState.Indeterminate;
                    }
                }

                view.ApplyFilter(
                    delegate(LogLine line)
                    {
                        string src = line.GetType().GetProperty(property).GetValue(line, null).ToString();

                        if (!matchCase.Checked)
                            src = src.ToLower();

                        if (regularExpression.CheckState == CheckState.Checked)
                            return m.Match(src).Success;
                        else
                            return (wholeText.Checked ? src.Equals(match) : src.Contains(match));
                    }
                 );
            }
        }

        private void regularExpression_CheckedChanged(object sender, EventArgs e)
        {
            if (regularExpression.Checked)
            {
                matchCase.Checked = false;
                matchCase.Enabled = false;
                wholeText.Checked = false;
                wholeText.Enabled = false;
            }
            else
            {
                matchCase.Enabled = true;
                wholeText.Enabled = true;
            }
            filterText_TextChanged(null, null);
        }
    }
}