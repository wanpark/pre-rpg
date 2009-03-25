using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rpg
{
    class Player : Character
    {

        public string Name
        {
            get { return name; }
        }
        private string name;

        public List<Command> Commands
        {
            get
            {
                List<Command> commands = new List<Command>();
                commands.Add(new AttackCommand(this));
                //commands.Add(new DefenceCommand(this));
                return commands;
            }
        }


        public Player(string name, Sex sex, Job job) : base(sex, job)
        {
            this.name = name;
        }

    }
}
