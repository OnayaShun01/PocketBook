using UnityEngine;
using UnityEngine.UI;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>連番アニメ再生器</summary>
	///=========================================================
	public class FlipAnimator : MonoBehaviour {
		[SerializeField] private Image image = null;

		private FlipAnimationClip flipAnimationClip;
		private bool isPlay = false;
		private int counter;
		private bool isDestroyed = false;

		private float time;

		///=========================================================
		/// <summary>クリップからアニメ再生</summary>
		///=========================================================
		public void PlayAnimation(FlipAnimationClip clip, int startCount = 0) {
			if (isDestroyed == true || clip == null || clip.Sprites.Length == 0 || flipAnimationClip == clip) {
				return;
			}

			flipAnimationClip = clip;
			isPlay = true;
			counter = startCount;

			image.sprite = clip.Sprites[0];
		}

		///=========================================================
		/// <summary>アニメ終了</summary>
		///=========================================================
		public void StopAnimation() {
			image.sprite = null;

			flipAnimationClip = null;
			isPlay = false;
			counter = 0;
		}

		///=========================================================
		/// <summary>アニメ停止</summary>
		///=========================================================
		public void PauseAnimation() {
			isPlay = false;
		}

		///=========================================================
		/// <summary>更新</summary>
		///=========================================================
		private void Update() {
			if (!isPlay) {
				return;
			}

			time += Time.deltaTime;
			if (time >= flipAnimationClip.Interval) {
				image.sprite = flipAnimationClip.Sprites[counter % flipAnimationClip.Sprites.Length];

				counter++;

				if (counter >= flipAnimationClip.Sprites.Length) {
					if (flipAnimationClip.CompletedType == FlipAnimationClip.AnimationCompletedType.Clear) {
						StopAnimation();
					} else if (flipAnimationClip.CompletedType == FlipAnimationClip.AnimationCompletedType.Stop) {
						StopAnimation();
					}
				}

				time -= flipAnimationClip.Interval;
			}
		}

		private void OnDestroy() {
			isDestroyed = true;
		}
	}
}
