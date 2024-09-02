// Decompiled with JetBrains decompiler
// Type: BattleUI05PunitiveExpeditionRewardPopupAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BattleUI05PunitiveExpeditionRewardPopupAnim : MonoBehaviour
{
  public System.Action nextCallback;

  public void Init(System.Action callback) => this.nextCallback = callback;

  public void OnFinish()
  {
    if (this.nextCallback == null)
      return;
    this.nextCallback();
  }
}
