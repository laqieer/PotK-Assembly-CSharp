// Decompiled with JetBrains decompiler
// Type: BattleMonoBehaviour
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleMonoBehaviour : MonoBehaviour
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
    BattleMonoBehaviour.\u003CStart_Original\u003Ec__Iterator7B5 originalCIterator7B5 = new BattleMonoBehaviour.\u003CStart_Original\u003Ec__Iterator7B5();
    return (IEnumerator) originalCIterator7B5;
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
    BattleMonoBehaviour.\u003CStart_Battle\u003Ec__Iterator7B6 battleCIterator7B6 = new BattleMonoBehaviour.\u003CStart_Battle\u003Ec__Iterator7B6();
    return (IEnumerator) battleCIterator7B6;
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
    return (IEnumerator) new BattleMonoBehaviour.\u003ConBattleInitSceneAsync\u003Ec__Iterator7B7()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleMonoBehaviour.\u003ConInitAsync\u003Ec__Iterator7B8 asyncCIterator7B8 = new BattleMonoBehaviour.\u003ConInitAsync\u003Ec__Iterator7B8();
    return (IEnumerator) asyncCIterator7B8;
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleMonoBehaviour.\u003CStart\u003Ec__Iterator7B9()
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

  public bool isStartInitialized()
  {
    return !((Component) this).gameObject.activeSelf || !this.isDoStart || this.bmStatus.IsBattleManagerCompleted();
  }

  public bool isAsyncInitialized => this.asyncInitialized;
}
