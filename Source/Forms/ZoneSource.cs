using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Launcher
{
	internal class ZoneSource : Form
	{
		private IContainer components;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem ZoneSourceFileMenuItem;
		private ToolStripMenuItem ZoneSourceSaveCSVMenuItem;
		private SplitContainer ZoneSourcePanel;
		private GroupBox ZoneSourceMissingAssetsGroupBox;
		internal RichTextBox ZoneSourceMissingAssetsCSVList;
		private GroupBox ZoneSourceCSVGroupBox;
		internal RichTextBox ZoneSourceCSVList;
		private GroupBox ZoneSourceInfoGroupBox;
		private TextBox ZoneSourceInfoCSVTextBox;
		private Label ZoneSourceInfoCSVLabel;
		private TextBox ZoneSourceInfoModTextBox;
		private Label ZoneSourceInfoModLabel;
		private Button ZoneSourceBottomSaveButton;

		internal ZoneSource(string modName)
		{
			InitializeComponent();
			ZoneSourceInfoModTextBox.Text = modName;
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
			menuStrip1 = new MenuStrip();
			ZoneSourceFileMenuItem = new ToolStripMenuItem();
			ZoneSourceSaveCSVMenuItem = new ToolStripMenuItem();
			ZoneSourcePanel = new SplitContainer();
			ZoneSourceMissingAssetsGroupBox = new GroupBox();
			ZoneSourceMissingAssetsCSVList = new RichTextBox();
			ZoneSourceCSVGroupBox = new GroupBox();
			ZoneSourceBottomSaveButton = new Button();
			ZoneSourceCSVList = new RichTextBox();
			ZoneSourceInfoGroupBox = new GroupBox();
			ZoneSourceInfoCSVTextBox = new TextBox();
			ZoneSourceInfoCSVLabel = new Label();
			ZoneSourceInfoModTextBox = new TextBox();
			ZoneSourceInfoModLabel = new Label();
			menuStrip1.SuspendLayout();
			ZoneSourcePanel.Panel1.SuspendLayout();
			ZoneSourcePanel.Panel2.SuspendLayout();
			ZoneSourcePanel.SuspendLayout();
			ZoneSourceMissingAssetsGroupBox.SuspendLayout();
			ZoneSourceCSVGroupBox.SuspendLayout();
			ZoneSourceInfoGroupBox.SuspendLayout();
			SuspendLayout();
			menuStrip1.Items.AddRange(new ToolStripItem[1]
			{
				ZoneSourceFileMenuItem
			});
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(762, 24);
			menuStrip1.TabIndex = 2;
			menuStrip1.Text = "menuStrip1";
			ZoneSourceFileMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
			{
				ZoneSourceSaveCSVMenuItem
			});
			ZoneSourceFileMenuItem.Name = "ZoneSourceFileMenuItem";
			ZoneSourceFileMenuItem.Size = new Size(37, 20);
			ZoneSourceFileMenuItem.Text = "File";
			ZoneSourceSaveCSVMenuItem.Name = "ZoneSourceSaveCSVMenuItem";
			ZoneSourceSaveCSVMenuItem.Size = new Size(98, 22);
			ZoneSourceSaveCSVMenuItem.Text = "Save";
			ZoneSourceSaveCSVMenuItem.Click += new EventHandler(ZoneSourceSaveCSVMenuItem_Click);
			ZoneSourcePanel.Dock = DockStyle.Fill;
			ZoneSourcePanel.IsSplitterFixed = true;
			ZoneSourcePanel.Location = new Point(0, 24);
			ZoneSourcePanel.Name = "ZoneSourcePanel";
			ZoneSourcePanel.Panel1.Controls.Add(ZoneSourceMissingAssetsGroupBox);
			ZoneSourcePanel.Panel2.Controls.Add(ZoneSourceCSVGroupBox);
			ZoneSourcePanel.Size = new Size(762, 706);
			ZoneSourcePanel.SplitterDistance = 381;
			ZoneSourcePanel.TabIndex = 3;
			ZoneSourceMissingAssetsGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ZoneSourceMissingAssetsGroupBox.Controls.Add(ZoneSourceMissingAssetsCSVList);
			ZoneSourceMissingAssetsGroupBox.Location = new Point(3, 46);
			ZoneSourceMissingAssetsGroupBox.Name = "ZoneSourceMissingAssetsGroupBox";
			ZoneSourceMissingAssetsGroupBox.Size = new Size(375, 657);
			ZoneSourceMissingAssetsGroupBox.TabIndex = 6;
			ZoneSourceMissingAssetsGroupBox.TabStop = false;
			ZoneSourceMissingAssetsGroupBox.Text = "Missing Assets";
			ZoneSourceMissingAssetsCSVList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ZoneSourceMissingAssetsCSVList.BackColor = SystemColors.Info;
			ZoneSourceMissingAssetsCSVList.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
			ZoneSourceMissingAssetsCSVList.Location = new Point(6, 16);
			ZoneSourceMissingAssetsCSVList.Name = "ZoneSourceMissingAssetsCSVList";
			ZoneSourceMissingAssetsCSVList.Size = new Size(363, 632);
			ZoneSourceMissingAssetsCSVList.TabIndex = 3;
			ZoneSourceMissingAssetsCSVList.Text = "";
			ZoneSourceMissingAssetsCSVList.WordWrap = false;
			ZoneSourceCSVGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ZoneSourceCSVGroupBox.Controls.Add(ZoneSourceBottomSaveButton);
			ZoneSourceCSVGroupBox.Controls.Add(ZoneSourceCSVList);
			ZoneSourceCSVGroupBox.Location = new Point(3, 46);
			ZoneSourceCSVGroupBox.Name = "ZoneSourceCSVGroupBox";
			ZoneSourceCSVGroupBox.Size = new Size(373, 657);
			ZoneSourceCSVGroupBox.TabIndex = 8;
			ZoneSourceCSVGroupBox.TabStop = false;
			ZoneSourceCSVGroupBox.Text = "Zone Source";
			ZoneSourceBottomSaveButton.Dock = DockStyle.Bottom;
			ZoneSourceBottomSaveButton.Location = new Point(3, 630);
			ZoneSourceBottomSaveButton.Name = "ZoneSourceBottomSaveButton";
			ZoneSourceBottomSaveButton.Size = new Size(367, 24);
			ZoneSourceBottomSaveButton.TabIndex = 3;
			ZoneSourceBottomSaveButton.Text = "Save";
			ZoneSourceBottomSaveButton.UseVisualStyleBackColor = true;
			ZoneSourceBottomSaveButton.Click += new EventHandler(ZoneSourceBottomSaveButton_Click);
			ZoneSourceCSVList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ZoneSourceCSVList.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
			ZoneSourceCSVList.Location = new Point(6, 16);
			ZoneSourceCSVList.Name = "ZoneSourceCSVList";
			ZoneSourceCSVList.Size = new Size(361, 605);
			ZoneSourceCSVList.TabIndex = 2;
			ZoneSourceCSVList.Text = "";
			ZoneSourceCSVList.WordWrap = false;
			ZoneSourceInfoGroupBox.Controls.Add(ZoneSourceInfoCSVTextBox);
			ZoneSourceInfoGroupBox.Controls.Add(ZoneSourceInfoCSVLabel);
			ZoneSourceInfoGroupBox.Controls.Add(ZoneSourceInfoModTextBox);
			ZoneSourceInfoGroupBox.Controls.Add(ZoneSourceInfoModLabel);
			ZoneSourceInfoGroupBox.Dock = DockStyle.Top;
			ZoneSourceInfoGroupBox.Location = new Point(0, 24);
			ZoneSourceInfoGroupBox.Name = "ZoneSourceInfoGroupBox";
			ZoneSourceInfoGroupBox.Size = new Size(762, 40);
			ZoneSourceInfoGroupBox.TabIndex = 5;
			ZoneSourceInfoGroupBox.TabStop = false;
			ZoneSourceInfoGroupBox.Text = "Info";
			ZoneSourceInfoCSVTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ZoneSourceInfoCSVTextBox.Location = new Point(284, 12);
			ZoneSourceInfoCSVTextBox.Multiline = true;
			ZoneSourceInfoCSVTextBox.Name = "ZoneSourceInfoCSVTextBox";
			ZoneSourceInfoCSVTextBox.ReadOnly = true;
			ZoneSourceInfoCSVTextBox.Size = new Size(472, 22);
			ZoneSourceInfoCSVTextBox.TabIndex = 21;
			ZoneSourceInfoCSVLabel.AutoSize = true;
			ZoneSourceInfoCSVLabel.Location = new Point(203, 16);
			ZoneSourceInfoCSVLabel.Name = "ZoneSourceInfoCSVLabel";
			ZoneSourceInfoCSVLabel.Size = new Size(75, 13);
			ZoneSourceInfoCSVLabel.TabIndex = 20;
			ZoneSourceInfoCSVLabel.Text = "CSV Location:";
			ZoneSourceInfoModTextBox.Location = new Point(47, 12);
			ZoneSourceInfoModTextBox.Multiline = true;
			ZoneSourceInfoModTextBox.Name = "ZoneSourceInfoModTextBox";
			ZoneSourceInfoModTextBox.ReadOnly = true;
			ZoneSourceInfoModTextBox.Size = new Size(150, 22);
			ZoneSourceInfoModTextBox.TabIndex = 19;
			ZoneSourceInfoModLabel.AutoSize = true;
			ZoneSourceInfoModLabel.Location = new Point(6, 16);
			ZoneSourceInfoModLabel.Name = "ZoneSourceInfoModLabel";
			ZoneSourceInfoModLabel.Size = new Size(31, 13);
			ZoneSourceInfoModLabel.TabIndex = 0;
			ZoneSourceInfoModLabel.Text = "Mod:";
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(762, 730);
			Controls.Add(ZoneSourceInfoGroupBox);
			Controls.Add(ZoneSourcePanel);
			Controls.Add(menuStrip1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MainMenuStrip = menuStrip1;
			MinimizeBox = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Zone Source";
			Load += new EventHandler(LauncherZoneSourceForm_Load);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ZoneSourcePanel.Panel1.ResumeLayout(false);
			ZoneSourcePanel.Panel2.ResumeLayout(false);
			ZoneSourcePanel.ResumeLayout(false);
			ZoneSourceMissingAssetsGroupBox.ResumeLayout(false);
			ZoneSourceCSVGroupBox.ResumeLayout(false);
			ZoneSourceInfoGroupBox.ResumeLayout(false);
			ZoneSourceInfoGroupBox.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private void LauncherZoneSourceForm_Load(object sender, EventArgs e)
		{
			string text = ZoneSourceInfoModTextBox.Text;

			string modCSV = Path.Combine(Launcher.GetModDirectory(text), "mod.csv");
			ZoneSourceInfoCSVTextBox.Text = modCSV;
			if (!File.Exists(modCSV)) File.Create(modCSV).Close();
			ZoneSourceCSVList.Lines = Launcher.LoadTextFile(modCSV);

			string missingAssetCSV = Path.Combine(Launcher.GetModDirectory(text), "missingasset.csv");
			if (!File.Exists(missingAssetCSV)) return;
			ZoneSourceMissingAssetsCSVList.Lines = Launcher.LoadTextFile(missingAssetCSV);
		}

		private void SaveCSV()
		{
			string text = ZoneSourceInfoModTextBox.Text;

			string modCSV = Path.Combine(Launcher.GetModDirectory(text), "mod.csv");
			if (!File.Exists(modCSV)) File.Create(modCSV).Close();
			Launcher.SaveTextFile(modCSV, ZoneSourceCSVList.Lines);

			string missingAssetCSV = Path.Combine(Launcher.GetModDirectory(text), "missingasset.csv");
			if (File.Exists(missingAssetCSV)) Launcher.SaveTextFile(missingAssetCSV, ZoneSourceMissingAssetsCSVList.Lines);

			Close();
		}

		private void ZoneSourceBottomSaveButton_Click(object sender, EventArgs e)
		{
			SaveCSV();
		}

		private void ZoneSourceSaveCSVMenuItem_Click(object sender, EventArgs e)
		{
			SaveCSV();
		}
	}
}