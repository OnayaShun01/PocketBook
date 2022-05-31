using UnityEngine;

namespace AkegamiLibrary {
	[System.Serializable]
	public class SoundData {
		[SerializeField] private string soundName = default;
		[SerializeField] private AudioClip audioClip = default;

		public string SoundName => soundName;
		public AudioClip AudioClip => audioClip;
	}
}
