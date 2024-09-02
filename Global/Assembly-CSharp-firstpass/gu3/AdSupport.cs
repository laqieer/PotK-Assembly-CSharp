// Decompiled with JetBrains decompiler
// Type: gu3.AdSupport
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System.Runtime.InteropServices;

#nullable disable
namespace gu3
{
  public static class AdSupport
  {
    public static bool isAdvertisingTrackingEnabled()
    {
      return AdSupport.AdSupport_isAdvertisingTrackingEnabled();
    }

    public static string getAdvertisingIdentifier()
    {
      return AdSupport.AdSupport_getAdvertisingIdentifier();
    }

    public static string getIdentifierForVender() => AdSupport.AdSupport_getIdentifierForVender();

    [DllImport("UnityAdSupportKit")]
    private static extern bool AdSupport_isAdvertisingTrackingEnabled();

    [DllImport("UnityAdSupportKit")]
    private static extern string AdSupport_getAdvertisingIdentifier();

    [DllImport("UnityAdSupportKit")]
    private static extern string AdSupport_getIdentifierForVender();
  }
}
