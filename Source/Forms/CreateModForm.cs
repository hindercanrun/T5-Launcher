// Decompiled with JetBrains decompiler
// Type: LauncherCS.CreateModForm
// Assembly: Launcher, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BE2EDF30-BDA3-4FE0-9EFC-B0A1BE215D80
// Assembly location: D:\SteamLibrary\steamapps\common\Call of Duty Black Ops\bin\Launcher.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LauncherCS
{
  public class CreateModForm : Form
  {
    private IContainer components;
    private GroupBox NewModGroupBox;
    private Label NewModNameLabel;
    private TextBox NewModNameTextBox;
    private Button NewModCreateButton;

    public CreateModForm() => this.InitializeComponent();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateModForm));
			this.NewModGroupBox = new System.Windows.Forms.GroupBox();
			this.NewModCreateButton = new System.Windows.Forms.Button();
			this.NewModNameTextBox = new System.Windows.Forms.TextBox();
			this.NewModNameLabel = new System.Windows.Forms.Label();
			this.NewModGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// NewModGroupBox
			// 
			this.NewModGroupBox.Controls.Add(this.NewModCreateButton);
			this.NewModGroupBox.Controls.Add(this.NewModNameTextBox);
			this.NewModGroupBox.Controls.Add(this.NewModNameLabel);
			this.NewModGroupBox.Location = new System.Drawing.Point(12, 12);
			this.NewModGroupBox.Name = "NewModGroupBox";
			this.NewModGroupBox.Size = new System.Drawing.Size(260, 71);
			this.NewModGroupBox.TabIndex = 0;
			this.NewModGroupBox.TabStop = false;
			this.NewModGroupBox.Text = "New Mod";
			// 
			// NewModCreateButton
			// 
			this.NewModCreateButton.Location = new System.Drawing.Point(124, 42);
			this.NewModCreateButton.Name = "NewModCreateButton";
			this.NewModCreateButton.Size = new System.Drawing.Size(130, 23);
			this.NewModCreateButton.TabIndex = 2;
			this.NewModCreateButton.Text = "Create Mod";
			this.NewModCreateButton.UseVisualStyleBackColor = true;
			this.NewModCreateButton.Click += new System.EventHandler(this.NewModCreateButton_Click);
			// 
			// NewModNameTextBox
			// 
			this.NewModNameTextBox.Location = new System.Drawing.Point(106, 16);
			this.NewModNameTextBox.Name = "NewModNameTextBox";
			this.NewModNameTextBox.Size = new System.Drawing.Size(148, 20);
			this.NewModNameTextBox.TabIndex = 1;
			// 
			// NewModNameLabel
			// 
			this.NewModNameLabel.AutoSize = true;
			this.NewModNameLabel.Location = new System.Drawing.Point(6, 19);
			this.NewModNameLabel.Name = "NewModNameLabel";
			this.NewModNameLabel.Size = new System.Drawing.Size(94, 13);
			this.NewModNameLabel.TabIndex = 0;
			this.NewModNameLabel.Text = "Mod Folder Name:";
			// 
			// CreateModForm
			// 
			this.AcceptButton = this.NewModCreateButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 95);
			this.Controls.Add(this.NewModGroupBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreateModForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create a New Mod";
			this.NewModGroupBox.ResumeLayout(false);
			this.NewModGroupBox.PerformLayout();
			this.ResumeLayout(false);

    }

    private void NewModCreateButton_Click(object sender, EventArgs e)
    {
      if (this.NewModNameTextBox.Text == null || !(this.NewModNameTextBox.Text != ""))
      {
        int num1 = (int) MessageBox.Show("Mod folder name is invalid.", "Error");
      }
      else
      {
        string text = this.NewModNameTextBox.Text;
        string path = Path.Combine(Launcher.GetModsDirectory(), text);
        if (Directory.Exists(path))
        {
          int num2 = (int) MessageBox.Show("Mod folder already exists\nwith name: " + text, "Error");
          this.NewModNameTextBox.Text = "";
        }
        else
        {
          Directory.CreateDirectory(path);
          File.Create(path + "/mod.csv").Close();
          this.Close();
          Launcher.TheLauncherForm.SetLauncherTab(LauncherForm.LauncherTabType.Mods);
          Launcher.TheLauncherForm.SetModSelection(text, true);
        }
      }
    }
  }
}
