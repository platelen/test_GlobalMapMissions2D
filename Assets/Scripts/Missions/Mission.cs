using System.Collections.Generic;
using UnityEngine;

namespace Missions
{
    [CreateAssetMenu(fileName = "Mission_", menuName = "Create Missions/Mission")]
    public class Mission : ScriptableObject
    {
        [SerializeField] private string _missionNumber;
        [SerializeField] private string _missionName;
        [SerializeField] private string _missionText;
        [SerializeField] private string _missionCompletedText;
        [SerializeField] private MissionState _missionState;
        [SerializeField] private List<Mission> _prerequisites;
        [SerializeField] private Faction _playerSide;
        [SerializeField] private Faction _enemySide;
        [SerializeField] private Vector2 _screenCoordinates;


        public enum MissionState
        {
            Active,
            Locked,
            TemporarilyLocked,
            Completed
        }

        public enum Faction
        {
            Player,
            Enemy
        }

        public string MissionNumber => _missionNumber;
    }
}