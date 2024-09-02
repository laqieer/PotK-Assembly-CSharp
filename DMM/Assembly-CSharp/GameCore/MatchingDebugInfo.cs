// Decompiled with JetBrains decompiler
// Type: GameCore.MatchingDebugInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

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
