using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WobblyText : MonoBehaviour
{
    public TMP_Text textComponent;
    private bool wobbling = false;
    private int startIndex = 0;
    private int endIndex = 1;

    void Update()
    {
        if (wobbling)
        {
            textComponent.ForceMeshUpdate();
            var textInfo = textComponent.textInfo;
            for (int i = startIndex; i <= endIndex; i++)
            {
                var charInfo = textInfo.characterInfo[i];

                if (!charInfo.isVisible)
                {
                    continue;
                }

                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

                for (int j = 0; j < 4; j++)
                {
                    var orig = verts[charInfo.vertexIndex + j];
                    verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 5f, 0);
                }
            }

            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                var meshInfo = textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                textComponent.UpdateGeometry(meshInfo.mesh, i);
            }
        }
    }

    public void WobbleText(int startIndex, int endIndex)
    {
        wobbling = true;
        this.startIndex = startIndex;
        this.endIndex = endIndex;
    }

    public void StopWobble()
    {
        wobbling = false;
    }
}
