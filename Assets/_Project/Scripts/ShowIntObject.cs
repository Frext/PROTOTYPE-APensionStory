using System.Collections;
using _Project.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace _Project.Scripts
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class ShowIntObject : MonoBehaviour
	{
		[SerializeField] private string precedingText;
		[SerializeField] private IntObject intObjectSO;

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
				textMeshPro.text = precedingText + "\n" + intObjectSO.value;
				yield return new WaitForSeconds(.25f);
			}
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}
	}
}