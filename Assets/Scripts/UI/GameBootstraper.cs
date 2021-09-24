using System;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts.UI
{
	public class GameBootstraper : MonoBehaviour 
	{
		private Service.Timer timer = default;
		private CancellationTokenSource cts = default;
		private UIState uiState = UIState.OnMain;
		[SerializeField] private Screen01 screen01 = default;
		[SerializeField] private SideScreen subscreen1 = default;
		[SerializeField] private SideScreen subscreen2 = default;
		[SerializeField] private GameObject autoScreen = default;
		private Action returnedToMain = default;

		private void Awake()
		{
			Init();
		}
		private void Start() => RunTimer();
		private void OnDestroy() => cts.Cancel();
		private void Init() 
		{
			screen01.Button1Clicked = delegate() 
			{
				uiState = UIState.NotOnMain;
				subscreen1.Open(); 
			};
			screen01.Button2Clicked = delegate() 
			{
				uiState = UIState.NotOnMain;
				subscreen2.Open();
			};
			subscreen1.BackButtonClicked = ReturnToMain;
			subscreen2.BackButtonClicked = ReturnToMain;
		}
		private void ReturnToMain() 
		{
			uiState = UIState.OnMain;
			returnedToMain?.Invoke();
		}
		private void RunTimer()
		{
			cts = new CancellationTokenSource();
			timer = new Service.Timer(OnTimerOut, cts.Token);
		}
		private void OnTimerOut() 
		{
			if (uiState == UIState.OnMain)
				autoScreen.SetActive(true);
			else
				returnedToMain = delegate () { autoScreen.SetActive(true); };
		}
	}
	internal enum  UIState
	{
		OnMain,
		NotOnMain
	}
}
