using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WordOFF.Libraries.Project.Frame;
using static System.Net.Mime.MediaTypeNames;

namespace WordOFF.Libraries.Project
{
	public enum TypeProject : int
	{
		[Description("Устаревший")]
		ImageProject = 1,
		[Description("Фрейм")]
		FrameProject = 2,
	}
	public class Project
	{
		private TypeProject _TypeProject = TypeProject.FrameProject;
		/// <summary>
		/// Тип проекта
		/// </summary>
		public TypeProject TypeProject { get { return _TypeProject; } }


		public DateFormatReplace DateFormatReplace = new DateFormatReplace();

		/// <summary>
		/// Имя работы (Отчет по [Title])
		/// </summary>
		public string Title;
		/// <summary>
		/// Список фреймов
		/// </summary>

		public ObservableCollection<Frame.WordFrame> Frames = new ObservableCollection<Frame.WordFrame>();

		[XmlIgnore]
		/// путь до папки с отчетом
		public string PathToProject = "";
		[XmlIgnore]
		public bool Changes = false;

		/// <summary>
		/// Получение даты в определенном формате
		/// </summary>
		/// <returns></returns>
		public string GetDate()
		{
			DateTime date = DateTime.Now;
			if (DateFormatReplace.CustomDate)
				date = DateFormatReplace.Date;
			switch (DateFormatReplace.DateFormat)
			{
				case DateFormat.Long:
					return date.ToString("D", DateFormatReplace.Culture);
				case DateFormat.Short:
					return date.ToString("d", DateFormatReplace.Culture);
				default:
					return "";
			}
		}
		public void MoveFrame(int _old, int _new)
		{
			Changes = true;
			Frames.Move(_old, _new);
		}
		public void AddFrame(int position, WordFrame frame)
		{
			Changes = true;
			Frames.Insert(position, frame);
		}
		public void AddFrame(WordFrame frame)
		{
			Changes = true;
			Frames.Add(frame);
		}
		public void DeleteFrame(WordFrame frame)
		{
			Changes = true;
			Frames.Remove(frame);
		}
		public void AddImage(string path, string description, string image_description, Frame.Context.ContextFrame context)
		{
			Changes = true;
			Frames.Add(new WordFrame()
			{
				DescriptionTopFrame = description,
				DescriptionBottomFrame = image_description,
				PathToImage = path,
				Type = TypeFrame.Image,
				Context = context
			});
		}
	}
}
