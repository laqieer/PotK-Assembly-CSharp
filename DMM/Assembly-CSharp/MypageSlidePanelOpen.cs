// Decompiled with JetBrains decompiler
// Type: MypageSlidePanelOpen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MypageSlidePanelOpen : MonoBehaviour
{
  private System.Action<MypageSlidePanelOpen> endAction;

  public void Init(System.Action<MypageSlidePanelOpen> action) => this.endAction = action;

  public void StartEffect()
  {
  }

  public void EndEffect() => this.endAction(this);
}
