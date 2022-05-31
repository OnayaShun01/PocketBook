using UnityEngine;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>カメラワーク</summary>
	///=========================================================
	public class CameraworkView : MonoBehaviour {
		[SerializeField] private Camera Camera = default;

		[SerializeField] private Transform trackPosition = default;

		[SerializeField] private Transform topPoint = default;
		[SerializeField] private Transform bottomPoint = default;

		public Transform TopPoint => topPoint;
		public Transform BottomPoint => bottomPoint;

		///=========================================================
		/// <summary>カメラ移動</summary>
		///=========================================================
		public void SetTrackPosition(Vector3 position) {
			trackPosition.position = position;
		}

		///=========================================================
		/// <summary>カメラ移動</summary>
		///=========================================================
		public void Dolly(Vector3 position, float duration) {
		}

		///=========================================================
		/// <summary>振動</summary>
		///=========================================================
		public void Shake() {
		}
	}
}
