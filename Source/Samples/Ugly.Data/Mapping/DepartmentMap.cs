using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Ugly.Data.Entities;

namespace Ugly.Data.Mapping
{
    public partial class DepartmentMap
    {
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ugly.Data.Entities.Department> builder)
        {
            // add mapping overrides here
        }
    }
}
