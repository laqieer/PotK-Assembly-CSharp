// Decompiled with JetBrains decompiler
// Type: GameCore.MatchingDebugInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
