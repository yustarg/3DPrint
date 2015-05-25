using UnityEngine;
using System.Collections;


namespace com.yhw.tdPrint {

	public interface IEventHandler {

		bool DoEvent(Event evt);

	}

}