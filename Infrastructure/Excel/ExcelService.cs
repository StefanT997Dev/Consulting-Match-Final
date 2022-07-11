using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Excel
{
    public static class ExcelService
    {
        public static void Read()
        {
            using (var stream = File.Open("test.xlsx", FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            reader.GetString(0);
                        }
                    } while (reader.NextResult());

                    var result = reader.AsDataSet();
                }
            }
        }
    }
}
