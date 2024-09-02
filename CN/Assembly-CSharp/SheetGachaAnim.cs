// Decompiled with JetBrains decompiler
// Type: SheetGachaAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
