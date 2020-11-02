using ObjectLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

namespace CustomerDates.FeaturesClasses
{
    class Softwares
    {
        public List<Grid> Parents = new List<Grid>();
        public List<Grid> Infogrids = new List<Grid>();
        public List<CheckBox> chkboxes = new List<CheckBox>();
        public List<TextBox> Descriptions = new List<TextBox>();
        public List<TextBox> Prices = new List<TextBox>();
        public List<Ellipse> Statuses = new List<Ellipse>();

        public Grid CreateSoftware(string PartTitle, string PartName)
        {
            Grid parent = new Grid();
            parent.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(140, GridUnitType.Pixel) });
            parent.ColumnDefinitions.Add(new ColumnDefinition());
            parent.Tag = PartName;
            parent.Height = 30.0;
            Parents.Add(parent);

            CheckBox chkbox = new CheckBox();
            chkbox.Name = PartName;
            Grid.SetColumn(chkbox, 0);
            chkbox.Content = PartTitle;
            chkbox.Template = (ControlTemplate)Application.Current.FindResource("CheckBoxTemplate");
            chkbox.HorizontalAlignment = HorizontalAlignment.Left;
            chkbox.VerticalAlignment = VerticalAlignment.Center;
            chkbox.Foreground = Brushes.White;
            chkbox.Margin = new Thickness(5, 0, 0, 0);
            parent.Children.Add(chkbox);
            chkbox.Checked += DeviceTechnics_Checked;
            chkbox.Unchecked += DeviceTechnics_Unchecked;
            chkboxes.Add(chkbox);

