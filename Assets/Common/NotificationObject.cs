using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class NotificationObject<T> : UnityEngine.Events.UnityEvent<T>
{
	private T data;

	public NotificationObject(){}
	public NotificationObject (T t)
	{
		Value = t;
	}

	public T Value {
		get {
			return data;
		}
		set {
			data = value;
			Invoke(data);
		}
	}

	public void Dispose()
	{
		RemoveAllListeners();
	}
}