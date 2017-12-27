using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SunBeam.Tool
{
    internal class BLCreate
    {        
        private readonly string tableName;
        private readonly List<TableSchema> tableSchema;
        private readonly TableSchema tablePk;
        private readonly string currentPath;

        public BLCreate(string tableName, List<TableSchema> tableSchema, string currentPath)
        {
            this.tableName = tableName;
            this.tableSchema = tableSchema;
            var firstOrDefault = tableSchema.FirstOrDefault(p => p.IsIdentity.ToLower() == "true");
            if (firstOrDefault != null)
                tablePk = firstOrDefault;
                tablePk = tableSchema.ElementAt<TableSchema>(0);
            this.currentPath = currentPath + tableName;
        }

        public void WriteBL()
        {
            using (var writer = new StreamWriter(currentPath + "\\" + tableName + "BL.cs"))
            {
                WriteBLClass(writer);
            }
        }

        private void WriteBLClass(StreamWriter writer)
        {
            writer.WriteLine("using SunBeam.Common.Log;");
            writer.WriteLine("using SunBeam.Data.Repositories.Implementations;");
            writer.WriteLine("using SunBeam.Domain.Models;");
            writer.WriteLine("using System;");
            writer.WriteLine("using System.Collections.Generic;");
            writer.WriteLine("using System.Threading.Tasks;");
            writer.WriteLine("");
            writer.WriteLine();

            writer.WriteLine("namespace SunBeam.Service.Interfaces");
            writer.WriteLine("{");

            writer.WriteLine();
            writer.WriteLine();

            writer.WriteLine("public class " + tableName + "BL : I" + tableName + "BL");
            writer.WriteLine("{");

            writer.WriteLine();
            writer.WriteLine("protected ILogger logger { get; set; }");
            writer.WriteLine();

            WriteBLCtor(writer);
            writer.WriteLine();
            WriteInsertBL(writer);
            writer.WriteLine();
            WriteUpdateBL(writer);
            writer.WriteLine();
            WriteIsDeleteBL(writer);
            writer.WriteLine();
            WriteDeleteBL(writer);
            writer.WriteLine();
            WriteGetAllBL(writer);
            writer.WriteLine();
            WriteGetByPkIdBL(writer);


            writer.WriteLine();
            writer.WriteLine();
            WriteDropDownBL(writer);
            writer.WriteLine("}");

            writer.WriteLine();
            writer.WriteLine();

            writer.WriteLine("}");
        }

        private void WriteBLCtor(StreamWriter writer)
        {
            writer.WriteLine(
                "public " + tableName + "BL(ILogger logger)");
            writer.WriteLine("{");
            writer.WriteLine("this.logger = logger;");
            writer.WriteLine("}");
        }

        private void WriteInsertBL(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Insert " + tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"entity\"></param>");
            writer.WriteLine("/// <returns>Message</returns>");
            writer.WriteLine("public async Task<string> Insert" + tableName + "(" + tableName + " entity)");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var result = await new " + tableName + "Repository(logger).Insert(entity);");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");

        }

        private void WriteUpdateBL(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Update " + tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"entity\"></param>");
            writer.WriteLine("/// <returns>Message</returns>");
            writer.WriteLine("public async Task<string> Update" + tableName + "(" + tableName + " entity)");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");

            writer.WriteLine("var result = await new "+tableName+"Repository(logger).Update(entity);");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");

        }

        private void WriteIsDeleteBL(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Delete " + tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"" + tablePk.ColumnName + "\"></param>");
            writer.WriteLine("/// <returns>Message</returns>");
            writer.WriteLine("public async Task<string> IsDelete" + tableName + "(string[] IdList, " + tableName + " entity)");
            writer.WriteLine("{");
            writer.WriteLine("string result = string.Empty;");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine(" for (int i = 0; i < IdList.Length - 1; i++)");
            writer.WriteLine("{");
            writer.WriteLine("result = await new " + tableName + "Repository(logger).IsDelete(Convert.ToInt32(IdList[i]), entity);");
            writer.WriteLine("}");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
        }

        private void WriteDeleteBL(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Delete " + tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"" + tablePk.ColumnName + "\"></param>");
            writer.WriteLine("/// <returns>Message</returns>");
            writer.WriteLine("public async Task<string> Delete" + tableName + "(int Id)");
            writer.WriteLine("{");
            writer.WriteLine("string result = string.Empty;");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("result = await new " + tableName + "Repository(logger).Delete(Id);");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
        }
        private void WriteGetAllBL(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Get All " + tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <returns>List of" + tableName + "</returns>");
            writer.WriteLine("public async Task<IEnumerable<" + tableName + ">> GetAll" + tableName + "()");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var result = await new " + tableName + "Repository(logger).GetAll();");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");
        }

        private void WriteGetByPkIdBL(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Get " + tableName + " by " + tablePk.ColumnName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"" + tablePk.ColumnName + "\"></param>");
            writer.WriteLine("/// <returns>" + tableName + " Object</returns>");
            writer.WriteLine("public async Task<" + tableName + "> Get" + tableName + "By" + tablePk.ColumnName + "(" + tablePk.DataTypeName + " " + tablePk.ColumnName + ")");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var result = await new " + tableName + "Repository(logger).GetBy" + tablePk.ColumnName + "(" + tablePk.ColumnName + ");");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");
        }
        private void WriteDropDownBL(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Get Id , Name " + tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <returns>List of" + tableName + "</returns>");
            writer.WriteLine("public async Task<IEnumerable<" + tableName + ">> DropDown" + tableName + "()");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var result = await new " + tableName + "Repository(logger).Dropdown();");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");
        }
    }
}