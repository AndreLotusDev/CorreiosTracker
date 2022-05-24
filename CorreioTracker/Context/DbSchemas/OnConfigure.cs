using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorreioTracker.Context.DbSchemas
{
    public class OnConfigure
    {
        public DbContextOptionsBuilder Builder { get; set; }

        public OnConfigure(DbContextOptionsBuilder builder)
        {
            Builder = builder;
        }

        public void Start()
        {
        }
    }
}
