// Decompiled with JetBrains decompiler
// Type: EventTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class EventTracker : MonoBehaviour
{
  [SerializeField]
  private int partyTrack_iOS_AppID;
  [SerializeField]
  private string partyTrack_iOS_AppKey;
  [SerializeField]
  private int partyTrack_Android_AppID;
  [SerializeField]
  private string partyTrack_Android_AppKey;
  [SerializeField]
  private string Growthbeat_ApplicationID;
  [SerializeField]
  private string Growthbeat_CredentialID;
  [SerializeField]
  private string Growthbeat_SenderID;
  private static int[] partyTrackEvents = new int[2]
  {
    20256,
    20257
  };
  private static int[] fiveRocksEvents = new int[0];

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    EventTracker.\u003CStart\u003Ec__Iterator9FB startCIterator9Fb = new EventTracker.\u003CStart\u003Ec__Iterator9FB();
    return (IEnumerator) startCIterator9Fb;
  }

  [DebuggerHidden]
  private IEnumerator SetDeviceToken()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    EventTracker.\u003CSetDeviceToken\u003Ec__Iterator9FC tokenCIterator9Fc = new EventTracker.\u003CSetDeviceToken\u003Ec__Iterator9FC();
    return (IEnumerator) tokenCIterator9Fc;
  }

  public static void SendPayment(string productId)
  {
  }

  public static void BeaconTutorial(string name, int seconds)
  {
  }

  public static void TrackEvent(string category, string name, int value)
  {
  }

  public static void TrackEvent(string category, string name, string id, int value)
  {
  }

  public static void TrackSpend(string category, string name, int value)
  {
  }

  public static void SendEvent(EventTracker.EventType e)
  {
  }

  private void OnDisable()
  {
  }

  public enum EventType
  {
    FINISH_FIRST_DLC,
    FINISH_TUTORIAL,
  }
}
