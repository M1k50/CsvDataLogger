using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelper;

namespace CsvDataLogger
{
    class Factory
    {
        public IFileHelper NewFileHelper()
        {
            return new IFileHelper();
        }
    }
}
