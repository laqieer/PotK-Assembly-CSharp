﻿// Decompiled with JetBrains decompiler
// Type: GuildJoinRequestFailedLimitPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

public class GuildJoinRequestFailedLimitPopup : BackButtonMenuBase
{
  private Guild0285Menu menu;

  public void Initialize()
  {
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();
}
