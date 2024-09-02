// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaChunkReader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace LuaInterface
{
  public delegate string LuaChunkReader(IntPtr luaState, ref ReaderInfo data, ref uint size);
}
