﻿// Decompiled with JetBrains decompiler
// Type: GameCore.UseItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
