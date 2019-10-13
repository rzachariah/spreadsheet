using System;

namespace spreadsheet
{
    static class Program
    {
        static void Main()
        {
            var sheet = new Spreadsheet(4, 3);
            sheet[0,0] = "Apple";
            sheet[0,1] = "1";
            sheet[0,2] = "Tom";
            sheet[1,0] = "Apricot";
            sheet[1,1] = "Matthew";
            sheet[1,2] = "Dave";
            sheet[3,0] = "Zachariah";
            sheet[3,2] = "Boss";

            Console.WriteLine(sheet);
            Console.WriteLine(sheet.PrettyPrint());
            Console.WriteLine(string.Join(",", sheet.ColumnWidths()));
 
        }
    }
}
