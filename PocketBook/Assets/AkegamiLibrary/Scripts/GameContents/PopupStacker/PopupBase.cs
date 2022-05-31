using DG.Tweening;
using UnityEngine;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>ポップアップのベースクラス</summary>
	///=========================================================
	public class PopupBase : MonoBehaviour {
		[SerializeField] protected CanvasGroup frame = default;

		public System.Action OnPopupClosed;

		///=========================================================
		/// <summary>ポップアップを開く</summary>
		///=========================================================
		public virtual void OpenPopup() {
			gameObject.SetActive(true);

			frame.transform.localScale = Vector3.one * 0.8f;
			frame.alpha = 0.0f;

			var sequence = DOTween.Sequence();
			sequence.Join(frame.transform.DOScale(1.0f, 0.3f))
					.Join(frame.DOFade(1.0f, 0.2f).SetDelay(0.1f))
					.Play();
		}

		///=========================================================
		/// <summary>ポップアップを閉じる</summary>
		///=========================================================
		public virtual void ClosePopup() {
			frame.transform.localScale = Vector3.one;

			var sequence = DOTween.Sequence();
			sequence.Join(frame.transform.DOScale(0.8f, 0.3f))
					.Join(frame.DOFade(0.0f, 0.2f))
					.Play()
					.OnComplete(() => {
						gameObject.SetActive(false);
						OnPopupClosed?.Invoke();
					});
		}
	}
}
