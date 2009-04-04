using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class JobManager
    {

        public static JobManager Instance
        {
            get { return instance; }
        }
        private static readonly JobManager instance = new JobManager();


        public List<Job> Jobs
        {
            get { return jobsForType.Values.ToList<Job>(); }
        }

        private Dictionary<Type, Job> jobsForType;

        private JobManager()
        {
            jobsForType = new Dictionary<Type, Job>();

            Job<Villager>();
            Job<Witch>();
            Job<Cat>();
        }


        public Job Job<T>()
            where T : Job
        {
            Type type = typeof(T);
            if (!jobsForType.ContainsKey(type))
                AddJob<T>();
            return jobsForType[type];
        }

        private void AddJob<T>()
            where T : Job
        {
            Type type = typeof(T);
            jobsForType.Add(type, (Job)Activator.CreateInstance(type));
        }


    }
}
