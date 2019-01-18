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
        private string _tableKeyName = "Key";
        private string _tableIndexName = "Index";
        public string ReadCell(int index,string column)
        {
            string output = null;

            bool columnExists = Table.Columns.Contains(column);
            bool rowExists = Table.Rows.Contains(index);
            if (columnExists && rowExists)
            {

                string query = $"{_tableIndexName} = {index}";
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
                Table.Rows[index][column] = entry;
            }
            Table.AcceptChanges();
            
        }

        private void InitializeTable()
        {
            string primKeyColTitle = _tableKeyName;
            Table = new DataTable()
            {
                TableName = "CsvTable",
                Columns =
                {
                    //new DataColumn()
                    //{
                    //    ReadOnly = true,
                    //    AutoIncrement=true,
                    //    Unique=true,
                    //    ColumnName=_tableKeyName,
                    //    Caption=_tableKeyName,
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

