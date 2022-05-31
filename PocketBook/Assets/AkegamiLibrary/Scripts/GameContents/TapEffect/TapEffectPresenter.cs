using UnityEngine;
using Zenject;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>タップエフェクト</summary>
	///=========================================================
	public class TapEffectPresenter : MonoBehaviour {
		[SerializeField] private TapEffectView tapEffectView = default;
		[Inject] private TouchNotifierUsecase touchNotifierUsecase = default;

		///=========================================================
		/// <summary>初期化</summary>
		///=========================================================
		public void Initialize() {
			touchNotifierUsecase.OnPenetrationPressDown += (pos) => {
				tapEffectView.PlayTapEffect(pos);
			};
		}
	}
}
