using Equals_Api.Models.EntityModel.AcquiringCompanys;

namespace Equals_Api.Models.EntityModel.CardLayouts
{
    public class CardLayout
    {
        public int Id { get; set; }
        public int RegisterType { get; set; }
        public long ProcessDate { get; set; }
        public long Establishment { get; set; }
        public int AcquiringCompanyId { get; set; }
        public int? FirstPeriod { get; set; }
        public int? FinalPeriod { get; set; }
        public int Sequence { get; set; }
        public AcquiringCompany AcquiringCompany { get; set; }
    }
}
