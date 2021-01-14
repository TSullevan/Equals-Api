using Equals_Api.Models.EntityModel.AcquiringCompanys;

namespace Equals_Api.Models.EntityModel.DeliveryPeriodicitys
{
    public class DeliveryPeriodicity
    {
        public int Id { get; set; }
        public int DaysWaiting { get; set; }
        public int FilesQty { get; set; }
        public int AcquiringCompanyId { get; set; }
        public AcquiringCompany AcquiringCompany { get; set; }
    }
}