using BloodDonationDataBase.Application.Queries.DonationQueries.DonationListToReportQuerys;
using BloodDonationDataBase.Domain.Models;
using FastReport;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BloodDonationDataBase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReportsController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Donations report")]
        public async Task<IActionResult> DonationsReport()
        {
            var donations = new DonationListToReportQuery();
            if (donations is null)
            {
                return NotFound();
            }
            var result = await _mediator.Send(donations);

            var webReport = new WebReport();
            webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "ListDonations.frx"));

            GenerateDataTableReport(result, webReport);

            webReport.Report.Prepare();

            using MemoryStream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Flush();
            byte[] arrayReport = stream.ToArray();
            return File(arrayReport, "application/zip", "DonationsReport.pdf");

        }

        private static void GenerateDataTableReport(IEnumerable<Donation> donations, WebReport webReport)
        {
            var donationsDataTable = new DataTable();

            donationsDataTable.Columns.Add("Id", typeof(int));
            donationsDataTable.Columns.Add("DonorId", typeof(int));
            donationsDataTable.Columns.Add("QuantityMl", typeof(int));
            donationsDataTable.Columns.Add("DateDonation", typeof(DateTime));

            foreach (var item in donations)
            {
                donationsDataTable.Rows.Add(item.Id, item.DonorId, item.QuantityMl, item.DateDonation);
            }

            webReport.Report.RegisterData(donationsDataTable, "List Donations");
        }

        [HttpGet("Donors report")]
        public async Task<IActionResult> DonorsReport()
        {
            var donations = new DonationListToReportQuery();
            if (donations is null)
            {
                return NotFound();
            }
            var result = await _mediator.Send(donations);

            var webReport = new WebReport();
            webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "ListDonors.frx"));

            GenerateDataTableReport(result, webReport);

            webReport.Report.Prepare();

            using MemoryStream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Flush();
            byte[] arrayReport = stream.ToArray();
            return File(arrayReport, "application/zip", "DonationsReport.pdf");

        }

        private static void GenerateDataTableReportDonors(IEnumerable<Donor> donors, WebReport webReport)
        {
            var donationsDataTable = new DataTable();

            donationsDataTable.Columns.Add("Id", typeof(int));
            donationsDataTable.Columns.Add("Name", typeof(string));
            donationsDataTable.Columns.Add("Email", typeof(string));
            donationsDataTable.Columns.Add("Age", typeof(int));
            donationsDataTable.Columns.Add("BloodType", typeof(string));
            donationsDataTable.Columns.Add("FactorRh", typeof(string));

            foreach (var item in donors)
            {
                donationsDataTable.Rows.Add(item.Id, item.Name, item.Email, item.Age, item.BloodType, item.FactorRh);
            }

            webReport.Report.RegisterData(donationsDataTable, "List Donations");
        }

        [HttpGet("Blood Stock report")]
        public async Task<IActionResult> BloodStockReport()
        {
            var donations = new DonationListToReportQuery();
            if (donations is null)
            {
                return NotFound();
            }
            var result = await _mediator.Send(donations);

            var webReport = new WebReport();
            webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "BloodStockReport.frx"));

            GenerateDataTableReport(result, webReport);

            webReport.Report.Prepare();

            using MemoryStream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Flush();
            byte[] arrayReport = stream.ToArray();
            return File(arrayReport, "application/zip", "DonationsReport.pdf");

        }

        private static void GenerateDataTableReportBloodStock(IEnumerable<Donor> donors, WebReport webReport)
        {
            var donationsDataTable = new DataTable();

            donationsDataTable.Columns.Add("Blood Type", typeof(int));
            donationsDataTable.Columns.Add("Factor Rh", typeof(string));
            donationsDataTable.Columns.Add("Quantity ml", typeof(string));
            

            foreach (var item in donors)
            {
                donationsDataTable.Rows.Add(item.Id, item.Name, item.Email, item.Age, item.BloodType, item.FactorRh);
            }

            webReport.Report.RegisterData(donationsDataTable, "Blood Stock Report");
        }

    }
}
