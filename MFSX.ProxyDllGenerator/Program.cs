using System;
using System.IO;
using System.Linq;
using PeNet;

namespace MFSX.ProxyDllGenerator {
	class Program {
		static void Main(string[] args) {
			if (args.Length == 0) {
				Console.WriteLine($"Usage: {AppDomain.CurrentDomain.FriendlyName} <dllPath> [outputPath] [projectType]");
				return;
			}

			var dllPath = args[0];
			var outputPath = args.Length > 1 ? args[1] : Directory.GetCurrentDirectory();
			var projectType = ProjectType.VisualStudio;

			if (args.Length > 2 && Enum.TryParse(args[2], true, out ProjectType newProjectType)) {
				projectType = newProjectType;
			}

			if (!File.Exists(dllPath)) {
				Console.WriteLine("Dll path doesn't exist.");
				return;
			}

			var dllName = Path.GetFileName(dllPath);
			var dirName = Path.GetFileNameWithoutExtension(dllName);
			var mainProjectPath = Path.Combine(outputPath, dirName);
			var mainProjectPath2 = Path.Combine(mainProjectPath, dirName);

			string[] paths;
			if (projectType == ProjectType.VisualStudio) {
				paths = [
					Path.Combine(mainProjectPath, $"{dirName}.sln"),
					Path.Combine(mainProjectPath2, $"{dirName}.cpp"),
					Path.Combine(mainProjectPath2, $"{dirName}.def"),
					Path.Combine(mainProjectPath2, "Logger.h"),
					Path.Combine(mainProjectPath2, $"{dirName}.vcxproj"),
				];
			}
			else {
				paths = [
					Path.Combine(mainProjectPath, "CMakeLists.txt"),
					Path.Combine(mainProjectPath, $"{dirName}.cpp"),
					Path.Combine(mainProjectPath, $"{dirName}.def"),
					Path.Combine(mainProjectPath, "Logger.h"),
				];
			}

			var peFile = new PeFile(dllPath);
			if (!peFile.IsDll || peFile.ExportedFunctions == null) {
				Console.WriteLine("It's not a valid dll or has no exported functions.");
				return;
			}

			CreateDirIfNotExists(mainProjectPath);

			if (projectType == ProjectType.VisualStudio) {
				CreateDirIfNotExists(mainProjectPath2);

				var slnFile = Properties.Resources.SlnFile;
				slnFile = slnFile.Replace("#NAME#", dirName);
				File.WriteAllText(paths[0], slnFile);

				var vcxprojFile = Properties.Resources.VcxprojFile;
				vcxprojFile = vcxprojFile.Replace("#NAME#", dirName);
				File.WriteAllText(paths[4], vcxprojFile);
			}
			else {
				var cMake = Properties.Resources.CMakeLists;
				cMake = cMake.Replace("#NAME#", dirName);
				File.WriteAllText(paths[0], cMake);
			}

			var exports = peFile.ExportedFunctions.Where(x => x.HasName).ToArray();

			var i = 0;
			var templateFile = Properties.Resources.TemplateCpp;
			templateFile = templateFile.Replace("#COUNT#", exports.Length.ToString());
			templateFile = templateFile.Replace("#IMPORTS#", string.Join(", ", exports.Select(x => $@"""{x.Name}""")));
			templateFile = templateFile.Replace("#NAME#", dllName);
			templateFile = templateFile.Replace("#EXPORTS#", string.Join("\r\n", exports.Select(x => $@"void {x.Name}_proxy() {{ FUNC({i++}); }}")));

			var defFile = $"LIBRARY {dllName}\r\nEXPORTS\r\n{string.Join("\r\n", exports.Select(x => $"{x.Name}={x.Name}_proxy @{x.Ordinal}"))}";

			File.WriteAllText(paths[1], templateFile);
			File.WriteAllText(paths[2], defFile);
			File.WriteAllText(paths[3], Properties.Resources.Logger);
			Console.WriteLine("Done!");
		}

		static void CreateDirIfNotExists(string path) {
			if (!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
			}
		}
	}

	public enum ProjectType {
		VisualStudio,
		CMake
	}
}
