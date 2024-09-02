// Decompiled with JetBrains decompiler
// Type: Unit0042SEASkillReleaseMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class Unit0042SEASkillReleaseMenu : BackButtonMenuBase
{
  [SerializeField]
  private Transform popupPosition;
  [SerializeField]
  private TweenAlpha BgAlpha;
  private GameObject popupObj;
  private GameObject popupPrefab;
  private Animator anima;
  private int unitId;
  private int skillId;

  public IEnumerator LoadPrefab(int unitId, int skillId)
  {
    Future<GameObject> prefab = Res.Prefabs.battle.SEASkillGetPrefab.Load<GameObject>();
    IEnumerator e = prefab.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.popupPrefab = prefab.Result;
    this.unitId = unitId;
    this.skillId = skillId;
  }

  public IEnumerator CreatePopup()
  {
    this.popupObj = Singleton<PopupManager>.GetInstance().open(this.popupPrefab);
    Battle02029Menu component = this.popupObj.GetComponent<Battle02029Menu>();
    this.popupObj.GetComponent<Unit0042SEASkillEffectPopup>().InitPopup(this.BgAlpha);
    this.popupObj.SetActive(false);
    this.BgAlpha.tweenFactor = 0.0f;
    this.BgAlpha.from = 0.0f;
    this.BgAlpha.to = 1f;
    this.BgAlpha.PlayForward();
    IEnumerator e = component.Init(this.unitId, this.skillId, true);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public override void onBackButton()
  {
  }
}
