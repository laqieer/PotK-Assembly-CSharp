// Decompiled with JetBrains decompiler
// Type: UniWebViewHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class UniWebViewHelper
{
  public static int screenHeight => Screen.height;

  public static int screenWidth => Screen.width;

  public static int screenScale => 1;

  public static string streamingAssetURLForPath(string path) => "file:///android_asset/" + path;
}
