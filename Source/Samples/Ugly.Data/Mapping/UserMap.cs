using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Ugly.Data.Entities;

namespace Ugly.Data.Mapping
{
    public partial class UserMap
    {
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ugly.Data.Entities.User> builder)
        {
            // add mapping overrides here
        }
    }
}
