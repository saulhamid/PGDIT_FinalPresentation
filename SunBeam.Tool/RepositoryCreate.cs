using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SunBeam.Tool
{
    internal class RepositoryCreate
    {
        private readonly string _tableName;
        private readonly List<TableSchema> _tableSchema;
        private readonly TableSchema _tablePk;

        private static string strOutPutPath;

        public enum RepositoryType
        {
            Add = 1,
            Update = 2,
            IsDelete = 3,
            Delete = 4,
            SelectAll = 5,
            SelectById = 6,
            Dropdown = 7
        }

        public RepositoryCreate(string tableName, List<TableSchema> tableSchema, string path)
        {
            _tableSchema = tableSchema;
            var firstOrDefault = tableSchema.FirstOrDefault(p => p.IsIdentity.ToLower() == "true");
            if (firstOrDefault != null)
                _tablePk = firstOrDefault;
            
                _tablePk = tableSchema.ElementAt<TableSchema>(0);
            _tableName = tableName;
            strOutPutPath = path + tableName;
            if (!Directory.Exists(strOutPutPath))  // if it doesn't exist, create
                Directory.CreateDirectory(strOutPutPath);
        }

        public void WriteRepository()
        {
            using (var writer = new StreamWriter(strOutPutPath + "\\" + _tableName + "Repository.cs"))
            {
                WriteRepositoryClass(writer);
            }
        }
        private void WriteRepositoryClass(StreamWriter writer)
        {      
            writer.WriteLine("using SunBeam.Common.Log;");
            writer.WriteLine("using SunBeam.Common.Utility;");
            writer.WriteLine("using SunBeam.Data.Infrastructure;");
            writer.WriteLine("using System;");
            writer.WriteLine("using System.Collections.Generic;");
            writer.WriteLine("using System.Data;");
            writer.WriteLine("using System.Data.SqlClient;");
            writer.WriteLine("using System.Threading.Tasks;");
            writer.WriteLine("using SunBeam.Data.Repositories.Interfaces;");
            writer.WriteLine("using SunBeam.Domain.Models;");
            writer.WriteLine();

            writer.WriteLine("namespace SunBeam.Data.Repositories.Implementations");
            writer.WriteLine("{");

            writer.WriteLine();
            writer.WriteLine();

            writer.WriteLine("public class " + _tableName + "Repository : DBGeneric<" + _tableName + ">, IRepository<" + _tableName + ">");
            writer.WriteLine("{");

            writer.WriteLine();
            writer.WriteLine("protected ILogger Logger { get; set; }");
            writer.WriteLine();

            WriteModelCtor(writer);
            writer.WriteLine();
            WriteInsertModel(writer);
            writer.WriteLine();
            WriteUpdateModel(writer);
            writer.WriteLine();
            WriteDelete(writer);
            writer.WriteLine();
            WriteIsDelete(writer);
            writer.WriteLine();
            WriteGetAllModel(writer);
            writer.WriteLine();
            WriteGetByPkIdModel(writer);
            writer.WriteLine();
            WriteModelMapping(writer);
            writer.WriteLine();
            WriteDropdownModel(writer);

            writer.WriteLine();
            writer.WriteLine();

            writer.WriteLine("}");

            writer.WriteLine();
            writer.WriteLine();
            writer.WriteLine("}");
        }

        private void WriteModelCtor(StreamWriter writer)
        {
            writer.WriteLine(
                "public " + _tableName + "Repository(ILogger logger)");
            writer.WriteLine("{");
            writer.WriteLine("Logger = logger;");
            writer.WriteLine("}");
        }

        private void WriteInsertModel(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Insert " + _tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"entity\"></param>");
            writer.WriteLine("/// <returns>Message</returns>");
            writer.WriteLine("public async Task<string> Insert" + "(" + _tableName + " entity)");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var cmd = new SqlCommand(\"sp_" + _tableName + "\");");

            foreach (var schema in _tableSchema)
                writer.WriteLine("cmd.Parameters.AddWithValue(\"@" + schema.ColumnName + "\", entity." +
                                 schema.ColumnName + ");");

            writer.WriteLine();
            writer.WriteLine("cmd.Parameters.Add(\"@Msg\", SqlDbType.NChar, 500);");
            writer.WriteLine("cmd.Parameters[\"@Msg\"].Direction = ParameterDirection.Output;");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@pOptions\", " + (int)RepositoryType.Add + ");");
            writer.WriteLine();

            writer.WriteLine("var result = await ExecuteNonQueryProc(cmd);");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");

        }

        private void WriteUpdateModel(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Update " + _tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"entity\"></param>");
            writer.WriteLine("/// <returns>Message</returns>");
            writer.WriteLine("public async Task<string> Update" + "(" + _tableName + " entity)");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var cmd = new SqlCommand(\"sp_" + _tableName + "\");");

            foreach (var schema in _tableSchema)
                writer.WriteLine("cmd.Parameters.AddWithValue(\"@" + schema.ColumnName + "\", entity." +
                                 schema.ColumnName + ");");
            
            writer.WriteLine();
            writer.WriteLine("cmd.Parameters.Add(\"@Msg\", SqlDbType.NChar, 500);");
            writer.WriteLine("cmd.Parameters[\"@Msg\"].Direction = ParameterDirection.Output;");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@pOptions\", " + (int)RepositoryType.Update + ");");
            
            writer.WriteLine();

            writer.WriteLine("var result = await ExecuteNonQueryProc(cmd);");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");

        }

        private void WriteIsDelete(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Delete " + _tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"" + _tablePk.ColumnName + "\"></param>");
            writer.WriteLine("/// <returns>Message</returns>");
            writer.WriteLine("public async Task<string> IsDelete" + "(" + _tablePk.DataTypeName + " " + _tablePk.ColumnName + "," + _tableName + " entity)");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var cmd = new SqlCommand(\"sp_" + _tableName + "\");");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@" + _tablePk.ColumnName + "\", " + _tablePk.ColumnName + ");");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@IsArchive \", \"true\");");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@LastUpdateBy \", entity.LastUpdateBy);");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@LastUpdateAt \", entity.LastUpdateAt);");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@LastUpdateFrom \", entity.LastUpdateFrom);");
            writer.WriteLine("cmd.Parameters.Add(\"@Msg\", SqlDbType.NChar, 500);");
            writer.WriteLine();
            writer.WriteLine();
            writer.WriteLine("cmd.Parameters[\"@Msg\"].Direction = ParameterDirection.Output;");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@pOptions\", " + (int)RepositoryType.IsDelete + ");");
            writer.WriteLine();
            writer.WriteLine();

            writer.WriteLine("var result = await ExecuteNonQueryProc(cmd);");
           
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");
        }

        private void WriteDelete(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Delete " + _tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"" + _tablePk.ColumnName + "\"></param>");
            writer.WriteLine("/// <returns>Message</returns>");
            writer.WriteLine("public async Task<string> Delete" + "(" + _tablePk.DataTypeName + " " + _tablePk.ColumnName +")");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var cmd = new SqlCommand(\"sp_" + _tableName + "\");");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@" + _tablePk.ColumnName + "\", " + _tablePk.ColumnName + ");");
            writer.WriteLine("cmd.Parameters.Add(\"@Msg\", SqlDbType.NChar, 500);");
            writer.WriteLine();
            writer.WriteLine();
            writer.WriteLine("cmd.Parameters[\"@Msg\"].Direction = ParameterDirection.Output;");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@pOptions\", " + (int)RepositoryType.Delete + ");");
            writer.WriteLine();
            writer.WriteLine();

            writer.WriteLine("var result = await ExecuteNonQueryProc(cmd);");

            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");
        }

        private void WriteGetAllModel(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Get All " + _tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <returns>List of" + _tableName + "</returns>");
            writer.WriteLine("public async Task<IEnumerable<" + _tableName + ">> GetAll()");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var cmd = new SqlCommand(\"sp_" + _tableName + "\");");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@pOptions\", " + (int)RepositoryType.SelectAll + ");");
            writer.WriteLine("var result = await GetDataReaderProc(cmd);");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");
        }

        private void WriteGetByPkIdModel(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Get " + _tableName + " by " + _tablePk.ColumnName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"" + _tablePk.ColumnName + "\"></param>");
            writer.WriteLine("/// <returns>" + _tableName + " Object</returns>");
            writer.WriteLine("public async Task<" + _tableName + "> GetBy" + _tablePk.ColumnName + "(" + _tablePk.DataTypeName + " " + _tablePk.ColumnName + ")");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var cmd = new SqlCommand(\"sp_" + _tableName + "\");");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@" + _tablePk.ColumnName + "\", " + _tablePk.ColumnName + ");");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@pOptions\", " + (int)RepositoryType.SelectById + ");");
            writer.WriteLine("var result = await GetByDataReaderProc(cmd);");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");
        }
        private void WriteDropdownModel(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Get Id, Name " + _tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <returns>List of" + _tableName + "</returns>");
            writer.WriteLine("public async Task<IEnumerable<" + _tableName + ">> Dropdown()");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine("var cmd = new SqlCommand(\"sp_" + _tableName + "\");");
            writer.WriteLine("cmd.Parameters.AddWithValue(\"@pOptions\", " + (int)RepositoryType.Dropdown + ");");
            writer.WriteLine("var result = await GetDataReaderProc(cmd);");
            writer.WriteLine("return result;");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");
        }
        private void WriteModelMapping(StreamWriter writer)
        {
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Data Mapping for " + _tableName);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("/// <param name=\"sqldatareader\"></param>");
            writer.WriteLine("/// <returns>" + _tableName + " Object</returns>");
            writer.WriteLine("public " + _tableName + " Mapping(SqlDataReader reader)");
            writer.WriteLine("{");
            writer.WriteLine("try");
            writer.WriteLine("{");
            writer.WriteLine(_tableName + " o" + _tableName + " = new " + _tableName + "();");
            foreach (var schema in _tableSchema)
            {
                writer.WriteLine(string.Format("o" + _tableName + "." + schema.ColumnName + " = {0}", GetRipoItem(schema)));
            }
            writer.WriteLine("return o" + _tableName + ";");
            writer.WriteLine("}");
            writer.WriteLine("catch (Exception ex)");
            writer.WriteLine("{");
            writer.WriteLine("Logger.Error(ex.Message);");
            writer.WriteLine("throw ex;");
            writer.WriteLine("}");
            writer.WriteLine("}");
        }
        private string GetRipoItem(TableSchema schema)
        {
            switch (schema.DataTypeName)
            {
                case "string":
                    {
                        return "Helper.ColumnExists(reader, \"" + schema.ColumnName + "\") ? reader[\"" + schema.ColumnName + "\"].ToString() : \"\";";
                    }
                case "long":
                    {
                        return "Helper.ColumnExists(reader, \"" + schema.ColumnName + "\") ? ((reader[\"" + schema.ColumnName +
                               "\"] == DBNull.Value) ? 0 : Convert.ToInt64(reader[\"" + schema.ColumnName + "\"])) : 0 ;";
                    }
                case "int":
                    {
                        return "Helper.ColumnExists(reader, \"" + schema.ColumnName + "\") ? ((reader[\"" + schema.ColumnName +
                               "\"] == DBNull.Value) ? 0 : Convert.ToInt32(reader[\"" + schema.ColumnName + "\"])) : 0 ;";
                    }
                case "tinyint":
                    {
                        return "Helper.ColumnExists(reader, \"" + schema.ColumnName + "\") ? ((reader[\"" + schema.ColumnName +
                               "\"] == DBNull.Value) ? 0 : Convert.ToInt16(reader[\"" + schema.ColumnName + "\"])) : 0 ;";
                    }
                case "DateTime":
                    {
                        return "Helper.ColumnExists(reader, \"" + schema.ColumnName + "\") ? ((reader[\"" + schema.ColumnName +
                                "\"] == DBNull.Value) ? Convert.ToDateTime(\"01/01/1900\") : Convert.ToDateTime(reader[\"" +
                                schema.ColumnName + "\"])) : Convert.ToDateTime(\"01/01/1900\");";
                    }
                case "double":
                    {
                        return "Helper.ColumnExists(reader, \"" + schema.ColumnName + "\") ? ((reader[\"" + schema.ColumnName +
                                "\"] == DBNull.Value) ? 0 : Convert.ToDouble(reader[\"" + schema.ColumnName + "\"])) : 0;";                
                    }
                case "bool":
                    {
                        return "Helper.ColumnExists(reader, \"" + schema.ColumnName + "\") ? ((reader[\"" + schema.ColumnName +
                                "\"] == DBNull.Value) ? false : Convert.ToBoolean(reader[\"" + schema.ColumnName +
                                "\"])) : false;";
                    }
                case "decimal":
                    {
                        return "Helper.ColumnExists(reader, \"" + schema.ColumnName + "\") ? ((reader[\"" + schema.ColumnName +
                                 "\"] == DBNull.Value) ? 0 : Convert.ToDecimal(reader[\"" + schema.ColumnName + "\"])) : 0;";
                    }
            }
            if ("ntext".Equals(schema.DbTypeName))
            {
                return "Helper.ColumnExists(reader, \"" + schema.ColumnName + "\") ? reader[\"" + schema.ColumnName + "\"].ToString() : \"\";";
            }
            return "";

        }

    }
}