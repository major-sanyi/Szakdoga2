﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdoga.BusinessLayer.Model
{
    public class MainSyllabus : Syllabus
    {
        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}