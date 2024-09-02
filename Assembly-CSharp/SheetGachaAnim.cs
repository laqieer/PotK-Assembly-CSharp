// Decompiled with JetBrains decompiler
// Type: SheetGachaAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

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
