// Decompiled with JetBrains decompiler
// Type: GameCore.ColosseumEnvironment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
