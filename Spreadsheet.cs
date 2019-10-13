using System;
using System.Linq;
using System.Text;

namespace spreadsheet {
    public class Spreadsheet
    {

        private readonly int rowCount;
        private readonly int columnCount;
        private readonly string[][] data;

        public Spreadsheet(int rowCount, int columnCount){
            this.rowCount = rowCount;
            this.columnCount = columnCount;
            data = Enumerable.Range(0, rowCount)
                .Select(i => 
                    Enumerable.Range(0, columnCount)
                        .Select(j => "")
                        .ToArray()
                    )
                .ToArray();
        }

        public string this[int row, int column]
        {
            get { return data[row][column]; }
            set { data[row][column] = value ?? ""; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var row in data)
            {
                var rowRepresentation = string.Join("|", row);
                sb.AppendLine(rowRepresentation);
            }
            return sb.ToString();
        }

        public string PrettyPrint()
        {
            var columnWidths = ColumnWidths();
            var sb = new StringBuilder();
            for (int i=0; i<rowCount; i++)
            {
                for (int j=0; j<columnCount; j++)
                {
                    sb.Append(data[i][j].PadRight(columnWidths[j]));
                }
                sb.AppendLine("");
            }
            return sb.ToString();
        }

        public int[] ColumnWidths()
        {
            return 
            Enumerable.Range(0, columnCount)
                .Select(j => {
                    return data
                        .Select(row => row.Skip(j)
                                          .Take(1)
                                          .Select(cell => cell.Length)
                                          .First())
                        .Max();
                }).ToArray();
        }
    }
}
