﻿/*******************************************************************************
 * You may amend and distribute as you like, but don't remove this header!
 * 
 * All rights reserved.
 * 
 * EPPlus is an Open Source project provided under the 
 * GNU General Public License (GPL) as published by the 
 * Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
 * 
 * EPPlus provides server-side generation of Excel 2007 spreadsheets.
 * See https://github.com/JanKallman/EPPlus for details.
 *
 *
 * 
 * The GNU General Public License can be viewed at http://www.opensource.org/licenses/gpl-license.php
 * If you unfamiliar with this license or have questions about it, here is an http://www.gnu.org/licenses/gpl-faq.html
 * 
 * The code for this project may be used and redistributed by any means PROVIDING it is 
 * not sold for profit without the author's written consent, and providing that this notice 
 * and the author's name and all copyright notices remain intact.
 * 
 * All code and executables are provided "as is" with no warranty either express or implied. 
 * The author accepts no liability for any damage or loss of business that this product may cause.
 *
 *
 * Code change notes:
 * 
 * Author							Change						Date
 *******************************************************************************
 * Jan Källman		Added		10-SEP-2009
 *******************************************************************************/
using System;
using System.Diagnostics;
using System.IO;
using OfficeOpenXml;

namespace EPPlusSamples
{
	class Sample_Main
	{
        static void Test()
        {
            Console.WriteLine("Running sample 4");
            var sample17Path = Sample17.RunSample17(new FileInfo(@"C:\Users\mohammad\Documents\Projects\DMS2\codes\backend\Infrastructure\XLSConverter\bin\Debug\132264854811994556.xlsx"));      //Template path from /bin/debug or /bin/release
            Console.WriteLine("Sample 17 created: {0}", sample17Path);
            Console.WriteLine();
        }
		static void Main(string[] args)
		{
            
			try
			{
                Utils.OutputDir = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}SampleApp");
                Test();
                return;
                //Sample 3, 4 and 12 uses the Adventureworks database. Enter the connectionstring to the Adventureworks database(2016 CTP3) into the variable below...
                //Leave this blank if you don't have access to the Adventureworks database 
                string connectionStr = "";      //for example "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AdventureWorks2016CTP3;Data Source=MySqlServer"

                //Set the output directory to the SampleApp folder where the app is running from. 
                Utils.OutputDir = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}SampleApp");

                // Sample 1 - simply creates a new workbook from scratch
                // containing a worksheet that adds a few numbers together 
                Console.WriteLine("Running sample 1");
                string sample1Path = Sample1.RunSample1();
                Console.WriteLine("Sample 1 created: {0}", sample1Path);
                Console.WriteLine();

                // Sample 2 - simply reads some values from the file generated by sample 1
                // and outputs them to the console
                Console.WriteLine("Running sample 2");
                Sample2.RunSample2(sample1Path);
                Console.WriteLine();

                if (connectionStr != "")
                {
                    // Sample 3 - creates a workbook from scratch 
                    // This is the same sample as the original Excelpackage, sample 4, but without the template
                    // This sample requires the AdventureWorks database.  
                    //Shows how to use Ranges, Styling, Namedstyles and Hyperlinks
                    Console.WriteLine("Running sample 3");
                    var sample3Path = Sample3.RunSample3(connectionStr);
                    Console.WriteLine("Sample 3 created: {0}", sample3Path);
                    Console.WriteLine();

                    // Sample 4 - creates a workbook based on a template.
                    // Populates a range with data and set the series of a linechart.
                    // This sample requires the AdventureWorks database.  
                    Console.WriteLine("Running sample 4");
                    var sample4Path = Sample4.RunSample4(connectionStr, new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}GraphTemplate.xlsx"));      //Template path from /bin/debug or /bin/release
                    Console.WriteLine("Sample 4 created: {0}", sample4Path);
                    Console.WriteLine();
                }

                //Sample 5
                //Open sample 1 and add a pie chart.
                Console.WriteLine("Running sample 5");
                var output = Sample5.RunSample5();
                Console.WriteLine("Sample 5 created:", output);
                Console.WriteLine();

