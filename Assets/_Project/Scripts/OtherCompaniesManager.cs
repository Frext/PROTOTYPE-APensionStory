using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.ScriptableObjects;
using UnityEngine;

namespace _Project.Scripts
{
    [Serializable]
    public class Company
    {
        public int incrementEvery15SecondsValue;
        public CompanyObject companyObjectSO;
    }
    
    public class OtherCompaniesManager : MonoBehaviour
    {
        [SerializeField] private List<Company> companiesList;

        private void Start()
        {
            StartCoroutine(IncrementCompanyValues());
        }

        private IEnumerator IncrementCompanyValues()
        {
            while (true)
            {
                foreach (var company in companiesList)
                {
                    company.companyObjectSO.companyValue += company.incrementEvery15SecondsValue;
                }
                
                yield return new WaitForSeconds(15);
            }
        }
    }
}
