// Decompiled with JetBrains decompiler
// Type: RequestDispatcher
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class RequestDispatcher : MonoBehaviour
{
  [DebuggerHidden]
  public static IEnumerator EquipGear(
    int changeGearIndex,
    int? afterGearID,
    int playerUnitID,
    Action<WebAPI.Response.UserError> errorHandler,
    bool isEarthMode = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new RequestDispatcher.\u003CEquipGear\u003Ec__IteratorC0E()
    {
      isEarthMode = isEarthMode,
      afterGearID = afterGearID,
      playerUnitID = playerUnitID,
      errorHandler = errorHandler,
      changeGearIndex = changeGearIndex,
      \u003C\u0024\u003EisEarthMode = isEarthMode,
      \u003C\u0024\u003EafterGearID = afterGearID,
      \u003C\u0024\u003EplayerUnitID = playerUnitID,
      \u003C\u0024\u003EerrorHandler = errorHandler,
      \u003C\u0024\u003EchangeGearIndex = changeGearIndex
    };
  }
}
