using System;

namespace Chsword.Excel2Object
{

    public class ExcelAttribute : Attribute
    {
        public ExcelAttribute(string title)
        {
            Title = title;
        }

        public int Order { get; set; }
        public string Title { get; set; }
    }
}