// Decompiled with JetBrains decompiler
// Type: LuaInterface.MethodCache
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Reflection;

#nullable disable
namespace LuaInterface
{
  internal struct MethodCache
  {
    private MethodBase _cachedMethod;
    public bool IsReturnVoid;
    public object[] args;
    public int[] outList;
    public MethodArgs[] argTypes;

    public MethodBase cachedMethod
    {
      get => this._cachedMethod;
      set
      {
        this._cachedMethod = value;
        MethodInfo methodInfo = value as MethodInfo;
        if ((object) methodInfo == null)
          return;
        this.IsReturnVoid = (object) methodInfo.ReturnType == (object) typeof (void);
      }
    }
  }
}
