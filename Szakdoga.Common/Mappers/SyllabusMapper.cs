﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szakdoga.Common.Dto;
using Szakdoga.DataLayer.Model;

namespace Szakdoga.Common.Mappers
{
    public class SyllabusMapper : IMapper<Syllabus, SyllabusDto>
    {
        public SyllabusDto? MapToDto(Syllabus? model)
        {
            if (model == null)
                return null;
            SyllabusDto dto = new()
            {
                Id = model.Id,
                Name = model.Name,
                Length = model.Length,
                MustChoseCredit = model.MustChoseCredit,
                ChosableCredit = model.ChosableCredit,
                StartingSpecSemester = model.StartingSpecSemester,
                Parent = model.Parent
            };
            var subjects = model.Subjects?.ToList();
            if (subjects != null && subjects.Count > 0)
            {
                SubjectMapper subjectMapper = new SubjectMapper();
                dto.Subjects = new List<SubjectDto>();
                foreach (var subject in subjects)
                    dto.Subjects.Add(subjectMapper.MapToDto(subject));
            }
            return dto;
        }

        public Syllabus? MapToModel(SyllabusDto? dto)
        {
            if (dto == null)
                return null;
            Syllabus model = new()
            {
                Name = dto.Name,
                Length = dto.Length,
                MustChoseCredit = dto.MustChoseCredit,
                ChosableCredit = dto.ChosableCredit,
                StartingSpecSemester = dto.StartingSpecSemester,
                Parent = dto.Parent
            };
            return model;
        }
    }
}