using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>音声再生クラス</summary>
	///=========================================================
	public class SoundPlayerView : MonoBehaviour {
		private readonly float BGM_FADE_TIME = 0.5f;
		private readonly float MAX_DECIBEL = 0;
		private readonly float MIN_DECIBEL = -80;

		[SerializeField] private AudioMixer audioMixer = default;
		[SerializeField] private AudioSource bgmAudioSource = default;
		[SerializeField] private AudioSource seAudioSource = default;

		///=========================================================
		/// <summary>BGM音量設定</summary>
		///=========================================================
		public void SetBgmVolume(float volume) {
			audioMixer.DOSetFloat("BGM", MIN_DECIBEL * (1.0f - volume), BGM_FADE_TIME);
		}

		///=========================================================
		/// <summary>SE音量設定</summary>
		///=========================================================
		public void SetSeVolume(float volume) {
			audioMixer.DOSetFloat("SE", MIN_DECIBEL * (1.0f - volume), BGM_FADE_TIME);
		}

		///=========================================================
		/// <summary>マスター音量設定</summary>
		///=========================================================
		public void SetMasterVolume(float volume) {
			audioMixer.DOSetFloat("Master", MIN_DECIBEL * (1.0f - volume), BGM_FADE_TIME);
		}

		///=========================================================
		/// <summary>BGMフェードアウト</summary>
		///=========================================================
		public void FadeOut() {
			audioMixer.DOSetFloat("Fading", MIN_DECIBEL, 1.0f);
		}

		///=========================================================
		/// <summary>BGMフェードイン</summary>
		///=========================================================
		public void FadeIn() {
			audioMixer.DOSetFloat("Fading", MAX_DECIBEL, 1.0f);
		}

		///=========================================================
		/// <summary>BGM再生</summary>
		///=========================================================
		public void PlayBGM(string bgmName) {
			AudioClip clip = Resources.Load(bgmName) as AudioClip;
			if (clip != null) {
				bgmAudioSource.clip = clip;
				bgmAudioSource.Play();
			}
		}

		public void StopBGM() {
		}

		///=========================================================
		/// <summary>効果音再生</summary>
		///=========================================================
		public void PlaySE(string seName) {
			AudioClip clip = Resources.Load(seName) as AudioClip;
			if (clip != null) {
				seAudioSource.PlayOneShot(clip);
			}
		}
	}
}
