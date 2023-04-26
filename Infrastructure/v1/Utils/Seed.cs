using Microsoft.VisualBasic.FileIO;

namespace Infrastructure.v1.Utils
{
    public class Seed
    {
        string pathToCSV = @"C:\Users\SCS\Desktop\IMDB\movies_metadata.csv";

        public void ReadData()
        {
            using (TextFieldParser parser = new TextFieldParser(pathToCSV))
            {
                parser.Delimiters = new string[] { "," };

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    System.Console.WriteLine(fields[0] + " " + fields[1]);
                }
            }
        }
    }
}