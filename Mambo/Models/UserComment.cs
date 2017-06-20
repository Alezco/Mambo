using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mambo.Models
{
    public class UserComment
    {
        [Required(ErrorMessage = "Le champ ne peut pas être vide")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Commentez")]
        public string Text { get; set; }
    }
}