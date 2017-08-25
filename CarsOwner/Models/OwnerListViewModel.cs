using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarsOwner.Core.DTO;

namespace CarsOwner.Models
{
    public class OwnerListViewModel
    {
        public IList<OwnerDTO> OwnersList = new List<OwnerDTO>(); 
    }
}