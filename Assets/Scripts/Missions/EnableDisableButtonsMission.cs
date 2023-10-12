using UnityEngine;
using UnityEngine.UI;

namespace Missions
{
    public class EnableDisableButtonsMission : MonoBehaviour
    {
        private float _alphaValue = 0.5f;
        private Image _imageButton;
        private Button _buttonMission;

        private void Awake()
        {
            _imageButton = GetComponent<Image>();
            _buttonMission = GetComponent<Button>();
        }

        private void Start()
        {
            ChangeAlpha();
        }

        private void ChangeAlpha()
        {
            var newColor = _imageButton.color;
            newColor.a = _alphaValue;
            _imageButton.color = newColor;
        }
    }
}