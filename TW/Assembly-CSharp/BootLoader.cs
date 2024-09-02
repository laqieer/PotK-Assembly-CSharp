// Decompiled with JetBrains decompiler
// Type: BootLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BootLoader : MonoBehaviour
{
  public static BootLoader Lunch()
  {
    BootLoader orAddComponent = GameObject.Find("DontDestroyObject").GetOrAddComponent<BootLoader>();
    orAddComponent.StartBoot();
    return orAddComponent;
  }

  public bool End { get; private set; }

  private void StartBoot()
  {
    this.End = false;
    this.StopCoroutine("LunchCore");
    this.StartCoroutine("LunchCore");
  }

  [DebuggerHidden]
  private IEnumerator LunchCore()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BootLoader.\u003CLunchCore\u003Ec__IteratorACF()
    {
      \u003C\u003Ef__this = this
    };
  }

  private class BootSequence
  {
    private readonly WebAPI.Response.PlayerBootRelease boot;
    private BootLoader.BootSequence.SequenceStatus status;

    public BootSequence(WebAPI.Response.PlayerBootRelease boot_)
    {
      this.boot = boot_;
      this.isCancelContinueBattle = false;
      this.isPvPBattle = false;
      this.isPvPBattleResult = false;
    }

    public bool isCancelContinueBattle { get; private set; }

    public bool isPvPBattle { get; private set; }

    public bool isPvPBattleResult { get; private set; }

    [DebuggerHidden]
    public IEnumerator Wait()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new BootLoader.BootSequence.\u003CWait\u003Ec__IteratorAD0()
      {
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator PvPClose()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new BootLoader.BootSequence.\u003CPvPClose\u003Ec__IteratorAD1()
      {
        \u003C\u003Ef__this = this
      };
    }

    private enum SequenceStatus
    {
      Noop,
      Wait,
      Break,
      Confirm,
    }
  }
}
