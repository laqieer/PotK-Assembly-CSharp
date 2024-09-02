// Decompiled with JetBrains decompiler
// Type: AnalyticsSample
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AnalyticsSample : MonoBehaviour
{
  private bool logEnabled = true;
  public string spotCode = "";
  public bool useReceiver;
  public bool testMode;
  private bool pushNotificationToggleState;

  private void Start() => this.pushNotificationToggleState = MetapsAnalyticsScript.IsPushNotificationEnabled();

  private void OnEnable()
  {
  }

  private void OnDisable()
  {
  }

  private void Update()
  {
  }

  private void OnGUI()
  {
    GUIStyle style = new GUIStyle();
    style.alignment = TextAnchor.MiddleCenter;
    style.normal.textColor = Color.white;
    style.wordWrap = true;
    float num1 = 60f;
    float width = 300f;
    float height = 40f;
    float y1 = 50f;
    double num2 = (double) (Screen.width / 2) - (double) width / 2.0;
    UnityEngine.GUI.Label(new Rect((float) num2, y1, width, height), "Analytics Unity Sample App", style);
    float y2 = y1 + num1;
    if (UnityEngine.GUI.Button(new Rect((float) num2, y2, width, height), "Purchase Diamonds for 0.99 USD"))
      MetapsAnalyticsScript.TrackPurchase("Diamonds", 0.99, "USD");
    float y3 = y2 + num1;
    if (UnityEngine.GUI.Button(new Rect((float) num2, y3, width, height), "Track Send 5 invites"))
      MetapsAnalyticsScript.TrackEvent("Invite", "Send", 5);
    float y4 = y3 + num1;
    if (UnityEngine.GUI.Button(new Rect((float) num2, y4, width, height), "Track Tutorial Clear"))
      MetapsAnalyticsScript.TrackEvent("Tutorial", "Clear");
    float y5 = y4 + num1;
    if (UnityEngine.GUI.Button(new Rect((float) num2, y5, width, height), "Track Spend 10 tickets in shop"))
      MetapsAnalyticsScript.TrackSpend("Shop", "tickets", 10);
    float y6 = y5 + num1;
    if (UnityEngine.GUI.Button(new Rect((float) num2, y6, width, height), "Set User Profile age"))
      MetapsAnalyticsScript.SetUserProfile("BIRTHDAY", "19801101");
    float y7 = y6 + num1;
    if (UnityEngine.GUI.Button(new Rect((float) num2, y7, width, height), "Remove Attribute"))
      MetapsAnalyticsScript.SetAttribute("AGE", (string) null);
    float y8 = y7 + num1;
    if (UnityEngine.GUI.Button(new Rect((float) num2, y8, width, height), "Track Action"))
      MetapsAnalyticsScript.TrackAction("ConversionPoint");
    float y9 = y8 + num1;
    if (UnityEngine.GUI.Button(new Rect((float) num2, y9, width, height), "Enable log"))
    {
      this.logEnabled = !this.logEnabled;
      MetapsAnalyticsScript.SetLogEnabled(this.logEnabled);
    }
    bool enabled = UnityEngine.GUI.Toggle(new Rect((float) num2, y9 + num1, width, height), this.pushNotificationToggleState, "Push Notification enabled");
    if (enabled == this.pushNotificationToggleState)
      return;
    this.pushNotificationToggleState = enabled;
    MetapsAnalyticsScript.SetPushNotificationEnabled(enabled);
  }
}
