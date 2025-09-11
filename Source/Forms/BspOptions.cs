using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Launcher
{
	internal class BspOptions : Form
	{
		private readonly IContainer components;
		private GroupBox BspOptionsGroupBox;
		private Label BspOptionsExtraOptionsLabelText;
		private CheckBox BspOptionsDebugLightsCheckBox;
		private NumericUpDown BspOptionsBlockSizeNumericUpDown;
		private NumericUpDown BspOptionsSampleScaleNumericUpDown;
		private CheckBox BspOptionsSampleScaleCheckBox;
		private CheckBox BspOptionsBlockSizeCheckBox;
		private CheckBox BspOptionsOnlyEntsCheckBox;
		private Button BspOptionsButtonOK;
		private Button BspOptionsButtonCancel;
		private CheckBox BspOptionsLeakTest;
		private CheckBox BspOptionsDebugProbes;
		private TextBox BspOptionsExtraOptionsTextBox;

		internal BspOptions()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			BspOptionsGroupBox = new GroupBox();
			BspOptionsLeakTest = new CheckBox();
			BspOptionsSampleScaleCheckBox = new CheckBox();
			BspOptionsExtraOptionsLabelText = new Label();
			BspOptionsDebugLightsCheckBox = new CheckBox();
			BspOptionsExtraOptionsTextBox = new TextBox();
			BspOptionsBlockSizeNumericUpDown = new NumericUpDown();
			BspOptionsSampleScaleNumericUpDown = new NumericUpDown();
			BspOptionsBlockSizeCheckBox = new CheckBox();
			BspOptionsOnlyEntsCheckBox = new CheckBox();
			BspOptionsButtonOK = new Button();
			BspOptionsButtonCancel = new Button();
			BspOptionsDebugProbes = new CheckBox();
			BspOptionsGroupBox.SuspendLayout();
			BspOptionsBlockSizeNumericUpDown.BeginInit();
			BspOptionsSampleScaleNumericUpDown.BeginInit();
			SuspendLayout();
			BspOptionsGroupBox.Controls.Add(BspOptionsDebugProbes);
			BspOptionsGroupBox.Controls.Add(BspOptionsLeakTest);
			BspOptionsGroupBox.Controls.Add(BspOptionsSampleScaleCheckBox);
			BspOptionsGroupBox.Controls.Add(BspOptionsExtraOptionsLabelText);
			BspOptionsGroupBox.Controls.Add(BspOptionsDebugLightsCheckBox);
			BspOptionsGroupBox.Controls.Add(BspOptionsExtraOptionsTextBox);
			BspOptionsGroupBox.Controls.Add(BspOptionsBlockSizeNumericUpDown);
			BspOptionsGroupBox.Controls.Add(BspOptionsSampleScaleNumericUpDown);
			BspOptionsGroupBox.Controls.Add(BspOptionsBlockSizeCheckBox);
			BspOptionsGroupBox.Controls.Add(BspOptionsOnlyEntsCheckBox);
			BspOptionsGroupBox.Location = new Point(12, 12);
			BspOptionsGroupBox.Name = "BspOptionsGroupBox";
			BspOptionsGroupBox.Size = new Size(291, 157);
			BspOptionsGroupBox.TabIndex = 21;
			BspOptionsGroupBox.TabStop = false;
			BspOptionsGroupBox.Text = "Compile BSP Options";
			BspOptionsLeakTest.AutoSize = true;
			BspOptionsLeakTest.FlatStyle = FlatStyle.Popup;
			BspOptionsLeakTest.Location = new Point(10, 81);
			BspOptionsLeakTest.Name = "BspOptionsLeakTest";
			BspOptionsLeakTest.Size = new Size(72, 17);
			BspOptionsLeakTest.TabIndex = 20;
			BspOptionsLeakTest.Tag = "Aborts compilation if a BSP leak is found";
			BspOptionsLeakTest.Text = "Leak Test";
			BspOptionsLeakTest.UseVisualStyleBackColor = true;
			BspOptionsSampleScaleCheckBox.AutoSize = true;
			BspOptionsSampleScaleCheckBox.FlatStyle = FlatStyle.Popup;
			BspOptionsSampleScaleCheckBox.Location = new Point(116, 50);
			BspOptionsSampleScaleCheckBox.Name = "BspOptionsSampleScaleCheckBox";
			BspOptionsSampleScaleCheckBox.Size = new Size(89, 17);
			BspOptionsSampleScaleCheckBox.TabIndex = 14;
			BspOptionsSampleScaleCheckBox.Text = "Sample Scale";
			BspOptionsSampleScaleCheckBox.UseVisualStyleBackColor = true;
			BspOptionsSampleScaleCheckBox.CheckedChanged += new EventHandler(BspOptionsSampleScaleCheckBox_CheckedChanged);
			BspOptionsExtraOptionsLabelText.AutoSize = true;
			BspOptionsExtraOptionsLabelText.Location = new Point(7, 114);
			BspOptionsExtraOptionsLabelText.Name = "BspOptionsExtraOptionsLabelText";
			BspOptionsExtraOptionsLabelText.Size = new Size(97, 13);
			BspOptionsExtraOptionsLabelText.TabIndex = 19;
			BspOptionsExtraOptionsLabelText.Text = "Extra BSP Options:";
			BspOptionsDebugLightsCheckBox.AutoSize = true;
			BspOptionsDebugLightsCheckBox.FlatStyle = FlatStyle.Popup;
			BspOptionsDebugLightsCheckBox.Location = new Point(10, 50);
			BspOptionsDebugLightsCheckBox.Name = "BspOptionsDebugLightsCheckBox";
			BspOptionsDebugLightsCheckBox.Size = new Size(107, 17);
			BspOptionsDebugLightsCheckBox.TabIndex = 18;
			BspOptionsDebugLightsCheckBox.Tag = "Fills lightmaps with random colors to show seams";
			BspOptionsDebugLightsCheckBox.Text = "Debug Lightmaps";
			BspOptionsDebugLightsCheckBox.UseVisualStyleBackColor = true;
			BspOptionsExtraOptionsTextBox.Location = new Point(6, 130);
			BspOptionsExtraOptionsTextBox.Name = "BspOptionsExtraOptionsTextBox";
			BspOptionsExtraOptionsTextBox.Size = new Size(276, 20);
			BspOptionsExtraOptionsTextBox.TabIndex = 17;
			BspOptionsBlockSizeNumericUpDown.DecimalPlaces = 2;
			BspOptionsBlockSizeNumericUpDown.Increment = new Decimal(new int[4]
			{
				1,
				0,
				0,
				131072
			});
			BspOptionsBlockSizeNumericUpDown.Location = new Point(211, 19);
			BspOptionsBlockSizeNumericUpDown.Name = "BspOptionsBlockSizeNumericUpDown";
			BspOptionsBlockSizeNumericUpDown.Size = new Size(71, 20);
			BspOptionsBlockSizeNumericUpDown.TabIndex = 16;
			BspOptionsBlockSizeNumericUpDown.Tag = "\"Grid size for regular BSP splits; 0 uses largest possible\"";
			BspOptionsSampleScaleNumericUpDown.DecimalPlaces = 2;
			BspOptionsSampleScaleNumericUpDown.Increment = new Decimal(new int[4]
			{
				1,
				0,
				0,
				131072
			});
			BspOptionsSampleScaleNumericUpDown.Location = new Point(211, 50);
			BspOptionsSampleScaleNumericUpDown.Name = "BspOptionsSampleScaleNumericUpDown";
			BspOptionsSampleScaleNumericUpDown.Size = new Size(71, 20);
			BspOptionsSampleScaleNumericUpDown.TabIndex = 15;
			BspOptionsSampleScaleNumericUpDown.Tag = "\"Scales all lightmaps; For example 2.00 doubles pixel size, 0.50 halves it\"";
			BspOptionsBlockSizeCheckBox.AutoSize = true;
			BspOptionsBlockSizeCheckBox.FlatStyle = FlatStyle.Popup;
			BspOptionsBlockSizeCheckBox.Location = new Point(116, 19);
			BspOptionsBlockSizeCheckBox.Name = "BspOptionsBlockSizeCheckBox";
			BspOptionsBlockSizeCheckBox.Size = new Size(74, 17);
			BspOptionsBlockSizeCheckBox.TabIndex = 13;
			BspOptionsBlockSizeCheckBox.Text = "Block Size";
			BspOptionsBlockSizeCheckBox.UseVisualStyleBackColor = true;
			BspOptionsBlockSizeCheckBox.CheckedChanged += new EventHandler(BspOptionsBlockSizeCheckBox_CheckedChanged);
			BspOptionsOnlyEntsCheckBox.AutoSize = true;
			BspOptionsOnlyEntsCheckBox.FlatStyle = FlatStyle.Popup;
			BspOptionsOnlyEntsCheckBox.Location = new Point(10, 19);
			BspOptionsOnlyEntsCheckBox.Name = "BspOptionsOnlyEntsCheckBox";
			BspOptionsOnlyEntsCheckBox.Size = new Size(69, 17);
			BspOptionsOnlyEntsCheckBox.TabIndex = 12;
			BspOptionsOnlyEntsCheckBox.Tag = "Compile doesn't touch triggers, geometry, or lighting";
			BspOptionsOnlyEntsCheckBox.Text = "Only Ents";
			BspOptionsOnlyEntsCheckBox.UseVisualStyleBackColor = true;
			BspOptionsButtonOK.Location = new Point(147, 185);
			BspOptionsButtonOK.Name = "BspOptionsButtonOK";
			BspOptionsButtonOK.Size = new Size(75, 23);
			BspOptionsButtonOK.TabIndex = 22;
			BspOptionsButtonOK.Text = "OK";
			BspOptionsButtonOK.UseVisualStyleBackColor = true;
			BspOptionsButtonOK.Click += new EventHandler(BspOptionsButtonOK_Click);
			BspOptionsButtonCancel.DialogResult = DialogResult.Cancel;
			BspOptionsButtonCancel.Location = new Point(228, 185);
			BspOptionsButtonCancel.Name = "BspOptionsButtonCancel";
			BspOptionsButtonCancel.Size = new Size(75, 23);
			BspOptionsButtonCancel.TabIndex = 23;
			BspOptionsButtonCancel.Text = "Cancel";
			BspOptionsButtonCancel.UseVisualStyleBackColor = true;
			BspOptionsButtonCancel.Click += new EventHandler(BspOptionsButtonCancel_Click);
			BspOptionsDebugProbes.AutoSize = true;
			BspOptionsDebugProbes.FlatStyle = FlatStyle.Popup;
			BspOptionsDebugProbes.Location = new Point(116, 81);
			BspOptionsDebugProbes.Name = "BspOptionsDebugProbes";
			BspOptionsDebugProbes.Size = new Size(92, 17);
			BspOptionsDebugProbes.TabIndex = 20;
			BspOptionsDebugProbes.Tag = "Adds reflective debug spheres to all reflection probes";
			BspOptionsDebugProbes.Text = "Debug Probes";
			BspOptionsDebugProbes.UseVisualStyleBackColor = true;
			AcceptButton = BspOptionsButtonOK;
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = BspOptionsButtonCancel;
			ClientSize = new Size(313, 220);
			ControlBox = false;
			Controls.Add(BspOptionsButtonCancel);
			Controls.Add(BspOptionsButtonOK);
			Controls.Add(BspOptionsGroupBox);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Advanced Users Options";
			Load += new EventHandler(BspOptionsForm_Load);
			BspOptionsGroupBox.ResumeLayout(false);
			BspOptionsGroupBox.PerformLayout();
			BspOptionsBlockSizeNumericUpDown.EndInit();
			BspOptionsSampleScaleNumericUpDown.EndInit();
			ResumeLayout(false);
		}

		private void BspOptionsBlockSizeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			BspOptionsFormUpdate();
		}

		private void BspOptionsButtonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BspOptionsButtonOK_Click(object sender, EventArgs e)
		{
			Launcher.mapSettings.SetBoolean("bspoptions_onlyents", BspOptionsOnlyEntsCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("bspoptions_blocksize", BspOptionsBlockSizeCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("bspoptions_samplescale", BspOptionsSampleScaleCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("bspoptions_debuglightmaps", BspOptionsDebugLightsCheckBox.Checked);
			Launcher.mapSettings.SetDecimal("bspoptions_blocksize_val", BspOptionsBlockSizeNumericUpDown.Value);
			Launcher.mapSettings.SetDecimal("bspoptions_samplescale_val", BspOptionsSampleScaleNumericUpDown.Value);
			Launcher.mapSettings.SetBoolean("bspoptions_leaktest", BspOptionsLeakTest.Checked);
			Launcher.mapSettings.SetBoolean("bspoptions_debugprobes", BspOptionsDebugProbes.Checked); Launcher.mapSettings.SetString("bspoptions_extraoptions", BspOptionsExtraOptionsTextBox.Text);
			Close();
		}

		private void BspOptionsForm_Load(object sender, EventArgs e)
		{
			BspOptionsOnlyEntsCheckBox.Checked = Launcher.mapSettings.GetBoolean("bspoptions_onlyents");
			BspOptionsBlockSizeCheckBox.Checked = Launcher.mapSettings.GetBoolean("bspoptions_blocksize");
			BspOptionsSampleScaleCheckBox.Checked = Launcher.mapSettings.GetBoolean("bspoptions_samplescale");
			BspOptionsDebugLightsCheckBox.Checked = Launcher.mapSettings.GetBoolean("bspoptions_debuglightmaps");
			Launcher.SetNumericUpDownValue(BspOptionsBlockSizeNumericUpDown, Launcher.mapSettings.GetDecimal("bspoptions_blocksize_val"));
			Launcher.SetNumericUpDownValue(BspOptionsSampleScaleNumericUpDown, Launcher.mapSettings.GetDecimal("bspoptions_samplescale_val"));
			BspOptionsLeakTest.Checked = Launcher.mapSettings.GetBoolean("bspoptions_leaktest", true);
			BspOptionsDebugProbes.Checked = Launcher.mapSettings.GetBoolean("bspoptions_debugprobes");
			BspOptionsExtraOptionsTextBox.Text = Launcher.mapSettings.GetString("bspoptions_extraoptions");
			BspOptionsFormUpdate();
		}

		private void BspOptionsFormUpdate()
		{
			BspOptionsBlockSizeNumericUpDown.Enabled = BspOptionsBlockSizeCheckBox.Checked;
			BspOptionsSampleScaleNumericUpDown.Enabled = BspOptionsSampleScaleCheckBox.Checked;
		}

		private void BspOptionsSampleScaleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			BspOptionsFormUpdate();
		}
	}
}