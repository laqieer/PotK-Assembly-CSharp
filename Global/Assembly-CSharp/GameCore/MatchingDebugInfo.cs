// Decompiled with JetBrains decompiler
// Type: GameCore.MatchingDebugInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace GameCore
{
  [Serializable]
  public class MatchingDebugInfo
  {
    public string targetPlayerId;
    public int? targetDeckType;
    public int? targetDeckId;
    public bool ignoreAuth;
    public int? order;
    public int? turns;
    public int? point;
  }
}
