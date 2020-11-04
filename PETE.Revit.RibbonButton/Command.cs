#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Dynamo.Core;
using Dynamo.Applications;
using System.Reflection;
#endregion

namespace PETE.Revit.RibbonButton
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            TaskDialog.Show("PETE", "Hello Revit");
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class LinkRedirect : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            Process.Start("http://www.google.com/");
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class KEAHomePage : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            Process.Start("http://www.kea.dk/");
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class BIMCafeLinkedin : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            Process.Start("https://www.linkedin.com/company/kea-bim-cafe/");
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)] 
    public class KEAByg : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            Process.Start("https://kea.dk/en/programmes/bachelor-degree/architectural-technology-and-construction-management");
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class RunDynamo : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            string Dynamo_Journal_Path = @"C:\Users\PeterMihok\AB Clausen\BIM Team - Dynamo Scripts\02 Scripts\02_01 All Scripts\ABC_Elements_SetElevation.dyn";
            DynamoRevit dynamoRevit = new DynamoRevit();

            DynamoRevitCommandData dynamoRevitCommandData = new DynamoRevitCommandData();
            dynamoRevitCommandData.Application = commandData.Application;
            IDictionary<string, string> journalData = new Dictionary<string, string>
            {
                {Dynamo.Applications.JournalKeys.ShowUiKey, false.ToString() }, // don't show DynamoUI at runtime
                {Dynamo.Applications.JournalKeys.AutomationModeKey, true.ToString() }, // run journal automatically
                {Dynamo.Applications.JournalKeys.DynPathKey, Dynamo_Journal_Path }, // run node at this file path
                {Dynamo.Applications.JournalKeys.DynPathExecuteKey, true.ToString() }, // The journal file can specify if the Dynamo workspace opened
                {Dynamo.Applications.JournalKeys.ForceManualRunKey, false.ToString() }, // don't run in manual mode
                {Dynamo.Applications.JournalKeys.ModelShutDownKey, true.ToString() },
                {Dynamo.Applications.JournalKeys.ModelNodesInfo, false.ToString() }
            };

            dynamoRevitCommandData.JournalData = journalData;
            Result externalCommandResult = dynamoRevit.ExecuteCommand(dynamoRevitCommandData);
            return externalCommandResult;
        }
    }
    // public class UIUIDocument OpenAndActivateDocument ()

}
