using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Petshop.Data.Entities;

namespace Petshop.Data.Mapping
{
    public partial class ItemMap
    {
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Petshop.Data.Entities.Item> builder)
        {
            // add mapping overrides here
        }
    }
}
