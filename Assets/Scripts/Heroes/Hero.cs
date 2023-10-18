using UnityEngine;

namespace Heroes
{
    [CreateAssetMenu(fileName = "Hero_", menuName = "Create Heroes/Hero")]
    public class Hero : ScriptableObject
    {
        [SerializeField] private string _nameHero;
        [SerializeField] private int _statsHero;

        private bool _isChange;

        public string NameHero => _nameHero;

        public bool IsChange
        {
            get => _isChange;
            set => _isChange = value;
        }

        public int StatsHero
        {
            get => _statsHero;
            set => _statsHero = value;
        }

        public void IncreaseMissionStats(int stats)
        {
            _statsHero += stats;
        }
    }
}