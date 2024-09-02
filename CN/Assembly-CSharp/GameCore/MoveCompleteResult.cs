// Decompiled with JetBrains decompiler
// Type: GameCore.MoveCompleteResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
