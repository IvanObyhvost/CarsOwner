using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CarsOwner.DAL.Entites
{
    public class DescriptionCarEntity
    {
        [Key]
        [ForeignKey("Car")]
        public int IdCar { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMineType { get; set; }
        public virtual CarEntity Car { get; set; }
    }
}
