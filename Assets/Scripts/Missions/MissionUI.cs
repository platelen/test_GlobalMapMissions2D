using Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Missions
{
    public class MissionUI : MonoBehaviour
    {
        [SerializeField] private Mission _mission;
        [SerializeField] private TextMeshProUGUI _textNumberMission;

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
            _buttonClick.onClick.AddListener(GlobalEvents.SendStartClickOnMission);
        }

        private void OnDisable()
        {
            _buttonClick.onClick.RemoveListener(GlobalEvents.SendStartClickOnMission);
        }
    }
}