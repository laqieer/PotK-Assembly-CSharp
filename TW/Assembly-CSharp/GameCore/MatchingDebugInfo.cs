// Decompiled with JetBrains decompiler
// Type: GameCore.MatchingDebugInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
