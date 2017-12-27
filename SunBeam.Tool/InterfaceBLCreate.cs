using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SunBeam.Tool
{
    internal class InterfaceBLCreate
    {
        private readonly string tableName;
        private List<TableSchema> tableSchema;
        private readonly TableSchema tablePk;
        private string currentPath;

        public InterfaceBLCreate(string tableName, List<TableSchema> tableSchema, string currentPath)
        {
            this.tableName = tableName;
            this.tableSchema = tableSchema;
            var firstOrDefault = tableSchema.FirstOrDefault(p => p.IsIdentity.ToLower() == "true");
            if (firstOrDefault != null)
                tablePk = firstOrDefault;
                tablePk = tableSchema.ElementAt<TableSchema>(0);
            this.currentPath = currentPath + tableName;
        }

        public void WriteInterfaceBL()
        {
            using (var writer = new StreamWriter(currentPath + "\\I" + tableName + "BL.cs"))
            {
                writer.WriteLine("using SunBeam.Domain.Models;");
                writer.WriteLine("using System.Collections.Generic;");
                writer.WriteLine("using System.Threading.Tasks;");
                writer.WriteLine("");
                writer.WriteLine("namespace SunBeam.Service.Interfaces");
                writer.WriteLine("{");
                writer.WriteLine("public interface I" + tableName + "BL");
                writer.WriteLine("{");
                writer.WriteLine("Task<string> Insert" + tableName + "(" + tableName + " entity);");
                writer.WriteLine("Task<string> Update" + tableName + "(" + tableName + " entity);");
                writer.WriteLine("Task<string> IsDelete" + tableName + "(string[] IdList," + tableName + " entity);");
                writer.WriteLine("Task<string> Delete" + tableName + "(int Id);");
                writer.WriteLine("Task<IEnumerable<" + tableName + ">> GetAll" + tableName + "();");
                writer.WriteLine("Task<" + tableName + "> Get" + tableName + "By" + tablePk.ColumnName + "(" + tablePk.DataTypeName + " " + tablePk.ColumnName + ");");
                writer.WriteLine("Task<IEnumerable<" + tableName + ">> DropDown" + tableName + "();");

                writer.WriteLine("  }");
                writer.WriteLine("}");
            }
        }
    }
}