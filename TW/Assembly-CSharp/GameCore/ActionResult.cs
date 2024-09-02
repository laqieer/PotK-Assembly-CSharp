// Decompiled with JetBrains decompiler
// Type: GameCore.ActionResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore
{
  [Serializable]
  public abstract class ActionResult
  {
    public bool isMove;
    public int row;
    public int column;
    public bool terminate;
    [NonSerialized]
    public bool isCompleted;

    public abstract ActionResultNetwork ToNetworkLocal(BL env);

    public ActionResultNetwork ToNetwork(BL env)
    {
      ActionResultNetwork networkLocal = this.ToNetworkLocal(env);
      networkLocal.isMove = this.isMove;
      networkLocal.row = this.row;
      networkLocal.column = this.column;
      networkLocal.terminate = this.terminate;
      return networkLocal;
    }

    public static ActionResult FromNetworkCommon(ActionResult ar, ActionResultNetwork nw)
    {
      if (ar == null)
        return (ActionResult) null;
      ar.isMove = nw.isMove;
      ar.row = nw.row;
      ar.column = nw.column;
      ar.terminate = nw.terminate;
      return ar;
    }
  }
}
