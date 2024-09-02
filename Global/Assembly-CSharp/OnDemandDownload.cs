// Decompiled with JetBrains decompiler
// Type: OnDemandDownload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;

#nullable disable
public class OnDemandDownload
{
  private static Modified<PlayerUnit[]> playerUnitsObserver = (Modified<PlayerUnit[]>) null;
  private static HashSet<int> checkedUnitIds = new HashSet<int>();

  public static long SizeOfLoadAllUnits()
  {
    ResourceManager rm = Singleton<ResourceManager>.GetInstance();
    string[] array = ((IEnumerable<UnitUnit>) MasterData.UnitUnitList).SelectMany<UnitUnit, string>((Func<UnitUnit, IEnumerable<string>>) (x => (IEnumerable<string>) rm.PathsFromUnit(x))).ToArray<string>();
    DLC dlc = rm.CreateDLC(((IEnumerable<string>) array).ToArray<string>());
    return dlc.DownloadRequired ? dlc.GetRequireSize() : 0L;
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadAllUnits()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OnDemandDownload.\u003CWaitLoadAllUnits\u003Ec__Iterator973 unitsCIterator973 = new OnDemandDownload.\u003CWaitLoadAllUnits\u003Ec__Iterator973();
    return (IEnumerator) unitsCIterator973;
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadHasUnitResource()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OnDemandDownload.\u003CWaitLoadHasUnitResource\u003Ec__Iterator974 resourceCIterator974 = new OnDemandDownload.\u003CWaitLoadHasUnitResource\u003Ec__Iterator974();
    return (IEnumerator) resourceCIterator974;
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadUnitResource(IEnumerable<PlayerUnit> xs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CWaitLoadUnitResource\u003Ec__Iterator975()
    {
      xs = xs,
      \u003C\u0024\u003Exs = xs
    };
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadUnitResource(IEnumerable<UnitUnit> xs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CWaitLoadUnitResource\u003Ec__Iterator976()
    {
      xs = xs,
      \u003C\u0024\u003Exs = xs
    };
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadUnitResource(IEnumerable<string> paths)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CWaitLoadUnitResource\u003Ec__Iterator977()
    {
      paths = paths,
      \u003C\u0024\u003Epaths = paths
    };
  }

  [DebuggerHidden]
  public static IEnumerator waitLoadUnitResource(IEnumerable<string> paths)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CwaitLoadUnitResource\u003Ec__Iterator978()
    {
      paths = paths,
      \u003C\u0024\u003Epaths = paths
    };
  }
}
