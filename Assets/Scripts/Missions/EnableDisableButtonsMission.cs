using UnityEngine;
using UnityEngine.UI;

namespace Missions
{
    public class EnableDisableButtonsMission : MonoBehaviour
    {
        private float _alphaValueLocked = 0.5f;
        private float _alphaValueActived = 1f;
        private Image _imageButton;
        private Button _buttonMission;
        private MissionUI _missionUI;

        private void Awake()
        {
            _imageButton = GetComponent<Image>();
            _buttonMission = GetComponent<Button>();
            _missionUI = GetComponent<MissionUI>();
        }

        private void Update()
        {
            ChangeStateButtons();
        }

        private void ChangeStateButtons()
        {
            if (_missionUI.Mission.MissionStateValue == Mission.MissionState.Locked ||
                _missionUI.Mission.MissionStateValue == Mission.MissionState.Completed)
            {
                var newColor = _imageButton.color;
                newColor.a = _alphaValueLocked;
                _imageButton.color = newColor;
                _buttonMission.enabled = false;
            }
            else if (_missionUI.Mission.MissionStateValue == Mission.MissionState.Active)
            {
                var newColorActive = _imageButton.color;
                newColorActive.a = _alphaValueActived;
                _imageButton.color = newColorActive;
                _buttonMission.enabled = true;
            }
        }
    }
}