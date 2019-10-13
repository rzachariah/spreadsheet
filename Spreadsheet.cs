using System.Linq;
using System.Text;

namespace spreadsheet {
    public class Spreadsheet
    {

        private readonly int _rowCount;
        private readonly int _columnCount;
        private readonly string[][] _data;

        public Spreadsheet(int rowCount, int columnCount){
            _rowCount = rowCount;
            _columnCount = columnCount;
            _data = Enumerable.Range(0, rowCount)
                .Select(i => 
                    Enumerable.Range(0, columnCount)
                        .Select(j => "")
                        .ToArray()
                    )
                .ToArray();
        }

        public string this[int row, int column]
        {
            get => _data[row][column];
            set => _data[row][column] = value ?? "";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var row in _data)
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
            for (int i=0; i<_rowCount; i++)
            {
                for (int j=0; j<_columnCount; j++)
                {
                    sb.Append(_data[i][j].PadRight(columnWidths[j]));
                }
                sb.AppendLine("");
            }
            return sb.ToString();
        }

        public int[] ColumnWidths()
        {
            return 
            Enumerable.Range(0, _columnCount)
                .Select(j => {
                    return _data
                        .Select(row => row.Skip(j)
                                          .Take(1)
                                          .Select(cell => cell.Length)
                                          .First())
                        .Max();
                }).ToArray();
        }
    }
}
