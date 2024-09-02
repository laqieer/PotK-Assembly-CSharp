// Decompiled with JetBrains decompiler
// Type: AnimationGachaUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class AnimationGachaUnit : MonoBehaviour
{
  public EffectControllerGacha gachaCon;
  public MeshRenderer intervalMeshRenderer;
  public MeshRenderer finishMeshRenderer;
  public float Interval = 0.03f;
  private float nowTime;

  private void FixedUpdate()
  {
    this.nowTime += Time.fixedDeltaTime;
    if ((double) this.nowTime < (double) this.Interval)
      return;
    this.setRandomUnit();
    this.nowTime %= this.Interval;
  }

  private void setRandomUnit()
  {
    if (Object.op_Equality((Object) this.gachaCon, (Object) null) || this.gachaCon.imgList == null || this.gachaCon.imgList.Count <= 0)
      return;
    ((Renderer) this.intervalMeshRenderer).material.mainTexture = (Texture) NC.RandomChoice<Sprite>(this.gachaCon.imgList).texture;
  }
}
