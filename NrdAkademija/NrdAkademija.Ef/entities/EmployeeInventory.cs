﻿using System;
using System.Collections.Generic;

namespace NrdAkademija.Ef.entities
{
    public partial class EmployeeInventory
    {
        public int EmployeeId { get; set; }
        public int InventoryId { get; set; }

        public Employee Employee { get; set; }
        public Inventory Inventory { get; set; }
    }
}
