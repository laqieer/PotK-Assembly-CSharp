// Decompiled with JetBrains decompiler
// Type: Guild028201Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Guild028201Popup : MonoBehaviour
{
  private Guild02811Menu menu;

  public void Initialize(Guild02811Menu guild02811menu) => this.menu = guild02811menu;

  public void onButtonOk()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    this.menu.onButtonSetting();
  }
}
