using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsOwner.DAL.Entites
{
    public class DescriptionCarEntity
    {
        [Key]
        public int IdCar { get; set; }
        public string Description { get; set; }
        public CarEntity Car { get; set; }
    }
}
