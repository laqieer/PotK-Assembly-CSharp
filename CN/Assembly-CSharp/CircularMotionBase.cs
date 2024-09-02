// Decompiled with JetBrains decompiler
// Type: CircularMotionBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class CircularMotionBase : MonoBehaviour
{
  protected const float Displace = -100f;
  [HideInInspector]
  protected float radius;
  [HideInInspector]
  protected Vector3 CenterPosition;
  [SerializeField]
  protected GameObject Director;
  [SerializeField]
  protected MypageSlidePanelDragged CenterTarget;

  public virtual void Init(MypageSlidePanelDragged centerObject)
  {
    Transform transform = this.Director.transform;
    Vector3 localPosition = transform.localPosition;
    Vector3 vector3 = ((IEnumerable<TweenPosition>) ((Component) transform.parent).GetComponents<TweenPosition>()).Where<TweenPosition>((Func<TweenPosition, bool>) (x => x.tweenGroup == MypageMenu.START_TWEEN_GROUP_JOGDIAL)).Select<TweenPosition, Vector3>((Func<TweenPosition, Vector3>) (x => x.to)).First<Vector3>();
    if (Object.op_Inequality((Object) centerObject, (Object) null))
      this.CenterTarget = centerObject;
    this.CenterPosition = Vector3.op_Addition(localPosition, vector3);
    this.CenterPosition.x += -100f;
    this.radius = (float) this.Director.GetComponent<UIWidget>().width;
  }
}
