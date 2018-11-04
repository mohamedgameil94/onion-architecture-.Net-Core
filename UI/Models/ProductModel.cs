using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class ProductModel : BaseModel
    {
      
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
    }
}
