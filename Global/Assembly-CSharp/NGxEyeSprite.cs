// Decompiled with JetBrains decompiler
// Type: NGxEyeSprite
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class NGxEyeSprite : MonoBehaviour
{
  public static readonly string[] Eyes = new string[17]
  {
    "normal",
    "nutual",
    "angry",
    "angry01",
    "angry02",
    "cry",
    "happy",
    "mad",
    "shy",
    "occur",
    "proud",
    "sad",
    "smile",
    "smile01",
    "smile02",
    "surprised",
    "unhappy"
  };
  public string EyeName = "normal";
  public UI2DSprite EyeUI2DSprite;
  public NGxMaskSpriteWithScale mask;
  private Dictionary<string, Sprite> eyeSpriteDict = new Dictionary<string, Sprite>();
  [SerializeField]
  private int unitID;
  private int resourceUnitID;

  private void Start()
  {
    this.resourceUnitID = !MasterData.UnitUnit.ContainsKey(this.unitID) ? this.unitID : MasterData.UnitUnit[this.unitID].resource_reference_unit_id_UnitUnit;
    this.StartCoroutine(this.ChangeEye(this.EyeName));
  }

  public int UnitID
  {
    get => this.unitID;
    set
    {
      if (this.unitID == value)
        return;
      this.unitID = value;
      this.resourceUnitID = !MasterData.UnitUnit.ContainsKey(this.unitID) ? this.unitID : MasterData.UnitUnit[this.unitID].resource_reference_unit_id_UnitUnit;
      this.eyeSpriteDict.Clear();
      this.mask.MainUI2DSprite.sprite2D = (Sprite) null;
    }
  }

  [DebuggerHidden]
  public IEnumerator ChangeEye(string eyeName)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGxEyeSprite.\u003CChangeEye\u003Ec__Iterator8F8()
    {
      eyeName = eyeName,
      \u003C\u0024\u003EeyeName = eyeName,
      \u003C\u003Ef__this = this
    };
  }

  public void updateEyeSprite(string eyeName, Sprite sprite)
  {
    this.eyeSpriteDict[eyeName] = sprite;
    this.EyeUI2DSprite.sprite2D = sprite;
    if (Object.op_Equality((Object) sprite, (Object) null))
      return;
    this.EyeUI2DSprite.SetDimensions(((Texture) sprite.texture).width, ((Texture) sprite.texture).height);
    Vector3 localPosition = ((Component) this.EyeUI2DSprite).gameObject.transform.localPosition;
    float num1 = (float) this.mask.xOffsetPixel * this.mask.scale;
    float num2 = (float) this.mask.yOffsetPixel * this.mask.scale + this.mask.topOffset;
    if (MasterData.UnitUnitStory.ContainsKey(this.resourceUnitID))
    {
      UnitUnitStory unitUnitStory = MasterData.UnitUnitStory[this.resourceUnitID];
      UI2DSprite component = ((Component) ((Component) this.EyeUI2DSprite).transform.parent).gameObject.GetComponent<UI2DSprite>();
      num1 += (float) (((Texture) component.sprite2D.texture).width / 2 - (unitUnitStory.face_x + ((Texture) sprite.texture).width / 2)) * this.mask.scale;
      num2 += (float) (((Texture) component.sprite2D.texture).height / 2 - (unitUnitStory.face_y + ((Texture) sprite.texture).height / 2)) * this.mask.scale;
    }
    ((Component) this.EyeUI2DSprite).gameObject.transform.localScale = new Vector3(this.mask.scale, this.mask.scale, 1f);
    ((Component) this.EyeUI2DSprite).gameObject.transform.localPosition = new Vector3(-num1, -num2, localPosition.z);
    this.EyeUI2DSprite.depth = ((Component) ((Component) this.EyeUI2DSprite).transform.parent).gameObject.GetComponent<UIWidget>().depth + 2;
  }
}
