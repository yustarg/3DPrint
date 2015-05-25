using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace com.yhw.tdPrint { 

	public class EventDispatcher : MonoBehaviour {

		private static EventDispatcher _instance;

		public static EventDispatcher Instance {

			get {
				if(_instance == null) {
					_instance = GameObject.Find("EventDispatcher").GetComponent<EventDispatcher>();
				}
				return _instance;
			}
		}

		public const string EVT_CLICK_LINE_TOOL = "EVT_CLICK_LINE_TOOL";
		public const string EVT_CLICK_CIRCLE_TOOL = "EVT_CLICK_CIRCLE_TOOL";


		private Dictionary<string, List<GameObject>> eventDic = new Dictionary<string, List<GameObject>>();


		public void PushEvent(string eventId) {
			if (eventDic.ContainsKey (eventId)) {
				List<GameObject> receivers;
				if (eventDic.TryGetValue (eventId, out receivers)) {
					for(int i = 0; i < receivers.Count; i++) {
						receivers[i].GetComponent<IEventHandler>().DoEvent(new Event(eventId));
					}
				}
			} else {
				Debug.LogWarning("no event!!");
			}
		}

		public void Register(string eventId, GameObject eventReceiver) {
			if (eventDic.ContainsKey (eventId)) {
				List<GameObject> receivers;
				if (eventDic.TryGetValue (eventId, out receivers)) {
					receivers.Add (eventReceiver);
				}else {
					Debug.LogError ("Can't add receiver !!");
					return;
				}
				eventDic[eventId] = receivers;
			} else {
				eventDic.Add(eventId, new List<GameObject>() { eventReceiver });
			}
		}

		public void UnRegister(string eventId, GameObject eventReceiver) {
			if (eventDic.ContainsKey (eventId)) {
				List<GameObject> receivers;
				if (eventDic.TryGetValue (eventId, out receivers)) {
					if (receivers.Contains (eventReceiver)) {
						receivers.Remove (eventReceiver);
					}
				} else {
					Debug.LogError ("Can't remove receiver !!");
					return;
				}
				if(receivers.Count > 0) {
					eventDic [eventId] = receivers;
				}else {
					eventDic.Remove(eventId);
				}
			} else {
				Debug.LogWarning ("No eventId to remove !!");
			}
		}
	}
}
