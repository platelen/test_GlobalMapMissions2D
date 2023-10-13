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
        [SerializeField] private TextMeshProUGUI _textNumberMission;
        [SerializeField] private PanelDescriptionMission _panelDescriptionMission;
        [SerializeField] private PanelCompletedMission _panelCompletedMission;

        private Button _buttonClick;

        private void Awake()
        {
            _buttonClick = GetComponent<Button>();
        }

        private void Start()
        {
            _textNumberMission.text = _mission.MissionNumber;
        }

        private void OnEnable()
        {
            _buttonClick.onClick.AddListener(OpenDescriptionPanel);
            _buttonClick.onClick.AddListener(SetInfoCompletedPanel);
        }

        private void OnDisable()
        {
            _buttonClick.onClick.RemoveListener(OpenDescriptionPanel);
            _buttonClick.onClick.RemoveListener(SetInfoCompletedPanel);
        }

        private void OpenDescriptionPanel()
        {
            _panelDescriptionMission.SetMission(_mission);
            MissionManager.Instance.SetSelectedMission(_mission);
            GlobalEvents.SendStartClickOnMission();
        }

        private void SetInfoCompletedPanel()
        {
            _panelCompletedMission.SetMission(_mission);
            MissionManager.Instance.SetSelectedMission(_mission);
        }
    }
}