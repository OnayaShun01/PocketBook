using UnityEngine;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>ゲーム時間</summary>
	///=========================================================
	public class GameTimeModel {
		public float GameTime { get; private set; }

		public event System.Action OnGameTimeUpdated;

		///=========================================================
		/// <summary>ゲーム時間更新</summary>
		///=========================================================
		public void UpdateGameTime() {
			GameTime += Time.deltaTime;

			OnGameTimeUpdated?.Invoke();
		}

		///=========================================================
		/// <summary>ゲーム時間更新</summary>
		///=========================================================
		public void SetTimeScale(float timeScale) {
			Time.timeScale = timeScale;
		}
	}
}
