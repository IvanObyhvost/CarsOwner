using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsOwner.DAL.Entites
{
    public class CarEntity
    {
        [Key]
        public int IdCar { get; set; }
        public string Model { get; set; }
        public string СarMake { get; set; }
        public byte TypeCar { get; set; }
        public decimal Price { get; set; }
        public int YearRelease { get; set; }

        public virtual ICollection<OwnerEntity> OwnerEntities { get; set; }

        public CarEntity()
        {
            OwnerEntities = new List<OwnerEntity>();
        }
        public DescriptionCarEntity DescriptionCar { get; set; }
    }
}
