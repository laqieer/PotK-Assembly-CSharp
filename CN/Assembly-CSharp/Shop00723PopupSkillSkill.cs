// Decompiled with JetBrains decompiler
// Type: Shop00723PopupSkillSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00723PopupSkillSkill : MonoBehaviour
{
  private const int DEFAULT_UNIT_LEVEL = 1;
  private const int WIDTH_ICON_ELEMENT = 60;
  private const int HEIGHT_ICON_ELEMENT = 55;
  private const float DURATION_CHANGEALPHA = 0.5f;
  [SerializeField]
  private UIWidget base_;
  [SerializeField]
  private GameObject labelSkill_;
  [SerializeField]
  private GameObject labelMagic_;
  [SerializeField]
  private GameObject btnChange_;
  [SerializeField]
  private UILabel txtName_;
  [SerializeField]
  private UILabel txtDetail_;
  [SerializeField]
  private UILabel txtMaxLv_;
  [SerializeField]
  private UILabel txtFactor_;
  [SerializeField]
  private GameObject topIcon_;
  [SerializeField]
  private GameObject[] topIconGenres_ = new GameObject[2];
  private bool isAutoChange_;
  private int current_;
  private int countFadeIn_;
  private int countFadeOut_;
  private GameObject[] objNames_;
  private GameObject[] objDetails_;
  private GameObject[] objMaxLvs_;
  private GameObject[] objIcons_;
  private GameObject[] objFactors_;
  private GameObject[] objGenres1_;
  private GameObject[] objGenres2_;
  private UnitBattleSkillOrigin[] skillOrigins_;
  private static Color COLOR_GRAY = new Color(0.3f, 0.3f, 0.3f);

  [DebuggerHidden]
  public IEnumerator coInitialize(Shop00723Menu menu, UnitBattleSkillOrigin[] datas)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723PopupSkillSkill.\u003CcoInitialize\u003Ec__Iterator478()
    {
      datas = datas,
      menu = menu,
      \u003C\u0024\u003Edatas = datas,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  private GameObject[] cloningLabel(UnitBattleSkillOrigin[] skills, UILabel labelOriginal)
  {
    GameObject gameObject = ((Component) labelOriginal).gameObject;
    GameObject[] gameObjectArray = new GameObject[1];
    bool flag = false;
    for (int index = 0; index < gameObjectArray.Length; ++index)
    {
      if (skills[index] != null)
      {
        if (flag)
        {
          gameObjectArray[index] = gameObject.Clone(gameObject.transform.parent);
          gameObjectArray[index].transform.localPosition = gameObject.transform.localPosition;
          gameObjectArray[index].transform.localRotation = gameObject.transform.localRotation;
          gameObjectArray[index].transform.localScale = gameObject.transform.localScale;
        }
        else
        {
          gameObjectArray[index] = gameObject;
          flag = true;
        }
      }
    }
    return gameObjectArray;
  }

  [DebuggerHidden]
  private IEnumerator coInitialize(Shop00723Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723PopupSkillSkill.\u003CcoInitialize\u003Ec__Iterator479()
    {
      menu = menu,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  private void Awake()
  {
    ((Collider) ((Component) this).GetComponent<BoxCollider>()).enabled = false;
  }

  public int CountSkillOrigins => this.skillOrigins_.Length;

  public void changeInfo(int index)
  {
    if (!this.isAutoChange_)
      return;
    this.changeInfoP(index, false);
  }

  private void changeInfoP(int index, bool bImmediate)
  {
    if (index >= this.objNames_.Length)
      index = this.objNames_.Length - 1;
    if (this.current_ == index)
      return;
    int current = this.current_;
    int index1 = index;
    this.changeGameObject(this.objNames_[current], this.objNames_[index1], bImmediate);
    this.changeGameObject(this.objDetails_[current], this.objDetails_[index1], bImmediate);
    this.changeGameObject(this.objMaxLvs_[current], this.objMaxLvs_[index1], bImmediate);
    this.changeGameObject(this.objIcons_[current], this.objIcons_[index1], bImmediate);
    this.changeGameObject(this.objFactors_[current], this.objFactors_[index1], bImmediate);
    this.changeGameObject(this.objGenres1_[current], this.objGenres1_[index1], bImmediate);
    this.changeGameObject(this.objGenres2_[current], this.objGenres2_[index1], bImmediate);
    this.current_ = index;
  }

  private void changeGameObject(GameObject go1, GameObject go2, bool bImmediate)
  {
    if (bImmediate)
    {
      if (Object.op_Inequality((Object) go1, (Object) null))
        go1.SetActive(false);
      if (!Object.op_Inequality((Object) go2, (Object) null))
        return;
      go2.SetActive(true);
    }
    else
    {
      if (Object.op_Inequality((Object) go1, (Object) null))
      {
        ++this.countFadeOut_;
        TweenAlpha ta1 = TweenAlpha.Begin(go1, 0.5f, 0.0f);
        EventDelegate.Set(ta1.onFinished, (EventDelegate.Callback) (() =>
        {
          --this.countFadeOut_;
          ta1.value = 1f;
          go1.SetActive(false);
          Object.Destroy((Object) ta1);
        }));
      }
      if (!Object.op_Inequality((Object) go2, (Object) null))
        return;
      ++this.countFadeIn_;
      go2.SetActive(true);
      go2.GetComponent<UIRect>().alpha = 0.0f;
      TweenAlpha ta2 = TweenAlpha.Begin(go2, 0.5f, 1f);
      EventDelegate.Set(ta2.onFinished, (EventDelegate.Callback) (() =>
      {
        --this.countFadeIn_;
        Object.Destroy((Object) ta2);
      }));
    }
  }
}
