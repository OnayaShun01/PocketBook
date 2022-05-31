using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>シーン管理</summary>
	///=========================================================
	public class SceneStackerController : MonoBehaviour {
		[Inject] private SceneStackerUsecase sceneStackerUsecase = default;

		[SerializeField] private string firstSceneName = default;

		///=========================================================
		/// <summary>初期化</summary>
		///=========================================================
		public void Initialize() {
		}

		///=========================================================
		/// <summary>ルートシーン読み込み</summary>
		///=========================================================
		public async void LoadRootSceme() {
			// ルートシーン読み込み
			await sceneStackerUsecase.PushScene("RootScene");

			// 起動済みのシーン読み込み
			int sceneCount = SceneManager.sceneCount;
			for (int index = 0; index < sceneCount; index++) {
				var scene = SceneManager.GetSceneAt(index);

				await sceneStackerUsecase.PushScene(scene.name);
			}

			// 初実行シーン読み込み
			await sceneStackerUsecase.PushScene(firstSceneName);
		}
	}
}
