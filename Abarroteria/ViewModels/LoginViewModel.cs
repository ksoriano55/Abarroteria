using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abarroteria.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "*El usuario es un campo obligatorio")]
        [AllowHtml]
        public string usuario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*La contraseña es un campo requerido")]
        [AllowHtml]
        [DataType(DataType.Password)]
        public string passWord { get; set; }
    }
}