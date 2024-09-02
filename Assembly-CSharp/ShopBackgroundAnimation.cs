// Decompiled with JetBrains decompiler
// Type: ShopBackgroundAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class ShopBackgroundAnimation : MonoBehaviour
{
  public static GameObject CurrentShopBackground;
  [SerializeField]
  private Animator ShopBackgroundControllAnim;
  private RuntimeAnimatorController ShopBackgroundControllAnimRuntime;
  private int IsOut = Animator.StringToHash(nameof (IsOut));

  public void Change()
  {
    CommonBackground commonBackground = Singleton<CommonRoot>.GetInstance().getCommonBackground();
    if ((Object) ShopBackgroundAnimation.CurrentShopBackground == (Object) null)
    {
      commonBackground.releaseBackground();
    }
    else
    {
      ShopBackgroundAnimation component = ShopBackgroundAnimation.CurrentShopBackground.GetComponent<ShopBackgroundAnimation>();
      Singleton<NGSceneManager>.GetInstance().StartCoroutine(component.OutAnimation(component));
    }
    ShopBackgroundAnimation.CurrentShopBackground = NGUITools.AddChild(commonBackground.bgContainer.gameObject, this.gameObject);
    foreach (UI2DSprite componentsInChild in ShopBackgroundAnimation.CurrentShopBackground.GetComponentsInChildren<UI2DSprite>())
    {
      if (commonBackground.bgContainer.height >= componentsInChild.height)
      {
        componentsInChild.keepAspectRatio = UIWidget.AspectRatioSource.BasedOnHeight;
        componentsInChild.topAnchor.target = commonBackground.bgContainer.transform;
        componentsInChild.topAnchor.absolute = 0;
        componentsInChild.bottomAnchor.target = commonBackground.bgContainer.transform;
        componentsInChild.bottomAnchor.absolute = 0;
      }
    }
  }

  private IEnumerator OutAnimation(ShopBackgroundAnimation shopBackgroundAnimation)
  {
    this.ShopBackgroundControllAnim.SetTrigger(this.IsOut);
    yield return (object) null;
    int lastStateHash = this.ShopBackgroundControllAnim.GetCurrentAnimatorStateInfo(0).nameHash;
    while (true)
    {
      AnimatorStateInfo animatorStateInfo = this.ShopBackgroundControllAnim.GetCurrentAnimatorStateInfo(0);
      if (animatorStateInfo.fullPathHash != lastStateHash || (double) animatorStateInfo.normalizedTime < 1.0)
        yield return (object) null;
      else
        break;
    }
    Object.DestroyImmediate((Object) shopBackgroundAnimation.gameObject);
  }

  public bool IsWait() => this.ShopBackgroundControllAnim.GetCurrentAnimatorStateInfo(0).IsName("Wait");
}
