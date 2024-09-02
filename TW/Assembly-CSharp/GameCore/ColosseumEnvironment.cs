// Decompiled with JetBrains decompiler
// Type: GameCore.ColosseumEnvironment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections.Generic;

#nullable disable
namespace GameCore
{
  public class ColosseumEnvironment
  {
    public string colosseumTransactionID;
    public Dictionary<int, BL.Unit> playerUnitDict;
    public Dictionary<int, BL.Unit> opponentUnitDict;
    public Dictionary<int, PlayerItem> playerGearDict;
    public Dictionary<int, PlayerItem> opponentGearDict;
    public Bonus[] bonusList;
    public string today;
  }
}
