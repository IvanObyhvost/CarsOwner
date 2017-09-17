using System.ComponentModel.DataAnnotations;

namespace CarsOwner.Models.Enum
{
    public enum EnumPageSize
    {
        [Display(Name = "3")]
        PageSizeThree,
        [Display(Name = "6")]
        PageSizeSix
    }
}