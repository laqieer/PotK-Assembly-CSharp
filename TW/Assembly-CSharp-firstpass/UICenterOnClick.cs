// Decompiled with JetBrains decompiler
// Type: UICenterOnClick
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Center Scroll View on Click")]
public class UICenterOnClick : MonoBehaviour
{
  private void OnClick()
  {
    UICenterOnChild inParents1 = NGUITools.FindInParents<UICenterOnChild>(((Component) this).gameObject);
    UIPanel inParents2 = NGUITools.FindInParents<UIPanel>(((Component) this).gameObject);
    if (Object.op_Inequality((Object) inParents1, (Object) null))
    {
      if (!((Behaviour) inParents1).enabled)
        return;
      inParents1.CenterOn(((Component) this).transform);
    }
    else
    {
      if (!Object.op_Inequality((Object) inParents2, (Object) null) || inParents2.clipping == UIDrawCall.Clipping.None)
        return;
      UIScrollView component = ((Component) inParents2).GetComponent<UIScrollView>();
      Vector3 pos = Vector3.op_UnaryNegation(inParents2.cachedTransform.InverseTransformPoint(((Component) this).transform.position));
      if (!component.canMoveHorizontally)
        pos.x = inParents2.cachedTransform.localPosition.x;
      if (!component.canMoveVertically)
        pos.y = inParents2.cachedTransform.localPosition.y;
      SpringPanel.Begin(inParents2.cachedGameObject, pos, 6f);
    }
  }
}
