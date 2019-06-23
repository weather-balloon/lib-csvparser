using System.IO;
using System.Text.RegularExpressions;

using CsvHelper;
using Newtonsoft.Json;

namespace WeatherBalloon.CsvParser
{

    public interface ParseCsvToJson
    {
        string ParseCsvString(string csvString,
                        string delimiter = ",",
                        bool hasHeaderRecord = true);

        string ParseCsvFile(string path,
                        string delimiter = ",",
                        bool hasHeaderRecord = true);

        string ParseCsv(TextReader csvData,
                        string delimiter = ",",
                        bool hasHeaderRecord = true);
    }

    public class CsvParser : ParseCsvToJson
    {

        public string ParseCsv(TextReader csvData,
                        string delimiter = ",",
                        bool hasHeaderRecord = true)
        {
            var csv = new CsvReader(csvData);

            if (hasHeaderRecord)
            {
                csv.Configuration.HasHeaderRecord = true;
            }
            else
            {
                csv.Configuration.HasHeaderRecord = false;
            }

            csv.Configuration.Delimiter = Regex.Unescape(delimiter);

            var jsonResult = csv.GetRecords<dynamic>();

            return JsonConvert.SerializeObject(jsonResult);
        }

        public string ParseCsvString(string csvString,
                        string delimiter = ",",
                        bool hasHeaderRecord = true)
        {
            return this.ParseCsv(
                    csvData: new StringReader(csvString),
                    delimiter: delimiter,
                    hasHeaderRecord: hasHeaderRecord
            );
        }

        public string ParseCsvFile(string path,
                        string delimiter = ",",
                        bool hasHeaderRecord = true)
        {
            return this.ParseCsv(
                    csvData: new StreamReader(path),
                    delimiter: delimiter,
                    hasHeaderRecord: hasHeaderRecord);
        }


    }
}