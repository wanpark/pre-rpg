using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class Player : Character
    {

        public override Party Party
        {
            get { return Party.Player; }
        }

        public string Name
        {
            get { return name; }
        }
        private string name;

        public event EventHandler JobMaster;

        public List<Command> Commands
        {
            get
            {
                List<Command> commands = new List<Command>();
                commands.Add(Job.Command);
                return commands;
            }
        }

        private Dictionary<Job, int> expForJob;

        public Player(string name, Sex sex, Job job) : base(sex, job)
        {
            this.name = name;
            expForJob = new Dictionary<Job, int>();
        }


        public int Exp(Job job)
        {
            if (expForJob.ContainsKey(job))
                return expForJob[job];
            return 0;
        }

        public void AddExp()
        {
            bool mastered = Exp(Job) >= Job.Exp;
            int exp = expForJob[Job] = Exp(Job) + 1;
            if (!mastered && exp >= Job.Exp)
            {
                OnJobMaster();
            }
        }

        protected void OnJobMaster()
        {
            if (JobMaster != null)
                JobMaster(this, EventArgs.Empty);
        }
    }
}
