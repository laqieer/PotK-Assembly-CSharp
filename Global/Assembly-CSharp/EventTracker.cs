// Decompiled with JetBrains decompiler
// Type: EventTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using gu3.Payment;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class EventTracker : MonoBehaviour
{
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
    return (IEnumerator) new EventTracker.\u003CStart\u003Ec__Iterator880()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetDeviceToken()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    EventTracker.\u003CSetDeviceToken\u003Ec__Iterator881 tokenCIterator881 = new EventTracker.\u003CSetDeviceToken\u003Ec__Iterator881();
    return (IEnumerator) tokenCIterator881;
  }

  public static void SendPayment(string productId)
  {
    if (!PaymentListener.Products.ContainsKey(productId))
      return;
    Product product = PaymentListener.Products[productId];
    FaceBookWrapper.Purchase((float) product.price, product.currency, productId);
    GrowthPush.GetInstance().TrackEvent("BUY_COIN");
    Player player = SMManager.Get<Player>();
    GrowthPush.GetInstance().SetTag("HAVE_COINS", (player.paid_coin + player.free_coin).ToString());
    GrowthPush.GetInstance().SetTag("HAVE_FREE_COINS", player.free_coin.ToString());
    GrowthPush.GetInstance().SetTag("HAVE_PAID_COINS", player.paid_coin.ToString());
    MetapsAnalyticsScript.TrackPurchase(productId, product.price, product.currency);
  }

  public static void BeaconTutorial(string name, int seconds)
  {
    MetapsAnalyticsScript.TrackEvent("TUTORIAL", name);
  }

  public static void TrackEvent(string category, string name, int value)
  {
    MetapsAnalyticsScript.TrackEvent(category, name, value);
  }

  public static void TrackEvent(string category, string name, string id, int value)
  {
    MetapsAnalyticsScript.TrackEvent(category, string.Format("{0}_{1}", (object) name, (object) id), value);
  }

  public static void TrackSpend(string category, string name, int value)
  {
    MetapsAnalyticsScript.TrackSpend(category, name, value);
  }

  public static void SendEvent(EventTracker.EventType e)
  {
    switch (e)
    {
      case EventTracker.EventType.FINISH_FIRST_DLC:
        MetapsAnalyticsScript.TrackEvent("FIRST_DLC", "FINISH");
        break;
      case EventTracker.EventType.FINISH_TUTORIAL:
        MetapsAnalyticsScript.TrackEvent("TUTORIAL", "FINISH");
        break;
    }
  }

  public enum EventType
  {
    FINISH_FIRST_DLC,
    FINISH_TUTORIAL,
  }
}
