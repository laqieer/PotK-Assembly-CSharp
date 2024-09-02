// Decompiled with JetBrains decompiler
// Type: BootLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BootLoader : MonoBehaviour
{
  public static BootLoader Lunch()
  {
    return GameObject.Find("DontDestroyObject").GetOrAddComponent<BootLoader>();
  }

  public bool End { get; private set; }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BootLoader.\u003CStart\u003Ec__Iterator9F5()
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
      return (IEnumerator) new BootLoader.BootSequence.\u003CWait\u003Ec__Iterator9F6()
      {
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    private IEnumerator PvPClose()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new BootLoader.BootSequence.\u003CPvPClose\u003Ec__Iterator9F7()
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
