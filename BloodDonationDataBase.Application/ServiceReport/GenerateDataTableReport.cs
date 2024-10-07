using BloodDonationDataBase.Domain.Models;
using FastReport.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.ServiceReport
{
    public class GenerateDataTableReport : IGenerateDataTableReport
    {
       
        public void DataTableReportBloodStock(IEnumerable<BloodStock> bloodStocks, WebReport webReport)
        {
            var donationsDataTable = new DataTable();

            donationsDataTable.Columns.Add("Blood Type", typeof(int));
            donationsDataTable.Columns.Add("Factor Rh", typeof(string));
            donationsDataTable.Columns.Add("Quantity ml", typeof(string));


            foreach (var item in bloodStocks)
            {
                donationsDataTable.Rows.Add(item.BloodType, item.FactorRh, item.QuantityMl);
            }

            webReport.Report.RegisterData(donationsDataTable, "Blood Stock Report");
        }

       
        public void DataTableReportDonations(IEnumerable<Donation> donations, WebReport webReport)
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


        public void DataTableReportDonors(IEnumerable<Donor> donors, WebReport webReport)
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
    }
}
