// Decompiled with JetBrains decompiler
// Type: PopupXLevelUpConfirm
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using UnityEngine;

[AddComponentMenu("Popup/Unit/PopupXLevelUpConfirm")]
public class PopupXLevelUpConfirm : BackButtonPopupBase
{
  [SerializeField]
  private UIGrid grid_;
  private Tuple<PlayerMaterialUnit, int>[] targets_;
  private System.Action<bool> onEnd_;

  public static Future<GameObject> createLoader() => new ResourceObject("Prefabs/unit004_2/popup_XLvUp_Confirm").Load<GameObject>();

  public static void show(
    GameObject prefab,
    Tuple<PlayerMaterialUnit, int>[] materials,
    System.Action<bool> eventEnd)
  {
    GameObject gameObject = Singleton<PopupManager>.GetInstance().open(prefab, isNonSe: true, isNonOpenAnime: true);
    PopupXLevelUpConfirm component = gameObject.GetComponent<PopupXLevelUpConfirm>();
    component.setTopObject(gameObject);
    component.targets_ = materials;
    component.onEnd_ = eventEnd;
  }

  private IEnumerator Start()
  {
    PopupXLevelUpConfirm popupXlevelUpConfirm = this;
    popupXlevelUpConfirm.gameObject.GetComponent<UIRect>().alpha = 0.0f;
    Future<GameObject> ldIcon = Res.Prefabs.UnitIcon.normal.Load<GameObject>();
    yield return (object) ldIcon.Wait();
    Future<GameObject> ldFrame = new ResourceObject("Prefabs/unit004_2/dir_Material_IconOnly_Item").Load<GameObject>();
    yield return (object) ldFrame.Wait();
    for (int n = 0; n < popupXlevelUpConfirm.targets_.Length; ++n)
    {
      Tuple<PlayerMaterialUnit, int> target = popupXlevelUpConfirm.targets_[n];
      GameObject goFrame = ldFrame.Result.Clone(popupXlevelUpConfirm.grid_.transform);
      UnitIcon icon = ldIcon.Result.Clone(goFrame.transform.GetChildInFind("dyn_Thum")).GetComponent<UnitIcon>();
      UnitUnit unit = target.Item1.unit;
      yield return (object) icon.SetUnit(unit, unit.GetElement(), false);
      icon.BottomModeValue = UnitIconBase.BottomMode.Nothing;
      icon.SetIconBoxCollider(false);
      icon = (UnitIcon) null;
      goFrame.transform.GetChildInFind("txt_Num_Quantity").GetComponent<UILabel>().SetTextLocalize(target.Item2);
      target = (Tuple<PlayerMaterialUnit, int>) null;
      goFrame = (GameObject) null;
    }
    popupXlevelUpConfirm.grid_.Reposition();
    Singleton<PopupManager>.GetInstance().startOpenAnime(popupXlevelUpConfirm.gameObject);
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
    this.onEnd_(false);
  }

  public void onClickedOk()
  {
    if (this.IsPushAndSet())
      return;
    this.onEnd_(true);
  }
}
