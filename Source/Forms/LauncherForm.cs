// Decompiled with JetBrains decompiler
// Type: LauncherCS.LauncherForm
// Assembly: Launcher, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BE2EDF30-BDA3-4FE0-9EFC-B0A1BE215D80
// Assembly location: D:\SteamLibrary\steamapps\common\Call of Duty Black Ops\bin\Launcher.exe

using Launcher.Properties;
using LauncherCS.Properties;
using Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace LauncherCS
{
  public class LauncherForm : Form
  {
    private ComboBox[] dvarComboBoxes = new ComboBox[0];
    private Hashtable processTable = new Hashtable();
    private ArrayList processList = new ArrayList();
    private Process consoleProcess;
    private DateTime consoleProcessStartTime;
    private string mapName;
    private string modName;
    private long consoleTicksWhenLastFocus = DateTime.Now.Ticks;
    private Mutex consoleMutex = new Mutex();
    private IContainer components;
    private SplitContainer LauncherSplitter;
    private TabControl LauncherTab;
    private TabPage LauncherTabCompileLevel;
    private TabPage LauncherTabModBuilder;
    private ListBox LauncherMapList;
    private Button LauncherButtonCancel;
    private ListBox LauncherProcessList;
    private GroupBox LauncherProcessGroupBox;
    private GroupBox LauncherRunGameModGroupBox;
    private ComboBox LauncherRunGameModComboBox;
    private Button LauncherRunGameButton;
    private GroupBox LauncherRunGameCustomCommandLineGroupBox;
    private TextBox LauncherRunGameCustomCommandLineTextBox;
    private GroupBox LauncherCompileLevelOptionsGroupBox;
    private CheckBox LauncherConnectPathsCheckBox;
    private CheckBox LauncherCompileLightsCheckBox;
    private CheckBox LauncherCompileBSPCheckBox;
    private Button LauncherCompileLightsButton;
    private Button LauncherCompileBSPButton;
    private CheckBox LauncherUseRunGameTypeOptionsCheckBox;
    private CheckBox LauncherRunMapAfterCompileCheckBox;
    private CheckBox LauncherBspInfoCheckBox;
    private CheckBox LauncherBuildFastFilesCheckBox;
    private Button LauncherCompileLevelButton;
    private Label LauncherCustomRunOptionsLabel;
    private TextBox LauncherCustomRunOptionsTextBox;
    private System.Windows.Forms.Timer LauncherTimer;
    internal GroupBox LauncherIwdFileGroupBox;
    internal GroupBox LauncherModGroupBox;
    internal ComboBox LauncherModComboBox;
    private TreeView LauncherIwdFileTree;
    private ComboBox LauncherModSpecificMapComboBox;
    private CheckBox LauncherModSpecificMapCheckBox;
    public RichTextBox LauncherConsole;
    private Button LauncherCreateMapButton;
    private Button LauncherDeleteMapButton;
    private FileSystemWatcher LauncherMapFilesSystemWatcher;
    private FileSystemWatcher LauncherModsDirectorySystemWatcher;
    private CheckBox LauncherGridCollectDotsCheckBox;
    private GroupBox LauncherGridFileGroupBox;
    private Button LauncherGridMakeNewButton;
    private Button LauncherGridEditExistingButton;
    private PictureBox LauncherIconBlops;
    private GroupBox LauncherGameGroupBox;
    private PictureBox LauncherIconMP;
    private PictureBox LauncherIconSP;
    private Button LauncherButtonMP;
    private Button LauncherButtonSP;
    private GroupBox LauncherApplicationsGroupBox;
    private PictureBox LauncherIconRadiant;
    private PictureBox LauncherIconEffectsEditor;
    private PictureBox LauncherIconConverter;
    private PictureBox LauncherIconAssetViewer;
    private PictureBox LauncherIconAssetManager;
    private Button LauncherButtonAssetViewer;
    private Button LauncherButtonRunConverter;
    private Button LauncherButtonAssetManager;
    private Button LauncherButtonEffectsEd;
    private Button LauncherButtonRadiant;
    private TextBox LauncherProcessTimeElapsedTextBox;
    private Button LauncherClearConsoleButton;
    private TextBox LauncherProcessTextBox;
    private GroupBox LauncherRunGameGroupBox;
    private GroupBox LauncherRunGameCustomCommandLineMPGroupBox;
    private TextBox LauncherRunGameCustomCommandLineMPTextBox;
    private CheckBox LauncherRunGameCustomCommandLineCheckBox;
    private CheckBox LauncherRunGameCustomCommandLineMPCheckBox;
    private TextBox LauncherRunGameCommandLineTextBox;
    private Label LauncherRunGameMapNameLabel;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem LauncherfileToolStripMenuItem;
    private ToolStripMenuItem LauncherexitToolStripMenuItem;
    private ToolStripMenuItem LauncherdocsToolStripMenuItem;
    private ToolStripMenuItem LaunchertoolsToolStripMenuItem;
    private ToolStripMenuItem LauncherhelpToolStripMenuItem;
    private ToolStripMenuItem LauncherwikiToolStripMenuItem;
    private Panel panel1;
    private ToolTip LauncherRadiantToolTip;
    private ToolTip LauncherEffectsEdToolTip;
    private ToolTip LauncherAssetViewerToolTip;
    private ToolTip LauncherConverterToolTip;
    private ToolTip LauncherAssetManagerToolTip;
    private CheckBox LauncherRunGameLogfileBox;
    private CheckBox LauncherRunGameDeveloperBox;
    private TextBox LauncherRunGameMapNameTextBox;
    private CheckBox LauncherGameLogfileBox;
    private CheckBox LauncherGameDeveloperBox;
    private ToolStripMenuItem gameDirToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolTip SaveConsoleToolTip;
    private Button LauncherSaveConsoleButton;
    private ToolStripMenuItem mayaExporterToolStripMenuItem;
    private Button LauncherScrollBottomConsoleButton;
    private ToolTip LauncherScrollBottomConsoleToolTip;
    private ComboBox LauncherMapTypeList;
    private Label LauncherMapType;
    private TabPage LauncherTabExplore;
    private GroupBox LauncherExploreGroupBox;
    private GroupBox LauncherExploreRawDirGroupBox;
    private Button LauncherExploreRawDirWeaponsButton;
    private Button LauncherExploreRawDirVisionButton;
    private Button LauncherExploreRawDirLocsButton;
    private Button LauncherExploreRawDirAnimTreesButton;
    private Button LauncherExploreRawDirSoundAliasesButton;
    private Button LauncherExploreRawDirCSCButton;
    private Button LauncherExploreRawDirGSCButton;
    private GroupBox LauncherExploreDevDirGroupBox;
    private Button LauncherExploreDevDirRawButton;
    private Button LauncherExploreDevDirModelExportButton;
    private Button LauncherExploreDevDirTextureAssetsButton;
    private Button LauncherExploreDevDirSrcDataButton;
    private Button LauncherExploreDevDirMapSrcButton;
    private Button LauncherExploreDevDirBinButton;
    private Button LauncherExploreDevDirZoneSourceButton;
    private GroupBox LauncherExploreBlopsDirGroupBox;
    private Button LauncherExploreBlopsDirConfigsButton;
    private Button LauncherExploreBlopsDirModsButton;
    private Button LauncherExploreBlopsDirGameButton;
    private Button LauncherExploreRawDirMPButton;
    private GroupBox LauncherExploreRawMapsDirGroupBox;
    private Button LauncherExploreRawGSCDirMPGametypesButton;
    private Button LauncherExploreRawGSCDirMPFXButton;
    private Button LauncherExploreRawGSCDirMPArtButton;
    private Button LauncherExploreRawGSCDirMPButton;
    private Button LauncherExploreRawGSCDirSPVoiceButton;
    private Button LauncherExploreRawGSCDirSPGametypesButton;
    private Button LauncherExploreRawGSCDirSPFXButton;
    private Button LauncherExploreRawGSCDirSPArtButton;
    private Button LauncherExploreRawGSCDirSPButton;
    private GroupBox LauncherModZoneSourceGroupBox;
    private Button LauncherEditZoneSourceButton;
    private GroupBox LauncherModBuildGroupBox;
    internal Button LauncherModBuildButton;
    internal CheckBox LauncherModBuildSoundsCheckBox;
    private Button LauncherModZoneSourceMissingAssetsButton;
    internal CheckBox LauncherModVerboseCheckBox;
    internal CheckBox LauncherModBuildFastFilesCheckBox;
    internal CheckBox LauncherModBuildIwdFileCheckBox;
    private Button LauncherModZoneSourceCSVButton;
    private GroupBox LauncherModFolderGroupBox;
    private Button LauncherModFolderViewButton;
    private TextBox LauncherModBuildLinkerOptionsTextBox;
    private Label LauncherModBuildLinkerOptionsLabel;
    private Button LauncherExploreRawDirFXButton;
    private PictureBox LauncherErrorsPictureBox;
    private Label LauncherErrorsLabel;
    private NumericUpDown LauncherErrorsNumericUpDown;
    private Label LauncherErrorsCounter;
    private Label LauncherWarningsCounter;
    private NumericUpDown LauncherWarningsNumericUpDown;
    private PictureBox LauncherWarningsPictureBox;
    private Label LauncherWarningsLabel;
    private ToolStripMenuItem mayaPluginSetupToolStripMenuItem;
    private ContextMenuStrip LauncherMapListContextMenuStrip;
    private ToolStripMenuItem runToolStripMenuItem;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem deleteToolStripMenuItem;
    private ToolStripMenuItem renameToolStripMenuItem;
    private CheckBox LauncherCompileReflectionsCheckBox;
    private ToolStripMenuItem newModToolStripMenuItem;
    private ToolStripMenuItem LaunchernewMapToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem exporterTutorialToolStripMenuItem;
    private int LauncherMapList_WaitingForMouseUp = -1;
		private Label label;
		private int LauncherMapListContextMenu_Map = -1;

    public LauncherForm()
    {
      this.InitializeComponent();
      this.LauncherMapTypeList.SelectedIndex = 0;
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    protected override void WndProc(ref Message m)
    {
      if (m.Msg == NativeMethods.WM_SHOWME)
      {
        if (this.WindowState == FormWindowState.Minimized)
          this.WindowState = FormWindowState.Normal;
        bool topMost = this.TopMost;
        this.TopMost = true;
        this.TopMost = topMost;
      }
      base.WndProc(ref m);
    }

    public void SetMapSelection(string mapName, bool updateList = false)
    {
      if (updateList)
        this.UpdateMapList();
      int stringExact = this.LauncherMapList.FindStringExact(mapName);
      if (stringExact == -1)
        return;
      this.LauncherMapList.SelectedIndex = stringExact;
    }

    public void SetModSelection(string modName, bool updateList = false)
    {
      if (updateList)
        this.UpdateModList();
      int stringExact = this.LauncherModComboBox.FindStringExact(modName);
      if (stringExact == -1)
        return;
      this.LauncherModComboBox.SelectedIndex = stringExact;
    }

    public void SetTabToSingleplayer() => this.LauncherMapTypeList.SelectedIndex = 0;

    public void SetTabToMultiplayer() => this.LauncherMapTypeList.SelectedIndex = 1;

    public void SetLauncherTab(LauncherForm.LauncherTabType tab)
    {
      switch (tab)
      {
        case LauncherForm.LauncherTabType.Mods:
          this.LauncherTab.SelectedTab = this.LauncherTabModBuilder;
          break;
        case LauncherForm.LauncherTabType.Maps:
          this.LauncherTab.SelectedTab = this.LauncherTabCompileLevel;
          break;
        case LauncherForm.LauncherTabType.Explore:
          this.LauncherTab.SelectedTab = this.LauncherTabExplore;
          break;
      }
    }

    private void AddFilesToTreeView(string Directory, TreeNodeCollection tree, bool firstTime)
    {
      TreeNode treeNode1 = (TreeNode) null;
      if (!firstTime)
      {
        treeNode1 = tree.Add(new DirectoryInfo(Directory).Name);
        tree = treeNode1.Nodes;
      }
      foreach (DirectoryInfo directory in new DirectoryInfo(Directory).GetDirectories())
      {
        if (!directory.Name.StartsWith("."))
          this.AddFilesToTreeView(Path.Combine(Directory, directory.Name), tree, false);
      }
      foreach (FileInfo file in new DirectoryInfo(Directory).GetFiles())
      {
        if (!file.Name.StartsWith(".") && file.Extension.ToLower() != ".ff" && file.Extension.ToLower() != ".iwd" && file.Extension.ToLower() != ".files")
        {
          TreeNode treeNode2 = tree.Add(file.Name);
          treeNode2.ForeColor = Color.Blue;
          treeNode2.Tag = (object) file;
        }
      }
      if (treeNode1 == null)
        return;
      if (treeNode1.Nodes.Count != 0)
        treeNode1.ExpandAll();
      else
        treeNode1.Remove();
    }

    private void BuildGridDelegate(int r_vc_makelog)
    {
      this.EnableControls(false);
      string path2 = this.mapName + ".grid";
      LauncherCS.Launcher.CopyFile(Path.Combine(LauncherCS.Launcher.GetMapSourceDirectory(), path2), Path.Combine(LauncherCS.Launcher.GetRawMapsDirectory(), Path.Combine(this.IsMP() ? "mp" : "", path2)));
      LauncherForm.ProcessFinishedDelegate nextStage = new LauncherForm.ProcessFinishedDelegate(this.BuildGridFinishedDelegate);
      string gameApplication = LauncherCS.Launcher.GetGameApplication(this.IsMP());
      string str1 = "raw";
      string str2 = "+set developer 1 +set logfile 2 + set r_vc_makelog " + r_vc_makelog.ToString() + "+set r_vc_showlog 16 +set r_cullxmodel " + (LauncherCS.Launcher.mapSettings.GetBoolean("compile_collectdots") ? "0" : "1") + " +set thereisacow 1960 +set com_introplayed 1 +set fs_game " + str1;
      string processOptions = (!(str1 == "raw") ? str2 + " +set fs_usedevdir 1" : str2 + " +set fs_useFastFile 0 +set fs_usedevdir 1") + "+devmap " + this.mapName;
      this.LaunchProcessHelper(true, nextStage, (Process) null, gameApplication, processOptions);
    }

    private void BuildGridFinishedDelegate(Process lastProcess)
    {
      string path2 = this.mapName + ".grid";
      LauncherCS.Launcher.MoveFile(Path.Combine(LauncherCS.Launcher.GetRawMapsDirectory(), Path.Combine(this.IsMP() ? "mp" : "", path2)), Path.Combine(LauncherCS.Launcher.GetMapSourceDirectory(), path2));
      this.EnableControls(true);
    }

    private void LauncherModSpecificMapCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      this.LauncherModSpecificMapComboBox.Enabled = this.LauncherModSpecificMapCheckBox.Checked;
    }

    private bool CheckZoneSourceFiles()
    {
      if (File.Exists(LauncherCS.Launcher.GetZoneSourceFile(this.mapName)))
        return true;
      if (MessageBox.Show("There are no zone files for " + this.mapName + ". Would you like to create them?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
        return false;
      LauncherCS.Launcher.CreateZoneSourceFiles(this.mapName);
      return true;
    }

    private void CompileLevel()
    {
      this.EnableControls(false);
      this.UpdateMapSettings();
      this.CompileLevelBspDelegate((Process) null);
    }

    private void CompileLevelBspDelegate(Process lastProcess)
    {
      LauncherForm.ProcessFinishedDelegate nextStage = new LauncherForm.ProcessFinishedDelegate(this.CompileLevelVisDelegate);
      LauncherCS.Launcher.DeleteFile(this.GetSourceBsp() + ".lin", false);
      string[] strArray = new string[9]
      {
        "-platform pc ",
        "-loadFrom \"",
        this.GetSourceBsp(),
        ".map\"",
        " ",
        LauncherCS.Launcher.GetBspOptions(),
        " \"",
        this.GetDestinationBsp(),
        "\""
      };
      this.CompileLevelHelper("compile_bsp", nextStage, lastProcess, "cod2map", string.Concat(strArray));
    }

    private void CompileLevelLightsDelegate(Process lastProcess)
    {
      string[] strArray = new string[5]
      {
        "-platform pc ",
        LauncherCS.Launcher.GetLightOptions(),
        "\"",
        this.GetDestinationBsp(),
        "\""
      };
      this.CompileLevelHelper("compile_lights", new LauncherForm.ProcessFinishedDelegate(this.CompileLevelCleanupDelegate), lastProcess, "cod2rad", string.Concat(strArray));
    }

    private void CompileLevelBspInfoDelegate(Process lastProcess)
    {
      this.CompileLevelHelper("compile_bspinfo", new LauncherForm.ProcessFinishedDelegate(this.CompileLevelFastFilesDelegate), lastProcess, "cod2map", "-info \"" + this.GetDestinationBsp() + "\"");
    }

    private void CompileLevelBuildFastFile(
      string name,
      Process lastProcess,
      LauncherForm.ProcessFinishedDelegate nextStage)
    {
      string str = LauncherCS.Launcher.mapSettings.GetBoolean("compile_modenabled") ? "-moddir " + LauncherCS.Launcher.mapSettings.GetString("compile_modname") + " " : "";
      this.CompileLevelHelper("compile_buildffs", nextStage, lastProcess, "linker_pc", "-nopause -language " + LauncherCS.Launcher.GetLanguage() + " " + str + name + (File.Exists(LauncherCS.Launcher.GetLoadZone(this.mapName)) ? " " + LauncherCS.Launcher.GetLoadZone(this.mapName) : ""));
    }

    private void CompileLevelCleanupDelegate(Process lastProcess)
    {
      string[] strArray = new string[5]
      {
        ".lin",
        ".map",
        ".d3dpoly",
        ".vclog",
        ".grid"
      };
      foreach (string str in strArray)
        LauncherCS.Launcher.DeleteFile(this.GetDestinationBsp() + str, false);
      this.CompileLevelPathsDelegate(lastProcess);
    }

    private void CompileLevelFastFilesDelegate(Process lastProcess)
    {
      if (!this.CheckZoneSourceFiles())
        this.CompileLevelRunGameDelegate(lastProcess);
      else if (this.IsMP())
        this.CompileLevelBuildFastFile(this.mapName, lastProcess, new LauncherForm.ProcessFinishedDelegate(this.CompileLevelFastFilesLocalizedDelegate));
      else
        this.CompileLevelBuildFastFile(this.mapName, lastProcess, new LauncherForm.ProcessFinishedDelegate(this.CompileLevelMoveFastFilesDelegate));
    }

    private void CompileLevelFastFilesLocalizedDelegate(Process lastProcess)
    {
      this.CompileLevelBuildFastFile("localized_" + this.mapName, lastProcess, new LauncherForm.ProcessFinishedDelegate(this.CompileLevelMoveFastFilesDelegate));
    }

    private void CompileLevelFinished(Process lastProcess) => this.EnableControls(true);

    private void CompileLevelHelper(
      string mapSettingsOption,
      LauncherForm.ProcessFinishedDelegate nextStage,
      Process lastProcess,
      string processName,
      string processOptions,
      string workingDirectory)
    {
      this.LaunchProcessHelper(LauncherCS.Launcher.mapSettings.GetBoolean(mapSettingsOption), nextStage, lastProcess, processName, processOptions, workingDirectory);
    }

    private void CompileLevelHelper(
      string mapSettingsOption,
      LauncherForm.ProcessFinishedDelegate nextStage,
      Process lastProcess,
      string processName,
      string processOptions)
    {
      this.LaunchProcessHelper(LauncherCS.Launcher.mapSettings.GetBoolean(mapSettingsOption), nextStage, lastProcess, processName, processOptions);
    }

    private void CompileLevelMoveFastFilesDelegate(Process lastProcess)
    {
      string zoneDirectory = LauncherCS.Launcher.GetZoneDirectory();
      string path1 = LauncherCS.Launcher.mapSettings.GetBoolean("compile_modenabled") ? LauncherCS.Launcher.GetModDirectory(LauncherCS.Launcher.mapSettings.GetString("compile_modname")) : Path.Combine(LauncherCS.Launcher.GetUsermapsDirectory(), this.mapName);
      string path2_1 = this.mapName + ".ff";
      string path2_2 = this.mapName + "_load.ff";
      LauncherCS.Launcher.MoveFile(Path.Combine(zoneDirectory, path2_1), Path.Combine(path1, path2_1));
      LauncherCS.Launcher.MoveFile(Path.Combine(zoneDirectory, "localized_" + path2_1), Path.Combine(path1, "localized_" + path2_1));
      LauncherCS.Launcher.MoveFile(Path.Combine(zoneDirectory, path2_2), Path.Combine(path1, path2_2));
      LauncherCS.Launcher.Publish();
      this.CompileLevelRunGameDelegate(lastProcess);
    }

    private void CompileLevelPathsDelegate(Process lastProcess)
    {
      this.CompileLevelHelper("compile_paths", new LauncherForm.ProcessFinishedDelegate(this.CompileLevelReflectionsDelegate), lastProcess, LauncherCS.Launcher.GetGameTool(this.IsMP()), "allowdupe +set developer 1 +set logfile 2 +set thereisacow 1960 +set com_introplayed 1 +set r_fullscreen 0 +set fs_usedevdir 1 +set g_connectpaths 2 +set useFastFile 0 +devmap " + this.mapName);
    }

    private void CompileLevelReflectionsDelegate(Process lastProcess)
    {
      this.CompileLevelHelper("compile_reflections", new LauncherForm.ProcessFinishedDelegate(this.CompileLevelBspInfoDelegate), lastProcess, LauncherCS.Launcher.GetGameTool(this.IsMP()), "allowdupe +set developer 1 +set logfile 2 +set thereisacow 1960 +set com_introplayed 1 +set r_fullscreen 0 +set fs_usedevdir 1 +set ui_autoContinue 1 +set r_reflectionProbeGenerateExit 1 +set useFastFile 0 +set r_fullscreen 0 +set r_reflectionProbeRegenerateAll 1 +set r_zFeather 1 +set r_reflectionProbeGenerate 1 +devmap " + this.mapName);
    }

    private void CompileLevelRunGameDelegate(Process lastProcess)
    {
      string str = LauncherCS.Launcher.mapSettings.GetBoolean("compile_modenabled") ? "\"mods/" + LauncherCS.Launcher.mapSettings.GetString("compile_modname") + "\"" : "raw";
      LauncherForm.ProcessFinishedDelegate nextStage = new LauncherForm.ProcessFinishedDelegate(this.CompileLevelFinished);
      Process lastProcess1 = lastProcess;
      string gameApplication = LauncherCS.Launcher.GetGameApplication(this.IsMP());
      string[] strArray1 = new string[7];
      strArray1[0] = "+set useFastFile 1 +set fs_usedevdir 1 +set logfile 2 +set thereisacow 1960 +set com_introplayed 1 ";
      string[] strArray2 = strArray1;
      strArray2[1] = this.IsMP() ? "+set sv_pure 0 +set g_gametype tdm " : "";
      strArray2[2] = "+devmap ";
      strArray2[3] = this.mapName;
      strArray2[4] = " +set fs_game ";
      strArray2[5] = str;
      strArray2[6] = " ";
      this.CompileLevelHelper("compile_runafter", nextStage, lastProcess1, gameApplication, string.Concat(strArray2));
    }

    private void CompileLevelVisDelegate(Process lastProcess)
    {
      this.CompileLevelHelper("compile_vis", new LauncherForm.ProcessFinishedDelegate(this.CompileLevelLightsDelegate), lastProcess, "cod2map", "-vis -platform pc \"" + this.GetDestinationBsp() + "\"");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (this.components != null)
          this.components.Dispose();
        if (this.consoleMutex != null)
          this.consoleMutex.Close();
      }
      base.Dispose(disposing);
    }

    private void EnableControls(bool enabled) => this.EnableControls(enabled, (TabPage) null);

    private void EnableControls(bool enabled, TabPage onlyForTabPage)
    {
      TabPage[] tabPageArray = new TabPage[2]
      {
        this.LauncherTabCompileLevel,
        this.LauncherTabModBuilder
      };
      foreach (TabPage tabPage in tabPageArray)
      {
        if (onlyForTabPage == null || onlyForTabPage == tabPage)
        {
          foreach (Control control in (ArrangedElementCollection) tabPage.Controls)
            control.Enabled = enabled;
        }
      }
      if (enabled)
        this.LauncherModSpecificMapComboBox.Enabled = this.LauncherModSpecificMapCheckBox.Checked;
      this.LauncherMapTypeList.Enabled = true;
      this.LauncherCreateMapButton.Enabled = true;
    }

    private void EnableMapList()
    {
      bool enabled = this.LauncherMapList.SelectedItem != null;
      this.LauncherCompileLevelButton.Enabled = enabled;
      this.EnableControls(enabled, this.LauncherTabCompileLevel);
      this.LauncherMapList.Enabled = true;
    }

    private void ExploreOpenDir(string dir)
    {
      if (Directory.Exists(dir))
      {
        Process.Start(dir);
      }
      else
      {
        int num = (int) MessageBox.Show("Could not find directory:\n" + dir, "Error");
      }
    }

    private void exporterTutorialToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start(LauncherCS.Launcher.GetRootDirectory() + "/bin/maya/tutorial/trashcan_metal/Treyarch_trashcan_metal_directions01sm.pdf");
    }

    public int FindLauncherConsoleText(string text, int start, int end)
    {
      int launcherConsoleText = -1;
      if (text.Length > 0 && start >= 0 && end >= 0)
      {
        int num = this.LauncherConsole.Find(text, start, end, RichTextBoxFinds.None);
        if (num >= 0)
          launcherConsoleText = num;
      }
      return launcherConsoleText;
    }

    private string FormatDVar(ComboBox cb)
    {
      string str1 = "";
      if (cb.SelectedItem != null && cb.SelectedIndex > 0)
        str1 = cb.SelectedItem.ToString();
      else if (cb.Items[0].ToString() != cb.Text)
        str1 = cb.Text;
      string str2 = str1.Trim();
      if (str2 == "")
        return "";
      return "+set " + cb.Tag + " " + str2 + " ";
    }

    private string FormatDvars()
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (ComboBox dvarComboBox in this.dvarComboBoxes)
        stringBuilder.Append(this.FormatDVar(dvarComboBox));
      return stringBuilder.ToString();
    }

    private void gameDirToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start(LauncherCS.Launcher.GetRootDirectory());
    }

    private string GetDestinationBsp()
    {
      return LauncherCS.Launcher.GetRawMapsDirectory() + (this.IsMP() ? "mp\\" : "") + this.mapName;
    }

    private string GetFS_Game(bool allowRaw = false)
    {
      if (this.LauncherRunGameModComboBox.SelectedIndex > 1)
        return "\"mods/" + this.LauncherRunGameModComboBox.Text + "\"";
      return this.LauncherRunGameModComboBox.SelectedIndex > 0 ? (this.LauncherModSpecificMapComboBox.Text.Length <= 0 || !this.LauncherModSpecificMapCheckBox.Checked ? "" : "\"mods/" + this.LauncherModSpecificMapComboBox.Text + "\"") : (allowRaw ? "raw" : "");
    }

    private string GetGameOptions()
    {
      string fsGame = this.GetFS_Game();
      return fsGame.Length != 0 ? "+set fs_game " + fsGame + " " + this.FormatDvars() : this.FormatDvars();
    }

    private string GetSourceBsp() => LauncherCS.Launcher.GetMapSourceDirectory() + this.mapName;

    private void HashTableToTreeView(Hashtable ht, TreeNodeCollection tree)
    {
      if (tree == null)
        return;
      foreach (TreeNode node in tree)
      {
        if (ht.Contains((object) node.FullPath))
        {
          node.Checked = true;
          this.RecursiveCheckNodesUp(node, true);
        }
        this.HashTableToTreeView(ht, node.Nodes);
      }
    }

    private void InitializeComponent()
    {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
			this.LauncherConsole = new System.Windows.Forms.RichTextBox();
			this.LauncherSplitter = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.LauncherRunGameCustomCommandLineGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherRunGameCustomCommandLineCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherRunGameCustomCommandLineTextBox = new System.Windows.Forms.TextBox();
			this.LauncherRunGameGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherRunGameMapNameTextBox = new System.Windows.Forms.TextBox();
			this.LauncherRunGameLogfileBox = new System.Windows.Forms.CheckBox();
			this.LauncherRunGameDeveloperBox = new System.Windows.Forms.CheckBox();
			this.LauncherRunGameMapNameLabel = new System.Windows.Forms.Label();
			this.LauncherRunGameButton = new System.Windows.Forms.Button();
			this.LauncherRunGameCustomCommandLineMPGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherRunGameCustomCommandLineMPCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherRunGameCustomCommandLineMPTextBox = new System.Windows.Forms.TextBox();
			this.LauncherRunGameModGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherRunGameModComboBox = new System.Windows.Forms.ComboBox();
			this.LauncherRunGameCommandLineTextBox = new System.Windows.Forms.TextBox();
			this.LauncherIconBlops = new System.Windows.Forms.PictureBox();
			this.LauncherGameGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherGameLogfileBox = new System.Windows.Forms.CheckBox();
			this.LauncherGameDeveloperBox = new System.Windows.Forms.CheckBox();
			this.LauncherIconMP = new System.Windows.Forms.PictureBox();
			this.LauncherIconSP = new System.Windows.Forms.PictureBox();
			this.LauncherButtonMP = new System.Windows.Forms.Button();
			this.LauncherButtonSP = new System.Windows.Forms.Button();
			this.LauncherTab = new System.Windows.Forms.TabControl();
			this.LauncherTabModBuilder = new System.Windows.Forms.TabPage();
			this.LauncherIwdFileGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherIwdFileTree = new System.Windows.Forms.TreeView();
			this.LauncherModGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherModFolderGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherModFolderViewButton = new System.Windows.Forms.Button();
			this.LauncherModBuildGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherModBuildLinkerOptionsTextBox = new System.Windows.Forms.TextBox();
			this.LauncherModBuildLinkerOptionsLabel = new System.Windows.Forms.Label();
			this.LauncherModVerboseCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherModBuildFastFilesCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherModBuildIwdFileCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherModBuildButton = new System.Windows.Forms.Button();
			this.LauncherModBuildSoundsCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherModZoneSourceGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherModZoneSourceCSVButton = new System.Windows.Forms.Button();
			this.LauncherModZoneSourceMissingAssetsButton = new System.Windows.Forms.Button();
			this.LauncherEditZoneSourceButton = new System.Windows.Forms.Button();
			this.LauncherModComboBox = new System.Windows.Forms.ComboBox();
			this.LauncherTabCompileLevel = new System.Windows.Forms.TabPage();
			this.LauncherMapType = new System.Windows.Forms.Label();
			this.LauncherMapTypeList = new System.Windows.Forms.ComboBox();
			this.LauncherCreateMapButton = new System.Windows.Forms.Button();
			this.LauncherDeleteMapButton = new System.Windows.Forms.Button();
			this.LauncherCompileLevelOptionsGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherCompileReflectionsCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherGridFileGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherGridEditExistingButton = new System.Windows.Forms.Button();
			this.LauncherGridMakeNewButton = new System.Windows.Forms.Button();
			this.LauncherGridCollectDotsCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherModSpecificMapComboBox = new System.Windows.Forms.ComboBox();
			this.LauncherModSpecificMapCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherCustomRunOptionsLabel = new System.Windows.Forms.Label();
			this.LauncherCustomRunOptionsTextBox = new System.Windows.Forms.TextBox();
			this.label = new System.Windows.Forms.Label();
			this.LauncherCompileLevelButton = new System.Windows.Forms.Button();
			this.LauncherCompileLightsButton = new System.Windows.Forms.Button();
			this.LauncherCompileBSPButton = new System.Windows.Forms.Button();
			this.LauncherUseRunGameTypeOptionsCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherRunMapAfterCompileCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherBspInfoCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherBuildFastFilesCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherConnectPathsCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherCompileLightsCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherCompileBSPCheckBox = new System.Windows.Forms.CheckBox();
			this.LauncherMapList = new System.Windows.Forms.ListBox();
			this.LauncherTabExplore = new System.Windows.Forms.TabPage();
			this.LauncherExploreGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherExploreRawMapsDirGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherExploreRawGSCDirMPGametypesButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawGSCDirMPFXButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawGSCDirMPArtButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawGSCDirMPButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawGSCDirSPVoiceButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawGSCDirSPGametypesButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawGSCDirSPFXButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawGSCDirSPArtButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawGSCDirSPButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawDirGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherExploreRawDirFXButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawDirMPButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawDirWeaponsButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawDirVisionButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawDirLocsButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawDirAnimTreesButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawDirSoundAliasesButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawDirCSCButton = new System.Windows.Forms.Button();
			this.LauncherExploreRawDirGSCButton = new System.Windows.Forms.Button();
			this.LauncherExploreDevDirGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherExploreDevDirRawButton = new System.Windows.Forms.Button();
			this.LauncherExploreDevDirModelExportButton = new System.Windows.Forms.Button();
			this.LauncherExploreDevDirTextureAssetsButton = new System.Windows.Forms.Button();
			this.LauncherExploreDevDirSrcDataButton = new System.Windows.Forms.Button();
			this.LauncherExploreDevDirMapSrcButton = new System.Windows.Forms.Button();
			this.LauncherExploreDevDirBinButton = new System.Windows.Forms.Button();
			this.LauncherExploreDevDirZoneSourceButton = new System.Windows.Forms.Button();
			this.LauncherExploreBlopsDirGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherExploreBlopsDirConfigsButton = new System.Windows.Forms.Button();
			this.LauncherExploreBlopsDirModsButton = new System.Windows.Forms.Button();
			this.LauncherExploreBlopsDirGameButton = new System.Windows.Forms.Button();
			this.LauncherApplicationsGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherIconRadiant = new System.Windows.Forms.PictureBox();
			this.LauncherIconEffectsEditor = new System.Windows.Forms.PictureBox();
			this.LauncherIconConverter = new System.Windows.Forms.PictureBox();
			this.LauncherIconAssetViewer = new System.Windows.Forms.PictureBox();
			this.LauncherIconAssetManager = new System.Windows.Forms.PictureBox();
			this.LauncherButtonAssetViewer = new System.Windows.Forms.Button();
			this.LauncherButtonRunConverter = new System.Windows.Forms.Button();
			this.LauncherButtonAssetManager = new System.Windows.Forms.Button();
			this.LauncherButtonEffectsEd = new System.Windows.Forms.Button();
			this.LauncherButtonRadiant = new System.Windows.Forms.Button();
			this.LauncherWarningsCounter = new System.Windows.Forms.Label();
			this.LauncherWarningsNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.LauncherWarningsPictureBox = new System.Windows.Forms.PictureBox();
			this.LauncherWarningsLabel = new System.Windows.Forms.Label();
			this.LauncherErrorsCounter = new System.Windows.Forms.Label();
			this.LauncherErrorsNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.LauncherErrorsPictureBox = new System.Windows.Forms.PictureBox();
			this.LauncherErrorsLabel = new System.Windows.Forms.Label();
			this.LauncherScrollBottomConsoleButton = new System.Windows.Forms.Button();
			this.LauncherSaveConsoleButton = new System.Windows.Forms.Button();
			this.LauncherProcessTimeElapsedTextBox = new System.Windows.Forms.TextBox();
			this.LauncherClearConsoleButton = new System.Windows.Forms.Button();
			this.LauncherProcessGroupBox = new System.Windows.Forms.GroupBox();
			this.LauncherButtonCancel = new System.Windows.Forms.Button();
			this.LauncherProcessList = new System.Windows.Forms.ListBox();
			this.LauncherProcessTextBox = new System.Windows.Forms.TextBox();
			this.LauncherTimer = new System.Windows.Forms.Timer(this.components);
			this.LauncherMapFilesSystemWatcher = new System.IO.FileSystemWatcher();
			this.LauncherModsDirectorySystemWatcher = new System.IO.FileSystemWatcher();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.LauncherfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LaunchernewMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.gameDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.LauncherexitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LauncherdocsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mayaExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exporterTutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LaunchertoolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mayaPluginSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LauncherhelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LauncherwikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LauncherRadiantToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.LauncherEffectsEdToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.LauncherAssetManagerToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.LauncherAssetViewerToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.LauncherConverterToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.SaveConsoleToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.LauncherScrollBottomConsoleToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.LauncherMapListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LauncherSplitter.Panel1.SuspendLayout();
			this.LauncherSplitter.Panel2.SuspendLayout();
			this.LauncherSplitter.SuspendLayout();
			this.panel1.SuspendLayout();
			this.LauncherRunGameCustomCommandLineGroupBox.SuspendLayout();
			this.LauncherRunGameGroupBox.SuspendLayout();
			this.LauncherRunGameCustomCommandLineMPGroupBox.SuspendLayout();
			this.LauncherRunGameModGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconBlops)).BeginInit();
			this.LauncherGameGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconMP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconSP)).BeginInit();
			this.LauncherTab.SuspendLayout();
			this.LauncherTabModBuilder.SuspendLayout();
			this.LauncherIwdFileGroupBox.SuspendLayout();
			this.LauncherModGroupBox.SuspendLayout();
			this.LauncherModFolderGroupBox.SuspendLayout();
			this.LauncherModBuildGroupBox.SuspendLayout();
			this.LauncherModZoneSourceGroupBox.SuspendLayout();
			this.LauncherTabCompileLevel.SuspendLayout();
			this.LauncherCompileLevelOptionsGroupBox.SuspendLayout();
			this.LauncherGridFileGroupBox.SuspendLayout();
			this.LauncherTabExplore.SuspendLayout();
			this.LauncherExploreGroupBox.SuspendLayout();
			this.LauncherExploreRawMapsDirGroupBox.SuspendLayout();
			this.LauncherExploreRawDirGroupBox.SuspendLayout();
			this.LauncherExploreDevDirGroupBox.SuspendLayout();
			this.LauncherExploreBlopsDirGroupBox.SuspendLayout();
			this.LauncherApplicationsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconRadiant)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconEffectsEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconConverter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconAssetViewer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconAssetManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherWarningsNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherWarningsPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherErrorsNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherErrorsPictureBox)).BeginInit();
			this.LauncherProcessGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LauncherMapFilesSystemWatcher)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherModsDirectorySystemWatcher)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.LauncherMapListContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// LauncherConsole
			// 
			this.LauncherConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherConsole.BackColor = System.Drawing.SystemColors.InfoText;
			this.LauncherConsole.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LauncherConsole.ForeColor = System.Drawing.SystemColors.ScrollBar;
			this.LauncherConsole.Location = new System.Drawing.Point(149, 3);
			this.LauncherConsole.Name = "LauncherConsole";
			this.LauncherConsole.ReadOnly = true;
			this.LauncherConsole.Size = new System.Drawing.Size(802, 242);
			this.LauncherConsole.TabIndex = 0;
			this.LauncherConsole.Text = "";
			this.LauncherConsole.WordWrap = false;
			// 
			// LauncherSplitter
			// 
			this.LauncherSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherSplitter.BackColor = System.Drawing.SystemColors.Control;
			this.LauncherSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.LauncherSplitter.Location = new System.Drawing.Point(12, 23);
			this.LauncherSplitter.Name = "LauncherSplitter";
			this.LauncherSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// LauncherSplitter.Panel1
			// 
			this.LauncherSplitter.Panel1.Controls.Add(this.panel1);
			this.LauncherSplitter.Panel1.Controls.Add(this.LauncherRunGameCommandLineTextBox);
			this.LauncherSplitter.Panel1.Controls.Add(this.LauncherIconBlops);
			this.LauncherSplitter.Panel1.Controls.Add(this.LauncherGameGroupBox);
			this.LauncherSplitter.Panel1.Controls.Add(this.LauncherTab);
			this.LauncherSplitter.Panel1.Controls.Add(this.LauncherApplicationsGroupBox);
			this.LauncherSplitter.Panel1MinSize = 380;
			// 
			// LauncherSplitter.Panel2
			// 
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherWarningsCounter);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherWarningsNumericUpDown);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherWarningsPictureBox);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherWarningsLabel);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherErrorsCounter);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherErrorsNumericUpDown);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherErrorsPictureBox);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherErrorsLabel);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherScrollBottomConsoleButton);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherSaveConsoleButton);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherProcessTimeElapsedTextBox);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherConsole);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherClearConsoleButton);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherProcessGroupBox);
			this.LauncherSplitter.Panel2.Controls.Add(this.LauncherProcessTextBox);
			this.LauncherSplitter.Panel2MinSize = 100;
			this.LauncherSplitter.Size = new System.Drawing.Size(954, 653);
			this.LauncherSplitter.SplitterDistance = 380;
			this.LauncherSplitter.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.LauncherRunGameCustomCommandLineGroupBox);
			this.panel1.Controls.Add(this.LauncherRunGameGroupBox);
			this.panel1.Controls.Add(this.LauncherRunGameCustomCommandLineMPGroupBox);
			this.panel1.Controls.Add(this.LauncherRunGameModGroupBox);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(804, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(150, 380);
			this.panel1.TabIndex = 10;
			// 
			// LauncherRunGameCustomCommandLineGroupBox
			// 
			this.LauncherRunGameCustomCommandLineGroupBox.Controls.Add(this.LauncherRunGameCustomCommandLineCheckBox);
			this.LauncherRunGameCustomCommandLineGroupBox.Controls.Add(this.LauncherRunGameCustomCommandLineTextBox);
			this.LauncherRunGameCustomCommandLineGroupBox.Location = new System.Drawing.Point(3, 49);
			this.LauncherRunGameCustomCommandLineGroupBox.Name = "LauncherRunGameCustomCommandLineGroupBox";
			this.LauncherRunGameCustomCommandLineGroupBox.Size = new System.Drawing.Size(145, 63);
			this.LauncherRunGameCustomCommandLineGroupBox.TabIndex = 4;
			this.LauncherRunGameCustomCommandLineGroupBox.TabStop = false;
			this.LauncherRunGameCustomCommandLineGroupBox.Text = "Singleplayer Options";
			// 
			// LauncherRunGameCustomCommandLineCheckBox
			// 
			this.LauncherRunGameCustomCommandLineCheckBox.AutoSize = true;
			this.LauncherRunGameCustomCommandLineCheckBox.Location = new System.Drawing.Point(6, 15);
			this.LauncherRunGameCustomCommandLineCheckBox.Name = "LauncherRunGameCustomCommandLineCheckBox";
			this.LauncherRunGameCustomCommandLineCheckBox.Size = new System.Drawing.Size(65, 17);
			this.LauncherRunGameCustomCommandLineCheckBox.TabIndex = 1;
			this.LauncherRunGameCustomCommandLineCheckBox.Text = "Enabled";
			this.LauncherRunGameCustomCommandLineCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherRunGameCustomCommandLineTextBox
			// 
			this.LauncherRunGameCustomCommandLineTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherRunGameCustomCommandLineTextBox.Location = new System.Drawing.Point(6, 37);
			this.LauncherRunGameCustomCommandLineTextBox.Name = "LauncherRunGameCustomCommandLineTextBox";
			this.LauncherRunGameCustomCommandLineTextBox.Size = new System.Drawing.Size(136, 20);
			this.LauncherRunGameCustomCommandLineTextBox.TabIndex = 0;
			this.LauncherRunGameCustomCommandLineTextBox.TextChanged += new System.EventHandler(this.LauncherRunGameCustomCommandLineTextBox_TextChanged);
			this.LauncherRunGameCustomCommandLineTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.LauncherRunGameCustomCommandLineTextBox_Validating);
			// 
			// LauncherRunGameGroupBox
			// 
			this.LauncherRunGameGroupBox.Controls.Add(this.LauncherRunGameMapNameTextBox);
			this.LauncherRunGameGroupBox.Controls.Add(this.LauncherRunGameLogfileBox);
			this.LauncherRunGameGroupBox.Controls.Add(this.LauncherRunGameDeveloperBox);
			this.LauncherRunGameGroupBox.Controls.Add(this.LauncherRunGameMapNameLabel);
			this.LauncherRunGameGroupBox.Controls.Add(this.LauncherRunGameButton);
			this.LauncherRunGameGroupBox.Location = new System.Drawing.Point(3, 181);
			this.LauncherRunGameGroupBox.Name = "LauncherRunGameGroupBox";
			this.LauncherRunGameGroupBox.Size = new System.Drawing.Size(145, 93);
			this.LauncherRunGameGroupBox.TabIndex = 11;
			this.LauncherRunGameGroupBox.TabStop = false;
			this.LauncherRunGameGroupBox.Text = "Run";
			// 
			// LauncherRunGameMapNameTextBox
			// 
			this.LauncherRunGameMapNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherRunGameMapNameTextBox.Location = new System.Drawing.Point(32, 19);
			this.LauncherRunGameMapNameTextBox.Multiline = true;
			this.LauncherRunGameMapNameTextBox.Name = "LauncherRunGameMapNameTextBox";
			this.LauncherRunGameMapNameTextBox.ReadOnly = true;
			this.LauncherRunGameMapNameTextBox.Size = new System.Drawing.Size(110, 19);
			this.LauncherRunGameMapNameTextBox.TabIndex = 18;
			// 
			// LauncherRunGameLogfileBox
			// 
			this.LauncherRunGameLogfileBox.AutoSize = true;
			this.LauncherRunGameLogfileBox.Location = new System.Drawing.Point(82, 44);
			this.LauncherRunGameLogfileBox.Name = "LauncherRunGameLogfileBox";
			this.LauncherRunGameLogfileBox.Size = new System.Drawing.Size(57, 17);
			this.LauncherRunGameLogfileBox.TabIndex = 17;
			this.LauncherRunGameLogfileBox.Text = "Logfile";
			this.LauncherRunGameLogfileBox.UseVisualStyleBackColor = true;
			// 
			// LauncherRunGameDeveloperBox
			// 
			this.LauncherRunGameDeveloperBox.AutoSize = true;
			this.LauncherRunGameDeveloperBox.Location = new System.Drawing.Point(6, 44);
			this.LauncherRunGameDeveloperBox.Name = "LauncherRunGameDeveloperBox";
			this.LauncherRunGameDeveloperBox.Size = new System.Drawing.Size(75, 17);
			this.LauncherRunGameDeveloperBox.TabIndex = 16;
			this.LauncherRunGameDeveloperBox.Text = "Developer";
			this.LauncherRunGameDeveloperBox.UseVisualStyleBackColor = true;
			// 
			// LauncherRunGameMapNameLabel
			// 
			this.LauncherRunGameMapNameLabel.AutoSize = true;
			this.LauncherRunGameMapNameLabel.Location = new System.Drawing.Point(3, 25);
			this.LauncherRunGameMapNameLabel.Name = "LauncherRunGameMapNameLabel";
			this.LauncherRunGameMapNameLabel.Size = new System.Drawing.Size(28, 13);
			this.LauncherRunGameMapNameLabel.TabIndex = 15;
			this.LauncherRunGameMapNameLabel.Text = "Map";
			// 
			// LauncherRunGameButton
			// 
			this.LauncherRunGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherRunGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.LauncherRunGameButton.Location = new System.Drawing.Point(6, 63);
			this.LauncherRunGameButton.Name = "LauncherRunGameButton";
			this.LauncherRunGameButton.Size = new System.Drawing.Size(133, 24);
			this.LauncherRunGameButton.TabIndex = 2;
			this.LauncherRunGameButton.Text = "Run";
			this.LauncherRunGameButton.UseVisualStyleBackColor = true;
			this.LauncherRunGameButton.Click += new System.EventHandler(this.LauncherRunGameButton_Click);
			// 
			// LauncherRunGameCustomCommandLineMPGroupBox
			// 
			this.LauncherRunGameCustomCommandLineMPGroupBox.Controls.Add(this.LauncherRunGameCustomCommandLineMPCheckBox);
			this.LauncherRunGameCustomCommandLineMPGroupBox.Controls.Add(this.LauncherRunGameCustomCommandLineMPTextBox);
			this.LauncherRunGameCustomCommandLineMPGroupBox.Location = new System.Drawing.Point(3, 118);
			this.LauncherRunGameCustomCommandLineMPGroupBox.Name = "LauncherRunGameCustomCommandLineMPGroupBox";
			this.LauncherRunGameCustomCommandLineMPGroupBox.Size = new System.Drawing.Size(145, 63);
			this.LauncherRunGameCustomCommandLineMPGroupBox.TabIndex = 5;
			this.LauncherRunGameCustomCommandLineMPGroupBox.TabStop = false;
			this.LauncherRunGameCustomCommandLineMPGroupBox.Text = "Multiplayer Options";
			// 
			// LauncherRunGameCustomCommandLineMPCheckBox
			// 
			this.LauncherRunGameCustomCommandLineMPCheckBox.AutoSize = true;
			this.LauncherRunGameCustomCommandLineMPCheckBox.Location = new System.Drawing.Point(6, 14);
			this.LauncherRunGameCustomCommandLineMPCheckBox.Name = "LauncherRunGameCustomCommandLineMPCheckBox";
			this.LauncherRunGameCustomCommandLineMPCheckBox.Size = new System.Drawing.Size(65, 17);
			this.LauncherRunGameCustomCommandLineMPCheckBox.TabIndex = 2;
			this.LauncherRunGameCustomCommandLineMPCheckBox.Text = "Enabled";
			this.LauncherRunGameCustomCommandLineMPCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherRunGameCustomCommandLineMPTextBox
			// 
			this.LauncherRunGameCustomCommandLineMPTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherRunGameCustomCommandLineMPTextBox.Location = new System.Drawing.Point(6, 37);
			this.LauncherRunGameCustomCommandLineMPTextBox.Name = "LauncherRunGameCustomCommandLineMPTextBox";
			this.LauncherRunGameCustomCommandLineMPTextBox.Size = new System.Drawing.Size(136, 20);
			this.LauncherRunGameCustomCommandLineMPTextBox.TabIndex = 0;
			// 
			// LauncherRunGameModGroupBox
			// 
			this.LauncherRunGameModGroupBox.Controls.Add(this.LauncherRunGameModComboBox);
			this.LauncherRunGameModGroupBox.Location = new System.Drawing.Point(3, 4);
			this.LauncherRunGameModGroupBox.Name = "LauncherRunGameModGroupBox";
			this.LauncherRunGameModGroupBox.Size = new System.Drawing.Size(145, 42);
			this.LauncherRunGameModGroupBox.TabIndex = 1;
			this.LauncherRunGameModGroupBox.TabStop = false;
			this.LauncherRunGameModGroupBox.Text = "Mod";
			// 
			// LauncherRunGameModComboBox
			// 
			this.LauncherRunGameModComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherRunGameModComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LauncherRunGameModComboBox.FormattingEnabled = true;
			this.LauncherRunGameModComboBox.Location = new System.Drawing.Point(6, 18);
			this.LauncherRunGameModComboBox.Name = "LauncherRunGameModComboBox";
			this.LauncherRunGameModComboBox.Size = new System.Drawing.Size(136, 21);
			this.LauncherRunGameModComboBox.TabIndex = 0;
			// 
			// LauncherRunGameCommandLineTextBox
			// 
			this.LauncherRunGameCommandLineTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherRunGameCommandLineTextBox.Location = new System.Drawing.Point(147, 357);
			this.LauncherRunGameCommandLineTextBox.Name = "LauncherRunGameCommandLineTextBox";
			this.LauncherRunGameCommandLineTextBox.ReadOnly = true;
			this.LauncherRunGameCommandLineTextBox.Size = new System.Drawing.Size(648, 20);
			this.LauncherRunGameCommandLineTextBox.TabIndex = 14;
			// 
			// LauncherIconBlops
			// 
			this.LauncherIconBlops.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconBlops.BackgroundImage")));
			this.LauncherIconBlops.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LauncherIconBlops.Location = new System.Drawing.Point(5, 3);
			this.LauncherIconBlops.Name = "LauncherIconBlops";
			this.LauncherIconBlops.Size = new System.Drawing.Size(138, 108);
			this.LauncherIconBlops.TabIndex = 9;
			this.LauncherIconBlops.TabStop = false;
			// 
			// LauncherGameGroupBox
			// 
			this.LauncherGameGroupBox.Controls.Add(this.LauncherGameLogfileBox);
			this.LauncherGameGroupBox.Controls.Add(this.LauncherGameDeveloperBox);
			this.LauncherGameGroupBox.Controls.Add(this.LauncherIconMP);
			this.LauncherGameGroupBox.Controls.Add(this.LauncherIconSP);
			this.LauncherGameGroupBox.Controls.Add(this.LauncherButtonMP);
			this.LauncherGameGroupBox.Controls.Add(this.LauncherButtonSP);
			this.LauncherGameGroupBox.Location = new System.Drawing.Point(4, 115);
			this.LauncherGameGroupBox.Name = "LauncherGameGroupBox";
			this.LauncherGameGroupBox.Size = new System.Drawing.Size(139, 65);
			this.LauncherGameGroupBox.TabIndex = 10;
			this.LauncherGameGroupBox.TabStop = false;
			this.LauncherGameGroupBox.Text = "Game";
			// 
			// LauncherGameLogfileBox
			// 
			this.LauncherGameLogfileBox.AutoSize = true;
			this.LauncherGameLogfileBox.Location = new System.Drawing.Point(81, 16);
			this.LauncherGameLogfileBox.Name = "LauncherGameLogfileBox";
			this.LauncherGameLogfileBox.Size = new System.Drawing.Size(57, 17);
			this.LauncherGameLogfileBox.TabIndex = 22;
			this.LauncherGameLogfileBox.Text = "Logfile";
			this.LauncherGameLogfileBox.UseVisualStyleBackColor = true;
			// 
			// LauncherGameDeveloperBox
			// 
			this.LauncherGameDeveloperBox.AutoSize = true;
			this.LauncherGameDeveloperBox.Location = new System.Drawing.Point(5, 16);
			this.LauncherGameDeveloperBox.Name = "LauncherGameDeveloperBox";
			this.LauncherGameDeveloperBox.Size = new System.Drawing.Size(75, 17);
			this.LauncherGameDeveloperBox.TabIndex = 21;
			this.LauncherGameDeveloperBox.Text = "Developer";
			this.LauncherGameDeveloperBox.UseVisualStyleBackColor = true;
			// 
			// LauncherIconMP
			// 
			this.LauncherIconMP.BackgroundImage = global::LauncherCS.Properties.Resources.icon_mp;
			this.LauncherIconMP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.LauncherIconMP.Enabled = false;
			this.LauncherIconMP.Location = new System.Drawing.Point(85, 39);
			this.LauncherIconMP.Name = "LauncherIconMP";
			this.LauncherIconMP.Size = new System.Drawing.Size(16, 16);
			this.LauncherIconMP.TabIndex = 20;
			this.LauncherIconMP.TabStop = false;
			// 
			// LauncherIconSP
			// 
			this.LauncherIconSP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconSP.BackgroundImage")));
			this.LauncherIconSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.LauncherIconSP.Enabled = false;
			this.LauncherIconSP.Location = new System.Drawing.Point(24, 39);
			this.LauncherIconSP.Name = "LauncherIconSP";
			this.LauncherIconSP.Size = new System.Drawing.Size(16, 16);
			this.LauncherIconSP.TabIndex = 11;
			this.LauncherIconSP.TabStop = false;
			// 
			// LauncherButtonMP
			// 
			this.LauncherButtonMP.Location = new System.Drawing.Point(71, 35);
			this.LauncherButtonMP.Name = "LauncherButtonMP";
			this.LauncherButtonMP.Size = new System.Drawing.Size(64, 24);
			this.LauncherButtonMP.TabIndex = 1;
			this.LauncherButtonMP.Text = "     MP";
			this.LauncherButtonMP.UseVisualStyleBackColor = true;
			this.LauncherButtonMP.Click += new System.EventHandler(this.LauncherButtonMP_Click);
			// 
			// LauncherButtonSP
			// 
			this.LauncherButtonSP.Location = new System.Drawing.Point(8, 35);
			this.LauncherButtonSP.Name = "LauncherButtonSP";
			this.LauncherButtonSP.Size = new System.Drawing.Size(64, 24);
			this.LauncherButtonSP.TabIndex = 0;
			this.LauncherButtonSP.Text = "     SP";
			this.LauncherButtonSP.UseVisualStyleBackColor = true;
			this.LauncherButtonSP.Click += new System.EventHandler(this.LauncherButtonSP_Click);
			// 
			// LauncherTab
			// 
			this.LauncherTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherTab.Controls.Add(this.LauncherTabModBuilder);
			this.LauncherTab.Controls.Add(this.LauncherTabCompileLevel);
			this.LauncherTab.Controls.Add(this.LauncherTabExplore);
			this.LauncherTab.Location = new System.Drawing.Point(149, 1);
			this.LauncherTab.Name = "LauncherTab";
			this.LauncherTab.SelectedIndex = 0;
			this.LauncherTab.Size = new System.Drawing.Size(649, 350);
			this.LauncherTab.TabIndex = 0;
			// 
			// LauncherTabModBuilder
			// 
			this.LauncherTabModBuilder.Controls.Add(this.LauncherIwdFileGroupBox);
			this.LauncherTabModBuilder.Controls.Add(this.LauncherModGroupBox);
			this.LauncherTabModBuilder.Location = new System.Drawing.Point(4, 22);
			this.LauncherTabModBuilder.Name = "LauncherTabModBuilder";
			this.LauncherTabModBuilder.Padding = new System.Windows.Forms.Padding(3);
			this.LauncherTabModBuilder.Size = new System.Drawing.Size(641, 324);
			this.LauncherTabModBuilder.TabIndex = 1;
			this.LauncherTabModBuilder.Text = "Mod Builder";
			this.LauncherTabModBuilder.UseVisualStyleBackColor = true;
			// 
			// LauncherIwdFileGroupBox
			// 
			this.LauncherIwdFileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherIwdFileGroupBox.Controls.Add(this.LauncherIwdFileTree);
			this.LauncherIwdFileGroupBox.Location = new System.Drawing.Point(298, 6);
			this.LauncherIwdFileGroupBox.Name = "LauncherIwdFileGroupBox";
			this.LauncherIwdFileGroupBox.Size = new System.Drawing.Size(340, 312);
			this.LauncherIwdFileGroupBox.TabIndex = 2;
			this.LauncherIwdFileGroupBox.TabStop = false;
			this.LauncherIwdFileGroupBox.Text = "IWD File List";
			// 
			// LauncherIwdFileTree
			// 
			this.LauncherIwdFileTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherIwdFileTree.CheckBoxes = true;
			this.LauncherIwdFileTree.Indent = 15;
			this.LauncherIwdFileTree.Location = new System.Drawing.Point(6, 19);
			this.LauncherIwdFileTree.Name = "LauncherIwdFileTree";
			this.LauncherIwdFileTree.Size = new System.Drawing.Size(328, 287);
			this.LauncherIwdFileTree.TabIndex = 1;
			this.LauncherIwdFileTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.LauncherIwdFileTree_AfterCheck);
			this.LauncherIwdFileTree.DoubleClick += new System.EventHandler(this.LauncherIwdFileTree_DoubleClick);
			// 
			// LauncherModGroupBox
			// 
			this.LauncherModGroupBox.Controls.Add(this.LauncherModFolderGroupBox);
			this.LauncherModGroupBox.Controls.Add(this.LauncherModBuildGroupBox);
			this.LauncherModGroupBox.Controls.Add(this.LauncherModZoneSourceGroupBox);
			this.LauncherModGroupBox.Controls.Add(this.LauncherModComboBox);
			this.LauncherModGroupBox.Location = new System.Drawing.Point(6, 6);
			this.LauncherModGroupBox.Name = "LauncherModGroupBox";
			this.LauncherModGroupBox.Size = new System.Drawing.Size(286, 312);
			this.LauncherModGroupBox.TabIndex = 4;
			this.LauncherModGroupBox.TabStop = false;
			this.LauncherModGroupBox.Text = "Mod";
			// 
			// LauncherModFolderGroupBox
			// 
			this.LauncherModFolderGroupBox.Controls.Add(this.LauncherModFolderViewButton);
			this.LauncherModFolderGroupBox.Location = new System.Drawing.Point(7, 262);
			this.LauncherModFolderGroupBox.Name = "LauncherModFolderGroupBox";
			this.LauncherModFolderGroupBox.Size = new System.Drawing.Size(273, 44);
			this.LauncherModFolderGroupBox.TabIndex = 24;
			this.LauncherModFolderGroupBox.TabStop = false;
			this.LauncherModFolderGroupBox.Text = "Mod Folder";
			// 
			// LauncherModFolderViewButton
			// 
			this.LauncherModFolderViewButton.Location = new System.Drawing.Point(6, 16);
			this.LauncherModFolderViewButton.Name = "LauncherModFolderViewButton";
			this.LauncherModFolderViewButton.Size = new System.Drawing.Size(262, 24);
			this.LauncherModFolderViewButton.TabIndex = 0;
			this.LauncherModFolderViewButton.Text = "View Mod";
			this.LauncherModFolderViewButton.UseVisualStyleBackColor = true;
			this.LauncherModFolderViewButton.Click += new System.EventHandler(this.LauncherModFolderViewButton_Click);
			// 
			// LauncherModBuildGroupBox
			// 
			this.LauncherModBuildGroupBox.Controls.Add(this.LauncherModBuildLinkerOptionsTextBox);
			this.LauncherModBuildGroupBox.Controls.Add(this.LauncherModBuildLinkerOptionsLabel);
			this.LauncherModBuildGroupBox.Controls.Add(this.LauncherModVerboseCheckBox);
			this.LauncherModBuildGroupBox.Controls.Add(this.LauncherModBuildFastFilesCheckBox);
			this.LauncherModBuildGroupBox.Controls.Add(this.LauncherModBuildIwdFileCheckBox);
			this.LauncherModBuildGroupBox.Controls.Add(this.LauncherModBuildButton);
			this.LauncherModBuildGroupBox.Controls.Add(this.LauncherModBuildSoundsCheckBox);
			this.LauncherModBuildGroupBox.Location = new System.Drawing.Point(7, 136);
			this.LauncherModBuildGroupBox.Name = "LauncherModBuildGroupBox";
			this.LauncherModBuildGroupBox.Size = new System.Drawing.Size(273, 120);
			this.LauncherModBuildGroupBox.TabIndex = 23;
			this.LauncherModBuildGroupBox.TabStop = false;
			this.LauncherModBuildGroupBox.Text = "Build Mod";
			// 
			// LauncherModBuildLinkerOptionsTextBox
			// 
			this.LauncherModBuildLinkerOptionsTextBox.Location = new System.Drawing.Point(128, 61);
			this.LauncherModBuildLinkerOptionsTextBox.Name = "LauncherModBuildLinkerOptionsTextBox";
			this.LauncherModBuildLinkerOptionsTextBox.Size = new System.Drawing.Size(137, 20);
			this.LauncherModBuildLinkerOptionsTextBox.TabIndex = 24;
			// 
			// LauncherModBuildLinkerOptionsLabel
			// 
			this.LauncherModBuildLinkerOptionsLabel.AutoSize = true;
			this.LauncherModBuildLinkerOptionsLabel.Location = new System.Drawing.Point(6, 64);
			this.LauncherModBuildLinkerOptionsLabel.Name = "LauncherModBuildLinkerOptionsLabel";
			this.LauncherModBuildLinkerOptionsLabel.Size = new System.Drawing.Size(116, 13);
			this.LauncherModBuildLinkerOptionsLabel.TabIndex = 23;
			this.LauncherModBuildLinkerOptionsLabel.Text = "Custom Linker Options:";
			// 
			// LauncherModVerboseCheckBox
			// 
			this.LauncherModVerboseCheckBox.AutoSize = true;
			this.LauncherModVerboseCheckBox.Location = new System.Drawing.Point(6, 42);
			this.LauncherModVerboseCheckBox.Name = "LauncherModVerboseCheckBox";
			this.LauncherModVerboseCheckBox.Size = new System.Drawing.Size(195, 17);
			this.LauncherModVerboseCheckBox.TabIndex = 22;
			this.LauncherModVerboseCheckBox.Text = "Verbose (More Detailed Information)";
			this.LauncherModVerboseCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherModBuildFastFilesCheckBox
			// 
			this.LauncherModBuildFastFilesCheckBox.AutoSize = true;
			this.LauncherModBuildFastFilesCheckBox.Location = new System.Drawing.Point(6, 19);
			this.LauncherModBuildFastFilesCheckBox.Name = "LauncherModBuildFastFilesCheckBox";
			this.LauncherModBuildFastFilesCheckBox.Size = new System.Drawing.Size(85, 17);
			this.LauncherModBuildFastFilesCheckBox.TabIndex = 21;
			this.LauncherModBuildFastFilesCheckBox.Text = "Link FastFile";
			this.LauncherModBuildFastFilesCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherModBuildIwdFileCheckBox
			// 
			this.LauncherModBuildIwdFileCheckBox.AutoSize = true;
			this.LauncherModBuildIwdFileCheckBox.Location = new System.Drawing.Point(97, 19);
			this.LauncherModBuildIwdFileCheckBox.Name = "LauncherModBuildIwdFileCheckBox";
			this.LauncherModBuildIwdFileCheckBox.Size = new System.Drawing.Size(74, 17);
			this.LauncherModBuildIwdFileCheckBox.TabIndex = 20;
			this.LauncherModBuildIwdFileCheckBox.Text = "Build IWD";
			this.LauncherModBuildIwdFileCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherModBuildButton
			// 
			this.LauncherModBuildButton.Location = new System.Drawing.Point(6, 88);
			this.LauncherModBuildButton.Name = "LauncherModBuildButton";
			this.LauncherModBuildButton.Size = new System.Drawing.Size(262, 24);
			this.LauncherModBuildButton.TabIndex = 19;
			this.LauncherModBuildButton.Text = "Build Mod";
			this.LauncherModBuildButton.UseVisualStyleBackColor = true;
			this.LauncherModBuildButton.Click += new System.EventHandler(this.LauncherModBuildButton_Click);
			// 
			// LauncherModBuildSoundsCheckBox
			// 
			this.LauncherModBuildSoundsCheckBox.AutoSize = true;
			this.LauncherModBuildSoundsCheckBox.Enabled = false;
			this.LauncherModBuildSoundsCheckBox.Location = new System.Drawing.Point(177, 19);
			this.LauncherModBuildSoundsCheckBox.Name = "LauncherModBuildSoundsCheckBox";
			this.LauncherModBuildSoundsCheckBox.Size = new System.Drawing.Size(88, 17);
			this.LauncherModBuildSoundsCheckBox.TabIndex = 18;
			this.LauncherModBuildSoundsCheckBox.Text = "Build Sounds";
			this.LauncherModBuildSoundsCheckBox.UseVisualStyleBackColor = true;
			this.LauncherModBuildSoundsCheckBox.Visible = false;
			// 
			// LauncherModZoneSourceGroupBox
			// 
			this.LauncherModZoneSourceGroupBox.Controls.Add(this.LauncherModZoneSourceCSVButton);
			this.LauncherModZoneSourceGroupBox.Controls.Add(this.LauncherModZoneSourceMissingAssetsButton);
			this.LauncherModZoneSourceGroupBox.Controls.Add(this.LauncherEditZoneSourceButton);
			this.LauncherModZoneSourceGroupBox.Location = new System.Drawing.Point(6, 47);
			this.LauncherModZoneSourceGroupBox.Name = "LauncherModZoneSourceGroupBox";
			this.LauncherModZoneSourceGroupBox.Size = new System.Drawing.Size(274, 83);
			this.LauncherModZoneSourceGroupBox.TabIndex = 22;
			this.LauncherModZoneSourceGroupBox.TabStop = false;
			this.LauncherModZoneSourceGroupBox.Text = "FastFile Zone Source";
			// 
			// LauncherModZoneSourceCSVButton
			// 
			this.LauncherModZoneSourceCSVButton.Location = new System.Drawing.Point(138, 50);
			this.LauncherModZoneSourceCSVButton.Name = "LauncherModZoneSourceCSVButton";
			this.LauncherModZoneSourceCSVButton.Size = new System.Drawing.Size(130, 23);
			this.LauncherModZoneSourceCSVButton.TabIndex = 24;
			this.LauncherModZoneSourceCSVButton.Text = "Zone Source";
			this.LauncherModZoneSourceCSVButton.UseVisualStyleBackColor = true;
			this.LauncherModZoneSourceCSVButton.Click += new System.EventHandler(this.LauncherModZoneSourceCSVButton_Click);
			// 
			// LauncherModZoneSourceMissingAssetsButton
			// 
			this.LauncherModZoneSourceMissingAssetsButton.Location = new System.Drawing.Point(6, 50);
			this.LauncherModZoneSourceMissingAssetsButton.Name = "LauncherModZoneSourceMissingAssetsButton";
			this.LauncherModZoneSourceMissingAssetsButton.Size = new System.Drawing.Size(130, 23);
			this.LauncherModZoneSourceMissingAssetsButton.TabIndex = 23;
			this.LauncherModZoneSourceMissingAssetsButton.Text = "Missing Assets";
			this.LauncherModZoneSourceMissingAssetsButton.UseVisualStyleBackColor = true;
			this.LauncherModZoneSourceMissingAssetsButton.Click += new System.EventHandler(this.LauncherModZoneSourceMissingAssetsButton_Click);
			// 
			// LauncherEditZoneSourceButton
			// 
			this.LauncherEditZoneSourceButton.Location = new System.Drawing.Point(6, 19);
			this.LauncherEditZoneSourceButton.Name = "LauncherEditZoneSourceButton";
			this.LauncherEditZoneSourceButton.Size = new System.Drawing.Size(262, 24);
			this.LauncherEditZoneSourceButton.TabIndex = 22;
			this.LauncherEditZoneSourceButton.Text = "Edit Zone Source";
			this.LauncherEditZoneSourceButton.UseVisualStyleBackColor = true;
			this.LauncherEditZoneSourceButton.Click += new System.EventHandler(this.LauncherEditZoneSourceButton_Click);
			// 
			// LauncherModComboBox
			// 
			this.LauncherModComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LauncherModComboBox.FormattingEnabled = true;
			this.LauncherModComboBox.Location = new System.Drawing.Point(6, 20);
			this.LauncherModComboBox.Name = "LauncherModComboBox";
			this.LauncherModComboBox.Size = new System.Drawing.Size(274, 21);
			this.LauncherModComboBox.TabIndex = 3;
			this.LauncherModComboBox.SelectedIndexChanged += new System.EventHandler(this.LauncherModComboBox_SelectedIndexChanged);
			// 
			// LauncherTabCompileLevel
			// 
			this.LauncherTabCompileLevel.Controls.Add(this.LauncherMapType);
			this.LauncherTabCompileLevel.Controls.Add(this.LauncherMapTypeList);
			this.LauncherTabCompileLevel.Controls.Add(this.LauncherCreateMapButton);
			this.LauncherTabCompileLevel.Controls.Add(this.LauncherDeleteMapButton);
			this.LauncherTabCompileLevel.Controls.Add(this.LauncherCompileLevelOptionsGroupBox);
			this.LauncherTabCompileLevel.Controls.Add(this.LauncherMapList);
			this.LauncherTabCompileLevel.Location = new System.Drawing.Point(4, 22);
			this.LauncherTabCompileLevel.Name = "LauncherTabCompileLevel";
			this.LauncherTabCompileLevel.Padding = new System.Windows.Forms.Padding(3);
			this.LauncherTabCompileLevel.Size = new System.Drawing.Size(641, 324);
			this.LauncherTabCompileLevel.TabIndex = 0;
			this.LauncherTabCompileLevel.Text = "Level";
			this.LauncherTabCompileLevel.UseVisualStyleBackColor = true;
			// 
			// LauncherMapType
			// 
			this.LauncherMapType.AutoSize = true;
			this.LauncherMapType.Location = new System.Drawing.Point(6, 9);
			this.LauncherMapType.Name = "LauncherMapType";
			this.LauncherMapType.Size = new System.Drawing.Size(34, 13);
			this.LauncherMapType.TabIndex = 6;
			this.LauncherMapType.Text = "Type:";
			// 
			// LauncherMapTypeList
			// 
			this.LauncherMapTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LauncherMapTypeList.FormattingEnabled = true;
			this.LauncherMapTypeList.Items.AddRange(new object[] {
            "Singleplayer",
            "Multiplayer"});
			this.LauncherMapTypeList.Location = new System.Drawing.Point(46, 4);
			this.LauncherMapTypeList.Name = "LauncherMapTypeList";
			this.LauncherMapTypeList.Size = new System.Drawing.Size(110, 21);
			this.LauncherMapTypeList.TabIndex = 5;
			this.LauncherMapTypeList.SelectedIndexChanged += new System.EventHandler(this.LauncherMapTypeList_SelectedIndexChanged);
			// 
			// LauncherCreateMapButton
			// 
			this.LauncherCreateMapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LauncherCreateMapButton.Location = new System.Drawing.Point(82, 294);
			this.LauncherCreateMapButton.Name = "LauncherCreateMapButton";
			this.LauncherCreateMapButton.Size = new System.Drawing.Size(74, 24);
			this.LauncherCreateMapButton.TabIndex = 4;
			this.LauncherCreateMapButton.Text = "Create Map";
			this.LauncherCreateMapButton.UseVisualStyleBackColor = true;
			this.LauncherCreateMapButton.Click += new System.EventHandler(this.LauncherCreateMap_Click);
			// 
			// LauncherDeleteMapButton
			// 
			this.LauncherDeleteMapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LauncherDeleteMapButton.Location = new System.Drawing.Point(6, 294);
			this.LauncherDeleteMapButton.Name = "LauncherDeleteMapButton";
			this.LauncherDeleteMapButton.Size = new System.Drawing.Size(74, 24);
			this.LauncherDeleteMapButton.TabIndex = 4;
			this.LauncherDeleteMapButton.Text = "Delete Map";
			this.LauncherDeleteMapButton.UseVisualStyleBackColor = true;
			this.LauncherDeleteMapButton.Click += new System.EventHandler(this.LauncherDeleteMap_Click);
			// 
			// LauncherCompileLevelOptionsGroupBox
			// 
			this.LauncherCompileLevelOptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherCompileReflectionsCheckBox);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherGridFileGroupBox);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherModSpecificMapComboBox);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherModSpecificMapCheckBox);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherCustomRunOptionsLabel);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherCustomRunOptionsTextBox);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.label);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherCompileLevelButton);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherCompileLightsButton);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherCompileBSPButton);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherUseRunGameTypeOptionsCheckBox);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherRunMapAfterCompileCheckBox);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherBspInfoCheckBox);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherBuildFastFilesCheckBox);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherConnectPathsCheckBox);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherCompileLightsCheckBox);
			this.LauncherCompileLevelOptionsGroupBox.Controls.Add(this.LauncherCompileBSPCheckBox);
			this.LauncherCompileLevelOptionsGroupBox.Location = new System.Drawing.Point(162, 6);
			this.LauncherCompileLevelOptionsGroupBox.Name = "LauncherCompileLevelOptionsGroupBox";
			this.LauncherCompileLevelOptionsGroupBox.Size = new System.Drawing.Size(473, 312);
			this.LauncherCompileLevelOptionsGroupBox.TabIndex = 3;
			this.LauncherCompileLevelOptionsGroupBox.TabStop = false;
			this.LauncherCompileLevelOptionsGroupBox.Text = "Compile Level Options";
			// 
			// LauncherCompileReflectionsCheckBox
			// 
			this.LauncherCompileReflectionsCheckBox.AutoSize = true;
			this.LauncherCompileReflectionsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.LauncherCompileReflectionsCheckBox.Location = new System.Drawing.Point(9, 88);
			this.LauncherCompileReflectionsCheckBox.Name = "LauncherCompileReflectionsCheckBox";
			this.LauncherCompileReflectionsCheckBox.Size = new System.Drawing.Size(117, 17);
			this.LauncherCompileReflectionsCheckBox.TabIndex = 19;
			this.LauncherCompileReflectionsCheckBox.Text = "Compile Reflections";
			this.LauncherCompileReflectionsCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherGridFileGroupBox
			// 
			this.LauncherGridFileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LauncherGridFileGroupBox.Controls.Add(this.LauncherGridEditExistingButton);
			this.LauncherGridFileGroupBox.Controls.Add(this.LauncherGridMakeNewButton);
			this.LauncherGridFileGroupBox.Controls.Add(this.LauncherGridCollectDotsCheckBox);
			this.LauncherGridFileGroupBox.Location = new System.Drawing.Point(6, 230);
			this.LauncherGridFileGroupBox.Name = "LauncherGridFileGroupBox";
			this.LauncherGridFileGroupBox.Size = new System.Drawing.Size(223, 76);
			this.LauncherGridFileGroupBox.TabIndex = 18;
			this.LauncherGridFileGroupBox.TabStop = false;
			this.LauncherGridFileGroupBox.Text = "Grid File";
			// 
			// LauncherGridEditExistingButton
			// 
			this.LauncherGridEditExistingButton.Location = new System.Drawing.Point(112, 42);
			this.LauncherGridEditExistingButton.Name = "LauncherGridEditExistingButton";
			this.LauncherGridEditExistingButton.Size = new System.Drawing.Size(100, 23);
			this.LauncherGridEditExistingButton.TabIndex = 19;
			this.LauncherGridEditExistingButton.Text = "Edit Existing Grid";
			this.LauncherGridEditExistingButton.UseVisualStyleBackColor = true;
			this.LauncherGridEditExistingButton.Click += new System.EventHandler(this.LauncherGridEditExistingButton_Click);
			// 
			// LauncherGridMakeNewButton
			// 
			this.LauncherGridMakeNewButton.Location = new System.Drawing.Point(6, 42);
			this.LauncherGridMakeNewButton.Name = "LauncherGridMakeNewButton";
			this.LauncherGridMakeNewButton.Size = new System.Drawing.Size(100, 23);
			this.LauncherGridMakeNewButton.TabIndex = 18;
			this.LauncherGridMakeNewButton.Text = "Make New Grid";
			this.LauncherGridMakeNewButton.UseVisualStyleBackColor = true;
			this.LauncherGridMakeNewButton.Click += new System.EventHandler(this.LauncherGridMakeNewButton_Click);
			// 
			// LauncherGridCollectDotsCheckBox
			// 
			this.LauncherGridCollectDotsCheckBox.AutoSize = true;
			this.LauncherGridCollectDotsCheckBox.Location = new System.Drawing.Point(6, 19);
			this.LauncherGridCollectDotsCheckBox.Name = "LauncherGridCollectDotsCheckBox";
			this.LauncherGridCollectDotsCheckBox.Size = new System.Drawing.Size(120, 17);
			this.LauncherGridCollectDotsCheckBox.TabIndex = 17;
			this.LauncherGridCollectDotsCheckBox.Text = "Models Collect Dots";
			this.LauncherGridCollectDotsCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherModSpecificMapComboBox
			// 
			this.LauncherModSpecificMapComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherModSpecificMapComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LauncherModSpecificMapComboBox.Enabled = false;
			this.LauncherModSpecificMapComboBox.FormattingEnabled = true;
			this.LauncherModSpecificMapComboBox.Items.AddRange(new object[] {
            "HumorOneMod",
            "HumorTwoMod",
            "BlahBlahMod"});
			this.LauncherModSpecificMapComboBox.Location = new System.Drawing.Point(149, 41);
			this.LauncherModSpecificMapComboBox.Name = "LauncherModSpecificMapComboBox";
			this.LauncherModSpecificMapComboBox.Size = new System.Drawing.Size(318, 21);
			this.LauncherModSpecificMapComboBox.TabIndex = 4;
			// 
			// LauncherModSpecificMapCheckBox
			// 
			this.LauncherModSpecificMapCheckBox.AutoSize = true;
			this.LauncherModSpecificMapCheckBox.Location = new System.Drawing.Point(149, 16);
			this.LauncherModSpecificMapCheckBox.Name = "LauncherModSpecificMapCheckBox";
			this.LauncherModSpecificMapCheckBox.Size = new System.Drawing.Size(112, 17);
			this.LauncherModSpecificMapCheckBox.TabIndex = 5;
			this.LauncherModSpecificMapCheckBox.Text = "Mod Specific Map";
			this.LauncherModSpecificMapCheckBox.UseVisualStyleBackColor = true;
			this.LauncherModSpecificMapCheckBox.CheckedChanged += new System.EventHandler(this.LauncherModSpecificMapCheckBox_CheckedChanged);
			// 
			// LauncherCustomRunOptionsLabel
			// 
			this.LauncherCustomRunOptionsLabel.AutoSize = true;
			this.LauncherCustomRunOptionsLabel.Location = new System.Drawing.Point(6, 206);
			this.LauncherCustomRunOptionsLabel.Name = "LauncherCustomRunOptionsLabel";
			this.LauncherCustomRunOptionsLabel.Size = new System.Drawing.Size(107, 13);
			this.LauncherCustomRunOptionsLabel.TabIndex = 14;
			this.LauncherCustomRunOptionsLabel.Text = "Custom Run Options:";
			this.LauncherCustomRunOptionsLabel.Visible = false;
			// 
			// LauncherCustomRunOptionsTextBox
			// 
			this.LauncherCustomRunOptionsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherCustomRunOptionsTextBox.Location = new System.Drawing.Point(119, 203);
			this.LauncherCustomRunOptionsTextBox.Name = "LauncherCustomRunOptionsTextBox";
			this.LauncherCustomRunOptionsTextBox.Size = new System.Drawing.Size(348, 20);
			this.LauncherCustomRunOptionsTextBox.TabIndex = 13;
			this.LauncherCustomRunOptionsTextBox.Visible = false;
			// 
			// label
			// 
			this.label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label.BackColor = System.Drawing.Color.Gainsboro;
			this.label.CausesValidation = false;
			this.label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label.Location = new System.Drawing.Point(0, 107);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(473, 1);
			this.label.TabIndex = 12;
			// 
			// LauncherCompileLevelButton
			// 
			this.LauncherCompileLevelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherCompileLevelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LauncherCompileLevelButton.Location = new System.Drawing.Point(340, 229);
			this.LauncherCompileLevelButton.Name = "LauncherCompileLevelButton";
			this.LauncherCompileLevelButton.Size = new System.Drawing.Size(128, 76);
			this.LauncherCompileLevelButton.TabIndex = 4;
			this.LauncherCompileLevelButton.Text = "Compile Level";
			this.LauncherCompileLevelButton.UseVisualStyleBackColor = true;
			this.LauncherCompileLevelButton.Click += new System.EventHandler(this.LauncherCompileLevelButton_Click);
			// 
			// LauncherCompileLightsButton
			// 
			this.LauncherCompileLightsButton.Location = new System.Drawing.Point(107, 16);
			this.LauncherCompileLightsButton.Name = "LauncherCompileLightsButton";
			this.LauncherCompileLightsButton.Size = new System.Drawing.Size(26, 23);
			this.LauncherCompileLightsButton.TabIndex = 11;
			this.LauncherCompileLightsButton.Text = "...";
			this.LauncherCompileLightsButton.UseVisualStyleBackColor = true;
			this.LauncherCompileLightsButton.Click += new System.EventHandler(this.LauncherCompileLightsButton_Click);
			// 
			// LauncherCompileBSPButton
			// 
			this.LauncherCompileBSPButton.Location = new System.Drawing.Point(107, 39);
			this.LauncherCompileBSPButton.Name = "LauncherCompileBSPButton";
			this.LauncherCompileBSPButton.Size = new System.Drawing.Size(26, 23);
			this.LauncherCompileBSPButton.TabIndex = 10;
			this.LauncherCompileBSPButton.Text = "...";
			this.LauncherCompileBSPButton.UseVisualStyleBackColor = true;
			this.LauncherCompileBSPButton.Click += new System.EventHandler(this.LauncherCompileBSPButton_Click);
			// 
			// LauncherUseRunGameTypeOptionsCheckBox
			// 
			this.LauncherUseRunGameTypeOptionsCheckBox.AutoSize = true;
			this.LauncherUseRunGameTypeOptionsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.LauncherUseRunGameTypeOptionsCheckBox.Location = new System.Drawing.Point(9, 180);
			this.LauncherUseRunGameTypeOptionsCheckBox.Name = "LauncherUseRunGameTypeOptionsCheckBox";
			this.LauncherUseRunGameTypeOptionsCheckBox.Size = new System.Drawing.Size(162, 17);
			this.LauncherUseRunGameTypeOptionsCheckBox.TabIndex = 9;
			this.LauncherUseRunGameTypeOptionsCheckBox.Text = "Use \'Run Game Tab\' Options";
			this.LauncherUseRunGameTypeOptionsCheckBox.UseVisualStyleBackColor = true;
			this.LauncherUseRunGameTypeOptionsCheckBox.Visible = false;
			// 
			// LauncherRunMapAfterCompileCheckBox
			// 
			this.LauncherRunMapAfterCompileCheckBox.AutoSize = true;
			this.LauncherRunMapAfterCompileCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.LauncherRunMapAfterCompileCheckBox.Location = new System.Drawing.Point(9, 157);
			this.LauncherRunMapAfterCompileCheckBox.Name = "LauncherRunMapAfterCompileCheckBox";
			this.LauncherRunMapAfterCompileCheckBox.Size = new System.Drawing.Size(133, 17);
			this.LauncherRunMapAfterCompileCheckBox.TabIndex = 8;
			this.LauncherRunMapAfterCompileCheckBox.Text = "Run Map After Compile";
			this.LauncherRunMapAfterCompileCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherBspInfoCheckBox
			// 
			this.LauncherBspInfoCheckBox.AutoSize = true;
			this.LauncherBspInfoCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.LauncherBspInfoCheckBox.Location = new System.Drawing.Point(9, 134);
			this.LauncherBspInfoCheckBox.Name = "LauncherBspInfoCheckBox";
			this.LauncherBspInfoCheckBox.Size = new System.Drawing.Size(66, 17);
			this.LauncherBspInfoCheckBox.TabIndex = 7;
			this.LauncherBspInfoCheckBox.Text = "BSP Info";
			this.LauncherBspInfoCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherBuildFastFilesCheckBox
			// 
			this.LauncherBuildFastFilesCheckBox.AutoSize = true;
			this.LauncherBuildFastFilesCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.LauncherBuildFastFilesCheckBox.Location = new System.Drawing.Point(9, 111);
			this.LauncherBuildFastFilesCheckBox.Name = "LauncherBuildFastFilesCheckBox";
			this.LauncherBuildFastFilesCheckBox.Size = new System.Drawing.Size(88, 17);
			this.LauncherBuildFastFilesCheckBox.TabIndex = 6;
			this.LauncherBuildFastFilesCheckBox.Text = "Build Fastfiles";
			this.LauncherBuildFastFilesCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherConnectPathsCheckBox
			// 
			this.LauncherConnectPathsCheckBox.AutoSize = true;
			this.LauncherConnectPathsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.LauncherConnectPathsCheckBox.Location = new System.Drawing.Point(9, 65);
			this.LauncherConnectPathsCheckBox.Name = "LauncherConnectPathsCheckBox";
			this.LauncherConnectPathsCheckBox.Size = new System.Drawing.Size(94, 17);
			this.LauncherConnectPathsCheckBox.TabIndex = 3;
			this.LauncherConnectPathsCheckBox.Text = "Connect Paths";
			this.LauncherConnectPathsCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherCompileLightsCheckBox
			// 
			this.LauncherCompileLightsCheckBox.AutoSize = true;
			this.LauncherCompileLightsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.LauncherCompileLightsCheckBox.Location = new System.Drawing.Point(9, 42);
			this.LauncherCompileLightsCheckBox.Name = "LauncherCompileLightsCheckBox";
			this.LauncherCompileLightsCheckBox.Size = new System.Drawing.Size(92, 17);
			this.LauncherCompileLightsCheckBox.TabIndex = 1;
			this.LauncherCompileLightsCheckBox.Text = "Compile Lights";
			this.LauncherCompileLightsCheckBox.UseVisualStyleBackColor = true;
			this.LauncherCompileLightsCheckBox.CheckedChanged += new System.EventHandler(this.LauncherCompileLightsCheckBox_CheckedChanged);
			// 
			// LauncherCompileBSPCheckBox
			// 
			this.LauncherCompileBSPCheckBox.AutoSize = true;
			this.LauncherCompileBSPCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.LauncherCompileBSPCheckBox.Location = new System.Drawing.Point(9, 19);
			this.LauncherCompileBSPCheckBox.Name = "LauncherCompileBSPCheckBox";
			this.LauncherCompileBSPCheckBox.Size = new System.Drawing.Size(85, 17);
			this.LauncherCompileBSPCheckBox.TabIndex = 0;
			this.LauncherCompileBSPCheckBox.Text = "Compile BSP";
			this.LauncherCompileBSPCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherMapList
			// 
			this.LauncherMapList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.LauncherMapList.FormattingEnabled = true;
			this.LauncherMapList.IntegralHeight = false;
			this.LauncherMapList.Location = new System.Drawing.Point(6, 31);
			this.LauncherMapList.Name = "LauncherMapList";
			this.LauncherMapList.Size = new System.Drawing.Size(150, 261);
			this.LauncherMapList.TabIndex = 1;
			this.LauncherMapList.SelectedIndexChanged += new System.EventHandler(this.LauncherMapList_SelectedIndexChanged);
			this.LauncherMapList.DoubleClick += new System.EventHandler(this.LauncherMapList_DoubleClick);
			this.LauncherMapList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LauncherMapList_MouseDown);
			this.LauncherMapList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LauncherMapList_MouseUp);
			// 
			// LauncherTabExplore
			// 
			this.LauncherTabExplore.Controls.Add(this.LauncherExploreGroupBox);
			this.LauncherTabExplore.Location = new System.Drawing.Point(4, 22);
			this.LauncherTabExplore.Name = "LauncherTabExplore";
			this.LauncherTabExplore.Padding = new System.Windows.Forms.Padding(3);
			this.LauncherTabExplore.Size = new System.Drawing.Size(641, 324);
			this.LauncherTabExplore.TabIndex = 3;
			this.LauncherTabExplore.Text = "Explore";
			this.LauncherTabExplore.UseVisualStyleBackColor = true;
			// 
			// LauncherExploreGroupBox
			// 
			this.LauncherExploreGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherExploreGroupBox.Controls.Add(this.LauncherExploreRawMapsDirGroupBox);
			this.LauncherExploreGroupBox.Controls.Add(this.LauncherExploreRawDirGroupBox);
			this.LauncherExploreGroupBox.Controls.Add(this.LauncherExploreDevDirGroupBox);
			this.LauncherExploreGroupBox.Controls.Add(this.LauncherExploreBlopsDirGroupBox);
			this.LauncherExploreGroupBox.Location = new System.Drawing.Point(6, 6);
			this.LauncherExploreGroupBox.Name = "LauncherExploreGroupBox";
			this.LauncherExploreGroupBox.Size = new System.Drawing.Size(629, 312);
			this.LauncherExploreGroupBox.TabIndex = 0;
			this.LauncherExploreGroupBox.TabStop = false;
			this.LauncherExploreGroupBox.Text = "Explore";
			// 
			// LauncherExploreRawMapsDirGroupBox
			// 
			this.LauncherExploreRawMapsDirGroupBox.Controls.Add(this.LauncherExploreRawGSCDirMPGametypesButton);
			this.LauncherExploreRawMapsDirGroupBox.Controls.Add(this.LauncherExploreRawGSCDirMPFXButton);
			this.LauncherExploreRawMapsDirGroupBox.Controls.Add(this.LauncherExploreRawGSCDirMPArtButton);
			this.LauncherExploreRawMapsDirGroupBox.Controls.Add(this.LauncherExploreRawGSCDirMPButton);
			this.LauncherExploreRawMapsDirGroupBox.Controls.Add(this.LauncherExploreRawGSCDirSPVoiceButton);
			this.LauncherExploreRawMapsDirGroupBox.Controls.Add(this.LauncherExploreRawGSCDirSPGametypesButton);
			this.LauncherExploreRawMapsDirGroupBox.Controls.Add(this.LauncherExploreRawGSCDirSPFXButton);
			this.LauncherExploreRawMapsDirGroupBox.Controls.Add(this.LauncherExploreRawGSCDirSPArtButton);
			this.LauncherExploreRawMapsDirGroupBox.Controls.Add(this.LauncherExploreRawGSCDirSPButton);
			this.LauncherExploreRawMapsDirGroupBox.Location = new System.Drawing.Point(463, 19);
			this.LauncherExploreRawMapsDirGroupBox.Name = "LauncherExploreRawMapsDirGroupBox";
			this.LauncherExploreRawMapsDirGroupBox.Size = new System.Drawing.Size(142, 226);
			this.LauncherExploreRawMapsDirGroupBox.TabIndex = 20;
			this.LauncherExploreRawMapsDirGroupBox.TabStop = false;
			this.LauncherExploreRawMapsDirGroupBox.Text = "Raw Maps Folders";
			// 
			// LauncherExploreRawGSCDirMPGametypesButton
			// 
			this.LauncherExploreRawGSCDirMPGametypesButton.Location = new System.Drawing.Point(6, 198);
			this.LauncherExploreRawGSCDirMPGametypesButton.Name = "LauncherExploreRawGSCDirMPGametypesButton";
			this.LauncherExploreRawGSCDirMPGametypesButton.Size = new System.Drawing.Size(64, 24);
			this.LauncherExploreRawGSCDirMPGametypesButton.TabIndex = 29;
			this.LauncherExploreRawGSCDirMPGametypesButton.Text = "Gametypes";
			this.LauncherExploreRawGSCDirMPGametypesButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawGSCDirMPGametypesButton.Click += new System.EventHandler(this.LauncherExploreRawGSCDirMPGametypesButton_Click);
			// 
			// LauncherExploreRawGSCDirMPFXButton
			// 
			this.LauncherExploreRawGSCDirMPFXButton.Location = new System.Drawing.Point(72, 168);
			this.LauncherExploreRawGSCDirMPFXButton.Name = "LauncherExploreRawGSCDirMPFXButton";
			this.LauncherExploreRawGSCDirMPFXButton.Size = new System.Drawing.Size(64, 24);
			this.LauncherExploreRawGSCDirMPFXButton.TabIndex = 28;
			this.LauncherExploreRawGSCDirMPFXButton.Text = "CreateFX";
			this.LauncherExploreRawGSCDirMPFXButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawGSCDirMPFXButton.Click += new System.EventHandler(this.LauncherExploreRawGSCDirMPFXButton_Click);
			// 
			// LauncherExploreRawGSCDirMPArtButton
			// 
			this.LauncherExploreRawGSCDirMPArtButton.Location = new System.Drawing.Point(6, 168);
			this.LauncherExploreRawGSCDirMPArtButton.Name = "LauncherExploreRawGSCDirMPArtButton";
			this.LauncherExploreRawGSCDirMPArtButton.Size = new System.Drawing.Size(64, 24);
			this.LauncherExploreRawGSCDirMPArtButton.TabIndex = 27;
			this.LauncherExploreRawGSCDirMPArtButton.Text = "CreateArt";
			this.LauncherExploreRawGSCDirMPArtButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawGSCDirMPArtButton.Click += new System.EventHandler(this.LauncherExploreRawGSCDirMPArtButton_Click);
			// 
			// LauncherExploreRawGSCDirMPButton
			// 
			this.LauncherExploreRawGSCDirMPButton.Location = new System.Drawing.Point(6, 138);
			this.LauncherExploreRawGSCDirMPButton.Name = "LauncherExploreRawGSCDirMPButton";
			this.LauncherExploreRawGSCDirMPButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreRawGSCDirMPButton.TabIndex = 26;
			this.LauncherExploreRawGSCDirMPButton.Text = "Multiplayer";
			this.LauncherExploreRawGSCDirMPButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawGSCDirMPButton.Click += new System.EventHandler(this.LauncherExploreRawGSCDirMPButton_Click);
			// 
			// LauncherExploreRawGSCDirSPVoiceButton
			// 
			this.LauncherExploreRawGSCDirSPVoiceButton.Location = new System.Drawing.Point(72, 79);
			this.LauncherExploreRawGSCDirSPVoiceButton.Name = "LauncherExploreRawGSCDirSPVoiceButton";
			this.LauncherExploreRawGSCDirSPVoiceButton.Size = new System.Drawing.Size(64, 24);
			this.LauncherExploreRawGSCDirSPVoiceButton.TabIndex = 25;
			this.LauncherExploreRawGSCDirSPVoiceButton.Text = "Voice";
			this.LauncherExploreRawGSCDirSPVoiceButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawGSCDirSPVoiceButton.Click += new System.EventHandler(this.LauncherExploreRawGSCDirSPVoiceButton_Click);
			// 
			// LauncherExploreRawGSCDirSPGametypesButton
			// 
			this.LauncherExploreRawGSCDirSPGametypesButton.Location = new System.Drawing.Point(6, 79);
			this.LauncherExploreRawGSCDirSPGametypesButton.Name = "LauncherExploreRawGSCDirSPGametypesButton";
			this.LauncherExploreRawGSCDirSPGametypesButton.Size = new System.Drawing.Size(64, 24);
			this.LauncherExploreRawGSCDirSPGametypesButton.TabIndex = 24;
			this.LauncherExploreRawGSCDirSPGametypesButton.Text = "Gametypes";
			this.LauncherExploreRawGSCDirSPGametypesButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawGSCDirSPGametypesButton.Click += new System.EventHandler(this.LauncherExploreRawGSCDirSPGametypesButton_Click);
			// 
			// LauncherExploreRawGSCDirSPFXButton
			// 
			this.LauncherExploreRawGSCDirSPFXButton.Location = new System.Drawing.Point(72, 49);
			this.LauncherExploreRawGSCDirSPFXButton.Name = "LauncherExploreRawGSCDirSPFXButton";
			this.LauncherExploreRawGSCDirSPFXButton.Size = new System.Drawing.Size(64, 24);
			this.LauncherExploreRawGSCDirSPFXButton.TabIndex = 23;
			this.LauncherExploreRawGSCDirSPFXButton.Text = "CreateFX";
			this.LauncherExploreRawGSCDirSPFXButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawGSCDirSPFXButton.Click += new System.EventHandler(this.LauncherExploreRawGSCDirSPFXButton_Click);
			// 
			// LauncherExploreRawGSCDirSPArtButton
			// 
			this.LauncherExploreRawGSCDirSPArtButton.Location = new System.Drawing.Point(6, 49);
			this.LauncherExploreRawGSCDirSPArtButton.Name = "LauncherExploreRawGSCDirSPArtButton";
			this.LauncherExploreRawGSCDirSPArtButton.Size = new System.Drawing.Size(64, 24);
			this.LauncherExploreRawGSCDirSPArtButton.TabIndex = 22;
			this.LauncherExploreRawGSCDirSPArtButton.Text = "CreateArt";
			this.LauncherExploreRawGSCDirSPArtButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawGSCDirSPArtButton.Click += new System.EventHandler(this.LauncherExploreRawGSCDirSPArtButton_Click);
			// 
			// LauncherExploreRawGSCDirSPButton
			// 
			this.LauncherExploreRawGSCDirSPButton.Location = new System.Drawing.Point(6, 19);
			this.LauncherExploreRawGSCDirSPButton.Name = "LauncherExploreRawGSCDirSPButton";
			this.LauncherExploreRawGSCDirSPButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreRawGSCDirSPButton.TabIndex = 21;
			this.LauncherExploreRawGSCDirSPButton.Text = "Singleplayer";
			this.LauncherExploreRawGSCDirSPButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawGSCDirSPButton.Click += new System.EventHandler(this.LauncherExploreRawGSCDirSPButton_Click);
			// 
			// LauncherExploreRawDirGroupBox
			// 
			this.LauncherExploreRawDirGroupBox.Controls.Add(this.LauncherExploreRawDirFXButton);
			this.LauncherExploreRawDirGroupBox.Controls.Add(this.LauncherExploreRawDirMPButton);
			this.LauncherExploreRawDirGroupBox.Controls.Add(this.LauncherExploreRawDirWeaponsButton);
			this.LauncherExploreRawDirGroupBox.Controls.Add(this.LauncherExploreRawDirVisionButton);
			this.LauncherExploreRawDirGroupBox.Controls.Add(this.LauncherExploreRawDirLocsButton);
			this.LauncherExploreRawDirGroupBox.Controls.Add(this.LauncherExploreRawDirAnimTreesButton);
			this.LauncherExploreRawDirGroupBox.Controls.Add(this.LauncherExploreRawDirSoundAliasesButton);
			this.LauncherExploreRawDirGroupBox.Controls.Add(this.LauncherExploreRawDirCSCButton);
			this.LauncherExploreRawDirGroupBox.Controls.Add(this.LauncherExploreRawDirGSCButton);
			this.LauncherExploreRawDirGroupBox.Location = new System.Drawing.Point(315, 19);
			this.LauncherExploreRawDirGroupBox.Name = "LauncherExploreRawDirGroupBox";
			this.LauncherExploreRawDirGroupBox.Size = new System.Drawing.Size(142, 287);
			this.LauncherExploreRawDirGroupBox.TabIndex = 19;
			this.LauncherExploreRawDirGroupBox.TabStop = false;
			this.LauncherExploreRawDirGroupBox.Text = "Raw Folders";
			// 
			// LauncherExploreRawDirFXButton
			// 
			this.LauncherExploreRawDirFXButton.Location = new System.Drawing.Point(6, 109);
			this.LauncherExploreRawDirFXButton.Name = "LauncherExploreRawDirFXButton";
			this.LauncherExploreRawDirFXButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreRawDirFXButton.TabIndex = 25;
			this.LauncherExploreRawDirFXButton.Text = "FX";
			this.LauncherExploreRawDirFXButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawDirFXButton.Click += new System.EventHandler(this.LauncherExploreRawDirFXButton_Click);
			// 
			// LauncherExploreRawDirMPButton
			// 
			this.LauncherExploreRawDirMPButton.Location = new System.Drawing.Point(6, 168);
			this.LauncherExploreRawDirMPButton.Name = "LauncherExploreRawDirMPButton";
			this.LauncherExploreRawDirMPButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreRawDirMPButton.TabIndex = 24;
			this.LauncherExploreRawDirMPButton.Text = "MP";
			this.LauncherExploreRawDirMPButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawDirMPButton.Click += new System.EventHandler(this.LauncherExploreRawDirMPButton_Click);
			// 
			// LauncherExploreRawDirWeaponsButton
			// 
			this.LauncherExploreRawDirWeaponsButton.Location = new System.Drawing.Point(6, 258);
			this.LauncherExploreRawDirWeaponsButton.Name = "LauncherExploreRawDirWeaponsButton";
			this.LauncherExploreRawDirWeaponsButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreRawDirWeaponsButton.TabIndex = 23;
			this.LauncherExploreRawDirWeaponsButton.Text = "Weapons";
			this.LauncherExploreRawDirWeaponsButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawDirWeaponsButton.Click += new System.EventHandler(this.LauncherExploreRawDirWeaponsButton_Click);
			// 
			// LauncherExploreRawDirVisionButton
			// 
			this.LauncherExploreRawDirVisionButton.Location = new System.Drawing.Point(6, 228);
			this.LauncherExploreRawDirVisionButton.Name = "LauncherExploreRawDirVisionButton";
			this.LauncherExploreRawDirVisionButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreRawDirVisionButton.TabIndex = 22;
			this.LauncherExploreRawDirVisionButton.Text = "Vision";
			this.LauncherExploreRawDirVisionButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawDirVisionButton.Click += new System.EventHandler(this.LauncherExploreRawDirVisionButton_Click);
			// 
			// LauncherExploreRawDirLocsButton
			// 
			this.LauncherExploreRawDirLocsButton.Location = new System.Drawing.Point(6, 79);
			this.LauncherExploreRawDirLocsButton.Name = "LauncherExploreRawDirLocsButton";
			this.LauncherExploreRawDirLocsButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreRawDirLocsButton.TabIndex = 21;
			this.LauncherExploreRawDirLocsButton.Text = "English Strings";
			this.LauncherExploreRawDirLocsButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawDirLocsButton.Click += new System.EventHandler(this.LauncherExploreRawDirLocsButton_Click);
			// 
			// LauncherExploreRawDirAnimTreesButton
			// 
			this.LauncherExploreRawDirAnimTreesButton.Location = new System.Drawing.Point(6, 19);
			this.LauncherExploreRawDirAnimTreesButton.Name = "LauncherExploreRawDirAnimTreesButton";
			this.LauncherExploreRawDirAnimTreesButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreRawDirAnimTreesButton.TabIndex = 20;
			this.LauncherExploreRawDirAnimTreesButton.Text = "AnimTrees";
			this.LauncherExploreRawDirAnimTreesButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawDirAnimTreesButton.Click += new System.EventHandler(this.LauncherExploreRawDirAnimTreesButton_Click);
			// 
			// LauncherExploreRawDirSoundAliasesButton
			// 
			this.LauncherExploreRawDirSoundAliasesButton.Location = new System.Drawing.Point(6, 198);
			this.LauncherExploreRawDirSoundAliasesButton.Name = "LauncherExploreRawDirSoundAliasesButton";
			this.LauncherExploreRawDirSoundAliasesButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreRawDirSoundAliasesButton.TabIndex = 19;
			this.LauncherExploreRawDirSoundAliasesButton.Text = "Sound Aliases";
			this.LauncherExploreRawDirSoundAliasesButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawDirSoundAliasesButton.Click += new System.EventHandler(this.LauncherExploreRawDirSoundAliasesButton_Click);
			// 
			// LauncherExploreRawDirCSCButton
			// 
			this.LauncherExploreRawDirCSCButton.Location = new System.Drawing.Point(6, 49);
			this.LauncherExploreRawDirCSCButton.Name = "LauncherExploreRawDirCSCButton";
			this.LauncherExploreRawDirCSCButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreRawDirCSCButton.TabIndex = 18;
			this.LauncherExploreRawDirCSCButton.Text = "Clientscripts";
			this.LauncherExploreRawDirCSCButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawDirCSCButton.Click += new System.EventHandler(this.LauncherExploreRawDirCSCButton_Click);
			// 
			// LauncherExploreRawDirGSCButton
			// 
			this.LauncherExploreRawDirGSCButton.Location = new System.Drawing.Point(6, 139);
			this.LauncherExploreRawDirGSCButton.Name = "LauncherExploreRawDirGSCButton";
			this.LauncherExploreRawDirGSCButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreRawDirGSCButton.TabIndex = 17;
			this.LauncherExploreRawDirGSCButton.Text = "Maps";
			this.LauncherExploreRawDirGSCButton.UseVisualStyleBackColor = true;
			this.LauncherExploreRawDirGSCButton.Click += new System.EventHandler(this.LauncherExploreRawDirGSCButton_Click);
			// 
			// LauncherExploreDevDirGroupBox
			// 
			this.LauncherExploreDevDirGroupBox.Controls.Add(this.LauncherExploreDevDirRawButton);
			this.LauncherExploreDevDirGroupBox.Controls.Add(this.LauncherExploreDevDirModelExportButton);
			this.LauncherExploreDevDirGroupBox.Controls.Add(this.LauncherExploreDevDirTextureAssetsButton);
			this.LauncherExploreDevDirGroupBox.Controls.Add(this.LauncherExploreDevDirSrcDataButton);
			this.LauncherExploreDevDirGroupBox.Controls.Add(this.LauncherExploreDevDirMapSrcButton);
			this.LauncherExploreDevDirGroupBox.Controls.Add(this.LauncherExploreDevDirBinButton);
			this.LauncherExploreDevDirGroupBox.Controls.Add(this.LauncherExploreDevDirZoneSourceButton);
			this.LauncherExploreDevDirGroupBox.Location = new System.Drawing.Point(167, 19);
			this.LauncherExploreDevDirGroupBox.Name = "LauncherExploreDevDirGroupBox";
			this.LauncherExploreDevDirGroupBox.Size = new System.Drawing.Size(142, 226);
			this.LauncherExploreDevDirGroupBox.TabIndex = 18;
			this.LauncherExploreDevDirGroupBox.TabStop = false;
			this.LauncherExploreDevDirGroupBox.Text = "Development Directories";
			// 
			// LauncherExploreDevDirRawButton
			// 
			this.LauncherExploreDevDirRawButton.Location = new System.Drawing.Point(6, 108);
			this.LauncherExploreDevDirRawButton.Name = "LauncherExploreDevDirRawButton";
			this.LauncherExploreDevDirRawButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreDevDirRawButton.TabIndex = 19;
			this.LauncherExploreDevDirRawButton.Text = "Raw";
			this.LauncherExploreDevDirRawButton.UseVisualStyleBackColor = true;
			this.LauncherExploreDevDirRawButton.Click += new System.EventHandler(this.LauncherExploreDevDirRawButton_Click);
			// 
			// LauncherExploreDevDirModelExportButton
			// 
			this.LauncherExploreDevDirModelExportButton.Location = new System.Drawing.Point(6, 78);
			this.LauncherExploreDevDirModelExportButton.Name = "LauncherExploreDevDirModelExportButton";
			this.LauncherExploreDevDirModelExportButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreDevDirModelExportButton.TabIndex = 18;
			this.LauncherExploreDevDirModelExportButton.Text = "Model Export";
			this.LauncherExploreDevDirModelExportButton.UseVisualStyleBackColor = true;
			this.LauncherExploreDevDirModelExportButton.Click += new System.EventHandler(this.LauncherExploreDevDirModelExportButton_Click);
			// 
			// LauncherExploreDevDirTextureAssetsButton
			// 
			this.LauncherExploreDevDirTextureAssetsButton.Location = new System.Drawing.Point(6, 168);
			this.LauncherExploreDevDirTextureAssetsButton.Name = "LauncherExploreDevDirTextureAssetsButton";
			this.LauncherExploreDevDirTextureAssetsButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreDevDirTextureAssetsButton.TabIndex = 17;
			this.LauncherExploreDevDirTextureAssetsButton.Text = "Texture Assets";
			this.LauncherExploreDevDirTextureAssetsButton.UseVisualStyleBackColor = true;
			this.LauncherExploreDevDirTextureAssetsButton.Click += new System.EventHandler(this.LauncherExploreDevDirTextureAssetsButton_Click);
			// 
			// LauncherExploreDevDirSrcDataButton
			// 
			this.LauncherExploreDevDirSrcDataButton.Location = new System.Drawing.Point(6, 138);
			this.LauncherExploreDevDirSrcDataButton.Name = "LauncherExploreDevDirSrcDataButton";
			this.LauncherExploreDevDirSrcDataButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreDevDirSrcDataButton.TabIndex = 16;
			this.LauncherExploreDevDirSrcDataButton.Text = "Source Data";
			this.LauncherExploreDevDirSrcDataButton.UseVisualStyleBackColor = true;
			this.LauncherExploreDevDirSrcDataButton.Click += new System.EventHandler(this.LauncherExploreDevDirSrcDataButton_Click);
			// 
			// LauncherExploreDevDirMapSrcButton
			// 
			this.LauncherExploreDevDirMapSrcButton.Location = new System.Drawing.Point(6, 48);
			this.LauncherExploreDevDirMapSrcButton.Name = "LauncherExploreDevDirMapSrcButton";
			this.LauncherExploreDevDirMapSrcButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreDevDirMapSrcButton.TabIndex = 15;
			this.LauncherExploreDevDirMapSrcButton.Text = "Map Source";
			this.LauncherExploreDevDirMapSrcButton.UseVisualStyleBackColor = true;
			this.LauncherExploreDevDirMapSrcButton.Click += new System.EventHandler(this.LauncherExploreDevDirMapSrcButton_Click);
			// 
			// LauncherExploreDevDirBinButton
			// 
			this.LauncherExploreDevDirBinButton.Location = new System.Drawing.Point(6, 19);
			this.LauncherExploreDevDirBinButton.Name = "LauncherExploreDevDirBinButton";
			this.LauncherExploreDevDirBinButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreDevDirBinButton.TabIndex = 14;
			this.LauncherExploreDevDirBinButton.Text = "Bin";
			this.LauncherExploreDevDirBinButton.UseVisualStyleBackColor = true;
			this.LauncherExploreDevDirBinButton.Click += new System.EventHandler(this.LauncherExploreDevDirBinButton_Click);
			// 
			// LauncherExploreDevDirZoneSourceButton
			// 
			this.LauncherExploreDevDirZoneSourceButton.Location = new System.Drawing.Point(6, 198);
			this.LauncherExploreDevDirZoneSourceButton.Name = "LauncherExploreDevDirZoneSourceButton";
			this.LauncherExploreDevDirZoneSourceButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreDevDirZoneSourceButton.TabIndex = 13;
			this.LauncherExploreDevDirZoneSourceButton.Text = "Zone Source";
			this.LauncherExploreDevDirZoneSourceButton.UseVisualStyleBackColor = true;
			this.LauncherExploreDevDirZoneSourceButton.Click += new System.EventHandler(this.LauncherExploreDevDirZoneSourceButton_Click);
			// 
			// LauncherExploreBlopsDirGroupBox
			// 
			this.LauncherExploreBlopsDirGroupBox.Controls.Add(this.LauncherExploreBlopsDirConfigsButton);
			this.LauncherExploreBlopsDirGroupBox.Controls.Add(this.LauncherExploreBlopsDirModsButton);
			this.LauncherExploreBlopsDirGroupBox.Controls.Add(this.LauncherExploreBlopsDirGameButton);
			this.LauncherExploreBlopsDirGroupBox.Location = new System.Drawing.Point(19, 19);
			this.LauncherExploreBlopsDirGroupBox.Name = "LauncherExploreBlopsDirGroupBox";
			this.LauncherExploreBlopsDirGroupBox.Size = new System.Drawing.Size(142, 110);
			this.LauncherExploreBlopsDirGroupBox.TabIndex = 17;
			this.LauncherExploreBlopsDirGroupBox.TabStop = false;
			this.LauncherExploreBlopsDirGroupBox.Text = "Call of Duty: Black Ops";
			// 
			// LauncherExploreBlopsDirConfigsButton
			// 
			this.LauncherExploreBlopsDirConfigsButton.Location = new System.Drawing.Point(6, 49);
			this.LauncherExploreBlopsDirConfigsButton.Name = "LauncherExploreBlopsDirConfigsButton";
			this.LauncherExploreBlopsDirConfigsButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreBlopsDirConfigsButton.TabIndex = 10;
			this.LauncherExploreBlopsDirConfigsButton.Text = "Player Configs";
			this.LauncherExploreBlopsDirConfigsButton.UseVisualStyleBackColor = true;
			this.LauncherExploreBlopsDirConfigsButton.Click += new System.EventHandler(this.LauncherExploreBlopsDirConfigsButton_Click);
			// 
			// LauncherExploreBlopsDirModsButton
			// 
			this.LauncherExploreBlopsDirModsButton.Location = new System.Drawing.Point(6, 79);
			this.LauncherExploreBlopsDirModsButton.Name = "LauncherExploreBlopsDirModsButton";
			this.LauncherExploreBlopsDirModsButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreBlopsDirModsButton.TabIndex = 9;
			this.LauncherExploreBlopsDirModsButton.Text = "Mods Folder";
			this.LauncherExploreBlopsDirModsButton.UseVisualStyleBackColor = true;
			this.LauncherExploreBlopsDirModsButton.Click += new System.EventHandler(this.LauncherExploreBlopsDirModsButton_Click);
			// 
			// LauncherExploreBlopsDirGameButton
			// 
			this.LauncherExploreBlopsDirGameButton.Location = new System.Drawing.Point(6, 19);
			this.LauncherExploreBlopsDirGameButton.Name = "LauncherExploreBlopsDirGameButton";
			this.LauncherExploreBlopsDirGameButton.Size = new System.Drawing.Size(128, 24);
			this.LauncherExploreBlopsDirGameButton.TabIndex = 8;
			this.LauncherExploreBlopsDirGameButton.Text = "Game Directory";
			this.LauncherExploreBlopsDirGameButton.UseVisualStyleBackColor = true;
			this.LauncherExploreBlopsDirGameButton.Click += new System.EventHandler(this.LauncherExploreBlopsDirGameButton_Click);
			// 
			// LauncherApplicationsGroupBox
			// 
			this.LauncherApplicationsGroupBox.Controls.Add(this.LauncherIconRadiant);
			this.LauncherApplicationsGroupBox.Controls.Add(this.LauncherIconEffectsEditor);
			this.LauncherApplicationsGroupBox.Controls.Add(this.LauncherIconConverter);
			this.LauncherApplicationsGroupBox.Controls.Add(this.LauncherIconAssetViewer);
			this.LauncherApplicationsGroupBox.Controls.Add(this.LauncherIconAssetManager);
			this.LauncherApplicationsGroupBox.Controls.Add(this.LauncherButtonAssetViewer);
			this.LauncherApplicationsGroupBox.Controls.Add(this.LauncherButtonRunConverter);
			this.LauncherApplicationsGroupBox.Controls.Add(this.LauncherButtonAssetManager);
			this.LauncherApplicationsGroupBox.Controls.Add(this.LauncherButtonEffectsEd);
			this.LauncherApplicationsGroupBox.Controls.Add(this.LauncherButtonRadiant);
			this.LauncherApplicationsGroupBox.Location = new System.Drawing.Point(5, 186);
			this.LauncherApplicationsGroupBox.Name = "LauncherApplicationsGroupBox";
			this.LauncherApplicationsGroupBox.Size = new System.Drawing.Size(139, 165);
			this.LauncherApplicationsGroupBox.TabIndex = 8;
			this.LauncherApplicationsGroupBox.TabStop = false;
			this.LauncherApplicationsGroupBox.Text = "Tools";
			// 
			// LauncherIconRadiant
			// 
			this.LauncherIconRadiant.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconRadiant.BackgroundImage")));
			this.LauncherIconRadiant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.LauncherIconRadiant.Enabled = false;
			this.LauncherIconRadiant.Location = new System.Drawing.Point(13, 139);
			this.LauncherIconRadiant.Name = "LauncherIconRadiant";
			this.LauncherIconRadiant.Size = new System.Drawing.Size(16, 16);
			this.LauncherIconRadiant.TabIndex = 10;
			this.LauncherIconRadiant.TabStop = false;
			// 
			// LauncherIconEffectsEditor
			// 
			this.LauncherIconEffectsEditor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconEffectsEditor.BackgroundImage")));
			this.LauncherIconEffectsEditor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.LauncherIconEffectsEditor.Enabled = false;
			this.LauncherIconEffectsEditor.Location = new System.Drawing.Point(12, 18);
			this.LauncherIconEffectsEditor.Name = "LauncherIconEffectsEditor";
			this.LauncherIconEffectsEditor.Size = new System.Drawing.Size(16, 16);
			this.LauncherIconEffectsEditor.TabIndex = 9;
			this.LauncherIconEffectsEditor.TabStop = false;
			// 
			// LauncherIconConverter
			// 
			this.LauncherIconConverter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconConverter.BackgroundImage")));
			this.LauncherIconConverter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.LauncherIconConverter.Enabled = false;
			this.LauncherIconConverter.Location = new System.Drawing.Point(12, 109);
			this.LauncherIconConverter.Name = "LauncherIconConverter";
			this.LauncherIconConverter.Size = new System.Drawing.Size(16, 16);
			this.LauncherIconConverter.TabIndex = 8;
			this.LauncherIconConverter.TabStop = false;
			// 
			// LauncherIconAssetViewer
			// 
			this.LauncherIconAssetViewer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconAssetViewer.BackgroundImage")));
			this.LauncherIconAssetViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.LauncherIconAssetViewer.Enabled = false;
			this.LauncherIconAssetViewer.Location = new System.Drawing.Point(12, 78);
			this.LauncherIconAssetViewer.Name = "LauncherIconAssetViewer";
			this.LauncherIconAssetViewer.Size = new System.Drawing.Size(16, 16);
			this.LauncherIconAssetViewer.TabIndex = 7;
			this.LauncherIconAssetViewer.TabStop = false;
			// 
			// LauncherIconAssetManager
			// 
			this.LauncherIconAssetManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.LauncherIconAssetManager.Enabled = false;
			this.LauncherIconAssetManager.Image = ((System.Drawing.Image)(resources.GetObject("LauncherIconAssetManager.Image")));
			this.LauncherIconAssetManager.Location = new System.Drawing.Point(12, 48);
			this.LauncherIconAssetManager.Name = "LauncherIconAssetManager";
			this.LauncherIconAssetManager.Size = new System.Drawing.Size(16, 16);
			this.LauncherIconAssetManager.TabIndex = 6;
			this.LauncherIconAssetManager.TabStop = false;
			// 
			// LauncherButtonAssetViewer
			// 
			this.LauncherButtonAssetViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherButtonAssetViewer.Location = new System.Drawing.Point(8, 74);
			this.LauncherButtonAssetViewer.Name = "LauncherButtonAssetViewer";
			this.LauncherButtonAssetViewer.Size = new System.Drawing.Size(128, 24);
			this.LauncherButtonAssetViewer.TabIndex = 5;
			this.LauncherButtonAssetViewer.Text = "     Asset Viewer";
			this.LauncherButtonAssetViewer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LauncherAssetViewerToolTip.SetToolTip(this.LauncherButtonAssetViewer, "View converted models");
			this.LauncherButtonAssetViewer.UseVisualStyleBackColor = true;
			this.LauncherButtonAssetViewer.Click += new System.EventHandler(this.LauncherButtonAssetViewer_Click);
			// 
			// LauncherButtonRunConverter
			// 
			this.LauncherButtonRunConverter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherButtonRunConverter.Location = new System.Drawing.Point(8, 105);
			this.LauncherButtonRunConverter.Name = "LauncherButtonRunConverter";
			this.LauncherButtonRunConverter.Size = new System.Drawing.Size(128, 24);
			this.LauncherButtonRunConverter.TabIndex = 3;
			this.LauncherButtonRunConverter.Text = "     Converter";
			this.LauncherButtonRunConverter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LauncherConverterToolTip.SetToolTip(this.LauncherButtonRunConverter, "Convert .GDTs to game data");
			this.LauncherButtonRunConverter.UseVisualStyleBackColor = true;
			this.LauncherButtonRunConverter.Click += new System.EventHandler(this.LauncherButtonRunConverter_Click);
			// 
			// LauncherButtonAssetManager
			// 
			this.LauncherButtonAssetManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherButtonAssetManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LauncherButtonAssetManager.Location = new System.Drawing.Point(8, 44);
			this.LauncherButtonAssetManager.Name = "LauncherButtonAssetManager";
			this.LauncherButtonAssetManager.Size = new System.Drawing.Size(128, 24);
			this.LauncherButtonAssetManager.TabIndex = 2;
			this.LauncherButtonAssetManager.Text = "     Asset Manager";
			this.LauncherButtonAssetManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LauncherAssetManagerToolTip.SetToolTip(this.LauncherButtonAssetManager, "Manage .GDT files");
			this.LauncherButtonAssetManager.UseVisualStyleBackColor = true;
			this.LauncherButtonAssetManager.Click += new System.EventHandler(this.LauncherButtonAssetManager_Click);
			// 
			// LauncherButtonEffectsEd
			// 
			this.LauncherButtonEffectsEd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherButtonEffectsEd.Location = new System.Drawing.Point(7, 14);
			this.LauncherButtonEffectsEd.Name = "LauncherButtonEffectsEd";
			this.LauncherButtonEffectsEd.Size = new System.Drawing.Size(128, 24);
			this.LauncherButtonEffectsEd.TabIndex = 1;
			this.LauncherButtonEffectsEd.Text = "     Effects Editor";
			this.LauncherButtonEffectsEd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LauncherEffectsEdToolTip.SetToolTip(this.LauncherButtonEffectsEd, "Effects Editor");
			this.LauncherButtonEffectsEd.UseVisualStyleBackColor = true;
			this.LauncherButtonEffectsEd.Click += new System.EventHandler(this.LauncherButtonEffectsEd_Click);
			// 
			// LauncherButtonRadiant
			// 
			this.LauncherButtonRadiant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherButtonRadiant.Location = new System.Drawing.Point(8, 135);
			this.LauncherButtonRadiant.Name = "LauncherButtonRadiant";
			this.LauncherButtonRadiant.Size = new System.Drawing.Size(128, 24);
			this.LauncherButtonRadiant.TabIndex = 0;
			this.LauncherButtonRadiant.Text = "     Radiant";
			this.LauncherButtonRadiant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.LauncherRadiantToolTip.SetToolTip(this.LauncherButtonRadiant, "Open Radiant, the level editor");
			this.LauncherButtonRadiant.UseVisualStyleBackColor = true;
			this.LauncherButtonRadiant.Click += new System.EventHandler(this.LauncherButtonRadiant_Click);
			// 
			// LauncherWarningsCounter
			// 
			this.LauncherWarningsCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherWarningsCounter.Location = new System.Drawing.Point(550, 249);
			this.LauncherWarningsCounter.Name = "LauncherWarningsCounter";
			this.LauncherWarningsCounter.Size = new System.Drawing.Size(31, 13);
			this.LauncherWarningsCounter.TabIndex = 25;
			this.LauncherWarningsCounter.Text = "0";
			this.LauncherWarningsCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LauncherWarningsNumericUpDown
			// 
			this.LauncherWarningsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherWarningsNumericUpDown.Location = new System.Drawing.Point(655, 246);
			this.LauncherWarningsNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LauncherWarningsNumericUpDown.Name = "LauncherWarningsNumericUpDown";
			this.LauncherWarningsNumericUpDown.ReadOnly = true;
			this.LauncherWarningsNumericUpDown.Size = new System.Drawing.Size(18, 20);
			this.LauncherWarningsNumericUpDown.TabIndex = 24;
			this.LauncherWarningsNumericUpDown.Visible = false;
			this.LauncherWarningsNumericUpDown.ValueChanged += new System.EventHandler(this.LauncherWarningsNumericUpDown_ValueChanged);
			// 
			// LauncherWarningsPictureBox
			// 
			this.LauncherWarningsPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherWarningsPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherWarningsPictureBox.BackgroundImage")));
			this.LauncherWarningsPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.LauncherWarningsPictureBox.Location = new System.Drawing.Point(635, 248);
			this.LauncherWarningsPictureBox.Name = "LauncherWarningsPictureBox";
			this.LauncherWarningsPictureBox.Size = new System.Drawing.Size(16, 16);
			this.LauncherWarningsPictureBox.TabIndex = 23;
			this.LauncherWarningsPictureBox.TabStop = false;
			// 
			// LauncherWarningsLabel
			// 
			this.LauncherWarningsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherWarningsLabel.AutoSize = true;
			this.LauncherWarningsLabel.Location = new System.Drawing.Point(580, 249);
			this.LauncherWarningsLabel.Name = "LauncherWarningsLabel";
			this.LauncherWarningsLabel.Size = new System.Drawing.Size(52, 13);
			this.LauncherWarningsLabel.TabIndex = 22;
			this.LauncherWarningsLabel.Text = "Warnings";
			this.LauncherWarningsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LauncherErrorsCounter
			// 
			this.LauncherErrorsCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherErrorsCounter.Location = new System.Drawing.Point(679, 249);
			this.LauncherErrorsCounter.Name = "LauncherErrorsCounter";
			this.LauncherErrorsCounter.Size = new System.Drawing.Size(35, 13);
			this.LauncherErrorsCounter.TabIndex = 21;
			this.LauncherErrorsCounter.Text = "0";
			this.LauncherErrorsCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LauncherErrorsNumericUpDown
			// 
			this.LauncherErrorsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherErrorsNumericUpDown.Location = new System.Drawing.Point(770, 246);
			this.LauncherErrorsNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LauncherErrorsNumericUpDown.Name = "LauncherErrorsNumericUpDown";
			this.LauncherErrorsNumericUpDown.ReadOnly = true;
			this.LauncherErrorsNumericUpDown.Size = new System.Drawing.Size(18, 20);
			this.LauncherErrorsNumericUpDown.TabIndex = 20;
			this.LauncherErrorsNumericUpDown.Visible = false;
			this.LauncherErrorsNumericUpDown.ValueChanged += new System.EventHandler(this.LauncherErrorsNumericUpDown_ValueChanged);
			// 
			// LauncherErrorsPictureBox
			// 
			this.LauncherErrorsPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherErrorsPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherErrorsPictureBox.BackgroundImage")));
			this.LauncherErrorsPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.LauncherErrorsPictureBox.Location = new System.Drawing.Point(750, 248);
			this.LauncherErrorsPictureBox.Name = "LauncherErrorsPictureBox";
			this.LauncherErrorsPictureBox.Size = new System.Drawing.Size(16, 16);
			this.LauncherErrorsPictureBox.TabIndex = 19;
			this.LauncherErrorsPictureBox.TabStop = false;
			// 
			// LauncherErrorsLabel
			// 
			this.LauncherErrorsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherErrorsLabel.AutoSize = true;
			this.LauncherErrorsLabel.Location = new System.Drawing.Point(713, 249);
			this.LauncherErrorsLabel.Name = "LauncherErrorsLabel";
			this.LauncherErrorsLabel.Size = new System.Drawing.Size(34, 13);
			this.LauncherErrorsLabel.TabIndex = 18;
			this.LauncherErrorsLabel.Text = "Errors";
			this.LauncherErrorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LauncherScrollBottomConsoleButton
			// 
			this.LauncherScrollBottomConsoleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherScrollBottomConsoleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LauncherScrollBottomConsoleButton.Image = ((System.Drawing.Image)(resources.GetObject("LauncherScrollBottomConsoleButton.Image")));
			this.LauncherScrollBottomConsoleButton.Location = new System.Drawing.Point(924, 244);
			this.LauncherScrollBottomConsoleButton.Name = "LauncherScrollBottomConsoleButton";
			this.LauncherScrollBottomConsoleButton.Size = new System.Drawing.Size(27, 23);
			this.LauncherScrollBottomConsoleButton.TabIndex = 17;
			this.LauncherScrollBottomConsoleToolTip.SetToolTip(this.LauncherScrollBottomConsoleButton, "Scroll to end");
			this.LauncherScrollBottomConsoleButton.UseVisualStyleBackColor = true;
			this.LauncherScrollBottomConsoleButton.Click += new System.EventHandler(this.LauncherScrollBottomConsoleButton_Click);
			// 
			// LauncherSaveConsoleButton
			// 
			this.LauncherSaveConsoleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherSaveConsoleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.LauncherSaveConsoleButton.Image = ((System.Drawing.Image)(resources.GetObject("LauncherSaveConsoleButton.Image")));
			this.LauncherSaveConsoleButton.Location = new System.Drawing.Point(794, 244);
			this.LauncherSaveConsoleButton.Name = "LauncherSaveConsoleButton";
			this.LauncherSaveConsoleButton.Size = new System.Drawing.Size(27, 23);
			this.LauncherSaveConsoleButton.TabIndex = 16;
			this.SaveConsoleToolTip.SetToolTip(this.LauncherSaveConsoleButton, "Save console to file");
			this.LauncherSaveConsoleButton.UseVisualStyleBackColor = true;
			this.LauncherSaveConsoleButton.Click += new System.EventHandler(this.LauncherSaveConsoleButton_Click);
			// 
			// LauncherProcessTimeElapsedTextBox
			// 
			this.LauncherProcessTimeElapsedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherProcessTimeElapsedTextBox.Location = new System.Drawing.Point(489, 246);
			this.LauncherProcessTimeElapsedTextBox.Name = "LauncherProcessTimeElapsedTextBox";
			this.LauncherProcessTimeElapsedTextBox.ReadOnly = true;
			this.LauncherProcessTimeElapsedTextBox.Size = new System.Drawing.Size(55, 20);
			this.LauncherProcessTimeElapsedTextBox.TabIndex = 4;
			// 
			// LauncherClearConsoleButton
			// 
			this.LauncherClearConsoleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherClearConsoleButton.Location = new System.Drawing.Point(827, 244);
			this.LauncherClearConsoleButton.Name = "LauncherClearConsoleButton";
			this.LauncherClearConsoleButton.Size = new System.Drawing.Size(86, 23);
			this.LauncherClearConsoleButton.TabIndex = 13;
			this.LauncherClearConsoleButton.Text = "Clear Console";
			this.LauncherClearConsoleButton.UseVisualStyleBackColor = true;
			this.LauncherClearConsoleButton.Click += new System.EventHandler(this.LauncherClearConsoleButton_Click);
			// 
			// LauncherProcessGroupBox
			// 
			this.LauncherProcessGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.LauncherProcessGroupBox.Controls.Add(this.LauncherButtonCancel);
			this.LauncherProcessGroupBox.Controls.Add(this.LauncherProcessList);
			this.LauncherProcessGroupBox.Location = new System.Drawing.Point(3, 3);
			this.LauncherProcessGroupBox.Name = "LauncherProcessGroupBox";
			this.LauncherProcessGroupBox.Size = new System.Drawing.Size(140, 263);
			this.LauncherProcessGroupBox.TabIndex = 2;
			this.LauncherProcessGroupBox.TabStop = false;
			this.LauncherProcessGroupBox.Text = "Processes";
			// 
			// LauncherButtonCancel
			// 
			this.LauncherButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherButtonCancel.BackColor = System.Drawing.Color.LightCoral;
			this.LauncherButtonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LauncherButtonCancel.ForeColor = System.Drawing.SystemColors.Info;
			this.LauncherButtonCancel.Location = new System.Drawing.Point(6, 192);
			this.LauncherButtonCancel.Name = "LauncherButtonCancel";
			this.LauncherButtonCancel.Size = new System.Drawing.Size(128, 65);
			this.LauncherButtonCancel.TabIndex = 4;
			this.LauncherButtonCancel.Text = "Cancel";
			this.LauncherButtonCancel.UseVisualStyleBackColor = false;
			this.LauncherButtonCancel.Click += new System.EventHandler(this.LauncherButtonCancel_Click);
			// 
			// LauncherProcessList
			// 
			this.LauncherProcessList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherProcessList.BackColor = System.Drawing.SystemColors.Info;
			this.LauncherProcessList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LauncherProcessList.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LauncherProcessList.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.LauncherProcessList.FormattingEnabled = true;
			this.LauncherProcessList.IntegralHeight = false;
			this.LauncherProcessList.ItemHeight = 11;
			this.LauncherProcessList.Location = new System.Drawing.Point(6, 19);
			this.LauncherProcessList.Name = "LauncherProcessList";
			this.LauncherProcessList.Size = new System.Drawing.Size(128, 167);
			this.LauncherProcessList.TabIndex = 1;
			this.LauncherProcessList.SelectedIndexChanged += new System.EventHandler(this.LauncherProcessList_SelectedIndexChanged);
			// 
			// LauncherProcessTextBox
			// 
			this.LauncherProcessTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LauncherProcessTextBox.Location = new System.Drawing.Point(149, 246);
			this.LauncherProcessTextBox.Name = "LauncherProcessTextBox";
			this.LauncherProcessTextBox.ReadOnly = true;
			this.LauncherProcessTextBox.Size = new System.Drawing.Size(334, 20);
			this.LauncherProcessTextBox.TabIndex = 11;
			// 
			// LauncherTimer
			// 
			this.LauncherTimer.Enabled = true;
			this.LauncherTimer.Interval = 1000;
			this.LauncherTimer.Tick += new System.EventHandler(this.LauncherTimer_Tick);
			// 
			// LauncherMapFilesSystemWatcher
			// 
			this.LauncherMapFilesSystemWatcher.EnableRaisingEvents = true;
			this.LauncherMapFilesSystemWatcher.Filter = "*.map";
			this.LauncherMapFilesSystemWatcher.NotifyFilter = System.IO.NotifyFilters.FileName;
			this.LauncherMapFilesSystemWatcher.SynchronizingObject = this;
			this.LauncherMapFilesSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.LauncherMapFilesSystemWatcher_Changed);
			this.LauncherMapFilesSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.LauncherMapFilesSystemWatcher_Created);
			this.LauncherMapFilesSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.LauncherMapFilesSystemWatcher_Deleted);
			this.LauncherMapFilesSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.LauncherMapFilesSystemWatcher_Renamed);
			// 
			// LauncherModsDirectorySystemWatcher
			// 
			this.LauncherModsDirectorySystemWatcher.EnableRaisingEvents = true;
			this.LauncherModsDirectorySystemWatcher.NotifyFilter = System.IO.NotifyFilters.DirectoryName;
			this.LauncherModsDirectorySystemWatcher.SynchronizingObject = this;
			this.LauncherModsDirectorySystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.LauncherModsDirectorySystemWatcher_Changed);
			this.LauncherModsDirectorySystemWatcher.Created += new System.IO.FileSystemEventHandler(this.LauncherModsDirectorySystemWatcher_Created);
			this.LauncherModsDirectorySystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.LauncherModsDirectorySystemWatcher_Deleted);
			this.LauncherModsDirectorySystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.LauncherModsDirectorySystemWatcher_Renamed);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LauncherfileToolStripMenuItem,
            this.LauncherdocsToolStripMenuItem,
            this.LaunchertoolsToolStripMenuItem,
            this.LauncherhelpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(978, 24);
			this.menuStrip1.TabIndex = 9;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// LauncherfileToolStripMenuItem
			// 
			this.LauncherfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newModToolStripMenuItem,
            this.LaunchernewMapToolStripMenuItem,
            this.toolStripSeparator3,
            this.gameDirToolStripMenuItem,
            this.toolStripSeparator1,
            this.LauncherexitToolStripMenuItem});
			this.LauncherfileToolStripMenuItem.Name = "LauncherfileToolStripMenuItem";
			this.LauncherfileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.LauncherfileToolStripMenuItem.Text = "File";
			// 
			// newModToolStripMenuItem
			// 
			this.newModToolStripMenuItem.Name = "newModToolStripMenuItem";
			this.newModToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.newModToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.newModToolStripMenuItem.Text = "New mod...";
			this.newModToolStripMenuItem.Click += new System.EventHandler(this.newModToolStripMenuItem_Click);
			// 
			// LaunchernewMapToolStripMenuItem
			// 
			this.LaunchernewMapToolStripMenuItem.Name = "LaunchernewMapToolStripMenuItem";
			this.LaunchernewMapToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.LaunchernewMapToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.LaunchernewMapToolStripMenuItem.Text = "New map...";
			this.LaunchernewMapToolStripMenuItem.Visible = false;
			this.LaunchernewMapToolStripMenuItem.Click += new System.EventHandler(this.LaunchernewMapToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
			// 
			// gameDirToolStripMenuItem
			// 
			this.gameDirToolStripMenuItem.Name = "gameDirToolStripMenuItem";
			this.gameDirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.gameDirToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.gameDirToolStripMenuItem.Text = "View Game Dir";
			this.gameDirToolStripMenuItem.Click += new System.EventHandler(this.gameDirToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
			// 
			// LauncherexitToolStripMenuItem
			// 
			this.LauncherexitToolStripMenuItem.Name = "LauncherexitToolStripMenuItem";
			this.LauncherexitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.LauncherexitToolStripMenuItem.Text = "Exit";
			this.LauncherexitToolStripMenuItem.Click += new System.EventHandler(this.LauncherexitToolStripMenuItem_Click);
			// 
			// LauncherdocsToolStripMenuItem
			// 
			this.LauncherdocsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mayaExporterToolStripMenuItem,
            this.exporterTutorialToolStripMenuItem});
			this.LauncherdocsToolStripMenuItem.Name = "LauncherdocsToolStripMenuItem";
			this.LauncherdocsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.LauncherdocsToolStripMenuItem.Text = "Docs";
			// 
			// mayaExporterToolStripMenuItem
			// 
			this.mayaExporterToolStripMenuItem.Name = "mayaExporterToolStripMenuItem";
			this.mayaExporterToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.mayaExporterToolStripMenuItem.Text = "Maya CoDTools";
			this.mayaExporterToolStripMenuItem.Click += new System.EventHandler(this.mayaExporterToolStripMenuItem_Click);
			// 
			// exporterTutorialToolStripMenuItem
			// 
			this.exporterTutorialToolStripMenuItem.Name = "exporterTutorialToolStripMenuItem";
			this.exporterTutorialToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.exporterTutorialToolStripMenuItem.Text = "Exporter Tutorial";
			this.exporterTutorialToolStripMenuItem.Click += new System.EventHandler(this.exporterTutorialToolStripMenuItem_Click);
			// 
			// LaunchertoolsToolStripMenuItem
			// 
			this.LaunchertoolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mayaPluginSetupToolStripMenuItem});
			this.LaunchertoolsToolStripMenuItem.Name = "LaunchertoolsToolStripMenuItem";
			this.LaunchertoolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.LaunchertoolsToolStripMenuItem.Text = "Tools";
			// 
			// mayaPluginSetupToolStripMenuItem
			// 
			this.mayaPluginSetupToolStripMenuItem.Name = "mayaPluginSetupToolStripMenuItem";
			this.mayaPluginSetupToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.mayaPluginSetupToolStripMenuItem.Text = "Maya Plugin Setup";
			this.mayaPluginSetupToolStripMenuItem.Click += new System.EventHandler(this.mayaPluginSetupToolStripMenuItem_Click);
			// 
			// LauncherhelpToolStripMenuItem
			// 
			this.LauncherhelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LauncherwikiToolStripMenuItem});
			this.LauncherhelpToolStripMenuItem.Name = "LauncherhelpToolStripMenuItem";
			this.LauncherhelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.LauncherhelpToolStripMenuItem.Text = "Help";
			// 
			// LauncherwikiToolStripMenuItem
			// 
			this.LauncherwikiToolStripMenuItem.Name = "LauncherwikiToolStripMenuItem";
			this.LauncherwikiToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.LauncherwikiToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.LauncherwikiToolStripMenuItem.Text = "Wiki";
			this.LauncherwikiToolStripMenuItem.Click += new System.EventHandler(this.LauncherwikiToolStripMenuItem_Click);
			// 
			// LauncherMapListContextMenuStrip
			// 
			this.LauncherMapListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem});
			this.LauncherMapListContextMenuStrip.Name = "LauncherMapListContextMenuStrip";
			this.LauncherMapListContextMenuStrip.Size = new System.Drawing.Size(118, 98);
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.runToolStripMenuItem.Text = "&Run";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.editToolStripMenuItem.Text = "&Edit";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(114, 6);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.deleteToolStripMenuItem.Text = "&Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// renameToolStripMenuItem
			// 
			this.renameToolStripMenuItem.Enabled = false;
			this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.renameToolStripMenuItem.Text = "Re&name";
			// 
			// LauncherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(978, 688);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.LauncherSplitter);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LauncherForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Launcher";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LauncherForm_FormClosing);
			this.Load += new System.EventHandler(this.LauncherForm_Load);
			this.LauncherSplitter.Panel1.ResumeLayout(false);
			this.LauncherSplitter.Panel1.PerformLayout();
			this.LauncherSplitter.Panel2.ResumeLayout(false);
			this.LauncherSplitter.Panel2.PerformLayout();
			this.LauncherSplitter.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.LauncherRunGameCustomCommandLineGroupBox.ResumeLayout(false);
			this.LauncherRunGameCustomCommandLineGroupBox.PerformLayout();
			this.LauncherRunGameGroupBox.ResumeLayout(false);
			this.LauncherRunGameGroupBox.PerformLayout();
			this.LauncherRunGameCustomCommandLineMPGroupBox.ResumeLayout(false);
			this.LauncherRunGameCustomCommandLineMPGroupBox.PerformLayout();
			this.LauncherRunGameModGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconBlops)).EndInit();
			this.LauncherGameGroupBox.ResumeLayout(false);
			this.LauncherGameGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconMP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconSP)).EndInit();
			this.LauncherTab.ResumeLayout(false);
			this.LauncherTabModBuilder.ResumeLayout(false);
			this.LauncherIwdFileGroupBox.ResumeLayout(false);
			this.LauncherModGroupBox.ResumeLayout(false);
			this.LauncherModFolderGroupBox.ResumeLayout(false);
			this.LauncherModBuildGroupBox.ResumeLayout(false);
			this.LauncherModBuildGroupBox.PerformLayout();
			this.LauncherModZoneSourceGroupBox.ResumeLayout(false);
			this.LauncherTabCompileLevel.ResumeLayout(false);
			this.LauncherTabCompileLevel.PerformLayout();
			this.LauncherCompileLevelOptionsGroupBox.ResumeLayout(false);
			this.LauncherCompileLevelOptionsGroupBox.PerformLayout();
			this.LauncherGridFileGroupBox.ResumeLayout(false);
			this.LauncherGridFileGroupBox.PerformLayout();
			this.LauncherTabExplore.ResumeLayout(false);
			this.LauncherExploreGroupBox.ResumeLayout(false);
			this.LauncherExploreRawMapsDirGroupBox.ResumeLayout(false);
			this.LauncherExploreRawDirGroupBox.ResumeLayout(false);
			this.LauncherExploreDevDirGroupBox.ResumeLayout(false);
			this.LauncherExploreBlopsDirGroupBox.ResumeLayout(false);
			this.LauncherApplicationsGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconRadiant)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconEffectsEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconConverter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconAssetViewer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherIconAssetManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherWarningsNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherWarningsPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherErrorsNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherErrorsPictureBox)).EndInit();
			this.LauncherProcessGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.LauncherMapFilesSystemWatcher)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LauncherModsDirectorySystemWatcher)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.LauncherMapListContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    private bool IsMP() => LauncherCS.Launcher.IsMP(this.mapName);

    private void LauncherButtonAssetManager_Click(object sender, EventArgs e)
    {
      this.LaunchProcess("asset_manager", "", (string) null, false, (LauncherForm.ProcessFinishedDelegate) null);
    }

    private void LauncherButtonAssetViewer_Click(object sender, EventArgs e)
    {
      this.LaunchProcess("AssetViewer", "", (string) null, false, (LauncherForm.ProcessFinishedDelegate) null);
    }

    private void LauncherButtonCancel_Click(object sender, EventArgs e)
    {
      int selectedIndex = this.LauncherProcessList.SelectedIndex;
      if (selectedIndex < 0)
        return;
      ((Process) ((DictionaryEntry) this.processList[selectedIndex]).Key).Kill();
    }

    private void LauncherButtonCreateMap_Click(object sender, EventArgs e)
    {
      if (new CreateMapForm().ShowDialog() != DialogResult.OK)
        return;
      this.UpdateMapList();
      this.EnableMapList();
    }

    private void LauncherButtonEffectsEd_Click(object sender, EventArgs e)
    {
      this.LaunchProcess("EffectsEd3", "", (string) null, false, (LauncherForm.ProcessFinishedDelegate) null);
    }

    private void LauncherButtonMP_Click(object sender, EventArgs e)
    {
      string arguments = "";
      if (this.LauncherGameDeveloperBox.Checked)
        arguments += "+set developer 1 +set developer_script 1 ";
      if (this.LauncherGameLogfileBox.Checked)
        arguments += "+set logfile 1 ";
      this.LaunchProcess(LauncherCS.Launcher.GetGameApplication(true), arguments, (string) null, false, (LauncherForm.ProcessFinishedDelegate) null);
    }

    private void LauncherButtonRadiant_Click(object sender, EventArgs e)
    {
      this.LaunchProcess("CoDBORadiant", this.mapName != null ? Path.Combine(LauncherCS.Launcher.GetMapSourceDirectory(), this.mapName + ".map") : "", (string) null, false, (LauncherForm.ProcessFinishedDelegate) null);
    }

    private void LauncherButtonRunConverter_Click(object sender, EventArgs eventArgs)
    {
      this.LaunchProcess("converter", "-nopause -n -nospam", (string) null, true, (LauncherForm.ProcessFinishedDelegate) null);
    }

    private void LauncherButtonSP_Click(object sender, EventArgs e)
    {
      string arguments = "";
      if (this.LauncherGameDeveloperBox.Checked)
        arguments += "+set developer 1";
      if (this.LauncherGameLogfileBox.Checked)
        arguments += "+set logfile 1 ";
      this.LaunchProcess(LauncherCS.Launcher.GetGameApplication(false), arguments, (string) null, false, (LauncherForm.ProcessFinishedDelegate) null);
    }

		private void LauncherClearConsoleButton_Click(object sender, EventArgs e)
		{
			LauncherErrorsCounter.Text = "0";
			LauncherErrorsPictureBox.BackgroundImage = Properties.Resources.error_grey;
			LauncherWarningsCounter.Text = "0";
			LauncherWarningsPictureBox.BackgroundImage = Properties.Resources.warning_grey;
			LauncherConsole.Clear();
		}

		private void LauncherCompileBSPButton_Click(object sender, EventArgs e)
    {
      int num = (int) new LightOptionsForm().ShowDialog();
    }

    private void LauncherCompileLevelButton_Click(object sender, EventArgs e)
    {
      this.CompileLevel();
    }

    private void LauncherCompileLightsButton_Click(object sender, EventArgs e)
    {
      int num = (int) new BspOptionsForm().ShowDialog();
    }

    private void LauncherCompileLightsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      LauncherCS.Launcher.mapSettings.SetDecimal("lightoptions_quality", 20M);
    }

    private void LauncherCreateMap_Click(object sender, EventArgs e)
    {
      if (new CreateMapForm().ShowDialog() != DialogResult.OK)
        return;
      this.UpdateMapList();
      this.EnableMapList();
    }

    private void LauncherDeleteMap_Click(object sender, EventArgs e)
    {
      string[] mapFiles1 = LauncherCS.Launcher.GetMapFiles(this.mapName);
      if (DialogResult.Yes != MessageBox.Show("The following files would be deleted:\n\n" + LauncherCS.Launcher.StringArrayToString(mapFiles1), "Are you sure you want to delete these files?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
        return;
      foreach (string fileName in mapFiles1)
        LauncherCS.Launcher.DeleteFile(fileName);
      string[] mapFiles2 = LauncherCS.Launcher.GetMapFiles(this.mapName);
      if (mapFiles2.Length != 0)
      {
        int num = (int) MessageBox.Show("Could not delete the following files:\n\n" + LauncherCS.Launcher.StringArrayToString(mapFiles2), "Error deleting files", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      this.UpdateMapList();
      this.EnableMapList();
      this.LauncherModSpecificMapComboBox.SelectedIndex = -1;
    }

    private void LauncherEditZoneSourceButton_Click(object sender, EventArgs e)
    {
      int num = (int) new ZoneSourceForm(this.LauncherModComboBox.SelectedItem.ToString()).ShowDialog();
    }

    private void LauncherErrorsNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
      if (Convert.ToInt32(this.LauncherErrorsCounter.Text) <= 0)
        return;
      this.LauncherConsole.SelectionStart = this.LauncherErrorsNumericUpDown.Value != 0M ? this.FindLauncherConsoleText("ERROR:", this.LauncherConsole.SelectionStart + this.LauncherConsole.SelectionLength, this.LauncherConsole.Text.Length) : this.FindLauncherConsoleText("ERROR:", 0, this.LauncherConsole.SelectionStart);
    }

    private void LauncherexitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void LauncherExploreBlopsDirConfigsButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "players\\");
    }

    private void LauncherExploreBlopsDirGameButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory());
    }

    private void LauncherExploreBlopsDirModsButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "mods\\");
    }

    private void LauncherExploreDevDirBinButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "bin\\");
    }

    private void LauncherExploreDevDirMapSrcButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "map_source\\");
    }

    private void LauncherExploreDevDirModelExportButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "model_export\\");
    }

    private void LauncherExploreDevDirRawButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\");
    }

    private void LauncherExploreDevDirSrcDataButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "source_data\\");
    }

    private void LauncherExploreDevDirTextureAssetsButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "texture_assets\\");
    }

    private void LauncherExploreDevDirZoneSourceButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "zone_source\\");
    }

    private void LauncherExploreRawDirAnimTreesButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\animtrees\\");
    }

    private void LauncherExploreRawDirCSCButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\clientscripts\\");
    }

    private void LauncherExploreRawDirFXButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\fx\\");
    }

    private void LauncherExploreRawDirGSCButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\maps\\");
    }

    private void LauncherExploreRawDirLocsButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\english\\localizedstrings\\");
    }

    private void LauncherExploreRawDirMPButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\mp\\");
    }

    private void LauncherExploreRawDirSoundAliasesButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\soundaliases\\");
    }

    private void LauncherExploreRawDirVisionButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\vision\\");
    }

    private void LauncherExploreRawDirWeaponsButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\weapons\\");
    }

    private void LauncherExploreRawGSCDirMPArtButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\maps\\mp\\createart\\");
    }

    private void LauncherExploreRawGSCDirMPButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\maps\\mp\\");
    }

    private void LauncherExploreRawGSCDirMPFXButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\maps\\mp\\createfx\\");
    }

    private void LauncherExploreRawGSCDirMPGametypesButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\maps\\mp\\gametypes\\");
    }

    private void LauncherExploreRawGSCDirSPArtButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\maps\\createart\\");
    }

    private void LauncherExploreRawGSCDirSPButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\maps\\");
    }

    private void LauncherExploreRawGSCDirSPFXButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\maps\\createfx\\");
    }

    private void LauncherExploreRawGSCDirSPGametypesButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\maps\\gametypes\\");
    }

    private void LauncherExploreRawGSCDirSPVoiceButton_Click(object sender, EventArgs e)
    {
      this.ExploreOpenDir(LauncherCS.Launcher.GetRootDirectory() + "raw\\maps\\voice\\");
    }

    private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.processTable.Count != 0)
      {
        switch (MessageBox.Show("But there are still processes running!\n\nDo you want to close them, or cancel exiting from the application?", "Application will exit!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
        {
          case DialogResult.Cancel:
            e.Cancel = true;
            return;
          case DialogResult.Yes:
            IDictionaryEnumerator enumerator = this.processTable.GetEnumerator();
            try
            {
              while (enumerator.MoveNext())
                ((Process) ((DictionaryEntry) enumerator.Current).Key).Kill();
              break;
            }
            finally
            {
              if (enumerator is IDisposable disposable)
                disposable.Dispose();
            }
          default:
            string[] stringArray = new string[this.processTable.Count];
            int index = 0;
            foreach (DictionaryEntry dictionaryEntry in this.processTable)
            {
              try
              {
                stringArray[index] = ((Process) dictionaryEntry.Key).MainModule.FileName;
              }
              catch
              {
                stringArray[index] = (string) dictionaryEntry.Value;
              }
              ++index;
            }
            if (stringArray.Length != 0)
            {
              int num = (int) MessageBox.Show("The following processes are still active:\n\n" + LauncherCS.Launcher.StringArrayToString(stringArray) + "\nPlease close them if neccessary using the Task Manager, or similar program!\n", "Note before exiting the application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              break;
            }
            break;
        }
      }
      this.UpdateMapSettings();
      this.UpdateModSettings();
      LauncherCS.Launcher.SaveLauncherSettings(LauncherCS.Launcher.launcherSettings.Get());
    }

    private void LauncherForm_Load(object sender, EventArgs e)
    {
      this.UpdateDVars();
      this.UpdateMapList();
      this.UpdateModList();
      this.EnableMapList();
      this.UpdateStopProcessButton();
      this.LauncherMapFilesSystemWatcher.Path = LauncherCS.Launcher.GetMapSourceDirectory();
      this.LauncherModsDirectorySystemWatcher.Path = LauncherCS.Launcher.GetModsDirectory();
      this.LauncherMapFilesSystemWatcher.EnableRaisingEvents = true;
      this.LauncherModsDirectorySystemWatcher.EnableRaisingEvents = true;
      LauncherForm launcherForm = this;
      launcherForm.Text = launcherForm.Text + " - " + LauncherCS.Launcher.GetRootDirectory();
      this.SetModSelection(LauncherCS.Launcher.launcherSettings.GetString("active_mod"), true);
    }

    private void LauncherGameOptionsFlowPanel_Click(object sender, EventArgs e)
    {
      MouseEventArgs mouseEventArgs = (MouseEventArgs) e;
      Control control = (Control) sender;
      if (mouseEventArgs.Button != MouseButtons.Right)
        return;
      ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
      contextMenuStrip.Items.Add("Edit dvar");
      contextMenuStrip.Items.Add("Remove dvar");
      contextMenuStrip.Items.Add("Add new dvar");
      contextMenuStrip.Items.Add("Duplicate dvar");
      contextMenuStrip.Show(control.PointToScreen(mouseEventArgs.Location));
    }

    private void LauncherGridEditExistingButton_Click(object sender, EventArgs e)
    {
      this.BuildGridDelegate(2);
    }

    private void LauncherGridMakeNewButton_Click(object sender, EventArgs e)
    {
      this.BuildGridDelegate(1);
    }

    private void LauncherIwdFileTree_AfterCheck(object sender, TreeViewEventArgs e)
    {
      this.LauncherIwdFileTreeBeginUpdate();
      this.RecursiveCheckNodesDown(e.Node.Nodes, e.Node.Checked);
      if (e.Node.Checked)
        this.RecursiveCheckNodesUp(e.Node.Parent, e.Node.Checked);
      this.LauncherIwdFileTreeEndUpdate();
    }

    private void LauncherIwdFileTree_DoubleClick(object sender, EventArgs e)
    {
      if (this.LauncherIwdFileTree.SelectedNode == null)
        return;
      try
      {
        new Process()
        {
          StartInfo = {
            ErrorDialog = true,
            FileName = Path.Combine(LauncherCS.Launcher.GetModDirectory(this.modName), this.LauncherIwdFileTree.SelectedNode.FullPath)
          }
        }.Start();
      }
      catch
      {
      }
    }

    private void LauncherIwdFileTreeBeginUpdate()
    {
      this.LauncherIwdFileTree.BeginUpdate();
      this.LauncherIwdFileTree.AfterCheck -= new TreeViewEventHandler(this.LauncherIwdFileTree_AfterCheck);
    }

    private void LauncherIwdFileTreeEndUpdate()
    {
      this.LauncherIwdFileTree.AfterCheck += new TreeViewEventHandler(this.LauncherIwdFileTree_AfterCheck);
      this.LauncherIwdFileTree.EndUpdate();
    }

    private void LauncherMapFilesSystemWatcher_Changed(object sender, FileSystemEventArgs e)
    {
      this.UpdateMapList();
    }

    private void LauncherMapFilesSystemWatcher_Created(object sender, FileSystemEventArgs e)
    {
      this.UpdateMapList();
    }

    private void LauncherMapFilesSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
    {
      this.UpdateMapList();
    }

    private void LauncherMapFilesSystemWatcher_Renamed(object sender, RenamedEventArgs e)
    {
      this.UpdateMapList();
    }

    private void LauncherMapList_DoubleClick(object sender, EventArgs e)
    {
      this.LauncherMapList.SelectedItem = (object) null;
    }

    private void LauncherMapList_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.UpdateMapSettings();
      this.EnableMapList();
      this.LauncherRunGameMapNameTextBox.Text = this.LauncherMapList.SelectedItem != null ? this.LauncherMapList.SelectedItem.ToString() : "";
    }

    private void LauncherMapList_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;
      for (int index = 0; index < this.LauncherMapList.Items.Count; ++index)
      {
        if (this.LauncherMapList.GetItemRectangle(index).Contains(e.Location))
          this.LauncherMapList_WaitingForMouseUp = index;
      }
    }

    private void LauncherMapList_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right && this.LauncherMapList_WaitingForMouseUp != -1)
      {
        for (int index = 0; index < this.LauncherMapList.Items.Count; ++index)
        {
          if (this.LauncherMapList.GetItemRectangle(index).Contains(e.Location) && this.LauncherMapList_WaitingForMouseUp == index)
          {
            this.LauncherMapListContextMenu_Map = index;
            this.LauncherMapList.SelectedIndex = index;
            this.LauncherMapListContextMenuStrip.Show(Cursor.Position);
          }
        }
      }
      this.LauncherMapList_WaitingForMouseUp = -1;
    }

    private void LauncherMapTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.UpdateMapList();
    }

    private void LauncherModBuildButton_Click(object sender, EventArgs e)
    {
      this.LauncherModComboBoxApplySettings();
      this.UpdateModSettings();
      this.ModBuildStart();
    }

    private void LauncherModComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      LauncherCS.Launcher.launcherSettings.SetString("active_mod", this.LauncherModComboBox.Text);
      this.LauncherModComboBoxApplySettings(load: false);
      this.UpdateModSettings();
      this.LauncherModComboBoxApplySettings(false);
    }

    private void LauncherModComboBoxApplySettings(bool save = true, bool load = true)
    {
      bool flag = this.LauncherModComboBox.SelectedItem != null;
      this.LauncherModZoneSourceGroupBox.Enabled = flag;
      this.LauncherModBuildGroupBox.Enabled = flag;
      this.LauncherModFolderGroupBox.Enabled = flag;
      this.LauncherIwdFileGroupBox.Enabled = flag;
      this.LauncherIwdFileTreeBeginUpdate();
      if (save && this.modName != null && Directory.Exists(LauncherCS.Launcher.GetModDirectory(this.modName, false)))
        LauncherCS.Launcher.SaveTextFile(Path.Combine(LauncherCS.Launcher.GetModDirectory(this.modName), this.modName + ".files"), LauncherCS.Launcher.HashTableToStringArray(this.TreeViewToHashTable(this.LauncherIwdFileTree.Nodes)));
      if (load && this.LauncherModComboBox.SelectedItem != null)
      {
        this.modName = this.LauncherModComboBox.SelectedItem.ToString();
        string textFile = Path.Combine(LauncherCS.Launcher.GetModDirectory(this.modName), this.modName + ".files");
        this.LauncherIwdFileTree.Nodes.Clear();
        this.AddFilesToTreeView(LauncherCS.Launcher.GetModDirectory(this.modName), this.LauncherIwdFileTree.Nodes, true);
        this.HashTableToTreeView(LauncherCS.Launcher.StringArrayToHashTable(LauncherCS.Launcher.LoadTextFile(textFile)), this.LauncherIwdFileTree.Nodes);
      }
      this.LauncherIwdFileTreeEndUpdate();
    }

    private void LauncherModFolderViewButton_Click(object sender, EventArgs e)
    {
      Process.Start(LauncherCS.Launcher.GetModDirectory(this.LauncherModComboBox.SelectedItem.ToString()));
    }

    private void LauncherModsDirectorySystemWatcher_Changed(object sender, FileSystemEventArgs e)
    {
      this.UpdateModList();
    }

    private void LauncherModsDirectorySystemWatcher_Created(object sender, FileSystemEventArgs e)
    {
      this.UpdateModList();
    }

    private void LauncherModsDirectorySystemWatcher_Deleted(object sender, FileSystemEventArgs e)
    {
      this.UpdateModList();
    }

    private void LauncherModsDirectorySystemWatcher_Renamed(object sender, RenamedEventArgs e)
    {
      this.UpdateModList();
    }

    private void LauncherModZoneSourceCSVButton_Click(object sender, EventArgs e)
    {
      string str = Path.Combine(LauncherCS.Launcher.GetModDirectory(this.LauncherModComboBox.SelectedItem.ToString()), "mod.csv");
      if (!File.Exists(str))
        File.Create(str).Close();
      Process.Start(str);
    }

    private void LauncherModZoneSourceMissingAssetsButton_Click(object sender, EventArgs e)
    {
      string str = Path.Combine(LauncherCS.Launcher.GetModDirectory(this.LauncherModComboBox.SelectedItem.ToString()), "missingasset.csv");
      if (File.Exists(str))
      {
        Process.Start(str);
      }
      else
      {
        int num = (int) MessageBox.Show("Could not find missingasset.csv for mod.\nRun the mod with Developer mode to generate it.", "Error");
      }
    }

    private void LaunchernewMapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (new CreateMapForm().ShowDialog() != DialogResult.OK)
        return;
      this.UpdateMapList();
      this.EnableMapList();
    }

    private void LauncherProcessList_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.UpdateStopProcessButton();
    }

    private void LauncherRunGameButton_Click(object sender, EventArgs e)
    {
      foreach (ComboBox dvarComboBox in this.dvarComboBoxes)
      {
        string str1 = dvarComboBox.Text.Trim();
        if (str1 != "")
        {
          foreach (string str2 in dvarComboBox.Items)
          {
            if (!(str1.ToLower() != str2.ToLower()))
            {
              str1 = "";
              break;
            }
          }
        }
        if (str1 != "")
          dvarComboBox.Items.Add((object) dvarComboBox.Text);
      }
      string arguments = this.GetGameOptions();
      if (this.LauncherRunGameDeveloperBox.Checked)
        arguments += "+set developer 1 ";
      if (this.LauncherRunGameLogfileBox.Checked)
        arguments += "+set logfile 1 ";
      if (this.LauncherRunGameMapNameTextBox.Text.Length > 0)
        arguments = arguments + "+devmap " + this.LauncherRunGameMapNameTextBox.Text + " ";
      bool mpVersion = false;
      if (this.LauncherRunGameMapNameTextBox.Text.StartsWith("mp_") || this.LauncherRunGameModComboBox.Text.StartsWith("mp_"))
        mpVersion = true;
      if (mpVersion && this.LauncherRunGameCustomCommandLineMPCheckBox.Checked)
        arguments += this.LauncherRunGameCustomCommandLineMPTextBox.Text;
      else if (!mpVersion && this.LauncherRunGameCustomCommandLineCheckBox.Checked)
        arguments += this.LauncherRunGameCustomCommandLineTextBox.Text;
      this.LaunchProcess(LauncherCS.Launcher.GetGameApplication(mpVersion), arguments, (string) null, false, (LauncherForm.ProcessFinishedDelegate) null);
    }

    private void LauncherRunGameCustomCommandLineTextBox_TextChanged(object sender, EventArgs e)
    {
    }

    private void LauncherRunGameCustomCommandLineTextBox_Validating(
      object sender,
      CancelEventArgs e)
    {
    }

    private void LauncherSaveConsoleButton_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();
      saveFileDialog1.Filter = "Rich Text File|*.rtf|Text File|*.txt|Log File|*.log";
      saveFileDialog1.Title = "Save console log";
      SaveFileDialog saveFileDialog2 = saveFileDialog1;
      int num = (int) saveFileDialog2.ShowDialog();
      if (!(saveFileDialog2.FileName != ""))
        return;
      if (Path.GetExtension(saveFileDialog2.FileName) == ".rtf")
        this.LauncherConsole.SaveFile(saveFileDialog2.FileName, RichTextBoxStreamType.RichText);
      else
        File.WriteAllText(saveFileDialog2.FileName, this.LauncherConsole.Text);
    }

    private void LauncherscriptToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start(LauncherCS.Launcher.GetRootDirectory() + "/docs/script_docs/scriptFunctions/index.htm");
    }

    private void LauncherScrollBottomConsoleButton_Click(object sender, EventArgs e)
    {
      this.LauncherConsole.SelectionStart = this.LauncherConsole.Text.Length;
      this.LauncherConsole.ScrollToCaret();
    }

    private void LauncherTimer_Tick(object sender, EventArgs e)
    {
      if (this.consoleProcess != null)
        this.LauncherProcessTimeElapsedTextBox.Text = (DateTime.Now - this.consoleProcessStartTime).ToString().Substring(0, 8);
      string gameOptions = this.GetGameOptions();
      if (!(this.LauncherRunGameCommandLineTextBox.Text != gameOptions))
        return;
      this.LauncherRunGameCommandLineTextBox.Text = gameOptions;
    }

    private void LauncherWarningsNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
      if (Convert.ToInt32(this.LauncherWarningsCounter.Text) <= 0)
        return;
      this.LauncherConsole.SelectionStart = this.LauncherWarningsNumericUpDown.Value != 0M ? this.FindLauncherConsoleText("WARNING:", this.LauncherConsole.SelectionStart + this.LauncherConsole.SelectionLength, this.LauncherConsole.Text.Length) : this.FindLauncherConsoleText("WARNING:", 0, this.LauncherConsole.SelectionStart);
    }

    private void LauncherWikiLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("http://wiki.treyarch.com");
    }

    private void LauncherwikiToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start("http://wiki.treyarch.com");
    }

    private void LaunchProcess(
      string processFileName,
      string arguments,
      string workingDirectory,
      bool consoleAttached,
      LauncherForm.ProcessFinishedDelegate theProcessFinishedDelegate)
    {
      if (this.consoleProcess != null & consoleAttached)
      {
        this.LauncherConsole.Invoke((MethodInvoker)(() =>
        {
          string text;
          if (!(processFileName == (string) this.processTable[(object) this.consoleProcess]))
            text = "Cannot start console process " + processFileName + "!\n\nAnother console process (" + this.processTable[(object) this.consoleProcess] + ") is already running";
          else
            text = "Console process (" + processFileName + ") is already running!";
          int num = (int) MessageBox.Show(text, "Console Busy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }));
      }
      else
      {
        try
        {
          Dictionary<string, string> dictionary = new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
          dictionary.Add("BlackOps", "game_mod.dll");
          dictionary.Add("AssetViewer", "asset_viewer.dll");
          dictionary.Add("linker_pc", "linker_pc.dll");
          dictionary.Add("CoDBORadiant", "radiant_mod.dll");
          dictionary.Add("cod2map", "cod2map.dll");
          dictionary.Add("cod2rad", "cod2rad.dll");
          string str = processFileName;
          string fileName = Path.GetFileName(processFileName);
          if (dictionary.ContainsKey(fileName))
          {
            arguments = dictionary[fileName] + " " + processFileName + " " + arguments;
            processFileName = "launcher_ldr";
            str = fileName;
          }
          Process process = new Process()
          {
            StartInfo = {
              FileName = Path.Combine(LauncherCS.Launcher.GetStartupDirectory(), processFileName),
              CreateNoWindow = true,
              Arguments = arguments,
              UseShellExecute = false
            }
          };
          process.StartInfo.WorkingDirectory = workingDirectory != null ? workingDirectory : Path.GetDirectoryName(process.StartInfo.FileName);
          process.EnableRaisingEvents = true;
          process.Exited += (EventHandler) ((argument0, argument1) =>
          {
            this.processTable.Remove((object) process);
            this.UpdateProcessList();
          });
          if (consoleAttached)
          {
            this.processFinishedDelegate = theProcessFinishedDelegate;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.OutputDataReceived += (DataReceivedEventHandler) ((s, e) => this.WriteConsole(e.Data, false));
            process.ErrorDataReceived += (DataReceivedEventHandler) ((s, e) => this.WriteConsole(e.Data, true));
            process.Exited += (EventHandler) ((argument2, argument3) => this.LauncherButtonCancel.Invoke((MethodInvoker)(() =>
            {
              this.LauncherProcessTimeElapsedTextBox.Text = process.ExitCode != 0 ? "Error " + process.ExitCode.ToString() : "Success";
              this.LauncherConsole.Focus();
              this.consoleProcess = (Process) null;
              this.UpdateConsoleColor();
              if (this.processFinishedDelegate == null)
                return;
              LauncherForm.ProcessFinishedDelegate finishedDelegate = this.processFinishedDelegate;
              this.processFinishedDelegate = (LauncherForm.ProcessFinishedDelegate) null;
              Process lastProcess = process;
              finishedDelegate(lastProcess);
            })));
          }
          process.Exited += (EventHandler) ((argument4, argument5) => process.Dispose());
          process.Start();
          if (consoleAttached)
          {
            this.consoleProcess = process;
            this.consoleProcessStartTime = DateTime.Now;
            this.UpdateConsoleColor();
            this.LauncherProcessTextBox.Text = (workingDirectory != null ? workingDirectory + "> " : "") + processFileName + " " + arguments;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
          }
          this.processTable.Add((object) process, (object) str);
          this.UpdateProcessList();
        }
        catch
        {
          this.WriteConsole("FAILED TO EXECUTE: " + processFileName + " " + arguments, true);
          if (this.processFinishedDelegate == null)
            return;
          LauncherForm.ProcessFinishedDelegate finishedDelegate = this.processFinishedDelegate;
          this.processFinishedDelegate = (LauncherForm.ProcessFinishedDelegate) null;
          finishedDelegate((Process) null);
        }
      }
    }

    private void LaunchProcessHelper(
      bool shouldRun,
      LauncherForm.ProcessFinishedDelegate nextStage,
      Process lastProcess,
      string processName,
      string processOptions,
      string workingDirectory)
    {
      if (lastProcess != null && lastProcess.ExitCode != 0 || !shouldRun)
        nextStage(lastProcess);
      else
        this.LaunchProcess(processName, processOptions, workingDirectory, true, nextStage);
    }

    private void LaunchProcessHelper(
      bool shouldRun,
      LauncherForm.ProcessFinishedDelegate nextStage,
      Process lastProcess,
      string processName,
      string processOptions)
    {
      this.LaunchProcessHelper(shouldRun, nextStage, lastProcess, processName, processOptions, (string) null);
    }

    private void mayaExporterToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start(LauncherCS.Launcher.GetRootDirectory() + "/bin/maya/tools/Help/Model_Exporter.pdf");
    }

    private void mayaPluginSetupToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("This will overwrite any existing Maya environment variable file and usersetup.\n     Continue?", "Maya Plugin Setup", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      if (Directory.Exists(folderPath + "/maya"))
      {
        string str1 = folderPath + "/maya";
        string str2;
        bool flag;
        if (!Directory.Exists(str1 + "/2009-x64"))
        {
          if (!Directory.Exists(str1 + "/2009"))
          {
            int num = (int) MessageBox.Show("Error: Couldn not find Maya 2009 folder.", "Maya Plugin Setup");
            return;
          }
          str2 = str1 + "/2009";
          flag = false;
        }
        else
        {
          str2 = str1 + "/2009-x64";
          flag = true;
        }
        if (File.Exists(str2 + "/Maya.env"))
          File.Delete(str2 + "/Maya.env");
        string str3 = Path.Combine(LauncherCS.Launcher.GetBinDirectory(), "maya/tools/");
        string[] contents = new string[2]
        {
          "MAYA_SCRIPT_PATH  = " + str3,
          "MAYA_PLUG_IN_PATH = " + str3
        };
        File.WriteAllLines(str2 + "/Maya.env", contents);
        File.Copy(Path.Combine(LauncherCS.Launcher.GetBinDirectory(), "maya/tools/usersetup.mel"), str2 + "/scripts/usersetup.mel", true);
        File.SetAttributes(str2 + "/scripts/usersetup.mel", FileAttributes.Normal);
        string str4 = "Maya2009_x86.zip";
        if (flag)
          str4 = "Maya2009_x64.zip";
        this.LaunchProcess("7za", "e \"" + str4 + "\" -y", Path.Combine(LauncherCS.Launcher.GetBinDirectory(), "maya/tools/"), false, (LauncherForm.ProcessFinishedDelegate) null);
        string str5 = "(32bit)";
        if (flag)
          str5 = "(64bit)";
        int num1 = (int) MessageBox.Show("Success!\nCoDTools should now be in the menu strip the next time you launch Maya " + str5, "Maya Plugin Setup");
      }
      else
      {
        int num2 = (int) MessageBox.Show("Error: Maya MyDocuments folder doesn't exist, please run Maya at least once.", "Maya Plugin Setup");
      }
    }

    private void ModBuildFastFileDelegate(Process lastProcess)
    {
      if (this.LauncherModBuildFastFilesCheckBox.Checked)
        LauncherCS.Launcher.CopyFileSmart(Path.Combine(LauncherCS.Launcher.GetModDirectory(this.modName), "mod.csv"), Path.Combine(LauncherCS.Launcher.GetZoneSourceDirectory(), "mod.csv"));
      string str = "";
      if (this.LauncherModBuildLinkerOptionsTextBox.Text != null)
        str = this.LauncherModBuildLinkerOptionsTextBox.Text;
      bool shouldRun = this.LauncherModBuildFastFilesCheckBox.Checked;
      LauncherForm.ProcessFinishedDelegate nextStage = new LauncherForm.ProcessFinishedDelegate(this.ModBuildMoveModFastFileDelegate);
      string[] strArray = new string[6]
      {
        "-nopause -language ",
        LauncherCS.Launcher.GetLanguage(),
        " -moddir ",
        this.modName,
        " mod ",
        str
      };
      this.LaunchProcessHelper(shouldRun, nextStage, lastProcess, "linker_pc", string.Concat(strArray));
    }

    private void ModBuildFinishedDelegate(Process lastProcess)
    {
      LauncherCS.Launcher.Publish();
      this.EnableControls(true);
    }

    private void ModBuildIwdFileDelegate(Process lastProcess)
    {
      string fileName = Path.Combine(LauncherCS.Launcher.GetModDirectory(this.modName), this.modName + ".iwd");
      if (this.LauncherModBuildIwdFileCheckBox.Checked)
        LauncherCS.Launcher.DeleteFile(fileName, false);
      bool shouldRun = this.LauncherModBuildIwdFileCheckBox.Checked;
      LauncherForm.ProcessFinishedDelegate nextStage = new LauncherForm.ProcessFinishedDelegate(this.ModBuildFinishedDelegate);
      string[] strArray = new string[5]
      {
        "a \"",
        fileName,
        "\" -tzip -r \"@",
        Path.Combine(LauncherCS.Launcher.GetModDirectory(this.modName), this.modName + ".files"),
        "\""
      };
      this.LaunchProcessHelper(shouldRun, nextStage, lastProcess, "7za", string.Concat(strArray), LauncherCS.Launcher.GetModDirectory(this.modName));
    }

    private void ModBuildMoveModFastFileDelegate(Process lastProcess)
    {
      if (this.LauncherModBuildFastFilesCheckBox.Checked)
        LauncherCS.Launcher.MoveFile(Path.Combine(LauncherCS.Launcher.GetZoneDirectory(), "mod.ff"), Path.Combine(LauncherCS.Launcher.GetModDirectory(this.modName), "mod.ff"));
      this.ModBuildIwdFileDelegate(lastProcess);
    }

    private void ModBuildSoundDelegate(Process lastProcess)
    {
      this.LaunchProcessHelper(this.LauncherModBuildSoundsCheckBox.Checked, new LauncherForm.ProcessFinishedDelegate(this.ModBuildFastFileDelegate), lastProcess, "MODSound", "-pc -ignore_orphans " + (this.LauncherModVerboseCheckBox.Checked ? "-verbose " : ""));
    }

    private void ModBuildStart()
    {
      this.EnableControls(false);
      this.ModBuildSoundDelegate((Process) null);
    }

    private void newModToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new CreateModForm().ShowDialog();
    }

    private void RecursiveCheckNodesDown(TreeNodeCollection tree, bool checkedFlag)
    {
      if (tree == null)
        return;
      foreach (TreeNode treeNode in tree)
      {
        TreeNodeCollection nodes = treeNode.Nodes;
        bool flag = checkedFlag;
        bool checkedFlag1 = flag;
        treeNode.Checked = flag;
        this.RecursiveCheckNodesDown(nodes, checkedFlag1);
      }
    }

    private void RecursiveCheckNodesUp(TreeNode node, bool checkedFlag)
    {
      if (node == null)
        return;
      TreeNode parent = node.Parent;
      bool flag = checkedFlag;
      bool checkedFlag1 = flag;
      node.Checked = flag;
      this.RecursiveCheckNodesUp(parent, checkedFlag1);
    }

    private void TreeViewToHashTable(TreeNodeCollection tree, Hashtable ht)
    {
      if (tree == null)
        return;
      foreach (TreeNode treeNode in tree)
      {
        if (!treeNode.Checked || treeNode.Tag == null)
          ht.Remove((object) treeNode.FullPath);
        else
          ht.Add((object) treeNode.FullPath, (object) null);
        this.TreeViewToHashTable(treeNode.Nodes, ht);
      }
    }

    private Hashtable TreeViewToHashTable(TreeNodeCollection tree)
    {
      Hashtable ht = new Hashtable();
      this.TreeViewToHashTable(tree, ht);
      return ht;
    }

    private void UpdateConsoleColor()
    {
      this.LauncherConsole.BackColor = this.consoleProcess == null ? Color.Black : Color.Black;
    }

    private void UpdateDVars()
    {
    }

    private void UpdateMapList()
    {
      object selectedItem = this.LauncherMapList.SelectedItem;
      int selectedIndex1 = this.LauncherMapList.SelectedIndex;
      int selectedIndex2 = this.LauncherMapTypeList.SelectedIndex;
      this.LauncherMapList.Items.Clear();
      this.LauncherMapList.Items.AddRange((object[]) LauncherCS.Launcher.GetMapList(selectedIndex2));
      if (this.LauncherMapList.Items.Count == 0)
        return;
      this.LauncherMapList.SelectedItem = selectedItem;
      if (this.LauncherMapList.SelectedItem != null)
        return;
      this.LauncherRunGameMapNameTextBox.Text = (string) null;
    }

    private void UpdateMapSettings(bool save = true, bool load = true)
    {
      if (this.mapName != null & save)
      {
        LauncherCS.Launcher.mapSettings.SetBoolean("compile_bsp", this.LauncherCompileBSPCheckBox.Checked);
        LauncherCS.Launcher.mapSettings.SetBoolean("compile_lights", this.LauncherCompileLightsCheckBox.Checked);
        LauncherCS.Launcher.mapSettings.SetBoolean("compile_paths", this.LauncherConnectPathsCheckBox.Checked);
        LauncherCS.Launcher.mapSettings.SetBoolean("compile_reflections", this.LauncherCompileReflectionsCheckBox.Checked);
        LauncherCS.Launcher.mapSettings.SetBoolean("compile_buildffs", this.LauncherBuildFastFilesCheckBox.Checked);
        LauncherCS.Launcher.mapSettings.SetBoolean("compile_bspinfo", this.LauncherBspInfoCheckBox.Checked);
        LauncherCS.Launcher.mapSettings.SetBoolean("compile_runafter", this.LauncherRunMapAfterCompileCheckBox.Checked);
        LauncherCS.Launcher.mapSettings.SetBoolean("compile_useruntab", this.LauncherUseRunGameTypeOptionsCheckBox.Checked);
        LauncherCS.Launcher.mapSettings.SetString("compile_runoptions", this.LauncherCustomRunOptionsTextBox.Text);
        LauncherCS.Launcher.mapSettings.SetBoolean("compile_modenabled", this.LauncherModSpecificMapCheckBox.Checked);
        LauncherCS.Launcher.mapSettings.SetString("compile_modname", this.LauncherModSpecificMapComboBox.Text);
        LauncherCS.Launcher.mapSettings.SetBoolean("compile_collectdots", this.LauncherGridCollectDotsCheckBox.Checked);
        LauncherCS.Launcher.SaveMapSettings(this.mapName, LauncherCS.Launcher.mapSettings.Get());
        this.mapName = (string) null;
      }
      if (!(this.LauncherMapList.SelectedItem != null & load))
        return;
      this.mapName = this.LauncherMapList.SelectedItem.ToString();
      LauncherCS.Launcher.mapSettings.Set(LauncherCS.Launcher.LoadMapSettings(this.mapName));
      this.LauncherCompileBSPCheckBox.Checked = LauncherCS.Launcher.mapSettings.GetBoolean("compile_bsp");
      this.LauncherCompileLightsCheckBox.Checked = LauncherCS.Launcher.mapSettings.GetBoolean("compile_lights");
      this.LauncherConnectPathsCheckBox.Checked = LauncherCS.Launcher.mapSettings.GetBoolean("compile_paths");
      this.LauncherCompileReflectionsCheckBox.Checked = LauncherCS.Launcher.mapSettings.GetBoolean("compile_reflections");
      this.LauncherBuildFastFilesCheckBox.Checked = LauncherCS.Launcher.mapSettings.GetBoolean("compile_buildffs");
      this.LauncherBspInfoCheckBox.Checked = LauncherCS.Launcher.mapSettings.GetBoolean("compile_bspinfo");
      this.LauncherRunMapAfterCompileCheckBox.Checked = LauncherCS.Launcher.mapSettings.GetBoolean("compile_runafter");
      this.LauncherUseRunGameTypeOptionsCheckBox.Checked = LauncherCS.Launcher.mapSettings.GetBoolean("compile_useruntab");
      this.LauncherCustomRunOptionsTextBox.Text = LauncherCS.Launcher.mapSettings.GetString("compile_runoptions");
      this.LauncherGridCollectDotsCheckBox.Checked = LauncherCS.Launcher.mapSettings.GetBoolean("compile_collectdots");
      this.LauncherModSpecificMapCheckBox.Checked = LauncherCS.Launcher.mapSettings.GetBoolean("compile_modenabled");
      string str = LauncherCS.Launcher.mapSettings.GetString("compile_modname");
      if (str.Length > 0)
        this.LauncherModSpecificMapComboBox.Text = str;
      else
        this.LauncherModSpecificMapComboBox.SelectedIndex = -1;
    }

    private void UpdateModSettings(bool save = true, bool load = true)
    {
      if (this.modName != null & save)
      {
        LauncherCS.Launcher.modSettings.SetBoolean("build_fastfile", this.LauncherModBuildFastFilesCheckBox.Checked);
        LauncherCS.Launcher.modSettings.SetBoolean("build_iwd", this.LauncherModBuildIwdFileCheckBox.Checked);
        LauncherCS.Launcher.modSettings.SetBoolean("build_sounds", this.LauncherModBuildSoundsCheckBox.Checked);
        LauncherCS.Launcher.modSettings.SetBoolean("build_verbose", this.LauncherModVerboseCheckBox.Checked);
        LauncherCS.Launcher.modSettings.SetString("build_options", this.LauncherModBuildLinkerOptionsTextBox.Text);
        LauncherCS.Launcher.SaveModSettings(this.modName, LauncherCS.Launcher.modSettings.Get());
        this.modName = (string) null;
      }
      if (!(this.LauncherModComboBox.SelectedItem != null & load))
        return;
      this.modName = this.LauncherModComboBox.SelectedItem.ToString();
      LauncherCS.Launcher.modSettings.Set(LauncherCS.Launcher.LoadModSettings(this.modName));
      this.LauncherModBuildFastFilesCheckBox.Checked = LauncherCS.Launcher.modSettings.GetBoolean("build_fastfile");
      this.LauncherModBuildIwdFileCheckBox.Checked = LauncherCS.Launcher.modSettings.GetBoolean("build_iwd");
      this.LauncherModBuildSoundsCheckBox.Checked = LauncherCS.Launcher.modSettings.GetBoolean("build_sounds");
      this.LauncherModVerboseCheckBox.Checked = LauncherCS.Launcher.modSettings.GetBoolean("build_verbose");
      this.LauncherModBuildLinkerOptionsTextBox.Text = LauncherCS.Launcher.modSettings.GetString("build_options");
    }

    private void UpdateModList()
    {
      ComboBox[] comboBoxArray = new ComboBox[3]
      {
        this.LauncherRunGameModComboBox,
        this.LauncherModComboBox,
        this.LauncherModSpecificMapComboBox
      };
      string[] strArray = new string[comboBoxArray.Length];
      string[] modList = LauncherCS.Launcher.GetModList();
      for (int index = 0; index < comboBoxArray.Length; ++index)
      {
        strArray[index] = comboBoxArray[index].SelectedItem != null ? comboBoxArray[index].SelectedItem.ToString() : "";
        comboBoxArray[index].Items.Clear();
      }
      this.LauncherRunGameModComboBox.Items.Add((object) "(not set)");
      this.LauncherRunGameModComboBox.Items.Add((object) "(auto)");
      for (int index = 0; index < comboBoxArray.Length; ++index)
      {
        comboBoxArray[index].Items.AddRange((object[]) modList);
        if (comboBoxArray[index].Items.Count > 0)
          comboBoxArray[index].Text = strArray[index];
      }
      this.LauncherModComboBoxApplySettings();
      if (this.LauncherRunGameModComboBox.SelectedIndex >= 0)
        return;
      this.LauncherRunGameModComboBox.SelectedIndex = 0;
    }

    private void UpdateProcessList()
    {
      this.LauncherProcessList.Invoke((MethodInvoker)(() =>
      {
        this.processList.Clear();
        this.LauncherProcessList.Items.Clear();
        foreach (DictionaryEntry dictionaryEntry in this.processTable)
        {
          this.processList.Add((object) dictionaryEntry);
          this.LauncherProcessList.Items.Add((object) Path.GetFileNameWithoutExtension((string) dictionaryEntry.Value));
        }
        if (this.LauncherProcessList.SelectedIndex < 0 && this.LauncherProcessList.Items.Count > 0)
          this.LauncherProcessList.SelectedIndex = 0;
        this.UpdateStopProcessButton();
      }));
    }

    private void UpdateRunGameCommandLine()
    {
    }

    private void UpdateStopProcessButton()
    {
      int selectedIndex = this.LauncherProcessList.SelectedIndex;
      if (selectedIndex < 0)
      {
        this.LauncherButtonCancel.Enabled = false;
        this.LauncherButtonCancel.Text = "No Active Process\n\nStart one and then use this button to stop it";
      }
      else
      {
        this.LauncherButtonCancel.Enabled = true;
        if (((DictionaryEntry) this.processList[selectedIndex]).Key == this.consoleProcess)
          this.LauncherButtonCancel.Text = "Stop Console Process\n\n" + Path.GetFileNameWithoutExtension(((DictionaryEntry) this.processList[selectedIndex]).Value.ToString());
        else
          this.LauncherButtonCancel.Text = "Stop Application\n\n" + Path.GetFileNameWithoutExtension(((DictionaryEntry) this.processList[selectedIndex]).Value.ToString());
      }
    }

    private void utilityDocsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Process.Start(LauncherCS.Launcher.GetRootDirectory() + "/docs/script_docs/UtilityFunctions/index.htm");
    }

    private void WriteConsole(string s, bool isStdError)
    {
      if (s == null)
        return;
      long ticks = DateTime.Now.Ticks;
      bool flag2 = ticks - this.consoleTicksWhenLastFocus > 10000000L;
      if (flag2)
        this.consoleTicksWhenLastFocus = ticks;
      if (s.Contains("Setting breakpad minidump AppID = ") || s.Contains("Steam_SetMinidumpSteamID:  Caching Steam ID:  "))
        s = "";
      else
        this.LauncherConsole.Invoke((MethodInvoker) (() =>
        {
          Color selectionColor = this.LauncherConsole.SelectionColor;
          Font selectionFont = this.LauncherConsole.SelectionFont;
          bool flag1 = isStdError || s.Contains("ERROR:");
          bool flag3 = s.Contains("WARNING:");
          if (flag1 | flag3)
          {
            if (!flag1)
            {
					LauncherWarningsPictureBox.BackgroundImage = Properties.Resources.Warning;
					this.LauncherWarningsCounter.Text = Convert.ToString(Convert.ToInt32(this.LauncherWarningsCounter.Text) + 1);
            }
            else
            {
					LauncherErrorsPictureBox.BackgroundImage = Properties.Resources.error;
					this.LauncherErrorsCounter.Text = Convert.ToString(Convert.ToInt32(this.LauncherErrorsCounter.Text) + 1);
            }
            this.LauncherConsole.SelectionFont = new Font(this.LauncherConsole.SelectionFont, FontStyle.Bold);
            this.LauncherConsole.SelectionColor = flag1 ? Color.Red : Color.Green;
          }
          this.LauncherConsole.AppendText(s + "\n");
          if (flag2)
            this.LauncherConsole.Focus();
          if (!(flag1 | flag3))
            return;
          this.LauncherConsole.SelectionColor = selectionColor;
          this.LauncherConsole.SelectionFont = selectionFont;
        }));
    }

    private void WriteError(string s) => this.WriteConsole(s, true);

    private void WriteMessage(string s) => this.WriteConsole(s, false);

    private event LauncherForm.ProcessFinishedDelegate processFinishedDelegate;

    private void runToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string str1 = this.LauncherMapList.Items[this.LauncherMapListContextMenu_Map].ToString();
      string str2 = "+set fs_game ";
      string arguments = !this.LauncherModSpecificMapCheckBox.Checked ? "" : (this.LauncherModSpecificMapComboBox.Text.Length <= 0 || !this.LauncherModSpecificMapCheckBox.Checked ? "" : str2 + "\"mods/" + this.LauncherModSpecificMapComboBox.Text + "\" ");
      if (str1.Length > 0)
        arguments = arguments + "+devmap " + str1 + " ";
      bool mpVersion = false;
      if (this.LauncherRunGameMapNameTextBox.Text.Contains("mp_"))
        mpVersion = true;
      this.LaunchProcess(LauncherCS.Launcher.GetGameApplication(mpVersion), arguments, (string) null, false, (LauncherForm.ProcessFinishedDelegate) null);
    }

    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string str = this.LauncherMapList.Items[this.LauncherMapListContextMenu_Map].ToString();
      this.LaunchProcess("CoDBORadiant", "\"" + Path.Combine(LauncherCS.Launcher.GetMapSourceDirectory(), str + ".map") + "\"", (string) null, false, (LauncherForm.ProcessFinishedDelegate) null);
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string mapName = this.LauncherMapList.Items[this.LauncherMapListContextMenu_Map].ToString();
      string[] mapFiles1 = LauncherCS.Launcher.GetMapFiles(mapName);
      if (DialogResult.Yes != MessageBox.Show("The following files would be deleted:\n\n" + LauncherCS.Launcher.StringArrayToString(mapFiles1), "Are you sure you want to delete these files?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
        return;
      foreach (string fileName in mapFiles1)
        LauncherCS.Launcher.DeleteFile(fileName);
      string[] mapFiles2 = LauncherCS.Launcher.GetMapFiles(mapName);
      if (mapFiles2.Length != 0)
      {
        int num = (int) MessageBox.Show("Could not delete the following files:\n\n" + LauncherCS.Launcher.StringArrayToString(mapFiles2), "Error deleting files", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      this.UpdateMapList();
      this.EnableMapList();
    }

    public enum LauncherTabType
    {
      Mods,
      Maps,
      Explore,
    }

    public delegate void ProcessFinishedDelegate(Process lastProcess);
  }
}
