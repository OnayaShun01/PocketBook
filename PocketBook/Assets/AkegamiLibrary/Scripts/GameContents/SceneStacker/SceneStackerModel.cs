using System.Collections.Generic;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>シーン管理</summary>
	///=========================================================
	public class SceneStackerModel {
		private Stack<SceneInfo> stackingScenes = new Stack<SceneInfo>();
		public Stack<SceneInfo> StackingScenes => stackingScenes;

		private Dictionary<string, SceneInfo> loadedScenes = new Dictionary<string, SceneInfo>();

		// シーン変更中か
		public bool isSceneChanging;

		///=========================================================
		/// <summary>シーンを重ねる</summary>
		/// <returns>成否</returns>
		///=========================================================
		public bool PushScene(string sceneName, SceneBase sceneBase) {
			if (!loadedScenes.ContainsKey(sceneName)) {
				var sceneInfo = new SceneInfo(sceneBase, sceneName);

				stackingScenes.Push(sceneInfo);
				loadedScenes.Add(sceneName, sceneInfo);

				return true;
			} else {
				return false;
			}
		}

		///=========================================================
		/// <summary>最前面のシーンを閉じる</summary>
		///=========================================================
		public void PopScene() {
			var sceneInfo = stackingScenes.Pop();
			loadedScenes.Remove(sceneInfo.Name);
		}

		///=========================================================
		/// <summary>シーンが既に読み込まれているか</summary>
		///=========================================================
		public bool IsSceneLoaded(string sceneName) {
			return loadedScenes.ContainsKey(sceneName);
		}
	}
}
