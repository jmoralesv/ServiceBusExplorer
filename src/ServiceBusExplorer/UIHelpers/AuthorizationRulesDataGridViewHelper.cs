#region Copyright
//=======================================================================================
// Microsoft Azure Customer Advisory Team 
//
// This sample is supplemental to the technical guidance published on my personal
// blog at http://blogs.msdn.com/b/paolos/. 
// 
// Author: Paolo Salvatori
//=======================================================================================
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// LICENSED UNDER THE APACHE LICENSE, VERSION 2.0 (THE "LICENSE"); YOU MAY NOT USE THESE 
// FILES EXCEPT IN COMPLIANCE WITH THE LICENSE. YOU MAY OBTAIN A COPY OF THE LICENSE AT 
// http://www.apache.org/licenses/LICENSE-2.0
// UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING, SOFTWARE DISTRIBUTED UNDER THE 
// LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY 
// KIND, EITHER EXPRESS OR IMPLIED. SEE THE LICENSE FOR THE SPECIFIC LANGUAGE GOVERNING 
// PERMISSIONS AND LIMITATIONS UNDER THE LICENSE.
//=======================================================================================
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace ServiceBusExplorer.UIHelpers
{
    internal class AuthorizationRulesDataGridViewHelper
    {
        private static readonly List<string> claimTypes = new List<string> { "NameIdentifier", "Upn", "Role", "SharedAccessKey" };

        internal static void InitializeDataGridView(DataGridView dataGridView)
        {
            if (dataGridView == null)
            {
                return;
            }

            // Set Grid style
            dataGridView.EnableHeadersVisualStyles = false;

            // Set the selection background color for all the cells.
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(92, 125, 150);
            dataGridView.DefaultCellStyle.SelectionForeColor = SystemColors.Window;

            // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
            // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(153, 180, 209);

            // Set the background color for all rows and for alternating rows.
            // The value for alternating rows overrides the value for all rows.
            dataGridView.RowsDefaultCellStyle.BackColor = SystemColors.Window;
            dataGridView.RowsDefaultCellStyle.ForeColor = SystemColors.ControlText;

            // Set the row and column header styles.
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(215, 228, 242);
            dataGridView.RowHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(215, 228, 242);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;

            dataGridView.AutoGenerateColumns = false;
        }

        internal static void AddAuthorizationRulesColumns(DataGridView dataGridView, bool isCloudNamespace, Func<int, int> logicalToDeviceUnits)
        {
            if (dataGridView.Columns.Count > 0)
            {
                return;
            }

            var columns = new List<DataGridViewColumn>
            {
                new DataGridViewTextBoxColumn { Name = "IssuerName", DataPropertyName = "IssuerName" },
                new DataGridViewComboBoxColumn { Name = "ClaimType", DataPropertyName = "ClaimType", DataSource = claimTypes, FlatStyle = FlatStyle.Flat },
                new DataGridViewTextBoxColumn { Name = "ClaimValue", DataPropertyName = "ClaimValue" }
            };

            if (isCloudNamespace)
            {
                columns.Add(new DataGridViewTextBoxColumn { Name = "KeyName", DataPropertyName = "KeyName" });
                columns.Add(new DataGridViewTextBoxColumn { Name = "PrimaryKey", DataPropertyName = "PrimaryKey" });
                columns.Add(new DataGridViewTextBoxColumn { Name = "SecondaryKey", DataPropertyName = "SecondaryKey" });
            }

            columns.Add(new DataGridViewCheckBoxColumn { Name = "Manage", DataPropertyName = "Manage", Width = logicalToDeviceUnits(50) });
            columns.Add(new DataGridViewCheckBoxColumn { Name = "Send", DataPropertyName = "Send", Width = logicalToDeviceUnits(50) });
            columns.Add(new DataGridViewCheckBoxColumn { Name = "Listen", DataPropertyName = "Listen", Width = logicalToDeviceUnits(50) });
            columns.Add(new DataGridViewTextBoxColumn { Name = "Revision", DataPropertyName = "Revision", Width = logicalToDeviceUnits(55), ReadOnly = true });
            columns.Add(new DataGridViewTextBoxColumn { Name = "CreatedTime", DataPropertyName = "CreatedTime", ReadOnly = true });
            columns.Add(new DataGridViewTextBoxColumn { Name = "ModifiedTime", DataPropertyName = "ModifiedTime", ReadOnly = true });

            dataGridView.Columns.AddRange(columns.ToArray());
        }
    }
}
