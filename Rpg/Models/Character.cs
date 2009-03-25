using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{

    public enum Sex
    {
        Male,
        Female
    }

    class Character
    {

        public Job Job
        {
            get { return job; }
        }
        private Job job;

        public Sex Sex
        {
            get { return sex; }
        }
        private Sex sex;

        public Character(Sex sex, Job job)
        {
            this.job = job;
            this.sex = sex;
        }

    }
}
