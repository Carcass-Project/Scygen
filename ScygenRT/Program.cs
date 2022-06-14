using System;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ScygenRT
{
    internal class Program
    {
        static void CreateProject(string name)
        {
            if(name == null)
            {
                throw new Exception("The project name is null/invalid.");
            }
         
            Directory.CreateDirectory(name);

            var writer = new XmlTextWriter($"{name}"+"/"+$"{name}.scyproj", System.Text.Encoding.ASCII);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();
            writer.WriteStartElement("Project");
            writer.WriteElementString("StartFile", "kernel.cpp");
            writer.WriteElementString("Launch", "qemu");
            writer.WriteElementString("OutputType", "iso");
            writer.WriteElementString("CPPVersion", "17");
            writer.WriteEndElement();

            writer.Close();
        }

        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Run 'ScygenRT new <ProjectName>' to create a new Scygen project.\nRun 'ScygenRT build <ProjectName>' to build your Scygen project into an ISO file.");
            }

            if(args[0] == "new")
            {
                if(args.Length > 1)
                {
                    CreateProject(args[1]);
                }
                else
                {
                    Console.WriteLine("Unspecified Project Name.");
                }
            }
        }
    }
}
