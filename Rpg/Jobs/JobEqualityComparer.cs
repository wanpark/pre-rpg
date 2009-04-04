using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class JobEqualityComparer : IEqualityComparer<Job>
    {

        public bool Equals(Job x, Job y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Job job)
        {
            return job.Name.GetHashCode();
        }

    }
}
