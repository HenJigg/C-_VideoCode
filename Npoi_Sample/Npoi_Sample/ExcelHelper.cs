using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Npoi_Sample
{
    /// <summary>
    /// Excel帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExcelHelper<T> where T : class
    {
        /// <summary>
        /// 导出文件
        /// </summary>
        /// <param name="xlsName">文件名</param>
        /// <param name="data">导出的数据源</param>
        public static void SaveXlsChangeds(string xlsName, List<T> data)
        {
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");

            var row = sheet.CreateRow(sheet.LastRowNum);

            //创建标题行
            int i = 0;
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            foreach (var property in propertyInfos)
            {
                object[] objs = property.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objs.Length > 0)
                {
                    //创建一个列并且赋值
                    row.CreateCell(i).SetCellValue(((DescriptionAttribute)objs[0]).Description);
                    i++;
                }
            }

            //给数据填充到表格当中
            int j = sheet.LastRowNum + 1, n = 0;
            foreach (var item in data)
            {
                n = 0;
                row = sheet.CreateRow(j++);
                //获取一项的所有属性
                var itemProps = item.GetType().GetProperties();
                foreach (var itemPropSub in itemProps)
                {
                    var objs = itemPropSub.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (objs.Length > 0)
                    {
                        row.CreateCell(n).SetCellValue(itemPropSub.GetValue(item, null) == null ? "" :
                            itemPropSub.GetValue(item, null).ToString());
                        n++;
                    }
                }
            }

            MemoryStream ms = new MemoryStream();

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            FileStream fileStream = new FileStream(xlsName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            ms.WriteTo(fileStream);
            ms.Close();
            ms.Dispose();
            fileStream.Close();
            workbook.Close();
        }
    }
}
