using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Model.Odev1.Attributes;

namespace RobotDreams.API.Model.Odev1
{
    [Route("api/[controller]")]
    [ApiController]
    [Dealer("Mehmet","9",true)]
    [Arac("Ferrari","Sport")]
    public class AttributeController : ControllerBase
    {

        [HttpGet]
        [Route("AttributeHomework")]
        public IActionResult AttributeHomework()
        {
            return Ok(GetAttribute(typeof(AttributeController)));
        }

        private string GetAttribute(Type t)
        {
            DealerAttribute myozell = (DealerAttribute)(System.Attribute.GetCustomAttribute(t, typeof(DealerAttribute)));
            AracAttribute AracAttr = (AracAttribute)(System.Attribute.GetCustomAttribute(t, typeof(AracAttribute)));

            List<string> attributesList = new List<string>
            {
                myozell.Name,
                myozell.Sales,
                AracAttr.AracName,
                AracAttr.SemaName
            };

            return $"Satış Personeli: {myozell.Name} -> Satış Puanı: {myozell.Sales} -> Test Drive: {myozell.Inspect} --> Marka: {AracAttr.AracName} --> Modeli: {AracAttr.SemaName}";

        }


    }
}
