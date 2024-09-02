// Decompiled with JetBrains decompiler
// Type: Unit0046Character
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Unit0046Character : MonoBehaviour
{
  public GameObject select;
  public GameObject Notselect;
  public int mynumber;
  [SerializeField]
  private UISprite specialIcon;
  private static readonly string specialIconSpriteName = "slc_icon_specific_effectiveness_{0}.png__GUI__004-6_sozai__004-6_sozai_prefab";

  public void CharaSetActive(bool selectCondition, string SpecialType)
  {
    this.Notselect.SetActive(!selectCondition);
    bool flag = !string.IsNullOrEmpty(SpecialType);
    ((Component) this.specialIcon).gameObject.SetActive(flag);
    if (!flag)
      return;
    this.specialIcon.spriteName = string.Format(Unit0046Character.specialIconSpriteName, (object) SpecialType);
  }
}
