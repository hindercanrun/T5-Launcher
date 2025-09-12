using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Utils
{
	internal class FileSystem
	{
#region Folder Getting
		internal static string CanonicalDirectory(
			string path,
			bool createIfMissing = true)
		{
			string fullPath = Path.GetFullPath(path);

			if (createIfMissing) CreateFolder(fullPath);
			if (!fullPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
				fullPath += Path.DirectorySeparatorChar.ToString();
			return fullPath;
		}
#endregion

#region Folder Creating
		internal static void CreateFolder(string directoryName)
		{
			if (string.IsNullOrWhiteSpace(directoryName)) return;
			Directory.CreateDirectory(directoryName);
		}
#endregion

#region File Getting
		internal static string[] GetFiles(
			string directory,
			string searchFilter)
		{
			// Get all files matching the search filter and return their filenames
			var files = new List<string>();
			foreach (var file in new DirectoryInfo(directory).GetFiles(searchFilter))
				files.Add(file.Name);
			return files.ToArray();
		}

		internal static string[] GetFilesRecursively(
			string directory)
		{
			return GetFilesRecursively(
				directory,
				"*");
		}

		internal static string[] GetFilesRecursively(
			string directory,
			string filesToIncludeFilter)
		{
			string[] files = new string[0];
			GetFilesRecursively(
				directory,
				filesToIncludeFilter,
				ref files);
			return files;
		}

		internal static void GetFilesRecursively(
			string directory,
			string filesToIncludeFilter,
			ref string[] files)
		{
			var currentDirectory = new DirectoryInfo(directory);

			// Recurse into subdirectories
			foreach (var subDirectory in currentDirectory.GetDirectories())
			{
				GetFilesRecursively(
					Path.Combine(directory, subDirectory.Name),
					filesToIncludeFilter,
					ref files);
			}

			// Collect matching files in this directory
			foreach (var file in currentDirectory.GetFiles(filesToIncludeFilter))
			{
				// Resize array by 1 and add the new file path
				Array.Resize(ref files, files.Length + 1);
				files[files.Length - 1] = Path.Combine(directory, file.Name.ToLower());
			}
		}

		internal static string[] GetFilesWithoutExtension(
			string directory,
			string searchFilter)
		{
			var results = new List<string>();
			string extension = searchFilter.TrimStart('*');

			try
			{
				foreach (var file in Directory.GetFiles(directory, searchFilter))
				{
					string fileName = Path.GetFileName(file);

					// Check if it actually matches the expected extension
					if (string.IsNullOrEmpty(extension) || fileName.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
						results.Add(Path.GetFileNameWithoutExtension(fileName));
				}
			}
			catch
			{
				// Ignore anything
			}
			return results.ToArray();
		}
#endregion

#region File Copying
		internal static bool CopyFileSmart(
			string sourceFileName,
			string destinationFileName)
		{
			return CopyFile(
				sourceFileName,
				destinationFileName,
				true);
		}

		internal static bool CopyFile(
			string sourceFileName,
			string destinationFileName)
		{
			return CopyFile(
				sourceFileName,
				destinationFileName,
				false);
		}

		internal static bool CopyFile(
			string sourceFileName,
			string destinationFileName,
			bool smartCopy)
		{
			if (!File.Exists(sourceFileName))
			{
				if (smartCopy) DeleteFile(destinationFileName, false);
				return false;
			}

			var sourceInfo = new FileInfo(sourceFileName);

			if (smartCopy)
			{
				var destInfo = new FileInfo(destinationFileName);
				if (destInfo.Exists &&
					sourceInfo.CreationTime == destInfo.CreationTime &&
					sourceInfo.LastWriteTime == destInfo.LastWriteTime &&
					sourceInfo.Length == destInfo.Length)
				{
					return true; // No need to copy, files are identical
				}
			}

			// Let the user know what we're copying
			Launcher.Launcher.WriteMessage($"Copying  {sourceFileName}\n     to  {destinationFileName}\n");

			if (!DeleteFile(destinationFileName, false)) return false;

			// Create the folder (we really should check if it exists prior)
			CreateFolder(Path.GetDirectoryName(destinationFileName));

			try
			{
				// Copy the file over
				File.Copy(sourceFileName, destinationFileName);
				if (smartCopy)
				{
					File.SetCreationTime(destinationFileName, sourceInfo.CreationTime);
					File.SetLastWriteTime(destinationFileName, sourceInfo.LastWriteTime);
				}
				return true;
			}
			catch (Exception ex)
			{
				Launcher.Launcher.WriteError($"ERROR: {ex.Message}\n");
				return false;
			}
		}
#endregion

#region File Moving
		internal static bool MoveFile(string sourceFileName, string destinationFileName)
		{
			if (!File.Exists(sourceFileName)) return false;

			// Let user know what we are moving
			Launcher.Launcher.WriteMessage($"Moving   {sourceFileName}\n    to   {destinationFileName}\n");

			if (!DeleteFile(destinationFileName, false)) return false;

			// Create the folder (we really should check if it exists prior)
			CreateFolder(Path.GetDirectoryName(destinationFileName));

			try
			{
				// Move it
				File.Move(sourceFileName, destinationFileName);
				return true;
			}
			// Moving has failed
			catch (Exception ex)
			{
				Launcher.Launcher.WriteError($"ERROR: {ex.Message}\n");
				return false;
			}
		}
#endregion

#region File Deleting
		internal static bool DeleteFile(string fileName)
		{
			return DeleteFile(fileName, true);
		}

		internal static bool DeleteFile(string fileName, bool verbose)
		{
			if (!File.Exists(fileName)) return true;

			// Only tell if verbose is enabled
			if (verbose)
				Launcher.Launcher.WriteMessage($"Deleting {fileName}\n");

			try
			{
				// Set attributes then delete
				File.SetAttributes(fileName, FileAttributes.Normal);
				File.Delete(fileName);
				return true;
			}
			catch (Exception ex)
			{
				// Only tell if verbose is enabled
				if (verbose)
					Launcher.Launcher.WriteError($"ERROR: {ex.Message}\n");
				return false;
			}
		}
		#endregion

#region Text File Saving
		internal static void SaveTextFile(
			string textFile,
			string[] text)
		{
			CreateFolder(Path.GetDirectoryName(textFile));

			using (var writer = new StreamWriter(textFile))
			{
				foreach (string str in text)
					writer.WriteLine(str);
			}
		}
		#endregion

#region Text File Loading
		internal static string[] LoadTextFile(
			string textFile)
		{
			return LoadTextFile(
				textFile,
				null);
		}

		internal static string[] LoadTextFile(
			string textFile,
			string skipCommentLinesStartingWith)
		{
			var lines = new List<string>();

			try
			{
				using (var reader = new StreamReader(textFile))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						line = line.Trim();
						if (line != "" && (skipCommentLinesStartingWith == null || 
							!line.StartsWith(skipCommentLinesStartingWith)))
						{
							lines.Add(line);
						}
					}
				}
			}
			catch
			{
				// Ignore anything
			}
			return lines.ToArray();
		}
		#endregion

#region File Tree
		internal static void AddFilesToTreeView(
			string directory,
			TreeNodeCollection tree,
			bool firstTime)
		{
			TreeNode currentNode = null;

			// If not the first level, add a directory node
			if (!firstTime)
			{
				currentNode = tree.Add(new DirectoryInfo(directory).Name);
				tree = currentNode.Nodes;
			}

			// Recursively add subdirectories
			foreach (var subDir in new DirectoryInfo(directory).GetDirectories())
			{
				AddFilesToTreeView(
					Path.Combine(directory, subDir.Name),
					tree,
					false);
			}

			// Add files, excluding certain extensions
			foreach (var file in new DirectoryInfo(directory).GetFiles())
			{
				string ext = file.Extension.ToLower();
				if (ext != ".ff" && ext != ".iwd" && ext != ".files")
				{
					var fileNode = tree.Add(file.Name);
					fileNode.ForeColor = Color.Blue;
					fileNode.Tag = file;
				}
			}

			// Handle empty directories
			if (currentNode != null)
			{
				if (currentNode.Nodes.Count > 0) currentNode.ExpandAll();
				else currentNode.Remove();
			}
		}
#endregion
	}
}