﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ADEPT_API.LIBRARY.Dto.Users
{
    [DataContract]
    public class StudyProgramCreateRequestDto
    {
        [DataMember]
        [Required]
        public string Name { get; set; }
    }
}
