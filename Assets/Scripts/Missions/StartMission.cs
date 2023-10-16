using System.Collections.Generic;
using Heroes;
using UnityEngine;
using UnityEngine.UI;

namespace Missions
{
    public class StartMission : MonoBehaviour
    {
        [SerializeField] private GameObject _panelDescriptionMission;
        [SerializeField] private List<Hero> _heroes;

        private Button _buttonStartMission;

        private void Awake()
        {
            _buttonStartMission = GetComponent<Button>();
            _buttonStartMission.onClick.AddListener(StartedMission);
        }

        private void StartedMission()
        {
            Mission selectedMission = MissionManager.SelectedMission; // Получаем текущую выбранную миссию

            if (selectedMission != null)
            {
                foreach (Hero heroes in _heroes)
                {
                    if (heroes.IsChange)
                    {
                        MissionManager.Instance.StartMission(selectedMission);
                        heroes.IsChange = false;  // Запускаем выбранную миссию
                    }
                }
                //MissionManager.Instance.StartMission(selectedMission); // Запускаем выбранную миссию
            }
        }
    }
}