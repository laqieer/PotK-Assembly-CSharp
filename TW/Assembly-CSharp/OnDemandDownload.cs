// Decompiled with JetBrains decompiler
// Type: OnDemandDownload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  private static Modified<PlayerMaterialUnit[]> playerMaterialUnitsObserver = (Modified<PlayerMaterialUnit[]>) null;
  private static HashSet<int> checkedUnitIds = new HashSet<int>();

  public static void InitVariable()
  {
    OnDemandDownload.playerUnitsObserver = (Modified<PlayerUnit[]>) null;
    OnDemandDownload.playerMaterialUnitsObserver = (Modified<PlayerMaterialUnit[]>) null;
    OnDemandDownload.checkedUnitIds = new HashSet<int>();
  }

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
    OnDemandDownload.\u003CWaitLoadAllUnits\u003Ec__IteratorC03 unitsCIteratorC03 = new OnDemandDownload.\u003CWaitLoadAllUnits\u003Ec__IteratorC03();
    return (IEnumerator) unitsCIteratorC03;
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadHasUnitResource()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OnDemandDownload.\u003CWaitLoadHasUnitResource\u003Ec__IteratorC04 resourceCIteratorC04 = new OnDemandDownload.\u003CWaitLoadHasUnitResource\u003Ec__IteratorC04();
    return (IEnumerator) resourceCIteratorC04;
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadUnitResource(
    IEnumerable<PlayerUnit> xs,
    IEnumerable<string> file_patterns = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CWaitLoadUnitResource\u003Ec__IteratorC05()
    {
      xs = xs,
      file_patterns = file_patterns,
      \u003C\u0024\u003Exs = xs,
      \u003C\u0024\u003Efile_patterns = file_patterns
    };
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadMaterialUnitResource(IEnumerable<PlayerMaterialUnit> xs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CWaitLoadMaterialUnitResource\u003Ec__IteratorC06()
    {
      xs = xs,
      \u003C\u0024\u003Exs = xs
    };
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadUnitResource(
    IEnumerable<UnitUnit> xs,
    IEnumerable<string> file_patterns = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CWaitLoadUnitResource\u003Ec__IteratorC07()
    {
      xs = xs,
      file_patterns = file_patterns,
      \u003C\u0024\u003Exs = xs,
      \u003C\u0024\u003Efile_patterns = file_patterns
    };
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadUnitResource(IEnumerable<string> paths)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CWaitLoadUnitResource\u003Ec__IteratorC08()
    {
      paths = paths,
      \u003C\u0024\u003Epaths = paths
    };
  }

  [DebuggerHidden]
  public static IEnumerator waitLoadUnitResource(IEnumerable<string> paths)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CwaitLoadUnitResource\u003Ec__IteratorC09()
    {
      paths = paths,
      \u003C\u0024\u003Epaths = paths
    };
  }
}
