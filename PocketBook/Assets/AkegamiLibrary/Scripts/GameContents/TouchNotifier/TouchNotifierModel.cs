using UnityEngine;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>タッチ管理</summary>
	///=========================================================
	public class TouchNotifierModel {
		public Vector3 CurrentTouchPosition { get; set; }
		public Vector3 CurrentDragPosition { get; set; }

		public bool IsDown { get; set; } = false;
		public bool IsZoom { get; set; } = false;
	}
}
