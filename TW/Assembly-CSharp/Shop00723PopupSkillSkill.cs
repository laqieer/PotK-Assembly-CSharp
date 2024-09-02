// Decompiled with JetBrains decompiler
// Type: Shop00723PopupSkillSkill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  private const int DEPTH_INTERVAL = 1;
  [SerializeField]
  private UIWidget base_;
  [SerializeField]
  private GameObject labelSkill_;
  [SerializeField]
  private GameObject labelMagic_;
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
  private GameObject objIcon_;
  private GameObject objFactor_;
  private GameObject objGenre1_;
  private GameObject objGenre2_;
  private UnitBattleSkillOrigin[] skillOrigins_;
  private static Color COLOR_GRAY = new Color(0.3f, 0.3f, 0.3f);

  [DebuggerHidden]
  public IEnumerator coInitialize(Shop00723Menu menu, UnitBattleSkillOrigin[] datas)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723PopupSkillSkill.\u003CcoInitialize\u003Ec__Iterator4C0()
    {
      datas = datas,
      menu = menu,
      \u003C\u0024\u003Edatas = datas,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator coInitialize(Shop00723Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723PopupSkillSkill.\u003CcoInitialize\u003Ec__Iterator4C1()
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
}
