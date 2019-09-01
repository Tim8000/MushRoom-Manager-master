using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MushRoom_Manager.Models
{
    public class RequestStatus
    {
        /// <summary>
        /// Id
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        /// Request status name
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
    }
}