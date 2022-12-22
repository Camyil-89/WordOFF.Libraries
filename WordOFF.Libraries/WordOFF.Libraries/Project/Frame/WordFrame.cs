using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WordOFF.Libraries.Project.Frame
{
	public enum TypeFrame : int
	{
		/// <summary>
		/// Описание сверху рисунка и снизу подпись
		/// </summary>
		Image = 1,
		/// <summary>
		/// Заголовок и описание снизу с выбором отступа.
		/// </summary>
		Heading = 2,
		/// <summary>
		/// обычный текст
		/// </summary>
		Paragraph = 3,
	}
	public class WordFrame
	{
		#region Type: Description
		/// <summary>Description</summary>
		private TypeFrame _Type = TypeFrame.Image;
		/// <summary>Description</summary>
		public TypeFrame Type { get => _Type; set
			{
				if (!Equals(_Type, value))
				{
					_Type = value;
					IsChange = true;
				}
			}
		}
		#endregion


		public bool CustomContext = false;

		#region Context: режимы форматирования
		/// <summary>режимы форматирования</summary>
		private Context.ContextFrame _Context;
		/// <summary>режимы форматирования</summary>
		public Context.ContextFrame Context { get => _Context; set
			{
				if (!Equals(_Context, value))
				{
					_Context = value;
					IsChange = true;
				}
			}
		}
		#endregion



		#region DescriptionTopFrame: описание сверху картинки или заголовок
		/// <summary>описание сверху картинки или заголовок</summary>
		private string _DescriptionTopFrame;
		/// <summary>описание сверху картинки или заголовок</summary>
		public string DescriptionTopFrame
		{
			get => _DescriptionTopFrame; set
			{
				if (!Equals(_DescriptionTopFrame, value))
				{
					_DescriptionTopFrame = value;
					IsChange = true;
				}
			}
		}
		#endregion


		#region DescriptionBottomFrame: надпись у рисунка или текст ниже заголовка
		/// <summary>надпись у рисунка или текст ниже заголовка</summary>
		private string _DescriptionBottomFrame;
		/// <summary>надпись у рисунка или текст ниже заголовка</summary>
		public string DescriptionBottomFrame { get => _DescriptionBottomFrame; set
			{
				if (!Equals(_DescriptionBottomFrame, value))
				{
					_DescriptionBottomFrame = value;
					IsChange = true;
				}
			}
		}
		#endregion


		#region PathToImage: Description
		/// <summary>Description</summary>
		private string _PathToImage;
		/// <summary>Description</summary>
		public string PathToImage
		{
			get => _PathToImage; set
			{
				if (!Equals(_PathToImage, value))
				{
					_PathToImage = value;
					IsChange = true;
				}
			}
		}
		#endregion

		[XmlIgnore]
		public string UID = Guid.NewGuid().ToString();
		[XmlIgnore]
		public string StyleGUID = null;
		[XmlIgnore]
		public bool IsChange = false;
	}
}
