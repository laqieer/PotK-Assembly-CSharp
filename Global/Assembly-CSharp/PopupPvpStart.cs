// Decompiled with JetBrains decompiler
// Type: PopupPvpStart
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class PopupPvpStart : MonoBehaviour
{
  [SerializeField]
  private PopupPvpStart.PopupPvpStartObject playerObjData;
  [SerializeField]
  private PopupPvpStart.PopupPvpStartObject enemyObjData;

  [DebuggerHidden]
  public IEnumerator Initialize(
    string pName,
    string eName,
    int pEmblem,
    int eEmblem,
    List<BL.Unit> pUnits,
    List<BL.Unit> eUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PopupPvpStart.\u003CInitialize\u003Ec__Iterator813()
    {
      pName = pName,
      pEmblem = pEmblem,
      eName = eName,
      eEmblem = eEmblem,
      pUnits = pUnits,
      eUnits = eUnits,
      \u003C\u0024\u003EpName = pName,
      \u003C\u0024\u003EpEmblem = pEmblem,
      \u003C\u0024\u003EeName = eName,
      \u003C\u0024\u003EeEmblem = eEmblem,
      \u003C\u0024\u003EpUnits = pUnits,
      \u003C\u0024\u003EeUnits = eUnits,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Initialize(
    string pName,
    string eName,
    int pEmblem,
    int eEmblem,
    int[] pUnits,
    int[] eUnits)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new PopupPvpStart.\u003CInitialize\u003Ec__Iterator814()
    {
      pName = pName,
      pEmblem = pEmblem,
      eName = eName,
      eEmblem = eEmblem,
      pUnits = pUnits,
      eUnits = eUnits,
      \u003C\u0024\u003EpName = pName,
      \u003C\u0024\u003EpEmblem = pEmblem,
      \u003C\u0024\u003EeName = eName,
      \u003C\u0024\u003EeEmblem = eEmblem,
      \u003C\u0024\u003EpUnits = pUnits,
      \u003C\u0024\u003EeUnits = eUnits,
      \u003C\u003Ef__this = this
    };
  }

  [Serializable]
  private class PopupPvpStartObject
  {
    [SerializeField]
    private UILabel name;
    [SerializeField]
    private UI2DSprite emblem;
    [SerializeField]
    private Transform[] units;

    [DebuggerHidden]
    public IEnumerator SetData(string name, int emblem)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new PopupPvpStart.PopupPvpStartObject.\u003CSetData\u003Ec__Iterator815()
      {
        name = name,
        emblem = emblem,
        \u003C\u0024\u003Ename = name,
        \u003C\u0024\u003Eemblem = emblem,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator CreateUnitsThumPlayer(List<BL.Unit> units, GameObject prefab)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new PopupPvpStart.PopupPvpStartObject.\u003CCreateUnitsThumPlayer\u003Ec__Iterator816()
      {
        units = units,
        prefab = prefab,
        \u003C\u0024\u003Eunits = units,
        \u003C\u0024\u003Eprefab = prefab,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator CreateUnitsThumEnemy(List<BL.Unit> units, GameObject prefab)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new PopupPvpStart.PopupPvpStartObject.\u003CCreateUnitsThumEnemy\u003Ec__Iterator817()
      {
        units = units,
        prefab = prefab,
        \u003C\u0024\u003Eunits = units,
        \u003C\u0024\u003Eprefab = prefab,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator CreateUnitsThumPlayerDebug(int[] units, GameObject prefab)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new PopupPvpStart.PopupPvpStartObject.\u003CCreateUnitsThumPlayerDebug\u003Ec__Iterator818()
      {
        units = units,
        prefab = prefab,
        \u003C\u0024\u003Eunits = units,
        \u003C\u0024\u003Eprefab = prefab,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator CreateUnitsThumEnemyDebug(int[] units, GameObject prefab)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new PopupPvpStart.PopupPvpStartObject.\u003CCreateUnitsThumEnemyDebug\u003Ec__Iterator819()
      {
        units = units,
        prefab = prefab,
        \u003C\u0024\u003Eunits = units,
        \u003C\u0024\u003Eprefab = prefab,
        \u003C\u003Ef__this = this
      };
    }

    [DebuggerHidden]
    public IEnumerator CreateUnitThum(int id, int lv, GameObject prefab, Transform parent)
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new PopupPvpStart.PopupPvpStartObject.\u003CCreateUnitThum\u003Ec__Iterator81A()
      {
        prefab = prefab,
        parent = parent,
        id = id,
        lv = lv,
        \u003C\u0024\u003Eprefab = prefab,
        \u003C\u0024\u003Eparent = parent,
        \u003C\u0024\u003Eid = id,
        \u003C\u0024\u003Elv = lv
      };
    }
  }
}
