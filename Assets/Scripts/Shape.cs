using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace com.yhw.tdPrint {

	public class Shape {
		private List<Point> mPoints;
		public List<Point> Points {
			get { return mPoints; }
		}

		public Shape() {
			mPoints = new List<Point>();
		}

		public void AddPoint(Point p) {
			mPoints.Add(p);
		}

		public bool isSelectd(Point p) {
			return false;
		}
	}

}
