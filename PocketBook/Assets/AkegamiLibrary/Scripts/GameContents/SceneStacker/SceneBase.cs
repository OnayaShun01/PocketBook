using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AkegamiLibrary {
	public abstract class SceneBase : MonoBehaviour {
#if UNITY_EDITOR
		///=========================================================
		/// <summary>Editor上で開いているシーンを開始する用</summary>
		///=========================================================
		protected virtual void Start() {
			var scene = SceneManager.GetSceneByName("RootScene");
			if (scene == null || !scene.isLoaded) {
				AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("RootScene", LoadSceneMode.Additive);
			}
		}
#else
	protected virtual void Start() {}

#endif

		///=========================================================
		/// <summary>
		/// シーンがロードされた時の処理
		/// </summary>
		///=========================================================
		public abstract UniTask EnterScene();

	}
}
