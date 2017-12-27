using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SunBeam.Web.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        //public FileResult TransferCertificate(long id)
        //{
        //    ReportViewer rptViewer = new ReportViewer();
        //    DataTable dt = new DataTable();
        //    dt = DataAccess.Instance.CommonServices.GetBySpWithParam("rpt_GetStudentInfoByIID", new object[] { id });
        //    var Gurdianinfo = DataAccess.Instance.aStudentGuardianService.Filter(e => e.StudentIID == id).ToList();
        //    var AcademicHis = DataAccess.Instance.aStudentAcademicService.Filter(e => e.StudentIID == id).ToList();

        //    rptViewer.ProcessingMode = ProcessingMode.Local;
        //    rptViewer.Width = Unit.Percentage(100);
        //    rptViewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/StudentBasic/rptTransferCertificate.rdlc");
        //    rptViewer.LocalReport.EnableExternalImages = true;
        //    rptViewer.LocalReport.DataSources.Add(new ReportDataSource("SPResults", dt));
        //    rptViewer.LocalReport.DataSources.Add(new ReportDataSource("GuardianInfo", Gurdianinfo));
        //    rptViewer.LocalReport.DataSources.Add(new ReportDataSource("AcademicHistory", AcademicHis));
        //    rptViewer.LocalReport.DataSources.Add(new ReportDataSource("Header", GetHeader()));
        //    rptViewer.LocalReport.Refresh();

        //    Warning[] warnings;
        //    string[] streamIds;
        //    string mimeType = string.Empty;
        //    string encoding = string.Empty;
        //    string extension = string.Empty;
        //    byte[] bytes = rptViewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        //    return File(bytes, "application/pdf");

        //}
    }
}