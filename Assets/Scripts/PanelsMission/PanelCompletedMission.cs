using Missions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PanelsMission
{
    public class PanelCompletedMission : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _missionNameText, _missionCompletedText;
        [SerializeField] private Image _imageMission;

        private Mission _currentMission;

        public void SetMission(Mission mission)
        {
            _currentMission = mission;
            UpdateMissionValues();
        }

        private void UpdateMissionValues()
        {
            if (_currentMission != null)
            {
                _missionNameText.text = _currentMission.MissionName;
                _missionCompletedText.text = _currentMission.MissionCompletedText;
                //_imageMission.sprite = _currentMission.ImageMission.sprite;
            }
        }
    }
}