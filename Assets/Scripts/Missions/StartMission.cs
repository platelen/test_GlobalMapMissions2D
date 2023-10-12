using UnityEngine;
using UnityEngine.UI;

namespace Missions
{
    public class StartMission : MonoBehaviour
    {
        private Button _buttonStartMission;


        private void Awake()
        {
            _buttonStartMission.GetComponent<Button>();
            _buttonStartMission.onClick.AddListener(StartedMission);
        }

        private void StartedMission()
        {
        }
    }
}