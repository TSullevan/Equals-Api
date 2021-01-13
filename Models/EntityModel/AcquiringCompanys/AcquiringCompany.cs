using System.Collections.Generic;
using Equals_Api.Models.EntityModel.CardLayouts;

namespace Equals_Api.Models.EntityModel.AcquiringCompanys
{
    public class AcquiringCompany
    {
        public int Id { get; set; }
        public int Description { get; set; }

        public List<CardLayout> CardLayouts { get; set; }
    }
}
