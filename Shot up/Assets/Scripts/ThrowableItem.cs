using System;
using UnityEngine;

[Serializable]
public abstract class ThrowableItem : MonoBehaviour
{

	public abstract void Fire(Vector2 target);

}
