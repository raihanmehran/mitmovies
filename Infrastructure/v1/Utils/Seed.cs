using Microsoft.VisualBasic.FileIO;

namespace Infrastructure.v1.Utils
{
    public static class Seed
    {
        public static void ReadData()
        {
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\SCS\Desktop\IMDB\movies_metadata.csv"))
            {
                string[] fields;
                parser.Delimiters = new string[] { "," };
                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    System.Console.WriteLine(fields[0] + " " + fields[1]);
                }
            }
        }
    }
}