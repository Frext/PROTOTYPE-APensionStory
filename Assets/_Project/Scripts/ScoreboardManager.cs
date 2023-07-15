using System.Collections.Generic;
using _Project.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace _Project.Scripts
{
    public class ScoreboardManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> fieldsList;
        [SerializeField] private List<CompanyObject> companyObjectsList;
        
        private const string USER_COMPANY_NAME = "Oyuncu Sirketi";

        void OnEnable()
        {
            SortCompanies();

            for (int i = 0; i < fieldsList.Count; i++)
            {
                TextMeshProUGUI text1 = fieldsList[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>(),
                    text2 = fieldsList[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>(),
                    text3 = fieldsList[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>();

                text2.text = companyObjectsList[i].companyName;
                text3.text = "$" + companyObjectsList[i].companyValue;

                if (companyObjectsList[i].companyName == USER_COMPANY_NAME)
                {
                    text1.color = Color.green;
                    text2.color = Color.green;
                    text3.color = Color.green;
                }

                else
                {
                    text1.color = Color.gray;
                    text2.color = Color.gray;
                    text3.color = Color.gray;
                }
            }
        }

        private void SortCompanies()
        {
            companyObjectsList.Sort((x, y) => y.companyValue.CompareTo(x.companyValue));
        }
    }
}
