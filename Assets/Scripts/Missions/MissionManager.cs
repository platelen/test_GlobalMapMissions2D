using System;
using System.Collections;
using System.Collections.Generic;
using Heroes;
using TMPro;
using UnityEngine;

namespace Missions
{
    public class MissionManager : MonoBehaviour
    {
        [SerializeField] private List<Mission> missions;
        [SerializeField] private GameObject _panelCompletedMission;
        [SerializeField] private GameObject _panelDescriptionMission;
        [SerializeField] private TextMeshProUGUI _rewardText;
        [SerializeField] private TextMeshProUGUI _windowHero;
        [SerializeField] private TextMeshProUGUI _nameHero;

        private List<Hero> _selectedHeroes = new List<Hero>();
        private string _enterHeroText = "Выбран герой:";
        private string _deleteHeroText = "Удалён герой:";

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
            Mission selectedMission = SelectedMission;

            if (selectedMission != null)
            {
                InfoRewardMission(selectedMission);
            }

            _panelCompletedMission.SetActive(true);
        }

        public void UpdateSelectedHeroes(Hero hero, bool isSelected)
        {
            if (isSelected)
            {
                _windowHero.text = _enterHeroText;
                _nameHero.text = hero.NameHero;
                _selectedHeroes.Add(hero);
            }
            else
            {
                _windowHero.text = _deleteHeroText;
                _nameHero.text = hero.NameHero;
                _selectedHeroes.Remove(hero);
            }
        }

        private void InfoRewardMission(Mission mission)
        {
            _rewardText.text = $"Награда: \nОчки для героев: " + mission.StatsAfterCompletedMission;
        }

        public void StartMission(Mission mission)
        {
            //TODO: можно делать логику с учётом того, какие герои были выбраны.

            mission.MissionStateValue = Mission.MissionState.TemporarilyLocked;
            StartCoroutine(StartTimerToOpenPanelCompletedMission());
        }

        public void CompleteMission(Mission mission)
        {
            mission.MissionStateValue = Mission.MissionState.Completed;

            foreach (Hero hero in _selectedHeroes)
            {
                int missionStats = mission.StatsAfterCompletedMission;
                hero.IncreaseMissionStats(missionStats);
            }

            UnlockNextMissions();
            _selectedHeroes.Clear();
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