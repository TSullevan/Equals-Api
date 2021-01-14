using System.Collections.Generic;
using Equals_Api.Models.EntityModel.CardLayouts;
using Equals_Api.Models.EntityModel.DeliveryPeriodicitys;

namespace Equals_Api.Models.EntityModel.AcquiringCompanys
{
    public class AcquiringCompany
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public int DeliveryPeriodicityId { get; set; }

        public List<CardLayout> CardLayouts { get; set; }
        public DeliveryPeriodicity DeliveryPeriodicity { get; set; }
    }
}
