using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NOT.Models
{
    public class ListaUtentiViewModel
    {
        [Display(Name = "Id Utente")]
        public string UserId { get; set; }

        [Display(Name = "Nome Utente")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Posta elettronica")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Ruolo")]
        [EnumDataType(typeof(RuoloEnum))]
        public string Ruolo { get; set; }
    }

    public class AddUtenteViewModel
    {
        [Required]
        [Display(Name = "Nome Utente")]
        [StringLength(100, ErrorMessage = "La lunghezza di {0} deve essere di almeno {2} caratteri.", MinimumLength = 6)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Posta elettronica")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La lunghezza di {0} deve essere di almeno {2} caratteri.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Conferma password")]
        [Compare("Password", ErrorMessage = "La password e la password di conferma non corrispondono.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Ruolo")]
        public string Ruolo { get; set; }
    }

    public class EditUtenteViewModel
    {
        [Display(Name = "Id Utente")]
        public string UserId { get; set; }

        [Display(Name = "Nome Utente")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Posta elettronica")]
        public string Email { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "La lunghezza di {0} deve essere di almeno {2} caratteri.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        [Required]
        [Display(Name = "Ruolo")]
        [EnumDataType(typeof(RuoloEnum))]
        public string Ruolo { get; set; }
    }
}

