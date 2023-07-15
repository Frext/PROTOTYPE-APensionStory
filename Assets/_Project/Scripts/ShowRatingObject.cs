using System.Collections;
using _Project.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace _Project.Scripts
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ShowRatingObject : MonoBehaviour
    {
        [SerializeField] private string precedingText;
        [SerializeField] private RatingObject ratingObjectSO;

        TextMeshProUGUI textMeshPro;

		
        void Awake()
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }
		
        void OnEnable()
        {
            StartCoroutine(IUpdateText());
        }

        IEnumerator IUpdateText()
        {
            while (true)
            {
                textMeshPro.text = precedingText + "\n" + ratingObjectSO.value;
                yield return new WaitForSeconds(.25f);
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}