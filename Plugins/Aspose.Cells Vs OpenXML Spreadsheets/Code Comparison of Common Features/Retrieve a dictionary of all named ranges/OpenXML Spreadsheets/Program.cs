﻿using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXML_Spreadsheets
{
    class Program
    {
        static void Main(string[] args)
        {
            string strDoc = @"E:\Aspose\Aspose Vs OpenXML\Aspose.Cells Vs OpenXML Spreadsheet v 1.1\SampleFiles\Retrieve a dictionary of all named ranges.xlsx";
            Dictionary<String, String> ranges = GetDefinedNames(strDoc);
        }
        public static Dictionary<String, String> GetDefinedNames(String fileName)
        {
            // Given a workbook name, return a dictionary of defined names.
            // The pairs include the range name and a string representing the range.
            var returnValue = new Dictionary<String, String>();

            // Open the spreadsheet document for read-only access.
            using (SpreadsheetDocument document =
                SpreadsheetDocument.Open(fileName, false))
            {
                // Retrieve a reference to the workbook part.
                var wbPart = document.WorkbookPart;

                // Retrieve a reference to the defined names collection.
                DefinedNames definedNames = wbPart.Workbook.DefinedNames;

                // If there are defined names, add them to the dictionary.
                if (definedNames != null)
                {
                    foreach (DefinedName dn in definedNames)
                        returnValue.Add(dn.Name.Value, dn.Text);
                }
            }
            return returnValue;
        }
    }
}
