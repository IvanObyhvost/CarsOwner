using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsOwner.DAL.Entites
{
    public class OwnerEntity
    {
        [Key]
        public int IdOwner { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthDate { get; set; }
        public decimal DrivingExperience { get; set; }

        public virtual ICollection<CarEntity> CarEntities { get; set; }

        public OwnerEntity()
        {
            CarEntities = new List<CarEntity>();
        }
    }
}
