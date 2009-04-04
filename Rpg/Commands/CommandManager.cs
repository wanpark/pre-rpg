using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using Rpg.Runtime;

namespace Rpg
{
    class CommandManager
    {

        public static CommandManager Instance
        {
            get { return Singleton<CommandManager>.Instance; }
        }

        private Dictionary<string, Command> commandsForName;

        private CommandManager()
        {
            commandsForName = new Dictionary<string, Command>();
            AddCommand(new AttackCommand());
            AddCommand(new DefenceCommand());
        }


        public Command Command(String name)
        {
            return commandsForName[name];
        }

        private void AddCommand(Command command)
        {
            commandsForName.Add(command.Name, command);
        }


    }
}
