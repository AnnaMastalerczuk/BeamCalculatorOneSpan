using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeamCalculatorOneSpanApp.Models.BeamInfo;
using CsvHelper;

namespace BeamCalculatorOneSpanApp.Models.Loader
{
    public class FileLoader
    {
        public List<Element> getElementsList()
        {
            string csvPath = @"D:\Ania\Z dysku H\KURS PROGRAMOWANIA\C#\kurs_c#\BeamCalculatorOneSpan\resources\elementsList.csv";
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                var records = csv.GetRecords<Element>().ToList();
                return records;
            }
        }
    }
}