                //Sample 6
                //Creates an advanced report on a directory in the filesystem.
                //Parameter 2 is the directory to report. Parameter 3 is how deep the scan will go. Parameter 4 Skips Icons if set to true (The icon handling is slow)
                //This example demonstrates how to use outlines, tables,comments, shapes, pictures and charts.                
                Console.WriteLine("Running sample 6");
                output = Sample6.RunSample6(new DirectoryInfo(System.Reflection.Assembly.GetEntryAssembly().Location).Parent, 5, true);
                Console.WriteLine("Sample 6 created:", output);
                Console.WriteLine();

                //Sample 7
                //This sample shows the performance capabilities of the component and shows sheet protection.
                //Load X(param 2) rows with five columns
                Console.WriteLine("Running sample 7");
                output = Sample7.RunSample7(65534);
                Console.WriteLine("Sample 7 created:", output);
                Console.WriteLine();

                //Sample 8 - Linq
                //Opens Sample 7 and perform some Linq queries
                Console.WriteLine("Running sample 8-Linq");
                LinqSample.RunLinqSample();
                Console.WriteLine();

                //Sample 9 Loads two csv files into tables and creates an area chart and a Column/Line chart on the data.
                //This sample also shows how to use a secondary axis.
                Console.WriteLine("Running sample 9");
                output = Sample9.RunSample9();
                Console.WriteLine("Sample 9 created: {0}", output);
                Console.WriteLine();

                //Sample 10 Swedish Quiz : Shows Encryption, workbook- and worksheet protection.
                Console.WriteLine("Running sample 10");
                Sample10.RunSample10();
                Console.WriteLine("Sample 10 created: {0}", Utils.OutputDir.FullName);
                Console.WriteLine();

                //Sample 11 - Data validation
                Console.WriteLine("Running sample 11");
                output = Sample11.RunSample11();
                Console.WriteLine("Sample 11 created {0}", output);
                Console.WriteLine();

                //Sample 12 - Pivottables
                Console.WriteLine("Running sample 12");
                output = Sample12.RunSample12(connectionStr);
                Console.WriteLine("Sample 12 created {0}", output);
                Console.WriteLine();

                //Sample 13 - Shows a few ways to load data (Datatable, IEnumerable and more).
                Console.WriteLine("Running sample 13");
                Sample13.RunSample13();
                Console.WriteLine("Sample 13 created {0}", Utils.OutputDir.Name);
                Console.WriteLine();

                //Sample 14 - Conditional Formatting
                Console.WriteLine("Running sample 14");
                Sample14.RunSample14();
                Console.WriteLine("Sample 14 created {0}", Utils.OutputDir.Name);
                Console.WriteLine();

                //Sample 15 - Shows how to work with macro-enabled workbooks(VBA).
                Console.WriteLine("Running sample 15-VBA");
                Sample15.VBASample();
                Console.WriteLine("Sample 15 created {0}", Utils.OutputDir.Name);
                Console.WriteLine();

                //Sample 16 - Shows how to add sparkline charts.
                Console.WriteLine("Running sample 16-Sparklines");
                Sample16.RunSample16();
                Console.WriteLine("Sample 16 created {0}", Utils.OutputDir.Name);
                Console.WriteLine();

                //Sample FormulaCalc - Shows how to calculate formulas in the workbook.
                Console.WriteLine("Running Sample_FormulaCalc");
                Sample_FormulaCalc.RunSampleFormulaCalc();
                Console.WriteLine();

                //Sample AddFormulaFunction - Shows how to add your own implementations of excel functions to EPPlus.
                Console.WriteLine("Running Sample_AddFormulaFunction");
                Sample_AddFormulaFunction.RunSample_AddFormulaFunction();
                Console.WriteLine();
            }
			catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
			}
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Genereted sample workbooks can be found in {Utils.OutputDir?.FullName}");
            Console.ForegroundColor = prevColor;

            Console.WriteLine();
			Console.WriteLine("Press the return key to exit...");
			Console.Read();
		}
	}
}
