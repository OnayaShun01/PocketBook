namespace AkegamiLibrary {
	public enum SceneTransitionType {
		Change,
		Push,
		Pop
	}

	public class SceneInfo {
		public SceneBase Scene { get; }
		public string Name { get; }

		public SceneInfo(SceneBase scene, string name) {
			Scene = scene;
			Name = name;
		}
	}
}
