using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NOT.Models
{
    public enum RuoloEnum
    {
        [Display(Name = "Amministratore")]
        Admin,
        [Display(Name = "Coordinatore")]
        Manager,
        [Display(Name = "Impiegato")]
        Employee,
        [Display(Name = "Utenti")]
        CustomerManager,
        [Display(Name = "Utente")]
        Customer
    }
}