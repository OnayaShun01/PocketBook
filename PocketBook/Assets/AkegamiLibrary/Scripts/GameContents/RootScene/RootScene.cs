using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>ルートシーン</summary>
	///=========================================================
	public class RootScene : SceneBase {
		[SerializeField] private SceneStackerController sceneStackerController = null;
		[SerializeField] private TouchNotifierController touchNotifierController = null;
		[SerializeField] private TapEffectPresenter tapEffectPresenter = null;

		///=========================================================
		/// <summary>開始</summary>
		///=========================================================
		protected override void Start() {
			base.Start();

			sceneStackerController.Initialize();
			touchNotifierController.Initialize();
			tapEffectPresenter.Initialize();

			sceneStackerController.LoadRootSceme();
		}

		///=========================================================
		/// <summary>開始</summary>
		///=========================================================
		public override async UniTask EnterScene() {
			await UniTask.Yield();
		}
	}
}
