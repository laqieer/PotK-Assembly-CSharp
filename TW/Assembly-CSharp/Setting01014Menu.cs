// Decompiled with JetBrains decompiler
// Type: Setting01014Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Setting01014Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel InpId01;

  public void Initialize()
  {
    Player player = SMManager.Get<Player>();
    this.InpId01.SetTextLocalize(player.comment);
    ((Component) this.InpId01).GetComponent<UIInput>().defaultText = this.SetTextPlayerComment(player.comment);
    ((Component) this.InpId01).GetComponent<UIInput>().onValidate = new UIInput.OnValidate(this.onValidate);
  }

  private string SetTextPlayerComment(string comment)
  {
    return comment == string.Empty ? Consts.GetInstance().FRIEND_COMMENT_DEFAULT : comment;
  }

  private char onValidate(string text, int charIndex, char addedChar)
  {
    bool flag = char.IsControl(addedChar) || addedChar >= '\uE000' && addedChar <= '\uF8FF';
    Debug.Log((object) (((int) addedChar).ToString() + ":" + (object) flag));
    return flag ? char.MinValue : addedChar;
  }

  public void onChangeInput()
  {
    if (this.IsPush)
      return;
    this.InpId01.SetTextLocalize(((Component) this.InpId01).GetComponent<UIInput>().value);
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().backScene();
  }

  [DebuggerHidden]
  private IEnumerator CommentEdit()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Setting01014Menu.\u003CCommentEdit\u003Ec__Iterator595()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnPopupOk() => this.StartCoroutine(this.CommentEdit());

  public void ErrDialog()
  {
    this.StartCoroutine(PopupCommon.Show(Consts.GetInstance().SETTING_01014_POPUP_TITLE, Consts.Format(Consts.GetInstance().SETTING_01014_ERROR_MESSAGE)));
  }
}
