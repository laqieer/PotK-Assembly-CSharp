// Decompiled with JetBrains decompiler
// Type: Clipboard
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
public class Clipboard
{
  private static void _setClipboardText(string text)
  {
    AndroidJavaClass androidJavaClass1 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    AndroidJavaObject androidJavaObject = ((AndroidJavaObject) androidJavaClass1).GetStatic<AndroidJavaObject>("currentActivity");
    AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("jp.co.gu3.plugins.Clipboard");
    ((AndroidJavaObject) androidJavaClass2).CallStatic("setText", new object[2]
    {
      (object) androidJavaObject,
      (object) text
    });
    ((AndroidJavaObject) androidJavaClass2).Dispose();
    androidJavaObject.Dispose();
    ((AndroidJavaObject) androidJavaClass1).Dispose();
  }

  private static string _getClipboardText()
  {
    AndroidJavaClass androidJavaClass1 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    AndroidJavaObject androidJavaObject = ((AndroidJavaObject) androidJavaClass1).GetStatic<AndroidJavaObject>("currentActivity");
    AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("jp.co.gu3.plugins.Clipboard");
    string clipboardText = ((AndroidJavaObject) androidJavaClass2).CallStatic<string>("getText", new object[1]
    {
      (object) androidJavaObject
    });
    ((AndroidJavaObject) androidJavaClass2).Dispose();
    androidJavaObject.Dispose();
    ((AndroidJavaObject) androidJavaClass1).Dispose();
    return clipboardText;
  }

  public static void setText(string val) => Clipboard._setClipboardText(val);

  public static string getText() => Clipboard._getClipboardText();
}
