﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto_EduXSprint2.Domains
{
    public partial class Perfil
    {
        [Key]
        public Guid Id { get; set; }
        public Perfil()
        {
            Usuario = new HashSet<Usuario>();
            Id = Guid.NewGuid();
        }

        public Guid IdPerfil { get; set; }
        public string Permissao { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
