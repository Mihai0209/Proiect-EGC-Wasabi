using UnityEngine;

namespace EGC.StateMachine
{
    public abstract class State
    {
        public abstract void Start();

        public abstract void Finish();
    }
}
