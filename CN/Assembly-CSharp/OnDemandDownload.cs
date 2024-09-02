// Decompiled with JetBrains decompiler
// Type: OnDemandDownload
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    OnDemandDownload.\u003CWaitLoadAllUnits\u003Ec__IteratorB0F unitsCIteratorB0F = new OnDemandDownload.\u003CWaitLoadAllUnits\u003Ec__IteratorB0F();
    return (IEnumerator) unitsCIteratorB0F;
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadHasUnitResource()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    OnDemandDownload.\u003CWaitLoadHasUnitResource\u003Ec__IteratorB10 resourceCIteratorB10 = new OnDemandDownload.\u003CWaitLoadHasUnitResource\u003Ec__IteratorB10();
    return (IEnumerator) resourceCIteratorB10;
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadUnitResource(IEnumerable<PlayerUnit> xs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CWaitLoadUnitResource\u003Ec__IteratorB11()
    {
      xs = xs,
      \u003C\u0024\u003Exs = xs
    };
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadMaterialUnitResource(IEnumerable<PlayerMaterialUnit> xs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CWaitLoadMaterialUnitResource\u003Ec__IteratorB12()
    {
      xs = xs,
      \u003C\u0024\u003Exs = xs
    };
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadUnitResource(IEnumerable<UnitUnit> xs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CWaitLoadUnitResource\u003Ec__IteratorB13()
    {
      xs = xs,
      \u003C\u0024\u003Exs = xs
    };
  }

  [DebuggerHidden]
  public static IEnumerator WaitLoadUnitResource(IEnumerable<string> paths)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CWaitLoadUnitResource\u003Ec__IteratorB14()
    {
      paths = paths,
      \u003C\u0024\u003Epaths = paths
    };
  }

  [DebuggerHidden]
  public static IEnumerator waitLoadUnitResource(IEnumerable<string> paths)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new OnDemandDownload.\u003CwaitLoadUnitResource\u003Ec__IteratorB15()
    {
      paths = paths,
      \u003C\u0024\u003Epaths = paths
    };
  }
}
