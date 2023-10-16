using System.Collections;
using System.Collections.Generic;
using Heroes;
using UnityEngine;

namespace Missions
{
    public class MissionManager : MonoBehaviour
    {
        [SerializeField] private List<Mission> missions;
        [SerializeField] private GameObject _panelCompletedMission;
        [SerializeField] private GameObject _panelDescriptionMission;

        private List<Hero> _selectedHeroes = new List<Hero>();

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

        public void UpdateSelectedHeroes(Hero hero, bool isSelected)
        {
            if (isSelected)
            {
                Debug.Log($"Выбран {hero.NameHero}");
                _selectedHeroes.Add(hero);
            }
            else
            {
                Debug.Log($"Удалён {hero.NameHero}");
                _selectedHeroes.Remove(hero);
            }
        }

        public void StartMission(Mission mission)
        {
            //TODO: можно делать логику с учётом того, какие герои были выбраны.

            mission.MissionStateValue = Mission.MissionState.TemporarilyLocked;
            StartCoroutine(StartTimerToOpenPanelCompletedMission());

            _selectedHeroes.Clear();
        }

        public void CompleteMission(Mission mission)
        {
            mission.MissionStateValue = Mission.MissionState.Completed;

            UnlockNextMissions();
        }

        private void UnlockNextMissions()
        {
            foreach (Mission mission in missions)
            {
                if (mission.MissionStateValue == Mission.MissionState.Locked)
                {
                    mission.MissionStateValue = Mission.MissionState.Active;
                    break;
                }
            }
        }

        public void SetSelectedMission(Mission mission)
        {
            SelectedMission = mission;
        }
    }
}