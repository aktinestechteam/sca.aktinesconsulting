﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.infrastructure.Interface
{
    public interface IDatabaseConfig
    {
        string ConnectionString { get; }
    }
}
