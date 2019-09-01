using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MushRoom_Manager.Models;
namespace MushRoom_Manager.ViewModels
{
    public class MushroomTypesViewModel
    {
        public IEnumerable<MushroomType> MushroomTypes { get; set; }
        public MushroomType MushroomType { get; set; }
    }
}