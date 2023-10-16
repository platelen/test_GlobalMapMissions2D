using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Heroes
{
    public class HeroUI : MonoBehaviour
    {
        [SerializeField] private Hero _hero;
        [SerializeField] private TextMeshProUGUI _nameHeroText;

        private Button _buttonHero;

        private void Awake()
        {
            _buttonHero = GetComponent<Button>();
        }


        private void Start()
        {
            _nameHeroText.text = _hero.NameHero;
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
            _hero.IsChange = true;
        }
    }
}