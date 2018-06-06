using System;
using System.Data;
using System.Linq;
using NQuery;

namespace Northwind.Data
{
    public static class NorthwindDb
    {
        public static string GetData(string path)
        {
            var values = GetRetiredEmployees(path);
            return string.Join(Environment.NewLine, values);
        }

        public static string[] GetRetiredEmployees(string path)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(path);

            var dataContext = new DataContext();
            dataContext.AddTablesAndRelations(dataSet);

            var sql = @"
            SELECT  e.FirstName + ' ' + e.LastName
            FROM    Employees e
            WHERE   e.Birthdate.AddYears(65) < GETDATE()";

            var query = new Query(sql, dataContext);
            var results = query.ExecuteDataTable();
            var values = results.Rows.Cast<DataRow>().Select(r => (string)r[0]);

            return values.ToArray();
        }
    }
}
