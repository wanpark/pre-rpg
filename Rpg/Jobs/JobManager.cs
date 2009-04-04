using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using Rpg.Runtime;

namespace Rpg
{
    class JobManager
    {

        public static JobManager Instance
        {
            get { return Singleton<JobManager>.Instance; }
        }


        public List<Job> Jobs
        {
            get { return jobsForName.Values.ToList<Job>(); }
        }

        private Dictionary<string, Job> jobsForName;

        private JobManager()
        {
        }

        public void LoadContent(ContentManager content)
        {
            jobsForName = new Dictionary<string, Job>();
            foreach (JobContent info in content.Load<List<JobContent>>("Job"))
            {
                AddJob(new Job(info.Name, CommandManager.Instance.Command(info.CommandName), info.MaxHp, info.MaxMp, info.Exp, info.HasSexTexture));
            }
        }


        public Job Job(String name)
        {
            return jobsForName[name];
        }

        private void AddJob(Job job)
        {
            jobsForName.Add(job.Name, job);
        }


    }
}
