// Decompiled with JetBrains decompiler
// Type: PinchUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class PinchUtil : MonoBehaviour
{
  private float beforeDistance;
  public Action<float> onPinch;
  [SerializeField]
  protected int mouseBoost = 1000;

  public float Distance { get; private set; }

  public bool IsPinching { get; private set; }

  private void Update() => this.UpdatePinch();

  private void UpdateMouseWheel()
  {
    this.Distance = Input.GetAxis("Mouse ScrollWheel") * (float) this.mouseBoost;
    if (this.onPinch == null || (double) this.Distance == 0.0)
      return;
    this.onPinch(this.Distance);
  }

  private void UpdatePinch()
  {
    if (this.onPinch == null || Input.touchCount < 2)
      return;
    Touch touch1 = Input.GetTouch(0);
    Touch touch2 = Input.GetTouch(1);
    if ((((Touch) ref touch1).phase == null || ((Touch) ref touch2).phase == null) && ((Touch) ref touch1).phase != 3 && ((Touch) ref touch2).phase != 3)
    {
      this.beforeDistance = Vector2.Distance(((Touch) ref touch1).position, ((Touch) ref touch2).position);
      this.IsPinching = true;
    }
    else if (((Touch) ref touch1).phase == 3 || ((Touch) ref touch2).phase == 3)
    {
      this.beforeDistance = 0.0f;
      this.IsPinching = false;
    }
    else
    {
      if (((Touch) ref touch1).phase != 1 && ((Touch) ref touch2).phase != 1)
        return;
      this.Distance = Vector2.Distance(((Touch) ref touch1).position, ((Touch) ref touch2).position);
      this.onPinch(this.beforeDistance - this.Distance);
    }
  }
}
