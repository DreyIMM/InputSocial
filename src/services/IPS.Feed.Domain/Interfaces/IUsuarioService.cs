﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.Feed.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task<string> ObterNomeUsuario(Guid idUsuario);
    }
}
