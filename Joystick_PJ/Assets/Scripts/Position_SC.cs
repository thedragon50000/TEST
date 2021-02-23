// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class Position_SC : MonoBehaviour
// {
//
//     // Start is called before the first frame update
//     void Start()
//     {
//
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//
//     }
//
//     public class TrackedTouch
//     {
//         public Vector2 startPos;
//         public Vector2 currentPos;
//
//         List<Touch> _touches = new List<Touch>();
//
//
//
//         void _UpdateTouches()
//         {
//
//             int numTouches = Input.touchCount;
//             for (int touchIndex = 0; touchIndex < numTouches; ++touchIndex)
//             {
//                 Touch touch = Input.touches[touchIndex];
//                 if (touch.phase == TouchPhase.Began)
//                 {
//                     Debug.Log("Touch " + touch.fingerId + "Started at : " + touch.position);
//                     TrackedTouch newTouch = new TrackedTouch();
//                     newTouch.startPos = touch.position;
//                     newTouch.currentPos = touch.position;
//                     _touches.Add(touch.fingerId, newTouch);
//                 }
//                 else if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
//                 {
//                     Debug.Log("Touch " + touch.fingerId + "Ended at : " + touch.position);
//                     _touches.Remove(touch.fingerId);
//                 }
//                 else
//                 {
//                     TrackedTouch currentTouch;
//                     if (_touches.TryGetValue(touch.fingerId, out currentTouch))
//                     {
//                         currentTouch.currentPos = touch.position;
//                     }
//                 }
//             }
//
//         }
//
//         protected Vector2 GetScreenJoystick(bool left)
//         {
//             foreach (TrackedTouch touch in _touches.Values)
//             {
//                 float halfScreenWidth = Screen.width * 0.5f;
//                 if ((left && touch.startPos.x < halfScreenWidth) ||
//                     (!left && touch.startPos.x > halfScreenWidth))
//                 {
//                     Vector2 screenJoy = touch.currentPos - touch.startPos;
//                     screenJoy.x = Mathf.Clamp(screenJoy.x / (halfScreenWidth * 0.5f * TouchScreenLookScale), -1f, 1f);
//                     screenJoy.y = Mathf.Clamp(screenJoy.y / (Screen.height * 0.5f * TouchScreenLookScale), -1f, 1f);
//                     return screenJoy;
//                 }
//             }
//
//             return Vector2.zero;
//         }
//     }
// }