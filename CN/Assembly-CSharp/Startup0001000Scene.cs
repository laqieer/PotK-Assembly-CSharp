// Decompiled with JetBrains decompiler
// Type: Startup0001000Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Startup0001000Scene : MonoBehaviour
{
  private bool isOpenPopup;
  public UIRoot uiRoot;
  public UIButton uiButton;

  private void Awake() => ModalWindow.setupRootPanel(this.uiRoot);

  private void Start() => Singleton<LuaHotFixMgr>.GetInstance().RefreshUsingLua();

  private void Update()
  {
    if (!Input.GetKeyUp((KeyCode) 27) || this.isOpenPopup)
      return;
    ModalWindow.ShowYesNo(Consts.GetInstance().titleback_title, Consts.GetInstance().titleback_text, (System.Action) (() =>
    {
      this.isOpenPopup = false;
      StartScript.Restart();
    }), (System.Action) (() => this.isOpenPopup = false));
    this.isOpenPopup = true;
  }
}
