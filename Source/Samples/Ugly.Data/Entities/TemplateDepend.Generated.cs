﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Ugly.Data.Entities
{
    public partial class TemplateDepend
    {
        public TemplateDepend()
        {
        }

        public int LinkID { get; set; }
        public int DependID { get; set; }

        public virtual Template LinkTemplate { get; set; }
        public virtual Template DependTemplate { get; set; }
    }
}