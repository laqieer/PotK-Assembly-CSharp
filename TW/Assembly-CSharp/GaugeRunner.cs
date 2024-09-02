// Decompiled with JetBrains decompiler
// Type: GaugeRunner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GaugeRunner
{
  public GameObject obj;
  public float before;
  public float after;
  public int loopNum;
  public bool isLow;
  private static HashSet<string> seQueue = new HashSet<string>();
  private Func<GameObject, int, IEnumerator> levelupCallback;
  private static int mSeChannel;
  private static bool mIsPlayingSE = false;

  public GaugeRunner(
    GameObject obj,
    float before,
    float after,
    int loopNum,
    Func<GameObject, int, IEnumerator> levelupCallback = null,
    bool isLow = false)
  {
    this.obj = obj;
    this.before = !float.IsNaN(before) ? before : 0.0f;
    this.after = !float.IsNaN(after) ? after : 0.0f;
    this.loopNum = loopNum;
    this.levelupCallback = levelupCallback;
    this.isLow = isLow;
    obj.transform.localScale = new Vector3()
    {
      x = this.before,
      y = 1f
    };
  }

  public static void PlaySE()
  {
    if (GaugeRunner.mIsPlayingSE)
      return;
    GaugeRunner.mSeChannel = Singleton<NGSoundManager>.GetInstance().playSE("SE_1014", true);
    GaugeRunner.mIsPlayingSE = true;
  }

  public static void StopSE()
  {
    if (!GaugeRunner.mIsPlayingSE)
      return;
    Singleton<NGSoundManager>.GetInstance().stopSE(GaugeRunner.mSeChannel);
    GaugeRunner.mIsPlayingSE = false;
  }

  public static void PauseSE()
  {
    if (!GaugeRunner.mIsPlayingSE)
      return;
    Singleton<NGSoundManager>.GetInstance().pauseSE(GaugeRunner.mSeChannel);
  }

  public static void ResumeSE()
  {
    if (!GaugeRunner.mIsPlayingSE)
      return;
    Singleton<NGSoundManager>.GetInstance().resumeSE(GaugeRunner.mSeChannel);
  }

  public static void AddSEQueue(string seName) => GaugeRunner.seQueue.Add(seName);

  private static void playQueuedSE()
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    foreach (string se in GaugeRunner.seQueue)
      instance.playSE(se);
    GaugeRunner.seQueue.Clear();
  }

  public static IEnumerator Run(GaugeRunner runner)
  {
    return GaugeRunner.Run(new GaugeRunner[1]{ runner });
  }

  [DebuggerHidden]
  public static IEnumerator Run(GaugeRunner[] runners)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GaugeRunner.\u003CRun\u003Ec__IteratorBEB()
    {
      runners = runners,
      \u003C\u0024\u003Erunners = runners
    };
  }

  [DebuggerHidden]
  public IEnumerator Run()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GaugeRunner.\u003CRun\u003Ec__IteratorBEC()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Run(float from, float to, float duration = 0.6f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GaugeRunner.\u003CRun\u003Ec__IteratorBED()
    {
      from = from,
      to = to,
      duration = duration,
      \u003C\u0024\u003Efrom = from,
      \u003C\u0024\u003Eto = to,
      \u003C\u0024\u003Eduration = duration,
      \u003C\u003Ef__this = this
    };
  }
}
