using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Equals_Api.Extensions;
using Equals_Api.Models.EntityModel.CardLayouts;
using Equals_Api.Models.EntityModel.DeliveryPeriodicitys;
using Equals_Api.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Equals_Api.Models.ServiceModel
{
    public class FileService
    {
        private readonly ApiDbContext _context;

        public FileService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<string> ReadFileAsync([FromForm] IFormFile file)
        {
            string text = string.Empty;
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                byte[] byteArray = stream.ToArray();

                text = System.Text.Encoding.Default.GetString(byteArray);
            }
            return text;
        }

        private string SelectBusinessType(string text)
        {
            string[] businessTypes = 
            {
                BusinessType.UflaCard,
                BusinessType.FagammonCard
            };

            foreach(string type in businessTypes)
            {
                if(text.ThereIs(type))
                {
                    return type;
                }
            }
            return string.Empty;
        }

        public void SaveFile(string text)
        {
            string businessType = SelectBusinessType(text);

            CardLayout card = new CardLayout();

            if(businessType.Equals(BusinessType.UflaCard))
            {
                card.RegisterType = Convert.ToInt32(text.Substring(0,1));
                card.Establishment = Convert.ToInt64(text.Substring(1,10));
                card.ProcessDate = Convert.ToInt64(text.Substring(11,8));
                card.FirstPeriod = Convert.ToInt32(text.Substring(19,8));
                card.FinalPeriod = Convert.ToInt32(text.Substring(27,8));
                card.Sequence = Convert.ToInt32(text.Substring(35,7));
                card.AcquiringCompanyId = 1;
                
                _context.CardLayouts.Add(card);
                _context.SaveChanges();
            }

            if(businessType.Equals(BusinessType.FagammonCard))
            {
                card.RegisterType = Convert.ToInt32(text.Substring(0,1));
                card.ProcessDate = Convert.ToInt64(text.Substring(1,10));
                card.Establishment = Convert.ToInt64(text.Substring(9,8));
                card.AcquiringCompanyId = 2;
                card.Sequence = Convert.ToInt32(text.Substring(29,7));

                _context.CardLayouts.Add(card);
                _context.SaveChanges();
            }
        }

        public void SaveFilePeriodicity(DeliveryPeriodicityModel deliveryPeriodicityModel)
        {
            DeliveryPeriodicity deliveryPeriodicity = new DeliveryPeriodicity();

            deliveryPeriodicity = DeliveryPeriodicityMapping.MapFrom(deliveryPeriodicityModel);

            DeliveryPeriodicity deliveryPeriodicityFound = _context.DeliveryPeriodicitys
                .FirstOrDefault<DeliveryPeriodicity>( entity => entity.AcquiringCompanyId == deliveryPeriodicity.AcquiringCompanyId);

            if(deliveryPeriodicityFound != null)
            {
                deliveryPeriodicityFound.FilesQty = deliveryPeriodicity.FilesQty;
                deliveryPeriodicityFound.DaysWaiting = deliveryPeriodicity.DaysWaiting;
                deliveryPeriodicityFound.AcquiringCompanyId = deliveryPeriodicity.AcquiringCompanyId;

                _context.DeliveryPeriodicitys.Update(deliveryPeriodicityFound);
            }
            else if(deliveryPeriodicityFound == null)
            {
                _context.DeliveryPeriodicitys.Add(deliveryPeriodicity);
            }
            
            _context.SaveChanges();
        }
    }
}