#region Namespaces
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Dynamo.Core;
using Dynamo.Applications;
using System.Windows;
#endregion

namespace PETE.Revit.RibbonButton
{
    class App : IExternalApplication
    {
        const string tabKEA = "KEA";
        const string tabABC = "AB Clausen";

        const string RIBBON_PANEL1 = "Bim Cafe";
        const string RIBBON_PANEL2 = "Q&A";
        const string RIBBON_PANEL3 = "Dynamo";
        const string RIBBON_PANEL4 = "AB";

        public Result OnStartup(UIControlledApplication a)
        {
            // get the ribbon tab
            try
            {
                a.CreateRibbonTab(tabKEA);
                a.CreateRibbonTab(tabABC);
            }
            catch (Exception) { } // Tab already exists

            // get or create the panel
            RibbonPanel panel1 = null;
            RibbonPanel panel2 = null;
            RibbonPanel panel3 = null;
            RibbonPanel panel4 = null;

            List<RibbonPanel> panelsKEA = a.GetRibbonPanels(tabKEA);
            foreach (RibbonPanel pnl in panelsKEA)
            {
                if (pnl.Name == RIBBON_PANEL1)
                {
                    panel1 = pnl;
                    break;
                }
                else if (pnl.Name == RIBBON_PANEL2)
                {
                    panel2 = pnl;
                    break;
                }
                else if (pnl.Name == RIBBON_PANEL3)
                {
                    panel3 = pnl;
                    break;
                }
                else if (pnl.Name == RIBBON_PANEL4)
                {
                    panel4 = pnl;
                    break;
                }
            }

            List<RibbonPanel> panelsABC = a.GetRibbonPanels(tabABC);
            foreach (RibbonPanel pnls in panelsABC)
            {
                if (pnls.Name == RIBBON_PANEL4)
                {
                    panel4 = pnls;
                    break;
                }
            }

            // couldn't find the panel, create it
            if (panel1 == null)
            {
                panel1 = a.CreateRibbonPanel(tabKEA, RIBBON_PANEL1);
            }
            if (panel2 == null)
            {
                panel2 = a.CreateRibbonPanel(tabKEA, RIBBON_PANEL2);
            }
            if (panel3 == null)
            {
                panel3 = a.CreateRibbonPanel(tabKEA, RIBBON_PANEL3);

            }
            if (panel4 == null)
            {
                panel4 = a.CreateRibbonPanel(tabABC, RIBBON_PANEL4);
            }

            // get the image for the button
            Image img = Properties.Resources.BimLogo;
            ImageSource imgSrc = GetImageSource(img);

            Image img1 = Properties.Resources.QA1;
            ImageSource imgSrc1 = GetImageSource(img1);

            // create the button data
            PushButtonData btnLibrary = new PushButtonData(
                "Library",
                "Library",
                Assembly.GetExecutingAssembly().Location,
                "PETE.Revit.RibbonButton.RunDynamo"
                )
            {
                ToolTip = "KEA BIM Cafe Library",
                LongDescription = "Here you can find all the necessary documents for your studies at KEA",
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PushButtonData btnGoogle = new PushButtonData(
                "Button 2",
                "Button 2",
                Assembly.GetExecutingAssembly().Location,
                "PETE.Revit.RibbonButton.LinkRedirect"
                )
            {
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PushButtonData btnHelloWorld = new PushButtonData(
                "FAQ",
                "FAQ",
                Assembly.GetExecutingAssembly().Location,
                "PETE.Revit.RibbonButton.Command"
                )
            {
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PushButtonData btnHelloWorld1 = new PushButtonData(
              "Teacher",
              "Teacher",
              Assembly.GetExecutingAssembly().Location,
              "PETE.Revit.RibbonButton.Command"
              )
            {
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PushButtonData btnHelloWorld2 = new PushButtonData(
             "Student",
             "Student",
             Assembly.GetExecutingAssembly().Location,
             "PETE.Revit.RibbonButton.Command"
             )
            {
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PushButtonData btnHelloWorld3 = new PushButtonData(
             "A",
             "A",
             Assembly.GetExecutingAssembly().Location,
             "PETE.Revit.RibbonButton.Command"
             )
            {
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PushButtonData btnHelloWorld4 = new PushButtonData(
             "B",
             "B",
             Assembly.GetExecutingAssembly().Location,
             "PETE.Revit.RibbonButton.Command"
             )
            {
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PushButtonData btnHelloWorld5 = new PushButtonData(
             "C",
             "C",
             Assembly.GetExecutingAssembly().Location,
             "PETE.Revit.RibbonButton.Command"
             )
            {
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PushButtonData btnHelloWorld6 = new PushButtonData(
             "D",
             "D",
             Assembly.GetExecutingAssembly().Location,
             "PETE.Revit.RibbonButton.Command"
             )
            {
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PushButtonData btnHelloWorld7 = new PushButtonData(
             "Push",
             "Push",
             Assembly.GetExecutingAssembly().Location,
             "PETE.Revit.RibbonButton.Command"
             )
            {
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PushButtonData btnHelloWorld8 = new PushButtonData(
             "Run",
             "Run",
             Assembly.GetExecutingAssembly().Location,
             "PETE.Revit.RibbonButton.Command"
             )
            {
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PulldownButtonData group1Data = new PulldownButtonData("PulldownGroup1", "Q&A")
            {
                Image = imgSrc,
                LargeImage = imgSrc
            };
            PushButtonData itemData11 = new PushButtonData("itemName11", "About KEA", 
                Assembly.GetExecutingAssembly().Location, "PETE.Revit.RibbonButton.KEAHomePage")
            {
                ToolTip = "KEA BIM Cafe Library",
                LongDescription = "Here you can find all the necessary documents for your studies at KEA",
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PushButtonData itemData12 = new PushButtonData("itemName12", "About BIM Cafe",
                Assembly.GetExecutingAssembly().Location, "PETE.Revit.RibbonButton.BIMCafeLinkedin")
            {
                ToolTip = "KEA BIM Cafe Library",
                LongDescription = "Here you can find all the necessary documents for your studies at KEA",
                Image = imgSrc,
                LargeImage = imgSrc
            };
            PushButtonData itemData13 = new PushButtonData("itemName13", "About BYG", 
                Assembly.GetExecutingAssembly().Location, "PETE.Revit.RibbonButton.KEAByg")
            {
                ToolTip = "KEA BIM Cafe Library",
                LongDescription = "Here you can find all the necessary documents for your studies at KEA",
                Image = imgSrc,
                LargeImage = imgSrc
            };

            PushButtonData group2Data = new PushButtonData(
              "TaskDialog",
              "TaskDialog",
              Assembly.GetExecutingAssembly().Location,
              "PETE.Revit.RibbonButton.Command"
                );


            // add the button to the ribbon
            PushButton button = panel4.AddItem(btnLibrary) as PushButton;
            button.Enabled = true;
            PushButton button1 = panel1.AddItem(btnGoogle) as PushButton;
            button1.Enabled = true;
            PushButton button3 = panel1.AddItem(btnHelloWorld) as PushButton;
            button3.Enabled = true;
            PushButton button4 = panel2.AddItem(btnHelloWorld1) as PushButton;
            button4.Enabled = true;
            PushButton button5 = panel2.AddItem(btnHelloWorld2) as PushButton;
            button5.Enabled = true;
            PushButton button6 = panel2.AddItem(btnHelloWorld3) as PushButton;
            button6.Enabled = true;
            PushButton button7 = panel2.AddItem(btnHelloWorld4) as PushButton;
            button7.Enabled = true;
            PushButton button8 = panel3.AddItem(btnHelloWorld5) as PushButton;
            button8.Enabled = true;
            PushButton button9 = panel3.AddItem(btnHelloWorld6) as PushButton;
            button9.Enabled = true;
            PushButton button10 = panel3.AddItem(btnHelloWorld7) as PushButton;
            button10.Enabled = true;
            PushButton button11 = panel3.AddItem(btnHelloWorld8) as PushButton;
            button11.Enabled = true;

            PulldownButton group1 = panel1.AddItem(group1Data) as PulldownButton;
            PushButton item11 = group1.AddPushButton(itemData11) as PushButton;
            item11.ToolTip = itemData11.Text; // Can be changed to a more descriptive text.
            PushButton item12 = group1.AddPushButton(itemData12) as PushButton;
            item12.ToolTip = itemData12.Text;
            PushButton item13 = group1.AddPushButton(itemData13) as PushButton;
            item13.ToolTip = itemData13.Text;

            //PushButton group2 = panel4.AddItem(group2Data) as PushButton;
            //PushButton item17 = group1.AddPushButton(group2Data) as PushButton;
            //item17.ToolTip = group2Data.Text;  // Can be changed to a more descriptive text

            

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }


        private BitmapSource GetImageSource(Image img)
        {
            BitmapImage bmp = new BitmapImage();

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                ms.Position = 0;

                bmp.BeginInit();

                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.UriSource = null;
                bmp.StreamSource = ms;

                bmp.EndInit();
            }

            return bmp;
        }
    }
}


/*

 */