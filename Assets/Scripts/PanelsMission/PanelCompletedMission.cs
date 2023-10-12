using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PanelsMission
{
    public class PanelCompletedMission:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _missionNameText, _missionCompletedText;
        [SerializeField] private Image _imageMission;
    }
}