using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvDataLogger
{
    class CsvTable
    {
        public CsvTable()
        {
            InitializeTable();

        }

        public CsvTable(List<DataColumn> columns)
        {

        }

        public DataTable _table { get; private set; }
        public void AddColumn(string columnName)
        {
            _table.Columns.Add(columnName);
        }

        public void WriteCell(string column, int row, string entry)
        {
            try
            {
                //_table.Columns[i]
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void InitializeTable()
        {
            _table = new DataTable();
        }
    }
}
