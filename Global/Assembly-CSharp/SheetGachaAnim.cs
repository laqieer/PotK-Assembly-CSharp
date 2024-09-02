// Decompiled with JetBrains decompiler
// Type: SheetGachaAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SheetGachaAnim : MonoBehaviour
{
  private System.Action action;

  public void Init(System.Action act) => this.action = act;

  public void AnimationEnd()
  {
    if (this.action == null)
      return;
    this.action();
  }
}
