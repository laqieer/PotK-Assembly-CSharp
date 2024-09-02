// Decompiled with JetBrains decompiler
// Type: Friend00820Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Text;
using UnityEngine;

#nullable disable
public class Friend00820Scroll : MonoBehaviour
{
  [SerializeField]
  private UIButton IbtnChapter;
  [SerializeField]
  private UILabel TxtChapter;

  public void onFbFeed()
  {
  }

  public void onTwitter()
  {
    Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(MasterData.InvitationInvitationList[1].discription));
  }

  public void onLine()
  {
    Application.OpenURL("http://line.naver.jp/R/msg/text/?" + WWW.EscapeURL(MasterData.InvitationInvitationList[2].discription, Encoding.UTF8));
  }

  public void onSms()
  {
    Application.OpenURL(string.Format("sms:?body={0}", (object) WWW.EscapeURL(MasterData.InvitationInvitationList[3].discription, Encoding.UTF8)));
  }

  public void onEmail()
  {
    Application.OpenURL(string.Format("mailto:?subject={0}&body={1}", (object) WWW.EscapeURL(MasterData.InvitationInvitationList[4].title, Encoding.UTF8), (object) WWW.EscapeURL(MasterData.InvitationInvitationList[4].discription, Encoding.UTF8)));
  }
}
