using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_8_1
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;

            var ifcOption = new IFCExportOptions();
            using (var ts = new Transaction(doc, "Экспорт IFC"))
            {
                ts.Start();
                doc.Export(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Export.ifc", ifcOption);
                ts.Commit();
            }
            return Result.Succeeded;
        }
    }
}
