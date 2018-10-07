using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyNextMatch.Entities.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Errors = new List<string>();
        }
        [NotMapped]
        public int Id { get; set; }
        [NotMapped]
        public List<string> Errors { get; set; }
        [NotMapped]
        public string SuccessMessage { get; set; }
        [NotMapped]
        public bool IsSuccess
        {
            get
            {
                return Errors.Count == 0;
            }
        }
    }
}
