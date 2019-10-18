using UnityEngine;

namespace Library.Combat.Enemy
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(StateController controller);
    }
}