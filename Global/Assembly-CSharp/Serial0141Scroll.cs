// Decompiled with JetBrains decompiler
// Type: Serial0141Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
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

  public void setCampainId(int id) => this.campain_id = id;

  [DebuggerHidden]
  private IEnumerator SerialRegisterAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Serial0141Scroll.\u003CSerialRegisterAsync\u003Ec__Iterator4D0()
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

  public void setTxtPeriod(DateTime fromDate, DateTime toDate)
  {
    this.txtPeriod.SetTextLocalize(fromDate.ToString("yyyy/MM/dd H:mm") + " - " + toDate.ToString("yyyy/MM/dd H:mm"));
  }

  public void setTxtPeriod(string str) => this.txtPeriod.SetTextLocalize(str);

  public void LoadBoxSprite()
  {
    ResourceManager.LoadOrNull<Sprite>(string.Format("AssetBundle/Resources/Serial/{0}/serial", (object) this.campain_id)).RunOn<Sprite>((MonoBehaviour) this, (Action<Sprite>) (s => this.slcBox.sprite2D = s));
  }
}
