// Decompiled with JetBrains decompiler
// Type: GameCore.ActionResultNetwork
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore
{
  [Serializable]
  public class ActionResultNetwork
  {
    public bool isMove;
    public int row;
    public int column;
    public bool terminate;
  }
}
