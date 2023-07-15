using UnityEngine;

namespace _Project.Scripts
{
    public class ToggleTimescale : MonoBehaviour
    {
        public void Toggle()
        {
            Time.timeScale = Mathf.Approximately(Time.timeScale, 1) ? 0 : 1;
        }
    }
}
