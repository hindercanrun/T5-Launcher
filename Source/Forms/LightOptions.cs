using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Launcher
{
	internal class LightOptions : Form
	{
		private readonly IContainer components = null;
		private Button LightOptionsButtonCancel;
		private Button LightOptionsButtonOK;
		private GroupBox LightOptionsGroupBox;
		private GroupBox LightOptionsFastExtraGroupBox;
		private RadioButton LightOptionsExtraRadioButton;
		private RadioButton LightOptionsFastRadioButton;
		private NumericUpDown LightOptionsJitterNumericUpDown;
		private NumericUpDown LightOptionsMaxBouncesNumericUpDown;
		private NumericUpDown LightOptionsTracesNumericUpDown;
		private CheckBox LightOptionsJitterCheckBox;
		private CheckBox LightOptionsMaxBouncesCheckBox;
		private CheckBox LightOptionsTracesCheckBox;
		private CheckBox LightOptionsVerboseCheckBox;
		private CheckBox LightOptionsNoModelShadowsCheckBox;
		private Label LightOptionsExtraOptionsLabelText;
		private TextBox LightOptionsExtraOptionsTextBox;
		private NumericUpDown LightOptionsLGINumericUpDown;
		private CheckBox LightOptionsLGICheckBox;
		private CheckBox LightOptionsHDRCheckBox;

		internal LightOptions()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			LightOptionsButtonCancel = new Button();
			LightOptionsButtonOK = new Button();
			LightOptionsGroupBox = new GroupBox();
			LightOptionsLGINumericUpDown = new NumericUpDown();
			LightOptionsLGICheckBox = new CheckBox();
			LightOptionsHDRCheckBox = new CheckBox();
			LightOptionsExtraOptionsLabelText = new Label();
			LightOptionsExtraOptionsTextBox = new TextBox();
			LightOptionsFastExtraGroupBox = new GroupBox();
			LightOptionsExtraRadioButton = new RadioButton();
			LightOptionsFastRadioButton = new RadioButton();
			LightOptionsJitterNumericUpDown = new NumericUpDown();
			LightOptionsMaxBouncesNumericUpDown = new NumericUpDown();
			LightOptionsTracesNumericUpDown = new NumericUpDown();
			LightOptionsJitterCheckBox = new CheckBox();
			LightOptionsMaxBouncesCheckBox = new CheckBox();
			LightOptionsTracesCheckBox = new CheckBox();
			LightOptionsVerboseCheckBox = new CheckBox();
			LightOptionsNoModelShadowsCheckBox = new CheckBox();
			LightOptionsGroupBox.SuspendLayout();
			LightOptionsLGINumericUpDown.BeginInit();
			LightOptionsFastExtraGroupBox.SuspendLayout();
			LightOptionsJitterNumericUpDown.BeginInit();
			LightOptionsMaxBouncesNumericUpDown.BeginInit();
			LightOptionsTracesNumericUpDown.BeginInit();
			SuspendLayout();
			LightOptionsButtonCancel.DialogResult = DialogResult.Cancel;
			LightOptionsButtonCancel.Location = new Point(268, 198);
			LightOptionsButtonCancel.Name = "LightOptionsButtonCancel";
			LightOptionsButtonCancel.Size = new Size(75, 23);
			LightOptionsButtonCancel.TabIndex = 5;
			LightOptionsButtonCancel.Text = "Cancel";
			LightOptionsButtonCancel.UseVisualStyleBackColor = true;
			LightOptionsButtonCancel.Click += new EventHandler(LightOptionsButtonCancel_Click);
			LightOptionsButtonOK.Location = new Point(179, 198);
			LightOptionsButtonOK.Name = "LightOptionsButtonOK";
			LightOptionsButtonOK.Size = new Size(75, 23);
			LightOptionsButtonOK.TabIndex = 4;
			LightOptionsButtonOK.Text = "OK";
			LightOptionsButtonOK.UseVisualStyleBackColor = true;
			LightOptionsButtonOK.Click += new EventHandler(LightOptionsButtonOK_Click);
			LightOptionsGroupBox.Controls.Add(LightOptionsLGINumericUpDown);
			LightOptionsGroupBox.Controls.Add(LightOptionsLGICheckBox);
			LightOptionsGroupBox.Controls.Add(LightOptionsHDRCheckBox);
			LightOptionsGroupBox.Controls.Add(LightOptionsExtraOptionsLabelText);
			LightOptionsGroupBox.Controls.Add(LightOptionsExtraOptionsTextBox);
			LightOptionsGroupBox.Controls.Add(LightOptionsFastExtraGroupBox);
			LightOptionsGroupBox.Controls.Add(LightOptionsJitterNumericUpDown);
			LightOptionsGroupBox.Controls.Add(LightOptionsMaxBouncesNumericUpDown);
			LightOptionsGroupBox.Controls.Add(LightOptionsTracesNumericUpDown);
			LightOptionsGroupBox.Controls.Add(LightOptionsJitterCheckBox);
			LightOptionsGroupBox.Controls.Add(LightOptionsMaxBouncesCheckBox);
			LightOptionsGroupBox.Controls.Add(LightOptionsTracesCheckBox);
			LightOptionsGroupBox.Controls.Add(LightOptionsVerboseCheckBox);
			LightOptionsGroupBox.Controls.Add(LightOptionsNoModelShadowsCheckBox);
			LightOptionsGroupBox.Location = new Point(15, 15);
			LightOptionsGroupBox.Name = "LightOptionsGroupBox";
			LightOptionsGroupBox.Size = new Size(325, 177);
			LightOptionsGroupBox.TabIndex = 3;
			LightOptionsGroupBox.TabStop = false;
			LightOptionsGroupBox.Text = "Compile Light Options";
			LightOptionsLGINumericUpDown.DecimalPlaces = 2;
			LightOptionsLGINumericUpDown.Increment = new Decimal(new int[4]
			{
				1,
				0,
				0,
				131072
			});
			LightOptionsLGINumericUpDown.Location = new Point(260, 103);
			LightOptionsLGINumericUpDown.Maximum = new Decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			LightOptionsLGINumericUpDown.Name = "LightOptionsLGINumericUpDown";
			LightOptionsLGINumericUpDown.Size = new Size(59, 20);
			LightOptionsLGINumericUpDown.TabIndex = 24;
			LightOptionsLGICheckBox.AutoSize = true;
			LightOptionsLGICheckBox.FlatStyle = FlatStyle.Popup;
			LightOptionsLGICheckBox.Location = new Point(147, 103);
			LightOptionsLGICheckBox.Name = "LightOptionsLGICheckBox";
			LightOptionsLGICheckBox.Size = new Size(108, 17);
			LightOptionsLGICheckBox.TabIndex = 23;
			LightOptionsLGICheckBox.Text = "LightGrid Intensity";
			LightOptionsLGICheckBox.UseVisualStyleBackColor = true;
			LightOptionsLGICheckBox.CheckedChanged += new EventHandler(LightOptionsLGICheckBox_CheckedChanged);
			LightOptionsHDRCheckBox.AutoSize = true;
			LightOptionsHDRCheckBox.FlatStyle = FlatStyle.Popup;
			LightOptionsHDRCheckBox.Location = new Point(12, 103);
			LightOptionsHDRCheckBox.Name = "LightOptionsHDRCheckBox";
			LightOptionsHDRCheckBox.Size = new Size(88, 17);
			LightOptionsHDRCheckBox.TabIndex = 22;
			LightOptionsHDRCheckBox.Text = "HDR Lighting";
			LightOptionsHDRCheckBox.UseVisualStyleBackColor = true;
			LightOptionsExtraOptionsLabelText.AutoSize = true;
			LightOptionsExtraOptionsLabelText.Location = new Point(13, 135);
			LightOptionsExtraOptionsLabelText.Name = "LightOptionsExtraOptionsLabelText";
			LightOptionsExtraOptionsLabelText.Size = new Size(99, 13);
			LightOptionsExtraOptionsLabelText.TabIndex = 21;
			LightOptionsExtraOptionsLabelText.Text = "Extra Light Options:";
			LightOptionsExtraOptionsTextBox.Location = new Point(12, 151);
			LightOptionsExtraOptionsTextBox.Name = "LightOptionsExtraOptionsTextBox";
			LightOptionsExtraOptionsTextBox.Size = new Size(298, 20);
			LightOptionsExtraOptionsTextBox.TabIndex = 20;
			LightOptionsFastExtraGroupBox.Controls.Add(LightOptionsExtraRadioButton);
			LightOptionsFastExtraGroupBox.Controls.Add(LightOptionsFastRadioButton);
			LightOptionsFastExtraGroupBox.Location = new Point(12, 19);
			LightOptionsFastExtraGroupBox.Name = "LightOptionsFastExtraGroupBox";
			LightOptionsFastExtraGroupBox.Size = new Size(117, 32);
			LightOptionsFastExtraGroupBox.TabIndex = 9;
			LightOptionsFastExtraGroupBox.TabStop = false;
			LightOptionsExtraRadioButton.AutoSize = true;
			LightOptionsExtraRadioButton.Location = new Point(57, 9);
			LightOptionsExtraRadioButton.Name = "LightOptionsExtraRadioButton";
			LightOptionsExtraRadioButton.Size = new Size(49, 17);
			LightOptionsExtraRadioButton.TabIndex = 1;
			LightOptionsExtraRadioButton.Text = "Extra";
			LightOptionsExtraRadioButton.UseVisualStyleBackColor = true;
			LightOptionsFastRadioButton.AutoSize = true;
			LightOptionsFastRadioButton.Checked = true;
			LightOptionsFastRadioButton.Location = new Point(6, 9);
			LightOptionsFastRadioButton.Name = "LightOptionsFastRadioButton";
			LightOptionsFastRadioButton.Size = new Size(45, 17);
			LightOptionsFastRadioButton.TabIndex = 0;
			LightOptionsFastRadioButton.TabStop = true;
			LightOptionsFastRadioButton.Text = "Fast";
			LightOptionsFastRadioButton.UseVisualStyleBackColor = true;
			LightOptionsJitterNumericUpDown.DecimalPlaces = 3;
			LightOptionsJitterNumericUpDown.Increment = new Decimal(new int[4]
			{
				1,
				0,
				0,
				196608
			});
			LightOptionsJitterNumericUpDown.Location = new Point(251, 80);
			LightOptionsJitterNumericUpDown.Maximum = new Decimal(new int[4]
			{
				4,
				0,
				0,
				0
			});
			LightOptionsJitterNumericUpDown.Name = "LightOptionsJitterNumericUpDown";
			LightOptionsJitterNumericUpDown.Size = new Size(68, 20);
			LightOptionsJitterNumericUpDown.TabIndex = 8;
			LightOptionsMaxBouncesNumericUpDown.Location = new Point(251, 57);
			LightOptionsMaxBouncesNumericUpDown.Name = "LightOptionsMaxBouncesNumericUpDown";
			LightOptionsMaxBouncesNumericUpDown.Size = new Size(68, 20);
			LightOptionsMaxBouncesNumericUpDown.TabIndex = 7;
			LightOptionsTracesNumericUpDown.Location = new Point(251, 34);
			LightOptionsTracesNumericUpDown.Maximum = new Decimal(new int[4]
			{
				500,
				0,
				0,
				0
			});
			LightOptionsTracesNumericUpDown.Name = "LightOptionsTracesNumericUpDown";
			LightOptionsTracesNumericUpDown.Size = new Size(69, 20);
			LightOptionsTracesNumericUpDown.TabIndex = 6;
			LightOptionsJitterCheckBox.AutoSize = true;
			LightOptionsJitterCheckBox.FlatStyle = FlatStyle.Popup;
			LightOptionsJitterCheckBox.Location = new Point(147, 80);
			LightOptionsJitterCheckBox.Name = "LightOptionsJitterCheckBox";
			LightOptionsJitterCheckBox.Size = new Size(46, 17);
			LightOptionsJitterCheckBox.TabIndex = 5;
			LightOptionsJitterCheckBox.Text = "Jitter";
			LightOptionsJitterCheckBox.UseVisualStyleBackColor = true;
			LightOptionsJitterCheckBox.CheckedChanged += new EventHandler(LightOptionsJitterCheckBox_CheckedChanged);
			LightOptionsMaxBouncesCheckBox.AutoSize = true;
			LightOptionsMaxBouncesCheckBox.FlatStyle = FlatStyle.Popup;
			LightOptionsMaxBouncesCheckBox.Location = new Point(147, 57);
			LightOptionsMaxBouncesCheckBox.Name = "LightOptionsMaxBouncesCheckBox";
			LightOptionsMaxBouncesCheckBox.Size = new Size(89, 17);
			LightOptionsMaxBouncesCheckBox.TabIndex = 4;
			LightOptionsMaxBouncesCheckBox.Text = "Max Bounces";
			LightOptionsMaxBouncesCheckBox.UseVisualStyleBackColor = true;
			LightOptionsMaxBouncesCheckBox.CheckedChanged += new EventHandler(LightOptionsMaxBouncesCheckBox_CheckedChanged);
			LightOptionsTracesCheckBox.AutoSize = true;
			LightOptionsTracesCheckBox.FlatStyle = FlatStyle.Popup;
			LightOptionsTracesCheckBox.Location = new Point(147, 34);
			LightOptionsTracesCheckBox.Name = "LightOptionsTracesCheckBox";
			LightOptionsTracesCheckBox.Size = new Size(57, 17);
			LightOptionsTracesCheckBox.TabIndex = 3;
			LightOptionsTracesCheckBox.Text = "Traces";
			LightOptionsTracesCheckBox.UseVisualStyleBackColor = true;
			LightOptionsTracesCheckBox.CheckedChanged += new EventHandler(LightOptionsTracesCheckBox_CheckedChanged);
			LightOptionsVerboseCheckBox.AutoSize = true;
			LightOptionsVerboseCheckBox.FlatStyle = FlatStyle.Popup;
			LightOptionsVerboseCheckBox.Location = new Point(12, 80);
			LightOptionsVerboseCheckBox.Name = "LightOptionsVerboseCheckBox";
			LightOptionsVerboseCheckBox.Size = new Size(63, 17);
			LightOptionsVerboseCheckBox.TabIndex = 2;
			LightOptionsVerboseCheckBox.Text = "Verbose";
			LightOptionsVerboseCheckBox.UseVisualStyleBackColor = true;
			LightOptionsNoModelShadowsCheckBox.AutoSize = true;
			LightOptionsNoModelShadowsCheckBox.FlatStyle = FlatStyle.Popup;
			LightOptionsNoModelShadowsCheckBox.Location = new Point(12, 57);
			LightOptionsNoModelShadowsCheckBox.Name = "LightOptionsNoModelShadowsCheckBox";
			LightOptionsNoModelShadowsCheckBox.Size = new Size(117, 17);
			LightOptionsNoModelShadowsCheckBox.TabIndex = 1;
			LightOptionsNoModelShadowsCheckBox.Text = "No Model Shadows";
			LightOptionsNoModelShadowsCheckBox.UseVisualStyleBackColor = true;
			AutoScaleDimensions = new SizeF(6f, 13f);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(355, 233);
			ControlBox = false;
			Controls.Add(LightOptionsButtonCancel);
			Controls.Add(LightOptionsButtonOK);
			Controls.Add(LightOptionsGroupBox);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Advanced Users Options";
			Load += new EventHandler(LightOptions_Load);
			LightOptionsGroupBox.ResumeLayout(false);
			LightOptionsGroupBox.PerformLayout();
			LightOptionsLGINumericUpDown.EndInit();
			LightOptionsFastExtraGroupBox.ResumeLayout(false);
			LightOptionsFastExtraGroupBox.PerformLayout();
			LightOptionsJitterNumericUpDown.EndInit();
			LightOptionsMaxBouncesNumericUpDown.EndInit();
			LightOptionsTracesNumericUpDown.EndInit();
			ResumeLayout(false);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null) components.Dispose();
			base.Dispose(disposing);
		}

		private void LightOptions_Load(object sender, EventArgs e)
		{
			LightOptionsExtraRadioButton.Checked = Launcher.mapSettings.GetBoolean("lightoptions_extra");
			LightOptionsFastRadioButton.Checked = !LightOptionsExtraRadioButton.Checked;
			LightOptionsNoModelShadowsCheckBox.Checked = Launcher.mapSettings.GetBoolean("lightoptions_nomodelshadow");
			LightOptionsVerboseCheckBox.Checked = Launcher.mapSettings.GetBoolean("lightoptions_verbose");
			LightOptionsHDRCheckBox.Checked = Launcher.mapSettings.GetBoolean("lightoptions_hdr");
			LightOptionsTracesCheckBox.Checked = Launcher.mapSettings.GetBoolean("lightoptions_traces");
			LightOptionsMaxBouncesCheckBox.Checked = Launcher.mapSettings.GetBoolean("lightoptions_maxbounces");
			LightOptionsJitterCheckBox.Checked = Launcher.mapSettings.GetBoolean("lightoptions_jitter");
			LightOptionsLGICheckBox.Checked = Launcher.mapSettings.GetBoolean("lightoptions_lgi");

			Launcher.SetNumericUpDownValue(LightOptionsTracesNumericUpDown, Launcher.mapSettings.GetDecimal("lightoptions_traces_val"));
			Launcher.SetNumericUpDownValue(LightOptionsMaxBouncesNumericUpDown, Launcher.mapSettings.GetDecimal("lightoptions_maxbounces_val"));
			Launcher.SetNumericUpDownValue(LightOptionsJitterNumericUpDown, Launcher.mapSettings.GetDecimal("lightoptions_jitter_val"));
			Launcher.SetNumericUpDownValue(LightOptionsLGINumericUpDown, Launcher.mapSettings.GetDecimal("lightoptions_lgi_val"));
			
			LightOptionsExtraOptionsTextBox.Text = Launcher.mapSettings.GetString("lightoptions_extraoptions");

			// Update the form
			LightOptionsUpdate();
		}

		private void LightOptionsUpdate()
		{
			LightOptionsTracesNumericUpDown.Enabled = LightOptionsTracesCheckBox.Checked;
			LightOptionsMaxBouncesNumericUpDown.Enabled = LightOptionsMaxBouncesCheckBox.Checked;
			LightOptionsJitterNumericUpDown.Enabled = LightOptionsJitterCheckBox.Checked;
			LightOptionsLGINumericUpDown.Enabled = LightOptionsLGICheckBox.Checked;
		}

		private void LightOptionsButtonOK_Click(object sender, EventArgs e)
		{
			// Set the settings
			Launcher.mapSettings.SetBoolean("lightoptions_extra", LightOptionsExtraRadioButton.Checked);
			Launcher.mapSettings.SetBoolean("lightoptions_nomodelshadow", LightOptionsNoModelShadowsCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("lightoptions_verbose", LightOptionsVerboseCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("lightoptions_hdr", LightOptionsHDRCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("lightoptions_traces", LightOptionsTracesCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("lightoptions_maxbounces", LightOptionsMaxBouncesCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("lightoptions_jitter", LightOptionsJitterCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("lightoptions_lgi", LightOptionsLGICheckBox.Checked);
			Launcher.mapSettings.SetDecimal("lightoptions_traces_val", LightOptionsTracesNumericUpDown.Value);
			Launcher.mapSettings.SetDecimal("lightoptions_maxbounces_val", LightOptionsMaxBouncesNumericUpDown.Value);
			Launcher.mapSettings.SetDecimal("lightoptions_jitter_val", LightOptionsJitterNumericUpDown.Value);
			Launcher.mapSettings.SetDecimal("lightoptions_lgi_val", LightOptionsLGINumericUpDown.Value);
			Launcher.mapSettings.SetString("lightoptions_extraoptions", LightOptionsExtraOptionsTextBox.Text);

			// Now close the pop-up
			Close();
		}

		private void LightOptionsButtonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void LightOptionsJitterCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			LightOptionsUpdate();
		}

		private void LightOptionsMaxBouncesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			LightOptionsUpdate();
		}

		private void LightOptionsTracesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			LightOptionsUpdate();
		}

		private void LightOptionsLGICheckBox_CheckedChanged(object sender, EventArgs e)
		{
			LightOptionsUpdate();
		}
	}
}