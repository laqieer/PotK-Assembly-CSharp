// Decompiled with JetBrains decompiler
// Type: BattleUI01DirAilmentsDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class BattleUI01DirAilmentsDetail : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite slcAlimentsIcon;
  [SerializeField]
  private UILabel txtAlimentsName;
  [SerializeField]
  private UILabel txtDescription;
  [SerializeField]
  private UILabel txtRemainTurn;
  [SerializeField]
  private Color colorTextUnit;
  [SerializeField]
  private Color colorTextEnemy;
  [SerializeField]
  private Color colorTextSupply;

  public IEnumerator Init(BattleFuncs.InvestSkill s)
  {
    Future<UnityEngine.Sprite> ft = s.skill.LoadBattleSkillIcon(s);
    IEnumerator e = ft.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.slcAlimentsIcon.sprite2D = ft.Result;
    this.txtAlimentsName.text = s.skill.name;
    this.txtDescription.text = this.DescriptionText(s);
    if (s.turnRemain.HasValue)
    {
      this.txtRemainTurn.text = string.Format("残り{0}ターン", (object) s.turnRemain.ToString());
      this.txtRemainTurn.gameObject.SetActive(true);
    }
    else
      this.txtRemainTurn.gameObject.SetActive(false);
    Color color = this.TextColor(s);
    this.txtAlimentsName.color = color;
    this.txtDescription.color = color;
  }

  private string DescriptionText(BattleFuncs.InvestSkill s)
  {
    if (s.fromEnemy && !s.skill.shortDescriptionEnemy.isEmptyOrWhitespace())
      return s.skill.shortDescriptionEnemy;
    return !s.fromEnemy && !s.skill.shortDescription.isEmptyOrWhitespace() ? s.skill.shortDescription : s.skill.description;
  }

  private Color TextColor(BattleFuncs.InvestSkill s)
  {
    if (s.fromEnemy)
      return this.colorTextEnemy;
    return s.fromFriend ? this.colorTextSupply : this.colorTextUnit;
  }
}
