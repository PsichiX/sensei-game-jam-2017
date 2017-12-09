using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class ThrowableItem : MonoBehaviour
{

	public abstract void Fire(Vector2 target);

}
