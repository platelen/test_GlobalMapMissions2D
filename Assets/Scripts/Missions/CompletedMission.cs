using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Missions
{
    public class CompletedMission : MonoBehaviour
    {
        [SerializeField] private GameObject _panelCompletedMission;
        [SerializeField] private List<GameObject> _buttonsHero;

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
            EnabledButtonHero();
            StopAllCoroutines();
        }

        private void EnabledButtonHero()
        {
            Mission selectedMission = MissionManager.SelectedMission;
            foreach (var button in _buttonsHero)
            {
                if (selectedMission.NameHeroReward == button.transform.GetChild(1).name)
                {
                    button.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
    }
}