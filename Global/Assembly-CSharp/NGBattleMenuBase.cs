// Decompiled with JetBrains decompiler
// Type: NGBattleMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class NGBattleMenuBase : NGMenuBase
{
  public BattleMonoBehaviourStatus bmStatus = new BattleMonoBehaviourStatus();
  protected NGBattleManager battleManager;
  protected BE env_;
  private bool isDoStart;
  private bool asyncStart;
  private bool asyncInitialized;

  [DebuggerHidden]
  protected virtual IEnumerator Start_Original()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGBattleMenuBase.\u003CStart_Original\u003Ec__Iterator675 originalCIterator675 = new NGBattleMenuBase.\u003CStart_Original\u003Ec__Iterator675();
    return (IEnumerator) originalCIterator675;
  }

  protected virtual void Update_Original()
  {
  }

  protected virtual void LateUpdate_Original()
  {
  }

  [DebuggerHidden]
  protected virtual IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGBattleMenuBase.\u003CStart_Battle\u003Ec__Iterator676 battleCIterator676 = new NGBattleMenuBase.\u003CStart_Battle\u003Ec__Iterator676();
    return (IEnumerator) battleCIterator676;
  }

  protected virtual void Update_Battle()
  {
  }

  protected virtual void LateUpdate_Battle()
  {
  }

  protected BE env
  {
    get
    {
      if (this.env_ == null)
      {
        this.battleManager = Singleton<NGBattleManager>.GetInstance();
        if (Object.op_Inequality((Object) this.battleManager, (Object) null))
          this.env_ = this.battleManager.environment;
      }
      return this.env_;
    }
  }

  public void resetEnvironment() => this.env_ = (BE) null;

  [DebuggerHidden]
  public IEnumerator onBattleInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleMenuBase.\u003ConBattleInitSceneAsync\u003Ec__Iterator677()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGBattleMenuBase.\u003ConInitAsync\u003Ec__Iterator678 asyncCIterator678 = new NGBattleMenuBase.\u003ConInitAsync\u003Ec__Iterator678();
    return (IEnumerator) asyncCIterator678;
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleMenuBase.\u003CStart\u003Ec__Iterator679()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    this.Update_Original();
    if (!this.bmStatus.IsBattleManagerCompleted())
      return;
    this.Update_Battle();
  }

  private void LateUpdate()
  {
    this.LateUpdate_Original();
    if (!this.bmStatus.IsBattleManagerCompleted())
      return;
    this.LateUpdate_Battle();
  }

  public virtual void setText(UILabel label, string v) => label.SetTextLocalize(v);

  public virtual void setText(UILabel label, int v)
  {
    label.SetTextLocalize(v.ToString() + string.Empty);
  }

  public bool isStartInitialized()
  {
    return !((Component) this).gameObject.activeSelf || !this.isDoStart || this.bmStatus.IsBattleManagerCompleted();
  }

  public bool isAsyncInitialized => this.asyncInitialized;
}
