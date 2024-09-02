// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace LuaInterface
{
  public abstract class LuaBase : IDisposable
  {
    private bool _Disposed;
    protected int _Reference;
    protected LuaState _Interpreter;
    protected ObjectTranslator translator;
    public string name;
    private int count;

    public LuaBase() => this.count = 1;

    ~LuaBase() => this.Dispose(false);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    public void AddRef() => ++this.count;

    public void Release()
    {
      if (this._Disposed || this.name == null)
      {
        this.Dispose();
      }
      else
      {
        --this.count;
        if (this.count > 0)
          return;
        if (this.name != null)
          LuaScriptMgr.GetMgrFromLuaState(this._Interpreter.L)?.RemoveLuaRes(this.name);
        this.Dispose();
      }
    }

    public virtual void Dispose(bool disposeManagedResources)
    {
      if (this._Disposed)
        return;
      if (this._Reference != 0 && this._Interpreter != null)
      {
        if (disposeManagedResources)
        {
          this._Interpreter.dispose(this._Reference);
          this._Reference = 0;
        }
        else if (this._Interpreter.L != IntPtr.Zero)
        {
          LuaScriptMgr.refGCList.Enqueue(new LuaRef(this._Interpreter.L, this._Reference));
          this._Reference = 0;
        }
      }
      this._Interpreter = (LuaState) null;
      this._Disposed = true;
    }

    protected void PushArgs(IntPtr L, object o) => LuaScriptMgr.PushVarObject(L, o);

    public override bool Equals(object o)
    {
      return o is LuaBase && this._Interpreter.compareRef(((LuaBase) o)._Reference, this._Reference);
    }

    public override int GetHashCode() => this._Reference;
  }
}
