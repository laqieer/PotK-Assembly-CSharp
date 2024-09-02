// Decompiled with JetBrains decompiler
// Type: I2.Loc.Localize
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace I2.Loc
{
  [AddComponentMenu("I2/Localization/Localize")]
  public class Localize : MonoBehaviour
  {
    public string mTerm;
    public string mTermSecondary;
    [NonSerialized]
    public string FinalTerm;
    [NonSerialized]
    public string FinalSecondaryTerm;
    public Localize.TermModification PrimaryTermModifier;
    public Localize.TermModification SecondaryTermModifier;
    public bool LocalizeOnAwake;
    private string LastLocalizedLanguage;
    public Object mTarget;
    public Localize.DelegateSetFinalTerms EventSetFinalTerms;
    public Localize.DelegateDoLocalize EventDoLocalize;
    public bool CanUseSecondaryTerm;
    public bool AllowMainTermToBeRTL;
    public bool AllowSecondTermToBeRTL;
    public bool IgnoreRTL;
    public int MaxCharactersInRTL;
    public bool CorrectAlignmentForRTL;
    public Object[] TranslatedObjects;
    public EventCallback LocalizeCallBack;
    public static string MainTranslation;
    public static string SecondaryTranslation;
    public static string CallBackTerm;
    public static string CallBackSecondaryTerm;
    public static Localize CurrentLocalizeComponent;
    private UILabel mTarget_UILabel;
    private UISprite mTarget_UISprite;
    private UITexture mTarget_UITexture;
    private NGUIText.Alignment mOriginalAlignmentNGUI;
    private UnityEngine.UI.Text mTarget_uGUI_Text;
    private Image mTarget_uGUI_Image;
    private RawImage mTarget_uGUI_RawImage;
    private TextAnchor mOriginalAlignmentUGUI;
    private GUIText mTarget_GUIText;
    private TextMesh mTarget_TextMesh;
    private AudioSource mTarget_AudioSource;
    private GUITexture mTarget_GUITexture;
    private GameObject mTarget_Child;
    private bool mInitializeAlignment;
    private TextAlignment mOriginalAlignmentStd;

    public Localize()
    {
      this.mTerm = string.Empty;
      this.mTermSecondary = string.Empty;
      this.LocalizeOnAwake = true;
      this.CorrectAlignmentForRTL = true;
      this.LocalizeCallBack = new EventCallback();
      // ISSUE: explicit constructor call
      base.\u002Ector();
    }

    public event System.Action EventFindTarget;

    public string Term
    {
      get => this.mTerm;
      set => this.SetTerm(value);
    }

    public string SecondaryTerm
    {
      get => this.mTermSecondary;
      set => this.SetTerm((string) null, value);
    }

    private void Awake()
    {
      this.RegisterTargets();
      if (this.HasTargetCache())
        this.EventFindTarget();
      if (!this.LocalizeOnAwake)
        return;
      this.OnLocalize();
    }

    private void RegisterTargets()
    {
      if (this.EventFindTarget != null)
        return;
      this.RegisterEvents_NGUI();
      Localize.RegisterEvents_DFGUI();
      this.RegisterEvents_UGUI();
      Localize.RegisterEvents_2DToolKit();
      Localize.RegisterEvents_TextMeshPro();
      this.RegisterEvents_UnityStandard();
      Localize.RegisterEvents_SVG();
    }

    private void OnEnable() => this.OnLocalize();

    public void OnLocalize(bool Force = false)
    {
      if (!Force && (!((Behaviour) this).enabled || Object.op_Equality((Object) ((Component) this).gameObject, (Object) null) || !((Component) this).gameObject.activeInHierarchy) || string.IsNullOrEmpty(LocalizationManager.CurrentLanguage) || !Force && this.LastLocalizedLanguage == LocalizationManager.CurrentLanguage)
        return;
      this.LastLocalizedLanguage = LocalizationManager.CurrentLanguage;
      if (!this.HasTargetCache())
        this.FindTarget();
      if (!this.HasTargetCache())
        return;
      if (string.IsNullOrEmpty(this.FinalTerm) || string.IsNullOrEmpty(this.FinalSecondaryTerm))
        this.GetFinalTerms(out this.FinalTerm, out this.FinalSecondaryTerm);
      if (string.IsNullOrEmpty(this.FinalTerm) && string.IsNullOrEmpty(this.FinalSecondaryTerm))
        return;
      Localize.CallBackTerm = this.FinalTerm;
      Localize.CallBackSecondaryTerm = this.FinalSecondaryTerm;
      Localize.MainTranslation = LocalizationManager.GetTermTranslation(this.FinalTerm);
      Localize.SecondaryTranslation = LocalizationManager.GetTermTranslation(this.FinalSecondaryTerm);
      if (string.IsNullOrEmpty(Localize.MainTranslation) && string.IsNullOrEmpty(Localize.SecondaryTranslation))
        return;
      Localize.CurrentLocalizeComponent = this;
      this.LocalizeCallBack.Execute((Object) this);
      if (LocalizationManager.IsRight2Left && !this.IgnoreRTL)
      {
        if (this.AllowMainTermToBeRTL && !string.IsNullOrEmpty(Localize.MainTranslation))
          Localize.MainTranslation = LocalizationManager.ApplyRTLfix(Localize.MainTranslation, this.MaxCharactersInRTL);
        if (this.AllowSecondTermToBeRTL && !string.IsNullOrEmpty(Localize.SecondaryTranslation))
          Localize.SecondaryTranslation = LocalizationManager.ApplyRTLfix(Localize.SecondaryTranslation);
      }
      switch (this.PrimaryTermModifier)
      {
        case Localize.TermModification.ToUpper:
          Localize.MainTranslation = Localize.MainTranslation.ToUpper();
          break;
        case Localize.TermModification.ToLower:
          Localize.MainTranslation = Localize.MainTranslation.ToLower();
          break;
        case Localize.TermModification.ToUpperFirst:
          Localize.MainTranslation = GoogleTranslation.UppercaseFirst(Localize.MainTranslation);
          break;
        case Localize.TermModification.ToTitle:
          Localize.MainTranslation = GoogleTranslation.TitleCase(Localize.MainTranslation);
          break;
      }
      switch (this.SecondaryTermModifier)
      {
        case Localize.TermModification.ToUpper:
          Localize.SecondaryTranslation = Localize.SecondaryTranslation.ToUpper();
          break;
        case Localize.TermModification.ToLower:
          Localize.SecondaryTranslation = Localize.SecondaryTranslation.ToLower();
          break;
        case Localize.TermModification.ToUpperFirst:
          Localize.SecondaryTranslation = GoogleTranslation.UppercaseFirst(Localize.SecondaryTranslation);
          break;
        case Localize.TermModification.ToTitle:
          Localize.SecondaryTranslation = GoogleTranslation.TitleCase(Localize.SecondaryTranslation);
          break;
      }
      this.EventDoLocalize(Localize.MainTranslation, Localize.SecondaryTranslation);
      Localize.CurrentLocalizeComponent = (Localize) null;
    }

    public bool FindTarget()
    {
      if (this.HasTargetCache())
        return true;
      if (this.EventFindTarget == null)
        this.RegisterTargets();
      this.EventFindTarget();
      return this.HasTargetCache();
    }

    public void FindAndCacheTarget<T>(
      ref T targetCache,
      Localize.DelegateSetFinalTerms setFinalTerms,
      Localize.DelegateDoLocalize doLocalize,
      bool UseSecondaryTerm,
      bool MainRTL,
      bool SecondRTL)
      where T : Component
    {
      if (Object.op_Inequality(this.mTarget, (Object) null))
        targetCache = this.mTarget as T;
      else
        this.mTarget = (Object) (object) (targetCache = ((Component) this).GetComponent<T>());
      if (!Object.op_Inequality((Object) (object) targetCache, (Object) null))
        return;
      this.EventSetFinalTerms = setFinalTerms;
      this.EventDoLocalize = doLocalize;
      this.CanUseSecondaryTerm = UseSecondaryTerm;
      this.AllowMainTermToBeRTL = MainRTL;
      this.AllowSecondTermToBeRTL = SecondRTL;
    }

    private void FindAndCacheTarget(
      ref GameObject targetCache,
      Localize.DelegateSetFinalTerms setFinalTerms,
      Localize.DelegateDoLocalize doLocalize,
      bool UseSecondaryTerm,
      bool MainRTL,
      bool SecondRTL)
    {
      if (Object.op_Inequality(this.mTarget, (Object) targetCache) && Object.op_Implicit((Object) targetCache))
        Object.Destroy((Object) targetCache);
      if (Object.op_Inequality(this.mTarget, (Object) null))
      {
        targetCache = this.mTarget as GameObject;
      }
      else
      {
        Transform transform = ((Component) this).transform;
        this.mTarget = (Object) (targetCache = transform.childCount >= 1 ? ((Component) transform.GetChild(0)).gameObject : (GameObject) null);
      }
      if (!Object.op_Inequality((Object) targetCache, (Object) null))
        return;
      this.EventSetFinalTerms = setFinalTerms;
      this.EventDoLocalize = doLocalize;
      this.CanUseSecondaryTerm = UseSecondaryTerm;
      this.AllowMainTermToBeRTL = MainRTL;
      this.AllowSecondTermToBeRTL = SecondRTL;
    }

    private bool HasTargetCache() => this.EventDoLocalize != null;

    public void GetFinalTerms(out string PrimaryTerm, out string SecondaryTerm)
    {
      if (this.EventSetFinalTerms == null || !Object.op_Implicit(this.mTarget) && !this.HasTargetCache())
        this.FindTarget();
      PrimaryTerm = string.Empty;
      SecondaryTerm = string.Empty;
      if (Object.op_Inequality(this.mTarget, (Object) null) && (string.IsNullOrEmpty(this.mTerm) || string.IsNullOrEmpty(this.mTermSecondary)) && this.EventSetFinalTerms != null)
        this.EventSetFinalTerms(this.mTerm, this.mTermSecondary, out PrimaryTerm, out SecondaryTerm);
      if (!string.IsNullOrEmpty(this.mTerm))
        PrimaryTerm = this.mTerm;
      if (string.IsNullOrEmpty(this.mTermSecondary))
        return;
      SecondaryTerm = this.mTermSecondary;
    }

    public string GetMainTargetsText()
    {
      string primaryTerm = (string) null;
      string secondaryTerm = (string) null;
      if (this.EventSetFinalTerms != null)
        this.EventSetFinalTerms((string) null, (string) null, out primaryTerm, out secondaryTerm);
      return string.IsNullOrEmpty(primaryTerm) ? this.mTerm : primaryTerm;
    }

    private void SetFinalTerms(
      string Main,
      string Secondary,
      out string PrimaryTerm,
      out string SecondaryTerm,
      bool RemoveNonASCII)
    {
      PrimaryTerm = !RemoveNonASCII || string.IsNullOrEmpty(Main) ? Main : Regex.Replace(Main, "[^a-zA-Z0-9_ ]+", " ");
      SecondaryTerm = Secondary;
    }

    public void SetTerm(string primary, string secondary = null)
    {
      if (!string.IsNullOrEmpty(primary))
        this.FinalTerm = this.mTerm = primary;
      if (!string.IsNullOrEmpty(secondary))
        this.FinalSecondaryTerm = this.mTermSecondary = secondary;
      this.OnLocalize(true);
    }

    private T GetSecondaryTranslatedObj<T>(
      ref string MainTranslation,
      ref string SecondaryTranslation)
      where T : Object
    {
      string str;
      string secondary;
      this.DeserializeTranslation(MainTranslation, out str, out secondary);
      T secondaryTranslatedObj = (T) null;
      if (!string.IsNullOrEmpty(secondary))
      {
        secondaryTranslatedObj = this.GetObject<T>(secondary);
        if (Object.op_Inequality((Object) secondaryTranslatedObj, (Object) null))
        {
          MainTranslation = str;
          SecondaryTranslation = secondary;
        }
      }
      if (Object.op_Equality((Object) secondaryTranslatedObj, (Object) null))
        secondaryTranslatedObj = this.GetObject<T>(SecondaryTranslation);
      return secondaryTranslatedObj;
    }

    private T GetObject<T>(string Translation) where T : Object
    {
      if (string.IsNullOrEmpty(Translation))
        return (T) null;
      T translatedObject = this.GetTranslatedObject<T>(Translation);
      if (Object.op_Equality((Object) translatedObject, (Object) null))
      {
        int num = Translation.LastIndexOfAny("/\\".ToCharArray());
        if (num >= 0)
        {
          Translation = Translation.Substring(num + 1);
          translatedObject = this.GetTranslatedObject<T>(Translation);
        }
      }
      return translatedObject;
    }

    private T GetTranslatedObject<T>(string Translation) where T : Object
    {
      return this.FindTranslatedObject<T>(Translation);
    }

    private void DeserializeTranslation(string translation, out string value, out string secondary)
    {
      if (!string.IsNullOrEmpty(translation) && translation.Length > 1 && translation[0] == '[')
      {
        int num = translation.IndexOf(']');
        if (num > 0)
        {
          secondary = translation.Substring(1, num - 1);
          value = translation.Substring(num + 1);
          return;
        }
      }
      value = translation;
      secondary = string.Empty;
    }

    public T FindTranslatedObject<T>(string value) where T : Object
    {
      if (string.IsNullOrEmpty(value))
        return (T) null;
      if (this.TranslatedObjects != null)
      {
        int index = 0;
        for (int length = this.TranslatedObjects.Length; index < length; ++index)
        {
          if (Object.op_Inequality((Object) (this.TranslatedObjects[index] as T), (Object) null) && value == this.TranslatedObjects[index].name)
            return this.TranslatedObjects[index] as T;
        }
      }
      T asset = LocalizationManager.FindAsset(value) as T;
      return Object.op_Implicit((Object) asset) ? asset : ResourceManager.pInstance.GetAsset<T>(value);
    }

    public bool HasTranslatedObject(Object Obj)
    {
      return Array.IndexOf<Object>(this.TranslatedObjects, Obj) >= 0 || ResourceManager.pInstance.HasAsset(Obj);
    }

    public void AddTranslatedObject(Object Obj)
    {
      Array.Resize<Object>(ref this.TranslatedObjects, this.TranslatedObjects.Length + 1);
      this.TranslatedObjects[this.TranslatedObjects.Length - 1] = Obj;
    }

    public void SetGlobalLanguage(string Language)
    {
      LocalizationManager.CurrentLanguage = Language;
    }

    public static void RegisterEvents_2DToolKit()
    {
    }

    public static void RegisterEvents_DFGUI()
    {
    }

    public void RegisterEvents_NGUI()
    {
      this.EventFindTarget += new System.Action(this.FindTarget_UILabel);
      this.EventFindTarget += new System.Action(this.FindTarget_UISprite);
      this.EventFindTarget += new System.Action(this.FindTarget_UITexture);
    }

    private void FindTarget_UILabel()
    {
      this.FindAndCacheTarget<UILabel>(ref this.mTarget_UILabel, new Localize.DelegateSetFinalTerms(this.SetFinalTerms_UIlabel), new Localize.DelegateDoLocalize(this.DoLocalize_UILabel), true, true, false);
    }

    private void FindTarget_UISprite()
    {
      this.FindAndCacheTarget<UISprite>(ref this.mTarget_UISprite, new Localize.DelegateSetFinalTerms(this.SetFinalTerms_UISprite), new Localize.DelegateDoLocalize(this.DoLocalize_UISprite), true, false, false);
    }

    private void FindTarget_UITexture()
    {
      this.FindAndCacheTarget<UITexture>(ref this.mTarget_UITexture, new Localize.DelegateSetFinalTerms(this.SetFinalTerms_UITexture), new Localize.DelegateDoLocalize(this.DoLocalize_UITexture), false, false, false);
    }

    private void SetFinalTerms_UIlabel(
      string Main,
      string Secondary,
      out string primaryTerm,
      out string secondaryTerm)
    {
      this.SetFinalTerms(this.mTarget_UILabel.text, !Object.op_Inequality(this.mTarget_UILabel.ambigiousFont, (Object) null) ? string.Empty : this.mTarget_UILabel.ambigiousFont.name, out primaryTerm, out secondaryTerm, true);
    }

    public void SetFinalTerms_UISprite(
      string Main,
      string Secondary,
      out string primaryTerm,
      out string secondaryTerm)
    {
      this.SetFinalTerms(this.mTarget_UISprite.spriteName, !Object.op_Inequality((Object) this.mTarget_UISprite.atlas, (Object) null) ? string.Empty : ((Object) this.mTarget_UISprite.atlas).name, out primaryTerm, out secondaryTerm, false);
    }

    public void SetFinalTerms_UITexture(
      string Main,
      string Secondary,
      out string primaryTerm,
      out string secondaryTerm)
    {
      this.SetFinalTerms(((Object) this.mTarget_UITexture.mainTexture).name, (string) null, out primaryTerm, out secondaryTerm, false);
    }

    public void DoLocalize_UILabel(string MainTranslation, string SecondaryTranslation)
    {
      Font secondaryTranslatedObj1 = this.GetSecondaryTranslatedObj<Font>(ref MainTranslation, ref SecondaryTranslation);
      if (Object.op_Inequality((Object) secondaryTranslatedObj1, (Object) null))
      {
        if (Object.op_Inequality((Object) secondaryTranslatedObj1, this.mTarget_UILabel.ambigiousFont))
          this.mTarget_UILabel.ambigiousFont = (Object) secondaryTranslatedObj1;
      }
      else
      {
        UIFont secondaryTranslatedObj2 = this.GetSecondaryTranslatedObj<UIFont>(ref MainTranslation, ref SecondaryTranslation);
        if (Object.op_Inequality((Object) secondaryTranslatedObj2, (Object) null) && Object.op_Inequality(this.mTarget_UILabel.ambigiousFont, (Object) secondaryTranslatedObj2))
          this.mTarget_UILabel.ambigiousFont = (Object) secondaryTranslatedObj2;
      }
      if (this.mInitializeAlignment)
      {
        this.mInitializeAlignment = false;
        this.mOriginalAlignmentNGUI = this.mTarget_UILabel.alignment;
      }
      UIInput inParents = NGUITools.FindInParents<UIInput>(((Component) this.mTarget_UILabel).gameObject);
      if (Object.op_Inequality((Object) inParents, (Object) null) && Object.op_Equality((Object) inParents.label, (Object) this.mTarget_UILabel))
      {
        if (string.IsNullOrEmpty(MainTranslation) || !(inParents.defaultText != MainTranslation))
          return;
        if (Localize.CurrentLocalizeComponent.CorrectAlignmentForRTL)
          inParents.label.alignment = !LocalizationManager.IsRight2Left ? this.mOriginalAlignmentNGUI : NGUIText.Alignment.Right;
        inParents.defaultText = MainTranslation;
      }
      else
      {
        if (string.IsNullOrEmpty(MainTranslation) || !(this.mTarget_UILabel.text != MainTranslation))
          return;
        if (Localize.CurrentLocalizeComponent.CorrectAlignmentForRTL)
          this.mTarget_UILabel.alignment = !LocalizationManager.IsRight2Left ? this.mOriginalAlignmentNGUI : NGUIText.Alignment.Right;
        this.mTarget_UILabel.text = MainTranslation;
      }
    }

    public void DoLocalize_UISprite(string MainTranslation, string SecondaryTranslation)
    {
      if (this.mTarget_UISprite.spriteName == MainTranslation)
        return;
      UIAtlas secondaryTranslatedObj = this.GetSecondaryTranslatedObj<UIAtlas>(ref MainTranslation, ref SecondaryTranslation);
      bool flag = false;
      if (Object.op_Inequality((Object) secondaryTranslatedObj, (Object) null) && Object.op_Inequality((Object) this.mTarget_UISprite.atlas, (Object) secondaryTranslatedObj))
      {
        this.mTarget_UISprite.atlas = secondaryTranslatedObj;
        flag = true;
      }
      if (this.mTarget_UISprite.spriteName != MainTranslation && this.mTarget_UISprite.atlas.GetSprite(MainTranslation) != null)
      {
        this.mTarget_UISprite.spriteName = MainTranslation;
        flag = true;
      }
      if (!flag)
        return;
      this.mTarget_UISprite.MakePixelPerfect();
    }

    public void DoLocalize_UITexture(string MainTranslation, string SecondaryTranslation)
    {
      Texture mainTexture = this.mTarget_UITexture.mainTexture;
      if (!Object.op_Inequality((Object) mainTexture, (Object) null) || !(((Object) mainTexture).name != MainTranslation))
        return;
      this.mTarget_UITexture.mainTexture = this.FindTranslatedObject<Texture>(MainTranslation);
    }

    public static void RegisterEvents_SVG()
    {
    }

    public static void RegisterEvents_TextMeshPro()
    {
    }

    public void RegisterEvents_UGUI()
    {
      this.EventFindTarget += new System.Action(this.FindTarget_uGUI_Text);
      this.EventFindTarget += new System.Action(this.FindTarget_uGUI_Image);
      this.EventFindTarget += new System.Action(this.FindTarget_uGUI_RawImage);
    }

    private void FindTarget_uGUI_Text()
    {
      this.FindAndCacheTarget<UnityEngine.UI.Text>(ref this.mTarget_uGUI_Text, new Localize.DelegateSetFinalTerms(this.SetFinalTerms_uGUI_Text), new Localize.DelegateDoLocalize(this.DoLocalize_uGUI_Text), true, true, false);
    }

    private void FindTarget_uGUI_Image()
    {
      this.FindAndCacheTarget<Image>(ref this.mTarget_uGUI_Image, new Localize.DelegateSetFinalTerms(this.SetFinalTerms_uGUI_Image), new Localize.DelegateDoLocalize(this.DoLocalize_uGUI_Image), false, false, false);
    }

    private void FindTarget_uGUI_RawImage()
    {
      this.FindAndCacheTarget<RawImage>(ref this.mTarget_uGUI_RawImage, new Localize.DelegateSetFinalTerms(this.SetFinalTerms_uGUI_RawImage), new Localize.DelegateDoLocalize(this.DoLocalize_uGUI_RawImage), false, false, false);
    }

    private void SetFinalTerms_uGUI_Text(
      string Main,
      string Secondary,
      out string primaryTerm,
      out string secondaryTerm)
    {
      this.SetFinalTerms(this.mTarget_uGUI_Text.text, !Object.op_Inequality((Object) this.mTarget_uGUI_Text.font, (Object) null) ? string.Empty : ((Object) this.mTarget_uGUI_Text.font).name, out primaryTerm, out secondaryTerm, true);
    }

    public void SetFinalTerms_uGUI_Image(
      string Main,
      string Secondary,
      out string primaryTerm,
      out string secondaryTerm)
    {
      this.SetFinalTerms(((Object) this.mTarget_uGUI_Image.mainTexture).name, (string) null, out primaryTerm, out secondaryTerm, false);
    }

    public void SetFinalTerms_uGUI_RawImage(
      string Main,
      string Secondary,
      out string primaryTerm,
      out string secondaryTerm)
    {
      this.SetFinalTerms(((Object) this.mTarget_uGUI_RawImage.texture).name, (string) null, out primaryTerm, out secondaryTerm, false);
    }

    public static T FindInParents<T>(Transform tr) where T : Component
    {
      if (!Object.op_Implicit((Object) tr))
        return (T) null;
      T component;
      for (component = ((Component) tr).GetComponent<T>(); !Object.op_Implicit((Object) (object) component) && Object.op_Implicit((Object) tr); tr = tr.parent)
        component = ((Component) tr).GetComponent<T>();
      return component;
    }

    public void DoLocalize_uGUI_Text(string MainTranslation, string SecondaryTranslation)
    {
      Font secondaryTranslatedObj = this.GetSecondaryTranslatedObj<Font>(ref MainTranslation, ref SecondaryTranslation);
      if (Object.op_Inequality((Object) secondaryTranslatedObj, (Object) null) && Object.op_Inequality((Object) secondaryTranslatedObj, (Object) this.mTarget_uGUI_Text.font))
        this.mTarget_uGUI_Text.font = secondaryTranslatedObj;
      if (this.mInitializeAlignment)
      {
        this.mInitializeAlignment = false;
        this.mOriginalAlignmentUGUI = this.mTarget_uGUI_Text.alignment;
      }
      if (string.IsNullOrEmpty(MainTranslation) || !(this.mTarget_uGUI_Text.text != MainTranslation))
        return;
      if (Localize.CurrentLocalizeComponent.CorrectAlignmentForRTL)
      {
        if (this.mTarget_uGUI_Text.alignment == null || this.mTarget_uGUI_Text.alignment == 1 || this.mTarget_uGUI_Text.alignment == 2)
          this.mTarget_uGUI_Text.alignment = !LocalizationManager.IsRight2Left ? this.mOriginalAlignmentUGUI : (TextAnchor) (object) 2;
        else if (this.mTarget_uGUI_Text.alignment == 3 || this.mTarget_uGUI_Text.alignment == 4 || this.mTarget_uGUI_Text.alignment == 5)
          this.mTarget_uGUI_Text.alignment = !LocalizationManager.IsRight2Left ? this.mOriginalAlignmentUGUI : (TextAnchor) (object) 5;
        else if (this.mTarget_uGUI_Text.alignment == 6 || this.mTarget_uGUI_Text.alignment == 7 || this.mTarget_uGUI_Text.alignment == 8)
          this.mTarget_uGUI_Text.alignment = !LocalizationManager.IsRight2Left ? this.mOriginalAlignmentUGUI : (TextAnchor) (object) 8;
      }
      this.mTarget_uGUI_Text.text = MainTranslation;
      ((Graphic) this.mTarget_uGUI_Text).SetVerticesDirty();
    }

    public void DoLocalize_uGUI_Image(string MainTranslation, string SecondaryTranslation)
    {
      Sprite sprite = this.mTarget_uGUI_Image.sprite;
      if (!Object.op_Equality((Object) sprite, (Object) null) && !(((Object) sprite).name != MainTranslation))
        return;
      this.mTarget_uGUI_Image.sprite = this.FindTranslatedObject<Sprite>(MainTranslation);
    }

    public void DoLocalize_uGUI_RawImage(string MainTranslation, string SecondaryTranslation)
    {
      Texture texture = this.mTarget_uGUI_RawImage.texture;
      if (!Object.op_Equality((Object) texture, (Object) null) && !(((Object) texture).name != MainTranslation))
        return;
      this.mTarget_uGUI_RawImage.texture = this.FindTranslatedObject<Texture>(MainTranslation);
    }

    public void RegisterEvents_UnityStandard()
    {
      this.EventFindTarget += new System.Action(this.FindTarget_GUIText);
      this.EventFindTarget += new System.Action(this.FindTarget_TextMesh);
      this.EventFindTarget += new System.Action(this.FindTarget_AudioSource);
      this.EventFindTarget += new System.Action(this.FindTarget_GUITexture);
      this.EventFindTarget += new System.Action(this.FindTarget_Child);
    }

    private void FindTarget_GUIText()
    {
      this.FindAndCacheTarget<GUIText>(ref this.mTarget_GUIText, new Localize.DelegateSetFinalTerms(this.SetFinalTerms_GUIText), new Localize.DelegateDoLocalize(this.DoLocalize_GUIText), true, true, false);
    }

    private void FindTarget_TextMesh()
    {
      this.FindAndCacheTarget<TextMesh>(ref this.mTarget_TextMesh, new Localize.DelegateSetFinalTerms(this.SetFinalTerms_TextMesh), new Localize.DelegateDoLocalize(this.DoLocalize_TextMesh), true, true, false);
    }

    private void FindTarget_AudioSource()
    {
      this.FindAndCacheTarget<AudioSource>(ref this.mTarget_AudioSource, new Localize.DelegateSetFinalTerms(this.SetFinalTerms_AudioSource), new Localize.DelegateDoLocalize(this.DoLocalize_AudioSource), false, false, false);
    }

    private void FindTarget_GUITexture()
    {
      this.FindAndCacheTarget<GUITexture>(ref this.mTarget_GUITexture, new Localize.DelegateSetFinalTerms(this.SetFinalTerms_GUITexture), new Localize.DelegateDoLocalize(this.DoLocalize_GUITexture), false, false, false);
    }

    private void FindTarget_Child()
    {
      this.FindAndCacheTarget(ref this.mTarget_Child, new Localize.DelegateSetFinalTerms(this.SetFinalTerms_Child), new Localize.DelegateDoLocalize(this.DoLocalize_Child), false, false, false);
    }

    public void SetFinalTerms_GUIText(
      string Main,
      string Secondary,
      out string PrimaryTerm,
      out string SecondaryTerm)
    {
      if (string.IsNullOrEmpty(Secondary) && Object.op_Inequality((Object) this.mTarget_GUIText.font, (Object) null))
        Secondary = ((Object) this.mTarget_GUIText.font).name;
      this.SetFinalTerms(this.mTarget_GUIText.text, Secondary, out PrimaryTerm, out SecondaryTerm, true);
    }

    public void SetFinalTerms_TextMesh(
      string Main,
      string Secondary,
      out string PrimaryTerm,
      out string SecondaryTerm)
    {
      this.SetFinalTerms(this.mTarget_TextMesh.text, !Object.op_Inequality((Object) this.mTarget_TextMesh.font, (Object) null) ? string.Empty : ((Object) this.mTarget_TextMesh.font).name, out PrimaryTerm, out SecondaryTerm, true);
    }

    public void SetFinalTerms_GUITexture(
      string Main,
      string Secondary,
      out string PrimaryTerm,
      out string SecondaryTerm)
    {
      if (!Object.op_Implicit((Object) this.mTarget_GUITexture) || !Object.op_Implicit((Object) this.mTarget_GUITexture.texture))
        this.SetFinalTerms(string.Empty, string.Empty, out PrimaryTerm, out SecondaryTerm, false);
      else
        this.SetFinalTerms(((Object) this.mTarget_GUITexture.texture).name, string.Empty, out PrimaryTerm, out SecondaryTerm, false);
    }

    public void SetFinalTerms_AudioSource(
      string Main,
      string Secondary,
      out string PrimaryTerm,
      out string SecondaryTerm)
    {
      if (!Object.op_Implicit((Object) this.mTarget_AudioSource) || !Object.op_Implicit((Object) this.mTarget_AudioSource.clip))
        this.SetFinalTerms(string.Empty, string.Empty, out PrimaryTerm, out SecondaryTerm, false);
      else
        this.SetFinalTerms(((Object) this.mTarget_AudioSource.clip).name, string.Empty, out PrimaryTerm, out SecondaryTerm, false);
    }

    public void SetFinalTerms_Child(
      string Main,
      string Secondary,
      out string PrimaryTerm,
      out string SecondaryTerm)
    {
      this.SetFinalTerms(((Object) this.mTarget_Child).name, string.Empty, out PrimaryTerm, out SecondaryTerm, false);
    }

    private void DoLocalize_GUIText(string MainTranslation, string SecondaryTranslation)
    {
      Font secondaryTranslatedObj = this.GetSecondaryTranslatedObj<Font>(ref MainTranslation, ref SecondaryTranslation);
      if (Object.op_Inequality((Object) secondaryTranslatedObj, (Object) null) && Object.op_Inequality((Object) this.mTarget_GUIText.font, (Object) secondaryTranslatedObj))
        this.mTarget_GUIText.font = secondaryTranslatedObj;
      if (this.mInitializeAlignment)
      {
        this.mInitializeAlignment = false;
        this.mOriginalAlignmentStd = this.mTarget_GUIText.alignment;
      }
      if (string.IsNullOrEmpty(MainTranslation) || !(this.mTarget_GUIText.text != MainTranslation))
        return;
      if (Localize.CurrentLocalizeComponent.CorrectAlignmentForRTL)
        this.mTarget_GUIText.alignment = !LocalizationManager.IsRight2Left ? this.mOriginalAlignmentStd : (TextAlignment) (object) 2;
      this.mTarget_GUIText.text = MainTranslation;
    }

    private void DoLocalize_TextMesh(string MainTranslation, string SecondaryTranslation)
    {
      Font secondaryTranslatedObj = this.GetSecondaryTranslatedObj<Font>(ref MainTranslation, ref SecondaryTranslation);
      if (Object.op_Inequality((Object) secondaryTranslatedObj, (Object) null) && Object.op_Inequality((Object) this.mTarget_TextMesh.font, (Object) secondaryTranslatedObj))
      {
        this.mTarget_TextMesh.font = secondaryTranslatedObj;
        ((Component) this).GetComponent<Renderer>().sharedMaterial = secondaryTranslatedObj.material;
      }
      if (this.mInitializeAlignment)
      {
        this.mInitializeAlignment = false;
        this.mOriginalAlignmentStd = this.mTarget_TextMesh.alignment;
      }
      if (string.IsNullOrEmpty(MainTranslation) || !(this.mTarget_TextMesh.text != MainTranslation))
        return;
      if (Localize.CurrentLocalizeComponent.CorrectAlignmentForRTL)
        this.mTarget_TextMesh.alignment = !LocalizationManager.IsRight2Left ? this.mOriginalAlignmentStd : (TextAlignment) (object) 2;
      this.mTarget_TextMesh.text = MainTranslation;
    }

    private void DoLocalize_AudioSource(string MainTranslation, string SecondaryTranslation)
    {
      bool isPlaying = this.mTarget_AudioSource.isPlaying;
      AudioClip clip = this.mTarget_AudioSource.clip;
      AudioClip translatedObject = this.FindTranslatedObject<AudioClip>(MainTranslation);
      if (Object.op_Inequality((Object) clip, (Object) translatedObject))
        this.mTarget_AudioSource.clip = translatedObject;
      if (!isPlaying || !Object.op_Implicit((Object) this.mTarget_AudioSource.clip))
        return;
      this.mTarget_AudioSource.Play();
    }

    private void DoLocalize_GUITexture(string MainTranslation, string SecondaryTranslation)
    {
      Texture texture = this.mTarget_GUITexture.texture;
      if (!Object.op_Inequality((Object) texture, (Object) null) || !(((Object) texture).name != MainTranslation))
        return;
      this.mTarget_GUITexture.texture = this.FindTranslatedObject<Texture>(MainTranslation);
    }

    private void DoLocalize_Child(string MainTranslation, string SecondaryTranslation)
    {
      if (Object.op_Implicit((Object) this.mTarget_Child) && ((Object) this.mTarget_Child).name == MainTranslation)
        return;
      GameObject mTargetChild = this.mTarget_Child;
      GameObject translatedObject = this.FindTranslatedObject<GameObject>(MainTranslation);
      if (Object.op_Implicit((Object) translatedObject))
      {
        this.mTarget_Child = Object.Instantiate<GameObject>(translatedObject);
        Transform transform1 = this.mTarget_Child.transform;
        Transform transform2 = !Object.op_Implicit((Object) mTargetChild) ? translatedObject.transform : mTargetChild.transform;
        transform1.parent = ((Component) this).transform;
        transform1.localScale = transform2.localScale;
        transform1.localRotation = transform2.localRotation;
        transform1.localPosition = transform2.localPosition;
      }
      if (!Object.op_Implicit((Object) mTargetChild))
        return;
      Object.Destroy((Object) mTargetChild);
    }

    public enum TermModification
    {
      DontModify,
      ToUpper,
      ToLower,
      ToUpperFirst,
      ToTitle,
    }

    public delegate void DelegateSetFinalTerms(
      string Main,
      string Secondary,
      out string primaryTerm,
      out string secondaryTerm);

    public delegate void DelegateDoLocalize(string primaryTerm, string secondaryTerm);
  }
}
