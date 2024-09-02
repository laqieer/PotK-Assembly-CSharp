// Decompiled with JetBrains decompiler
// Type: Friend00820Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
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
    FaceBookWrapper.Feed(MasterData.InvitationInvitationList[0].link, MasterData.InvitationInvitationList[0].title, " ", this.InsertPlayerID(MasterData.InvitationInvitationList[0].discription));
  }

  public void onTwitter()
  {
    Application.OpenURL("https://twitter.com/intent/tweet?text=" + this.SpaceToPlusCounter(MasterData.InvitationInvitationList[1].discription));
  }

  public void onLine()
  {
    Application.OpenURL("https://line.naver.jp/R/msg/text/?" + this.SpaceToPlusCounter(MasterData.InvitationInvitationList[2].discription));
  }

  public void onSms()
  {
    Application.OpenURL(string.Format("sms:?body={0}", (object) this.SpaceToPlusCounter(MasterData.InvitationInvitationList[3].discription)));
  }

  public void onEmail()
  {
    Application.OpenURL(string.Format("mailto:?subject={0}&body={1}", (object) this.SpaceToPlusCounter(MasterData.InvitationInvitationList[4].title), (object) this.SpaceToPlusCounter(MasterData.InvitationInvitationList[4].discription)));
  }

  private string InsertPlayerID(string message)
  {
    return message.Replace("{playerID}", SMManager.Get<Player>().short_id);
  }

  public string SpaceToPlusCounter(string str)
  {
    return WWW.EscapeURL(this.InsertPlayerID(str), Encoding.UTF8).Replace("+", "%20");
  }
}
