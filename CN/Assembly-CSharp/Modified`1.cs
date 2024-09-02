// Decompiled with JetBrains decompiler
// Type: Modified`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class Modified<T> where T : class
{
  private long revision;

  public Modified(long revision) => this.revision = revision;

  public bool Loaded => SMManager.Contains<T>();

  public bool Changed => this.revision != SMManager.Revision<T>();

  public void Commit() => this.revision = SMManager.Revision<T>();

  public void NotifyChanged()
  {
    if (!this.Loaded)
      return;
    SMManager.Change<T>(SMManager.Get<T>());
  }

  public bool IsChangedOnce()
  {
    bool changed = this.Changed;
    this.revision = SMManager.Revision<T>();
    return changed;
  }

  public T Value => SMManager.Get<T>();
}
