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
        public CsvTable(string indexColumnName = "index")
        {
            _tableIndexName = indexColumnName;
            InitializeTable();
            
        }

        public DataTable Table { get; private set; }
        private string _tableIndexName = "Index";
        public string ReadCell(int index,string column)
        {
            string output = null;

            bool columnExists = Table.Columns.Contains(column);
            bool rowExists = Table.Rows.Contains(index);
            if (columnExists && rowExists)
            {

                string query = queryIndex(index);
                DataRow[] results = Table.Select(query);
                int numberOfRows = results.Count();
                if (numberOfRows > 1) { throw new Exception("Multiple rows with equal index number found. Index must be unique!"); }
                DataRow resultRow = results[0];
                output = resultRow[column].ToString();
            }

            return output;
        }

        public void WriteCell(int index,string column, string entry)
        {
            bool colExists = Table.Columns.Contains(column);
            if (!colExists)
            {
                DataColumn newColumn = new DataColumn();
                newColumn.ColumnName = column;
                newColumn.Caption = column;
                Table.Columns.Add(newColumn);
            }
            bool rowExists = Table.Rows.Contains(index);
            if (!rowExists)
            {
                DataRow newRow = Table.NewRow();
                newRow[_tableIndexName] = index;
                newRow[column] = entry;
                Table.Rows.Add(newRow);
            }
            else
            {
                string searchString = queryIndex(index);
                DataRow[] result = Table.Select(searchString);
                int numRowsFound = result.Count();
                if (numRowsFound >1 )
                {
                    throw new Exception("Multiple entries with equal index found. Index must be unique");
                }
                result[0][column] = entry;

            }
            Table.AcceptChanges();
            
        }

        private string queryIndex(int index)
        {
            return $"{_tableIndexName} = {index}";
        }

        private void InitializeTable()
        {
            string keyColumnName = "key";
            Table = new DataTable()
            {
                //TableName = "CsvTable",
                Columns =
                {
                    //new DataColumn()
                    //{
                    //    ReadOnly = true,
                    //    AutoIncrement=true,
                    //    Unique=true,
                    //    ColumnName=keyColumnName,
                    //    Caption=keyColumnName,
                    //},

                    new DataColumn()
                    {
                        ReadOnly=false,
                        AutoIncrement=false,
                        Unique=true,
                        ColumnName=_tableIndexName,
                        Caption=_tableIndexName
                    }
                },
            };

            DataColumn[] primaryKeyColumn = new DataColumn[1];
            primaryKeyColumn[0]= Table.Columns[_tableIndexName];
            Table.PrimaryKey = primaryKeyColumn;
            
            Table.AcceptChanges();

        }

    }
}

