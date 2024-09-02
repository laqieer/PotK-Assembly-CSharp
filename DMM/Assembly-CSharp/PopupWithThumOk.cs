// Decompiled with JetBrains decompiler
// Type: PopupWithThumOk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class PopupWithThumOk : PopupCommon
{
  [SerializeField]
  private CreateIconObject createIcon;

  public IEnumerator Initialize(
    string title,
    string message,
    MasterDataTable.CommonRewardType rewardType,
    int rewardId,
    int quantity = 0,
    System.Action callback = null)
  {
    PopupWithThumOk popupWithThumOk = this;
    popupWithThumOk.transform.localScale = Vector3.zero;
    popupWithThumOk.Init(title, message, callback);
    IEnumerator e = popupWithThumOk.createIcon.CreateThumbnail(rewardType, rewardId, quantity, isButton: false);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }
}
