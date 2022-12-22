using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WordOFF.Libraries.Project;
using WordOFF.Libraries.Project.Frame;

namespace WordOFF.Libraries.WOFF
{
	public class WOFFFile
	{
		public WOFFFile(string PathToWOFFFile)
		{
			if (!File.Exists(PathToWOFFFile))
				throw new System.IO.FileNotFoundException("WOFF file not find!");
			Path = PathToWOFFFile;

			List<string> images = new List<string>();
			foreach (var i in Project.Frames)
				if (i.Type == TypeFrame.Image)
					images.Add(i.PathToImage);
			List<string> delete = new List<string>();
			foreach (var i in XML.WOFFReader.GetEntriesWOFF(Path, "images\\"))
				if (images.Contains(i.FullName))
					ListImages.Add(i.FullName);
				else
					delete.Add(i.FullName);
			foreach (var i in delete)
				DeleteImage(i);

		}

		private InfoAboutWOFFFile _Info = null;

		public InfoAboutWOFFFile Info
		{
			get
			{
				if (_Info is null)
				{
					_Info = XML.WOFFReader.LoadInWOFF<InfoAboutWOFFFile>(Path, PathsWOFF.InfoFile);
				}
				return _Info;
			}
			set => _Info = value;
		}

		private Project.Project _Project;
		public Project.Project Project
		{
			get
			{
				if (_Project is null)
					_Project = XML.WOFFReader.LoadInWOFF<Project.Project>(Path, PathsWOFF.ProjectFile);

				return _Project;
			}
			set => _Project = value;
		}

		public Version Version { get; } = Assembly.GetEntryAssembly().GetName().Version;
		public string Path { get; }
		

		private List<string> _ListImages = new List<string>();

		public List<string> ListImages { get { return _ListImages; } }

		public string XmlInfo()
		{
			return Encoding.UTF8.GetString(XML.WOFFReader.GetEntryStreamWOFF(Path, PathsWOFF.InfoFile).ToArray());
		}
		public string XmlProject()
		{
			return Encoding.UTF8.GetString(XML.WOFFReader.GetEntryStreamWOFF(Path, PathsWOFF.ProjectFile).ToArray());
		}
		public void Save()
		{
			XML.WOFFReader.SaveInWOFF(Path, PathsWOFF.ProjectFile, Project);
			XML.WOFFReader.SaveInWOFF(Path, PathsWOFF.InfoFile, Info);
		}
		public void DeleteImage(string path)
		{
			ListImages.Remove(path);
			XML.WOFFReader.DeleteEntryWOFF(Path, path);
		}
		public bool ExistsImage(string path)
		{
			return ListImages.Contains(path);
		}
		public void ExtractImage(string path, string path_to)
		{
			var memory = XML.WOFFReader.GetEntryStreamWOFF(Path, path);
			File.WriteAllBytes(path_to, memory.ToArray());
		}
		public MemoryStream GetMemoryStreamEntry(string path)
		{
			var x = XML.WOFFReader.GetEntryStreamWOFF(Path, path);
			x.Position = 0;
			return x;
		}
		public string SaveImage(Stream stream)
		{
			List<string> files = new List<string>();
			XML.WOFFReader.CreateDirectoryWOFF(Path, "images");
			foreach (var i in XML.WOFFReader.GetEntriesWOFF(Path, "images\\"))
				files.Add(i.FullName);
			Random random = new Random();
			string name = "";
			while (true)
			{
				name = $"images\\{random.Next(1000000, 10000000)}.jpg";
				if (!files.Contains(name))
					break;
			}
			ListImages.Add(name);
			XML.WOFFReader.WriteInWOFF(Path, name, stream);
			return name;
		}


		public static WOFFFile Create(string Path, string Name)
		{
			XML.WOFFReader.CreateWOFF(Path);
			XML.WOFFReader.SaveInWOFF(Path, PathsWOFF.InfoFile, new InfoAboutWOFFFile() { WOFFName = Name});
			XML.WOFFReader.SaveInWOFF(Path, PathsWOFF.ProjectFile, new Project.Project());
			return new WOFFFile(Path);
		}
	}
}
