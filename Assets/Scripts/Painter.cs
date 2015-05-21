using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace com.yhw.tdPrint {
	
	public class Painter : MonoBehaviour {

		private Texture2D mTransparentLayer;
		[SerializeField]
		private Texture2D mBaseTexture;

		private List<Shape> mShapes = new List<Shape>();
		private Shape mCurShape;

		void Awake() {
			CreateTransparentLayer();
		}

		private void CreateTransparentLayer() {
			mTransparentLayer = new Texture2D(Screen.width, Screen.height);
			Color32[] cols = mTransparentLayer.GetPixels32(0);
			for( int i = 0; i < cols.Length; ++i ) {
				cols[i] = new Color32(0, 0, 0, 0);
			}
			mTransparentLayer.SetPixels32(cols);
			mTransparentLayer.Apply();
		}

		// Subscribe to events
		void OnEnable(){
			EasyTouch.On_Swipe += On_Swipe;
			EasyTouch.On_SwipeStart += On_SwipeStart;
			EasyTouch.On_SwipeEnd += On_SwipeEnd;
		}
		
		void OnDisable(){
			UnsubscribeEvent();
		}
		
		void OnDestroy(){
			UnsubscribeEvent();
			Drawing.Cleanup(mTransparentLayer, mShapes);
		}
		
		void UnsubscribeEvent(){
			EasyTouch.On_Swipe -= On_Swipe;
			EasyTouch.On_SwipeStart -= On_SwipeStart;
			EasyTouch.On_SwipeEnd -= On_SwipeEnd;
		}	
		
		// Update is called once per frame
		void Update () {
		
		}

		void OnGUI() {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), mBaseTexture);
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), mTransparentLayer);
		}

		private void On_Swipe(Gesture gesture) {
	//		gesture.
			Debug.Log("gesture.position");
			Point p = new Point(gesture.position);
			mCurShape.AddPoint(p);
			Drawing.DrawPoint(mTransparentLayer, p);
		}

		private void On_SwipeStart(Gesture gesture) {
			Debug.Log("on_swipeStart");
			mCurShape = new Shape();
			mShapes.Add(mCurShape);
		}

		private void On_SwipeEnd(Gesture gesture) {
			Debug.Log("on_swipeEnd");
		}
	}

}
