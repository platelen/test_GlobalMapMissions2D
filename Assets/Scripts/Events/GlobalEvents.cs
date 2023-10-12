using Missions;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GlobalEvents : MonoBehaviour
    {
        public static readonly UnityEvent OnStartClickOnMission = new UnityEvent();
        public static readonly UnityEvent OnStartEnableCompletedMission = new UnityEvent();
        public static readonly UnityEvent OnStartDisablePanelDescription = new UnityEvent();
        public static readonly UnityEvent OnStartDisablePanelCompletedMission = new UnityEvent();


        public static void SendStartClickOnMission()
        {
            OnStartClickOnMission.Invoke();
        }

        public static void SendStartEnableCompletedMission()
        {
            OnStartEnableCompletedMission.Invoke();
        }

        public static void SendStartDisablePanelDescription()
        {
            OnStartDisablePanelDescription.Invoke();
        }

        public static void SendStartDisablePanelCompletedMission()
        {
            OnStartDisablePanelCompletedMission.Invoke();
        }
    }
}