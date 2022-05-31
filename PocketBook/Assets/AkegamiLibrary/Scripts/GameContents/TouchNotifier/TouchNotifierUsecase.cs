using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace AkegamiLibrary {
	///=========================================================
	/// <summary>タッチ管理</summary>
	///=========================================================
	public class TouchNotifierUsecase {
		[Inject] private TouchNotifierModel touchNotifierModel = null;

		private Camera rootCamera;

		public event Action<Vector3> OnPressDown;
		public event Action<Vector3> OnPenetrationPressDown;
		public event Action<Vector3> OnPressUp;
		public event Action<Vector3> OnDrag;
		public event Action<ZoomType> OnZoom;

		///=========================================================
		/// <summary>カメラセット</summary>
		///=========================================================
		public void SetRootCamera(Camera rootCamera) {
			this.rootCamera = rootCamera;
		}

		///=========================================================
		/// <summary>押下処理</summary>
		///=========================================================
		public void CheckPressDown() {
#if UNITY_EDITOR || UNITY_STANDALONE
			if (Input.GetMouseButtonDown(0)) {
				touchNotifierModel.CurrentTouchPosition = rootCamera.ScreenToWorldPoint(Input.mousePosition);

				if (!EventSystem.current.IsPointerOverGameObject()) {
					OnPressDown?.Invoke(touchNotifierModel.CurrentTouchPosition);
					touchNotifierModel.IsDown = true;
				}

				OnPenetrationPressDown?.Invoke(touchNotifierModel.CurrentTouchPosition);
			}

#else
            for (int index = 0; index < Input.touchCount; ++index)
            {
                UnityEngine.Touch touch = Input.GetTouch(index);

                if (touch.phase == TouchPhase.Began)
                {
                    touchNotifierModel.CurrentTouchPosition = rootCamera.ScreenToWorldPoint(touch.position);

                    if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(index).fingerId))
                    {
                        OnPressDown?.Invoke(touchNotifierModel.CurrentTouchPosition);
                        touchNotifierModel.IsDown = true;
                    }

                    OnPenetrationPressDown?.Invoke(touchNotifierModel.CurrentTouchPosition);
                }
            }
#endif
		}

		///=========================================================
		/// <summary>押上処理</summary>
		///=========================================================
		public void CheckPressUp() {
			if (!touchNotifierModel.IsDown) {
				return;
			}

#if UNITY_EDITOR || UNITY_STANDALONE
			if (Input.GetMouseButtonUp(0)) {
				Vector3 position = rootCamera.ScreenToWorldPoint(Input.mousePosition);

				OnPressUp?.Invoke(position);
				touchNotifierModel.IsDown = false;
				touchNotifierModel.IsZoom = false;
			}

#else
            for (int index = 0; index < Input.touchCount; ++index)
            {
                UnityEngine.Touch touch = Input.GetTouch(index);

                if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(index).fingerId))
                {
                    Vector3 position = rootCamera.ScreenToWorldPoint(touch.position);

                    OnPressUp?.Invoke(position);
                    touchNotifierModel.IsDown = false;
                    touchNotifierModel.IsZoom = false;
                }
            }
#endif
		}

		///=========================================================
		/// <summary>ドラッグ処理</summary>
		///=========================================================
		public void CheckDrag() {
			if (!touchNotifierModel.IsDown || touchNotifierModel.IsZoom) {
				return;
			}

#if UNITY_EDITOR || UNITY_STANDALONE
			if (Input.GetMouseButton(0)) {
				touchNotifierModel.CurrentDragPosition = rootCamera.ScreenToWorldPoint(Input.mousePosition);

				// 0.1動かしたら押下判定を解除
				if ((touchNotifierModel.CurrentDragPosition - touchNotifierModel.CurrentTouchPosition).magnitude > 0.2f) {
					OnDrag?.Invoke(touchNotifierModel.CurrentDragPosition - touchNotifierModel.CurrentTouchPosition);
				}
			}

#else
            if (Input.touchCount != 1)
            {
                return;
            }

            UnityEngine.Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                touchNotifierModel.CurrentDragPosition = rootCamera.ScreenToWorldPoint(Input.mousePosition);

                // 0.1動かしたら押下判定を解除
                if ((touchNotifierModel.CurrentDragPosition - touchNotifierModel.CurrentTouchPosition).magnitude > 0.1f)
                {
                    OnDrag?.Invoke(touchNotifierModel.CurrentDragPosition - touchNotifierModel.CurrentTouchPosition);
                }
            }
#endif
		}

		///=========================================================
		/// <summary>ズーム処理</summary>
		///=========================================================
		public void CheckZoom() {
#if UNITY_EDITOR || UNITY_STANDALONE
			float axis = Input.GetAxis("Mouse ScrollWheel");
			if (axis != 0) {
				touchNotifierModel.IsZoom = true;

				OnZoom?.Invoke(axis > 0 ? ZoomType.Out : ZoomType.In);
			}

#else
            if (Input.touchCount < 2)
            {
                return;
            }

            List<UnityEngine.Touch> dragList = new List<UnityEngine.Touch>();

            for (int index = 0; index < Input.touchCount; ++index)
            {
                UnityEngine.Touch touch = Input.GetTouch(index);

                if (touch.phase == TouchPhase.Moved && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(index).fingerId))
                {
                    dragList.Add(touch);

                    if (dragList.Count == 2)
                    {
                        break;
                    }
                }
            }

            if (dragList.Count < 2)
            {
                return;
            }

            Vector3 beforeDrug0 = dragList[0].position;
            Vector3 beforeDrug1 = dragList[1].position;
            Vector3 afterDrug0 = dragList[0].position + dragList[0].deltaPosition;
            Vector3 afterDrug1 = dragList[1].position + dragList[1].deltaPosition;

            float sqrMag0 = (afterDrug0 - beforeDrug1).sqrMagnitude;
            float sqrMag1 = (beforeDrug0 - beforeDrug1).sqrMagnitude;
            float sqrMag2 = (afterDrug1 - beforeDrug0).sqrMagnitude;
            float sqrMag3 = (beforeDrug1 - beforeDrug0).sqrMagnitude;

            if (sqrMag0 < sqrMag1 && sqrMag2 < sqrMag3)
            {
                touchNotifierModel.IsZoom = true;

                OnZoom?.Invoke(ZoomType.In);
            }
            else if (sqrMag0 > sqrMag1 && sqrMag2 > sqrMag3)
            {
                touchNotifierModel.IsZoom = true;

                OnZoom?.Invoke(ZoomType.Out);
            }
#endif
        }

	}
}
