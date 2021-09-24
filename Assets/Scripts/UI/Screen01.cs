using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
	public class Screen01 : MonoBehaviour
	{
		[SerializeField] private Button redButton = default;
		[SerializeField] private Button blueButton = default;
		public Action Button1Clicked = default;
		public Action Button2Clicked = default;
		private void Awake()
		{
			PrepareButtons();
		}
		private void PrepareButtons() 
		{
			redButton.onClick.RemoveAllListeners();
			redButton.onClick.AddListener(()=> { Button1Clicked?.Invoke(); });
			blueButton.onClick.RemoveAllListeners();
			blueButton.onClick.AddListener(()=> { Button2Clicked?.Invoke(); });
		}
	}
}
