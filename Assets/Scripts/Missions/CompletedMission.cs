using UnityEngine;
using UnityEngine.UI;

namespace Missions
{
    public class CompletedMission : MonoBehaviour
    {
        [SerializeField] private GameObject _panelCompletedMission;

        private Button _buttonCompletedMission;


        private void Awake()
        {
            _buttonCompletedMission = GetComponent<Button>();
            _buttonCompletedMission.onClick.AddListener(OnCompletedMission);
        }

        private void OnCompletedMission()
        {
            Mission selectedMission = MissionManager.SelectedMission; // Получаем текущую выбранную миссию

            if (selectedMission != null)
            {
                MissionManager.Instance.CompleteMission(selectedMission); // Завершаем выбранную миссию
            }

            _panelCompletedMission.SetActive(false);
            StopAllCoroutines();
        }
    }
}