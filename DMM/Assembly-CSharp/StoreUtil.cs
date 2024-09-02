// Decompiled with JetBrains decompiler
// Type: StoreUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using DeviceKit;

public static class StoreUtil
{
  public static void OpenMyStore()
  {
    string appId = "http://dg-pk.fg-games.co.jp/";
    if (appId.Length > 0)
      App.OpenStore(appId);
    else
      Debug.Log((object) "appHomeUrl is not defined.");
  }
}
