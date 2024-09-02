// Decompiled with JetBrains decompiler
// Type: PopupReisouFusionResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using UnityEngine;

public class PopupReisouFusionResult : MonoBehaviour
{
  [SerializeField]
  protected GameObject dirIcon;
  protected System.Action callBack;

  public IEnumerator Init(System.Action callBack, PlayerItem item)
  {
    this.callBack = callBack;
    Future<GameObject> prefabF = Res.Prefabs.ItemIcon.prefab.Load<GameObject>();
    IEnumerator e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    ItemIcon itemIcon = prefabF.Result.Clone(this.dirIcon.transform).GetComponent<ItemIcon>();
    e = itemIcon.InitByPlayerItem(item);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    itemIcon.EnableLongPressEventReisou();
    Singleton<NGGameDataManager>.GetInstance().lastReferenceItemID = item.id;
  }

  public void onBtnYes()
  {
    System.Action callBack = this.callBack;
    if (callBack == null)
      return;
    callBack();
  }
}
