using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Petshop.Data.Entities;

namespace Petshop.Data.Mapping
{
    public partial class InventoryMap
    {
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Petshop.Data.Entities.Inventory> builder)
        {
            // add mapping overrides here
        }
    }
}
