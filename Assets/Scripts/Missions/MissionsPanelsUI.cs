using Events;
using UnityEngine;

namespace Missions
{
    public class MissionsPanelsUI : MonoBehaviour
    {
        [SerializeField] private GameObject _panelMissionDescription;
        [SerializeField] private GameObject _panelMissionCompleted;

        private bool _isDescriptionPanelActive;

        private void Awake()
        {
            GlobalEvents.OnStartClickOnMission.AddListener(EnablePanelDescription);
        }

        private void EnablePanelDescription()
        {
            _isDescriptionPanelActive = !_isDescriptionPanelActive;

            if (_isDescriptionPanelActive)
            {
                _panelMissionDescription.SetActive(true);
            }
            else
            {
                _panelMissionDescription.SetActive(false);
            }
        }
    }
}