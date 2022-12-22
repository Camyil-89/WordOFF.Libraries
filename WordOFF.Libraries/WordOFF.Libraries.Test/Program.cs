

namespace WordOFF.Libraries.Test
{
	public static class Program
	{
		public static void Main(string[] args)
		{

			WOFF.WOFFFile file = WOFF.WOFFFile.Create($"{Directory.GetCurrentDirectory()}\\test1.woff", "test1");


			file.Project.AddFrame(new Project.Frame.WordFrame() { DescriptionTopFrame = "test1", DescriptionBottomFrame = "test1", PathToImage = file.SaveImage(new FileStream("test.png",FileMode.Open))});
			file.Save();
			Console.WriteLine(file.XmlInfo());
			Console.WriteLine("---------------------");
			Console.WriteLine(file.Project);
			Console.WriteLine("---------------------");
			Console.WriteLine(file.XmlProject());
			Console.WriteLine("END");
			Console.Read();
		}
	}

}