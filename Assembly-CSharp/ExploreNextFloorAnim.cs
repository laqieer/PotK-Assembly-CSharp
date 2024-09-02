// Decompiled with JetBrains decompiler
// Type: ExploreNextFloorAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

public class ExploreNextFloorAnim : MonoBehaviour
{
  private const string floorNumSpriteFormat = "slc_text_{0}.png__GUI__battleUI_05__battleUI_05_prefab";
  public const int BaseLayer = 0;
  [SerializeField]
  private Animator anim;
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UISprite[] sprFloorNumber;
  [SerializeField]
  private UIGrid gridDirFloor;

  public void Initialize(string name, int floor)
  {
    this.txtTitle.SetTextLocalize(name);
    int num1 = 1;
    for (int index = 0; index < this.sprFloorNumber.Length; ++index)
      num1 *= 10;
    int b = num1 - 1;
    floor = Mathf.Min(floor, b);
    int num2 = floor;
    ((IEnumerable<UISprite>) this.sprFloorNumber).ForEach<UISprite>((System.Action<UISprite>) (x => x.gameObject.SetActive(false)));
    for (int index = 0; index < this.sprFloorNumber.Length; ++index)
    {
      this.sprFloorNumber[index].gameObject.SetActive(true);
      this.sprFloorNumber[index].spriteName = "slc_text_{0}.png__GUI__battleUI_05__battleUI_05_prefab".F((object) (num2 % 10));
      num2 /= 10;
      if (num2 <= 0)
        break;
    }
    ((IEnumerable<UISprite>) this.sprFloorNumber).ForEach<UISprite>((System.Action<UISprite>) (x =>
    {
      if (x.gameObject.activeSelf)
        return;
      x.gameObject.SingletonDestory();
      x = (UISprite) null;
    }));
    this.gridDirFloor.Reposition();
  }

  public void Close() => Singleton<PopupManager>.GetInstance().dismiss();

  public bool animEnd => (double) this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 2.0;
}
