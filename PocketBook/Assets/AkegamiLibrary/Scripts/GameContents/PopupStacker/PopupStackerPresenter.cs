using UnityEngine;
using Zenject;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>ポップアップ管理</summary>
	///=========================================================
	public class PopupStackerPresenter : MonoBehaviour {
		[Inject] private PopupStackerView popupStackerView = default;

		///=========================================================
		/// <summary>初期化</summary>
		///=========================================================
		public void Initialize() {
			popupStackerView.OnPopupCreated += () => {
				if (popupStackerView.StackingCount == 1) {
					//subScreenView.ShowBlackOut();
				}
			};

			popupStackerView.OnPopupRemoved += () => {
				if (popupStackerView.StackingCount == 0) {
					//subScreenView.HideBlackOut();
				}
			};
		}
	}
}
