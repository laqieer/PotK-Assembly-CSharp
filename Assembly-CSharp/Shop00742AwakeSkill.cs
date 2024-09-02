// Decompiled with JetBrains decompiler
// Type: Shop00742AwakeSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using UnityEngine;

public class Shop00742AwakeSkill : MonoBehaviour
{
  private Battle0171111Event floatingSkillDialogObject;

  public IEnumerator Init(int entity_id, ItemDetailPopupBase itemDetailPopupBase)
  {
    Shop00742AwakeSkill shop00742AwakeSkill = this;
    Future<GameObject> loader = Res.Prefabs.battle017_11_1_1.SkillDetailDialog.Load<GameObject>();
    IEnumerator e = loader.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject result = loader.Result;
    BattleskillSkill skill = MasterData.BattleskillSkill[entity_id];
    if ((Object) shop00742AwakeSkill.gameObject != (Object) null)
    {
      if ((Object) shop00742AwakeSkill.floatingSkillDialogObject == (Object) null)
      {
        shop00742AwakeSkill.gameObject.transform.Clear();
        shop00742AwakeSkill.floatingSkillDialogObject = result.Clone(shop00742AwakeSkill.gameObject.transform).GetComponentInChildren<Battle0171111Event>();
      }
      shop00742AwakeSkill.floatingSkillDialogObject.transform.parent.gameObject.SetActive(false);
      shop00742AwakeSkill.floatingSkillDialogObject.setSkillLv(0);
      shop00742AwakeSkill.floatingSkillDialogObject.setData(skill);
      shop00742AwakeSkill.floatingSkillDialogObject.setClosePopup(itemDetailPopupBase);
      e = shop00742AwakeSkill.floatingSkillDialogObject.ShowAsync();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }
}
