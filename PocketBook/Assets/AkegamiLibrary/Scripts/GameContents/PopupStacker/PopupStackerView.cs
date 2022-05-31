using System.Collections.Generic;
using UnityEngine;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>ポップアップ管理</summary>
	///=========================================================
	public class PopupStackerView : MonoBehaviour {
		private List<PopupBase> stackingPopups = new List<PopupBase>();

		public int StackingCount => stackingPopups.Count;

		public event System.Action OnPopupCreated;
		public event System.Action OnPopupRemoved;

		///=========================================================
		/// <summary>ポップアップ生成</summary>
		///=========================================================
		public PopupBase CreatePopup(PopupBase originalPopup) {
			var popup = Instantiate(originalPopup, transform);
			popup.OnPopupClosed += () => Destroy(popup.gameObject);

			popup.OpenPopup();

			stackingPopups.Add(popup);

			OnPopupCreated?.Invoke();

			return popup;
		}

		///=========================================================
		/// <summary>ポップアップ削除</summary>
		///=========================================================
		public void RemovePopup(PopupBase popup) {
			popup.ClosePopup();

			stackingPopups.Remove(popup);

			OnPopupRemoved?.Invoke();
		}
	}
}
