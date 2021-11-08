using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiEfCorePoc.Models.Entities
{
    public class User
    {
        [Key] public Guid Id { get; set; }
        public string Name { get; set; }
    }
}