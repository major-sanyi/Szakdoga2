﻿using System;
using System.Collections.Generic;

namespace Szakdoga.DataLayer.Model
{
    public partial class Subject
    {
        public Subject()
        {
            StudentFinisheds = new HashSet<StudentFinished>();
            ChildSubjects = new HashSet<Subject>();
            Parents = new HashSet<Subject>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Kredit { get; set; }
        public string? RecommendedSemester { get; set; }
        public string? SyllabusId { get; set; }
        public int? TypeId { get; set; }
        public string Language { get; set; } = null!;

        public virtual Syllabus? Syllabus { get; set; }
        public virtual SubjectType? Type { get; set; }
        public virtual ICollection<StudentFinished> StudentFinisheds { get; set; }

        public virtual ICollection<Subject> ChildSubjects { get; set; }
        public virtual ICollection<Subject> Parents { get; set; }
    }
}
