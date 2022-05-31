using UnityEngine;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>タップエフェクト</summary>
	///=========================================================
	public class TapEffectView : MonoBehaviour {
		[SerializeField] private GameObject originalTapEffect = default;

		///=========================================================
		/// <summary>タップエフェクト再生</summary>
		///=========================================================
		public void PlayTapEffect(Vector2 position) {
			var effect = Instantiate(originalTapEffect, transform);
			effect.transform.position = position;
		}
	}
}
