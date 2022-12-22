using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordOFF.Libraries.Project.Frame.Context
{
	public enum ContextType : int
	{
		Paragraph = 3,
		ImageParagraph = 1,
		Header = 2,
	}

	public class ContextFrame
	{
		public ContextImageParagraph ContextImageParagraph;

		public ContextParagraph ContextParagraph;

		public ContextHeader ContextHeader;

	}
	public enum HeaderTopTextPositionFormat : int
	{
		[Description("По левому краю")]
		Left = 1,
		[Description("По центру")]
		Center = 2,
		[Description("По правому краю")]
		Right = 3,
	}
	public class ContextHeader
	{
		public ContextParagraph ContextParagraph;

		public HeaderTopTextPositionFormat TopTextPosition;

		public HeadingTypeWordOFF HeadingType = HeadingTypeWordOFF.Heading1;

		public double FontSizeHeading;
	}
	public enum HeadingTypeWordOFF
	{
		[Description("Заголовок 1 уровня")]
		Heading1,
		[Description("Заголовок 2 уровня")]
		Heading2,
		[Description("Заголовок 3 уровня")]
		Heading3,
		[Description("Заголовок 4 уровня")]
		Heading4,
		[Description("Заголовок 5 уровня")]
		Heading5,
		[Description("Заголовок 6 уровня")]
		Heading6,
		[Description("Заголовок 7 уровня")]
		Heading7,
		[Description("Заголовок 8 уровня")]
		Heading8,
		[Description("Заголовок 9 уровня")]
		Heading9,
	}
	public enum ParagraphFormat : int
	{
		[Description("Без стиля")]
		None = 0,
		[Description("Табуляция")]
		Tabulation = 1,
		[Description("Нумерованный список")]
		List = 2,
		[Description("Настраиваемый отступ")]
		RedLine = 3,
	}
	public class ContextParagraph
	{
		public ParagraphFormat TypeFormat;

		public int CountCharRedLine;

		public short ListLevel;

		public bool UseTabulationOnList;

		public int FontSize;
	}
	public class ContextImageParagraph
	{
		public ContextParagraph ContextParagraph;

		public string CaptionBottom = "Рисунок";

		public int FontSizeImage = 11;
	}
}
