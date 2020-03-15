using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElementoSelect.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }


    public class Pedido
    {
        [Display(Name="Cliente")]
        public string ClienteId { get; set; }

        public List<SelectListItem> Clientes;
    }
}
