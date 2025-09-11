// Decompiled with JetBrains decompiler
// Type: Launcher
// Assembly: Launcher, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BE2EDF30-BDA3-4FE0-9EFC-B0A1BE215D80
// Assembly location: D:\SteamLibrary\steamapps\common\Call of Duty Black Ops\bin\Launcher.exe

using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Launcher
{
  internal static class Launcher
  {
    public static MainWindow TheLauncherForm = (MainWindow) null;
    public static Settings launcherSettings = new Settings();
    public static Settings mapSettings = new Settings();
    public static Settings modSettings;
    private static bool use_exedir_as_startupdir = true;

    static Launcher() => Launcher.launcherSettings.Set(Launcher.LoadLauncherSettings());

    public static string CanonicalDirectory(string path, bool createIfMissing = true)
    {
			string fullPath = Path.GetFullPath(path);
			MakeDirectory(fullPath);

			if (!fullPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
			{
				fullPath += Path.DirectorySeparatorChar.ToString();
			}
			return fullPath;
		}

    public static bool CopyFile(string sourceFileName, string destinationFileName)
    {
      return Launcher.CopyFile(sourceFileName, destinationFileName, false);
    }

    public static bool CopyFile(string sourceFileName, string destinationFileName, bool smartCopy)
    {
      if (!File.Exists(sourceFileName))
      {
        if (smartCopy)
          Launcher.DeleteFile(destinationFileName, false);
        return false;
      }
      FileInfo fileInfo1 = new FileInfo(sourceFileName);
      if (smartCopy)
      {
        FileInfo fileInfo2 = new FileInfo(destinationFileName);
        if (fileInfo1.Exists && fileInfo2.Exists && fileInfo1.CreationTime == fileInfo2.CreationTime && fileInfo1.LastWriteTime == fileInfo2.LastWriteTime && fileInfo1.Length == fileInfo2.Length)
          return true;
      }
      Launcher.WriteMessage("Copying  " + sourceFileName + "\n     to  " + destinationFileName + "\n");
      if (!Launcher.DeleteFile(destinationFileName, false))
        return false;
      Launcher.MakeDirectory(Path.GetDirectoryName(destinationFileName));
      try
      {
        File.Copy(sourceFileName, destinationFileName);
        if (smartCopy)
        {
          File.SetCreationTime(destinationFileName, fileInfo1.CreationTime);
          File.SetLastWriteTime(destinationFileName, fileInfo1.LastWriteTime);
        }
        return true;
      }
      catch (Exception ex)
      {
        Launcher.WriteError("ERROR: " + ex.Message + "\n");
        return false;
      }
    }

    public static bool CopyFileSmart(string sourceFileName, string destinationFileName)
    {
      return Launcher.CopyFile(sourceFileName, destinationFileName, true);
    }

    public static string[] CreateMapFromTemplate(string mapTemplate, string mapName)
    {
      return Launcher.CreateMapFromTemplate(mapTemplate, mapName, false);
    }

    public static string[] CreateMapFromTemplate(
      string mapTemplate,
      string mapName,
      bool justCheckForOverwrite)
    {
      string[] stringArray = new string[0];
      string directory = Launcher.CanonicalDirectory(Path.Combine(Launcher.GetMapTemplatesDirectory(), mapTemplate));
      foreach (string textFile in Launcher.GetFilesRecursively(directory, "*template*"))
      {
        string str1 = textFile.Substring(directory.Length).Replace("template", mapName);
        string str2 = Path.Combine(Launcher.GetRootDirectory(), str1);
        if (!justCheckForOverwrite)
        {
          string[] text = Launcher.LoadTextFile(textFile);
          int num = 0;
          foreach (string str3 in text)
          {
            int index = num++;
            text[index] = str3.Replace("template", mapName);
          }
          Launcher.SaveTextFile(str2, text);
        }
        else if (File.Exists(str2))
          Launcher.StringArrayAdd(ref stringArray, str1);
      }
      return stringArray;
    }

    public static void CreateZoneSourceFiles(string mapName)
    {
      using (StreamWriter streamWriter = new StreamWriter(Launcher.GetZoneSourceFile(mapName)))
      {
        if (!Launcher.IsMP(mapName))
        {
          streamWriter.WriteLine("ignore,code_post_gfx");
          streamWriter.WriteLine("ignore,common");
          streamWriter.WriteLine("col_map_sp,maps/" + mapName + ".d3dbsp");
          streamWriter.WriteLine("rawfile,maps/" + mapName + ".gsc");
          streamWriter.WriteLine("rawfile,maps/" + mapName + "_anim.gsc");
          streamWriter.WriteLine("rawfile,maps/" + mapName + "_amb.gsc");
          streamWriter.WriteLine("rawfile,maps/" + mapName + "_fx.gsc");
          streamWriter.WriteLine("sound,common," + mapName + ",all_sp");
          streamWriter.WriteLine("sound,generic," + mapName + ",all_sp");
          streamWriter.WriteLine("sound,voiceovers," + mapName + ",all_sp");
          streamWriter.WriteLine("sound,requests," + mapName + ",all_sp");
        }
        else
        {
          streamWriter.WriteLine("ignore,code_post_gfx_mp");
          streamWriter.WriteLine("ignore,common_mp");
          streamWriter.WriteLine("col_map_mp,maps/mp/" + mapName + ".d3dbsp");
          streamWriter.WriteLine("rawfile,maps/mp/" + mapName + ".gsc");
          streamWriter.WriteLine("rawfile,maps/mp/" + mapName + "_fx.gsc");
          streamWriter.WriteLine("sound,common," + mapName + ",all_mp");
          streamWriter.WriteLine("sound,generic," + mapName + ",all_mp");
          streamWriter.WriteLine("sound,voiceovers," + mapName + ",all_mp");
          streamWriter.WriteLine("sound,multiplayer," + mapName + ",all_mp");
        }
      }
    }

    public static bool DeleteFile(string fileName) => Launcher.DeleteFile(fileName, true);

    public static bool DeleteFile(string fileName, bool verbose)
    {
      if (!File.Exists(fileName))
        return true;
      if (verbose)
        Launcher.WriteMessage("Deleting " + fileName + "\n");
      try
      {
        File.SetAttributes(fileName, FileAttributes.Normal);
        File.Delete(fileName);
        return true;
      }
      catch (Exception ex)
      {
        if (verbose)
          Launcher.WriteError("ERROR: " + ex.Message + "\n");
        return false;
      }
    }

    public static string FilterMP(string name) => !Launcher.IsMP(name) ? name : name.Substring(3);

    public static string FilterZM(string name) => !Launcher.IsZM(name) ? name : name.Substring(7);

    public static string FilterPrefix(string name, Launcher.MAP_TEMPLATE_TYPE prevTemplateType)
    {
      if (prevTemplateType == Launcher.MAP_TEMPLATE_TYPE.SELECTION_MP_TEMPLATE)
        return Launcher.FilterMP(name);
      return prevTemplateType == Launcher.MAP_TEMPLATE_TYPE.SELECTION_ZM_TEMPLATE ? Launcher.FilterZM(name) : name;
    }

    public static string GetBinDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetRootDirectory(), "bin"));
    }

    public static string GetBspOptions()
    {
      string[] strArray = new string[6]
      {
        Launcher.mapSettings.GetBoolean("bspoptions_onlyents") ? " -onlyents" : "",
        !Launcher.mapSettings.GetBoolean("bspoptions_blocksize") ? "" : " -blocksize " + Launcher.mapSettings.GetDecimal("bspoptions_blocksize_val").ToString(),
        !Launcher.mapSettings.GetBoolean("bspoptions_samplescale") ? "" : " -samplescale " + Launcher.mapSettings.GetDecimal("bspoptions_samplescale_val").ToString(),
        (Launcher.mapSettings.GetBoolean("bspoptions_debuglightmaps") ? " -debugLightmaps" : "") + " ",
        null,
        null
      };
      strArray[3] = (Launcher.mapSettings.GetBoolean("bspoptions_leaktest") ? " -LeakTest" : "") + " ";
      strArray[3] = (Launcher.mapSettings.GetBoolean("bspoptions_debugprobes") ? " -debugProbes" : "") + " ";
      strArray[4] = Launcher.mapSettings.GetString("bspoptions_extraoptions");
      strArray[5] = " ";
      return string.Concat(strArray);
    }

    public static string GetClientScriptsDirectory(bool isMP = false)
    {
      string path2 = isMP ? "mp\\clientscripts" : "clientscripts";
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetRawDirectory(), path2));
    }

    public static string GetCreateFxDirectory(bool isMP = false)
    {
      string path2 = isMP ? "mp\\createfx" : "createfx";
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetClientScriptsDirectory(), path2));
    }

    public static string[] GetDirs(string directory)
    {
      string[] stringArray = new string[0];
      foreach (FileSystemInfo directory1 in new DirectoryInfo(directory).GetDirectories())
        Launcher.StringArrayAdd(ref stringArray, directory1.Name);
      return stringArray;
    }

    public static string GetExposureDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetRawDirectory(), "exposure"));
    }

    public static string[] GetFiles(string directory, string searchFilter)
    {
      string[] stringArray = new string[0];
      foreach (FileInfo file in new DirectoryInfo(directory).GetFiles(searchFilter))
        Launcher.StringArrayAdd(ref stringArray, Path.GetFileName(file.Name));
      return stringArray;
    }

    public static string[] GetFilesRecursively(string directory)
    {
      return Launcher.GetFilesRecursively(directory, "*");
    }

    public static string[] GetFilesRecursively(string directory, string filesToIncludeFilter)
    {
      string[] files = new string[0];
      Launcher.GetFilesRecursively(directory, filesToIncludeFilter, ref files);
      return files;
    }

    public static void GetFilesRecursively(
      string directory,
      string filesToIncludeFilter,
      ref string[] files)
    {
      foreach (DirectoryInfo directory1 in new DirectoryInfo(directory).GetDirectories())
        Launcher.GetFilesRecursively(Path.Combine(directory, directory1.Name), filesToIncludeFilter, ref files);
      foreach (FileInfo file in new DirectoryInfo(directory).GetFiles(filesToIncludeFilter))
        Launcher.StringArrayAdd(ref files, Path.Combine(directory, file.Name.ToLower()));
    }

    public static string[] GetFilesWithoutExtension(string directory, string searchFilter)
    {
      string[] stringArray = new string[0];
      string str = searchFilter.TrimStart('*');
      try
      {
        foreach (FileSystemInfo file in new DirectoryInfo(directory).GetFiles(searchFilter))
        {
          string name = file.Name;
          if (str.Length == 0 || str.Length > 0 && name.EndsWith(str))
            Launcher.StringArrayAdd(ref stringArray, Path.GetFileNameWithoutExtension(name));
        }
      }
      catch
      {
      }
      return stringArray;
    }

    public static string GetGameApplication(bool mpVersion)
    {
      return mpVersion ? "../BlackOpsMP" : "../BlackOps";
    }

    public static string GetGameTool(bool mpVersion) => mpVersion ? "../BlackOpsMP" : "../BlackOps";

    public static string GetLanguage() => "english";

    public static string GetLightOptions()
    {
      string str1 = (Launcher.mapSettings.GetBoolean("lightoptions_extra") ? "-extra" : "-fast") + (Launcher.mapSettings.GetBoolean("lightoptions_nomodelshadow") ? " -nomodelshadow" : " -modelshadow");
      Decimal num;
      string str2;
      if (!Launcher.mapSettings.GetBoolean("lightoptions_traces"))
      {
        str2 = "";
      }
      else
      {
        num = Launcher.mapSettings.GetDecimal("lightoptions_traces_val");
        str2 = " -traces " + num.ToString();
      }
      string str3 = str1 + str2;
      string str4;
      if (!Launcher.mapSettings.GetBoolean("lightoptions_maxbounces"))
      {
        str4 = "";
      }
      else
      {
        num = Launcher.mapSettings.GetDecimal("lightoptions_maxbounces_val");
        str4 = " -maxbounces " + num.ToString();
      }
      string str5 = str3 + str4;
      string str6;
      if (!Launcher.mapSettings.GetBoolean("lightoptions_jitter"))
      {
        str6 = "";
      }
      else
      {
        num = Launcher.mapSettings.GetDecimal("lightoptions_jitter_val");
        str6 = " -jitter " + num.ToString();
      }
      string str7 = str5 + str6;
      string str8;
      if (!Launcher.mapSettings.GetBoolean("lightoptions_lgi"))
      {
        str8 = "";
      }
      else
      {
        num = Launcher.mapSettings.GetDecimal("lightoptions_lgi_val");
        str8 = " -LightGridIntensity " + num.ToString();
      }
      return str7 + str8 + (Launcher.mapSettings.GetBoolean("lightoptions_verbose") ? " -verbose " : "") + " " + (Launcher.mapSettings.GetBoolean("lightoptions_hdr") ? " -HDR 1 " : "") + " " + Launcher.mapSettings.GetString("lightoptions_extraoptions") + " ";
    }

    public static string GetLoadZone(string mapName) => mapName + "_load";

    private static string GetLocalApplicationDirectory() => Launcher.GetRootDirectory();

    private static string GetLocalApplicationModDirectory(string modName)
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetLocalApplicationModsDirectory(), modName));
    }

    public static string[] GetLocalApplicationModFiles(string modName)
    {
      return Launcher.GetModFilesByDirectory(Launcher.GetLocalApplicationModDirectory(modName));
    }

    private static string GetLocalApplicationModsDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetLocalApplicationDirectory(), "mods"));
    }

    private static string GetLocalApplicationUsermapsDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetLocalApplicationDirectory(), "usermaps"));
    }

    public static string[] GetMapFiles(string mapName)
    {
      bool isMP = mapName.StartsWith("mp_");
      string[] stringArray = new string[0];
      string[] strArray1 = new string[7]
      {
        Launcher.GetMapSourceDirectory(isMP),
        Launcher.GetRawMapsDirectory(isMP),
        Launcher.GetZoneSourceDirectory(),
        Launcher.GetCreateFxDirectory(isMP),
        Launcher.GetClientScriptsDirectory(isMP),
        Launcher.GetExposureDirectory(),
        Launcher.GetStringAssetsDirectory()
      };
      foreach (string str1 in strArray1)
      {
        string[] strArray2 = new string[2]{ ".*", "_*.*" };
        foreach (string str2 in strArray2)
        {
          string[] strArray3 = new string[2]
          {
            "",
            "localized_"
          };
          foreach (string str3 in strArray3)
          {
            foreach (FileInfo file in new DirectoryInfo(str1).GetFiles(str3 + mapName + str2))
              Launcher.StringArrayAdd(ref stringArray, Path.Combine(str1, file.Name));
          }
        }
      }
      return stringArray;
    }

    public static string[] GetMapList(int isMP)
    {
      if (isMP == 0)
        return Launcher.GetFilesWithoutExtension(Launcher.GetMapSourceDirectory(), "*.map");
      try
      {
        return Launcher.GetFilesWithoutExtension(Launcher.GetMapSourceDirectory() + "\\mp", "*.map");
      }
      catch
      {
        Directory.CreateDirectory(Launcher.GetMapSourceDirectory() + "\\mp");
        return Launcher.GetFilesWithoutExtension(Launcher.GetMapSourceDirectory() + "\\mp", "*.map");
      }
    }

    public static string GetMapSettingsDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetStartupDirectory(), Path.Combine(nameof (Launcher), "map_settings")));
    }

    public static string GetModSettingsDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetStartupDirectory(), Path.Combine(nameof (Launcher), "mod_settings")));
    }

    public static string GetLauncherSettingsDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetStartupDirectory(), nameof (Launcher)));
    }

    private static string GetMapSettingsFilename(string mapName)
    {
      return Path.Combine(Launcher.GetMapSettingsDirectory(), mapName + ".cfg");
    }

    private static string GetModSettingsFilename(string modName)
    {
      return Path.Combine(Launcher.GetModSettingsDirectory(), modName + ".cfg");
    }

    private static string GetLauncherSettingsFilename()
    {
      return Path.Combine(Launcher.GetLauncherSettingsDirectory(), "settings" + ".cfg");
    }

    public static string GetMapSourceDirectory(bool isMP = false)
    {
      string path2 = isMP ? "map_source\\mp" : "map_source";
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetRootDirectory(), path2));
    }

    public static string GetMapTemplatesDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetStartupDirectory(), Path.Combine(nameof (Launcher), "map_templates")));
    }

    public static string[] GetMapTemplatesList()
    {
      return Launcher.GetDirs(Launcher.GetMapTemplatesDirectory());
    }

    public static string GetModDirectory(string modName, bool createIfMissing = true)
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetModsDirectory(), modName), createIfMissing);
    }

    public static string[] GetModFiles(string modName)
    {
      return Launcher.GetModFilesByDirectory(Launcher.GetModDirectory(modName));
    }

    public static string[] GetModFilesByDirectory(string directory)
    {
      string[] filesRecursively1 = Launcher.GetFilesRecursively(directory, "*.ff");
      string[] filesRecursively2 = Launcher.GetFilesRecursively(directory, "*.iwd");
      string[] filesRecursively3 = Launcher.GetFilesRecursively(directory, "*.arena");
      string[] filesByDirectory = new string[filesRecursively1.Length + filesRecursively2.Length + filesRecursively3.Length];
      filesRecursively1.CopyTo((Array) filesByDirectory, 0);
      filesRecursively2.CopyTo((Array) filesByDirectory, filesRecursively1.Length);
      filesRecursively3.CopyTo((Array) filesByDirectory, filesRecursively1.Length + filesRecursively2.Length);
      return filesByDirectory;
    }

    public static string[] GetModList() => Launcher.GetDirs(Launcher.GetModsDirectory());

    public static string GetModsDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetRootDirectory(), "mods"));
    }

    public static string GetRawDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetRootDirectory(), "raw"));
    }

    public static string GetRawMapsDirectory(bool isMP = false)
    {
      string path2 = isMP ? "maps\\mp" : "maps";
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetRawDirectory(), path2));
    }

    public static string GetRootDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetStartupDirectory(), ".."));
    }

    public static string GetStartupDirectory()
    {
      string path = Launcher.use_exedir_as_startupdir ? Path.GetDirectoryName(Application.ExecutablePath) : Path.GetFullPath(".");
      Directory.SetCurrentDirectory(path);
      return Launcher.CanonicalDirectory(path);
    }

    public static string GetStringAssetsDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetRootDirectory(), "string_assets"));
    }

    public static string GetUsermapsDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetModsDirectory(), "usermaps"));
    }

    public static string GetZoneDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Path.Combine(Launcher.GetRootDirectory(), "zone"), Launcher.GetLanguage()));
    }

    public static string GetZoneSourceDirectory()
    {
      return Launcher.CanonicalDirectory(Path.Combine(Launcher.GetRootDirectory(), "zone_source"));
    }

    public static string GetZoneSourceFile(string mapName)
    {
      return Path.Combine(Launcher.GetZoneSourceDirectory(), mapName + ".csv");
    }

    public static string GetZoneSourceLoadCSVFile(string mapName)
    {
      return Path.Combine(Launcher.GetZoneSourceDirectory(), Launcher.GetLoadZone(mapName) + ".csv");
    }

    public static string[] HashTableToStringArray(Hashtable hashTable)
    {
      int num = 0;
      string[] array = new string[hashTable.Count];
      foreach (DictionaryEntry dictionaryEntry in hashTable)
        array[num++] = dictionaryEntry.Key.ToString() + (dictionaryEntry.Value != null ? (object) ("," + dictionaryEntry.Value) : (object) "");
      Array.Sort<string>(array);
      return array;
    }

    public static bool IsMP(string name) => name.ToLower().StartsWith("mp_");

    public static bool IsZM(string name) => name.ToLower().StartsWith("zombie_");

    public static bool IsMultiplayerMapTemplate(string mapTemplate)
    {
      return File.Exists(Path.Combine(Path.Combine(Launcher.GetMapTemplatesDirectory(), mapTemplate), "mp.txt"));
    }

    public static bool IsZombieMapTemplate(string mapTemplate)
    {
      return File.Exists(Path.Combine(Path.Combine(Launcher.GetMapTemplatesDirectory(), mapTemplate), "zm.txt"));
    }

    public static Hashtable LoadMapSettings(string mapName)
    {
      string settingsFilename = Launcher.GetMapSettingsFilename(mapName);
      if (!File.Exists(settingsFilename))
        File.Create(settingsFilename).Dispose();
      return Launcher.StringArrayToHashTable(Launcher.LoadTextFile(settingsFilename));
    }

    public static Hashtable LoadModSettings(string modName)
    {
      string settingsFilename = Launcher.GetModSettingsFilename(modName);
      if (!File.Exists(settingsFilename))
        File.Create(settingsFilename).Dispose();
      return Launcher.StringArrayToHashTable(Launcher.LoadTextFile(settingsFilename));
    }

    public static Hashtable LoadLauncherSettings()
    {
      string settingsFilename = Launcher.GetLauncherSettingsFilename();
      if (!File.Exists(settingsFilename))
        File.Create(settingsFilename).Dispose();
      return Launcher.StringArrayToHashTable(Launcher.LoadTextFile(settingsFilename));
    }

    public static string[] LoadTextFile(string textFile, string skipCommentLinesStartingWith)
    {
      string[] stringArray = new string[0];
      try
      {
        using (StreamReader streamReader = new StreamReader(textFile))
        {
          string stringItem;
          while ((stringItem = streamReader.ReadLine()) != null)
          {
            stringItem.Trim();
            if (!(stringItem == "") && (skipCommentLinesStartingWith == null || !stringItem.StartsWith(skipCommentLinesStartingWith)))
              Launcher.StringArrayAdd(ref stringArray, stringItem);
          }
        }
      }
      catch
      {
      }
      return stringArray;
    }

    public static string[] LoadTextFile(string textFile)
    {
      return Launcher.LoadTextFile(textFile, (string) null);
    }

    [STAThread]
    private static void Main()
    {
      bool createdNew = false;
      string name = "";
      foreach (char ch in (Launcher.GetRootDirectory() + nameof(Launcher)).ToLower())
        name += (ch == '\\' || ch == ':' ? '-' : ch);
      Mutex mutex = new Mutex(true, name, out createdNew);
      if (!createdNew)
      {
        NativeMethods.PostMessage((IntPtr) (int) ushort.MaxValue, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
      }
      else
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run((Form) (Launcher.TheLauncherForm = new MainWindow()));
      }
    }

    public static void MakeDirectory(string directoryName)
    {
      while (!Directory.Exists(directoryName))
      {
        string directoryName1 = Path.GetDirectoryName(directoryName);
        if (directoryName1 != directoryName)
          Launcher.MakeDirectory(directoryName1);
        Directory.CreateDirectory(directoryName);
      }
    }

    public static string MakeMP(string name) => Launcher.IsMP(name) ? name : "mp_" + name;

    public static string MakeZM(string name) => Launcher.IsZM(name) ? name : "zombie_" + name;

    public static bool MoveFile(string sourceFileName, string destinationFileName)
    {
      if (!File.Exists(sourceFileName))
        return false;
      Launcher.WriteMessage("Moving   " + sourceFileName + "\n    to   " + destinationFileName + "\n");
      if (!Launcher.DeleteFile(destinationFileName, false))
        return false;
      Launcher.MakeDirectory(Path.GetDirectoryName(destinationFileName));
      try
      {
        File.Move(sourceFileName, destinationFileName);
        return true;
      }
      catch (Exception ex)
      {
        Launcher.WriteError("ERROR: " + ex.Message + "\n");
        return false;
      }
    }

    public static void Publish()
    {
      Launcher.PublishUsermaps();
      Launcher.PublishMods();
    }

    public static void PublishMod(string modName)
    {
      string modDirectory = Launcher.GetModDirectory(modName);
      foreach (string modFile in Launcher.GetModFiles(modName))
        Launcher.CopyFileSmart(modFile, Path.Combine(Launcher.GetLocalApplicationModDirectory(modName), modFile.Substring(modDirectory.Length)));
    }

    public static void PublishMods()
    {
      foreach (string mod in Launcher.GetModList())
        Launcher.PublishMod(mod);
    }

    public static void PublishUsermaps()
    {
      string usermapsDirectory = Launcher.GetUsermapsDirectory();
      foreach (string sourceFileName in Launcher.GetFilesRecursively(usermapsDirectory, "*.ff"))
        Launcher.CopyFileSmart(sourceFileName, Path.Combine(Launcher.GetLocalApplicationUsermapsDirectory(), sourceFileName.Substring(usermapsDirectory.Length)));
    }

    public static void SaveMapSettings(string mapName, Hashtable mapSettings)
    {
      Launcher.SaveTextFile(Launcher.GetMapSettingsFilename(mapName), Launcher.HashTableToStringArray(mapSettings));
    }

    public static void SaveModSettings(string modName, Hashtable modSettings)
    {
      Launcher.SaveTextFile(Launcher.GetModSettingsFilename(modName), Launcher.HashTableToStringArray(modSettings));
    }

    public static void SaveLauncherSettings(Hashtable settings)
    {
      Launcher.SaveTextFile(Launcher.GetLauncherSettingsFilename(), Launcher.HashTableToStringArray(settings));
    }

    public static void SaveTextFile(string textFile, string[] text)
    {
      Directory.CreateDirectory(Path.GetDirectoryName(textFile));
      using (StreamWriter streamWriter = new StreamWriter(textFile))
      {
        foreach (string str in text)
          streamWriter.WriteLine(str);
      }
    }

    public static Decimal SetNumericUpDownValue(NumericUpDown ctrl, Decimal Value)
    {
      Decimal num = ctrl.Value;
      if (Value < ctrl.Minimum)
      {
        ctrl.Value = ctrl.Minimum;
        return num;
      }
      if (Value <= ctrl.Maximum)
      {
        ctrl.Value = Value;
        return num;
      }
      ctrl.Value = ctrl.Maximum;
      return num;
    }

    public static void StringArrayAdd(ref string[] stringArray, string stringItem)
    {
      Array.Resize<string>(ref stringArray, stringArray.Length + 1);
      stringArray[stringArray.Length - 1] = stringItem;
    }

    public static Hashtable StringArrayToHashTable(string[] stringArray)
    {
      Hashtable hashTable = new Hashtable(stringArray.Length);
      foreach (string str1 in stringArray)
      {
        char[] chArray = new char[1]{ ',' };
        string[] strArray = str1.Split(chArray);
        if (strArray.Length != 0)
        {
          Hashtable hashtable = hashTable;
          string str2 = strArray[0];
          object obj1 = strArray.Length <= 1 ? (object) null : (object) strArray[1];
          string key = str2;
          object obj2 = obj1;
          hashtable.Add((object) key, obj2);
        }
      }
      return hashTable;
    }

    public static string StringArrayToString(string[] stringArray)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (string str in stringArray)
        stringBuilder.Append(str).AppendLine();
      return stringBuilder.ToString();
    }

    public static void WriteError(string s) => Launcher.WriteMessage(s, Color.Red);

    public static void WriteMessage(string s, Color messageColor)
    {
      Color selectionColor = Launcher.TheLauncherForm.LauncherConsole.SelectionColor;
      Launcher.TheLauncherForm.LauncherConsole.SelectionColor = messageColor;
      Launcher.TheLauncherForm.LauncherConsole.AppendText(s);
      Launcher.TheLauncherForm.LauncherConsole.SelectionColor = selectionColor;
      Launcher.TheLauncherForm.LauncherConsole.Focus();
    }

    public static void WriteMessage(string s) => Launcher.WriteMessage(s, Color.SlateBlue);

    public enum MAP_TEMPLATE_TYPE
    {
      SELECTION_UNDEFINED_TEMPLATE,
      SELECTION_MP_TEMPLATE,
      SELECTION_ZM_TEMPLATE,
      SELECTION_CUSTOM_TEMPLATE,
    }
  }
}
