using UnityEngine;
using UnityEngine.UI;

namespace Missions
{
    public class StartMission : MonoBehaviour
    {
        [SerializeField] private GameObject _panelDescriptionMission;

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
                MissionManager.Instance.StartMission(selectedMission); // Запускаем выбранную миссию
            }
        }
    }
}