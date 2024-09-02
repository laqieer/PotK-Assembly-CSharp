// Decompiled with JetBrains decompiler
// Type: NGBattleMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    NGBattleMenuBase.\u003CStart_Original\u003Ec__Iterator7BB originalCIterator7Bb = new NGBattleMenuBase.\u003CStart_Original\u003Ec__Iterator7BB();
    return (IEnumerator) originalCIterator7Bb;
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
    NGBattleMenuBase.\u003CStart_Battle\u003Ec__Iterator7BC battleCIterator7Bc = new NGBattleMenuBase.\u003CStart_Battle\u003Ec__Iterator7BC();
    return (IEnumerator) battleCIterator7Bc;
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
    return (IEnumerator) new NGBattleMenuBase.\u003ConBattleInitSceneAsync\u003Ec__Iterator7BD()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGBattleMenuBase.\u003ConInitAsync\u003Ec__Iterator7BE asyncCIterator7Be = new NGBattleMenuBase.\u003ConInitAsync\u003Ec__Iterator7BE();
    return (IEnumerator) asyncCIterator7Be;
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGBattleMenuBase.\u003CStart\u003Ec__Iterator7BF()
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
