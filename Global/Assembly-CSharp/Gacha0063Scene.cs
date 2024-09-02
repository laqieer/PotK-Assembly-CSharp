// Decompiled with JetBrains decompiler
// Type: Gacha0063Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Gacha0063Scene : NGSceneBase
{
  private const int GachaModuleMax = 3;
  [SerializeField]
  private Gacha0063Menu gacha0063Menu;
  [SerializeField]
  private NGHorizontalScrollParts scrollParts;
  [SerializeField]
  private UICenterOnChild centerOnChild;
  [SerializeField]
  private UIScrollView scrollView;
  [SerializeField]
  private UIGrid grid;
  public Consts.GachaType GachaType;
  protected Modified<GachaModule[]> gachaModule;
  public bool apiUpdate;
  public DateTime serverTime;
  private Dictionary<int, Transform> gachas = new Dictionary<int, Transform>();
  private bool update;
  private bool seEnable;
  private bool apiError;
  private List<Gacha0063hindicator> gacha0063hindicatorList;
  private GameObject kisekiPrefab;
  private GameObject pointPrefab;
  private GameObject ticketPrefab;
  private GameObject detailPopup;
  public GameObject dirPanel;
  public GameObject dirPanelSpecial;

  public UIScrollView ScrollView => this.scrollView;

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Scene.\u003ConInitSceneAsync\u003Ec__Iterator36C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Scene.\u003ConStartSceneAsync\u003Ec__Iterator36D()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int gachaType, bool forceApiUpdate)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Scene.\u003ConStartSceneAsync\u003Ec__Iterator36E()
    {
      forceApiUpdate = forceApiUpdate,
      gachaType = gachaType,
      \u003C\u0024\u003EforceApiUpdate = forceApiUpdate,
      \u003C\u0024\u003EgachaType = gachaType,
      \u003C\u003Ef__this = this
    };
  }

  private bool IsSyncRemote()
  {
    return ((IEnumerable<bool>) new bool[3]
    {
      this.apiUpdate,
      DateTime.Now > Singleton<NGGameDataManager>.GetInstance().lastGachaTime.AddMinutes(10.0),
      DateTime.Now.Hour != Singleton<NGGameDataManager>.GetInstance().lastGachaTime.Hour
    }).Any<bool>((Func<bool, bool>) (a => a));
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(int gachaType)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Scene.\u003ConStartSceneAsync\u003Ec__Iterator36F()
    {
      gachaType = gachaType,
      \u003C\u0024\u003EgachaType = gachaType,
      \u003C\u003Ef__this = this
    };
  }

  private int GetGachaPageLength(GachaModule[] gachaModules)
  {
    int num = ((IEnumerable<GachaModule>) gachaModules).Count<GachaModule>((Func<GachaModule, bool>) (c => c.number != 4));
    GachaModule gachaModule = ((IEnumerable<GachaModule>) gachaModules).FirstOrDefault<GachaModule>((Func<GachaModule, bool>) (n => n.number == 4));
    int length = gachaModule == null ? 0 : gachaModule.gacha.Length;
    return num + length;
  }

  public void onStartScene()
  {
    if (this.apiError)
      return;
    this.gacha0063hindicatorList.ForEach((Action<Gacha0063hindicator>) (x => x.EndAnim()));
    Singleton<PopupManager>.GetInstance().closeAll();
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    this.gacha0063hindicatorList.ForEach((Action<Gacha0063hindicator>) (x => x.PlayAnim()));
  }

  public void onStartScene(int gacha_type)
  {
    if (this.apiError)
      return;
    this.gacha0063hindicatorList.ForEach((Action<Gacha0063hindicator>) (x => x.EndAnim()));
    Singleton<PopupManager>.GetInstance().closeAll();
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    this.gacha0063hindicatorList.ForEach((Action<Gacha0063hindicator>) (x => x.PlayAnim()));
  }

  public void onStartScene(int gacha_type, bool forceApiUpdate)
  {
    if (this.apiError)
      return;
    this.gacha0063hindicatorList.ForEach((Action<Gacha0063hindicator>) (x => x.EndAnim()));
    Singleton<PopupManager>.GetInstance().closeAll();
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    this.gacha0063hindicatorList.ForEach((Action<Gacha0063hindicator>) (x => x.PlayAnim()));
  }

  public override void onEndScene()
  {
    if (this.apiError)
      return;
    this.seEnable = false;
    this.scrollParts.SeEnable = false;
    this.gacha0063hindicatorList.ForEach((Action<Gacha0063hindicator>) (x => x.EndAnim()));
  }

  private void StartPoint(int gacha_type)
  {
    if (!this.gachas.ContainsKey(gacha_type))
      return;
    this.scrollParts.setItemPosition(this.scrollParts.GetIndex(this.gachas[gacha_type]));
    this.scrollParts.setItemPositionQuick(this.scrollParts.GetIndex(this.gachas[gacha_type]));
  }

  public void BackPage()
  {
    int index = this.scrollParts.selected - 1;
    if (index < 0)
      return;
    this.centerOnChild.CenterOn(((Component) this.gacha0063hindicatorList[index]).transform);
  }

  public void NextPage()
  {
    int index = this.scrollParts.selected + 1;
    if (index >= this.gacha0063hindicatorList.Count)
      return;
    this.centerOnChild.CenterOn(((Component) this.gacha0063hindicatorList[index]).transform);
  }

  [DebuggerHidden]
  private IEnumerator WaitScrollSe()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Scene.\u003CWaitScrollSe\u003Ec__Iterator370()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreatePrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Scene.\u003CCreatePrefab\u003Ec__Iterator371()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateGachaList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Scene.\u003CCreateGachaList\u003Ec__Iterator372()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void AddGachaIndicator(GameObject prefab, GachaModule gachaModule)
  {
    bool flag = false;
    if (gachaModule.type == 4)
    {
      if (gachaModule.gacha != null && gachaModule.gacha.Length > 0)
        flag = true;
    }
    else if (gachaModule.gacha != null && gachaModule.gacha.Length > 0 && gachaModule.gacha.Length < 3)
      flag = true;
    if (!flag)
      return;
    Gacha0063hindicator component = this.scrollParts.instantiateParts(prefab, false).GetComponent<Gacha0063hindicator>();
    this.gacha0063Menu.scene = this;
    component.InitGachaModuleGacha(this.gacha0063Menu, gachaModule, this.serverTime, this.scrollView);
    this.gacha0063hindicatorList.Add(component);
    this.gachas[gachaModule.number] = ((Component) component).transform;
  }

  private void AddGachaIndicator(
    GameObject prefab,
    GachaModule gachaModule,
    GachaModuleGacha gacha)
  {
    if (gachaModule.gacha == null || gachaModule.gacha.Length <= 0 || gachaModule.gacha.Length >= 3)
      return;
    Gacha0063Ticket component = this.scrollParts.instantiateParts(prefab, false).GetComponent<Gacha0063Ticket>();
    this.gacha0063Menu.scene = this;
    component.InitGachaModuleGacha(this.gacha0063Menu, gacha);
    this.gacha0063hindicatorList.Add((Gacha0063hindicator) component);
    if (this.gachas.ContainsKey(gachaModule.number))
      return;
    this.gachas[gachaModule.number] = ((Component) component).transform;
  }

  private void PadScale()
  {
    if (!Object.op_Inequality((Object) this.ScrollView, (Object) null) || !Object.op_Inequality((Object) this.grid, (Object) null))
      return;
    this.grid.cellWidth = ((Component) this.ScrollView).gameObject.GetComponent<UIPanel>().width;
  }

  [DebuggerHidden]
  private IEnumerator SetBackGround()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063Scene.\u003CSetBackGround\u003Ec__Iterator373()
    {
      \u003C\u003Ef__this = this
    };
  }

  public bool IsLimited(GachaModule module)
  {
    DateTime? endAt = module.period.end_at;
    TimeSpan? nullable = !endAt.HasValue ? new TimeSpan?() : new TimeSpan?(endAt.Value - this.serverTime);
    return module.period.end_at.HasValue && nullable.Value.Milliseconds < 0;
  }
}
