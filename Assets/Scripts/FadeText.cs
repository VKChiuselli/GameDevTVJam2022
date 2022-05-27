using UnityEngine;
using System.Collections;
namespace TMPro.Examples {
    public class FadeText : MonoBehaviour {
        private TMP_Text m_TextComponent;
        public float FadeSpeed = 1.0F;
        public int RolloverCharacterSpread = 10;
        public Color ColorTint;
        void Awake() {
            m_TextComponent = GetComponent<TMP_Text>();
        }
        void Start() {
            StartCoroutine(AnimateVertexColors());
        }
        IEnumerator AnimateVertexColors() {
            m_TextComponent.ForceMeshUpdate();
            TMP_TextInfo textInfo = m_TextComponent.textInfo;
            Color32[] newVertexColors;
            int currentCharacter = 0;
            int startingCharacterRange = currentCharacter;
            bool isRangeMax = false;
            while (!isRangeMax) {
                int characterCount = textInfo.characterCount;
                byte fadeSteps = (byte)Mathf.Max(1, 255 / RolloverCharacterSpread);
                for (int i = startingCharacterRange; i < currentCharacter + 1; i++) {
                    if (!textInfo.characterInfo[i].isVisible) continue;
                    int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
                    newVertexColors = textInfo.meshInfo[materialIndex].colors32;
                    int vertexIndex = textInfo.characterInfo[i].vertexIndex;
                    byte alpha = (byte)Mathf.Clamp(newVertexColors[vertexIndex + 0].a - fadeSteps, 0, 255);
                    newVertexColors[vertexIndex + 0].a = alpha;
                    newVertexColors[vertexIndex + 1].a = alpha;
                    newVertexColors[vertexIndex + 2].a = alpha;
                    newVertexColors[vertexIndex + 3].a = alpha;
                    newVertexColors[vertexIndex + 0] = (Color)newVertexColors[vertexIndex + 0] * ColorTint;
                    newVertexColors[vertexIndex + 1] = (Color)newVertexColors[vertexIndex + 1] * ColorTint;
                    newVertexColors[vertexIndex + 2] = (Color)newVertexColors[vertexIndex + 2] * ColorTint;
                    newVertexColors[vertexIndex + 3] = (Color)newVertexColors[vertexIndex + 3] * ColorTint;
                    if (alpha == 0) {
                        startingCharacterRange += 1;
                        if (startingCharacterRange == characterCount) {
                            m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
                            yield return new WaitForSeconds(1.0f);
                            m_TextComponent.ForceMeshUpdate();
                            yield return new WaitForSeconds(1.0f);
                            currentCharacter = 0;
                            startingCharacterRange = 0;
                        }
                    }
                }
                m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
                if (currentCharacter + 1 < characterCount) currentCharacter += 1;
                yield return new WaitForSeconds(0.25f - FadeSpeed * 0.01f);
            }
        }
    }
}
