using CorreioTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorreioTracker.Context.DbSchemas
{
    public class OnModelConfiguring
    {
        public ModelBuilder Model { get; set; }
        public OnModelConfiguring(ModelBuilder model)
        {
            Model = model;
        }

        public void Start()
        {
            var user = Model.Entity<User>();
                
            user.Property(m => m.Email).IsRequired();

            user.Property(m => m.Senha).IsRequired().HasMaxLength(100);

            user.Property(m => m.Username).IsRequired();
        }
    }
}
