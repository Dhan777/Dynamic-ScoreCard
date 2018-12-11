using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication10.Models
{
    public class ScoreCard
    {
        public string ProjectName { get; set; }
        public string GroupName { get; set; }
        public string ProductName { get; set; }
        public string PlatformName { get; set; }
        public int Total { get; set; }
        public int passPer { get; set; }
    }
    public class ColumnMapping
    {
        public string ColumnName { get; set; }
        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public string ColorName { get; set; }
    }
    public class ColorMapping
    {
        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public string ColorName { get; set; }
    }
}