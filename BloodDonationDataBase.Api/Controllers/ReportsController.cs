using BloodDonationDataBase.Application.Queries.BloodStockQueries.BloodStockReportQuery;
using BloodDonationDataBase.Application.Queries.DonationQueries.DonationListToReportQuerys;
using BloodDonationDataBase.Application.Queries.DonorQueries.DonorReportQuerys;
using BloodDonationDataBase.Application.ServiceReport;
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
        private readonly IGenerateDataTableReport _generateDataTableReport;

        public ReportsController(IMediator mediator, IWebHostEnvironment webHostEnvironment, IGenerateDataTableReport generateDataTableReport)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
            _generateDataTableReport = generateDataTableReport;
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

            _generateDataTableReport.DataTableReportDonations(result, webReport);

            webReport.Report.Prepare();

            using MemoryStream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Flush();
            byte[] arrayReport = stream.ToArray();
            return File(arrayReport, "application/zip", "DonationsReport.pdf");

        }


        [HttpGet("Donors report")]
        public async Task<IActionResult> DonorsReport()
        {
            var donor = new DonorReportQuery();
            if (donor is null)
            {
                return NotFound();
            }
            var result = await _mediator.Send(donor);

            var webReport = new WebReport();
            webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "ListDonors.frx"));

            _generateDataTableReport.DataTableReportDonors(result, webReport);

            webReport.Report.Prepare();

            using MemoryStream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Flush();
            byte[] arrayReport = stream.ToArray();
            return File(arrayReport, "application/zip", "DonationsReport.pdf");

        }


        [HttpGet("Blood Stock report")]
        public async Task<IActionResult> BloodStockReport()
        {
            var bloodStock = new BloodStockReportQuery();
            if (bloodStock is null)
            {
                return NotFound();
            }
            var result = await _mediator.Send(bloodStock);

            var webReport = new WebReport();
            webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "BloodStockReport.frx"));

            _generateDataTableReport.DataTableReportBloodStock(result, webReport);

            webReport.Report.Prepare();

            using MemoryStream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Flush();
            byte[] arrayReport = stream.ToArray();
            return File(arrayReport, "application/zip", "DonationsReport.pdf");

        }


    }
}
