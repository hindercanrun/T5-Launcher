using Launcher.Properties;
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

namespace Launcher
{
	internal class MainWindow : Form
	{
		private readonly ComboBox[] dvarComboBoxes = new ComboBox[0];
		private readonly Hashtable processTable = new Hashtable();
		private readonly ArrayList processList = new ArrayList();
		private Process consoleProcess;
		private DateTime consoleProcessStartTime;
		private string mapName;
		private string modName;
		private long consoleTicksWhenLastFocus = DateTime.Now.Ticks;
		private readonly Mutex consoleMutex = new Mutex();
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

		internal MainWindow()
		{
			InitializeComponent();
			LauncherMapTypeList.SelectedIndex = 0; // Singleplayer
		}

		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == NativeMethods.WM_SHOWME)
			{
				if (WindowState == FormWindowState.Minimized)
					WindowState = FormWindowState.Normal;
				bool topMost = TopMost;
				TopMost = true;
				TopMost = topMost;
			}
			base.WndProc(ref m);
		}

		internal void SetMapSelection(string mapName, bool updateList = false)
		{
			if (updateList)
				UpdateMapList();

			int stringExact = LauncherMapList.FindStringExact(mapName);
			if (stringExact == -1)
				return;

			LauncherMapList.SelectedIndex = stringExact;
		}

		internal void SetModSelection(string modName, bool updateList = false)
		{
			if (updateList)
				UpdateModList();

			int stringExact = LauncherModComboBox.FindStringExact(modName);
			if (stringExact == -1)
				return;

			LauncherModComboBox.SelectedIndex = stringExact;
		}

		internal enum LauncherTabType
		{
			Mods,
			Maps,
			Explore,
		}

		internal void SetLauncherTab(LauncherTabType tab)
		{
			switch (tab)
			{
				case LauncherTabType.Mods:
					LauncherTab.SelectedTab = LauncherTabModBuilder;
					break;
				case LauncherTabType.Maps:
					LauncherTab.SelectedTab = LauncherTabCompileLevel;
					break;
				case LauncherTabType.Explore:
					LauncherTab.SelectedTab = LauncherTabExplore;
					break;
			}
		}

		internal void SetTabToSingleplayer()
		{
			LauncherMapTypeList.SelectedIndex = 0;
		}

		internal void SetTabToMultiplayer()
		{
			LauncherMapTypeList.SelectedIndex = 1;
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
			  AddFilesToTreeView(Path.Combine(Directory, directory.Name), tree, false);
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
		  EnableControls(false);
		  string path2 = mapName + ".grid";
		  Launcher.CopyFile(Path.Combine(Launcher.GetMapSourceDirectory(), path2), Path.Combine(Launcher.GetRawMapsDirectory(), Path.Combine(IsMP() ? "mp" : "", path2)));
		  MainWindow.ProcessFinishedDelegate nextStage = new MainWindow.ProcessFinishedDelegate(BuildGridFinishedDelegate);
		  string gameApplication = Launcher.GetGameApplication(IsMP());
		  string str1 = "raw";
		  string str2 = "+set developer 1 +set logfile 2 + set r_vc_makelog " + r_vc_makelog.ToString() + "+set r_vc_showlog 16 +set r_cullxmodel " + (Launcher.mapSettings.GetBoolean("compile_collectdots") ? "0" : "1") + " +set thereisacow 1960 +set com_introplayed 1 +set fs_game " + str1;
		  string processOptions = (!(str1 == "raw") ? str2 + " +set fs_usedevdir 1" : str2 + " +set fs_useFastFile 0 +set fs_usedevdir 1") + "+devmap " + mapName;
		  LaunchProcessHelper(true, nextStage, (Process) null, gameApplication, processOptions);
		}

		private void BuildGridFinishedDelegate(Process lastProcess)
		{
		  string path2 = mapName + ".grid";
		  Launcher.MoveFile(Path.Combine(Launcher.GetRawMapsDirectory(), Path.Combine(IsMP() ? "mp" : "", path2)), Path.Combine(Launcher.GetMapSourceDirectory(), path2));
		  EnableControls(true);
		}

		private void LauncherModSpecificMapCheckBox_CheckedChanged(object sender, EventArgs e)
		{
		  LauncherModSpecificMapComboBox.Enabled = LauncherModSpecificMapCheckBox.Checked;
		}

		private bool CheckZoneSourceFiles()
		{
		  if (File.Exists(Launcher.GetZoneSourceFile(mapName)))
			return true;
		  if (MessageBox.Show("There are no zone files for " + mapName + ". Would you like to create them?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
			return false;
		  Launcher.CreateZoneSourceFiles(mapName);
		  return true;
		}

		private void CompileLevel()
		{
		  EnableControls(false);
		  UpdateMapSettings();
		  CompileLevelBspDelegate((Process) null);
		}

		private void CompileLevelBspDelegate(Process lastProcess)
		{
		  MainWindow.ProcessFinishedDelegate nextStage = new MainWindow.ProcessFinishedDelegate(CompileLevelVisDelegate);
		  Launcher.DeleteFile(GetSourceBsp() + ".lin", false);
		  string[] strArray = new string[9]
		  {
			"-platform pc ",
			"-loadFrom \"",
			GetSourceBsp(),
			".map\"",
			" ",
			Launcher.GetBspOptions(),
			" \"",
			GetDestinationBsp(),
			"\""
		  };
		  CompileLevelHelper("compile_bsp", nextStage, lastProcess, "cod2map", string.Concat(strArray));
		}

		private void CompileLevelLightsDelegate(Process lastProcess)
		{
		  string[] strArray = new string[5]
		  {
			"-platform pc ",
			Launcher.GetLightOptions(),
			"\"",
			GetDestinationBsp(),
			"\""
		  };
		  CompileLevelHelper("compile_lights", new MainWindow.ProcessFinishedDelegate(CompileLevelCleanupDelegate), lastProcess, "cod2rad", string.Concat(strArray));
		}

		private void CompileLevelBspInfoDelegate(Process lastProcess)
		{
		  CompileLevelHelper("compile_bspinfo", new MainWindow.ProcessFinishedDelegate(CompileLevelFastFilesDelegate), lastProcess, "cod2map", "-info \"" + GetDestinationBsp() + "\"");
		}

		private void CompileLevelBuildFastFile(
		  string name,
		  Process lastProcess,
		  MainWindow.ProcessFinishedDelegate nextStage)
		{
		  string str = Launcher.mapSettings.GetBoolean("compile_modenabled") ? "-moddir " + Launcher.mapSettings.GetString("compile_modname") + " " : "";
		  CompileLevelHelper("compile_buildffs", nextStage, lastProcess, "linker_pc", "-nopause -language " + Launcher.GetLanguage() + " " + str + name + (File.Exists(Launcher.GetLoadZone(mapName)) ? " " + Launcher.GetLoadZone(mapName) : ""));
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
			Launcher.DeleteFile(GetDestinationBsp() + str, false);
		  CompileLevelPathsDelegate(lastProcess);
		}

		private void CompileLevelFastFilesDelegate(Process lastProcess)
		{
		  if (!CheckZoneSourceFiles())
			CompileLevelRunGameDelegate(lastProcess);
		  else if (IsMP())
			CompileLevelBuildFastFile(mapName, lastProcess, new MainWindow.ProcessFinishedDelegate(CompileLevelFastFilesLocalizedDelegate));
		  else
			CompileLevelBuildFastFile(mapName, lastProcess, new MainWindow.ProcessFinishedDelegate(CompileLevelMoveFastFilesDelegate));
		}

		private void CompileLevelFastFilesLocalizedDelegate(Process lastProcess)
		{
		  CompileLevelBuildFastFile("localized_" + mapName, lastProcess, new MainWindow.ProcessFinishedDelegate(CompileLevelMoveFastFilesDelegate));
		}

		private void CompileLevelFinished(Process lastProcess) => EnableControls(true);

		private void CompileLevelHelper(
		  string mapSettingsOption,
		  MainWindow.ProcessFinishedDelegate nextStage,
		  Process lastProcess,
		  string processName,
		  string processOptions,
		  string workingDirectory)
		{
		  LaunchProcessHelper(Launcher.mapSettings.GetBoolean(mapSettingsOption), nextStage, lastProcess, processName, processOptions, workingDirectory);
		}

		private void CompileLevelHelper(
		  string mapSettingsOption,
		  MainWindow.ProcessFinishedDelegate nextStage,
		  Process lastProcess,
		  string processName,
		  string processOptions)
		{
		  LaunchProcessHelper(Launcher.mapSettings.GetBoolean(mapSettingsOption), nextStage, lastProcess, processName, processOptions);
		}

		private void CompileLevelMoveFastFilesDelegate(Process lastProcess)
		{
		  string zoneDirectory = Launcher.GetZoneDirectory();
		  string path1 = Launcher.mapSettings.GetBoolean("compile_modenabled") ? Launcher.GetModDirectory(Launcher.mapSettings.GetString("compile_modname")) : Path.Combine(Launcher.GetUsermapsDirectory(), mapName);
		  string path2_1 = mapName + ".ff";
		  string path2_2 = mapName + "_load.ff";
		  Launcher.MoveFile(Path.Combine(zoneDirectory, path2_1), Path.Combine(path1, path2_1));
		  Launcher.MoveFile(Path.Combine(zoneDirectory, "localized_" + path2_1), Path.Combine(path1, "localized_" + path2_1));
		  Launcher.MoveFile(Path.Combine(zoneDirectory, path2_2), Path.Combine(path1, path2_2));
		  Launcher.Publish();
		  CompileLevelRunGameDelegate(lastProcess);
		}

		private void CompileLevelPathsDelegate(Process lastProcess)
		{
		  CompileLevelHelper("compile_paths", new MainWindow.ProcessFinishedDelegate(CompileLevelReflectionsDelegate), lastProcess, Launcher.GetGameTool(IsMP()), "allowdupe +set developer 1 +set logfile 2 +set thereisacow 1960 +set com_introplayed 1 +set r_fullscreen 0 +set fs_usedevdir 1 +set g_connectpaths 2 +set useFastFile 0 +devmap " + mapName);
		}

		private void CompileLevelReflectionsDelegate(Process lastProcess)
		{
		  CompileLevelHelper("compile_reflections", new MainWindow.ProcessFinishedDelegate(CompileLevelBspInfoDelegate), lastProcess, Launcher.GetGameTool(IsMP()), "allowdupe +set developer 1 +set logfile 2 +set thereisacow 1960 +set com_introplayed 1 +set r_fullscreen 0 +set fs_usedevdir 1 +set ui_autoContinue 1 +set r_reflectionProbeGenerateExit 1 +set useFastFile 0 +set r_fullscreen 0 +set r_reflectionProbeRegenerateAll 1 +set r_zFeather 1 +set r_reflectionProbeGenerate 1 +devmap " + mapName);
		}

		private void CompileLevelRunGameDelegate(Process lastProcess)
		{
		  string str = Launcher.mapSettings.GetBoolean("compile_modenabled") ? "\"mods/" + Launcher.mapSettings.GetString("compile_modname") + "\"" : "raw";
		  MainWindow.ProcessFinishedDelegate nextStage = new MainWindow.ProcessFinishedDelegate(CompileLevelFinished);
		  Process lastProcess1 = lastProcess;
		  string gameApplication = Launcher.GetGameApplication(IsMP());
		  string[] strArray1 = new string[7];
		  strArray1[0] = "+set useFastFile 1 +set fs_usedevdir 1 +set logfile 2 +set thereisacow 1960 +set com_introplayed 1 ";
		  string[] strArray2 = strArray1;
		  strArray2[1] = IsMP() ? "+set sv_pure 0 +set g_gametype tdm " : "";
		  strArray2[2] = "+devmap ";
		  strArray2[3] = mapName;
		  strArray2[4] = " +set fs_game ";
		  strArray2[5] = str;
		  strArray2[6] = " ";
		  CompileLevelHelper("compile_runafter", nextStage, lastProcess1, gameApplication, string.Concat(strArray2));
		}

		private void CompileLevelVisDelegate(Process lastProcess)
		{
		  CompileLevelHelper("compile_vis", new MainWindow.ProcessFinishedDelegate(CompileLevelLightsDelegate), lastProcess, "cod2map", "-vis -platform pc \"" + GetDestinationBsp() + "\"");
		}

		protected override void Dispose(bool disposing)
		{
		  if (disposing)
		  {
			if (components != null)
			  components.Dispose();
			if (consoleMutex != null)
			  consoleMutex.Close();
		  }
		  base.Dispose(disposing);
		}

		private void EnableControls(bool enabled) => EnableControls(enabled, (TabPage) null);

		private void EnableControls(bool enabled, TabPage onlyForTabPage)
		{
		  TabPage[] tabPageArray = new TabPage[2]
		  {
			LauncherTabCompileLevel,
			LauncherTabModBuilder
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
			LauncherModSpecificMapComboBox.Enabled = LauncherModSpecificMapCheckBox.Checked;
		  LauncherMapTypeList.Enabled = true;
		  LauncherCreateMapButton.Enabled = true;
		}

		private void EnableMapList()
		{
		  bool enabled = LauncherMapList.SelectedItem != null;
		  LauncherCompileLevelButton.Enabled = enabled;
		  EnableControls(enabled, LauncherTabCompileLevel);
		  LauncherMapList.Enabled = true;
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
		  Process.Start(Launcher.GetRootDirectory() + "/bin/maya/tutorial/trashcan_metal/Treyarch_trashcan_metal_directions01sm.pdf");
		}

		public int FindLauncherConsoleText(string text, int start, int end)
		{
		  int launcherConsoleText = -1;
		  if (text.Length > 0 && start >= 0 && end >= 0)
		  {
			int num = LauncherConsole.Find(text, start, end, RichTextBoxFinds.None);
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
		  foreach (ComboBox dvarComboBox in dvarComboBoxes)
			stringBuilder.Append(FormatDVar(dvarComboBox));
		  return stringBuilder.ToString();
		}

		private void gameDirToolStripMenuItem_Click(object sender, EventArgs e)
		{
		  Process.Start(Launcher.GetRootDirectory());
		}

		private string GetDestinationBsp()
		{
		  return Launcher.GetRawMapsDirectory() + (IsMP() ? "mp\\" : "") + mapName;
		}

		private string GetFS_Game(bool allowRaw = false)
		{
		  if (LauncherRunGameModComboBox.SelectedIndex > 1)
			return "\"mods/" + LauncherRunGameModComboBox.Text + "\"";
		  return LauncherRunGameModComboBox.SelectedIndex > 0 ? (LauncherModSpecificMapComboBox.Text.Length <= 0 || !LauncherModSpecificMapCheckBox.Checked ? "" : "\"mods/" + LauncherModSpecificMapComboBox.Text + "\"") : (allowRaw ? "raw" : "");
		}

		private string GetGameOptions()
		{
		  string fsGame = GetFS_Game();
		  return fsGame.Length != 0 ? "+set fs_game " + fsGame + " " + FormatDvars() : FormatDvars();
		}

		private string GetSourceBsp() => Launcher.GetMapSourceDirectory() + mapName;

		private void HashTableToTreeView(Hashtable ht, TreeNodeCollection tree)
		{
		  if (tree == null)
			return;
		  foreach (TreeNode node in tree)
		  {
			if (ht.Contains((object) node.FullPath))
			{
			  node.Checked = true;
			  RecursiveCheckNodesUp(node, true);
			}
			HashTableToTreeView(ht, node.Nodes);
		  }
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			LauncherConsole = new System.Windows.Forms.RichTextBox();
			LauncherSplitter = new System.Windows.Forms.SplitContainer();
			panel1 = new System.Windows.Forms.Panel();
			LauncherRunGameCustomCommandLineGroupBox = new System.Windows.Forms.GroupBox();
			LauncherRunGameCustomCommandLineCheckBox = new System.Windows.Forms.CheckBox();
			LauncherRunGameCustomCommandLineTextBox = new System.Windows.Forms.TextBox();
			LauncherRunGameGroupBox = new System.Windows.Forms.GroupBox();
			LauncherRunGameMapNameTextBox = new System.Windows.Forms.TextBox();
			LauncherRunGameLogfileBox = new System.Windows.Forms.CheckBox();
			LauncherRunGameDeveloperBox = new System.Windows.Forms.CheckBox();
			LauncherRunGameMapNameLabel = new System.Windows.Forms.Label();
			LauncherRunGameButton = new System.Windows.Forms.Button();
			LauncherRunGameCustomCommandLineMPGroupBox = new System.Windows.Forms.GroupBox();
			LauncherRunGameCustomCommandLineMPCheckBox = new System.Windows.Forms.CheckBox();
			LauncherRunGameCustomCommandLineMPTextBox = new System.Windows.Forms.TextBox();
			LauncherRunGameModGroupBox = new System.Windows.Forms.GroupBox();
			LauncherRunGameModComboBox = new System.Windows.Forms.ComboBox();
			LauncherRunGameCommandLineTextBox = new System.Windows.Forms.TextBox();
			LauncherIconBlops = new System.Windows.Forms.PictureBox();
			LauncherGameGroupBox = new System.Windows.Forms.GroupBox();
			LauncherGameLogfileBox = new System.Windows.Forms.CheckBox();
			LauncherGameDeveloperBox = new System.Windows.Forms.CheckBox();
			LauncherIconMP = new System.Windows.Forms.PictureBox();
			LauncherIconSP = new System.Windows.Forms.PictureBox();
			LauncherButtonMP = new System.Windows.Forms.Button();
			LauncherButtonSP = new System.Windows.Forms.Button();
			LauncherTab = new System.Windows.Forms.TabControl();
			LauncherTabModBuilder = new System.Windows.Forms.TabPage();
			LauncherIwdFileGroupBox = new System.Windows.Forms.GroupBox();
			LauncherIwdFileTree = new System.Windows.Forms.TreeView();
			LauncherModGroupBox = new System.Windows.Forms.GroupBox();
			LauncherModFolderGroupBox = new System.Windows.Forms.GroupBox();
			LauncherModFolderViewButton = new System.Windows.Forms.Button();
			LauncherModBuildGroupBox = new System.Windows.Forms.GroupBox();
			LauncherModBuildLinkerOptionsTextBox = new System.Windows.Forms.TextBox();
			LauncherModBuildLinkerOptionsLabel = new System.Windows.Forms.Label();
			LauncherModVerboseCheckBox = new System.Windows.Forms.CheckBox();
			LauncherModBuildFastFilesCheckBox = new System.Windows.Forms.CheckBox();
			LauncherModBuildIwdFileCheckBox = new System.Windows.Forms.CheckBox();
			LauncherModBuildButton = new System.Windows.Forms.Button();
			LauncherModBuildSoundsCheckBox = new System.Windows.Forms.CheckBox();
			LauncherModZoneSourceGroupBox = new System.Windows.Forms.GroupBox();
			LauncherModZoneSourceCSVButton = new System.Windows.Forms.Button();
			LauncherModZoneSourceMissingAssetsButton = new System.Windows.Forms.Button();
			LauncherEditZoneSourceButton = new System.Windows.Forms.Button();
			LauncherModComboBox = new System.Windows.Forms.ComboBox();
			LauncherTabCompileLevel = new System.Windows.Forms.TabPage();
			LauncherMapType = new System.Windows.Forms.Label();
			LauncherMapTypeList = new System.Windows.Forms.ComboBox();
			LauncherCreateMapButton = new System.Windows.Forms.Button();
			LauncherDeleteMapButton = new System.Windows.Forms.Button();
			LauncherCompileLevelOptionsGroupBox = new System.Windows.Forms.GroupBox();
			LauncherCompileReflectionsCheckBox = new System.Windows.Forms.CheckBox();
			LauncherGridFileGroupBox = new System.Windows.Forms.GroupBox();
			LauncherGridEditExistingButton = new System.Windows.Forms.Button();
			LauncherGridMakeNewButton = new System.Windows.Forms.Button();
			LauncherGridCollectDotsCheckBox = new System.Windows.Forms.CheckBox();
			LauncherModSpecificMapComboBox = new System.Windows.Forms.ComboBox();
			LauncherModSpecificMapCheckBox = new System.Windows.Forms.CheckBox();
			LauncherCustomRunOptionsLabel = new System.Windows.Forms.Label();
			LauncherCustomRunOptionsTextBox = new System.Windows.Forms.TextBox();
			label = new System.Windows.Forms.Label();
			LauncherCompileLevelButton = new System.Windows.Forms.Button();
			LauncherCompileLightsButton = new System.Windows.Forms.Button();
			LauncherCompileBSPButton = new System.Windows.Forms.Button();
			LauncherUseRunGameTypeOptionsCheckBox = new System.Windows.Forms.CheckBox();
			LauncherRunMapAfterCompileCheckBox = new System.Windows.Forms.CheckBox();
			LauncherBspInfoCheckBox = new System.Windows.Forms.CheckBox();
			LauncherBuildFastFilesCheckBox = new System.Windows.Forms.CheckBox();
			LauncherConnectPathsCheckBox = new System.Windows.Forms.CheckBox();
			LauncherCompileLightsCheckBox = new System.Windows.Forms.CheckBox();
			LauncherCompileBSPCheckBox = new System.Windows.Forms.CheckBox();
			LauncherMapList = new System.Windows.Forms.ListBox();
			LauncherTabExplore = new System.Windows.Forms.TabPage();
			LauncherExploreGroupBox = new System.Windows.Forms.GroupBox();
			LauncherExploreRawMapsDirGroupBox = new System.Windows.Forms.GroupBox();
			LauncherExploreRawGSCDirMPGametypesButton = new System.Windows.Forms.Button();
			LauncherExploreRawGSCDirMPFXButton = new System.Windows.Forms.Button();
			LauncherExploreRawGSCDirMPArtButton = new System.Windows.Forms.Button();
			LauncherExploreRawGSCDirMPButton = new System.Windows.Forms.Button();
			LauncherExploreRawGSCDirSPVoiceButton = new System.Windows.Forms.Button();
			LauncherExploreRawGSCDirSPGametypesButton = new System.Windows.Forms.Button();
			LauncherExploreRawGSCDirSPFXButton = new System.Windows.Forms.Button();
			LauncherExploreRawGSCDirSPArtButton = new System.Windows.Forms.Button();
			LauncherExploreRawGSCDirSPButton = new System.Windows.Forms.Button();
			LauncherExploreRawDirGroupBox = new System.Windows.Forms.GroupBox();
			LauncherExploreRawDirFXButton = new System.Windows.Forms.Button();
			LauncherExploreRawDirMPButton = new System.Windows.Forms.Button();
			LauncherExploreRawDirWeaponsButton = new System.Windows.Forms.Button();
			LauncherExploreRawDirVisionButton = new System.Windows.Forms.Button();
			LauncherExploreRawDirLocsButton = new System.Windows.Forms.Button();
			LauncherExploreRawDirAnimTreesButton = new System.Windows.Forms.Button();
			LauncherExploreRawDirSoundAliasesButton = new System.Windows.Forms.Button();
			LauncherExploreRawDirCSCButton = new System.Windows.Forms.Button();
			LauncherExploreRawDirGSCButton = new System.Windows.Forms.Button();
			LauncherExploreDevDirGroupBox = new System.Windows.Forms.GroupBox();
			LauncherExploreDevDirRawButton = new System.Windows.Forms.Button();
			LauncherExploreDevDirModelExportButton = new System.Windows.Forms.Button();
			LauncherExploreDevDirTextureAssetsButton = new System.Windows.Forms.Button();
			LauncherExploreDevDirSrcDataButton = new System.Windows.Forms.Button();
			LauncherExploreDevDirMapSrcButton = new System.Windows.Forms.Button();
			LauncherExploreDevDirBinButton = new System.Windows.Forms.Button();
			LauncherExploreDevDirZoneSourceButton = new System.Windows.Forms.Button();
			LauncherExploreBlopsDirGroupBox = new System.Windows.Forms.GroupBox();
			LauncherExploreBlopsDirConfigsButton = new System.Windows.Forms.Button();
			LauncherExploreBlopsDirModsButton = new System.Windows.Forms.Button();
			LauncherExploreBlopsDirGameButton = new System.Windows.Forms.Button();
			LauncherApplicationsGroupBox = new System.Windows.Forms.GroupBox();
			LauncherIconRadiant = new System.Windows.Forms.PictureBox();
			LauncherIconEffectsEditor = new System.Windows.Forms.PictureBox();
			LauncherIconConverter = new System.Windows.Forms.PictureBox();
			LauncherIconAssetViewer = new System.Windows.Forms.PictureBox();
			LauncherIconAssetManager = new System.Windows.Forms.PictureBox();
			LauncherButtonAssetViewer = new System.Windows.Forms.Button();
			LauncherButtonRunConverter = new System.Windows.Forms.Button();
			LauncherButtonAssetManager = new System.Windows.Forms.Button();
			LauncherButtonEffectsEd = new System.Windows.Forms.Button();
			LauncherButtonRadiant = new System.Windows.Forms.Button();
			LauncherWarningsCounter = new System.Windows.Forms.Label();
			LauncherWarningsNumericUpDown = new System.Windows.Forms.NumericUpDown();
			LauncherWarningsPictureBox = new System.Windows.Forms.PictureBox();
			LauncherWarningsLabel = new System.Windows.Forms.Label();
			LauncherErrorsCounter = new System.Windows.Forms.Label();
			LauncherErrorsNumericUpDown = new System.Windows.Forms.NumericUpDown();
			LauncherErrorsPictureBox = new System.Windows.Forms.PictureBox();
			LauncherErrorsLabel = new System.Windows.Forms.Label();
			LauncherScrollBottomConsoleButton = new System.Windows.Forms.Button();
			LauncherSaveConsoleButton = new System.Windows.Forms.Button();
			LauncherProcessTimeElapsedTextBox = new System.Windows.Forms.TextBox();
			LauncherClearConsoleButton = new System.Windows.Forms.Button();
			LauncherProcessGroupBox = new System.Windows.Forms.GroupBox();
			LauncherButtonCancel = new System.Windows.Forms.Button();
			LauncherProcessList = new System.Windows.Forms.ListBox();
			LauncherProcessTextBox = new System.Windows.Forms.TextBox();
			LauncherTimer = new System.Windows.Forms.Timer(components);
			LauncherMapFilesSystemWatcher = new System.IO.FileSystemWatcher();
			LauncherModsDirectorySystemWatcher = new System.IO.FileSystemWatcher();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			LauncherfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			newModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			LaunchernewMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			gameDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			LauncherexitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			LauncherdocsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mayaExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			exporterTutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			LaunchertoolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mayaPluginSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			LauncherhelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			LauncherwikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			LauncherRadiantToolTip = new System.Windows.Forms.ToolTip(components);
			LauncherEffectsEdToolTip = new System.Windows.Forms.ToolTip(components);
			LauncherAssetManagerToolTip = new System.Windows.Forms.ToolTip(components);
			LauncherAssetViewerToolTip = new System.Windows.Forms.ToolTip(components);
			LauncherConverterToolTip = new System.Windows.Forms.ToolTip(components);
			SaveConsoleToolTip = new System.Windows.Forms.ToolTip(components);
			LauncherScrollBottomConsoleToolTip = new System.Windows.Forms.ToolTip(components);
			LauncherMapListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
			runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(LauncherSplitter)).BeginInit();
			LauncherSplitter.Panel1.SuspendLayout();
			LauncherSplitter.Panel2.SuspendLayout();
			LauncherSplitter.SuspendLayout();
			panel1.SuspendLayout();
			LauncherRunGameCustomCommandLineGroupBox.SuspendLayout();
			LauncherRunGameGroupBox.SuspendLayout();
			LauncherRunGameCustomCommandLineMPGroupBox.SuspendLayout();
			LauncherRunGameModGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(LauncherIconBlops)).BeginInit();
			LauncherGameGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(LauncherIconMP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(LauncherIconSP)).BeginInit();
			LauncherTab.SuspendLayout();
			LauncherTabModBuilder.SuspendLayout();
			LauncherIwdFileGroupBox.SuspendLayout();
			LauncherModGroupBox.SuspendLayout();
			LauncherModFolderGroupBox.SuspendLayout();
			LauncherModBuildGroupBox.SuspendLayout();
			LauncherModZoneSourceGroupBox.SuspendLayout();
			LauncherTabCompileLevel.SuspendLayout();
			LauncherCompileLevelOptionsGroupBox.SuspendLayout();
			LauncherGridFileGroupBox.SuspendLayout();
			LauncherTabExplore.SuspendLayout();
			LauncherExploreGroupBox.SuspendLayout();
			LauncherExploreRawMapsDirGroupBox.SuspendLayout();
			LauncherExploreRawDirGroupBox.SuspendLayout();
			LauncherExploreDevDirGroupBox.SuspendLayout();
			LauncherExploreBlopsDirGroupBox.SuspendLayout();
			LauncherApplicationsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(LauncherIconRadiant)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(LauncherIconEffectsEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(LauncherIconConverter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(LauncherIconAssetViewer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(LauncherIconAssetManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(LauncherWarningsNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(LauncherWarningsPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(LauncherErrorsNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(LauncherErrorsPictureBox)).BeginInit();
			LauncherProcessGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(LauncherMapFilesSystemWatcher)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(LauncherModsDirectorySystemWatcher)).BeginInit();
			menuStrip1.SuspendLayout();
			LauncherMapListContextMenuStrip.SuspendLayout();
			SuspendLayout();
			// 
			// LauncherConsole
			// 
			LauncherConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherConsole.BackColor = System.Drawing.SystemColors.InfoText;
			LauncherConsole.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			LauncherConsole.ForeColor = System.Drawing.SystemColors.ScrollBar;
			LauncherConsole.Location = new System.Drawing.Point(149, 3);
			LauncherConsole.Name = "LauncherConsole";
			LauncherConsole.ReadOnly = true;
			LauncherConsole.Size = new System.Drawing.Size(802, 242);
			LauncherConsole.TabIndex = 0;
			LauncherConsole.Text = "";
			LauncherConsole.WordWrap = false;
			// 
			// LauncherSplitter
			// 
			LauncherSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherSplitter.BackColor = System.Drawing.SystemColors.Control;
			LauncherSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			LauncherSplitter.Location = new System.Drawing.Point(12, 23);
			LauncherSplitter.Name = "LauncherSplitter";
			LauncherSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// LauncherSplitter.Panel1
			// 
			LauncherSplitter.Panel1.Controls.Add(panel1);
			LauncherSplitter.Panel1.Controls.Add(LauncherRunGameCommandLineTextBox);
			LauncherSplitter.Panel1.Controls.Add(LauncherIconBlops);
			LauncherSplitter.Panel1.Controls.Add(LauncherGameGroupBox);
			LauncherSplitter.Panel1.Controls.Add(LauncherTab);
			LauncherSplitter.Panel1.Controls.Add(LauncherApplicationsGroupBox);
			LauncherSplitter.Panel1MinSize = 380;
			// 
			// LauncherSplitter.Panel2
			// 
			LauncherSplitter.Panel2.Controls.Add(LauncherWarningsCounter);
			LauncherSplitter.Panel2.Controls.Add(LauncherWarningsNumericUpDown);
			LauncherSplitter.Panel2.Controls.Add(LauncherWarningsPictureBox);
			LauncherSplitter.Panel2.Controls.Add(LauncherWarningsLabel);
			LauncherSplitter.Panel2.Controls.Add(LauncherErrorsCounter);
			LauncherSplitter.Panel2.Controls.Add(LauncherErrorsNumericUpDown);
			LauncherSplitter.Panel2.Controls.Add(LauncherErrorsPictureBox);
			LauncherSplitter.Panel2.Controls.Add(LauncherErrorsLabel);
			LauncherSplitter.Panel2.Controls.Add(LauncherScrollBottomConsoleButton);
			LauncherSplitter.Panel2.Controls.Add(LauncherSaveConsoleButton);
			LauncherSplitter.Panel2.Controls.Add(LauncherProcessTimeElapsedTextBox);
			LauncherSplitter.Panel2.Controls.Add(LauncherConsole);
			LauncherSplitter.Panel2.Controls.Add(LauncherClearConsoleButton);
			LauncherSplitter.Panel2.Controls.Add(LauncherProcessGroupBox);
			LauncherSplitter.Panel2.Controls.Add(LauncherProcessTextBox);
			LauncherSplitter.Panel2MinSize = 100;
			LauncherSplitter.Size = new System.Drawing.Size(954, 653);
			LauncherSplitter.SplitterDistance = 380;
			LauncherSplitter.TabIndex = 1;
			// 
			// panel1
			// 
			panel1.Controls.Add(LauncherRunGameCustomCommandLineGroupBox);
			panel1.Controls.Add(LauncherRunGameGroupBox);
			panel1.Controls.Add(LauncherRunGameCustomCommandLineMPGroupBox);
			panel1.Controls.Add(LauncherRunGameModGroupBox);
			panel1.Dock = System.Windows.Forms.DockStyle.Right;
			panel1.Location = new System.Drawing.Point(804, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(150, 380);
			panel1.TabIndex = 10;
			// 
			// LauncherRunGameCustomCommandLineGroupBox
			// 
			LauncherRunGameCustomCommandLineGroupBox.Controls.Add(LauncherRunGameCustomCommandLineCheckBox);
			LauncherRunGameCustomCommandLineGroupBox.Controls.Add(LauncherRunGameCustomCommandLineTextBox);
			LauncherRunGameCustomCommandLineGroupBox.Location = new System.Drawing.Point(3, 49);
			LauncherRunGameCustomCommandLineGroupBox.Name = "LauncherRunGameCustomCommandLineGroupBox";
			LauncherRunGameCustomCommandLineGroupBox.Size = new System.Drawing.Size(145, 63);
			LauncherRunGameCustomCommandLineGroupBox.TabIndex = 4;
			LauncherRunGameCustomCommandLineGroupBox.TabStop = false;
			LauncherRunGameCustomCommandLineGroupBox.Text = "Singleplayer Options";
			// 
			// LauncherRunGameCustomCommandLineCheckBox
			// 
			LauncherRunGameCustomCommandLineCheckBox.AutoSize = true;
			LauncherRunGameCustomCommandLineCheckBox.Location = new System.Drawing.Point(6, 15);
			LauncherRunGameCustomCommandLineCheckBox.Name = "LauncherRunGameCustomCommandLineCheckBox";
			LauncherRunGameCustomCommandLineCheckBox.Size = new System.Drawing.Size(65, 17);
			LauncherRunGameCustomCommandLineCheckBox.TabIndex = 1;
			LauncherRunGameCustomCommandLineCheckBox.Text = "Enabled";
			LauncherRunGameCustomCommandLineCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherRunGameCustomCommandLineTextBox
			// 
			LauncherRunGameCustomCommandLineTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherRunGameCustomCommandLineTextBox.Location = new System.Drawing.Point(6, 37);
			LauncherRunGameCustomCommandLineTextBox.Name = "LauncherRunGameCustomCommandLineTextBox";
			LauncherRunGameCustomCommandLineTextBox.Size = new System.Drawing.Size(136, 20);
			LauncherRunGameCustomCommandLineTextBox.TabIndex = 0;
			LauncherRunGameCustomCommandLineTextBox.TextChanged += new System.EventHandler(LauncherRunGameCustomCommandLineTextBox_TextChanged);
			LauncherRunGameCustomCommandLineTextBox.Validating += new System.ComponentModel.CancelEventHandler(LauncherRunGameCustomCommandLineTextBox_Validating);
			// 
			// LauncherRunGameGroupBox
			// 
			LauncherRunGameGroupBox.Controls.Add(LauncherRunGameMapNameTextBox);
			LauncherRunGameGroupBox.Controls.Add(LauncherRunGameLogfileBox);
			LauncherRunGameGroupBox.Controls.Add(LauncherRunGameDeveloperBox);
			LauncherRunGameGroupBox.Controls.Add(LauncherRunGameMapNameLabel);
			LauncherRunGameGroupBox.Controls.Add(LauncherRunGameButton);
			LauncherRunGameGroupBox.Location = new System.Drawing.Point(3, 181);
			LauncherRunGameGroupBox.Name = "LauncherRunGameGroupBox";
			LauncherRunGameGroupBox.Size = new System.Drawing.Size(145, 93);
			LauncherRunGameGroupBox.TabIndex = 11;
			LauncherRunGameGroupBox.TabStop = false;
			LauncherRunGameGroupBox.Text = "Run";
			// 
			// LauncherRunGameMapNameTextBox
			// 
			LauncherRunGameMapNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherRunGameMapNameTextBox.Location = new System.Drawing.Point(32, 19);
			LauncherRunGameMapNameTextBox.Multiline = true;
			LauncherRunGameMapNameTextBox.Name = "LauncherRunGameMapNameTextBox";
			LauncherRunGameMapNameTextBox.ReadOnly = true;
			LauncherRunGameMapNameTextBox.Size = new System.Drawing.Size(110, 19);
			LauncherRunGameMapNameTextBox.TabIndex = 18;
			// 
			// LauncherRunGameLogfileBox
			// 
			LauncherRunGameLogfileBox.AutoSize = true;
			LauncherRunGameLogfileBox.Location = new System.Drawing.Point(82, 44);
			LauncherRunGameLogfileBox.Name = "LauncherRunGameLogfileBox";
			LauncherRunGameLogfileBox.Size = new System.Drawing.Size(57, 17);
			LauncherRunGameLogfileBox.TabIndex = 17;
			LauncherRunGameLogfileBox.Text = "Logfile";
			LauncherRunGameLogfileBox.UseVisualStyleBackColor = true;
			// 
			// LauncherRunGameDeveloperBox
			// 
			LauncherRunGameDeveloperBox.AutoSize = true;
			LauncherRunGameDeveloperBox.Location = new System.Drawing.Point(6, 44);
			LauncherRunGameDeveloperBox.Name = "LauncherRunGameDeveloperBox";
			LauncherRunGameDeveloperBox.Size = new System.Drawing.Size(75, 17);
			LauncherRunGameDeveloperBox.TabIndex = 16;
			LauncherRunGameDeveloperBox.Text = "Developer";
			LauncherRunGameDeveloperBox.UseVisualStyleBackColor = true;
			// 
			// LauncherRunGameMapNameLabel
			// 
			LauncherRunGameMapNameLabel.AutoSize = true;
			LauncherRunGameMapNameLabel.Location = new System.Drawing.Point(3, 25);
			LauncherRunGameMapNameLabel.Name = "LauncherRunGameMapNameLabel";
			LauncherRunGameMapNameLabel.Size = new System.Drawing.Size(28, 13);
			LauncherRunGameMapNameLabel.TabIndex = 15;
			LauncherRunGameMapNameLabel.Text = "Map";
			// 
			// LauncherRunGameButton
			// 
			LauncherRunGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherRunGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			LauncherRunGameButton.Location = new System.Drawing.Point(6, 63);
			LauncherRunGameButton.Name = "LauncherRunGameButton";
			LauncherRunGameButton.Size = new System.Drawing.Size(133, 24);
			LauncherRunGameButton.TabIndex = 2;
			LauncherRunGameButton.Text = "Run";
			LauncherRunGameButton.UseVisualStyleBackColor = true;
			LauncherRunGameButton.Click += new System.EventHandler(LauncherRunGameButton_Click);
			// 
			// LauncherRunGameCustomCommandLineMPGroupBox
			// 
			LauncherRunGameCustomCommandLineMPGroupBox.Controls.Add(LauncherRunGameCustomCommandLineMPCheckBox);
			LauncherRunGameCustomCommandLineMPGroupBox.Controls.Add(LauncherRunGameCustomCommandLineMPTextBox);
			LauncherRunGameCustomCommandLineMPGroupBox.Location = new System.Drawing.Point(3, 118);
			LauncherRunGameCustomCommandLineMPGroupBox.Name = "LauncherRunGameCustomCommandLineMPGroupBox";
			LauncherRunGameCustomCommandLineMPGroupBox.Size = new System.Drawing.Size(145, 63);
			LauncherRunGameCustomCommandLineMPGroupBox.TabIndex = 5;
			LauncherRunGameCustomCommandLineMPGroupBox.TabStop = false;
			LauncherRunGameCustomCommandLineMPGroupBox.Text = "Multiplayer Options";
			// 
			// LauncherRunGameCustomCommandLineMPCheckBox
			// 
			LauncherRunGameCustomCommandLineMPCheckBox.AutoSize = true;
			LauncherRunGameCustomCommandLineMPCheckBox.Location = new System.Drawing.Point(6, 14);
			LauncherRunGameCustomCommandLineMPCheckBox.Name = "LauncherRunGameCustomCommandLineMPCheckBox";
			LauncherRunGameCustomCommandLineMPCheckBox.Size = new System.Drawing.Size(65, 17);
			LauncherRunGameCustomCommandLineMPCheckBox.TabIndex = 2;
			LauncherRunGameCustomCommandLineMPCheckBox.Text = "Enabled";
			LauncherRunGameCustomCommandLineMPCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherRunGameCustomCommandLineMPTextBox
			// 
			LauncherRunGameCustomCommandLineMPTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherRunGameCustomCommandLineMPTextBox.Location = new System.Drawing.Point(6, 37);
			LauncherRunGameCustomCommandLineMPTextBox.Name = "LauncherRunGameCustomCommandLineMPTextBox";
			LauncherRunGameCustomCommandLineMPTextBox.Size = new System.Drawing.Size(136, 20);
			LauncherRunGameCustomCommandLineMPTextBox.TabIndex = 0;
			// 
			// LauncherRunGameModGroupBox
			// 
			LauncherRunGameModGroupBox.Controls.Add(LauncherRunGameModComboBox);
			LauncherRunGameModGroupBox.Location = new System.Drawing.Point(3, 4);
			LauncherRunGameModGroupBox.Name = "LauncherRunGameModGroupBox";
			LauncherRunGameModGroupBox.Size = new System.Drawing.Size(145, 42);
			LauncherRunGameModGroupBox.TabIndex = 1;
			LauncherRunGameModGroupBox.TabStop = false;
			LauncherRunGameModGroupBox.Text = "Mod";
			// 
			// LauncherRunGameModComboBox
			// 
			LauncherRunGameModComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherRunGameModComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			LauncherRunGameModComboBox.FormattingEnabled = true;
			LauncherRunGameModComboBox.Location = new System.Drawing.Point(6, 18);
			LauncherRunGameModComboBox.Name = "LauncherRunGameModComboBox";
			LauncherRunGameModComboBox.Size = new System.Drawing.Size(136, 21);
			LauncherRunGameModComboBox.TabIndex = 0;
			// 
			// LauncherRunGameCommandLineTextBox
			// 
			LauncherRunGameCommandLineTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherRunGameCommandLineTextBox.Location = new System.Drawing.Point(147, 357);
			LauncherRunGameCommandLineTextBox.Name = "LauncherRunGameCommandLineTextBox";
			LauncherRunGameCommandLineTextBox.ReadOnly = true;
			LauncherRunGameCommandLineTextBox.Size = new System.Drawing.Size(648, 20);
			LauncherRunGameCommandLineTextBox.TabIndex = 14;
			// 
			// LauncherIconBlops
			// 
			LauncherIconBlops.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconBlops.BackgroundImage")));
			LauncherIconBlops.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			LauncherIconBlops.Location = new System.Drawing.Point(5, 3);
			LauncherIconBlops.Name = "LauncherIconBlops";
			LauncherIconBlops.Size = new System.Drawing.Size(138, 108);
			LauncherIconBlops.TabIndex = 9;
			LauncherIconBlops.TabStop = false;
			// 
			// LauncherGameGroupBox
			// 
			LauncherGameGroupBox.Controls.Add(LauncherGameLogfileBox);
			LauncherGameGroupBox.Controls.Add(LauncherGameDeveloperBox);
			LauncherGameGroupBox.Controls.Add(LauncherIconMP);
			LauncherGameGroupBox.Controls.Add(LauncherIconSP);
			LauncherGameGroupBox.Controls.Add(LauncherButtonMP);
			LauncherGameGroupBox.Controls.Add(LauncherButtonSP);
			LauncherGameGroupBox.Location = new System.Drawing.Point(4, 115);
			LauncherGameGroupBox.Name = "LauncherGameGroupBox";
			LauncherGameGroupBox.Size = new System.Drawing.Size(139, 65);
			LauncherGameGroupBox.TabIndex = 10;
			LauncherGameGroupBox.TabStop = false;
			LauncherGameGroupBox.Text = "Game";
			// 
			// LauncherGameLogfileBox
			// 
			LauncherGameLogfileBox.AutoSize = true;
			LauncherGameLogfileBox.Location = new System.Drawing.Point(81, 16);
			LauncherGameLogfileBox.Name = "LauncherGameLogfileBox";
			LauncherGameLogfileBox.Size = new System.Drawing.Size(57, 17);
			LauncherGameLogfileBox.TabIndex = 22;
			LauncherGameLogfileBox.Text = "Logfile";
			LauncherGameLogfileBox.UseVisualStyleBackColor = true;
			// 
			// LauncherGameDeveloperBox
			// 
			LauncherGameDeveloperBox.AutoSize = true;
			LauncherGameDeveloperBox.Location = new System.Drawing.Point(5, 16);
			LauncherGameDeveloperBox.Name = "LauncherGameDeveloperBox";
			LauncherGameDeveloperBox.Size = new System.Drawing.Size(75, 17);
			LauncherGameDeveloperBox.TabIndex = 21;
			LauncherGameDeveloperBox.Text = "Developer";
			LauncherGameDeveloperBox.UseVisualStyleBackColor = true;
			// 
			// LauncherIconMP
			// 
			LauncherIconMP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconMP.BackgroundImage")));
			LauncherIconMP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			LauncherIconMP.Enabled = false;
			LauncherIconMP.Location = new System.Drawing.Point(85, 39);
			LauncherIconMP.Name = "LauncherIconMP";
			LauncherIconMP.Size = new System.Drawing.Size(16, 16);
			LauncherIconMP.TabIndex = 20;
			LauncherIconMP.TabStop = false;
			// 
			// LauncherIconSP
			// 
			LauncherIconSP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconSP.BackgroundImage")));
			LauncherIconSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			LauncherIconSP.Enabled = false;
			LauncherIconSP.Location = new System.Drawing.Point(24, 39);
			LauncherIconSP.Name = "LauncherIconSP";
			LauncherIconSP.Size = new System.Drawing.Size(16, 16);
			LauncherIconSP.TabIndex = 11;
			LauncherIconSP.TabStop = false;
			// 
			// LauncherButtonMP
			// 
			LauncherButtonMP.Location = new System.Drawing.Point(71, 35);
			LauncherButtonMP.Name = "LauncherButtonMP";
			LauncherButtonMP.Size = new System.Drawing.Size(64, 24);
			LauncherButtonMP.TabIndex = 1;
			LauncherButtonMP.Text = "     MP";
			LauncherButtonMP.UseVisualStyleBackColor = true;
			LauncherButtonMP.Click += new System.EventHandler(LauncherButtonMP_Click);
			// 
			// LauncherButtonSP
			// 
			LauncherButtonSP.Location = new System.Drawing.Point(8, 35);
			LauncherButtonSP.Name = "LauncherButtonSP";
			LauncherButtonSP.Size = new System.Drawing.Size(64, 24);
			LauncherButtonSP.TabIndex = 0;
			LauncherButtonSP.Text = "     SP";
			LauncherButtonSP.UseVisualStyleBackColor = true;
			LauncherButtonSP.Click += new System.EventHandler(LauncherButtonSP_Click);
			// 
			// LauncherTab
			// 
			LauncherTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherTab.Controls.Add(LauncherTabModBuilder);
			LauncherTab.Controls.Add(LauncherTabCompileLevel);
			LauncherTab.Controls.Add(LauncherTabExplore);
			LauncherTab.Location = new System.Drawing.Point(149, 1);
			LauncherTab.Name = "LauncherTab";
			LauncherTab.SelectedIndex = 0;
			LauncherTab.Size = new System.Drawing.Size(649, 350);
			LauncherTab.TabIndex = 0;
			// 
			// LauncherTabModBuilder
			// 
			LauncherTabModBuilder.Controls.Add(LauncherIwdFileGroupBox);
			LauncherTabModBuilder.Controls.Add(LauncherModGroupBox);
			LauncherTabModBuilder.Location = new System.Drawing.Point(4, 22);
			LauncherTabModBuilder.Name = "LauncherTabModBuilder";
			LauncherTabModBuilder.Padding = new System.Windows.Forms.Padding(3);
			LauncherTabModBuilder.Size = new System.Drawing.Size(641, 324);
			LauncherTabModBuilder.TabIndex = 1;
			LauncherTabModBuilder.Text = "Mod Builder";
			LauncherTabModBuilder.UseVisualStyleBackColor = true;
			// 
			// LauncherIwdFileGroupBox
			// 
			LauncherIwdFileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherIwdFileGroupBox.Controls.Add(LauncherIwdFileTree);
			LauncherIwdFileGroupBox.Location = new System.Drawing.Point(298, 6);
			LauncherIwdFileGroupBox.Name = "LauncherIwdFileGroupBox";
			LauncherIwdFileGroupBox.Size = new System.Drawing.Size(340, 312);
			LauncherIwdFileGroupBox.TabIndex = 2;
			LauncherIwdFileGroupBox.TabStop = false;
			LauncherIwdFileGroupBox.Text = "IWD File List";
			// 
			// LauncherIwdFileTree
			// 
			LauncherIwdFileTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherIwdFileTree.CheckBoxes = true;
			LauncherIwdFileTree.Indent = 15;
			LauncherIwdFileTree.Location = new System.Drawing.Point(6, 19);
			LauncherIwdFileTree.Name = "LauncherIwdFileTree";
			LauncherIwdFileTree.Size = new System.Drawing.Size(328, 287);
			LauncherIwdFileTree.TabIndex = 1;
			LauncherIwdFileTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(LauncherIwdFileTree_AfterCheck);
			LauncherIwdFileTree.DoubleClick += new System.EventHandler(LauncherIwdFileTree_DoubleClick);
			// 
			// LauncherModGroupBox
			// 
			LauncherModGroupBox.Controls.Add(LauncherModFolderGroupBox);
			LauncherModGroupBox.Controls.Add(LauncherModBuildGroupBox);
			LauncherModGroupBox.Controls.Add(LauncherModZoneSourceGroupBox);
			LauncherModGroupBox.Controls.Add(LauncherModComboBox);
			LauncherModGroupBox.Location = new System.Drawing.Point(6, 6);
			LauncherModGroupBox.Name = "LauncherModGroupBox";
			LauncherModGroupBox.Size = new System.Drawing.Size(286, 312);
			LauncherModGroupBox.TabIndex = 4;
			LauncherModGroupBox.TabStop = false;
			LauncherModGroupBox.Text = "Mod";
			// 
			// LauncherModFolderGroupBox
			// 
			LauncherModFolderGroupBox.Controls.Add(LauncherModFolderViewButton);
			LauncherModFolderGroupBox.Location = new System.Drawing.Point(7, 262);
			LauncherModFolderGroupBox.Name = "LauncherModFolderGroupBox";
			LauncherModFolderGroupBox.Size = new System.Drawing.Size(273, 44);
			LauncherModFolderGroupBox.TabIndex = 24;
			LauncherModFolderGroupBox.TabStop = false;
			LauncherModFolderGroupBox.Text = "Mod Folder";
			// 
			// LauncherModFolderViewButton
			// 
			LauncherModFolderViewButton.Location = new System.Drawing.Point(6, 16);
			LauncherModFolderViewButton.Name = "LauncherModFolderViewButton";
			LauncherModFolderViewButton.Size = new System.Drawing.Size(262, 24);
			LauncherModFolderViewButton.TabIndex = 0;
			LauncherModFolderViewButton.Text = "View Mod";
			LauncherModFolderViewButton.UseVisualStyleBackColor = true;
			LauncherModFolderViewButton.Click += new System.EventHandler(LauncherModFolderViewButton_Click);
			// 
			// LauncherModBuildGroupBox
			// 
			LauncherModBuildGroupBox.Controls.Add(LauncherModBuildLinkerOptionsTextBox);
			LauncherModBuildGroupBox.Controls.Add(LauncherModBuildLinkerOptionsLabel);
			LauncherModBuildGroupBox.Controls.Add(LauncherModVerboseCheckBox);
			LauncherModBuildGroupBox.Controls.Add(LauncherModBuildFastFilesCheckBox);
			LauncherModBuildGroupBox.Controls.Add(LauncherModBuildIwdFileCheckBox);
			LauncherModBuildGroupBox.Controls.Add(LauncherModBuildButton);
			LauncherModBuildGroupBox.Controls.Add(LauncherModBuildSoundsCheckBox);
			LauncherModBuildGroupBox.Location = new System.Drawing.Point(7, 136);
			LauncherModBuildGroupBox.Name = "LauncherModBuildGroupBox";
			LauncherModBuildGroupBox.Size = new System.Drawing.Size(273, 120);
			LauncherModBuildGroupBox.TabIndex = 23;
			LauncherModBuildGroupBox.TabStop = false;
			LauncherModBuildGroupBox.Text = "Build Mod";
			// 
			// LauncherModBuildLinkerOptionsTextBox
			// 
			LauncherModBuildLinkerOptionsTextBox.Location = new System.Drawing.Point(128, 61);
			LauncherModBuildLinkerOptionsTextBox.Name = "LauncherModBuildLinkerOptionsTextBox";
			LauncherModBuildLinkerOptionsTextBox.Size = new System.Drawing.Size(137, 20);
			LauncherModBuildLinkerOptionsTextBox.TabIndex = 24;
			// 
			// LauncherModBuildLinkerOptionsLabel
			// 
			LauncherModBuildLinkerOptionsLabel.AutoSize = true;
			LauncherModBuildLinkerOptionsLabel.Location = new System.Drawing.Point(6, 64);
			LauncherModBuildLinkerOptionsLabel.Name = "LauncherModBuildLinkerOptionsLabel";
			LauncherModBuildLinkerOptionsLabel.Size = new System.Drawing.Size(116, 13);
			LauncherModBuildLinkerOptionsLabel.TabIndex = 23;
			LauncherModBuildLinkerOptionsLabel.Text = "Custom Linker Options:";
			// 
			// LauncherModVerboseCheckBox
			// 
			LauncherModVerboseCheckBox.AutoSize = true;
			LauncherModVerboseCheckBox.Location = new System.Drawing.Point(6, 42);
			LauncherModVerboseCheckBox.Name = "LauncherModVerboseCheckBox";
			LauncherModVerboseCheckBox.Size = new System.Drawing.Size(195, 17);
			LauncherModVerboseCheckBox.TabIndex = 22;
			LauncherModVerboseCheckBox.Text = "Verbose (More Detailed Information)";
			LauncherModVerboseCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherModBuildFastFilesCheckBox
			// 
			LauncherModBuildFastFilesCheckBox.AutoSize = true;
			LauncherModBuildFastFilesCheckBox.Location = new System.Drawing.Point(6, 19);
			LauncherModBuildFastFilesCheckBox.Name = "LauncherModBuildFastFilesCheckBox";
			LauncherModBuildFastFilesCheckBox.Size = new System.Drawing.Size(85, 17);
			LauncherModBuildFastFilesCheckBox.TabIndex = 21;
			LauncherModBuildFastFilesCheckBox.Text = "Link FastFile";
			LauncherModBuildFastFilesCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherModBuildIwdFileCheckBox
			// 
			LauncherModBuildIwdFileCheckBox.AutoSize = true;
			LauncherModBuildIwdFileCheckBox.Location = new System.Drawing.Point(97, 19);
			LauncherModBuildIwdFileCheckBox.Name = "LauncherModBuildIwdFileCheckBox";
			LauncherModBuildIwdFileCheckBox.Size = new System.Drawing.Size(74, 17);
			LauncherModBuildIwdFileCheckBox.TabIndex = 20;
			LauncherModBuildIwdFileCheckBox.Text = "Build IWD";
			LauncherModBuildIwdFileCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherModBuildButton
			// 
			LauncherModBuildButton.Location = new System.Drawing.Point(6, 88);
			LauncherModBuildButton.Name = "LauncherModBuildButton";
			LauncherModBuildButton.Size = new System.Drawing.Size(262, 24);
			LauncherModBuildButton.TabIndex = 19;
			LauncherModBuildButton.Text = "Build Mod";
			LauncherModBuildButton.UseVisualStyleBackColor = true;
			LauncherModBuildButton.Click += new System.EventHandler(LauncherModBuildButton_Click);
			// 
			// LauncherModBuildSoundsCheckBox
			// 
			LauncherModBuildSoundsCheckBox.AutoSize = true;
			LauncherModBuildSoundsCheckBox.Enabled = false;
			LauncherModBuildSoundsCheckBox.Location = new System.Drawing.Point(177, 19);
			LauncherModBuildSoundsCheckBox.Name = "LauncherModBuildSoundsCheckBox";
			LauncherModBuildSoundsCheckBox.Size = new System.Drawing.Size(88, 17);
			LauncherModBuildSoundsCheckBox.TabIndex = 18;
			LauncherModBuildSoundsCheckBox.Text = "Build Sounds";
			LauncherModBuildSoundsCheckBox.UseVisualStyleBackColor = true;
			LauncherModBuildSoundsCheckBox.Visible = false;
			// 
			// LauncherModZoneSourceGroupBox
			// 
			LauncherModZoneSourceGroupBox.Controls.Add(LauncherModZoneSourceCSVButton);
			LauncherModZoneSourceGroupBox.Controls.Add(LauncherModZoneSourceMissingAssetsButton);
			LauncherModZoneSourceGroupBox.Controls.Add(LauncherEditZoneSourceButton);
			LauncherModZoneSourceGroupBox.Location = new System.Drawing.Point(6, 47);
			LauncherModZoneSourceGroupBox.Name = "LauncherModZoneSourceGroupBox";
			LauncherModZoneSourceGroupBox.Size = new System.Drawing.Size(274, 83);
			LauncherModZoneSourceGroupBox.TabIndex = 22;
			LauncherModZoneSourceGroupBox.TabStop = false;
			LauncherModZoneSourceGroupBox.Text = "FastFile Zone Source";
			// 
			// LauncherModZoneSourceCSVButton
			// 
			LauncherModZoneSourceCSVButton.Location = new System.Drawing.Point(138, 50);
			LauncherModZoneSourceCSVButton.Name = "LauncherModZoneSourceCSVButton";
			LauncherModZoneSourceCSVButton.Size = new System.Drawing.Size(130, 23);
			LauncherModZoneSourceCSVButton.TabIndex = 24;
			LauncherModZoneSourceCSVButton.Text = "Zone Source";
			LauncherModZoneSourceCSVButton.UseVisualStyleBackColor = true;
			LauncherModZoneSourceCSVButton.Click += new System.EventHandler(LauncherModZoneSourceCSVButton_Click);
			// 
			// LauncherModZoneSourceMissingAssetsButton
			// 
			LauncherModZoneSourceMissingAssetsButton.Location = new System.Drawing.Point(6, 50);
			LauncherModZoneSourceMissingAssetsButton.Name = "LauncherModZoneSourceMissingAssetsButton";
			LauncherModZoneSourceMissingAssetsButton.Size = new System.Drawing.Size(130, 23);
			LauncherModZoneSourceMissingAssetsButton.TabIndex = 23;
			LauncherModZoneSourceMissingAssetsButton.Text = "Missing Assets";
			LauncherModZoneSourceMissingAssetsButton.UseVisualStyleBackColor = true;
			LauncherModZoneSourceMissingAssetsButton.Click += new System.EventHandler(LauncherModZoneSourceMissingAssetsButton_Click);
			// 
			// LauncherEditZoneSourceButton
			// 
			LauncherEditZoneSourceButton.Location = new System.Drawing.Point(6, 19);
			LauncherEditZoneSourceButton.Name = "LauncherEditZoneSourceButton";
			LauncherEditZoneSourceButton.Size = new System.Drawing.Size(262, 24);
			LauncherEditZoneSourceButton.TabIndex = 22;
			LauncherEditZoneSourceButton.Text = "Edit Zone Source";
			LauncherEditZoneSourceButton.UseVisualStyleBackColor = true;
			LauncherEditZoneSourceButton.Click += new System.EventHandler(LauncherEditZoneSourceButton_Click);
			// 
			// LauncherModComboBox
			// 
			LauncherModComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			LauncherModComboBox.FormattingEnabled = true;
			LauncherModComboBox.Location = new System.Drawing.Point(6, 20);
			LauncherModComboBox.Name = "LauncherModComboBox";
			LauncherModComboBox.Size = new System.Drawing.Size(274, 21);
			LauncherModComboBox.TabIndex = 3;
			LauncherModComboBox.SelectedIndexChanged += new System.EventHandler(LauncherModComboBox_SelectedIndexChanged);
			// 
			// LauncherTabCompileLevel
			// 
			LauncherTabCompileLevel.Controls.Add(LauncherMapType);
			LauncherTabCompileLevel.Controls.Add(LauncherMapTypeList);
			LauncherTabCompileLevel.Controls.Add(LauncherCreateMapButton);
			LauncherTabCompileLevel.Controls.Add(LauncherDeleteMapButton);
			LauncherTabCompileLevel.Controls.Add(LauncherCompileLevelOptionsGroupBox);
			LauncherTabCompileLevel.Controls.Add(LauncherMapList);
			LauncherTabCompileLevel.Location = new System.Drawing.Point(4, 22);
			LauncherTabCompileLevel.Name = "LauncherTabCompileLevel";
			LauncherTabCompileLevel.Padding = new System.Windows.Forms.Padding(3);
			LauncherTabCompileLevel.Size = new System.Drawing.Size(641, 324);
			LauncherTabCompileLevel.TabIndex = 0;
			LauncherTabCompileLevel.Text = "Level";
			LauncherTabCompileLevel.UseVisualStyleBackColor = true;
			// 
			// LauncherMapType
			// 
			LauncherMapType.AutoSize = true;
			LauncherMapType.Location = new System.Drawing.Point(6, 9);
			LauncherMapType.Name = "LauncherMapType";
			LauncherMapType.Size = new System.Drawing.Size(34, 13);
			LauncherMapType.TabIndex = 6;
			LauncherMapType.Text = "Type:";
			// 
			// LauncherMapTypeList
			// 
			LauncherMapTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			LauncherMapTypeList.FormattingEnabled = true;
			LauncherMapTypeList.Items.AddRange(new object[] {
            "Singleplayer",
            "Multiplayer"});
			LauncherMapTypeList.Location = new System.Drawing.Point(46, 4);
			LauncherMapTypeList.Name = "LauncherMapTypeList";
			LauncherMapTypeList.Size = new System.Drawing.Size(110, 21);
			LauncherMapTypeList.TabIndex = 5;
			LauncherMapTypeList.SelectedIndexChanged += new System.EventHandler(LauncherMapTypeList_SelectedIndexChanged);
			// 
			// LauncherCreateMapButton
			// 
			LauncherCreateMapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			LauncherCreateMapButton.Location = new System.Drawing.Point(82, 294);
			LauncherCreateMapButton.Name = "LauncherCreateMapButton";
			LauncherCreateMapButton.Size = new System.Drawing.Size(74, 24);
			LauncherCreateMapButton.TabIndex = 4;
			LauncherCreateMapButton.Text = "Create Map";
			LauncherCreateMapButton.UseVisualStyleBackColor = true;
			LauncherCreateMapButton.Click += new System.EventHandler(LauncherCreateMap_Click);
			// 
			// LauncherDeleteMapButton
			// 
			LauncherDeleteMapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			LauncherDeleteMapButton.Location = new System.Drawing.Point(6, 294);
			LauncherDeleteMapButton.Name = "LauncherDeleteMapButton";
			LauncherDeleteMapButton.Size = new System.Drawing.Size(74, 24);
			LauncherDeleteMapButton.TabIndex = 4;
			LauncherDeleteMapButton.Text = "Delete Map";
			LauncherDeleteMapButton.UseVisualStyleBackColor = true;
			LauncherDeleteMapButton.Click += new System.EventHandler(LauncherDeleteMap_Click);
			// 
			// LauncherCompileLevelOptionsGroupBox
			// 
			LauncherCompileLevelOptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherCompileReflectionsCheckBox);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherGridFileGroupBox);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherModSpecificMapComboBox);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherModSpecificMapCheckBox);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherCustomRunOptionsLabel);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherCustomRunOptionsTextBox);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(label);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherCompileLevelButton);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherCompileLightsButton);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherCompileBSPButton);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherUseRunGameTypeOptionsCheckBox);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherRunMapAfterCompileCheckBox);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherBspInfoCheckBox);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherBuildFastFilesCheckBox);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherConnectPathsCheckBox);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherCompileLightsCheckBox);
			LauncherCompileLevelOptionsGroupBox.Controls.Add(LauncherCompileBSPCheckBox);
			LauncherCompileLevelOptionsGroupBox.Location = new System.Drawing.Point(162, 6);
			LauncherCompileLevelOptionsGroupBox.Name = "LauncherCompileLevelOptionsGroupBox";
			LauncherCompileLevelOptionsGroupBox.Size = new System.Drawing.Size(473, 312);
			LauncherCompileLevelOptionsGroupBox.TabIndex = 3;
			LauncherCompileLevelOptionsGroupBox.TabStop = false;
			LauncherCompileLevelOptionsGroupBox.Text = "Compile Level Options";
			// 
			// LauncherCompileReflectionsCheckBox
			// 
			LauncherCompileReflectionsCheckBox.AutoSize = true;
			LauncherCompileReflectionsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			LauncherCompileReflectionsCheckBox.Location = new System.Drawing.Point(9, 88);
			LauncherCompileReflectionsCheckBox.Name = "LauncherCompileReflectionsCheckBox";
			LauncherCompileReflectionsCheckBox.Size = new System.Drawing.Size(117, 17);
			LauncherCompileReflectionsCheckBox.TabIndex = 19;
			LauncherCompileReflectionsCheckBox.Text = "Compile Reflections";
			LauncherCompileReflectionsCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherGridFileGroupBox
			// 
			LauncherGridFileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			LauncherGridFileGroupBox.Controls.Add(LauncherGridEditExistingButton);
			LauncherGridFileGroupBox.Controls.Add(LauncherGridMakeNewButton);
			LauncherGridFileGroupBox.Controls.Add(LauncherGridCollectDotsCheckBox);
			LauncherGridFileGroupBox.Location = new System.Drawing.Point(6, 230);
			LauncherGridFileGroupBox.Name = "LauncherGridFileGroupBox";
			LauncherGridFileGroupBox.Size = new System.Drawing.Size(223, 76);
			LauncherGridFileGroupBox.TabIndex = 18;
			LauncherGridFileGroupBox.TabStop = false;
			LauncherGridFileGroupBox.Text = "Grid File";
			// 
			// LauncherGridEditExistingButton
			// 
			LauncherGridEditExistingButton.Location = new System.Drawing.Point(112, 42);
			LauncherGridEditExistingButton.Name = "LauncherGridEditExistingButton";
			LauncherGridEditExistingButton.Size = new System.Drawing.Size(100, 23);
			LauncherGridEditExistingButton.TabIndex = 19;
			LauncherGridEditExistingButton.Text = "Edit Existing Grid";
			LauncherGridEditExistingButton.UseVisualStyleBackColor = true;
			LauncherGridEditExistingButton.Click += new System.EventHandler(LauncherGridEditExistingButton_Click);
			// 
			// LauncherGridMakeNewButton
			// 
			LauncherGridMakeNewButton.Location = new System.Drawing.Point(6, 42);
			LauncherGridMakeNewButton.Name = "LauncherGridMakeNewButton";
			LauncherGridMakeNewButton.Size = new System.Drawing.Size(100, 23);
			LauncherGridMakeNewButton.TabIndex = 18;
			LauncherGridMakeNewButton.Text = "Make New Grid";
			LauncherGridMakeNewButton.UseVisualStyleBackColor = true;
			LauncherGridMakeNewButton.Click += new System.EventHandler(LauncherGridMakeNewButton_Click);
			// 
			// LauncherGridCollectDotsCheckBox
			// 
			LauncherGridCollectDotsCheckBox.AutoSize = true;
			LauncherGridCollectDotsCheckBox.Location = new System.Drawing.Point(6, 19);
			LauncherGridCollectDotsCheckBox.Name = "LauncherGridCollectDotsCheckBox";
			LauncherGridCollectDotsCheckBox.Size = new System.Drawing.Size(120, 17);
			LauncherGridCollectDotsCheckBox.TabIndex = 17;
			LauncherGridCollectDotsCheckBox.Text = "Models Collect Dots";
			LauncherGridCollectDotsCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherModSpecificMapComboBox
			// 
			LauncherModSpecificMapComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherModSpecificMapComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			LauncherModSpecificMapComboBox.Enabled = false;
			LauncherModSpecificMapComboBox.FormattingEnabled = true;
			LauncherModSpecificMapComboBox.Items.AddRange(new object[] {
            "HumorOneMod",
            "HumorTwoMod",
            "BlahBlahMod"});
			LauncherModSpecificMapComboBox.Location = new System.Drawing.Point(149, 41);
			LauncherModSpecificMapComboBox.Name = "LauncherModSpecificMapComboBox";
			LauncherModSpecificMapComboBox.Size = new System.Drawing.Size(318, 21);
			LauncherModSpecificMapComboBox.TabIndex = 4;
			// 
			// LauncherModSpecificMapCheckBox
			// 
			LauncherModSpecificMapCheckBox.AutoSize = true;
			LauncherModSpecificMapCheckBox.Location = new System.Drawing.Point(149, 16);
			LauncherModSpecificMapCheckBox.Name = "LauncherModSpecificMapCheckBox";
			LauncherModSpecificMapCheckBox.Size = new System.Drawing.Size(112, 17);
			LauncherModSpecificMapCheckBox.TabIndex = 5;
			LauncherModSpecificMapCheckBox.Text = "Mod Specific Map";
			LauncherModSpecificMapCheckBox.UseVisualStyleBackColor = true;
			LauncherModSpecificMapCheckBox.CheckedChanged += new System.EventHandler(LauncherModSpecificMapCheckBox_CheckedChanged);
			// 
			// LauncherCustomRunOptionsLabel
			// 
			LauncherCustomRunOptionsLabel.AutoSize = true;
			LauncherCustomRunOptionsLabel.Location = new System.Drawing.Point(6, 206);
			LauncherCustomRunOptionsLabel.Name = "LauncherCustomRunOptionsLabel";
			LauncherCustomRunOptionsLabel.Size = new System.Drawing.Size(107, 13);
			LauncherCustomRunOptionsLabel.TabIndex = 14;
			LauncherCustomRunOptionsLabel.Text = "Custom Run Options:";
			LauncherCustomRunOptionsLabel.Visible = false;
			// 
			// LauncherCustomRunOptionsTextBox
			// 
			LauncherCustomRunOptionsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherCustomRunOptionsTextBox.Location = new System.Drawing.Point(119, 203);
			LauncherCustomRunOptionsTextBox.Name = "LauncherCustomRunOptionsTextBox";
			LauncherCustomRunOptionsTextBox.Size = new System.Drawing.Size(348, 20);
			LauncherCustomRunOptionsTextBox.TabIndex = 13;
			LauncherCustomRunOptionsTextBox.Visible = false;
			// 
			// label
			// 
			label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			label.BackColor = System.Drawing.Color.Gainsboro;
			label.CausesValidation = false;
			label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			label.Location = new System.Drawing.Point(0, 107);
			label.Name = "label";
			label.Size = new System.Drawing.Size(473, 1);
			label.TabIndex = 12;
			// 
			// LauncherCompileLevelButton
			// 
			LauncherCompileLevelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherCompileLevelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			LauncherCompileLevelButton.Location = new System.Drawing.Point(340, 229);
			LauncherCompileLevelButton.Name = "LauncherCompileLevelButton";
			LauncherCompileLevelButton.Size = new System.Drawing.Size(128, 76);
			LauncherCompileLevelButton.TabIndex = 4;
			LauncherCompileLevelButton.Text = "Compile Level";
			LauncherCompileLevelButton.UseVisualStyleBackColor = true;
			LauncherCompileLevelButton.Click += new System.EventHandler(LauncherCompileLevelButton_Click);
			// 
			// LauncherCompileLightsButton
			// 
			LauncherCompileLightsButton.Location = new System.Drawing.Point(107, 16);
			LauncherCompileLightsButton.Name = "LauncherCompileLightsButton";
			LauncherCompileLightsButton.Size = new System.Drawing.Size(26, 23);
			LauncherCompileLightsButton.TabIndex = 11;
			LauncherCompileLightsButton.Text = "...";
			LauncherCompileLightsButton.UseVisualStyleBackColor = true;
			LauncherCompileLightsButton.Click += new System.EventHandler(LauncherCompileLightsButton_Click);
			// 
			// LauncherCompileBSPButton
			// 
			LauncherCompileBSPButton.Location = new System.Drawing.Point(107, 39);
			LauncherCompileBSPButton.Name = "LauncherCompileBSPButton";
			LauncherCompileBSPButton.Size = new System.Drawing.Size(26, 23);
			LauncherCompileBSPButton.TabIndex = 10;
			LauncherCompileBSPButton.Text = "...";
			LauncherCompileBSPButton.UseVisualStyleBackColor = true;
			LauncherCompileBSPButton.Click += new System.EventHandler(LauncherCompileBSPButton_Click);
			// 
			// LauncherUseRunGameTypeOptionsCheckBox
			// 
			LauncherUseRunGameTypeOptionsCheckBox.AutoSize = true;
			LauncherUseRunGameTypeOptionsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			LauncherUseRunGameTypeOptionsCheckBox.Location = new System.Drawing.Point(9, 180);
			LauncherUseRunGameTypeOptionsCheckBox.Name = "LauncherUseRunGameTypeOptionsCheckBox";
			LauncherUseRunGameTypeOptionsCheckBox.Size = new System.Drawing.Size(162, 17);
			LauncherUseRunGameTypeOptionsCheckBox.TabIndex = 9;
			LauncherUseRunGameTypeOptionsCheckBox.Text = "Use \'Run Game Tab\' Options";
			LauncherUseRunGameTypeOptionsCheckBox.UseVisualStyleBackColor = true;
			LauncherUseRunGameTypeOptionsCheckBox.Visible = false;
			// 
			// LauncherRunMapAfterCompileCheckBox
			// 
			LauncherRunMapAfterCompileCheckBox.AutoSize = true;
			LauncherRunMapAfterCompileCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			LauncherRunMapAfterCompileCheckBox.Location = new System.Drawing.Point(9, 157);
			LauncherRunMapAfterCompileCheckBox.Name = "LauncherRunMapAfterCompileCheckBox";
			LauncherRunMapAfterCompileCheckBox.Size = new System.Drawing.Size(133, 17);
			LauncherRunMapAfterCompileCheckBox.TabIndex = 8;
			LauncherRunMapAfterCompileCheckBox.Text = "Run Map After Compile";
			LauncherRunMapAfterCompileCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherBspInfoCheckBox
			// 
			LauncherBspInfoCheckBox.AutoSize = true;
			LauncherBspInfoCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			LauncherBspInfoCheckBox.Location = new System.Drawing.Point(9, 134);
			LauncherBspInfoCheckBox.Name = "LauncherBspInfoCheckBox";
			LauncherBspInfoCheckBox.Size = new System.Drawing.Size(66, 17);
			LauncherBspInfoCheckBox.TabIndex = 7;
			LauncherBspInfoCheckBox.Text = "BSP Info";
			LauncherBspInfoCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherBuildFastFilesCheckBox
			// 
			LauncherBuildFastFilesCheckBox.AutoSize = true;
			LauncherBuildFastFilesCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			LauncherBuildFastFilesCheckBox.Location = new System.Drawing.Point(9, 111);
			LauncherBuildFastFilesCheckBox.Name = "LauncherBuildFastFilesCheckBox";
			LauncherBuildFastFilesCheckBox.Size = new System.Drawing.Size(88, 17);
			LauncherBuildFastFilesCheckBox.TabIndex = 6;
			LauncherBuildFastFilesCheckBox.Text = "Build Fastfiles";
			LauncherBuildFastFilesCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherConnectPathsCheckBox
			// 
			LauncherConnectPathsCheckBox.AutoSize = true;
			LauncherConnectPathsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			LauncherConnectPathsCheckBox.Location = new System.Drawing.Point(9, 65);
			LauncherConnectPathsCheckBox.Name = "LauncherConnectPathsCheckBox";
			LauncherConnectPathsCheckBox.Size = new System.Drawing.Size(94, 17);
			LauncherConnectPathsCheckBox.TabIndex = 3;
			LauncherConnectPathsCheckBox.Text = "Connect Paths";
			LauncherConnectPathsCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherCompileLightsCheckBox
			// 
			LauncherCompileLightsCheckBox.AutoSize = true;
			LauncherCompileLightsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			LauncherCompileLightsCheckBox.Location = new System.Drawing.Point(9, 42);
			LauncherCompileLightsCheckBox.Name = "LauncherCompileLightsCheckBox";
			LauncherCompileLightsCheckBox.Size = new System.Drawing.Size(92, 17);
			LauncherCompileLightsCheckBox.TabIndex = 1;
			LauncherCompileLightsCheckBox.Text = "Compile Lights";
			LauncherCompileLightsCheckBox.UseVisualStyleBackColor = true;
			LauncherCompileLightsCheckBox.CheckedChanged += new System.EventHandler(LauncherCompileLightsCheckBox_CheckedChanged);
			// 
			// LauncherCompileBSPCheckBox
			// 
			LauncherCompileBSPCheckBox.AutoSize = true;
			LauncherCompileBSPCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			LauncherCompileBSPCheckBox.Location = new System.Drawing.Point(9, 19);
			LauncherCompileBSPCheckBox.Name = "LauncherCompileBSPCheckBox";
			LauncherCompileBSPCheckBox.Size = new System.Drawing.Size(85, 17);
			LauncherCompileBSPCheckBox.TabIndex = 0;
			LauncherCompileBSPCheckBox.Text = "Compile BSP";
			LauncherCompileBSPCheckBox.UseVisualStyleBackColor = true;
			// 
			// LauncherMapList
			// 
			LauncherMapList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			LauncherMapList.FormattingEnabled = true;
			LauncherMapList.IntegralHeight = false;
			LauncherMapList.Location = new System.Drawing.Point(6, 31);
			LauncherMapList.Name = "LauncherMapList";
			LauncherMapList.Size = new System.Drawing.Size(150, 261);
			LauncherMapList.TabIndex = 1;
			LauncherMapList.SelectedIndexChanged += new System.EventHandler(LauncherMapList_SelectedIndexChanged);
			LauncherMapList.DoubleClick += new System.EventHandler(LauncherMapList_DoubleClick);
			LauncherMapList.MouseDown += new System.Windows.Forms.MouseEventHandler(LauncherMapList_MouseDown);
			LauncherMapList.MouseUp += new System.Windows.Forms.MouseEventHandler(LauncherMapList_MouseUp);
			// 
			// LauncherTabExplore
			// 
			LauncherTabExplore.Controls.Add(LauncherExploreGroupBox);
			LauncherTabExplore.Location = new System.Drawing.Point(4, 22);
			LauncherTabExplore.Name = "LauncherTabExplore";
			LauncherTabExplore.Padding = new System.Windows.Forms.Padding(3);
			LauncherTabExplore.Size = new System.Drawing.Size(641, 324);
			LauncherTabExplore.TabIndex = 3;
			LauncherTabExplore.Text = "Explore";
			LauncherTabExplore.UseVisualStyleBackColor = true;
			// 
			// LauncherExploreGroupBox
			// 
			LauncherExploreGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherExploreGroupBox.Controls.Add(LauncherExploreRawMapsDirGroupBox);
			LauncherExploreGroupBox.Controls.Add(LauncherExploreRawDirGroupBox);
			LauncherExploreGroupBox.Controls.Add(LauncherExploreDevDirGroupBox);
			LauncherExploreGroupBox.Controls.Add(LauncherExploreBlopsDirGroupBox);
			LauncherExploreGroupBox.Location = new System.Drawing.Point(6, 6);
			LauncherExploreGroupBox.Name = "LauncherExploreGroupBox";
			LauncherExploreGroupBox.Size = new System.Drawing.Size(629, 312);
			LauncherExploreGroupBox.TabIndex = 0;
			LauncherExploreGroupBox.TabStop = false;
			LauncherExploreGroupBox.Text = "Explore";
			// 
			// LauncherExploreRawMapsDirGroupBox
			// 
			LauncherExploreRawMapsDirGroupBox.Controls.Add(LauncherExploreRawGSCDirMPGametypesButton);
			LauncherExploreRawMapsDirGroupBox.Controls.Add(LauncherExploreRawGSCDirMPFXButton);
			LauncherExploreRawMapsDirGroupBox.Controls.Add(LauncherExploreRawGSCDirMPArtButton);
			LauncherExploreRawMapsDirGroupBox.Controls.Add(LauncherExploreRawGSCDirMPButton);
			LauncherExploreRawMapsDirGroupBox.Controls.Add(LauncherExploreRawGSCDirSPVoiceButton);
			LauncherExploreRawMapsDirGroupBox.Controls.Add(LauncherExploreRawGSCDirSPGametypesButton);
			LauncherExploreRawMapsDirGroupBox.Controls.Add(LauncherExploreRawGSCDirSPFXButton);
			LauncherExploreRawMapsDirGroupBox.Controls.Add(LauncherExploreRawGSCDirSPArtButton);
			LauncherExploreRawMapsDirGroupBox.Controls.Add(LauncherExploreRawGSCDirSPButton);
			LauncherExploreRawMapsDirGroupBox.Location = new System.Drawing.Point(463, 19);
			LauncherExploreRawMapsDirGroupBox.Name = "LauncherExploreRawMapsDirGroupBox";
			LauncherExploreRawMapsDirGroupBox.Size = new System.Drawing.Size(142, 226);
			LauncherExploreRawMapsDirGroupBox.TabIndex = 20;
			LauncherExploreRawMapsDirGroupBox.TabStop = false;
			LauncherExploreRawMapsDirGroupBox.Text = "Raw Maps Folders";
			// 
			// LauncherExploreRawGSCDirMPGametypesButton
			// 
			LauncherExploreRawGSCDirMPGametypesButton.Location = new System.Drawing.Point(6, 198);
			LauncherExploreRawGSCDirMPGametypesButton.Name = "LauncherExploreRawGSCDirMPGametypesButton";
			LauncherExploreRawGSCDirMPGametypesButton.Size = new System.Drawing.Size(64, 24);
			LauncherExploreRawGSCDirMPGametypesButton.TabIndex = 29;
			LauncherExploreRawGSCDirMPGametypesButton.Text = "Gametypes";
			LauncherExploreRawGSCDirMPGametypesButton.UseVisualStyleBackColor = true;
			LauncherExploreRawGSCDirMPGametypesButton.Click += new System.EventHandler(LauncherExploreRawGSCDirMPGametypesButton_Click);
			// 
			// LauncherExploreRawGSCDirMPFXButton
			// 
			LauncherExploreRawGSCDirMPFXButton.Location = new System.Drawing.Point(72, 168);
			LauncherExploreRawGSCDirMPFXButton.Name = "LauncherExploreRawGSCDirMPFXButton";
			LauncherExploreRawGSCDirMPFXButton.Size = new System.Drawing.Size(64, 24);
			LauncherExploreRawGSCDirMPFXButton.TabIndex = 28;
			LauncherExploreRawGSCDirMPFXButton.Text = "CreateFX";
			LauncherExploreRawGSCDirMPFXButton.UseVisualStyleBackColor = true;
			LauncherExploreRawGSCDirMPFXButton.Click += new System.EventHandler(LauncherExploreRawGSCDirMPFXButton_Click);
			// 
			// LauncherExploreRawGSCDirMPArtButton
			// 
			LauncherExploreRawGSCDirMPArtButton.Location = new System.Drawing.Point(6, 168);
			LauncherExploreRawGSCDirMPArtButton.Name = "LauncherExploreRawGSCDirMPArtButton";
			LauncherExploreRawGSCDirMPArtButton.Size = new System.Drawing.Size(64, 24);
			LauncherExploreRawGSCDirMPArtButton.TabIndex = 27;
			LauncherExploreRawGSCDirMPArtButton.Text = "CreateArt";
			LauncherExploreRawGSCDirMPArtButton.UseVisualStyleBackColor = true;
			LauncherExploreRawGSCDirMPArtButton.Click += new System.EventHandler(LauncherExploreRawGSCDirMPArtButton_Click);
			// 
			// LauncherExploreRawGSCDirMPButton
			// 
			LauncherExploreRawGSCDirMPButton.Location = new System.Drawing.Point(6, 138);
			LauncherExploreRawGSCDirMPButton.Name = "LauncherExploreRawGSCDirMPButton";
			LauncherExploreRawGSCDirMPButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreRawGSCDirMPButton.TabIndex = 26;
			LauncherExploreRawGSCDirMPButton.Text = "Multiplayer";
			LauncherExploreRawGSCDirMPButton.UseVisualStyleBackColor = true;
			LauncherExploreRawGSCDirMPButton.Click += new System.EventHandler(LauncherExploreRawGSCDirMPButton_Click);
			// 
			// LauncherExploreRawGSCDirSPVoiceButton
			// 
			LauncherExploreRawGSCDirSPVoiceButton.Location = new System.Drawing.Point(72, 79);
			LauncherExploreRawGSCDirSPVoiceButton.Name = "LauncherExploreRawGSCDirSPVoiceButton";
			LauncherExploreRawGSCDirSPVoiceButton.Size = new System.Drawing.Size(64, 24);
			LauncherExploreRawGSCDirSPVoiceButton.TabIndex = 25;
			LauncherExploreRawGSCDirSPVoiceButton.Text = "Voice";
			LauncherExploreRawGSCDirSPVoiceButton.UseVisualStyleBackColor = true;
			LauncherExploreRawGSCDirSPVoiceButton.Click += new System.EventHandler(LauncherExploreRawGSCDirSPVoiceButton_Click);
			// 
			// LauncherExploreRawGSCDirSPGametypesButton
			// 
			LauncherExploreRawGSCDirSPGametypesButton.Location = new System.Drawing.Point(6, 79);
			LauncherExploreRawGSCDirSPGametypesButton.Name = "LauncherExploreRawGSCDirSPGametypesButton";
			LauncherExploreRawGSCDirSPGametypesButton.Size = new System.Drawing.Size(64, 24);
			LauncherExploreRawGSCDirSPGametypesButton.TabIndex = 24;
			LauncherExploreRawGSCDirSPGametypesButton.Text = "Gametypes";
			LauncherExploreRawGSCDirSPGametypesButton.UseVisualStyleBackColor = true;
			LauncherExploreRawGSCDirSPGametypesButton.Click += new System.EventHandler(LauncherExploreRawGSCDirSPGametypesButton_Click);
			// 
			// LauncherExploreRawGSCDirSPFXButton
			// 
			LauncherExploreRawGSCDirSPFXButton.Location = new System.Drawing.Point(72, 49);
			LauncherExploreRawGSCDirSPFXButton.Name = "LauncherExploreRawGSCDirSPFXButton";
			LauncherExploreRawGSCDirSPFXButton.Size = new System.Drawing.Size(64, 24);
			LauncherExploreRawGSCDirSPFXButton.TabIndex = 23;
			LauncherExploreRawGSCDirSPFXButton.Text = "CreateFX";
			LauncherExploreRawGSCDirSPFXButton.UseVisualStyleBackColor = true;
			LauncherExploreRawGSCDirSPFXButton.Click += new System.EventHandler(LauncherExploreRawGSCDirSPFXButton_Click);
			// 
			// LauncherExploreRawGSCDirSPArtButton
			// 
			LauncherExploreRawGSCDirSPArtButton.Location = new System.Drawing.Point(6, 49);
			LauncherExploreRawGSCDirSPArtButton.Name = "LauncherExploreRawGSCDirSPArtButton";
			LauncherExploreRawGSCDirSPArtButton.Size = new System.Drawing.Size(64, 24);
			LauncherExploreRawGSCDirSPArtButton.TabIndex = 22;
			LauncherExploreRawGSCDirSPArtButton.Text = "CreateArt";
			LauncherExploreRawGSCDirSPArtButton.UseVisualStyleBackColor = true;
			LauncherExploreRawGSCDirSPArtButton.Click += new System.EventHandler(LauncherExploreRawGSCDirSPArtButton_Click);
			// 
			// LauncherExploreRawGSCDirSPButton
			// 
			LauncherExploreRawGSCDirSPButton.Location = new System.Drawing.Point(6, 19);
			LauncherExploreRawGSCDirSPButton.Name = "LauncherExploreRawGSCDirSPButton";
			LauncherExploreRawGSCDirSPButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreRawGSCDirSPButton.TabIndex = 21;
			LauncherExploreRawGSCDirSPButton.Text = "Singleplayer";
			LauncherExploreRawGSCDirSPButton.UseVisualStyleBackColor = true;
			LauncherExploreRawGSCDirSPButton.Click += new System.EventHandler(LauncherExploreRawGSCDirSPButton_Click);
			// 
			// LauncherExploreRawDirGroupBox
			// 
			LauncherExploreRawDirGroupBox.Controls.Add(LauncherExploreRawDirFXButton);
			LauncherExploreRawDirGroupBox.Controls.Add(LauncherExploreRawDirMPButton);
			LauncherExploreRawDirGroupBox.Controls.Add(LauncherExploreRawDirWeaponsButton);
			LauncherExploreRawDirGroupBox.Controls.Add(LauncherExploreRawDirVisionButton);
			LauncherExploreRawDirGroupBox.Controls.Add(LauncherExploreRawDirLocsButton);
			LauncherExploreRawDirGroupBox.Controls.Add(LauncherExploreRawDirAnimTreesButton);
			LauncherExploreRawDirGroupBox.Controls.Add(LauncherExploreRawDirSoundAliasesButton);
			LauncherExploreRawDirGroupBox.Controls.Add(LauncherExploreRawDirCSCButton);
			LauncherExploreRawDirGroupBox.Controls.Add(LauncherExploreRawDirGSCButton);
			LauncherExploreRawDirGroupBox.Location = new System.Drawing.Point(315, 19);
			LauncherExploreRawDirGroupBox.Name = "LauncherExploreRawDirGroupBox";
			LauncherExploreRawDirGroupBox.Size = new System.Drawing.Size(142, 287);
			LauncherExploreRawDirGroupBox.TabIndex = 19;
			LauncherExploreRawDirGroupBox.TabStop = false;
			LauncherExploreRawDirGroupBox.Text = "Raw Folders";
			// 
			// LauncherExploreRawDirFXButton
			// 
			LauncherExploreRawDirFXButton.Location = new System.Drawing.Point(6, 109);
			LauncherExploreRawDirFXButton.Name = "LauncherExploreRawDirFXButton";
			LauncherExploreRawDirFXButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreRawDirFXButton.TabIndex = 25;
			LauncherExploreRawDirFXButton.Text = "FX";
			LauncherExploreRawDirFXButton.UseVisualStyleBackColor = true;
			LauncherExploreRawDirFXButton.Click += new System.EventHandler(LauncherExploreRawDirFXButton_Click);
			// 
			// LauncherExploreRawDirMPButton
			// 
			LauncherExploreRawDirMPButton.Location = new System.Drawing.Point(6, 168);
			LauncherExploreRawDirMPButton.Name = "LauncherExploreRawDirMPButton";
			LauncherExploreRawDirMPButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreRawDirMPButton.TabIndex = 24;
			LauncherExploreRawDirMPButton.Text = "MP";
			LauncherExploreRawDirMPButton.UseVisualStyleBackColor = true;
			LauncherExploreRawDirMPButton.Click += new System.EventHandler(LauncherExploreRawDirMPButton_Click);
			// 
			// LauncherExploreRawDirWeaponsButton
			// 
			LauncherExploreRawDirWeaponsButton.Location = new System.Drawing.Point(6, 258);
			LauncherExploreRawDirWeaponsButton.Name = "LauncherExploreRawDirWeaponsButton";
			LauncherExploreRawDirWeaponsButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreRawDirWeaponsButton.TabIndex = 23;
			LauncherExploreRawDirWeaponsButton.Text = "Weapons";
			LauncherExploreRawDirWeaponsButton.UseVisualStyleBackColor = true;
			LauncherExploreRawDirWeaponsButton.Click += new System.EventHandler(LauncherExploreRawDirWeaponsButton_Click);
			// 
			// LauncherExploreRawDirVisionButton
			// 
			LauncherExploreRawDirVisionButton.Location = new System.Drawing.Point(6, 228);
			LauncherExploreRawDirVisionButton.Name = "LauncherExploreRawDirVisionButton";
			LauncherExploreRawDirVisionButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreRawDirVisionButton.TabIndex = 22;
			LauncherExploreRawDirVisionButton.Text = "Vision";
			LauncherExploreRawDirVisionButton.UseVisualStyleBackColor = true;
			LauncherExploreRawDirVisionButton.Click += new System.EventHandler(LauncherExploreRawDirVisionButton_Click);
			// 
			// LauncherExploreRawDirLocsButton
			// 
			LauncherExploreRawDirLocsButton.Location = new System.Drawing.Point(6, 79);
			LauncherExploreRawDirLocsButton.Name = "LauncherExploreRawDirLocsButton";
			LauncherExploreRawDirLocsButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreRawDirLocsButton.TabIndex = 21;
			LauncherExploreRawDirLocsButton.Text = "English Strings";
			LauncherExploreRawDirLocsButton.UseVisualStyleBackColor = true;
			LauncherExploreRawDirLocsButton.Click += new System.EventHandler(LauncherExploreRawDirLocsButton_Click);
			// 
			// LauncherExploreRawDirAnimTreesButton
			// 
			LauncherExploreRawDirAnimTreesButton.Location = new System.Drawing.Point(6, 19);
			LauncherExploreRawDirAnimTreesButton.Name = "LauncherExploreRawDirAnimTreesButton";
			LauncherExploreRawDirAnimTreesButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreRawDirAnimTreesButton.TabIndex = 20;
			LauncherExploreRawDirAnimTreesButton.Text = "AnimTrees";
			LauncherExploreRawDirAnimTreesButton.UseVisualStyleBackColor = true;
			LauncherExploreRawDirAnimTreesButton.Click += new System.EventHandler(LauncherExploreRawDirAnimTreesButton_Click);
			// 
			// LauncherExploreRawDirSoundAliasesButton
			// 
			LauncherExploreRawDirSoundAliasesButton.Location = new System.Drawing.Point(6, 198);
			LauncherExploreRawDirSoundAliasesButton.Name = "LauncherExploreRawDirSoundAliasesButton";
			LauncherExploreRawDirSoundAliasesButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreRawDirSoundAliasesButton.TabIndex = 19;
			LauncherExploreRawDirSoundAliasesButton.Text = "Sound Aliases";
			LauncherExploreRawDirSoundAliasesButton.UseVisualStyleBackColor = true;
			LauncherExploreRawDirSoundAliasesButton.Click += new System.EventHandler(LauncherExploreRawDirSoundAliasesButton_Click);
			// 
			// LauncherExploreRawDirCSCButton
			// 
			LauncherExploreRawDirCSCButton.Location = new System.Drawing.Point(6, 49);
			LauncherExploreRawDirCSCButton.Name = "LauncherExploreRawDirCSCButton";
			LauncherExploreRawDirCSCButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreRawDirCSCButton.TabIndex = 18;
			LauncherExploreRawDirCSCButton.Text = "Clientscripts";
			LauncherExploreRawDirCSCButton.UseVisualStyleBackColor = true;
			LauncherExploreRawDirCSCButton.Click += new System.EventHandler(LauncherExploreRawDirCSCButton_Click);
			// 
			// LauncherExploreRawDirGSCButton
			// 
			LauncherExploreRawDirGSCButton.Location = new System.Drawing.Point(6, 139);
			LauncherExploreRawDirGSCButton.Name = "LauncherExploreRawDirGSCButton";
			LauncherExploreRawDirGSCButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreRawDirGSCButton.TabIndex = 17;
			LauncherExploreRawDirGSCButton.Text = "Maps";
			LauncherExploreRawDirGSCButton.UseVisualStyleBackColor = true;
			LauncherExploreRawDirGSCButton.Click += new System.EventHandler(LauncherExploreRawDirGSCButton_Click);
			// 
			// LauncherExploreDevDirGroupBox
			// 
			LauncherExploreDevDirGroupBox.Controls.Add(LauncherExploreDevDirRawButton);
			LauncherExploreDevDirGroupBox.Controls.Add(LauncherExploreDevDirModelExportButton);
			LauncherExploreDevDirGroupBox.Controls.Add(LauncherExploreDevDirTextureAssetsButton);
			LauncherExploreDevDirGroupBox.Controls.Add(LauncherExploreDevDirSrcDataButton);
			LauncherExploreDevDirGroupBox.Controls.Add(LauncherExploreDevDirMapSrcButton);
			LauncherExploreDevDirGroupBox.Controls.Add(LauncherExploreDevDirBinButton);
			LauncherExploreDevDirGroupBox.Controls.Add(LauncherExploreDevDirZoneSourceButton);
			LauncherExploreDevDirGroupBox.Location = new System.Drawing.Point(167, 19);
			LauncherExploreDevDirGroupBox.Name = "LauncherExploreDevDirGroupBox";
			LauncherExploreDevDirGroupBox.Size = new System.Drawing.Size(142, 226);
			LauncherExploreDevDirGroupBox.TabIndex = 18;
			LauncherExploreDevDirGroupBox.TabStop = false;
			LauncherExploreDevDirGroupBox.Text = "Development Directories";
			// 
			// LauncherExploreDevDirRawButton
			// 
			LauncherExploreDevDirRawButton.Location = new System.Drawing.Point(6, 108);
			LauncherExploreDevDirRawButton.Name = "LauncherExploreDevDirRawButton";
			LauncherExploreDevDirRawButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreDevDirRawButton.TabIndex = 19;
			LauncherExploreDevDirRawButton.Text = "Raw";
			LauncherExploreDevDirRawButton.UseVisualStyleBackColor = true;
			LauncherExploreDevDirRawButton.Click += new System.EventHandler(LauncherExploreDevDirRawButton_Click);
			// 
			// LauncherExploreDevDirModelExportButton
			// 
			LauncherExploreDevDirModelExportButton.Location = new System.Drawing.Point(6, 78);
			LauncherExploreDevDirModelExportButton.Name = "LauncherExploreDevDirModelExportButton";
			LauncherExploreDevDirModelExportButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreDevDirModelExportButton.TabIndex = 18;
			LauncherExploreDevDirModelExportButton.Text = "Model Export";
			LauncherExploreDevDirModelExportButton.UseVisualStyleBackColor = true;
			LauncherExploreDevDirModelExportButton.Click += new System.EventHandler(LauncherExploreDevDirModelExportButton_Click);
			// 
			// LauncherExploreDevDirTextureAssetsButton
			// 
			LauncherExploreDevDirTextureAssetsButton.Location = new System.Drawing.Point(6, 168);
			LauncherExploreDevDirTextureAssetsButton.Name = "LauncherExploreDevDirTextureAssetsButton";
			LauncherExploreDevDirTextureAssetsButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreDevDirTextureAssetsButton.TabIndex = 17;
			LauncherExploreDevDirTextureAssetsButton.Text = "Texture Assets";
			LauncherExploreDevDirTextureAssetsButton.UseVisualStyleBackColor = true;
			LauncherExploreDevDirTextureAssetsButton.Click += new System.EventHandler(LauncherExploreDevDirTextureAssetsButton_Click);
			// 
			// LauncherExploreDevDirSrcDataButton
			// 
			LauncherExploreDevDirSrcDataButton.Location = new System.Drawing.Point(6, 138);
			LauncherExploreDevDirSrcDataButton.Name = "LauncherExploreDevDirSrcDataButton";
			LauncherExploreDevDirSrcDataButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreDevDirSrcDataButton.TabIndex = 16;
			LauncherExploreDevDirSrcDataButton.Text = "Source Data";
			LauncherExploreDevDirSrcDataButton.UseVisualStyleBackColor = true;
			LauncherExploreDevDirSrcDataButton.Click += new System.EventHandler(LauncherExploreDevDirSrcDataButton_Click);
			// 
			// LauncherExploreDevDirMapSrcButton
			// 
			LauncherExploreDevDirMapSrcButton.Location = new System.Drawing.Point(6, 48);
			LauncherExploreDevDirMapSrcButton.Name = "LauncherExploreDevDirMapSrcButton";
			LauncherExploreDevDirMapSrcButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreDevDirMapSrcButton.TabIndex = 15;
			LauncherExploreDevDirMapSrcButton.Text = "Map Source";
			LauncherExploreDevDirMapSrcButton.UseVisualStyleBackColor = true;
			LauncherExploreDevDirMapSrcButton.Click += new System.EventHandler(LauncherExploreDevDirMapSrcButton_Click);
			// 
			// LauncherExploreDevDirBinButton
			// 
			LauncherExploreDevDirBinButton.Location = new System.Drawing.Point(6, 19);
			LauncherExploreDevDirBinButton.Name = "LauncherExploreDevDirBinButton";
			LauncherExploreDevDirBinButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreDevDirBinButton.TabIndex = 14;
			LauncherExploreDevDirBinButton.Text = "Bin";
			LauncherExploreDevDirBinButton.UseVisualStyleBackColor = true;
			LauncherExploreDevDirBinButton.Click += new System.EventHandler(LauncherExploreDevDirBinButton_Click);
			// 
			// LauncherExploreDevDirZoneSourceButton
			// 
			LauncherExploreDevDirZoneSourceButton.Location = new System.Drawing.Point(6, 198);
			LauncherExploreDevDirZoneSourceButton.Name = "LauncherExploreDevDirZoneSourceButton";
			LauncherExploreDevDirZoneSourceButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreDevDirZoneSourceButton.TabIndex = 13;
			LauncherExploreDevDirZoneSourceButton.Text = "Zone Source";
			LauncherExploreDevDirZoneSourceButton.UseVisualStyleBackColor = true;
			LauncherExploreDevDirZoneSourceButton.Click += new System.EventHandler(LauncherExploreDevDirZoneSourceButton_Click);
			// 
			// LauncherExploreBlopsDirGroupBox
			// 
			LauncherExploreBlopsDirGroupBox.Controls.Add(LauncherExploreBlopsDirConfigsButton);
			LauncherExploreBlopsDirGroupBox.Controls.Add(LauncherExploreBlopsDirModsButton);
			LauncherExploreBlopsDirGroupBox.Controls.Add(LauncherExploreBlopsDirGameButton);
			LauncherExploreBlopsDirGroupBox.Location = new System.Drawing.Point(19, 19);
			LauncherExploreBlopsDirGroupBox.Name = "LauncherExploreBlopsDirGroupBox";
			LauncherExploreBlopsDirGroupBox.Size = new System.Drawing.Size(142, 110);
			LauncherExploreBlopsDirGroupBox.TabIndex = 17;
			LauncherExploreBlopsDirGroupBox.TabStop = false;
			LauncherExploreBlopsDirGroupBox.Text = "Call of Duty: Black Ops";
			// 
			// LauncherExploreBlopsDirConfigsButton
			// 
			LauncherExploreBlopsDirConfigsButton.Location = new System.Drawing.Point(6, 49);
			LauncherExploreBlopsDirConfigsButton.Name = "LauncherExploreBlopsDirConfigsButton";
			LauncherExploreBlopsDirConfigsButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreBlopsDirConfigsButton.TabIndex = 10;
			LauncherExploreBlopsDirConfigsButton.Text = "Player Configs";
			LauncherExploreBlopsDirConfigsButton.UseVisualStyleBackColor = true;
			LauncherExploreBlopsDirConfigsButton.Click += new System.EventHandler(LauncherExploreBlopsDirConfigsButton_Click);
			// 
			// LauncherExploreBlopsDirModsButton
			// 
			LauncherExploreBlopsDirModsButton.Location = new System.Drawing.Point(6, 79);
			LauncherExploreBlopsDirModsButton.Name = "LauncherExploreBlopsDirModsButton";
			LauncherExploreBlopsDirModsButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreBlopsDirModsButton.TabIndex = 9;
			LauncherExploreBlopsDirModsButton.Text = "Mods Folder";
			LauncherExploreBlopsDirModsButton.UseVisualStyleBackColor = true;
			LauncherExploreBlopsDirModsButton.Click += new System.EventHandler(LauncherExploreBlopsDirModsButton_Click);
			// 
			// LauncherExploreBlopsDirGameButton
			// 
			LauncherExploreBlopsDirGameButton.Location = new System.Drawing.Point(6, 19);
			LauncherExploreBlopsDirGameButton.Name = "LauncherExploreBlopsDirGameButton";
			LauncherExploreBlopsDirGameButton.Size = new System.Drawing.Size(128, 24);
			LauncherExploreBlopsDirGameButton.TabIndex = 8;
			LauncherExploreBlopsDirGameButton.Text = "Game Directory";
			LauncherExploreBlopsDirGameButton.UseVisualStyleBackColor = true;
			LauncherExploreBlopsDirGameButton.Click += new System.EventHandler(LauncherExploreBlopsDirGameButton_Click);
			// 
			// LauncherApplicationsGroupBox
			// 
			LauncherApplicationsGroupBox.Controls.Add(LauncherIconRadiant);
			LauncherApplicationsGroupBox.Controls.Add(LauncherIconEffectsEditor);
			LauncherApplicationsGroupBox.Controls.Add(LauncherIconConverter);
			LauncherApplicationsGroupBox.Controls.Add(LauncherIconAssetViewer);
			LauncherApplicationsGroupBox.Controls.Add(LauncherIconAssetManager);
			LauncherApplicationsGroupBox.Controls.Add(LauncherButtonAssetViewer);
			LauncherApplicationsGroupBox.Controls.Add(LauncherButtonRunConverter);
			LauncherApplicationsGroupBox.Controls.Add(LauncherButtonAssetManager);
			LauncherApplicationsGroupBox.Controls.Add(LauncherButtonEffectsEd);
			LauncherApplicationsGroupBox.Controls.Add(LauncherButtonRadiant);
			LauncherApplicationsGroupBox.Location = new System.Drawing.Point(5, 186);
			LauncherApplicationsGroupBox.Name = "LauncherApplicationsGroupBox";
			LauncherApplicationsGroupBox.Size = new System.Drawing.Size(139, 165);
			LauncherApplicationsGroupBox.TabIndex = 8;
			LauncherApplicationsGroupBox.TabStop = false;
			LauncherApplicationsGroupBox.Text = "Tools";
			// 
			// LauncherIconRadiant
			// 
			LauncherIconRadiant.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconRadiant.BackgroundImage")));
			LauncherIconRadiant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			LauncherIconRadiant.Enabled = false;
			LauncherIconRadiant.Location = new System.Drawing.Point(13, 139);
			LauncherIconRadiant.Name = "LauncherIconRadiant";
			LauncherIconRadiant.Size = new System.Drawing.Size(16, 16);
			LauncherIconRadiant.TabIndex = 10;
			LauncherIconRadiant.TabStop = false;
			// 
			// LauncherIconEffectsEditor
			// 
			LauncherIconEffectsEditor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconEffectsEditor.BackgroundImage")));
			LauncherIconEffectsEditor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			LauncherIconEffectsEditor.Enabled = false;
			LauncherIconEffectsEditor.Location = new System.Drawing.Point(12, 18);
			LauncherIconEffectsEditor.Name = "LauncherIconEffectsEditor";
			LauncherIconEffectsEditor.Size = new System.Drawing.Size(16, 16);
			LauncherIconEffectsEditor.TabIndex = 9;
			LauncherIconEffectsEditor.TabStop = false;
			// 
			// LauncherIconConverter
			// 
			LauncherIconConverter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconConverter.BackgroundImage")));
			LauncherIconConverter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			LauncherIconConverter.Enabled = false;
			LauncherIconConverter.Location = new System.Drawing.Point(12, 109);
			LauncherIconConverter.Name = "LauncherIconConverter";
			LauncherIconConverter.Size = new System.Drawing.Size(16, 16);
			LauncherIconConverter.TabIndex = 8;
			LauncherIconConverter.TabStop = false;
			// 
			// LauncherIconAssetViewer
			// 
			LauncherIconAssetViewer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherIconAssetViewer.BackgroundImage")));
			LauncherIconAssetViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			LauncherIconAssetViewer.Enabled = false;
			LauncherIconAssetViewer.Location = new System.Drawing.Point(12, 78);
			LauncherIconAssetViewer.Name = "LauncherIconAssetViewer";
			LauncherIconAssetViewer.Size = new System.Drawing.Size(16, 16);
			LauncherIconAssetViewer.TabIndex = 7;
			LauncherIconAssetViewer.TabStop = false;
			// 
			// LauncherIconAssetManager
			// 
			LauncherIconAssetManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			LauncherIconAssetManager.Enabled = false;
			LauncherIconAssetManager.Image = ((System.Drawing.Image)(resources.GetObject("LauncherIconAssetManager.Image")));
			LauncherIconAssetManager.Location = new System.Drawing.Point(12, 48);
			LauncherIconAssetManager.Name = "LauncherIconAssetManager";
			LauncherIconAssetManager.Size = new System.Drawing.Size(16, 16);
			LauncherIconAssetManager.TabIndex = 6;
			LauncherIconAssetManager.TabStop = false;
			// 
			// LauncherButtonAssetViewer
			// 
			LauncherButtonAssetViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherButtonAssetViewer.Location = new System.Drawing.Point(8, 74);
			LauncherButtonAssetViewer.Name = "LauncherButtonAssetViewer";
			LauncherButtonAssetViewer.Size = new System.Drawing.Size(128, 24);
			LauncherButtonAssetViewer.TabIndex = 5;
			LauncherButtonAssetViewer.Text = "     Asset Viewer";
			LauncherButtonAssetViewer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			LauncherAssetViewerToolTip.SetToolTip(LauncherButtonAssetViewer, "View converted models");
			LauncherButtonAssetViewer.UseVisualStyleBackColor = true;
			LauncherButtonAssetViewer.Click += new System.EventHandler(LauncherButtonAssetViewer_Click);
			// 
			// LauncherButtonRunConverter
			// 
			LauncherButtonRunConverter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherButtonRunConverter.Location = new System.Drawing.Point(8, 105);
			LauncherButtonRunConverter.Name = "LauncherButtonRunConverter";
			LauncherButtonRunConverter.Size = new System.Drawing.Size(128, 24);
			LauncherButtonRunConverter.TabIndex = 3;
			LauncherButtonRunConverter.Text = "     Converter";
			LauncherButtonRunConverter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			LauncherConverterToolTip.SetToolTip(LauncherButtonRunConverter, "Convert .GDTs to game data");
			LauncherButtonRunConverter.UseVisualStyleBackColor = true;
			LauncherButtonRunConverter.Click += new System.EventHandler(LauncherButtonRunConverter_Click);
			// 
			// LauncherButtonAssetManager
			// 
			LauncherButtonAssetManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherButtonAssetManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			LauncherButtonAssetManager.Location = new System.Drawing.Point(8, 44);
			LauncherButtonAssetManager.Name = "LauncherButtonAssetManager";
			LauncherButtonAssetManager.Size = new System.Drawing.Size(128, 24);
			LauncherButtonAssetManager.TabIndex = 2;
			LauncherButtonAssetManager.Text = "     Asset Manager";
			LauncherButtonAssetManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			LauncherAssetManagerToolTip.SetToolTip(LauncherButtonAssetManager, "Manage .GDT files");
			LauncherButtonAssetManager.UseVisualStyleBackColor = true;
			LauncherButtonAssetManager.Click += new System.EventHandler(LauncherButtonAssetManager_Click);
			// 
			// LauncherButtonEffectsEd
			// 
			LauncherButtonEffectsEd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherButtonEffectsEd.Location = new System.Drawing.Point(7, 14);
			LauncherButtonEffectsEd.Name = "LauncherButtonEffectsEd";
			LauncherButtonEffectsEd.Size = new System.Drawing.Size(128, 24);
			LauncherButtonEffectsEd.TabIndex = 1;
			LauncherButtonEffectsEd.Text = "     Effects Editor";
			LauncherButtonEffectsEd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			LauncherEffectsEdToolTip.SetToolTip(LauncherButtonEffectsEd, "Effects Editor");
			LauncherButtonEffectsEd.UseVisualStyleBackColor = true;
			LauncherButtonEffectsEd.Click += new System.EventHandler(LauncherButtonEffectsEd_Click);
			// 
			// LauncherButtonRadiant
			// 
			LauncherButtonRadiant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherButtonRadiant.Location = new System.Drawing.Point(8, 135);
			LauncherButtonRadiant.Name = "LauncherButtonRadiant";
			LauncherButtonRadiant.Size = new System.Drawing.Size(128, 24);
			LauncherButtonRadiant.TabIndex = 0;
			LauncherButtonRadiant.Text = "     Radiant";
			LauncherButtonRadiant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			LauncherRadiantToolTip.SetToolTip(LauncherButtonRadiant, "Open Radiant, the level editor");
			LauncherButtonRadiant.UseVisualStyleBackColor = true;
			LauncherButtonRadiant.Click += new System.EventHandler(LauncherButtonRadiant_Click);
			// 
			// LauncherWarningsCounter
			// 
			LauncherWarningsCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherWarningsCounter.Location = new System.Drawing.Point(550, 249);
			LauncherWarningsCounter.Name = "LauncherWarningsCounter";
			LauncherWarningsCounter.Size = new System.Drawing.Size(31, 13);
			LauncherWarningsCounter.TabIndex = 25;
			LauncherWarningsCounter.Text = "0";
			LauncherWarningsCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LauncherWarningsNumericUpDown
			// 
			LauncherWarningsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherWarningsNumericUpDown.Location = new System.Drawing.Point(655, 246);
			LauncherWarningsNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			LauncherWarningsNumericUpDown.Name = "LauncherWarningsNumericUpDown";
			LauncherWarningsNumericUpDown.ReadOnly = true;
			LauncherWarningsNumericUpDown.Size = new System.Drawing.Size(18, 20);
			LauncherWarningsNumericUpDown.TabIndex = 24;
			LauncherWarningsNumericUpDown.Visible = false;
			LauncherWarningsNumericUpDown.ValueChanged += new System.EventHandler(LauncherWarningsNumericUpDown_ValueChanged);
			// 
			// LauncherWarningsPictureBox
			// 
			LauncherWarningsPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherWarningsPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherWarningsPictureBox.BackgroundImage")));
			LauncherWarningsPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			LauncherWarningsPictureBox.Location = new System.Drawing.Point(635, 248);
			LauncherWarningsPictureBox.Name = "LauncherWarningsPictureBox";
			LauncherWarningsPictureBox.Size = new System.Drawing.Size(16, 16);
			LauncherWarningsPictureBox.TabIndex = 23;
			LauncherWarningsPictureBox.TabStop = false;
			// 
			// LauncherWarningsLabel
			// 
			LauncherWarningsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherWarningsLabel.AutoSize = true;
			LauncherWarningsLabel.Location = new System.Drawing.Point(580, 249);
			LauncherWarningsLabel.Name = "LauncherWarningsLabel";
			LauncherWarningsLabel.Size = new System.Drawing.Size(52, 13);
			LauncherWarningsLabel.TabIndex = 22;
			LauncherWarningsLabel.Text = "Warnings";
			LauncherWarningsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LauncherErrorsCounter
			// 
			LauncherErrorsCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherErrorsCounter.Location = new System.Drawing.Point(679, 249);
			LauncherErrorsCounter.Name = "LauncherErrorsCounter";
			LauncherErrorsCounter.Size = new System.Drawing.Size(35, 13);
			LauncherErrorsCounter.TabIndex = 21;
			LauncherErrorsCounter.Text = "0";
			LauncherErrorsCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LauncherErrorsNumericUpDown
			// 
			LauncherErrorsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherErrorsNumericUpDown.Location = new System.Drawing.Point(770, 246);
			LauncherErrorsNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			LauncherErrorsNumericUpDown.Name = "LauncherErrorsNumericUpDown";
			LauncherErrorsNumericUpDown.ReadOnly = true;
			LauncherErrorsNumericUpDown.Size = new System.Drawing.Size(18, 20);
			LauncherErrorsNumericUpDown.TabIndex = 20;
			LauncherErrorsNumericUpDown.Visible = false;
			LauncherErrorsNumericUpDown.ValueChanged += new System.EventHandler(LauncherErrorsNumericUpDown_ValueChanged);
			// 
			// LauncherErrorsPictureBox
			// 
			LauncherErrorsPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherErrorsPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LauncherErrorsPictureBox.BackgroundImage")));
			LauncherErrorsPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			LauncherErrorsPictureBox.Location = new System.Drawing.Point(750, 248);
			LauncherErrorsPictureBox.Name = "LauncherErrorsPictureBox";
			LauncherErrorsPictureBox.Size = new System.Drawing.Size(16, 16);
			LauncherErrorsPictureBox.TabIndex = 19;
			LauncherErrorsPictureBox.TabStop = false;
			// 
			// LauncherErrorsLabel
			// 
			LauncherErrorsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherErrorsLabel.AutoSize = true;
			LauncherErrorsLabel.Location = new System.Drawing.Point(713, 249);
			LauncherErrorsLabel.Name = "LauncherErrorsLabel";
			LauncherErrorsLabel.Size = new System.Drawing.Size(34, 13);
			LauncherErrorsLabel.TabIndex = 18;
			LauncherErrorsLabel.Text = "Errors";
			LauncherErrorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// LauncherScrollBottomConsoleButton
			// 
			LauncherScrollBottomConsoleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherScrollBottomConsoleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			LauncherScrollBottomConsoleButton.Image = ((System.Drawing.Image)(resources.GetObject("LauncherScrollBottomConsoleButton.Image")));
			LauncherScrollBottomConsoleButton.Location = new System.Drawing.Point(924, 244);
			LauncherScrollBottomConsoleButton.Name = "LauncherScrollBottomConsoleButton";
			LauncherScrollBottomConsoleButton.Size = new System.Drawing.Size(27, 23);
			LauncherScrollBottomConsoleButton.TabIndex = 17;
			LauncherScrollBottomConsoleToolTip.SetToolTip(LauncherScrollBottomConsoleButton, "Scroll to end");
			LauncherScrollBottomConsoleButton.UseVisualStyleBackColor = true;
			LauncherScrollBottomConsoleButton.Click += new System.EventHandler(LauncherScrollBottomConsoleButton_Click);
			// 
			// LauncherSaveConsoleButton
			// 
			LauncherSaveConsoleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherSaveConsoleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			LauncherSaveConsoleButton.Image = ((System.Drawing.Image)(resources.GetObject("LauncherSaveConsoleButton.Image")));
			LauncherSaveConsoleButton.Location = new System.Drawing.Point(794, 244);
			LauncherSaveConsoleButton.Name = "LauncherSaveConsoleButton";
			LauncherSaveConsoleButton.Size = new System.Drawing.Size(27, 23);
			LauncherSaveConsoleButton.TabIndex = 16;
			SaveConsoleToolTip.SetToolTip(LauncherSaveConsoleButton, "Save console to file");
			LauncherSaveConsoleButton.UseVisualStyleBackColor = true;
			LauncherSaveConsoleButton.Click += new System.EventHandler(LauncherSaveConsoleButton_Click);
			// 
			// LauncherProcessTimeElapsedTextBox
			// 
			LauncherProcessTimeElapsedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherProcessTimeElapsedTextBox.Location = new System.Drawing.Point(489, 246);
			LauncherProcessTimeElapsedTextBox.Name = "LauncherProcessTimeElapsedTextBox";
			LauncherProcessTimeElapsedTextBox.ReadOnly = true;
			LauncherProcessTimeElapsedTextBox.Size = new System.Drawing.Size(55, 20);
			LauncherProcessTimeElapsedTextBox.TabIndex = 4;
			// 
			// LauncherClearConsoleButton
			// 
			LauncherClearConsoleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			LauncherClearConsoleButton.Location = new System.Drawing.Point(827, 244);
			LauncherClearConsoleButton.Name = "LauncherClearConsoleButton";
			LauncherClearConsoleButton.Size = new System.Drawing.Size(86, 23);
			LauncherClearConsoleButton.TabIndex = 13;
			LauncherClearConsoleButton.Text = "Clear Console";
			LauncherClearConsoleButton.UseVisualStyleBackColor = true;
			LauncherClearConsoleButton.Click += new System.EventHandler(LauncherClearConsoleButton_Click);
			// 
			// LauncherProcessGroupBox
			// 
			LauncherProcessGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			LauncherProcessGroupBox.Controls.Add(LauncherButtonCancel);
			LauncherProcessGroupBox.Controls.Add(LauncherProcessList);
			LauncherProcessGroupBox.Location = new System.Drawing.Point(3, 3);
			LauncherProcessGroupBox.Name = "LauncherProcessGroupBox";
			LauncherProcessGroupBox.Size = new System.Drawing.Size(140, 263);
			LauncherProcessGroupBox.TabIndex = 2;
			LauncherProcessGroupBox.TabStop = false;
			LauncherProcessGroupBox.Text = "Processes";
			// 
			// LauncherButtonCancel
			// 
			LauncherButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherButtonCancel.BackColor = System.Drawing.Color.LightCoral;
			LauncherButtonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			LauncherButtonCancel.ForeColor = System.Drawing.SystemColors.Info;
			LauncherButtonCancel.Location = new System.Drawing.Point(6, 192);
			LauncherButtonCancel.Name = "LauncherButtonCancel";
			LauncherButtonCancel.Size = new System.Drawing.Size(128, 65);
			LauncherButtonCancel.TabIndex = 4;
			LauncherButtonCancel.Text = "Cancel";
			LauncherButtonCancel.UseVisualStyleBackColor = false;
			LauncherButtonCancel.Click += new System.EventHandler(LauncherButtonCancel_Click);
			// 
			// LauncherProcessList
			// 
			LauncherProcessList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherProcessList.BackColor = System.Drawing.SystemColors.Info;
			LauncherProcessList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			LauncherProcessList.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			LauncherProcessList.ForeColor = System.Drawing.SystemColors.HotTrack;
			LauncherProcessList.FormattingEnabled = true;
			LauncherProcessList.IntegralHeight = false;
			LauncherProcessList.ItemHeight = 11;
			LauncherProcessList.Location = new System.Drawing.Point(6, 19);
			LauncherProcessList.Name = "LauncherProcessList";
			LauncherProcessList.Size = new System.Drawing.Size(128, 167);
			LauncherProcessList.TabIndex = 1;
			LauncherProcessList.SelectedIndexChanged += new System.EventHandler(LauncherProcessList_SelectedIndexChanged);
			// 
			// LauncherProcessTextBox
			// 
			LauncherProcessTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			LauncherProcessTextBox.Location = new System.Drawing.Point(149, 246);
			LauncherProcessTextBox.Name = "LauncherProcessTextBox";
			LauncherProcessTextBox.ReadOnly = true;
			LauncherProcessTextBox.Size = new System.Drawing.Size(334, 20);
			LauncherProcessTextBox.TabIndex = 11;
			// 
			// LauncherTimer
			// 
			LauncherTimer.Enabled = true;
			LauncherTimer.Interval = 1000;
			LauncherTimer.Tick += new System.EventHandler(LauncherTimer_Tick);
			// 
			// LauncherMapFilesSystemWatcher
			// 
			LauncherMapFilesSystemWatcher.EnableRaisingEvents = true;
			LauncherMapFilesSystemWatcher.Filter = "*.map";
			LauncherMapFilesSystemWatcher.NotifyFilter = System.IO.NotifyFilters.FileName;
			LauncherMapFilesSystemWatcher.SynchronizingObject = this;
			LauncherMapFilesSystemWatcher.Changed += new System.IO.FileSystemEventHandler(LauncherMapFilesSystemWatcher_Changed);
			LauncherMapFilesSystemWatcher.Created += new System.IO.FileSystemEventHandler(LauncherMapFilesSystemWatcher_Created);
			LauncherMapFilesSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(LauncherMapFilesSystemWatcher_Deleted);
			LauncherMapFilesSystemWatcher.Renamed += new System.IO.RenamedEventHandler(LauncherMapFilesSystemWatcher_Renamed);
			// 
			// LauncherModsDirectorySystemWatcher
			// 
			LauncherModsDirectorySystemWatcher.EnableRaisingEvents = true;
			LauncherModsDirectorySystemWatcher.NotifyFilter = System.IO.NotifyFilters.DirectoryName;
			LauncherModsDirectorySystemWatcher.SynchronizingObject = this;
			LauncherModsDirectorySystemWatcher.Changed += new System.IO.FileSystemEventHandler(LauncherModsDirectorySystemWatcher_Changed);
			LauncherModsDirectorySystemWatcher.Created += new System.IO.FileSystemEventHandler(LauncherModsDirectorySystemWatcher_Created);
			LauncherModsDirectorySystemWatcher.Deleted += new System.IO.FileSystemEventHandler(LauncherModsDirectorySystemWatcher_Deleted);
			LauncherModsDirectorySystemWatcher.Renamed += new System.IO.RenamedEventHandler(LauncherModsDirectorySystemWatcher_Renamed);
			// 
			// menuStrip1
			// 
			menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            LauncherfileToolStripMenuItem,
            LauncherdocsToolStripMenuItem,
            LaunchertoolsToolStripMenuItem,
            LauncherhelpToolStripMenuItem});
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new System.Drawing.Size(978, 24);
			menuStrip1.TabIndex = 9;
			menuStrip1.Text = "menuStrip1";
			// 
			// LauncherfileToolStripMenuItem
			// 
			LauncherfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            newModToolStripMenuItem,
            LaunchernewMapToolStripMenuItem,
            toolStripSeparator3,
            gameDirToolStripMenuItem,
            toolStripSeparator1,
            LauncherexitToolStripMenuItem});
			LauncherfileToolStripMenuItem.Name = "LauncherfileToolStripMenuItem";
			LauncherfileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			LauncherfileToolStripMenuItem.Text = "File";
			// 
			// newModToolStripMenuItem
			// 
			newModToolStripMenuItem.Name = "newModToolStripMenuItem";
			newModToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			newModToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			newModToolStripMenuItem.Text = "New mod...";
			newModToolStripMenuItem.Click += new System.EventHandler(newModToolStripMenuItem_Click);
			// 
			// LaunchernewMapToolStripMenuItem
			// 
			LaunchernewMapToolStripMenuItem.Name = "LaunchernewMapToolStripMenuItem";
			LaunchernewMapToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			LaunchernewMapToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			LaunchernewMapToolStripMenuItem.Text = "New map...";
			LaunchernewMapToolStripMenuItem.Visible = false;
			LaunchernewMapToolStripMenuItem.Click += new System.EventHandler(LaunchernewMapToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
			// 
			// gameDirToolStripMenuItem
			// 
			gameDirToolStripMenuItem.Name = "gameDirToolStripMenuItem";
			gameDirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			gameDirToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			gameDirToolStripMenuItem.Text = "View Game Dir";
			gameDirToolStripMenuItem.Click += new System.EventHandler(gameDirToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
			// 
			// LauncherexitToolStripMenuItem
			// 
			LauncherexitToolStripMenuItem.Name = "LauncherexitToolStripMenuItem";
			LauncherexitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			LauncherexitToolStripMenuItem.Text = "Exit";
			LauncherexitToolStripMenuItem.Click += new System.EventHandler(LauncherexitToolStripMenuItem_Click);
			// 
			// LauncherdocsToolStripMenuItem
			// 
			LauncherdocsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            mayaExporterToolStripMenuItem,
            exporterTutorialToolStripMenuItem});
			LauncherdocsToolStripMenuItem.Name = "LauncherdocsToolStripMenuItem";
			LauncherdocsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			LauncherdocsToolStripMenuItem.Text = "Docs";
			// 
			// mayaExporterToolStripMenuItem
			// 
			mayaExporterToolStripMenuItem.Name = "mayaExporterToolStripMenuItem";
			mayaExporterToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			mayaExporterToolStripMenuItem.Text = "Maya CoDTools";
			mayaExporterToolStripMenuItem.Click += new System.EventHandler(mayaExporterToolStripMenuItem_Click);
			// 
			// exporterTutorialToolStripMenuItem
			// 
			exporterTutorialToolStripMenuItem.Name = "exporterTutorialToolStripMenuItem";
			exporterTutorialToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			exporterTutorialToolStripMenuItem.Text = "Exporter Tutorial";
			exporterTutorialToolStripMenuItem.Click += new System.EventHandler(exporterTutorialToolStripMenuItem_Click);
			// 
			// LaunchertoolsToolStripMenuItem
			// 
			LaunchertoolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            mayaPluginSetupToolStripMenuItem});
			LaunchertoolsToolStripMenuItem.Name = "LaunchertoolsToolStripMenuItem";
			LaunchertoolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			LaunchertoolsToolStripMenuItem.Text = "Tools";
			// 
			// mayaPluginSetupToolStripMenuItem
			// 
			mayaPluginSetupToolStripMenuItem.Name = "mayaPluginSetupToolStripMenuItem";
			mayaPluginSetupToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			mayaPluginSetupToolStripMenuItem.Text = "Maya Plugin Setup";
			mayaPluginSetupToolStripMenuItem.Click += new System.EventHandler(mayaPluginSetupToolStripMenuItem_Click);
			// 
			// LauncherhelpToolStripMenuItem
			// 
			LauncherhelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            LauncherwikiToolStripMenuItem});
			LauncherhelpToolStripMenuItem.Name = "LauncherhelpToolStripMenuItem";
			LauncherhelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			LauncherhelpToolStripMenuItem.Text = "Help";
			// 
			// LauncherwikiToolStripMenuItem
			// 
			LauncherwikiToolStripMenuItem.Name = "LauncherwikiToolStripMenuItem";
			LauncherwikiToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			LauncherwikiToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			LauncherwikiToolStripMenuItem.Text = "Wiki";
			LauncherwikiToolStripMenuItem.Click += new System.EventHandler(LauncherwikiToolStripMenuItem_Click);
			// 
			// LauncherMapListContextMenuStrip
			// 
			LauncherMapListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            runToolStripMenuItem,
            editToolStripMenuItem,
            toolStripSeparator2,
            deleteToolStripMenuItem,
            renameToolStripMenuItem});
			LauncherMapListContextMenuStrip.Name = "LauncherMapListContextMenuStrip";
			LauncherMapListContextMenuStrip.Size = new System.Drawing.Size(118, 98);
			// 
			// runToolStripMenuItem
			// 
			runToolStripMenuItem.Name = "runToolStripMenuItem";
			runToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			runToolStripMenuItem.Text = "&Run";
			runToolStripMenuItem.Click += new System.EventHandler(RunToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			editToolStripMenuItem.Name = "editToolStripMenuItem";
			editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			editToolStripMenuItem.Text = "&Edit";
			editToolStripMenuItem.Click += new System.EventHandler(EditToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(114, 6);
			// 
			// deleteToolStripMenuItem
			// 
			deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			deleteToolStripMenuItem.Text = "&Delete";
			deleteToolStripMenuItem.Click += new System.EventHandler(DeleteToolStripMenuItem_Click);
			// 
			// renameToolStripMenuItem
			// 
			renameToolStripMenuItem.Enabled = false;
			renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			renameToolStripMenuItem.Text = "Re&name";
			// 
			// LauncherForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(978, 688);
			Controls.Add(menuStrip1);
			Controls.Add(LauncherSplitter);
			Icon = ((System.Drawing.Icon)(resources.GetObject("$Icon")));
			Name = "LauncherForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Launcher";
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(LauncherForm_FormClosing);
			Load += new System.EventHandler(LauncherForm_Load);
			LauncherSplitter.Panel1.ResumeLayout(false);
			LauncherSplitter.Panel1.PerformLayout();
			LauncherSplitter.Panel2.ResumeLayout(false);
			LauncherSplitter.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(LauncherSplitter)).EndInit();
			LauncherSplitter.ResumeLayout(false);
			panel1.ResumeLayout(false);
			LauncherRunGameCustomCommandLineGroupBox.ResumeLayout(false);
			LauncherRunGameCustomCommandLineGroupBox.PerformLayout();
			LauncherRunGameGroupBox.ResumeLayout(false);
			LauncherRunGameGroupBox.PerformLayout();
			LauncherRunGameCustomCommandLineMPGroupBox.ResumeLayout(false);
			LauncherRunGameCustomCommandLineMPGroupBox.PerformLayout();
			LauncherRunGameModGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(LauncherIconBlops)).EndInit();
			LauncherGameGroupBox.ResumeLayout(false);
			LauncherGameGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(LauncherIconMP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(LauncherIconSP)).EndInit();
			LauncherTab.ResumeLayout(false);
			LauncherTabModBuilder.ResumeLayout(false);
			LauncherIwdFileGroupBox.ResumeLayout(false);
			LauncherModGroupBox.ResumeLayout(false);
			LauncherModFolderGroupBox.ResumeLayout(false);
			LauncherModBuildGroupBox.ResumeLayout(false);
			LauncherModBuildGroupBox.PerformLayout();
			LauncherModZoneSourceGroupBox.ResumeLayout(false);
			LauncherTabCompileLevel.ResumeLayout(false);
			LauncherTabCompileLevel.PerformLayout();
			LauncherCompileLevelOptionsGroupBox.ResumeLayout(false);
			LauncherCompileLevelOptionsGroupBox.PerformLayout();
			LauncherGridFileGroupBox.ResumeLayout(false);
			LauncherGridFileGroupBox.PerformLayout();
			LauncherTabExplore.ResumeLayout(false);
			LauncherExploreGroupBox.ResumeLayout(false);
			LauncherExploreRawMapsDirGroupBox.ResumeLayout(false);
			LauncherExploreRawDirGroupBox.ResumeLayout(false);
			LauncherExploreDevDirGroupBox.ResumeLayout(false);
			LauncherExploreBlopsDirGroupBox.ResumeLayout(false);
			LauncherApplicationsGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(LauncherIconRadiant)).EndInit();
			((System.ComponentModel.ISupportInitialize)(LauncherIconEffectsEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(LauncherIconConverter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(LauncherIconAssetViewer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(LauncherIconAssetManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(LauncherWarningsNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(LauncherWarningsPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(LauncherErrorsNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(LauncherErrorsPictureBox)).EndInit();
			LauncherProcessGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(LauncherMapFilesSystemWatcher)).EndInit();
			((System.ComponentModel.ISupportInitialize)(LauncherModsDirectorySystemWatcher)).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			LauncherMapListContextMenuStrip.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		private bool IsMP()
		{
			return Launcher.IsMP(mapName);
		}

		private void LauncherButtonAssetManager_Click(object sender, EventArgs e)
		{
			LaunchProcess(
				"asset_manager",
				"",
				null,
				false,
				null);
		}

		private void LauncherButtonAssetViewer_Click(object sender, EventArgs e)
		{
			LaunchProcess(
				"AssetViewer",
				"",
				null,
				false,
				null);
		}

		private void LauncherButtonCancel_Click(object sender, EventArgs e)
		{
			int selectedIndex = LauncherProcessList.SelectedIndex;
			if (selectedIndex < 0) return;
			((Process)((DictionaryEntry)processList[selectedIndex]).Key).Kill();
		}

		private void LauncherButtonCreateMap_Click(object sender, EventArgs e)
		{
			if (new CreateMap().ShowDialog() != DialogResult.OK) return;
			UpdateMapList();
			EnableMapList();
		}

		private void LauncherButtonEffectsEd_Click(object sender, EventArgs e)
		{
			LaunchProcess(
				"EffectsEd3",
				"",
				null,
				false,
				null);
		}

		private void LauncherButtonMP_Click(object sender, EventArgs e)
		{
			string arguments = "";
			if (LauncherGameDeveloperBox.Checked) arguments += "+set developer 1 +set developer_script 1 ";
			if (LauncherGameLogfileBox.Checked) arguments += "+set logfile 1 ";

			LaunchProcess(
				Launcher.GetGameApplication(true),
				arguments,
				null,
				false,
				null);
		}

		private void LauncherButtonRadiant_Click(object sender, EventArgs e)
		{
			LaunchProcess("CoDBORadiant",
				(mapName != null)
				? Path.Combine(Launcher.GetMapSourceDirectory(), mapName + ".map")
				: "",
				null,
				false,
				null);
		}

		private void LauncherButtonRunConverter_Click(object sender, EventArgs eventArgs)
		{
			LaunchProcess(
				"converter",
				"-nopause -n -nospam",
				null,
				true,
				null);
		}

		private void LauncherButtonSP_Click(object sender, EventArgs e)
		{
			string arguments = "";
			if (LauncherGameDeveloperBox.Checked) arguments += "+set developer 1";
			if (LauncherGameLogfileBox.Checked) arguments += "+set logfile 1 ";

			LaunchProcess(
				Launcher.GetGameApplication(false),
				arguments,
				null,
				false,
				null);
		}

		private void LauncherClearConsoleButton_Click(object sender, EventArgs e)
		{
			LauncherErrorsCounter.Text = "0";
			//TODO LauncherErrorsPictureBox.BackgroundImage = Properties.Resources.error_grey;
			LauncherWarningsCounter.Text = "0";
			//TODO LauncherWarningsPictureBox.BackgroundImage = Properties.Resources.warning_grey;
			LauncherConsole.Clear();
		}

		private void LauncherCompileBSPButton_Click(object sender, EventArgs e)
		{
			new LightOptions().ShowDialog();
		}

		private void LauncherCompileLevelButton_Click(object sender, EventArgs e)
		{
			CompileLevel();
		}

		private void LauncherCompileLightsButton_Click(object sender, EventArgs e)
		{
			new BspOptions().ShowDialog();
		}

		private void LauncherCompileLightsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Launcher.mapSettings.SetDecimal("lightoptions_quality", 20M);
		}

		private void LauncherCreateMap_Click(object sender, EventArgs e)
		{
			if (new CreateMap().ShowDialog() != DialogResult.OK) return;
			UpdateMapList();
			EnableMapList();
		}

		private void LauncherDeleteMap_Click(object sender, EventArgs e)
		{
			string[] mapFiles1 = Launcher.GetMapFiles(mapName);
			if (DialogResult.Yes != MessageBox.Show("The following files would be deleted:\n\n" + Launcher.StringArrayToString(mapFiles1), "Are you sure you want to delete these files?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
				return;
			foreach (string fileName in mapFiles1)
				Launcher.DeleteFile(fileName);
			string[] mapFiles2 = Launcher.GetMapFiles(mapName);
			if (mapFiles2.Length != 0)
			{
				int num = (int) MessageBox.Show("Could not delete the following files:\n\n" + Launcher.StringArrayToString(mapFiles2), "Error deleting files", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			UpdateMapList();
			EnableMapList();
			LauncherModSpecificMapComboBox.SelectedIndex = -1;
		}

		private void LauncherEditZoneSourceButton_Click(object sender, EventArgs e)
		{
			new ZoneSource(LauncherModComboBox.SelectedItem.ToString()).ShowDialog();
		}

		private void LauncherErrorsNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (Convert.ToInt32(LauncherErrorsCounter.Text) <= 0) return;
			LauncherConsole.SelectionStart = (LauncherErrorsNumericUpDown.Value != 0M)
				? FindLauncherConsoleText("ERROR:", LauncherConsole.SelectionStart + LauncherConsole.SelectionLength, LauncherConsole.Text.Length)
				: FindLauncherConsoleText("ERROR:", 0, LauncherConsole.SelectionStart);
		}

		private void LauncherexitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void LauncherExploreBlopsDirConfigsButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "players\\");
		}

		private void LauncherExploreBlopsDirGameButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory());
		}

		private void LauncherExploreBlopsDirModsButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "mods\\");
		}

		private void LauncherExploreDevDirBinButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "bin\\");
		}

		private void LauncherExploreDevDirMapSrcButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "map_source\\");
		}

		private void LauncherExploreDevDirModelExportButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "model_export\\");
		}

		private void LauncherExploreDevDirRawButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\");
		}

		private void LauncherExploreDevDirSrcDataButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "source_data\\");
		}

		private void LauncherExploreDevDirTextureAssetsButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "texture_assets\\");
		}

		private void LauncherExploreDevDirZoneSourceButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "zone_source\\");
		}

		private void LauncherExploreRawDirAnimTreesButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\animtrees\\");
		}

		private void LauncherExploreRawDirCSCButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\clientscripts\\");
		}

		private void LauncherExploreRawDirFXButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\fx\\");
		}

		private void LauncherExploreRawDirGSCButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\maps\\");
		}

		private void LauncherExploreRawDirLocsButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\english\\localizedstrings\\");
		}

		private void LauncherExploreRawDirMPButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\mp\\");
		}

		private void LauncherExploreRawDirSoundAliasesButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\soundaliases\\");
		}

		private void LauncherExploreRawDirVisionButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\vision\\");
		}

		private void LauncherExploreRawDirWeaponsButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\weapons\\");
		}

		private void LauncherExploreRawGSCDirMPArtButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\maps\\mp\\createart\\");
		}

		private void LauncherExploreRawGSCDirMPButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\maps\\mp\\");
		}

		private void LauncherExploreRawGSCDirMPFXButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\maps\\mp\\createfx\\");
		}

		private void LauncherExploreRawGSCDirMPGametypesButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\maps\\mp\\gametypes\\");
		}

		private void LauncherExploreRawGSCDirSPArtButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\maps\\createart\\");
		}

		private void LauncherExploreRawGSCDirSPButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\maps\\");
		}

		private void LauncherExploreRawGSCDirSPFXButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\maps\\createfx\\");
		}

		private void LauncherExploreRawGSCDirSPGametypesButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\maps\\gametypes\\");
		}

		private void LauncherExploreRawGSCDirSPVoiceButton_Click(object sender, EventArgs e)
		{
			ExploreOpenDir(Launcher.GetRootDirectory() + "raw\\maps\\voice\\");
		}

		private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
		{
		  if (processTable.Count != 0)
		  {
			switch (MessageBox.Show("But there are still processes running!\n\nDo you want to close them, or cancel exiting from the application?", "Application will exit!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
			{
			  case DialogResult.Cancel:
				e.Cancel = true;
				return;
			  case DialogResult.Yes:
				IDictionaryEnumerator enumerator = processTable.GetEnumerator();
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
				string[] stringArray = new string[processTable.Count];
				int index = 0;
				foreach (DictionaryEntry dictionaryEntry in processTable)
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
				  int num = (int) MessageBox.Show("The following processes are still active:\n\n" + Launcher.StringArrayToString(stringArray) + "\nPlease close them if neccessary using the Task Manager, or similar program!\n", "Note before exiting the application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				  break;
				}
				break;
			}
		  }
		  UpdateMapSettings();
		  UpdateModSettings();
		  Launcher.SaveLauncherSettings(Launcher.launcherSettings.Get());
		}

		private void LauncherForm_Load(object sender, EventArgs e)
		{
		  UpdateDVars();
		  UpdateMapList();
		  UpdateModList();
		  EnableMapList();
		  UpdateStopProcessButton();
		  LauncherMapFilesSystemWatcher.Path = Launcher.GetMapSourceDirectory();
		  LauncherModsDirectorySystemWatcher.Path = Launcher.GetModsDirectory();
		  LauncherMapFilesSystemWatcher.EnableRaisingEvents = true;
		  LauncherModsDirectorySystemWatcher.EnableRaisingEvents = true;
		  MainWindow launcherForm = this;
		  launcherForm.Text = launcherForm.Text + " - " + Launcher.GetRootDirectory();
		  SetModSelection(Launcher.launcherSettings.GetString("active_mod"), true);
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
		  BuildGridDelegate(2);
		}

		private void LauncherGridMakeNewButton_Click(object sender, EventArgs e)
		{
		  BuildGridDelegate(1);
		}

		private void LauncherIwdFileTree_AfterCheck(object sender, TreeViewEventArgs e)
		{
		  LauncherIwdFileTreeBeginUpdate();
		  RecursiveCheckNodesDown(e.Node.Nodes, e.Node.Checked);
		  if (e.Node.Checked)
			RecursiveCheckNodesUp(e.Node.Parent, e.Node.Checked);
		  LauncherIwdFileTreeEndUpdate();
		}

		private void LauncherIwdFileTree_DoubleClick(object sender, EventArgs e)
		{
		  if (LauncherIwdFileTree.SelectedNode == null)
			return;
		  try
		  {
			new Process()
			{
			  StartInfo = {
				ErrorDialog = true,
				FileName = Path.Combine(Launcher.GetModDirectory(modName), LauncherIwdFileTree.SelectedNode.FullPath)
			  }
			}.Start();
		  }
		  catch
		  {
		  }
		}

		private void LauncherIwdFileTreeBeginUpdate()
		{
		  LauncherIwdFileTree.BeginUpdate();
		  LauncherIwdFileTree.AfterCheck -= new TreeViewEventHandler(LauncherIwdFileTree_AfterCheck);
		}

		private void LauncherIwdFileTreeEndUpdate()
		{
		  LauncherIwdFileTree.AfterCheck += new TreeViewEventHandler(LauncherIwdFileTree_AfterCheck);
		  LauncherIwdFileTree.EndUpdate();
		}

		private void LauncherMapFilesSystemWatcher_Changed(object sender, FileSystemEventArgs e)
		{
		  UpdateMapList();
		}

		private void LauncherMapFilesSystemWatcher_Created(object sender, FileSystemEventArgs e)
		{
		  UpdateMapList();
		}

		private void LauncherMapFilesSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
		{
		  UpdateMapList();
		}

		private void LauncherMapFilesSystemWatcher_Renamed(object sender, RenamedEventArgs e)
		{
		  UpdateMapList();
		}

		private void LauncherMapList_DoubleClick(object sender, EventArgs e)
		{
		  LauncherMapList.SelectedItem = (object) null;
		}

		private void LauncherMapList_SelectedIndexChanged(object sender, EventArgs e)
		{
		  UpdateMapSettings();
		  EnableMapList();
		  LauncherRunGameMapNameTextBox.Text = LauncherMapList.SelectedItem != null ? LauncherMapList.SelectedItem.ToString() : "";
		}

		private void LauncherMapList_MouseDown(object sender, MouseEventArgs e)
		{
		  if (e.Button != MouseButtons.Right)
			return;
		  for (int index = 0; index < LauncherMapList.Items.Count; ++index)
		  {
			if (LauncherMapList.GetItemRectangle(index).Contains(e.Location))
			  LauncherMapList_WaitingForMouseUp = index;
		  }
		}

		private void LauncherMapList_MouseUp(object sender, MouseEventArgs e)
		{
		  if (e.Button == MouseButtons.Right && LauncherMapList_WaitingForMouseUp != -1)
		  {
			for (int index = 0; index < LauncherMapList.Items.Count; ++index)
			{
			  if (LauncherMapList.GetItemRectangle(index).Contains(e.Location) && LauncherMapList_WaitingForMouseUp == index)
			  {
				LauncherMapListContextMenu_Map = index;
				LauncherMapList.SelectedIndex = index;
				LauncherMapListContextMenuStrip.Show(Cursor.Position);
			  }
			}
		  }
		  LauncherMapList_WaitingForMouseUp = -1;
		}

		private void LauncherMapTypeList_SelectedIndexChanged(object sender, EventArgs e)
		{
		  UpdateMapList();
		}

		private void LauncherModBuildButton_Click(object sender, EventArgs e)
		{
		  LauncherModComboBoxApplySettings();
		  UpdateModSettings();
		  ModBuildStart();
		}

		private void LauncherModComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
		  Launcher.launcherSettings.SetString("active_mod", LauncherModComboBox.Text);
		  LauncherModComboBoxApplySettings(load: false);
		  UpdateModSettings();
		  LauncherModComboBoxApplySettings(false);
		}

		private void LauncherModComboBoxApplySettings(bool save = true, bool load = true)
		{
		  bool flag = LauncherModComboBox.SelectedItem != null;
		  LauncherModZoneSourceGroupBox.Enabled = flag;
		  LauncherModBuildGroupBox.Enabled = flag;
		  LauncherModFolderGroupBox.Enabled = flag;
		  LauncherIwdFileGroupBox.Enabled = flag;
		  LauncherIwdFileTreeBeginUpdate();
		  if (save && modName != null && Directory.Exists(Launcher.GetModDirectory(modName, false)))
			Launcher.SaveTextFile(Path.Combine(Launcher.GetModDirectory(modName), modName + ".files"), Launcher.HashTableToStringArray(TreeViewToHashTable(LauncherIwdFileTree.Nodes)));
		  if (load && LauncherModComboBox.SelectedItem != null)
		  {
			modName = LauncherModComboBox.SelectedItem.ToString();
			string textFile = Path.Combine(Launcher.GetModDirectory(modName), modName + ".files");
			LauncherIwdFileTree.Nodes.Clear();
			AddFilesToTreeView(Launcher.GetModDirectory(modName), LauncherIwdFileTree.Nodes, true);
			HashTableToTreeView(Launcher.StringArrayToHashTable(Launcher.LoadTextFile(textFile)), LauncherIwdFileTree.Nodes);
		  }
		  LauncherIwdFileTreeEndUpdate();
		}

		private void LauncherModFolderViewButton_Click(object sender, EventArgs e)
		{
		  Process.Start(Launcher.GetModDirectory(LauncherModComboBox.SelectedItem.ToString()));
		}

		private void LauncherModsDirectorySystemWatcher_Changed(object sender, FileSystemEventArgs e)
		{
		  UpdateModList();
		}

		private void LauncherModsDirectorySystemWatcher_Created(object sender, FileSystemEventArgs e)
		{
		  UpdateModList();
		}

		private void LauncherModsDirectorySystemWatcher_Deleted(object sender, FileSystemEventArgs e)
		{
		  UpdateModList();
		}

		private void LauncherModsDirectorySystemWatcher_Renamed(object sender, RenamedEventArgs e)
		{
		  UpdateModList();
		}

		private void LauncherModZoneSourceCSVButton_Click(object sender, EventArgs e)
		{
		  string str = Path.Combine(Launcher.GetModDirectory(LauncherModComboBox.SelectedItem.ToString()), "mod.csv");
		  if (!File.Exists(str))
			File.Create(str).Close();
		  Process.Start(str);
		}

		private void LauncherModZoneSourceMissingAssetsButton_Click(object sender, EventArgs e)
		{
		  string str = Path.Combine(Launcher.GetModDirectory(LauncherModComboBox.SelectedItem.ToString()), "missingasset.csv");
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
		  if (new CreateMap().ShowDialog() != DialogResult.OK)
			return;
		  UpdateMapList();
		  EnableMapList();
		}

		private void LauncherProcessList_SelectedIndexChanged(object sender, EventArgs e)
		{
		  UpdateStopProcessButton();
		}

		private void LauncherRunGameButton_Click(object sender, EventArgs e)
		{
		  foreach (ComboBox dvarComboBox in dvarComboBoxes)
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
		  string arguments = GetGameOptions();
		  if (LauncherRunGameDeveloperBox.Checked)
			arguments += "+set developer 1 ";
		  if (LauncherRunGameLogfileBox.Checked)
			arguments += "+set logfile 1 ";
		  if (LauncherRunGameMapNameTextBox.Text.Length > 0)
			arguments = arguments + "+devmap " + LauncherRunGameMapNameTextBox.Text + " ";
		  bool mpVersion = false;
		  if (LauncherRunGameMapNameTextBox.Text.StartsWith("mp_") || LauncherRunGameModComboBox.Text.StartsWith("mp_"))
			mpVersion = true;
		  if (mpVersion && LauncherRunGameCustomCommandLineMPCheckBox.Checked)
			arguments += LauncherRunGameCustomCommandLineMPTextBox.Text;
		  else if (!mpVersion && LauncherRunGameCustomCommandLineCheckBox.Checked)
			arguments += LauncherRunGameCustomCommandLineTextBox.Text;
		  LaunchProcess(Launcher.GetGameApplication(mpVersion), arguments, (string) null, false, (MainWindow.ProcessFinishedDelegate) null);
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
			LauncherConsole.SaveFile(saveFileDialog2.FileName, RichTextBoxStreamType.RichText);
		  else
			File.WriteAllText(saveFileDialog2.FileName, LauncherConsole.Text);
		}

		private void LauncherscriptToolStripMenuItem_Click(object sender, EventArgs e)
		{
		  Process.Start(Launcher.GetRootDirectory() + "/docs/script_docs/scriptFunctions/index.htm");
		}

		private void LauncherScrollBottomConsoleButton_Click(object sender, EventArgs e)
		{
		  LauncherConsole.SelectionStart = LauncherConsole.Text.Length;
		  LauncherConsole.ScrollToCaret();
		}

		private void LauncherTimer_Tick(object sender, EventArgs e)
		{
		  if (consoleProcess != null)
			LauncherProcessTimeElapsedTextBox.Text = (DateTime.Now - consoleProcessStartTime).ToString().Substring(0, 8);
		  string gameOptions = GetGameOptions();
		  if (!(LauncherRunGameCommandLineTextBox.Text != gameOptions))
			return;
		  LauncherRunGameCommandLineTextBox.Text = gameOptions;
		}

		private void LauncherWarningsNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
		  if (Convert.ToInt32(LauncherWarningsCounter.Text) <= 0)
			return;
		  LauncherConsole.SelectionStart = LauncherWarningsNumericUpDown.Value != 0M ? FindLauncherConsoleText("WARNING:", LauncherConsole.SelectionStart + LauncherConsole.SelectionLength, LauncherConsole.Text.Length) : FindLauncherConsoleText("WARNING:", 0, LauncherConsole.SelectionStart);
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
		  MainWindow.ProcessFinishedDelegate theProcessFinishedDelegate)
		{
		  if (consoleProcess != null & consoleAttached)
		  {
			LauncherConsole.Invoke((MethodInvoker)(() =>
			{
			  string text;
			  if (!(processFileName == (string) processTable[(object) consoleProcess]))
				text = "Cannot start console process " + processFileName + "!\n\nAnother console process (" + processTable[(object) consoleProcess] + ") is already running";
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
				  FileName = Path.Combine(Launcher.GetStartupDirectory(), processFileName),
				  CreateNoWindow = true,
				  Arguments = arguments,
				  UseShellExecute = false
				}
			  };
			  process.StartInfo.WorkingDirectory = workingDirectory != null ? workingDirectory : Path.GetDirectoryName(process.StartInfo.FileName);
			  process.EnableRaisingEvents = true;
			  process.Exited += (EventHandler) ((argument0, argument1) =>
			  {
				processTable.Remove((object) process);
				UpdateProcessList();
			  });
			  if (consoleAttached)
			  {
				processFinishedDelegate = theProcessFinishedDelegate;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.OutputDataReceived += (DataReceivedEventHandler) ((s, e) => WriteConsole(e.Data, false));
				process.ErrorDataReceived += (DataReceivedEventHandler) ((s, e) => WriteConsole(e.Data, true));
				process.Exited += (EventHandler) ((argument2, argument3) => LauncherButtonCancel.Invoke((MethodInvoker)(() =>
				{
				  LauncherProcessTimeElapsedTextBox.Text = process.ExitCode != 0 ? "Error " + process.ExitCode.ToString() : "Success";
				  LauncherConsole.Focus();
				  consoleProcess = (Process) null;
				  UpdateConsoleColor();
				  if (processFinishedDelegate == null)
					return;
				  MainWindow.ProcessFinishedDelegate finishedDelegate = processFinishedDelegate;
				  processFinishedDelegate = (MainWindow.ProcessFinishedDelegate) null;
				  Process lastProcess = process;
				  finishedDelegate(lastProcess);
				})));
			  }
			  process.Exited += (EventHandler) ((argument4, argument5) => process.Dispose());
			  process.Start();
			  if (consoleAttached)
			  {
				consoleProcess = process;
				consoleProcessStartTime = DateTime.Now;
				UpdateConsoleColor();
				LauncherProcessTextBox.Text = (workingDirectory != null ? workingDirectory + "> " : "") + processFileName + " " + arguments;
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
			  }
			  processTable.Add((object) process, (object) str);
			  UpdateProcessList();
			}
			catch
			{
			  WriteConsole("FAILED TO EXECUTE: " + processFileName + " " + arguments, true);
			  if (processFinishedDelegate == null)
				return;
			  MainWindow.ProcessFinishedDelegate finishedDelegate = processFinishedDelegate;
			  processFinishedDelegate = (MainWindow.ProcessFinishedDelegate) null;
			  finishedDelegate((Process) null);
			}
		  }
		}

		private void LaunchProcessHelper(
		  bool shouldRun,
		  MainWindow.ProcessFinishedDelegate nextStage,
		  Process lastProcess,
		  string processName,
		  string processOptions,
		  string workingDirectory)
		{
		  if (lastProcess != null && lastProcess.ExitCode != 0 || !shouldRun)
			nextStage(lastProcess);
		  else
			LaunchProcess(processName, processOptions, workingDirectory, true, nextStage);
		}

		private void LaunchProcessHelper(
		  bool shouldRun,
		  MainWindow.ProcessFinishedDelegate nextStage,
		  Process lastProcess,
		  string processName,
		  string processOptions)
		{
		  LaunchProcessHelper(shouldRun, nextStage, lastProcess, processName, processOptions, (string) null);
		}

		private void mayaExporterToolStripMenuItem_Click(object sender, EventArgs e)
		{
		  Process.Start(Launcher.GetRootDirectory() + "/bin/maya/tools/Help/Model_Exporter.pdf");
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
			string str3 = Path.Combine(Launcher.GetBinDirectory(), "maya/tools/");
			string[] contents = new string[2]
			{
			  "MAYA_SCRIPT_PATH  = " + str3,
			  "MAYA_PLUG_IN_PATH = " + str3
			};
			File.WriteAllLines(str2 + "/Maya.env", contents);
			File.Copy(Path.Combine(Launcher.GetBinDirectory(), "maya/tools/usersetup.mel"), str2 + "/scripts/usersetup.mel", true);
			File.SetAttributes(str2 + "/scripts/usersetup.mel", FileAttributes.Normal);
			string str4 = "Maya2009_x86.zip";
			if (flag)
			  str4 = "Maya2009_x64.zip";
			LaunchProcess("7za", "e \"" + str4 + "\" -y", Path.Combine(Launcher.GetBinDirectory(), "maya/tools/"), false, (MainWindow.ProcessFinishedDelegate) null);
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
		  if (LauncherModBuildFastFilesCheckBox.Checked)
			Launcher.CopyFileSmart(Path.Combine(Launcher.GetModDirectory(modName), "mod.csv"), Path.Combine(Launcher.GetZoneSourceDirectory(), "mod.csv"));
		  string str = "";
		  if (LauncherModBuildLinkerOptionsTextBox.Text != null)
			str = LauncherModBuildLinkerOptionsTextBox.Text;
		  bool shouldRun = LauncherModBuildFastFilesCheckBox.Checked;
		  MainWindow.ProcessFinishedDelegate nextStage = new MainWindow.ProcessFinishedDelegate(ModBuildMoveModFastFileDelegate);
		  string[] strArray = new string[6]
		  {
			"-nopause -language ",
			Launcher.GetLanguage(),
			" -moddir ",
			modName,
			" mod ",
			str
		  };
		  LaunchProcessHelper(shouldRun, nextStage, lastProcess, "linker_pc", string.Concat(strArray));
		}

		private void ModBuildFinishedDelegate(Process lastProcess)
		{
		  Launcher.Publish();
		  EnableControls(true);
		}

		private void ModBuildIwdFileDelegate(Process lastProcess)
		{
		  string fileName = Path.Combine(Launcher.GetModDirectory(modName), modName + ".iwd");
		  if (LauncherModBuildIwdFileCheckBox.Checked)
			Launcher.DeleteFile(fileName, false);
		  bool shouldRun = LauncherModBuildIwdFileCheckBox.Checked;
		  MainWindow.ProcessFinishedDelegate nextStage = new MainWindow.ProcessFinishedDelegate(ModBuildFinishedDelegate);
		  string[] strArray = new string[5]
		  {
			"a \"",
			fileName,
			"\" -tzip -r \"@",
			Path.Combine(Launcher.GetModDirectory(modName), modName + ".files"),
			"\""
		  };
		  LaunchProcessHelper(shouldRun, nextStage, lastProcess, "7za", string.Concat(strArray), Launcher.GetModDirectory(modName));
		}

		private void ModBuildMoveModFastFileDelegate(Process lastProcess)
		{
		  if (LauncherModBuildFastFilesCheckBox.Checked)
			Launcher.MoveFile(Path.Combine(Launcher.GetZoneDirectory(), "mod.ff"), Path.Combine(Launcher.GetModDirectory(modName), "mod.ff"));
		  ModBuildIwdFileDelegate(lastProcess);
		}

		private void ModBuildSoundDelegate(Process lastProcess)
		{
		  LaunchProcessHelper(LauncherModBuildSoundsCheckBox.Checked, new MainWindow.ProcessFinishedDelegate(ModBuildFastFileDelegate), lastProcess, "MODSound", "-pc -ignore_orphans " + (LauncherModVerboseCheckBox.Checked ? "-verbose " : ""));
		}

		private void ModBuildStart()
		{
		  EnableControls(false);
		  ModBuildSoundDelegate((Process) null);
		}

		private void newModToolStripMenuItem_Click(object sender, EventArgs e)
		{
		  int num = (int) new CreateMod().ShowDialog();
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
			RecursiveCheckNodesDown(nodes, checkedFlag1);
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
		  RecursiveCheckNodesUp(parent, checkedFlag1);
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
			TreeViewToHashTable(treeNode.Nodes, ht);
		  }
		}

		private Hashtable TreeViewToHashTable(TreeNodeCollection tree)
		{
		  Hashtable ht = new Hashtable();
		  TreeViewToHashTable(tree, ht);
		  return ht;
		}

		private void UpdateConsoleColor()
		{
		  LauncherConsole.BackColor = consoleProcess == null ? Color.Black : Color.Black;
		}

		private void UpdateDVars()
		{
		}

		private void UpdateMapList()
		{
		  object selectedItem = LauncherMapList.SelectedItem;
		  int selectedIndex1 = LauncherMapList.SelectedIndex;
		  int selectedIndex2 = LauncherMapTypeList.SelectedIndex;
		  LauncherMapList.Items.Clear();
		  LauncherMapList.Items.AddRange((object[]) Launcher.GetMapList(selectedIndex2));
		  if (LauncherMapList.Items.Count == 0)
			return;
		  LauncherMapList.SelectedItem = selectedItem;
		  if (LauncherMapList.SelectedItem != null)
			return;
		  LauncherRunGameMapNameTextBox.Text = (string) null;
		}

		private void UpdateMapSettings(bool save = true, bool load = true)
		{
		  if (mapName != null & save)
		  {
			Launcher.mapSettings.SetBoolean("compile_bsp", LauncherCompileBSPCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("compile_lights", LauncherCompileLightsCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("compile_paths", LauncherConnectPathsCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("compile_reflections", LauncherCompileReflectionsCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("compile_buildffs", LauncherBuildFastFilesCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("compile_bspinfo", LauncherBspInfoCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("compile_runafter", LauncherRunMapAfterCompileCheckBox.Checked);
			Launcher.mapSettings.SetBoolean("compile_useruntab", LauncherUseRunGameTypeOptionsCheckBox.Checked);
			Launcher.mapSettings.SetString("compile_runoptions", LauncherCustomRunOptionsTextBox.Text);
			Launcher.mapSettings.SetBoolean("compile_modenabled", LauncherModSpecificMapCheckBox.Checked);
			Launcher.mapSettings.SetString("compile_modname", LauncherModSpecificMapComboBox.Text);
			Launcher.mapSettings.SetBoolean("compile_collectdots", LauncherGridCollectDotsCheckBox.Checked);
			Launcher.SaveMapSettings(mapName, Launcher.mapSettings.Get());
			mapName = (string) null;
		  }
		  if (!(LauncherMapList.SelectedItem != null & load))
			return;
		  mapName = LauncherMapList.SelectedItem.ToString();
		  Launcher.mapSettings.Set(Launcher.LoadMapSettings(mapName));
		  LauncherCompileBSPCheckBox.Checked = Launcher.mapSettings.GetBoolean("compile_bsp");
		  LauncherCompileLightsCheckBox.Checked = Launcher.mapSettings.GetBoolean("compile_lights");
		  LauncherConnectPathsCheckBox.Checked = Launcher.mapSettings.GetBoolean("compile_paths");
		  LauncherCompileReflectionsCheckBox.Checked = Launcher.mapSettings.GetBoolean("compile_reflections");
		  LauncherBuildFastFilesCheckBox.Checked = Launcher.mapSettings.GetBoolean("compile_buildffs");
		  LauncherBspInfoCheckBox.Checked = Launcher.mapSettings.GetBoolean("compile_bspinfo");
		  LauncherRunMapAfterCompileCheckBox.Checked = Launcher.mapSettings.GetBoolean("compile_runafter");
		  LauncherUseRunGameTypeOptionsCheckBox.Checked = Launcher.mapSettings.GetBoolean("compile_useruntab");
		  LauncherCustomRunOptionsTextBox.Text = Launcher.mapSettings.GetString("compile_runoptions");
		  LauncherGridCollectDotsCheckBox.Checked = Launcher.mapSettings.GetBoolean("compile_collectdots");
		  LauncherModSpecificMapCheckBox.Checked = Launcher.mapSettings.GetBoolean("compile_modenabled");
		  string str = Launcher.mapSettings.GetString("compile_modname");
		  if (str.Length > 0)
			LauncherModSpecificMapComboBox.Text = str;
		  else
			LauncherModSpecificMapComboBox.SelectedIndex = -1;
		}

		private void UpdateModSettings(bool save = true, bool load = true)
		{
		  if (modName != null & save)
		  {
			Launcher.modSettings.SetBoolean("build_fastfile", LauncherModBuildFastFilesCheckBox.Checked);
			Launcher.modSettings.SetBoolean("build_iwd", LauncherModBuildIwdFileCheckBox.Checked);
			Launcher.modSettings.SetBoolean("build_sounds", LauncherModBuildSoundsCheckBox.Checked);
			Launcher.modSettings.SetBoolean("build_verbose", LauncherModVerboseCheckBox.Checked);
			Launcher.modSettings.SetString("build_options", LauncherModBuildLinkerOptionsTextBox.Text);
			Launcher.SaveModSettings(modName, Launcher.modSettings.Get());
			modName = (string) null;
		  }
		  if (!(LauncherModComboBox.SelectedItem != null & load))
			return;
		  modName = LauncherModComboBox.SelectedItem.ToString();
		  Launcher.modSettings.Set(Launcher.LoadModSettings(modName));
		  LauncherModBuildFastFilesCheckBox.Checked = Launcher.modSettings.GetBoolean("build_fastfile");
		  LauncherModBuildIwdFileCheckBox.Checked = Launcher.modSettings.GetBoolean("build_iwd");
		  LauncherModBuildSoundsCheckBox.Checked = Launcher.modSettings.GetBoolean("build_sounds");
		  LauncherModVerboseCheckBox.Checked = Launcher.modSettings.GetBoolean("build_verbose");
		  LauncherModBuildLinkerOptionsTextBox.Text = Launcher.modSettings.GetString("build_options");
		}

		private void UpdateModList()
		{
		  ComboBox[] comboBoxArray = new ComboBox[3]
		  {
			LauncherRunGameModComboBox,
			LauncherModComboBox,
			LauncherModSpecificMapComboBox
		  };
		  string[] strArray = new string[comboBoxArray.Length];
		  string[] modList = Launcher.GetModList();
		  for (int index = 0; index < comboBoxArray.Length; ++index)
		  {
			strArray[index] = comboBoxArray[index].SelectedItem != null ? comboBoxArray[index].SelectedItem.ToString() : "";
			comboBoxArray[index].Items.Clear();
		  }
		  LauncherRunGameModComboBox.Items.Add((object) "(not set)");
		  LauncherRunGameModComboBox.Items.Add((object) "(auto)");
		  for (int index = 0; index < comboBoxArray.Length; ++index)
		  {
			comboBoxArray[index].Items.AddRange((object[]) modList);
			if (comboBoxArray[index].Items.Count > 0)
			  comboBoxArray[index].Text = strArray[index];
		  }
		  LauncherModComboBoxApplySettings();
		  if (LauncherRunGameModComboBox.SelectedIndex >= 0)
			return;
		  LauncherRunGameModComboBox.SelectedIndex = 0;
		}

		private void UpdateProcessList()
		{
		  LauncherProcessList.Invoke((MethodInvoker)(() =>
		  {
			processList.Clear();
			LauncherProcessList.Items.Clear();
			foreach (DictionaryEntry dictionaryEntry in processTable)
			{
			  processList.Add((object) dictionaryEntry);
			  LauncherProcessList.Items.Add((object) Path.GetFileNameWithoutExtension((string) dictionaryEntry.Value));
			}
			if (LauncherProcessList.SelectedIndex < 0 && LauncherProcessList.Items.Count > 0)
			  LauncherProcessList.SelectedIndex = 0;
			UpdateStopProcessButton();
		  }));
		}

		private void UpdateRunGameCommandLine()
		{
		}

		private void UpdateStopProcessButton()
		{
		  int selectedIndex = LauncherProcessList.SelectedIndex;
		  if (selectedIndex < 0)
		  {
			LauncherButtonCancel.Enabled = false;
			LauncherButtonCancel.Text = "No Active Process\n\nStart one and then use this button to stop it";
		  }
		  else
		  {
			LauncherButtonCancel.Enabled = true;
			if (((DictionaryEntry) processList[selectedIndex]).Key == consoleProcess)
			  LauncherButtonCancel.Text = "Stop Console Process\n\n" + Path.GetFileNameWithoutExtension(((DictionaryEntry) processList[selectedIndex]).Value.ToString());
			else
			  LauncherButtonCancel.Text = "Stop Application\n\n" + Path.GetFileNameWithoutExtension(((DictionaryEntry) processList[selectedIndex]).Value.ToString());
		  }
		}

		private void utilityDocsToolStripMenuItem_Click(object sender, EventArgs e)
		{
		  Process.Start(Launcher.GetRootDirectory() + "/docs/script_docs/UtilityFunctions/index.htm");
		}

		private void WriteConsole(string s, bool isStdError)
		{
		  if (s == null)
			return;
		  long ticks = DateTime.Now.Ticks;
		  bool flag2 = ticks - consoleTicksWhenLastFocus > 10000000L;
		  if (flag2)
			consoleTicksWhenLastFocus = ticks;
		  if (s.Contains("Setting breakpad minidump AppID = ") || s.Contains("Steam_SetMinidumpSteamID:  Caching Steam ID:  "))
			s = "";
		  else
			LauncherConsole.Invoke((MethodInvoker) (() =>
			{
			  Color selectionColor = LauncherConsole.SelectionColor;
			  Font selectionFont = LauncherConsole.SelectionFont;
			  bool flag1 = isStdError || s.Contains("ERROR:");
			  bool flag3 = s.Contains("WARNING:");
			  if (flag1 | flag3)
			  {
				if (!flag1)
				{
						LauncherWarningsPictureBox.BackgroundImage = Resources.Warning;
						LauncherWarningsCounter.Text = Convert.ToString(Convert.ToInt32(LauncherWarningsCounter.Text) + 1);
				}
				else
				{
						LauncherErrorsPictureBox.BackgroundImage = Resources.error;
						LauncherErrorsCounter.Text = Convert.ToString(Convert.ToInt32(LauncherErrorsCounter.Text) + 1);
				}
				LauncherConsole.SelectionFont = new Font(LauncherConsole.SelectionFont, FontStyle.Bold);
				LauncherConsole.SelectionColor = flag1 ? Color.Red : Color.Green;
			  }
			  LauncherConsole.AppendText(s + "\n");
			  if (flag2)
				LauncherConsole.Focus();
			  if (!(flag1 | flag3))
				return;
			  LauncherConsole.SelectionColor = selectionColor;
			  LauncherConsole.SelectionFont = selectionFont;
			}));
		}

		private event ProcessFinishedDelegate processFinishedDelegate;

		private void RunToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string str1 = LauncherMapList.Items[LauncherMapListContextMenu_Map].ToString();
			string str2 = "+set fs_game ";
			string arguments = !LauncherModSpecificMapCheckBox.Checked ? "" : (LauncherModSpecificMapComboBox.Text.Length <= 0 || !LauncherModSpecificMapCheckBox.Checked ? "" : str2 + "\"mods/" + LauncherModSpecificMapComboBox.Text + "\" ");
			if (str1.Length > 0)
				arguments = arguments + "+devmap " + str1 + " ";
			bool mpVersion = false;
			if (LauncherRunGameMapNameTextBox.Text.Contains("mp_"))
				mpVersion = true;
			LaunchProcess(Launcher.GetGameApplication(mpVersion), arguments, (string) null, false, (MainWindow.ProcessFinishedDelegate) null);
		}

		private void EditToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string str = LauncherMapList.Items[LauncherMapListContextMenu_Map].ToString();
			LaunchProcess("CoDBORadiant", "\"" + Path.Combine(Launcher.GetMapSourceDirectory(), str + ".map") + "\"", (string) null, false, (MainWindow.ProcessFinishedDelegate) null);
		}

		private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string mapName = LauncherMapList.Items[LauncherMapListContextMenu_Map].ToString();
			string[] mapFiles1 = Launcher.GetMapFiles(mapName);
			if (DialogResult.Yes != MessageBox.Show("The following files would be deleted:\n\n" + Launcher.StringArrayToString(mapFiles1), "Are you sure you want to delete these files?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
				return;
			foreach (string fileName in mapFiles1)
				Launcher.DeleteFile(fileName);
			string[] mapFiles2 = Launcher.GetMapFiles(mapName);
			if (mapFiles2.Length != 0)
			{
				int num = (int) MessageBox.Show("Could not delete the following files:\n\n" + Launcher.StringArrayToString(mapFiles2), "Error deleting files", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			UpdateMapList();
			EnableMapList();
		}

		internal delegate void ProcessFinishedDelegate(Process lastProcess);
	}
}