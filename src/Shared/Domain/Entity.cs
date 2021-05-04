using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Domain
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}
