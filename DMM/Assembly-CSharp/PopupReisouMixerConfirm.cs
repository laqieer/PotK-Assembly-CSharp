// Decompiled with JetBrains decompiler
// Type: PopupReisouMixerConfirm
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupReisouMixerConfirm : BackButtonMonoBehaiviour
{
  [SerializeField]
  private UILabel m_Warning;
  [SerializeField]
  private UIGrid m_Grid;
  private System.Action m_YesCallback;

  public IEnumerator Init(
    List<InventoryItem> materials,
    System.Action yesCallback,
    GameObject iconPrefab = null)
  {
    IEnumerator e;
    if ((UnityEngine.Object) iconPrefab == (UnityEngine.Object) null)
    {
      Future<GameObject> ItemIconF = Res.Prefabs.ItemIcon.prefab.Load<GameObject>();
      e = ItemIconF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      iconPrefab = ItemIconF.Result;
      ItemIconF = (Future<GameObject>) null;
    }
    this.m_YesCallback = yesCallback;
    foreach (InventoryItem material in materials)
    {
      InventoryItem item = material;
      ItemIcon icon = iconPrefab.CloneAndGetComponent<ItemIcon>(this.m_Grid.transform);
      e = icon.InitByItemInfo(item.Item);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      icon.SetRenseiIcon(false, false);
      icon.SetRenseiMaterialNum(item.Item.isTempSelectedCount ? item.Item.tempSelectedCount : 1);
      icon = (ItemIcon) null;
      item = (InventoryItem) null;
    }
    this.m_Grid.repositionNow = true;
  }

  public void IbtnYes()
  {
    if (this.m_YesCallback == null)
      return;
    this.m_YesCallback();
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();
}
