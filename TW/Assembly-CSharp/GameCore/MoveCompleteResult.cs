// Decompiled with JetBrains decompiler
// Type: GameCore.MoveCompleteResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore
{
  [Serializable]
  public class MoveCompleteResult : ActionResult
  {
    public MoveCompleteResult(int r, int c)
    {
      this.row = r;
      this.column = c;
      this.isMove = true;
      this.terminate = true;
    }

    public override ActionResultNetwork ToNetworkLocal(BL env) => new ActionResultNetwork();
  }
}
