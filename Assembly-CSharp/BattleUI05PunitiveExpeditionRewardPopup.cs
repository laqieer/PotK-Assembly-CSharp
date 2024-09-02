// Decompiled with JetBrains decompiler
// Type: BattleUI05PunitiveExpeditionRewardPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class BattleUI05PunitiveExpeditionRewardPopup : MonoBehaviour
{
  [SerializeField]
  private BattleUI05PunitiveExpeditionRewardPopupAnim anim;
  [SerializeField]
  private GameObject popupObj;

  public IEnumerator Init()
  {
    yield break;
  }

  public void SetTapCallBack(System.Action callback) => this.anim.Init(callback);

  public void TapFinish() => this.anim.OnFinish();
}
