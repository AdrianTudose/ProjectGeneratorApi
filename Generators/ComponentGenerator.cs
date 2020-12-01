

using System.Xml.Linq;
using System;
using System.IO;
using System.Text;
using ProjectGeneratorApi.Models.Component;
using System.Collections.Generic;

namespace ProjectGeneratorApi.Generators
{
    public class ComponentGenerator
    {
        private string css = "";
        public ComponentGenerator(VueComponent component, string test)
        {
            writeToFile(test, "test");
            string fileContent = generateVueComponent(component) + "<style scoped>\n" + css + "</style>";
            writeToFile(fileContent, component.name);
        }

        private string generateVueComponent(VueComponent comp)
        {
            return new XElement("template", recursiveGenerateVueComponent(comp.tree)).ToString();
        }

        private XElement[] recursiveGenerateVueComponent(TreeElement comp)
        {
            List<XElement> children = new List<XElement>();
            if (comp.style.Count > 0)
                css += generateCssClass(comp.id, comp.style);
            foreach (TreeElement child in comp.children)
            {
                XElement e = new XElement(child.index, recursiveGenerateVueComponent(child));
                e.Add(new XAttribute("id", child.id));
                children.Add(e);
            }
            return children.ToArray();
        }

        string generateCssClass(string id, Dictionary<string, string> style)
        {
            string text = "." + id + "{\n";
            foreach (var item in style)
            {
                text += "\t" + item.Key + " : " + item.Value + ";\n";
            }
            return text + "}\n";
        }

        void writeToFile(string fileContent, string filename)
        {
            string fileName = @"D:\VueWebMaker\TEMPORARYGenerationFolder\" + filename + ".vue";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file    
                    Byte[] byteContent = new UTF8Encoding(true).GetBytes(fileContent);
                    fs.Write(byteContent, 0, byteContent.Length);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}