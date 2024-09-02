// Decompiled with JetBrains decompiler
// Type: LuaInterface.EventHandlerContainer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace LuaInterface
{
  internal class EventHandlerContainer : IDisposable
  {
    private Dictionary<Delegate, RegisterEventHandler> dict = new Dictionary<Delegate, RegisterEventHandler>();

    public void Add(Delegate handler, RegisterEventHandler eventInfo)
    {
      this.dict.Add(handler, eventInfo);
    }

    public void Remove(Delegate handler) => this.dict.Remove(handler);

    public void Dispose()
    {
      foreach (KeyValuePair<Delegate, RegisterEventHandler> keyValuePair in this.dict)
        keyValuePair.Value.RemovePending(keyValuePair.Key);
      this.dict.Clear();
    }
  }
}
