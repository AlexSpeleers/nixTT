using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
	public class SideScreen : MonoBehaviour
	{
		[SerializeField] private CanvasGroup canvasGroup = default;
		[SerializeField] private Button backButton = default;
		[SerializeField] private Button mainButton = default;
		[Header("Sub window")]
		[SerializeField] private CanvasGroup subCanvasGroup = default;
		[SerializeField] private Button subBackButton = default;
		public Action BackButtonClicked = default;

		private void Awake()
		{
			PrepareButtons();
		}
		private void PrepareButtons() 
		{
			backButton.onClick.RemoveAllListeners();
			backButton.onClick.AddListener(() =>
			{
				Close();
				BackButtonClicked?.Invoke();
			});
			mainButton.onClick.RemoveAllListeners();
			mainButton.onClick.AddListener(()=>
			{
				EnableCanvasGroup(subCanvasGroup);
			});
			subBackButton.onClick.RemoveAllListeners();
			subBackButton.onClick.AddListener(() => 
			{
				DisableCanvasGroup(subCanvasGroup);
			});
		}
		private void Close() => DisableCanvasGroup(canvasGroup);

		public void Open() => EnableCanvasGroup(canvasGroup);

		private void EnableCanvasGroup(CanvasGroup canvasG) 
		{
			canvasG.alpha = 1;
			canvasG.interactable = true;
			canvasG.blocksRaycasts = true;
		}
		private void DisableCanvasGroup(CanvasGroup canvasG) 
		{
			canvasG.alpha = 0;
			canvasG.interactable = false;
			canvasG.blocksRaycasts = false;
		}
	}
}
