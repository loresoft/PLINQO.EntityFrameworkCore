﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tracker.Data.Entities;

namespace Tracker.Data.Mapping
{
    public partial class UserMap
    {
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tracker.Data.Entities.User> builder)
        {
            // add mapping overrides here
        }
    }
}
