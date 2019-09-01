using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MushRoom_Manager.Models
{
    public class Request
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }        
        
        /// <summary>
        /// Request client
        /// </summary>
        public int ClientId { get; set; }
        public Client Client { get; set; }

        /// <summary>
        /// Request delivery date
        /// </summary>
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Request status
        /// </summary>
        public RequestStatus RequestStatus { get; set; }
        public byte RequestStatusId { get; set; }
    }
}