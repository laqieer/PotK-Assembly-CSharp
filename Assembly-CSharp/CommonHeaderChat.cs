// Decompiled with JetBrains decompiler
// Type: CommonHeaderChat
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CommonHeaderChat : MonoBehaviour
{
  [SerializeField]
  private UILabel chatText1;
  [SerializeField]
  private TweenPosition textTweenPosition1;
  [SerializeField]
  private GameObject newBadge;

  private void Awake() => this.chatText1.SetTextLocalize("");

  public void ChatReset()
  {
    this.chatText1.SetTextLocalize("");
    this.newBadge.SetActive(false);
  }

  public void TextScrollStart()
  {
    this.chatText1.transform.localPosition = this.textTweenPosition1.from;
    this.textTweenPosition1.onFinished.Clear();
    this.textTweenPosition1.ResetToBeginning();
    this.textTweenPosition1.enabled = false;
    this.textTweenPosition1.enabled = true;
    this.textTweenPosition1.PlayForward();
    this.textTweenPosition1.AddOnFinished(new EventDelegate.Callback(this.Text1ScrollFinish1));
  }

  public void SetNewIcon() => this.newBadge.SetActive(Persist.guildHeaderChat.Data.isChatNew);

  public void DisableNewIcon()
  {
    Persist.guildHeaderChat.Data.isChatNew = false;
    this.newBadge.SetActive(false);
  }

  public void SetText(GuildChatMessageData data)
  {
    string str = data.messageContent;
    if (str.Length > 23)
      str = data.messageContent.Substring(0, 23) + "…";
    string text = string.Format("【{0}】{1}", (object) data.senderName, (object) str);
    this.chatText1.SetTextLocalize(text);
    int num = text.Length * this.chatText1.fontSize;
    if (num <= 23 * this.chatText1.fontSize)
      return;
    this.textTweenPosition1.to = new Vector3((float) -num, 0.0f, 2f);
  }

  public void Text1ScrollFinish1()
  {
    this.textTweenPosition1.ResetToBeginning();
    this.textTweenPosition1.PlayForward();
  }
}
