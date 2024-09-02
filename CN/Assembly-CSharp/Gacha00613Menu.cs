// Decompiled with JetBrains decompiler
// Type: Gacha00613Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Gacha00613Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private UIButton nextBtn;
  [SerializeField]
  private UIButton tryAgainBtn;
  [SerializeField]
  private UIButton ptlianchouBtn;
  public Startup00010Score startup;
  public Gacha00613Scene Scene;
  public List<Transform> SpriteList;
  public List<GameObject> IconList;
  private int btnSpacing = 20;
  private int point_count;
  public Consts.GachaType gachaType;
  private Gacha0063Menu menu;
  private GachaModule gachaModule;
  private GachaModuleGacha gachaModuleGacha;
  public int gachaModuleGachaId = -1;
  public string gachaModuleName;
  private int maxRollCount;
  private bool isBtnAction = true;

  public bool IsBtnAction => this.isBtnAction;

  public void BtnActionEnable(bool enable)
  {
    this.isBtnAction = enable;
    foreach (GameObject icon in this.IconList)
    {
      Transform child = icon.transform.FindChild("button");
      if (Object.op_Inequality((Object) child, (Object) null))
        ((Component) child).gameObject.SetActive(enable);
    }
    Singleton<CommonRoot>.GetInstance().SetFooterEnable(this.isBtnAction);
  }

  public void IbtnBack()
  {
    if (!this.isBtnAction)
      return;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_3", false, (object) (int) this.gachaType);
  }

  public void TryAgain()
  {
    if (this.gachaModule == null || this.gachaModuleGacha == null || !this.canGachaAgainWithData())
      return;
    if (this.gachaType == Consts.GachaType.FRIEND)
    {
      if (!this.menu.CheckGachaPt(this.gachaModuleGacha, this.maxRollCount, true) || this.IsPushAndSet())
        return;
      this.menu.scene.GachaType = this.gachaType;
      this.StartCoroutine(this.Play(this.maxRollCount, this.gachaModuleGacha));
    }
    else
    {
      if (!this.menu.CheckGachaCharge(this.gachaModuleGacha) || this.IsPushAndSet())
        return;
      this.menu.scene.GachaType = this.gachaType;
      Singleton<PopupManager>.GetInstance().open(this.menu.gachaChargePrefab).GetComponent<Gacha0065Menu>().Init(this.gachaModule.name, this.gachaModuleGacha, this.menu.scene);
    }
  }

  [DebuggerHidden]
  public IEnumerator Play(int num = 1, GachaModuleGacha gacha_data = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Menu.\u003CPlay\u003Ec__Iterator3D8()
    {
      num = num,
      gacha_data = gacha_data,
      \u003C\u0024\u003Enum = num,
      \u003C\u0024\u003Egacha_data = gacha_data,
      \u003C\u003Ef__this = this
    };
  }

  public void EvenSmoke()
  {
    if (this.gachaModuleGacha == null || this.point_count < 1 || !this.canGachaRemainBy(this.gachaType) || !this.menu.CheckGachaPt(this.gachaModuleGacha, this.point_count, true) || this.IsPushAndSet())
      return;
    this.menu.scene.GachaType = this.gachaType;
    this.StartCoroutine(this.Play(this.point_count, this.gachaModuleGacha));
  }

  public override void onBackButton() => this.IbtnBack();

  private void refreshButtons()
  {
    ((Component) ((Component) this.tryAgainBtn).transform).gameObject.SetActive(false);
    ((Component) ((Component) this.ptlianchouBtn).transform).gameObject.SetActive(false);
    if (this.gachaModule == null || this.gachaModuleGacha == null)
      return;
    Vector3 localPosition1 = ((Component) this.nextBtn).transform.localPosition;
    int num1 = -(((Component) this.nextBtn).GetComponent<UIWidget>().width / 2 + this.btnSpacing);
    localPosition1.x = (float) num1;
    if (this.canGachaAgainWithData())
    {
      Vector3 localPosition2 = ((Component) this.tryAgainBtn).transform.localPosition;
      int num2 = ((Component) this.tryAgainBtn).GetComponent<UIWidget>().width / 2 + this.btnSpacing;
      localPosition2.x = (float) num2;
      ((Component) this.tryAgainBtn).transform.localPosition = localPosition2;
      ((Component) ((Component) this.tryAgainBtn).transform).gameObject.SetActive(true);
      ((Component) this.nextBtn).transform.localPosition = localPosition1;
    }
    else if (this.point_count < 1 || !this.canGachaRemainBy(this.gachaType))
    {
      localPosition1.x = 0.0f;
      ((Component) this.nextBtn).transform.localPosition = localPosition1;
    }
    else
    {
      if (Object.op_Inequality((Object) this.startup, (Object) null))
        this.startup.SetActive(this.point_count);
      Vector3 localPosition3 = ((Component) this.ptlianchouBtn).transform.localPosition;
      int num3 = ((Component) this.ptlianchouBtn).GetComponent<UIWidget>().width / 2 + this.btnSpacing;
      localPosition3.x = (float) num3;
      ((Component) this.ptlianchouBtn).transform.localPosition = localPosition3;
      ((Component) ((Component) this.ptlianchouBtn).transform).gameObject.SetActive(true);
      ((Component) this.nextBtn).transform.localPosition = localPosition1;
    }
  }

  public bool canGachaRemainBy(Consts.GachaType type) => type == Consts.GachaType.FRIEND;

  public bool canGachaAgainWithData()
  {
    if (this.gachaType == Consts.GachaType.FRIEND)
    {
      if (this.maxRollCount > 0 && this.point_count >= this.maxRollCount)
        return true;
    }
    else if (this.gachaModuleGacha != null && (this.gachaType == Consts.GachaType.KISEKI || this.gachaType == Consts.GachaType.PICKUP || this.gachaType == Consts.GachaType.BEGINNER || this.gachaType == Consts.GachaType.SHEET) && SMManager.Get<Player>().CheckKiseki(this.gachaModuleGacha.payment_amount))
      return true;
    return false;
  }

  [DebuggerHidden]
  public IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Menu.\u003ConEndSceneAsync\u003Ec__Iterator3D9()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CreateGetListAsync(GachaResultData.ResultData resultData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha00613Menu.\u003CCreateGetListAsync\u003Ec__Iterator3DA()
    {
      resultData = resultData,
      \u003C\u0024\u003EresultData = resultData,
      \u003C\u003Ef__this = this
    };
  }

  public void SetEvent(UnitIcon UI, MonoBehaviour target)
  {
    UI.button.onLongPress.Clear();
    UI.button.onLongPress.Add(new EventDelegate(target, "IbtnIcon"));
    UI.button.onClick.Clear();
    UI.button.onClick.Add(new EventDelegate(target, "IbtnIcon"));
  }

  public void SetEvent(ItemIcon II, MonoBehaviour target)
  {
    II.gear.button.onLongPress.Clear();
    II.gear.button.onLongPress.Add(new EventDelegate(target, "IbtnIcon"));
    II.gear.button.onClick.Clear();
    II.gear.button.onClick.Add(new EventDelegate(target, "IbtnIcon"));
  }
}
