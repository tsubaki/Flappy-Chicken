using UnityEngine;
using System.Collections;

public class ActiveFalse : MonoBehaviour
{
	void Awake ()
	{
		gameObject.SetActive (false);
	}
}
