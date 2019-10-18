using UnityEngine;

namespace Library.Events
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T item);
    }
}