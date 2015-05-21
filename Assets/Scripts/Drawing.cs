using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace com.yhw.tdPrint {

	public class Drawing {

		public static void DrawPoint(Texture2D baseTex, Point p) {
			baseTex.SetPixel((int)p.Coord.x, (int)p.Coord.y, Color.red);
			baseTex.Apply();
		}

		public static void Cleanup(Texture2D baseTex, List<Shape> shapes) {
//			for(int i = 0; i < shapes.Count; i++) {
//				for(int j = 0; j < shapes[i].Points.Count; j++) {
//					baseTex.SetPixel(i, j, new Color(0, 0, 0, 0));
//				}
//			}
		}

	}

}