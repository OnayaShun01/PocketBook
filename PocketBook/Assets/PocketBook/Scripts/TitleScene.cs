using AkegamiLibrary;
using Cysharp.Threading.Tasks;

namespace PocketBook {
	///=========================================================
	/// <summary>ルートシーン</summary>
	///=========================================================
	public class TitleScene : SceneBase {
		///=========================================================
		/// <summary>開始</summary>
		///=========================================================
		protected override void Start() {
			base.Start();
		}

		///=========================================================
		/// <summary>開始</summary>
		///=========================================================
		public override async UniTask EnterScene() {
			await UniTask.Yield();
		}
	}
}
