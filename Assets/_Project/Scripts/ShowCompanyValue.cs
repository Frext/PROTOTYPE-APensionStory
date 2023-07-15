using System.Collections;
using _Project.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace _Project.Scripts
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ShowCompanyValue : MonoBehaviour
    {
        [SerializeField] private string precedingText;
        [SerializeField] private CompanyObject companyObjectSO;

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
                textMeshPro.text = precedingText + "\n" + companyObjectSO.companyValue;
                yield return new WaitForSeconds(.25f);
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}