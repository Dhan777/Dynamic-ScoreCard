using MvcApplication10.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication10.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return Json(new DataLaye().GetData(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Test2()
        {
            var D = new DataLaye().GetData3();
            var Columns = new DataLaye().GetColumns2();
            var Colors = new DataLaye().GetColors().ToList();
            string RowHeader = "";
            string Rows = "";
            string Table = "";
            string Status = "OUT";
            string ColorStatus = "NotFILLED";
            string MatchingColumn = "";
            foreach (DataColumn col in D.Columns)
            {
                RowHeader = RowHeader + "<th>" + col.ColumnName + "</th>";
            }
            RowHeader = "<tr>" + RowHeader + "</tr>";

            foreach (DataRow row in D.Rows)
            {
                Rows = string.Empty;
               // MatchingColumn = "";
                foreach (DataColumn col in D.Columns)
                {
                    Status = "OUT";
                    foreach (var MappingColumns in Columns.Where(x => x.ColumnName == col.ColumnName))
                    {
                        Status = "IN";
                        if (col.ColumnName == MappingColumns.ColumnName)
                        {
                            ColorStatus = "NotFILLED";
                            foreach (var Values in Colors)
                            {
                                if (Convert.ToInt32(row[col.ColumnName]) >= Values.MinValue && Convert.ToInt32(row[col.ColumnName]) <= Values.MaxValue)
                                {
                                    ColorStatus = "FILLED";
                                    Rows = Rows + "<td style='background-color:" + Values.ColorName + "'>" + row[col.ColumnName] + "</td>";
                                }
                            }
                            if (ColorStatus == "NotFILLED")
                            {
                                Rows = Rows + "<td>" + row[col.ColumnName] + "</td>";
                            }
                        }
                    }
                    if (Status == "OUT")
                    {
                        if (row[col.ColumnName].ToString().Contains(','))
                        {
                            if (row[col.ColumnName].ToString().Split(',')[0] != MatchingColumn)
                            {
                                Rows = Rows + "<td rowspan=" + row[col.ColumnName].ToString().Split(',')[1] + ">" + row[col.ColumnName].ToString().Split(',')[0] + "</td>";
                            }
                            //else
                            //{
                            //    Rows = Rows + "<td>Duplicate</td>";
                            //}
                            MatchingColumn = row[col.ColumnName].ToString().Split(',')[0];
                        }
                        else
                        {
                            Rows = Rows + "<td>" + row[col.ColumnName] + "</td>";
                        }
                    }
                }

                Rows = "<tr>" + Rows + "</tr>";
                Table = Table + Rows;
            }
            Table = "<table border='1'>" + RowHeader + Table + "</Table>";
            ///   var  P = "<h1>My name is Amit</h1>";
            ScoreCard model = new ScoreCard();
            model.ProjectName = Table;
            return View(model);
        }

    }
}
