// Decompiled with JetBrains decompiler
// Type: Serial0141Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Serial0141Scroll : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite slcBox;
  [SerializeField]
  private UIInput InpId;
  [SerializeField]
  private UILabel txtPeriod;
  [SerializeField]
  private UIButton ibtnPopupSend;
  [SerializeField]
  private UILabel txtSerialcode;
  private int campain_id;
  private BackButtonMenuBase _baseMenu;

  public void init(BackButtonMenuBase baseMenu) => this._baseMenu = baseMenu;

  [DebuggerHidden]
  private IEnumerator SerialRegisterAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Serial0141Scroll.\u003CSerialRegisterAsync\u003Ec__Iterator5C5()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnPopupSend()
  {
    if (this._baseMenu.IsPushAndSet())
      return;
    this.StartCoroutine(this.SerialRegisterAsync());
  }

  public void onChangeInput()
  {
    ((Component) this.InpId).GetComponent<UILabel>().SetTextLocalize(this.InpId.value);
  }

  public void setKeyboardTypeNumber()
  {
    this.InpId.keyboardType = UIInput.KeyboardType.ASCIICapable;
    this.InpId.characterLimit = 16;
  }
}
