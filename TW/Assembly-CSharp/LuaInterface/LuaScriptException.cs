// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaScriptException
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace LuaInterface
{
  public class LuaScriptException : LuaException
  {
    private bool isNet;
    private readonly string source;

    public LuaScriptException(string message, string source)
      : base(message)
    {
      this.source = source;
    }

    public LuaScriptException(Exception innerException, string source)
      : base(innerException.Message, innerException)
    {
      this.source = source;
      this.IsNetException = true;
    }

    public bool IsNetException
    {
      get => this.isNet;
      set => this.isNet = value;
    }

    public override string Source => this.source;

    public override string ToString()
    {
      return this.GetType().FullName + ": " + this.source + this.Message;
    }
  }
}
