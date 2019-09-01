using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MushRoom_Manager.Models
{
    public class MushroomType
    {
        /// <summary>
        /// Id
        /// </summary>
        public byte? Id { get; set; }

        /// <summary>
        /// Mushroom type name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Package weight (kg)
        /// </summary>
        public byte PackageWeight { get; set; }

     
    }
}