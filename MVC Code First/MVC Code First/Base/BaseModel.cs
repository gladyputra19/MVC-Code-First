﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Code_First.Base
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; } 
    }
}