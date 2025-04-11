using Newtonsoft.Json;
using System.Xml;

namespace AzureEnvToAppSettingsConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Azure Environment Variables to appSettings Converter");
            Console.WriteLine("--------------------------------------------------");

            try
            {
                // Get input file path
                Console.Write("Enter path to Azure environment variables JSON file: ");
                string inputPath = Console.ReadLine();

                // Get output file path
                Console.Write("Enter path for output appSettings.config file: ");
                string outputPath = Console.ReadLine();

                // Read and convert
                ConvertAzureEnvToAppSettings(inputPath, outputPath);

                Console.WriteLine("\nConversion completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void ConvertAzureEnvToAppSettings(string inputPath, string outputPath)
        {
            // Validate input file
            if (!File.Exists(inputPath))
            {
                throw new FileNotFoundException("Input file not found.");
            }

            // Read JSON content
            string jsonContent = File.ReadAllText(inputPath);
            var azureSettings = JsonConvert.DeserializeObject<List<AzureEnvironmentVariable>>(jsonContent);

            if (azureSettings == null || azureSettings.Count == 0)
            {
                throw new Exception("No environment variables found in the input file.");
            }

            // Create XML document
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmlDeclaration);

            // Create root element
            XmlElement rootElement = xmlDoc.CreateElement("appSettings");
            xmlDoc.AppendChild(rootElement);

            // Add each setting
            foreach (var setting in azureSettings)
            {
                XmlElement addElement = xmlDoc.CreateElement("add");
                addElement.SetAttribute("key", setting.name);
                addElement.SetAttribute("value", setting.value);
                rootElement.AppendChild(addElement);
            }

            // Save to file
            xmlDoc.Save(outputPath);
        }
    }

    // Class to deserialize Azure environment variables
    public class AzureEnvironmentVariable
    {
        public string name { get; set; }
        public string value { get; set; }
        public bool slotSetting { get; set; }
    }
}