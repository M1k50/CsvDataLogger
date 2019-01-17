using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvDataLogger
{
    public class CsvTable : ICsvTable
    {
        public CsvTable()
        {
            InitializeTable();

        }

        public DataTable Table { get; private set; }

        public string ReadCell(int row,string column)
        {
            string output = null;

            bool columnExists = Table.Columns.Contains(column);
            bool rowExists = Table.Rows.Contains(row);
            if (columnExists && rowExists)
            {
                output = Table.Rows[row][column].ToString();
            }

            return output;
        }

        public void WriteCell(int row,string column, string entry)
        {
            bool colExists = Table.Columns.Contains(column);
            if (!colExists)
            {
                Table.Columns.Add(column);
            }
            bool rowExists = Table.Rows.Contains(row);
            if (!rowExists)
            {
                Table.Rows.Add(row);
            
            }
            Table.Rows[row][column] = entry;
            
        }

        private void InitializeTable()
        {
            Table = new DataTable();
        }
    }
}

