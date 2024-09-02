// Decompiled with JetBrains decompiler
// Type: GuildJoinRequestFailedLimitPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class GuildJoinRequestFailedLimitPopup : BackButtonMenuBase
{
  private Guild0285Menu menu;

  public void Initialize()
  {
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();
}
