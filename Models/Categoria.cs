﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKX.Models
{
    public class Categoria
    {
        public int Id { get; set; }

       

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        
    }
}
