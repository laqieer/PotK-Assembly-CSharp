// Decompiled with JetBrains decompiler
// Type: UnitPositionExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
