// Decompiled with JetBrains decompiler
// Type: ApPopup0027
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class ApPopup0027 : BackButtonMenuBase
{
  private System.Action btnAct;

  public void ibtnYes() => this.StartCoroutine(PopupUtility.RecoveryAP(true, this.btnAct));

  public void SetBtnAct(System.Action questChangeScene) => this.btnAct = questChangeScene;

  private IEnumerator popup00712()
  {
    Future<GameObject> prefab = Res.Prefabs.popup.popup_007_12__popup01.Load<GameObject>();
    IEnumerator e = prefab.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    Shop00712Menu component = Singleton<PopupManager>.GetInstance().open(prefab.Result).GetComponent<Shop00712Menu>();
    component.setUserData();
    component.SetBtnAction(this.btnAct);
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
