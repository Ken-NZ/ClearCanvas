#region License

// Copyright (c) 2013, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This file is part of the ClearCanvas RIS/PACS open source project.
//
// The ClearCanvas RIS/PACS open source project is free software: you can
// redistribute it and/or modify it under the terms of the GNU General Public
// License as published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// The ClearCanvas RIS/PACS open source project is distributed in the hope that it
// will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General
// Public License for more details.
//
// You should have received a copy of the GNU General Public License along with
// the ClearCanvas RIS/PACS open source project.  If not, see
// <http://www.gnu.org/licenses/>.

#endregion

using System;
using System.Windows.Forms;

using ClearCanvas.Desktop.View.WinForms;

namespace ClearCanvas.Ris.Client.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="OrderNoteEditorComponent"/>
    /// </summary>
    public partial class OrderNoteEditorComponentControl : ApplicationComponentUserControl
    {
        private readonly OrderNoteEditorComponent _component;
		private readonly CannedTextSupport _cannedTextSupport;

        /// <summary>
        /// Constructor
        /// </summary>
        public OrderNoteEditorComponentControl(OrderNoteEditorComponent component)
            :base(component)
        {
            InitializeComponent();
            _component = component;

            _comment.DataBindings.Add("Value", _component, "Comment", true, DataSourceUpdateMode.OnPropertyChanged);
			_cannedTextSupport = new CannedTextSupport(_comment, _component.CannedTextLookupHandler);

			_acceptButton.DataBindings.Add("Enabled", _component, "AcceptEnabled", true, DataSourceUpdateMode.OnPropertyChanged);
            _comment.ReadOnly = !_component.IsNewItem;
        }

        private void _acceptButton_Click(object sender, EventArgs e)
        {
            _component.Accept();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            _component.Cancel();
        }
    }
}
