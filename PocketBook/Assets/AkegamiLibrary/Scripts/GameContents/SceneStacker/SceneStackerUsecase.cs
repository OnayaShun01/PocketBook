using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>シーン管理</summary>
	///=========================================================
	public class SceneStackerUsecase {
		[Inject] private SceneStackerModel sceneStackerModel = null;

		///=========================================================
		/// <summary>スタックしているシーンを破棄してシーンを変更</summary>
		///=========================================================
		public async UniTask ChangeScene(string sceneName) {
			// スタック全破棄
			while (sceneStackerModel.StackingScenes.Count > 0) {
				await PopScene();
			}

			await PushScene(sceneName);
		}

		///=========================================================
		/// <summary>シーンを重ねる</summary>
		///=========================================================
		public async UniTask PushScene(string sceneName) {
			var scene = SceneManager.GetSceneByName(sceneName);
			if (scene == null || !scene.isLoaded) {
				AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

				// ロード待ち
				await new WaitUntil(() => asyncOperation.isDone && scene.isLoaded);
			}

			SceneBase pushedScene = null;

			var gameObjects = scene.GetRootGameObjects();
			foreach (var gameObject in gameObjects) {
				pushedScene = gameObject.GetComponent<SceneBase>();
				if (pushedScene != null) break;
			}

			if (sceneStackerModel.PushScene(sceneName, pushedScene)) {
				await pushedScene.EnterScene();
			}
		}

		///=========================================================
		/// <summary>最前面のシーンを閉じる</summary>
		///=========================================================
		public async UniTask PopScene() {
			string currentSceneName = sceneStackerModel.StackingScenes.Peek().Name;
			sceneStackerModel.PopScene();

			await SceneManager.UnloadSceneAsync(currentSceneName);
		}
	}
}
