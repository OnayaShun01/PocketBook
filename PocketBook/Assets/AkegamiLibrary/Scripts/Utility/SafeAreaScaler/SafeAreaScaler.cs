using UnityEngine;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>セーフエリア</summary>
	///=========================================================
	[ExecuteInEditMode()]
	public class SafeAreaScaler : MonoBehaviour {
		[SerializeField, Header("セーフエリアに設定するフレーム")] private RectTransform rectTransform = null;
		private Rect lastSafeArea = new Rect(0, 0, 0, 0);
		public RectTransform SafeTransform => rectTransform;

		///=========================================================
		/// <summary>セーフエリア適用</summary>
		///=========================================================
		private void ApplySafeArea(Rect area) {
			rectTransform.anchoredPosition = Vector2.zero;
			rectTransform.sizeDelta = Vector2.zero;

			var anchorMin = area.position;
			var anchorMax = area.position + area.size;
			anchorMin.x /= UnityEngine.Screen.width;
			anchorMin.y /= UnityEngine.Screen.height;
			anchorMax.x /= UnityEngine.Screen.width;
			anchorMax.y /= UnityEngine.Screen.height;
			rectTransform.anchorMin = anchorMin;
			rectTransform.anchorMax = anchorMax;

			lastSafeArea = area;
		}

		///=========================================================
		/// <summary>セーフエリア変更監視</summary>
		///=========================================================
		private void Update() {
			// セーフエリアの取り方修正(https://qiita.com/nkjzm/items/e395e6da9ca46963dba9)
			/*
            Display display = Display.displays[0];
            Rect safeArea = UnityEngine.Screen.safeArea;

            float width = safeArea.width / display.renderingWidth;
            float height = safeArea.height / display.renderingHeight;

            rectTransform.sizeDelta = new Vector2(screenRect.rect.width * width, screenRect.rect.height * height);
            rectTransform.transform.position = new Vector3(screenRect.position.x * width, screenRect.position.y * height);
            rectTransform.transform.localPosition = new Vector3(rectTransform.transform.localPosition.x, rectTransform.transform.localPosition.y, 0);
            */
			if (rectTransform == null) { return; }

			Rect safeArea = UnityEngine.Screen.safeArea;

#if UNITY_EDITOR
			if (UnityEngine.Screen.width == 1125 && UnityEngine.Screen.height == 2436) {
				safeArea.y = 102;
				safeArea.height = 2202;
			}
			if (UnityEngine.Screen.width == 2436 && UnityEngine.Screen.height == 1125) {
				safeArea.x = 132;
				safeArea.y = 63;
				safeArea.height = 1062;
				safeArea.width = 2172;
			}
#endif

			if (safeArea != lastSafeArea) {
				ApplySafeArea(safeArea);
			}
		}
	}
}
