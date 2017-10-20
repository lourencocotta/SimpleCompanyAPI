﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyAPI.Core.Contracts
{
    public abstract class DomainEventBase
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
