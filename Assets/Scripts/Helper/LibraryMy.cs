using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LibraryMy
{
    public static GameObject ShowObObjectPrefabs(GameObject gameObject_Prefabs, Transform Parent_Object = default(Transform), Vector3 pos_Object = default(Vector3), Vector3 scale_Object = default(Vector3))
    {
        GameObject ob = UnityEngine.Object.Instantiate(gameObject_Prefabs);
        ob.transform.position = new Vector3(pos_Object.x, pos_Object.y, ob.transform.position.z);
        ob.transform.SetParent(Parent_Object);
        ob.transform.localScale = scale_Object.x > 0 ? scale_Object : ob.transform.localScale;
        return ob;
    }

    // YesOrNo_DoTweening == true => Transform_Button != null
    // YesOrNo_DoTweening == false => Transform_Button == null
    public static void OnClickButtonLoadScene(string Name_Scene, bool YesOrNo_DoTweening = default(bool), Transform Transform_Button = default(Transform), UnityAction action = default(UnityAction))
    {
        if (YesOrNo_DoTweening == true && Transform_Button != null)
        {
            Transform_Button.DOScale(1.2f, 0.2f)
            .OnComplete(() =>
            {
                Transform_Button.DOScale(1.0f, 0.2f)
                .OnComplete(() =>
                {
                    if (action == null)
                    {
                        SceneManager.LoadScene(Name_Scene);
                    }
                    else
                    {
                        action?.Invoke();
                    }
                });
            });
        }
        else if (YesOrNo_DoTweening == false && Transform_Button == null)
        {
            if (action == null)
            {
                SceneManager.LoadScene(Name_Scene);
            }
            else
            {
                action?.Invoke();
            }
        }
    }

    // LibraryMy.NormalButton(() => test(điền giá trị index vào), true, btn);
    // public void test(int index)
    // {
    //     print(index);
    // }
    // LibraryMy.NormalButton(() => test()); hoặc LibraryMy.NormalButton(() => test(), true, btn); // LibraryMy.NormalButton(test)
    // public void test()
    // {
    // }
    // YesOrNo_DoTweening == true => Transform_Button != null
    // YesOrNo_DoTweening == false => Transform_Button == null
    public static void NormalButton(UnityAction action, bool YesOrNo_DoTweening = default(bool), Transform Transform_Button = default(Transform))
    {
        if (YesOrNo_DoTweening == true)
        {
            Transform_Button.DOScale(1.2f, 0.2f)
            .OnComplete(() =>
            {
                Transform_Button.DOScale(1.0f, 0.2f)
                .OnComplete(() =>
                {
                    action?.Invoke();
                });
            });
        }
        else if (YesOrNo_DoTweening == false)
        {
            action?.Invoke();
        }
    }

    public static void EffectScaleRepeat(Transform objectToScale, float duration, float maxScale = 1.2f)
    {
        if (objectToScale != null)
        {
            Sequence scaleSequence = DOTween.Sequence();
            scaleSequence.Append(objectToScale.DOScale(maxScale, duration));
            scaleSequence.Append(objectToScale.DOScale(1.0f, duration));
            scaleSequence.OnComplete(() => EffectScaleRepeat(objectToScale, duration, maxScale));
        }
    }

    public static void EffectScaleObjectOn(Transform objectToScale, float duration, float maxScale = 1.0f, UnityAction action = default(UnityAction))
    {
        if (objectToScale != null)
        {
            Sequence scaleSequence = DOTween.Sequence();
            scaleSequence.Append(objectToScale.DOScale(maxScale, duration))
            .OnComplete(() => action?.Invoke());
            objectToScale.localScale = Vector3.zero;
        }
    }

    public static void EffectScaleObjectOff(Transform objectToScale, float duration, float minScale = 0, UnityAction action = default(UnityAction))
    {
        if (objectToScale != null)
        {
            Sequence scaleSequence = DOTween.Sequence();
            scaleSequence.Append(objectToScale.DOScale(minScale, duration))
            .OnComplete(() => action?.Invoke());
            // objectToScale.localScale = Vector3.zero;
        }
    }

    public static void EffectRotateRepeat(Transform objectToRotate, float duration, float rotationAmount = 4f)
    {
        if (objectToRotate != null)
        {
            Sequence rotateSequence = DOTween.Sequence();
            // Xoay về phía dương
            rotateSequence.Append(objectToRotate.DORotate(new Vector3(0, 0, rotationAmount), duration));
            // Xoay về phía âm sau khi hoàn thành
            rotateSequence.Append(objectToRotate.DORotate(new Vector3(0, 0, -rotationAmount), duration))
            .OnComplete(() => EffectRotateRepeat(objectToRotate, duration, rotationAmount));
        }
    }




    /*  Vector3 pos = Vector3.zero;
           if (GameObject.Find("MageParent").transform.childCount < BoxParent.childCount)
           {
               GameObject ob = Instantiate(MagePrefabs[0]);
               for (int i = 0; i < BoxParent.childCount; i++)
               {
                   Box box = BoxParent.GetChild(i).GetComponent<Box>();
                   if (box.isCheckBox == false)
                   {
                       pos = BoxParent.GetChild(i).transform.position;
                   }
               }
               ob.transform.position = new Vector3(pos.x, ob.transform.position.y, pos.z);
               ShowEffect(ob.transform, 1);
               ob.transform.SetParent(GameObject.Find("MageParent").transform);
           } */
}