using System;
using System.Collections.Generic;
using Missions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Heroes
{
    public class HeroUI : MonoBehaviour
    {
        [SerializeField] private Hero _hero;
        [SerializeField] private TextMeshProUGUI _nameHeroText;
        [SerializeField] private TextMeshProUGUI _statsHeroText;
        [SerializeField] private GameObject _imageHeroChange;

        private List<Hero> _selectedHeroes;
        private Button _buttonHero;

        private void Awake()
        {
            _buttonHero = GetComponent<Button>();
        }


        private void Start()
        {
            _nameHeroText.text = _hero.NameHero;
        }

        private void Update()
        {
            _statsHeroText.text = "Stats: " + _hero.StatsHero;
        }

        private void OnEnable()
        {
            _buttonHero.onClick.AddListener(ChangeHero);
        }

        private void OnDisable()
        {
            _buttonHero.onClick.RemoveListener(ChangeHero);
        }

        private void ChangeHero()
        {
            _hero.IsChange = !_hero.IsChange;
            // if (_hero.IsChange)
            // {
            //     _imageHeroChange.SetActive(true);
            // }
            // else
            // {
            //     _imageHeroChange.SetActive(false);
            // }

            MissionManager.Instance.UpdateSelectedHeroes(_hero, _hero.IsChange);
        }
    }
}