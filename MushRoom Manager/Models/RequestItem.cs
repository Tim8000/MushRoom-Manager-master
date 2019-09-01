using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MushRoom_Manager.Models
{
    public class RequestItem
    {
        /// <summary>
        /// Id
        /// </summary>        
        public int Id { get; set; }

        /// <summary>
        /// Item's request
        /// </summary>
        [Required]
        public Request Request { get; set; }
        public int RequestId { get; set; }

        /// <summary>
        /// Mushroom type
        /// </summary>
        public MushroomType MushroomType { get; set; }
        public byte MushroomTypeId { get; set; }

        /// <summary>
        /// Number of boxes
        /// </summary>
        public byte Amount { get; set; }

        /// <summary>
        /// Actual price
        /// </summary>
        [Required]        
        public byte Price { get; set; }
    }
}