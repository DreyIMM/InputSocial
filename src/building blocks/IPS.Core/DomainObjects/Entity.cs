using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        [NotMapped]
        public ValidationResult ValidationResult { get; set; }


        protected Entity()
        {
            Id = Guid.NewGuid();
        }

    }
}
