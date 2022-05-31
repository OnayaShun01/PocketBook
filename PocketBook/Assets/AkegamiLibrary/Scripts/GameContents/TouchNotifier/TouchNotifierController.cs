using UnityEngine;
using Zenject;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>タッチ管理</summary>
	///=========================================================
	public class TouchNotifierController : MonoBehaviour {
		[Inject] private TouchNotifierUsecase touchNotifierUsecase = null;

		[SerializeField] private Camera rootCamera = null;

		///=========================================================
		/// <summary>初期化</summary>
		///=========================================================
		public void Initialize() {
			touchNotifierUsecase.SetRootCamera(rootCamera);
		}

		///=========================================================
		/// <summary>タッチ監視</summary>
		///=========================================================
		public void Update() {
			touchNotifierUsecase.CheckPressDown();
			touchNotifierUsecase.CheckPressUp();
			touchNotifierUsecase.CheckDrag();
			touchNotifierUsecase.CheckZoom();
		}
	}
}
