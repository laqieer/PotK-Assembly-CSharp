﻿// Decompiled with JetBrains decompiler
// Type: CustomDeck.GearInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;

namespace CustomDeck
{
  public class GearInfo
  {
    public PlayerItem gear { get; private set; }

    public PlayerUnit playerUnit { get; private set; }

    public PlayerItem reisou { get; private set; }

    public GearInfo(PlayerItem gear, PlayerUnit playerUnit, PlayerItem reisou)
    {
      this.gear = gear;
      this.playerUnit = playerUnit;
      this.reisou = reisou;
    }
  }
}
