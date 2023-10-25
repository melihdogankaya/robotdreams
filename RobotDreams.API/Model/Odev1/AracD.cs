using RobotDreams.API.Model.Odev1.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RobotDreams.API.Model.Odev1
{
    [Arac("Arac", "Base")] //Buraya Yazılan sadece Classlar için yapılmakta
    public class AracD
    {
        [Property("ID", true)]
        public Guid Id { get; set; }
    }
}
