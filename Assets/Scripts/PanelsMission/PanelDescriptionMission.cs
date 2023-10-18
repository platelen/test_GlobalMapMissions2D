using Missions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PanelsMission
{
    public class PanelDescriptionMission : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _missionNameText, _missionText;
        [SerializeField] private Image _imageMission;
        [SerializeField] private TextMeshProUGUI _coordinatesText;

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
                _missionText.text = _currentMission.MissionText;
                //_imageMission.sprite = _currentMission.ImageMission.sprite;
            }
        }

        public void SetCoordinates(Vector2 coordinates)
        {
            _coordinatesText.text = $"Координаты: ({coordinates.x}, {coordinates.y})";
        }
    }
}