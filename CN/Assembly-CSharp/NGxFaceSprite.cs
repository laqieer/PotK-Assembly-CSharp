// Decompiled with JetBrains decompiler
// Type: NGxFaceSprite
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class NGxFaceSprite : MonoBehaviour
{
  public static readonly string[] Faces = new string[17]
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
  public string faceName = "normal";
  public UI2DSprite FaceUI2DSprite;
  public NGxMaskSpriteWithScale mask;
  private Dictionary<string, Sprite> faceSpriteDict = new Dictionary<string, Sprite>();
  [SerializeField]
  private int unitID;
  private int resourceUnitID;

  private void Start()
  {
    this.resourceUnitID = !MasterData.UnitUnit.ContainsKey(this.unitID) ? this.unitID : MasterData.UnitUnit[this.unitID].resource_reference_unit_id_UnitUnit;
    this.StartCoroutine(this.ChangeFace(this.faceName));
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
      this.faceSpriteDict.Clear();
      this.mask.MainUI2DSprite.sprite2D = (Sprite) null;
    }
  }

  [DebuggerHidden]
  public IEnumerator ChangeFace(string faceName_)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGxFaceSprite.\u003CChangeFace\u003Ec__IteratorA8C()
    {
      faceName_ = faceName_,
      \u003C\u0024\u003EfaceName_ = faceName_,
      \u003C\u003Ef__this = this
    };
  }

  public void updateFaceSprite(string faceName, Sprite sprite)
  {
    this.faceSpriteDict[faceName] = sprite;
    this.FaceUI2DSprite.sprite2D = sprite;
    if (Object.op_Equality((Object) sprite, (Object) null))
      return;
    this.FaceUI2DSprite.SetDimensions(((Texture) sprite.texture).width, ((Texture) sprite.texture).height);
    Vector3 localPosition = ((Component) this.FaceUI2DSprite).gameObject.transform.localPosition;
    float num1 = (float) this.mask.xOffsetPixel * this.mask.scale;
    float num2 = (float) this.mask.yOffsetPixel * this.mask.scale + this.mask.topOffset;
    if (MasterData.UnitUnitStory.ContainsKey(this.resourceUnitID))
    {
      UnitUnitStory unitUnitStory = MasterData.UnitUnitStory[this.resourceUnitID];
      UI2DSprite component = ((Component) ((Component) this.FaceUI2DSprite).transform.parent).gameObject.GetComponent<UI2DSprite>();
      num1 += (float) (((Texture) component.sprite2D.texture).width / 2 - (unitUnitStory.face_x + ((Texture) sprite.texture).width / 2)) * this.mask.scale;
      num2 += (float) (((Texture) component.sprite2D.texture).height / 2 - (unitUnitStory.face_y + ((Texture) sprite.texture).height / 2)) * this.mask.scale;
    }
    ((Component) this.FaceUI2DSprite).gameObject.transform.localScale = new Vector3(this.mask.scale, this.mask.scale, 1f);
    ((Component) this.FaceUI2DSprite).gameObject.transform.localPosition = new Vector3(-num1, -num2, localPosition.z);
    this.FaceUI2DSprite.depth = ((Component) ((Component) this.FaceUI2DSprite).transform.parent).gameObject.GetComponent<UIWidget>().depth + 1;
  }
}
