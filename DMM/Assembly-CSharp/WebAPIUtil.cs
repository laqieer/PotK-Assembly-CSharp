// Decompiled with JetBrains decompiler
// Type: WebAPIUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;

public static class WebAPIUtil
{
  public static Future<WebAPI.Response.UnitSell> UnitSell(
    int[] player_material_unit_ids,
    int[] player_unit_ids,
    System.Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    foreach (int playerUnitId in player_unit_ids)
      MypageUnitUtil.sellUnit(playerUnitId);
    return WebAPI.UnitSell(player_material_unit_ids, player_unit_ids, userErrorCallback);
  }

  public static Future<WebAPI.Response.UnitReservesAdd> UnitReservesAdd(
    int[] player_unit_ids,
    System.Action<WebAPI.Response.UserError> userErrorCallback = null)
  {
    foreach (int playerUnitId in player_unit_ids)
      MypageUnitUtil.sellUnit(playerUnitId);
    return WebAPI.UnitReservesAdd(player_unit_ids, userErrorCallback);
  }
}
