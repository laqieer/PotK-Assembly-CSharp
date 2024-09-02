// Decompiled with JetBrains decompiler
// Type: LCMNative_Android
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class LCMNative_Android
{
  private const string csJavaClass = ".UnityPlayerNativeActivity";
  public static string packAgeName = string.Empty;

  public static AndroidJavaClass native { get; set; }

  public static void setPackageName(string value)
  {
    DDebug.Log("setPackageName:" + value);
    LCMNative_Android.packAgeName = value;
    if (LCMNative_Android.native != null)
      return;
    if (LCMNative_Android.packAgeName != string.Empty)
    {
      try
      {
        string str = LCMNative_Android.packAgeName + ".UnityPlayerNativeActivity";
        DDebug.Log("javaClass:" + str);
        LCMNative_Android.native = new AndroidJavaClass(str);
      }
      catch
      {
        ModalWindow.Show(string.Empty, Consts.GetInstance().java_package_error, (System.Action) (() => { }));
      }
    }
    else
      DDebug.Log("LCMNative_Android packAgeName is null");
  }

  public static void SDKinit()
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (SDKinit), new object[0]);
  }

  public static void login()
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (login), new object[0]);
  }

  public static void logout()
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (logout), new object[0]);
  }

  public static void wxShare(string path)
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>("shareWx", new object[1]
    {
      (object) path
    });
  }

  public static void exitSDK()
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (exitSDK), new object[0]);
  }

  public static void quitSDK()
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (quitSDK), new object[0]);
  }

  public static void getSDKLoginInfo()
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (getSDKLoginInfo), new object[0]);
  }

  public static void createRole(
    string roleid,
    string rolename,
    string zoneid,
    string createTime,
    string balance)
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>("CreateRole", new object[5]
    {
      (object) roleid,
      (object) rolename,
      (object) zoneid,
      (object) createTime,
      (object) balance
    });
  }

  public static void roleEvent(
    string eventname,
    string roleid,
    string rolename,
    string zoneid,
    string roleLevel,
    string createTime,
    string balance)
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>("LCMroleEvent", new object[7]
    {
      (object) eventname,
      (object) roleid,
      (object) rolename,
      (object) zoneid,
      (object) roleLevel,
      (object) createTime,
      (object) balance
    });
  }

  public static void getPayItemList()
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (getPayItemList), new object[0]);
  }

  public static void payItemOrder(int index, string serorder, int just_substract)
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (payItemOrder), new object[3]
    {
      (object) index,
      (object) serorder,
      (object) just_substract
    });
  }

  public static void onlyPurchase()
  {
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (onlyPurchase), new object[0]);
  }

  public static void updateMoney()
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (updateMoney), new object[0]);
  }

  public static void showRemoteMsg(string message, string extras)
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (showRemoteMsg), new object[2]
    {
      (object) message,
      (object) extras
    });
  }

  public static void checkRealName()
  {
    if (LCMNative_Android.native == null)
      return;
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>("LCMCheckRealName", new object[0]);
  }

  public static void link(string linkType)
  {
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (link), new object[1]
    {
      (object) linkType
    });
  }

  public static void unlink()
  {
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (unlink), new object[0]);
  }

  public static void loadaccount(string linkType, string oneKeyStr)
  {
    ((AndroidJavaObject) LCMNative_Android.native).CallStatic<int>(nameof (loadaccount), new object[2]
    {
      (object) linkType,
      (object) oneKeyStr
    });
  }
}
