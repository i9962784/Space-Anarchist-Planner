using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class SDE
    {

        public static DataTable GetSystem()
        {
            return GetDataTableFromExcel(ConfigurationManager.AppSettings["SystemExcelSDELocation"], true);
        }

        public static Dictionary<int, int> GetSystemToRegionLookup()
        {
            Dictionary<int, int> StoR = new Dictionary<int, int>();

            foreach (DataRow dr in GetSystem().Rows)
                StoR.Add(Convert.ToInt32(dr["SOLARSYSTEMID"]), Convert.ToInt32(dr["REGIONID"]));

            return StoR;
        }
        
        public static DataTable GetRegions()
        {
            return GetDataTableFromExcel(ConfigurationManager.AppSettings["RegionExcelSDELocation"], true);
        }

        public static Dictionary<int, string> GetRegionsLookup()
        {
            Dictionary<int, string> Region = new Dictionary<int, string>();

            foreach(DataRow dr in GetRegions().Rows)
                Region.Add(Convert.ToInt32(dr["REGIONID"]),Convert.ToString(dr["REGIONNAME"]));

            return Region;
        }
        
        public static DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                return tbl;
            }
        }
    }


    /*
    List<Region> employeeList = dt.ToList<Region>();
    */
    public static class Helper
    {
        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
    }

}
