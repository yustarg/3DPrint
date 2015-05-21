using UnityEngine;
using System.Collections;

namespace com.yhw.tdPrint {

	public struct Point {
		private Vector2 mCoord;
		public Vector2 Coord {
			get { return mCoord; }
		}

		public Point(Vector2 coord) {
			mCoord = coord;
		}

	}

}