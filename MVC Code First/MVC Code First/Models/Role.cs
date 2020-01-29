using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MVC_Code_First.Base;

namespace MVC_Code_First.Models
{
    [Table("TB_M_Role")]
    public class Role : BaseModel
    {
        public string Name { get; set; }

    }
}