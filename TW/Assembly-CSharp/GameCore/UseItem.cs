// Decompiled with JetBrains decompiler
// Type: GameCore.UseItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore
{
  public class UseItem : INode, IParam<int>
  {
    public readonly Node ID;
    public readonly int iID;

    public UseItem(Node id)
    {
      this.ID = (Node) null;
      if (!int.TryParse(id.Text, out this.iID))
        return;
      this.ID = id;
    }

    public float Eval(Func<string, float> convert) => this.ID != null ? 1f : 0.0f;

    public int getParam(Func<string, float> convert) => this.iID;
  }
}
