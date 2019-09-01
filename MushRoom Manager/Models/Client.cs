using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MushRoom_Manager.Models
{
    public class Client
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Clinet's Name
        /// </summary>
        [Required]
        [StringLength(150)]        
        public string Name { get; set; }

        /// <summary>
        /// Client's Phone Number
        /// </summary>                
        public string Phone { get; set; }
    }
}