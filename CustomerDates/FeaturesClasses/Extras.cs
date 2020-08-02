using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace CustomerDates.FeaturesClasses
{
    public class Extras
    {
        List<CheckBox> CheckBoxes = new List<CheckBox>();

        public CheckBox CreateExtra(string Title,string Name)
        {
            CheckBox chkbox = new CheckBox();
            chkbox.Template = (ControlTemplate)Application.Current.FindResource("CheckBoxTemplate");
            chkbox.Content = Title;
            chkbox.Name = Name;
            chkbox.Foreground = Brushes.White;
            CheckBoxes.Add(chkbox);
            return chkbox;
        }
        public string WriteExtras()
        {
            StringBuilder extras = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(new StringWriter(extras));
            writer.WriteStartDocument();
            writer.WriteStartElement("Extras");
            foreach (CheckBox chkbox in CheckBoxes)
            {
                if (chkbox.IsChecked == true)
                {
                    writer.WriteStartElement(chkbox.Name);
                    writer.WriteAttributeString("Availability", chkbox.IsChecked.ToString());
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            return extras.ToString();
        }
        public void ReadExtras(string ExtrasString)
        {
            if (string.IsNullOrEmpty(ExtrasString) == true && string.IsNullOrWhiteSpace(ExtrasString) == true)
            {
                return;
            }
            XmlReader reader = XmlReader.Create(new StringReader(ExtrasString));
            while (reader.Read())
            {
                if (reader.Name != "xml" && reader.Name != "Extras")
                {
                    CheckBox chkbox = CheckBoxes.Find(x => x.Name == reader.Name);
                    if (chkbox is null == false)
                    {
                        if (reader.GetAttribute("Availability") == "True")
                        {
                            chkbox.IsChecked = true;
                        }
                    }
                }
            }
        }
    }
}
