
using UnityEngine;

namespace AkegamiLibrary {
	public interface ICameraworkModel {
		Vector3 Position { get; }

		event System.Action OnPositionMoved;
		event System.Action OnShaked;
	}

	///=========================================================
	/// <summary>カメラワーク</summary>
	///=========================================================
	public class CameraworkModel : ICameraworkModel {
		public Vector3 Position { get; private set; }

		public event System.Action OnPositionMoved;
		public event System.Action OnShaked;

		///=========================================================
		/// <summary>カメラ移動</summary>
		///=========================================================
		public void SetPosition(Vector3 position) {
			Position = position;

			OnPositionMoved?.Invoke();
		}

		///=========================================================
		/// <summary>振動エフェクト</summary>
		///=========================================================
		public void Shake() {
			OnShaked?.Invoke();
		}
	}
}
