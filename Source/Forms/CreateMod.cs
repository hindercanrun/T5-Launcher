using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Launcher
{
	internal class CreateMod : Form
	{
		private readonly IContainer components = null;
		private GroupBox NewModGroupBox;
		private Label NewModNameLabel;
		private TextBox NewModNameTextBox;
		private Button NewModCreateButton;

		internal CreateMod()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(CreateMod));
			NewModGroupBox = new GroupBox();
			NewModCreateButton = new Button();
			NewModNameTextBox = new TextBox();
			NewModNameLabel = new Label();
			NewModGroupBox.SuspendLayout();
			SuspendLayout();
			// 
			// NewModGroupBox
			// 
			NewModGroupBox.Controls.Add(NewModCreateButton);
			NewModGroupBox.Controls.Add(NewModNameTextBox);
			NewModGroupBox.Controls.Add(NewModNameLabel);
			NewModGroupBox.Location = new Point(12, 12);
			NewModGroupBox.Name = "NewModGroupBox";
			NewModGroupBox.Size = new Size(260, 71);
			NewModGroupBox.TabIndex = 0;
			NewModGroupBox.TabStop = false;
			NewModGroupBox.Text = "New Mod";
			// 
			// NewModCreateButton
			// 
			NewModCreateButton.Location = new Point(124, 42);
			NewModCreateButton.Name = "NewModCreateButton";
			NewModCreateButton.Size = new Size(130, 23);
			NewModCreateButton.TabIndex = 2;
			NewModCreateButton.Text = "Create Mod";
			NewModCreateButton.UseVisualStyleBackColor = true;
			NewModCreateButton.Click += new EventHandler(NewModCreateButton_Click);
			// 
			// NewModNameTextBox
			// 
			NewModNameTextBox.Location = new Point(106, 16);
			NewModNameTextBox.Name = "NewModNameTextBox";
			NewModNameTextBox.Size = new Size(148, 20);
			NewModNameTextBox.TabIndex = 1;
			// 
			// NewModNameLabel
			// 
			NewModNameLabel.AutoSize = true;
			NewModNameLabel.Location = new Point(6, 19);
			NewModNameLabel.Name = "NewModNameLabel";
			NewModNameLabel.Size = new Size(94, 13);
			NewModNameLabel.TabIndex = 0;
			NewModNameLabel.Text = "Mod Folder Name:";
			// 
			// CreateModForm
			// 
			AcceptButton = NewModCreateButton;
			AutoScaleDimensions = new SizeF(6F, 13F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(284, 95);
			Controls.Add(NewModGroupBox);
			Icon = ((Icon)(resources.GetObject("$this.Icon")));
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "CreateModForm";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Create a New Mod";
			NewModGroupBox.ResumeLayout(false);
			NewModGroupBox.PerformLayout();
			ResumeLayout(false);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null) components.Dispose();
			base.Dispose(disposing);
		}

		private void NewModCreateButton_Click(object sender, EventArgs e)
		{
			string text = NewModNameTextBox.Text;
			string path = Path.Combine(Launcher.GetModsDirectory(), text);

			// Check if null or empty
			if (text == null || text == "")
			{
				MessageBox.Show("Mod folder name is invalid.", "Error");
				return;
			}

			// Check if mod exists
			if (Directory.Exists(path))
			{
				MessageBox.Show($"Mod folder already exists\nwith name: {text}", "Error");
				NewModNameTextBox.Text = "";
				return;
			}

			// Create the stuff
			Directory.CreateDirectory(path);
			File.Create(path + "/mod.csv").Close();

			// Close form
			Close();

			// Set tabs
			Launcher.MainForm.SetLauncherTab(MainWindow.LauncherTabType.Mods);
			Launcher.MainForm.SetModSelection(text, true);
		}
	}
}