using UnityEngine;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>連番アニメクリップ</summary>
	///=========================================================
	[CreateAssetMenu(menuName = "AkegamiLibrary/FlipAnimationClip")]
	public class FlipAnimationClip : ScriptableObject {
		public enum AnimationCompletedType {
			Clear,
			Stop,
			Loop
		}

		[SerializeField] private Sprite[] sprites = null;
		[SerializeField] private AnimationCompletedType completedType = AnimationCompletedType.Clear;
		[SerializeField] private float interval = default;

		public Sprite[] Sprites => sprites;
		public AnimationCompletedType CompletedType => completedType;
		public float Interval => interval;
	}
}
