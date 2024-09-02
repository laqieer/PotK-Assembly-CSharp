// Decompiled with JetBrains decompiler
// Type: GameCore.MoveCompleteResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
