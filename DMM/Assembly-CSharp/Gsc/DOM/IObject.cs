﻿// Decompiled with JetBrains decompiler
// Type: Gsc.DOM.IObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;

namespace Gsc.DOM
{
  public interface IObject : IEnumerable<IMember>, IEnumerable
  {
    int MemberCount { get; }

    bool HasMember(string name);

    bool TryGetValue(string name, out IValue value);

    IValue this[string name] { get; }
  }
}
