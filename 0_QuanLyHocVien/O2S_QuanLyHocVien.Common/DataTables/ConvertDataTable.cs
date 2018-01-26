using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace O2S_QuanLyHocVien.Common.DataTables
{
    public static class ConvertDataTable
    {
        //public static DataTable ConvertListToDataTable(List<string[]> list)
        //{
        //    // New table.
        //    DataTable table = new DataTable();
        //    // Get max columns.
        //    int columns = 0;
        //    foreach (var array in list)
        //    {
        //        if (array.Length > columns)
        //        {
        //            columns = array.Length;
        //        }
        //    }
        //    // Add columns.
        //    for (int i = 0; i < columns; i++)
        //    {
        //        table.Columns.Add();
        //    }
        //    // Add rows.
        //    foreach (var array in list)
        //    {
        //        table.Rows.Add(array);
        //    }
        //    return table;
        //}

        //Function chuyển đổi List to Datatable C#
        public static DataTable ListToDataTable<T>(this IList<T> data)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        //Function chuyen doi tu Datatable sang List - ver 2.0 - nhanh hon v1 nhung phai chinh xac cac truong dl
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                T tempT = new T();
                var tType = tempT.GetType();
                List<T> list = new List<T>();
                foreach (var row in table.Rows.Cast<DataRow>())
                {
                    T obj = new T();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        var propertyInfo = tType.GetProperty(prop.Name);
                        var rowValue = row[prop.Name];
                        var t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;

                        try
                        {
                            object safeValue = (rowValue == null || DBNull.Value.Equals(rowValue)) ? null : Convert.ChangeType(rowValue, t);
                            propertyInfo.SetValue(obj, safeValue, null);

                        }
                        catch (Exception ex)
                        {//this write exception to my logger
                            continue;
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}
