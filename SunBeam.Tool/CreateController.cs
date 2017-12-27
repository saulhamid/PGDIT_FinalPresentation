using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunBeam.Tool
{
    public class CreateController
    {
        private readonly string tableName;
        private List<TableSchema> tableSchema;
        private readonly TableSchema tablePk;
        private string currentPath;

        public CreateController(string tableName, List<TableSchema> tableSchema, string currentPath)
        {
            this.tableName = tableName;
            this.tableSchema = tableSchema;
            var firstOrDefault = tableSchema.FirstOrDefault(p => p.IsIdentity.ToLower() == "true");
            if (firstOrDefault != null)
                tablePk = firstOrDefault;
                tablePk = tableSchema.ElementAt<TableSchema>(0);
            this.currentPath = currentPath + tableName;
        }

        public void WriteRepositoryClass()
        {
            using (var writer = new StreamWriter(currentPath + "\\" + tableName + "Controller.cs"))
            {
                writer.WriteLine("#region Library");
                writer.WriteLine("using SunBeam.Domain.Models;");
                writer.WriteLine("using SunBeam.Service.Interfaces;");
                writer.WriteLine("using System;");
                writer.WriteLine("using System.Collections.Generic;");
                writer.WriteLine("using System.Linq;");
                writer.WriteLine("using System.Threading.Tasks;");
                writer.WriteLine("using System.Web.Mvc;");
                writer.WriteLine("#endregion library");

                writer.WriteLine(" ");

                writer.WriteLine("namespace SunBeam.Web.Areas.Config.Controllers");
                writer.WriteLine("{");
                writer.WriteLine("public class " + tableName.Remove(tableName.Length - 1) + "Controller:Controller");
                writer.WriteLine("{");

                writer.WriteLine("private readonly I" + tableName + "BL repo;");
                writer.WriteLine("public " + tableName.Remove(tableName.Length - 1) + "Controller(I" + tableName + "BL _repo)");
                writer.WriteLine("{");

                writer.WriteLine("this.repo = _repo;");
                writer.WriteLine("}");
                writer.WriteLine(" ");

                writer.WriteLine(" public ActionResult Index()");
                writer.WriteLine(" {");
                writer.WriteLine(" return View();");
                writer.WriteLine(" }");

                writer.WriteLine(" ");
                writer.WriteLine("[HttpGet] ");
                writer.WriteLine("public ActionResult Create()");
                writer.WriteLine("{");
                writer.WriteLine("return PartialView();");
                writer.WriteLine("}");

                writer.WriteLine("[HttpPost] ");
                writer.WriteLine("  public async Task<ActionResult> Create(" + tableName + " data)");
                writer.WriteLine("{ ");
                writer.WriteLine(" string result = string.Empty; ");
                writer.WriteLine("try ");
                writer.WriteLine(" {");
                writer.WriteLine("result = await repo.Insert" + tableName + "(data); ");
                writer.WriteLine(" }");
                writer.WriteLine("catch (Exception ex) ");
                writer.WriteLine("{ ");
                writer.WriteLine(" throw;");
                writer.WriteLine(" }");
                writer.WriteLine("return Json(result,JsonRequestBehavior.AllowGet); ");
                writer.WriteLine("} ");

                writer.WriteLine("[HttpGet] ");
                writer.WriteLine("public ActionResult Edit(int Id) ");
                writer.WriteLine("{ ");
                writer.WriteLine(" dynamic data; ");
                writer.WriteLine(" try");
                writer.WriteLine(" {");
                writer.WriteLine(" data =  repo.Get" + tableName + "ById(Id).Result;");
                writer.WriteLine(" }");
                writer.WriteLine("catch (Exception ex) ");
                writer.WriteLine("{ ");
                writer.WriteLine(" throw;");
                writer.WriteLine(" }");
                writer.WriteLine(" return PartialView(data);");
                writer.WriteLine("}");

                writer.WriteLine(" [HttpPost] ");
                writer.WriteLine("  public async Task<ActionResult> Edit(" + tableName + " data)");
                writer.WriteLine("{ ");
                writer.WriteLine(" string result = string.Empty; ");
                writer.WriteLine("try ");
                writer.WriteLine(" {");
                writer.WriteLine("result = await repo.Update" + tableName + "(data); ");
                writer.WriteLine(" }");
                writer.WriteLine("catch (Exception ex) ");
                writer.WriteLine("{ ");
                writer.WriteLine(" throw;");
                writer.WriteLine(" }");
                writer.WriteLine("return Json(result,JsonRequestBehavior.AllowGet); ");
                writer.WriteLine("} ");
                writer.WriteLine(" ");

                writer.WriteLine(" public async Task<JsonResult> Delete(string ids) ");
                writer.WriteLine(" {");
                writer.WriteLine("string result = string.Empty; ");
                writer.WriteLine("string[] IdList = ids.Split('~'); ");
                writer.WriteLine(tableName +" vm = new "+ tableName + "(); ");
                writer.WriteLine("try ");
                writer.WriteLine("{ ");
                writer.WriteLine(" result = await repo.IsDelete" + tableName + "(IdList,vm); ");
                writer.WriteLine(" }");
                writer.WriteLine("catch (Exception ex) ");
                writer.WriteLine("{ ");
                writer.WriteLine(" throw;");
                writer.WriteLine(" }");
                writer.WriteLine("  return Json(result, JsonRequestBehavior.AllowGet);");
                writer.WriteLine("} ");
                writer.WriteLine(" public async Task<JsonResult> DropDown"+tableName+"() ");
                writer.WriteLine(" {");
                writer.WriteLine("   dynamic result;");
                writer.WriteLine(" try");
                writer.WriteLine(" {");
                writer.WriteLine("  result = await repo.DropDown"+tableName+"();");
                writer.WriteLine(" }");
                writer.WriteLine("catch (Exception ex) ");
                writer.WriteLine(" {");
                writer.WriteLine("  throw ex;");
                writer.WriteLine("} ");
                writer.WriteLine("return Json(new SelectList((result), \"Id\","+ "\"Name\"), JsonRequestBehavior.AllowGet); ");
                writer.WriteLine(" }");
                writer.WriteLine(" ");
                writer.WriteLine("}");
                writer.WriteLine("}");
            }
        }
    }
}
