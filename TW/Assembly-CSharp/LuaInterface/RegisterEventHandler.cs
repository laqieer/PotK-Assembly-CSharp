// Decompiled with JetBrains decompiler
// Type: LuaInterface.RegisterEventHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Reflection;

#nullable disable
namespace LuaInterface
{
  internal class RegisterEventHandler
  {
    private object target;
    private EventInfo eventInfo;
    private EventHandlerContainer pendingEvents;

    public RegisterEventHandler(
      EventHandlerContainer pendingEvents,
      object target,
      EventInfo eventInfo)
    {
      this.target = target;
      this.eventInfo = eventInfo;
      this.pendingEvents = pendingEvents;
    }

    public Delegate Add(LuaFunction function)
    {
      Delegate handler = CodeGeneration.Instance.GetDelegate(this.eventInfo.EventHandlerType, function);
      this.eventInfo.AddEventHandler(this.target, handler);
      this.pendingEvents.Add(handler, this);
      return handler;
    }

    public void Remove(Delegate handlerDelegate)
    {
      this.RemovePending(handlerDelegate);
      this.pendingEvents.Remove(handlerDelegate);
    }

    internal void RemovePending(Delegate handlerDelegate)
    {
      this.eventInfo.RemoveEventHandler(this.target, handlerDelegate);
    }
  }
}
