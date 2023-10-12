using System.Collections.Generic;
using UnityEngine;

namespace Missions
{
    public class MissionManager : MonoBehaviour
    {
        [SerializeField] private List<Mission> missions;

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
            // Установите начальное состояние для миссий.
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

        public void StartMission(Mission mission)
        {
            // Запустите миссию и установите состояние в TemporarilyLocked.
            mission.MissionStateValue = Mission.MissionState.TemporarilyLocked;
        }

        public void CompleteMission(Mission mission)
        {
            // Завершите миссию и установите состояние в Completed.
            mission.MissionStateValue = Mission.MissionState.Completed;

            // Здесь вы можете также проверить зависимости и разблокировать следующие миссии.
            UnlockNextMissions();
        }

        private void UnlockNextMissions()
        {
            // Разблокируйте следующие миссии после успешного завершения миссии.
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
    }
}