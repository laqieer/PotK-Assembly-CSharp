// Decompiled with JetBrains decompiler
// Type: SheetGachaAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
