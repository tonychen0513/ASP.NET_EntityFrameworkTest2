﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Learning.Data
{
    class LearningContextMigrationConfiguration: DbMigrationsConfiguration<LearningContext>
    {
        public LearningContextMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

#if DEBUG
        protected override void Seed(LearningContext context)
        {
            new LearningDataSeeder(context).Seed();
        }
#endif
    }
}
