// Decompiled with JetBrains decompiler
// Type: UniWebViewHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class UniWebViewHelper
{
  public static int screenHeight => Screen.height;

  public static int screenWidth => Screen.width;

  public static int screenScale => 1;

  public static string streamingAssetURLForPath(string path) => "file:///android_asset/" + path;
}
