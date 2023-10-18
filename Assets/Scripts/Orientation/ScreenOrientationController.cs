using UnityEngine;

namespace Orientation
{
    public class ScreenOrientationController : MonoBehaviour
    {
        void Start()
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
        }


        public void SetToLandscape()
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

        public void SetToPortrait()
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
}