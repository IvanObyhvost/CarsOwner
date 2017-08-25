using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CarsOwner.Core.Resource;

namespace CarsOwner.Core.DTO
{
    public class OwnerDTO
    {
        [HiddenInput(DisplayValue = false)]
        public int IdOwner { get; set; }

        [Display(Name = DisplayName.NameOwner)]
        public string Name { get; set; }
        [Display(Name = DisplayName.SurNameOwner)]
        public string Surname { get; set; }
        [Display(Name = DisplayName.BirthDate)]
        public int BirthDate { get; set; }
    
        [Display(Name = DisplayName.DrivingExperience)]
        [DisplayFormat(DataFormatString = "{0:N1}", ApplyFormatInEditMode = true)]
        public decimal DrivingExperience { get; set; }
        public List<CarDTO> CarList { get; set; }

        public OwnerDTO()
        {
            CarList = new List<CarDTO>();
        }

       }
}
