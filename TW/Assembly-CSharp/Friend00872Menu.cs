// Decompiled with JetBrains decompiler
// Type: Friend00872Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Friend00872Menu : NGMenuBase
{
  [SerializeField]
  private UILabel TxtDescription1Left;
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  public UIButton btnOk;
  [SerializeField]
  public UIButton btnGoto;
  public string strSceneToChange = string.Empty;
  private bool m_bCommonConfirm;

  public void SetTxtDescription1Left(string str)
  {
    this.TxtDescription1Left.SetTextLocalize(str);
    if (Object.op_Implicit((Object) this.btnGoto))
      ((Component) this.btnGoto).gameObject.SetActive(false);
    if (!Object.op_Implicit((Object) this.btnOk))
      return;
    ((Component) this.btnOk).gameObject.SetActive(true);
  }

  public void SetTxtTitel(string str)
  {
    this.m_bCommonConfirm = true;
    this.TxtTitle.SetTextLocalize(str);
  }

  public void SetScene(string strScene)
  {
    this.strSceneToChange = strScene;
    if (this.strSceneToChange == "activity004_18" || this.strSceneToChange.Length > 1)
    {
      ((Component) this.btnGoto).gameObject.SetActive(true);
      ((Component) this.btnOk).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.btnGoto).gameObject.SetActive(false);
      ((Component) this.btnOk).gameObject.SetActive(true);
    }
  }

  public virtual void IbtnOk()
  {
    if (!this.m_bCommonConfirm)
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    if (this.strSceneToChange.Length <= 1)
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene(this.strSceneToChange, true);
  }

  public virtual void IbtnChangeScene()
  {
    if (!this.m_bCommonConfirm)
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    if (this.strSceneToChange.Length <= 1)
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene(this.strSceneToChange, true);
  }
}
