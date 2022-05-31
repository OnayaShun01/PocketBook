using UnityEngine;
using Zenject;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>ゲーム時間</summary>
	///=========================================================
	public class GameTimeController : MonoBehaviour {
		[Inject] private GameTimeModel gameTimeModel = null;

		///=========================================================
		/// <summary>更新</summary>
		///=========================================================
		private void Update() {
			gameTimeModel.UpdateGameTime();
		}
	}
}
