using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Launcher
{
	internal class CreateMap : Form
	{
		private IContainer components;
		private GroupBox MapTemplatesGroupBox;
		private ListBox MapTemplatesListBox;
		private GroupBox MapNameGroupBox;
		private TextBox MapNameTextBox;
		private Button MapCreateButtonOK;
		private Button MapCreateButtonCancel;
		private Launcher.MAP_TEMPLATE_TYPE cTemplateType;

		internal CreateMap()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new Container();
			MapTemplatesGroupBox = new GroupBox();
			MapTemplatesListBox = new ListBox();
			MapNameGroupBox = new GroupBox();
			MapNameTextBox = new TextBox();
			MapCreateButtonOK = new Button();
			MapCreateButtonCancel = new Button();
			MapTemplatesGroupBox.SuspendLayout();
			MapNameGroupBox.SuspendLayout();
			SuspendLayout();
			MapTemplatesGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			MapTemplatesGroupBox.Controls.Add(MapTemplatesListBox);
			MapTemplatesGroupBox.Location = new Point(12, 12);
			MapTemplatesGroupBox.Name = "MapTemplatesGroupBox";
			MapTemplatesGroupBox.Size = new Size(132, 135);
			MapTemplatesGroupBox.TabIndex = 0;
			MapTemplatesGroupBox.TabStop = false;
			MapTemplatesGroupBox.Text = "Map Templates";
			MapTemplatesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			MapTemplatesListBox.FormattingEnabled = true;
			MapTemplatesListBox.Location = new Point(6, 19);
			MapTemplatesListBox.Name = "MapTemplatesListBox";
			MapTemplatesListBox.Size = new Size(120, 108);
			MapTemplatesListBox.TabIndex = 0;
			MapTemplatesListBox.SelectedIndexChanged += new EventHandler(MapTemplatesListBox_SelectedIndexChanged);
			MapNameGroupBox.Controls.Add((Control)this.MapNameTextBox);
			MapNameGroupBox.Location = new Point(150, 12);
			MapNameGroupBox.Name = "MapNameGroupBox";
			MapNameGroupBox.Size = new Size(260, 49);
			MapNameGroupBox.TabIndex = 1;
			MapNameGroupBox.TabStop = false;
			MapNameGroupBox.Text = "Map Name";
			MapNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			MapNameTextBox.Location = new Point(6, 19);
			MapNameTextBox.MaxLength = 15;
			MapNameTextBox.Name = "MapNameTextBox";
			MapNameTextBox.Size = new Size(248, 20);
			MapNameTextBox.TabIndex = 0;
			MapCreateButtonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			MapCreateButtonOK.Enabled = false;
			MapCreateButtonOK.Location = new Point(246, 124);
			MapCreateButtonOK.Name = "MapCreateButtonOK";
			MapCreateButtonOK.Size = new Size(75, 23);
			MapCreateButtonOK.TabIndex = 2;
			MapCreateButtonOK.Text = "OK";
			MapCreateButtonOK.UseVisualStyleBackColor = true;
			MapCreateButtonOK.Click += new EventHandler(MapCreateButtonOK_Click);
			MapCreateButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			MapCreateButtonCancel.DialogResult = DialogResult.Cancel;
			MapCreateButtonCancel.Location = new Point(327, 124);
			MapCreateButtonCancel.Name = "MapCreateButtonCancel";
			MapCreateButtonCancel.Size = new Size(75, 23);
			MapCreateButtonCancel.TabIndex = 3;
			MapCreateButtonCancel.Text = "Cancel";
			MapCreateButtonCancel.UseVisualStyleBackColor = true;
			AcceptButton = MapCreateButtonOK;
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = MapCreateButtonCancel;
			ClientSize = new Size(414, 159);
			Controls.Add(MapCreateButtonCancel);
			Controls.Add(MapCreateButtonOK);
			Controls.Add(MapNameGroupBox);
			Controls.Add(MapTemplatesGroupBox);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Create a New Map";
			Load += new EventHandler(LauncherCreateMapForm_Load);
			MapTemplatesGroupBox.ResumeLayout(false);
			MapNameGroupBox.ResumeLayout(false);
			MapNameGroupBox.PerformLayout();
			ResumeLayout(false);
			cTemplateType = Launcher.MAP_TEMPLATE_TYPE.SELECTION_UNDEFINED_TEMPLATE;
		}

		private void LauncherCreateMapForm_Load(object sender, EventArgs e)
		{
			// Clear the list, then grab the template list
			MapTemplatesListBox.Items.Clear();
			MapTemplatesListBox.Items.AddRange(Launcher.GetMapTemplatesList());

			// There must be atleast one template, error out if less then 1 exist
			if (MapTemplatesListBox.Items.Count < 1)
			{
				MessageBox.Show("There are no map templates.", "Error");
				Close();
				return;
			}

			// All good
			MapTemplatesListBox.SelectedIndex = 0;
		}

		private void MapCreateButtonOK_Click(object sender, EventArgs e)
		{
			string text = MapNameTextBox.Text;

			// Check if null or empty
			if (text == null || text == "")
			{
				MessageBox.Show("Map name is invalid.", "Error");
				return;
			}

			string mapTemplate = MapTemplatesListBox.Items[MapTemplatesListBox.SelectedIndex].ToString();
			string mapName = Launcher.FilterMP(text);

			bool flag = true;
			string[] mapFromTemplate = Launcher.CreateMapFromTemplate(mapTemplate, mapName, true);

			if (mapFromTemplate.Length != 0 &&
				DialogResult.No ==
				MessageBox.Show(
					$"Certain files would be overwritten:\n\n{Launcher.StringArrayToString(mapFromTemplate)}\nDo you want to continue?",
					"Should overwrite files?",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Exclamation))
			{
				flag = false;
			}

			if (flag)
			{
				// Create the level based on the template
				Launcher.CreateMapFromTemplate(mapTemplate, mapName);

				// Swich the tab to whatever mode
				if (cTemplateType == Launcher.MAP_TEMPLATE_TYPE.SELECTION_MP_TEMPLATE)
				{
					Launcher.TheLauncherForm.SetTabToMultiplayer();
				}
				else
				{
					Launcher.TheLauncherForm.SetTabToSingleplayer();
				}

				// Set the selection and stuff
				Launcher.TheLauncherForm.SetMapSelection(text, true);
				Launcher.TheLauncherForm.SetLauncherTab(LauncherForm.LauncherTabType.Maps);
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void MapTemplatesListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = MapTemplatesListBox.SelectedIndex;
			MapCreateButtonOK.Enabled = selectedIndex >= 0;

			if (selectedIndex < 0)
			{
				cTemplateType = Launcher.MAP_TEMPLATE_TYPE.SELECTION_UNDEFINED_TEMPLATE;
			}
			else
			{
				string mapTemplate = MapTemplatesListBox.Items[selectedIndex].ToString();
				string name = Launcher.FilterPrefix(MapNameTextBox.Text, cTemplateType);

				if (Launcher.IsMultiplayerMapTemplate(mapTemplate))
				{
					cTemplateType = Launcher.MAP_TEMPLATE_TYPE.SELECTION_MP_TEMPLATE;
					MapNameTextBox.Text = Launcher.MakeMP(name);
				}
				else if (Launcher.IsZombieMapTemplate(mapTemplate))
				{
					cTemplateType = Launcher.MAP_TEMPLATE_TYPE.SELECTION_ZM_TEMPLATE;
					MapNameTextBox.Text = Launcher.MakeZM(name);
				}
				else // Singleplayer
				{
					cTemplateType = Launcher.MAP_TEMPLATE_TYPE.SELECTION_CUSTOM_TEMPLATE;
					MapNameTextBox.Text = name;
				}
			}
		}
	}
}