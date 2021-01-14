using System;
using Equals_Api.Models.ViewModel;

namespace Equals_Api.Models.EntityModel.DeliveryPeriodicitys
{
    public static class DeliveryPeriodicityMapping
    {
        public static DeliveryPeriodicity MapFrom(DeliveryPeriodicityModel model)
        {
            return new  DeliveryPeriodicity
            {
                FilesQty = model.FilesQty,
                DaysWaiting = model.DaysWaiting,
                AcquiringCompanyId = Convert.ToInt32(model.AcquiringCompany == BusinessType.UflaCard ? BusinessTypeId.UflaCard : BusinessTypeId.FagammonCard)
            };
        }
    }
}