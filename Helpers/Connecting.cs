﻿
using Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Helpers
{
    internal class Connecting
    {
        public static CRUDdbEntities conn { get; set; } = new CRUDdbEntities();
    }
}
