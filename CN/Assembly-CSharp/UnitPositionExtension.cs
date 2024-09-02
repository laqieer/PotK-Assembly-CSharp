// Decompiled with JetBrains decompiler
// Type: UnitPositionExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public static class UnitPositionExtension
{
  public static void startMoveRoute(
    this BL.UnitPosition up,
    List<BL.Panel> route,
    float speed,
    BE env)
  {
    BL.Unit unit = up.unit;
    BE.UnitResource unitResource = env.unitResource[up.unit];
    if (!unit.isEnable || Object.op_Equality((Object) unitResource.gameObject, (Object) null))
      return;
    unitResource.unitParts.startMoveRoute(route, speed);
  }

  public static void cancelMove(this BL.UnitPosition up, BE env)
  {
    BL.Unit unit = up.unit;
    BE.UnitResource unitResource = env.unitResource[up.unit];
    if (!unit.isEnable || Object.op_Equality((Object) unitResource.gameObject, (Object) null))
      return;
    unitResource.unitParts.cancelMove(Singleton<NGBattleManager>.GetInstance().defaultUnitSpeed * 3f);
  }

  public static bool isMoving(this BL.UnitPosition up, BE env)
  {
    BL.Unit unit = up.unit;
    BE.UnitResource unitResource = env.unitResource[up.unit];
    return unit.isEnable && !Object.op_Equality((Object) unitResource.gameObject, (Object) null) && unitResource.unitParts.isMoving;
  }
}