            Grid infogrid = new Grid();
            infogrid.Name = PartName + "Grid";
            infogrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(430, GridUnitType.Pixel) });
            infogrid.ColumnDefinitions.Add(new ColumnDefinition());
            infogrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });
            infogrid.IsEnabled = false;
            Grid.SetColumn(infogrid, 1);
            parent.Children.Add(infogrid);
            Infogrids.Add(infogrid);

            TextBox Description = new TextBox();
            Description.Name = PartName + "Description";
            Grid.SetColumn(Description, 0);
            Description.VerticalAlignment = VerticalAlignment.Center;
            Description.Template = (ControlTemplate)Application.Current.FindResource("TextBoxTemplate");
            Description.CaretBrush = Brushes.White;
            Description.Foreground = Brushes.White;
            Description.Margin = new Thickness(5, 0, 10, 0);
            Description.Padding = new Thickness(0, 0, 0, 3);
            infogrid.Children.Add(Description);
            Descriptions.Add(Description);

            TextBox Price = new TextBox();
            Price.Name = PartName + "Price";
            Grid.SetColumn(Price, 1);
            Price.VerticalAlignment = VerticalAlignment.Center;
            Price.Template = (ControlTemplate)Application.Current.FindResource("TextBoxTemplate");
            Price.CaretBrush = Brushes.White;
            Price.Foreground = Brushes.White;
            Price.Padding = new Thickness(0, 0, 0, 3);
            infogrid.Children.Add(Price);
            Prices.Add(Price);

            Ellipse Status = new Ellipse();
            Status.Name = PartName + "Status";
            Grid.SetColumn(Status, 2);
            Status.VerticalAlignment = VerticalAlignment.Center;
            Status.HorizontalAlignment = HorizontalAlignment.Center;
            Status.Width = 20;
            Status.Height = 20;
            Status.Fill = Brushes.White;
            Status.MouseLeftButtonDown += StatusEllipse_MouseLeftButtonDown;
            infogrid.Children.Add(Status);
            Statuses.Add(Status);



            return parent;
        }
        private void DeviceTechnics_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox Controller = ((CheckBox)sender);
            Grid infogrd = Infogrids.Find(x => x.Name == Controller.Name + "Grid");
            infogrd.IsEnabled = true;


        }
        private void DeviceTechnics_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox Controller = ((CheckBox)sender);
            Grid gridcontrol = Infogrids.Find(x => x.Name == Controller.Name + "Grid");
            TextBox description = Descriptions.Find(x => x.Name == Controller.Name + "Description");
            TextBox price = Prices.Find(x => x.Name == Controller.Name + "Price");
            Ellipse status = Statuses.Find(x => x.Name == Controller.Name + "Status");
            if (gridcontrol != null)
            {
                description.Text = "";
                price.Text = "";
                status.Fill = Brushes.White;
                gridcontrol.IsEnabled = false;
            }
        }
        private void StatusEllipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse controller = ((Ellipse)sender);

            if (controller.Fill == Brushes.Red || controller.Fill == Brushes.White)
            {
                controller.Fill = Brushes.Yellow;
                controller.Tag = "Repairing";
                return;
            }
            if (controller.Fill == Brushes.Yellow)
            {
                controller.Fill = Brushes.Lime;
                controller.Tag = "Completed";
                return;
            }
            if (controller.Fill == Brushes.Lime)
            {
                controller.Fill = Brushes.Red;
                TextBox prc = Prices.Find(x => x.Name == controller.Name + "Price");
                prc.Text = "0";
                controller.Tag = "Failed";
                return;
            }
        }
        public string WriteSoftwaresXml()
        {
            StringBuilder softwarexml = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(new StringWriter(softwarexml));
            writer.WriteStartDocument();
            writer.WriteStartElement("Softwares");
            int index = 0;
            while (index < chkboxes.Count)
            {

                if (chkboxes[index].IsChecked == true)
                {
                    CheckBox chkbox = chkboxes[index];
                    writer.WriteStartElement(chkbox.Name);
                    writer.WriteAttributeString("Availability", chkbox.IsChecked.ToString());
                    TextBox description = Descriptions.Find(x => x.Name == chkbox.Name + "Description");
                    writer.WriteAttributeString("Description", description.Text);
                    TextBox price = Prices.Find(x => x.Name == chkbox.Name + "Price");
                    writer.WriteAttributeString("Price", price.Text);
                    Ellipse ellipse = Statuses.Find(x => x.Name == chkbox.Name + "Status");
                    writer.WriteAttributeString("Status", ellipse.Tag.ToString());
                    writer.WriteEndElement();

                }
                else
                {
                    writer.WriteStartElement(chkboxes[index].Name);
                    writer.WriteAttributeString("Availability", chkboxes[index].IsChecked.ToString());
                    writer.WriteEndElement();
                }
                index++;
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
            return softwarexml.ToString();
        }
        public void ReadSoftwaresXml(string softwares)
        {
            if (string.IsNullOrEmpty(softwares) == true && string.IsNullOrWhiteSpace(softwares) == true)
            {
                return;
            }
            XmlReader reader = XmlReader.Create(new StringReader(softwares));
            while (reader.Read())
            {
                CheckBox chkbox = null;
                if (reader.Name != "xml" && reader.Name != "Softwares")
                {
                    chkbox = chkboxes.Find(x => x.Name == reader.Name);
                    chkbox.IsChecked = Convert.ToBoolean(reader.GetAttribute("Availability"));
                    if (chkbox.IsChecked == true)
                    {
                        TextBox description = Descriptions.Find(x => x.Name == chkbox.Name + "Description");
                        description.Text = reader.GetAttribute("Description");

                        TextBox price = Prices.Find(x => x.Name == chkbox.Name + "Price");
                        price.Text = reader.GetAttribute("Price");

                        Ellipse status = Statuses.Find(x => x.Name == chkbox.Name + "Status");
                        if (reader.GetAttribute("Status") == "Repairing")
                        {
                            status.Fill = Brushes.Yellow;
                            status.Tag = "Repairing";
                        }
                        if (reader.GetAttribute("Status") == "Completed")
                        {
                            status.Fill = Brushes.Lime;
                            status.Tag = "Completed";
                        }
                        if (reader.GetAttribute("Status") == "Failed")
                        {
                            status.Fill = Brushes.Red;
                            status.Tag = "Failed";
                            price.Text = "0";
                        }
                    }
                }
            }
        }
        public void ResetELementsValues()
        {
            foreach (var item in Infogrids)
            {
                item.IsEnabled = false;
            }

            foreach (var item in chkboxes)
            {
                item.IsChecked = false;
            }

            foreach (var item in Descriptions)
            {
                item.Text = "";
            }

            foreach (var item in Prices)
            {
                item.Text = "";
            }

            foreach (var item in Statuses)
            {
                item.Fill = Brushes.White;
            }

        }



    }
}
