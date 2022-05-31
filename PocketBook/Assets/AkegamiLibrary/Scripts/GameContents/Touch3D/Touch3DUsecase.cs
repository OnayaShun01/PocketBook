using System.Runtime.InteropServices;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>iOSの触感タッチ</summary>
	///=========================================================
	public class Touch3DUsecase {
		[DllImport("__Internal")]
		private static extern void audioServicePlaySystemSound(int soundId);

		///=========================================================
		/// <summary>再生</summary>
		///=========================================================
		public void PlayTouch3DEffect(Touch3DEffectType touch3DEffectType) {
#if !UNITY_EDITOR && UNITY_IOS
            audioServicePlaySystemSound((int)touch3DEffectType);
#endif
		}
	}
}
