// Decompiled with JetBrains decompiler
// Type: UniWebViewHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class UniWebViewHelper
{
  public static int screenHeight => Screen.height;

  public static int screenWidth => Screen.width;

  public static int screenScale => 1;

  public static string streamingAssetURLForPath(string path) => "file:///android_asset/" + path;
}
