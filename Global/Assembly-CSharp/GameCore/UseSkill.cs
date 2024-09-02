// Decompiled with JetBrains decompiler
// Type: GameCore.UseSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore
{
  public class UseSkill : INode, IParam<int>
  {
    public readonly Node ID;
    public readonly int iID;

    public UseSkill(Node id)
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
