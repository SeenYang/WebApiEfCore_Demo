using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiEfCorePoc.Models.Entities
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime FinalisedDateTime { get; set; }
        public string Description { get; set; }
    }
}