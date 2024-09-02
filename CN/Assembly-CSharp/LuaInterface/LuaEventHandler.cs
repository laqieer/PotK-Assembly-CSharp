// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaEventHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
namespace LuaInterface
{
  public class LuaEventHandler
  {
    public LuaFunction handler;

    public void handleEvent(object[] args) => this.handler.Call(args);
  }
}
