// Decompiled with JetBrains decompiler
// Type: DenaLib.IGameLogic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace DenaLib
{
  public interface IGameLogic
  {
    CallbackCenter GetCallbackCenter();

    HFResourceManager GetResourceManager();

    LuaManager GetLuaManager();

    WindowStackManager GetWindowStackManager();
  }
}
