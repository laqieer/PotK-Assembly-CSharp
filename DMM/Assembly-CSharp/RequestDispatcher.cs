﻿// Decompiled with JetBrains decompiler
// Type: RequestDispatcher
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Earth;
using System.Collections;

public static class RequestDispatcher
{
  public static IEnumerator EquipGear(
    int changeGearIndex,
    int? afterGearID,
    int playerUnitID,
    System.Action<WebAPI.Response.UserError> errorHandler,
    bool isEarthMode = false)
  {
    if (isEarthMode)
    {
      EarthDataManager instance = Singleton<EarthDataManager>.GetInstance();
      if (afterGearID.HasValue && !instance.EquipGear(playerUnitID, afterGearID.Value))
        errorHandler((WebAPI.Response.UserError) null);
    }
    else
    {
      IEnumerator e = WebAPI.UnitEquip(changeGearIndex, afterGearID, playerUnitID, errorHandler).Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }
}
