// Decompiled with JetBrains decompiler
// Type: MapEdit031MenuMapCatalog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using UnityEngine;

public class MapEdit031MenuMapCatalog : MapEditMenuBase
{
  [SerializeField]
  private GameObject topInterface_;
  private MapEditBaseMapSelect catalog_;

  public override MapEdit031TopMenu.EditState editState_ => MapEdit031TopMenu.EditState.MapCatalog;

  protected override IEnumerator initializeAsync()
  {
    MapEdit031MenuMapCatalog edit031MenuMapCatalog = this;
    Future<GameObject> ldprefab = MapEdit.Prefabs.base_map_select.Load<GameObject>();
    IEnumerator e = ldprefab.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject go = ldprefab.Result.Clone(edit031MenuMapCatalog.topInterface_.transform);
    edit031MenuMapCatalog.catalog_ = go.GetComponent<MapEditBaseMapSelect>();
    int master = edit031MenuMapCatalog.topMenu_.data_.saveSlot_._master;
    PlayerGuildTown[] towns = SMManager.Get<PlayerGuildTown[]>() ?? new PlayerGuildTown[0];
    e = edit031MenuMapCatalog.catalog_.initialize(towns, master, new System.Action<PlayerGuildTown>(edit031MenuMapCatalog.onSelectedMap), new System.Action<int>(edit031MenuMapCatalog.onClickedDetail), new System.Action(((BackButtonMenuBase) edit031MenuMapCatalog).onBackButton));
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    edit031MenuMapCatalog.addControlObject(go);
  }

  protected override void onEnable()
  {
  }

  protected override void onDisable()
  {
  }

  public override void onBackButton()
  {
    if (this.waitAndSet())
      return;
    this.topMenu_.backMapCatalog();
  }

  private void onSelectedMap(PlayerGuildTown town)
  {
    if (town != null)
    {
      if (this.waitAndSet())
        return;
      this.StartCoroutine(this.doConfirmExchange(town));
    }
    else
      this.onBackButton();
  }

  private IEnumerator doConfirmExchange(PlayerGuildTown town)
  {
    yield return (object) null;
    int townId = town._master;
    IEnumerator e = MapEditPopupConfirmExchangeMap.show(town, (System.Action) (() =>
    {
      this.catalog_.setCurrent(townId);
      this.topMenu_.exchangeMap(townId);
    }), (System.Action) (() => this.clearWait()));
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private void onClickedDetail(int id)
  {
    if (this.waitAndSet())
      return;
    this.StartCoroutine(this.doPopupDetail(id));
  }

  private IEnumerator doPopupDetail(int id)
  {
    MapEdit031MenuMapCatalog edit031MenuMapCatalog = this;
    Future<GameObject> ldPopup = MapEdit.Prefabs.popup_base_map_detail.Load<GameObject>();
    IEnumerator e = ldPopup.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if ((UnityEngine.Object) ldPopup.Result == (UnityEngine.Object) null)
    {
      edit031MenuMapCatalog.clearWait();
    }
    else
    {
      GameObject go = Singleton<PopupManager>.GetInstance().open(ldPopup.Result, isNonSe: true, isNonOpenAnime: true);
      e = go.GetComponent<PopupMapDetailMenu>().InitializeAsync(id);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      Singleton<PopupManager>.GetInstance().startOpenAnime(go);
      while (Singleton<PopupManager>.GetInstance().isOpen)
        yield return (object) null;
      edit031MenuMapCatalog.clearWait();
    }
  }
}
