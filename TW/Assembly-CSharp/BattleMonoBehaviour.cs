// Decompiled with JetBrains decompiler
// Type: BattleMonoBehaviour
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    BattleMonoBehaviour.\u003CStart_Original\u003Ec__Iterator880 originalCIterator880 = new BattleMonoBehaviour.\u003CStart_Original\u003Ec__Iterator880();
    return (IEnumerator) originalCIterator880;
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
    BattleMonoBehaviour.\u003CStart_Battle\u003Ec__Iterator881 battleCIterator881 = new BattleMonoBehaviour.\u003CStart_Battle\u003Ec__Iterator881();
    return (IEnumerator) battleCIterator881;
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
    return (IEnumerator) new BattleMonoBehaviour.\u003ConBattleInitSceneAsync\u003Ec__Iterator882()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public virtual IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleMonoBehaviour.\u003ConInitAsync\u003Ec__Iterator883 asyncCIterator883 = new BattleMonoBehaviour.\u003ConInitAsync\u003Ec__Iterator883();
    return (IEnumerator) asyncCIterator883;
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleMonoBehaviour.\u003CStart\u003Ec__Iterator884()
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
