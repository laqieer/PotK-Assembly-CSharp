// Decompiled with JetBrains decompiler
// Type: Setting01013Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Setting01013Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel InpId01;
  [SerializeField]
  protected UILabel README;
  [SerializeField]
  protected UILabel TxtDescription;
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  protected UILabel TxtTitle;
  public UILabel message;
  public GameObject advice;

  public void Initialize()
  {
    Player player = SMManager.Get<Player>();
    this.InpId01.SetTextLocalize(player.name);
    ((Component) this.InpId01).GetComponent<UIInput>().defaultText = player.name;
    ((Component) this.InpId01).GetComponent<UIInput>().onValidate = new UIInput.OnValidate(this.onValidate);
    this.advice.SetActive(false);
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
  private IEnumerator NameEdit()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Setting01013Menu.\u003CNameEdit\u003Ec__Iterator543()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnPopupOk()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.NameEdit());
  }

  public void ErrDialog()
  {
    this.advice.SetActive(true);
    this.message.SetText(Consts.GetInstance().tutorial_fail_player_name);
  }

  public void ErrDialogOnTap() => this.advice.SetActive(false);
}
