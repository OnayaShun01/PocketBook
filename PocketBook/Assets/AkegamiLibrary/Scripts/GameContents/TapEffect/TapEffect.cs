using DG.Tweening;
using UnityEngine;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>タップエフェクト</summary>
	///=========================================================
	public class TapEffect : MonoBehaviour {
		[SerializeField] private SpriteRenderer sprite1 = default;

		///=========================================================
		/// <summary>開始</summary>
		///=========================================================
		private void Start() {
			var sequence = DOTween.Sequence();
			sequence.Join(sprite1.DOFade(1.0f, 0.1f))
					.Join(sprite1.transform.DOScale(1.0f, 0.5f).SetEase(Ease.OutQuad))
					.Join(sprite1.DOFade(0.0f, 0.4f).SetDelay(0.1f))
					.SetUpdate(true)
					.Play()
					.OnComplete(() => {
						Destroy(gameObject);
					});
		}
	}
}
