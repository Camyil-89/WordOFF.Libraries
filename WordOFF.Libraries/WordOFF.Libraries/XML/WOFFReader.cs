using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WordOFF.Libraries.XML
{
	public static class WOFFReader
	{
		public static CompressionLevel CompressionLevel = CompressionLevel.SmallestSize;
		public static void CreateWOFF(string path)
		{
			if (File.Exists(path))
				return;
			using (var archive = ZipFile.Open(path, ZipArchiveMode.Create)) { }
		}
		public static void DeleteEntryWOFF(string path_WOFF, string path_in_WOFF)
		{
			using (var archive = ZipFile.Open(path_WOFF, ZipArchiveMode.Update))
			{
				var demoFile = archive.GetEntry(path_in_WOFF);
				if (demoFile != null)
					demoFile.Delete();
			}
		}
		public static MemoryStream GetEntryStreamWOFF(string path_WOFF, string path_in_WOFF)
		{
			MemoryStream memory = new MemoryStream();
			using (var archive = ZipFile.Open(path_WOFF, ZipArchiveMode.Read))
			{
				var demoFile = archive.GetEntry(path_in_WOFF);
				if (demoFile != null)
				{
					demoFile.Open().CopyTo(memory);
					return memory;
				}
			}
			return memory;
		}
		public static void CreateDirectoryWOFF(string path_WOFF, string path_in_WOFF)
		{
			using (var archive = ZipFile.Open(path_WOFF, ZipArchiveMode.Update))
			{
				var demoFile = archive.GetEntry($"{path_in_WOFF}\\");
				if (demoFile == null)
					archive.CreateEntry($"{path_in_WOFF}\\", CompressionLevel);
			}
		}
		public static IEnumerable<ZipArchiveEntry> GetEntriesWOFF(string path_WOFF, string path_in_WOFF)
		{
			using (ZipArchive archive = ZipFile.OpenRead(path_WOFF))
			{
				foreach (ZipArchiveEntry entry in archive.Entries)
				{
					if (entry.FullName.Contains(path_in_WOFF) && entry.FullName != path_in_WOFF)
						yield return entry;
				}
			}
		}
		public static T LoadInWOFF<T>(string path_WOFF, string path_in_WOFF)
		{
			using (var archive = ZipFile.Open(path_WOFF, ZipArchiveMode.Read))
			{
				var file = archive.GetEntry(path_in_WOFF);
				using (var stream = file.Open())
				{
					XmlSerializer xmls = new XmlSerializer(typeof(T));
					var x = (T)xmls.Deserialize(stream);
					return x;
				}
			}
		}
		public static void WriteInWOFF(string path_WOFF, string path_in_WOFF, Stream stream)
		{
			using (var archive = ZipFile.Open(path_WOFF, ZipArchiveMode.Update))
			{
				var demoFile = archive.GetEntry(path_in_WOFF);
				if (demoFile == null)
					demoFile = archive.CreateEntry(path_in_WOFF, CompressionLevel);
				else
				{
					demoFile.Delete();
					demoFile = archive.CreateEntry(path_in_WOFF, CompressionLevel);
				}
				using (var entryStream = demoFile.Open())
					stream.CopyTo(entryStream);
			}
		}
		public static void SaveInWOFF<T>(string path_WOFF, string path_in_WOFF, T obj)
		{
			using (var archive = ZipFile.Open(path_WOFF, ZipArchiveMode.Update))
			{
				var demoFile = archive.GetEntry(path_in_WOFF);
				if (demoFile == null)
					demoFile = archive.CreateEntry(path_in_WOFF, CompressionLevel);
				else
				{
					demoFile.Delete();
					demoFile = archive.CreateEntry(path_in_WOFF, CompressionLevel);
				}
				using (var entryStream = demoFile.Open())
				using (var sw = new StreamWriter(entryStream))
				{
					XmlSerializer xmls = new XmlSerializer(typeof(T));
					xmls.Serialize(sw, obj);
				}
			}
		}
	}
}
