using Zenject;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>DIコンテナに登録</summary>
	///=========================================================
	public class RootSceneInstaller : MonoInstaller {
		public override void InstallBindings() {
			Container.BindInterfacesAndSelfTo<SceneStackerUsecase>().AsSingle();
			Container.BindInterfacesAndSelfTo<SceneStackerModel>().AsSingle();

			Container.BindInterfacesAndSelfTo<GameTimeModel>().AsSingle();

			Container.BindInterfacesAndSelfTo<TouchNotifierUsecase>().AsSingle();
			Container.BindInterfacesAndSelfTo<TouchNotifierModel>().AsSingle();

			Container.BindInterfacesAndSelfTo<Touch3DUsecase>().AsSingle();
		}
	}
}
