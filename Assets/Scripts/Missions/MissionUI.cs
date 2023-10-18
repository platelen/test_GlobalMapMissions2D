using Events;
using PanelsMission;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Missions
{
    public class MissionUI : MonoBehaviour
    {
        [SerializeField] private Mission _mission;
        [SerializeField] private Vector2 _coordinates;
        [SerializeField] private TextMeshProUGUI _textNumberMission;
        [SerializeField] private PanelDescriptionMission _panelDescriptionMission;
        [SerializeField] private PanelCompletedMission _panelCompletedMission;

        private Button _buttonClick;

        public Mission Mission => _mission;

        private void Awake()
        {
            _buttonClick = GetComponent<Button>();
        }

        private void Start()
        {
            _coordinates = transform.position;
            _textNumberMission.text = _mission.MissionNumber;
        }

        private void OnEnable()
        {
            _buttonClick.onClick.AddListener(OpenDescriptionPanel);
            _buttonClick.onClick.AddListener(SetInfoCompletedPanel);
            _buttonClick.onClick.AddListener(SetCoordinatesInDescriptionPanel);
        }

        private void OnDisable()
        {
            _buttonClick.onClick.RemoveListener(OpenDescriptionPanel);
            _buttonClick.onClick.RemoveListener(SetInfoCompletedPanel);
            _buttonClick.onClick.RemoveListener(SetCoordinatesInDescriptionPanel);
        }

        private void OpenDescriptionPanel()
        {
            _panelDescriptionMission.SetMission(_mission);
            MissionManager.Instance.SetSelectedMission(_mission);
            GlobalEvents.SendStartClickOnMission();
        }

        private void SetCoordinatesInDescriptionPanel()
        {
            _panelDescriptionMission.SetCoordinates(_coordinates);
        }

        private void SetInfoCompletedPanel()
        {
            _panelCompletedMission.SetMission(_mission);
            MissionManager.Instance.SetSelectedMission(_mission);
        }
    }
}