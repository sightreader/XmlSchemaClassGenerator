using XmlSchemaClassGenerator;
using System;
using System.Collections.Generic;

namespace ExampleProgram
{
    static class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator
            {
                OutputFolder = "output",
                Log = s => Console.WriteLine(s),
                GenerateNullables = false,
                PrivateMemberPrefix = "",
                NamespaceProvider = new Dictionary<NamespaceKey, string>
                {
                    { new NamespaceKey("http://wadl.dev.java.net/2009/02"), "MusicXmlSchema" }
                }
                .ToNamespaceProvider(new GeneratorConfiguration { NamespacePrefix = "MusicXmlSchema" }.NamespaceProvider.GenerateNamespace)
            };

            try
            {
                generator.Generate(new string[] { "musicxml.xsd" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
        }
    }
}
