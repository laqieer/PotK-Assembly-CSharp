// Decompiled with JetBrains decompiler
// Type: gu3.Device.DeviceManager
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
namespace gu3.Device
{
  public class DeviceManager
  {
    private const string LIBNAME = "UnityDeviceManager";
    private static DeviceManager _instance;

    private DeviceManager()
    {
      AndroidJavaClass androidJavaClass1 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
      AndroidJavaObject androidJavaObject = ((AndroidJavaObject) androidJavaClass1).GetStatic<AndroidJavaObject>("currentActivity");
      AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("jp.co.gu3.device.DeviceManager");
      ((AndroidJavaObject) androidJavaClass2).CallStatic("setCurrentActivity", new object[1]
      {
        (object) androidJavaObject
      });
      ((AndroidJavaObject) androidJavaClass2).Dispose();
      androidJavaObject.Dispose();
      ((AndroidJavaObject) androidJavaClass1).Dispose();
    }

    private static DeviceManager instance
    {
      get
      {
        if (DeviceManager._instance == null)
          DeviceManager._instance = new DeviceManager();
        return DeviceManager._instance;
      }
    }

    public static void SetAutoSleep(bool active) => DeviceManager.instance._SetAutoSleep(active);

    public static string GetUserAgent() => DeviceManager.instance._GetUserAgent();

    public static string GetSystemProxyURL() => DeviceManager.instance._GetSystemProxyURL();

    public static string GetBundleIdentifier() => DeviceManager.instance._GetBundleIdentifier();

    public static string GetBundleVersion() => DeviceManager.instance._GetBundleVersion();

    public static string GetTimeZone() => DeviceManager.instance._GetTimeZone();

    public static string GetLanguageLocale() => DeviceManager.instance._GetLanguageLocale();

    public static string GetDeviceIdentifier() => DeviceManager.instance._GetDeviceIdentifier();

    public static bool CanOpenUrl(string url) => DeviceManager.instance._CanOpenUrl(url);

    public static void OpenUrl(string url) => DeviceManager.instance._OpenUrl(url);

    public static void OpenStore(string appId) => DeviceManager.instance._OpenStore(appId);

    public static void LaunchMailer(string mailto, string subject, string body)
    {
      DeviceManager.instance._LaunchMailer(mailto, subject, body);
    }

    public static float GetOSVersion() => DeviceManager.instance._GetOSVersion();

    public static bool VerifyBinarySignature(byte[] signature)
    {
      return DeviceManager.instance._VeifyBinarySignature(signature);
    }

    public static string GetBinaryHash() => DeviceManager.instance._GetBinaryHash();

    public static bool CanLaunchIntent(string package_name)
    {
      return DeviceManager.instance._CanLaunchIntent(package_name);
    }

    [DllImport("UnityDeviceManager")]
    private static extern void DeviceManager_SetAutoSleep(bool active);

    [DllImport("UnityDeviceManager")]
    private static extern string DeviceManager_GetUserAgent();

    [DllImport("UnityDeviceManager")]
    private static extern string DeviceManager_GetSystemProxyURL();

    [DllImport("UnityDeviceManager")]
    private static extern string DeviceManager_GetBundleIdentifier();

    [DllImport("UnityDeviceManager")]
    private static extern string DeviceManager_GetBundleVersion();

    [DllImport("UnityDeviceManager")]
    private static extern string DeviceManager_GetTimeZone();

    [DllImport("UnityDeviceManager")]
    private static extern string DeviceManager_GetLanguageLocale();

    [DllImport("UnityDeviceManager")]
    private static extern string DeviceManager_GetDeviceIdentifier();

    [DllImport("UnityDeviceManager")]
    private static extern bool DeviceManager_CanOpenUrl(string url);

    [DllImport("UnityDeviceManager")]
    private static extern void DeviceManager_OpenUrl(string url);

    [DllImport("UnityDeviceManager")]
    private static extern void DeviceManager_OpenStore(string appId);

    [DllImport("UnityDeviceManager")]
    private static extern void DeviceManager_LaunchMailer(
      string mailto,
      string subject,
      string body);

    [DllImport("UnityDeviceManager")]
    private static extern float DeviceManager_getOSVersion();

    [DllImport("UnityDeviceManager")]
    private static extern bool DeviceManager_verifyBinarySignature(byte[] signature);

    [DllImport("UnityDeviceManager")]
    private static extern string DeviceManager_getBinaryHash();

    [DllImport("UnityDeviceManager")]
    private static extern bool DeviceManager_canLaunchIntent(string package_name);

    private void _SetAutoSleep(bool active) => DeviceManager.DeviceManager_SetAutoSleep(active);

    private string _GetUserAgent() => DeviceManager.DeviceManager_GetUserAgent();

    private string _GetSystemProxyURL() => DeviceManager.DeviceManager_GetSystemProxyURL();

    private string _GetBundleIdentifier() => DeviceManager.DeviceManager_GetBundleIdentifier();

    private string _GetBundleVersion() => DeviceManager.DeviceManager_GetBundleVersion();

    private string _GetTimeZone() => DeviceManager.DeviceManager_GetTimeZone();

    private string _GetLanguageLocale() => DeviceManager.DeviceManager_GetLanguageLocale();

    private string _GetDeviceIdentifier() => DeviceManager.DeviceManager_GetDeviceIdentifier();

    private bool _CanOpenUrl(string url) => DeviceManager.DeviceManager_CanOpenUrl(url);

    private void _OpenUrl(string url) => DeviceManager.DeviceManager_OpenUrl(url);

    private void _OpenStore(string appId) => DeviceManager.DeviceManager_OpenStore(appId);

    private void _LaunchMailer(string mailto, string subject, string body)
    {
      DeviceManager.DeviceManager_LaunchMailer(mailto, subject, body);
    }

    private float _GetOSVersion() => DeviceManager.DeviceManager_getOSVersion();

    private bool _VeifyBinarySignature(byte[] signature)
    {
      return DeviceManager.DeviceManager_verifyBinarySignature(signature);
    }

    private string _GetBinaryHash() => DeviceManager.DeviceManager_getBinaryHash();

    private bool _CanLaunchIntent(string package_name)
    {
      return DeviceManager.DeviceManager_canLaunchIntent(package_name);
    }
  }
}
