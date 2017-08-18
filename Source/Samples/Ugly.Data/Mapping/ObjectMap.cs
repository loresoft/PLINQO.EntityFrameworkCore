using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Ugly.Data.Entities;

namespace Ugly.Data.Mapping
{
    public partial class ObjectMap
    {
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ugly.Data.Entities.Object> builder)
        {
            // add mapping overrides here
        }
    }
}
