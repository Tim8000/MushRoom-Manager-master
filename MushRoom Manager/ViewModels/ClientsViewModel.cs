using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MushRoom_Manager.Models;

namespace MushRoom_Manager.ViewModels
{
    public class ClientsViewModel 
    {
        public IEnumerable<Client> Clients { get; set; }

        public Client Client { get; set; }
      
    }
}