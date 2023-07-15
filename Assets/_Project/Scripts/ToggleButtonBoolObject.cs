using _Project.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    [RequireComponent(typeof(Image), typeof(Button))]
    public class ToggleButtonBoolObject : MonoBehaviour
    {
        [SerializeField] private BoolObject boolObjecttSO;

        private Image image;
        private Button button;

        [SerializeField] private TextMeshProUGUI tmp;
        
        void Start()
        {
            image = GetComponent<Image>();
            button = GetComponent<Button>();
                     
            image.enabled = boolObjecttSO.value;
            button.enabled = boolObjecttSO.value;
            tmp.enabled = boolObjecttSO.value;
        }

        void Update()
        {
            image.enabled = boolObjecttSO.value;
            button.enabled = boolObjecttSO.value;
            tmp.enabled = boolObjecttSO.value;
        }
    }
}