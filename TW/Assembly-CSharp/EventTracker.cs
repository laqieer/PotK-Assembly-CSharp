// Decompiled with JetBrains decompiler
// Type: EventTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    EventTracker.\u003CStart\u003Ec__IteratorAD5 startCIteratorAd5 = new EventTracker.\u003CStart\u003Ec__IteratorAD5();
    return (IEnumerator) startCIteratorAd5;
  }

  [DebuggerHidden]
  private IEnumerator SetDeviceToken()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    EventTracker.\u003CSetDeviceToken\u003Ec__IteratorAD6 tokenCIteratorAd6 = new EventTracker.\u003CSetDeviceToken\u003Ec__IteratorAD6();
    return (IEnumerator) tokenCIteratorAd6;
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
