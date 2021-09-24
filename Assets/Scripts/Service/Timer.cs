using System;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts.Service
{
	public class Timer
	{
		private const int MIn_TIME = 10000;
		private const int MAX_TIME = 20000;
		public Timer(Action onTimeOut, CancellationToken ct)
		{
			var rand = new Random();
			var timeToWait = rand.Next(MIn_TIME, MAX_TIME);
			StartTimer(timeToWait, ct, onTimeOut);
		}

		private async void StartTimer(int timeToW8, CancellationToken ct, Action onTimeOut) 
		{
			await Task.Delay(timeToW8, ct);
			onTimeOut?.Invoke();
		}
	}
}
