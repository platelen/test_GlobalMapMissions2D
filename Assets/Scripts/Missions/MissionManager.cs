using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missions
{
    public class MissionManager : MonoBehaviour
    {
        [SerializeField] private List<Mission> missions;
        [SerializeField] private GameObject _panelCompletedMission;
        [SerializeField] private GameObject _panelDescriptionMission;

        public static Mission SelectedMission { get; private set; }
        public static MissionManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            InitializeMissions();
        }

        private void InitializeMissions()
        {
            bool foundActiveMission = false;

            foreach (Mission mission in missions)
            {
                if (!foundActiveMission)
                {
                    mission.MissionStateValue = Mission.MissionState.Active;
                    foundActiveMission = true;
                }
                else
                {
                    mission.MissionStateValue = Mission.MissionState.Locked;
                }
            }
        }

        private IEnumerator StartTimerToOpenPanelCompletedMission()
        {
            _panelDescriptionMission.SetActive(false);
            yield return new WaitForSeconds(2f);
            _panelCompletedMission.SetActive(true);
        }

        public void StartMission(Mission mission)
        {
            mission.MissionStateValue = Mission.MissionState.TemporarilyLocked;
            StartCoroutine(StartTimerToOpenPanelCompletedMission());
        }

        public void CompleteMission(Mission mission)
        {
            mission.MissionStateValue = Mission.MissionState.Completed;

            UnlockNextMissions();
        }

        private void UnlockNextMissions()
        {
            bool foundActiveMission = false;

            foreach (Mission mission in missions)
            {
                if (foundActiveMission)
                {
                    mission.MissionStateValue = Mission.MissionState.Active;
                    foundActiveMission = true;
                }
            }
        }

        public void SetSelectedMission(Mission mission)
        {
            SelectedMission = mission;
        }
    }
}