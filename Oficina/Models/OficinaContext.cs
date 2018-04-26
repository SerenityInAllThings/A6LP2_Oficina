using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Oficina.Models
{
    public class OficinaContext: DbContext
    {
        public OficinaContext() : base("name=oficinaContainer") { }
    }
}