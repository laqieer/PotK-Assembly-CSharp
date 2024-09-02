// Decompiled with JetBrains decompiler
// Type: CircularMotionBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class CircularMotionBase : MonoBehaviour
{
  [HideInInspector]
  protected float radius;
  [HideInInspector]
  protected Vector3 CenterPosition;
  [SerializeField]
  protected GameObject Director;
  [SerializeField]
  protected MypageSlidePanelDragged CenterTarget;
  protected const float Displace = -100f;

  public virtual void Init(MypageSlidePanelDragged centerObject)
  {
    Transform transform = this.Director.transform;
    Vector3 localPosition = transform.localPosition;
    Vector3 vector3 = ((IEnumerable<TweenPosition>) transform.parent.GetComponents<TweenPosition>()).Where<TweenPosition>((Func<TweenPosition, bool>) (x => x.tweenGroup == MypageMenuBase.START_TWEEN_GROUP_JOGDIAL)).Select<TweenPosition, Vector3>((Func<TweenPosition, Vector3>) (x => x.to)).First<Vector3>();
    if ((UnityEngine.Object) centerObject != (UnityEngine.Object) null)
      this.CenterTarget = centerObject;
    this.CenterPosition = localPosition + vector3;
    this.CenterPosition.x += -100f;
    this.radius = (float) this.Director.GetComponent<UIWidget>().width;
  }
}
