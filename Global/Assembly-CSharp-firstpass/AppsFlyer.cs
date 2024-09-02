// Decompiled with JetBrains decompiler
// Type: AppsFlyer
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class AppsFlyer : MonoBehaviour
{
  private static AndroidJavaClass obj = new AndroidJavaClass("com.appsflyer.AppsFlyerLib");
  private static AndroidJavaObject cls_AppsFlyer = ((AndroidJavaObject) AppsFlyer.obj).CallStatic<AndroidJavaObject>("getInstance", new object[0]);
  private static AndroidJavaClass cls_AppsFlyerHelper = new AndroidJavaClass("com.appsflyer.AppsFlyerUnityHelper");
  private static string devKey;

  public static void trackEvent(string eventName, string eventValue)
  {
    MonoBehaviour.print((object) "AF.cs this is deprecated method. please use trackRichEvent instead. nothing is sent.");
  }

  public static void setCurrencyCode(string currencyCode)
  {
    AppsFlyer.cls_AppsFlyer.Call(nameof (setCurrencyCode), new object[1]
    {
      (object) currencyCode
    });
  }

  public static void setCustomerUserID(string customerUserID)
  {
    AppsFlyer.cls_AppsFlyer.Call("setAppUserId", new object[1]
    {
      (object) customerUserID
    });
  }

  public static void loadConversionData(string callbackObject)
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
      using (AndroidJavaObject androidJavaObject = ((AndroidJavaObject) androidJavaClass).GetStatic<AndroidJavaObject>("currentActivity"))
        ((AndroidJavaObject) AppsFlyer.cls_AppsFlyerHelper).CallStatic("createConversionDataListener", new object[2]
        {
          (object) androidJavaObject,
          (object) callbackObject
        });
    }
  }

  [Obsolete("Use loadConversionData(string callbackObject)")]
  public static void loadConversionData(
    string callbackObject,
    string callbackMethod,
    string callbackFailedMethod)
  {
    AppsFlyer.loadConversionData(callbackObject);
  }

  public static void setCollectIMEI(bool shouldCollect)
  {
    AppsFlyer.cls_AppsFlyer.Call(nameof (setCollectIMEI), new object[1]
    {
      (object) shouldCollect
    });
  }

  public static void setCollectAndroidID(bool shouldCollect)
  {
    MonoBehaviour.print((object) "AF.cs setCollectAndroidID");
    AppsFlyer.cls_AppsFlyer.Call(nameof (setCollectAndroidID), new object[1]
    {
      (object) shouldCollect
    });
  }

  public static void init(string key)
  {
    MonoBehaviour.print((object) "AF.cs init");
    AppsFlyer.devKey = key;
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
      using (AndroidJavaObject androidJavaObject = ((AndroidJavaObject) androidJavaClass).GetStatic<AndroidJavaObject>("currentActivity"))
      {
        // ISSUE: method pointer
        androidJavaObject.Call("runOnUiThread", new object[1]
        {
          (object) new AndroidJavaRunnable((object) null, __methodptr(init_cb))
        });
      }
    }
  }

  private static void init_cb()
  {
    MonoBehaviour.print((object) "AF.cs start tracking");
    AppsFlyer.trackAppLaunch();
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
      using (AndroidJavaObject androidJavaObject1 = ((AndroidJavaObject) androidJavaClass).GetStatic<AndroidJavaObject>("currentActivity"))
      {
        AndroidJavaObject androidJavaObject2 = androidJavaObject1.Call<AndroidJavaObject>("getApplication", new object[0]);
        AppsFlyer.cls_AppsFlyer.Call("startTracking", new object[2]
        {
          (object) androidJavaObject2,
          (object) AppsFlyer.devKey
        });
      }
    }
  }

  public static void setAppsFlyerKey(string key)
  {
    MonoBehaviour.print((object) "AF.cs setAppsFlyerKey");
    AppsFlyer.init(key);
  }

  public static void trackAppLaunch()
  {
    MonoBehaviour.print((object) "AF.cs trackAppLaunch");
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
      using (AndroidJavaObject androidJavaObject = ((AndroidJavaObject) androidJavaClass).GetStatic<AndroidJavaObject>("currentActivity"))
        AppsFlyer.cls_AppsFlyer.Call(nameof (trackAppLaunch), new object[2]
        {
          (object) androidJavaObject,
          (object) AppsFlyer.devKey
        });
    }
  }

  public static void setAppID(string packageName)
  {
    AppsFlyer.cls_AppsFlyer.Call("setAppId", new object[1]
    {
      (object) packageName
    });
  }

  public static void createValidateInAppListener(
    string aObject,
    string callbackMethod,
    string callbackFailedMethod)
  {
    MonoBehaviour.print((object) "AF.cs createValidateInAppListener called");
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
      using (AndroidJavaObject androidJavaObject = ((AndroidJavaObject) androidJavaClass).GetStatic<AndroidJavaObject>("currentActivity"))
        ((AndroidJavaObject) AppsFlyer.cls_AppsFlyerHelper).CallStatic(nameof (createValidateInAppListener), new object[4]
        {
          (object) androidJavaObject,
          (object) aObject,
          (object) callbackMethod,
          (object) callbackFailedMethod
        });
    }
  }

  public static void validateReceipt(
    string publicKey,
    string purchaseData,
    string signature,
    string price,
    string currency,
    Dictionary<string, string> extraParams)
  {
    MonoBehaviour.print((object) ("AF.cs validateReceipt pk = " + publicKey + " data = " + purchaseData + "sig = " + signature));
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
      using (AndroidJavaObject androidJavaObject1 = ((AndroidJavaObject) androidJavaClass).GetStatic<AndroidJavaObject>("currentActivity"))
      {
        AndroidJavaObject androidJavaObject2 = (AndroidJavaObject) null;
        if (extraParams != null)
          androidJavaObject2 = AppsFlyer.ConvertHashMap(extraParams);
        MonoBehaviour.print((object) "inside cls_activity");
        AppsFlyer.cls_AppsFlyer.Call("validateAndTrackInAppPurchase", new object[7]
        {
          (object) androidJavaObject1,
          (object) publicKey,
          (object) signature,
          (object) purchaseData,
          (object) price,
          (object) currency,
          (object) androidJavaObject2
        });
      }
    }
  }

  public static void trackRichEvent(string eventName, Dictionary<string, string> eventValues)
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
      using (AndroidJavaObject androidJavaObject1 = ((AndroidJavaObject) androidJavaClass).GetStatic<AndroidJavaObject>("currentActivity"))
      {
        AndroidJavaObject androidJavaObject2 = AppsFlyer.ConvertHashMap(eventValues);
        AppsFlyer.cls_AppsFlyer.Call("trackEvent", new object[3]
        {
          (object) androidJavaObject1,
          (object) eventName,
          (object) androidJavaObject2
        });
      }
    }
  }

  private static AndroidJavaObject ConvertHashMap(Dictionary<string, string> dict)
  {
    AndroidJavaObject androidJavaObject1 = new AndroidJavaObject("java.util.HashMap", new object[0]);
    IntPtr methodId = AndroidJNIHelper.GetMethodID(androidJavaObject1.GetRawClass(), "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
    object[] objArray = new object[2];
    foreach (KeyValuePair<string, string> keyValuePair in dict)
    {
      using (AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.lang.String", new object[1]
      {
        (object) keyValuePair.Key
      }))
      {
        using (AndroidJavaObject androidJavaObject3 = new AndroidJavaObject("java.lang.String", new object[1]
        {
          (object) keyValuePair.Value
        }))
        {
          objArray[0] = (object) androidJavaObject2;
          objArray[1] = (object) androidJavaObject3;
          AndroidJNI.CallObjectMethod(androidJavaObject1.GetRawObject(), methodId, AndroidJNIHelper.CreateJNIArgArray(objArray));
        }
      }
    }
    return androidJavaObject1;
  }

  public static void setImeiData(string imeiData)
  {
    MonoBehaviour.print((object) "AF.cs setImeiData");
    AppsFlyer.cls_AppsFlyer.Call(nameof (setImeiData), new object[1]
    {
      (object) imeiData
    });
  }

  public static void setAndroidIdData(string androidIdData)
  {
    MonoBehaviour.print((object) "AF.cs setImeiData");
    AppsFlyer.cls_AppsFlyer.Call(nameof (setAndroidIdData), new object[1]
    {
      (object) androidIdData
    });
  }

  public static void setIsDebug(bool isDebug)
  {
    MonoBehaviour.print((object) "AF.cs setDebugLog");
    AppsFlyer.cls_AppsFlyer.Call("setDebugLog", new object[1]
    {
      (object) isDebug
    });
  }

  public static void setIsSandbox(bool isSandbox)
  {
  }

  public static void getConversionData()
  {
  }

  public static void handleOpenUrl(string url, string sourceApplication, string annotation)
  {
  }

  public static string getAppsFlyerId()
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
      using (AndroidJavaObject androidJavaObject = ((AndroidJavaObject) androidJavaClass).GetStatic<AndroidJavaObject>("currentActivity"))
        return AppsFlyer.cls_AppsFlyer.Call<string>("getAppsFlyerUID", new object[1]
        {
          (object) androidJavaObject
        });
    }
  }

  public static void setGCMProjectNumber(string googleGCMNumber)
  {
    AppsFlyer.cls_AppsFlyer.Call(nameof (setGCMProjectNumber), new object[1]
    {
      (object) googleGCMNumber
    });
  }
}
