using UnityEngine;
using System.Collections;
using com.yhw.tdPrint;

public class EvtTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		EventDispatcher.Instance.PushEvent (EventDispatcher.EVT_CLICK_LINE_TOOL);
	}
}
