using UnityEngine;
using UnityEngine.Events;

namespace Week_8_Platformer
{
    public class EventsArray : MonoBehaviour
    {
        public UnityEvent[] Event;

        public void StartEvent(int eventIndex)
        {
            Event[eventIndex]?.Invoke();
        }
    }
}