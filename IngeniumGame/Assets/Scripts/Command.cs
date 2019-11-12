using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverPattern;

namespace CommandPattern
{
    public abstract class Command
    {
        public abstract void Execute(GameObject p, Command c);

        public virtual void mP(GameObject p) { }

        public virtual void undo(GameObject p) { }
    }
    public class mouseClick : Command
    {

        public override void Execute(GameObject p, Command c)
        {
            p.GetComponent<Control>().mouse();

            mP(p);

            InputControl.oldCommands.Add(c);
        }
        public override void undo(GameObject p)
        {
            p.transform.Translate(-p.transform.forward * 0.5f);
        }
    }

    
    public class UndoCommand : Command
    {
        //Called when we press a key
        public override void Execute(GameObject t, Command command)
        {
            List<Command> oldCommands = InputControl.oldCommands;

            if (oldCommands.Count > 0)
            {
                Command latestCommand = oldCommands[oldCommands.Count - 1];

                latestCommand.undo(t);

                //Remove the command from the list
                oldCommands.RemoveAt(oldCommands.Count - 1);
            }
        }

        public class ReplayCommand : Command
        {
            public override void Execute(GameObject p, Command command)
            {
                InputControl.shouldStartReplay = true;
            }
        }

    }
}

