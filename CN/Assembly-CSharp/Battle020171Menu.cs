// Decompiled with JetBrains decompiler
// Type: Battle020171Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Battle020171Menu : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtExplanation24;
  [SerializeField]
  protected UILabel TxtLvAfter28;
  [SerializeField]
  protected UILabel TxtLvbefore28;
  [SerializeField]
  protected UILabel TxtPlayername30;
  private System.Action onCallback;
  public Touch2NextAuto touchScript;

  private void Awake()
  {
    this.touchScript = ((Component) this).gameObject.AddComponent<Touch2NextAuto>();
  }

  private void Start()
  {
    Singleton<NGSoundManager>.GetInstance().playSE("SE_1022");
    Singleton<NGSoundManager>.GetInstance().PlayBgm("bgm016", 1);
    if (!Object.op_Implicit((Object) this.touchScript))
      return;
    this.touchScript.touch2Next.SetActive(false);
    this.Invoke("ShowTouchToNext", 1.5f);
  }

  private void ShowTouchToNext()
  {
    if (!Object.op_Implicit((Object) this.touchScript))
      return;
    this.touchScript.touch2Next.SetActive(true);
  }

  private void OnDestroy() => Singleton<NGSoundManager>.GetInstance().StopBgm(1);

  public void SetLv(int before, int after)
  {
    this.TxtLvbefore28.SetTextLocalize(before);
    this.TxtLvAfter28.SetTextLocalize(after);
  }

  public void SetName(string name) => this.TxtPlayername30.SetTextLocalize(name);

  public void SetExplanetion(string str) => this.TxtExplanation24.SetTextLocalize(str);

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  public virtual void IbtnScreen()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (this.onCallback == null)
      return;
    this.onCallback();
  }
}
