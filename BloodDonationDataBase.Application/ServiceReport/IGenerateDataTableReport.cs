using BloodDonationDataBase.Domain.Models;
using FastReport.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationDataBase.Application.ServiceReport
{
    public interface IGenerateDataTableReport
    {
        void DataTableReportDonors(IEnumerable<Donor> donations, WebReport webReport);
        void DataTableReportDonations(IEnumerable<Donation> donations, WebReport webReport);
        void DataTableReportBloodStock(IEnumerable<BloodStock> donations, WebReport webReport);
    }
}
