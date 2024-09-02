// Decompiled with JetBrains decompiler
// Type: Startup000121EventsScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup000121EventsScrollParts : Startup000121ScrollParts
{
  [SerializeField]
  private UI2DSprite sprite;

  [DebuggerHidden]
  public IEnumerator SetDataOld(OfficialInformationArticle info, NGMenuBase menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup000121EventsScrollParts.\u003CSetDataOld\u003Ec__Iterator174()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  public override void SetData(OfficialInformationArticle info, NGMenuBase menu)
  {
    this.article = info;
    ((MonoBehaviour) menu).StartCoroutine(Mypage00182Menu.LoadSprite(this.sprite, info.title_img_url, action: new System.Action(this.SetSprite)));
  }

  private void SetSprite()
  {
    this.sprite.SetDimensions(this.sprite.mainTexture.width, this.sprite.mainTexture.height);
    ((Component) this.sprite).GetComponent<BoxCollider>().size = new Vector3((float) this.sprite.mainTexture.width, (float) this.sprite.mainTexture.height, 0.0f);
    this.newSprite.transform.localPosition = new Vector3((float) (-(this.sprite.mainTexture.width / 2) + this.newSprite.GetComponent<UISprite>().width / 2 + 15), (float) (this.sprite.mainTexture.height / 2 + 14), this.newSprite.transform.localPosition.z);
  }
}
