using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class KeyboardInteraction : MonoBehaviour {
    public Text textObject;
    public List<string> codeSnippets;
    private AudioSource audioSource;
    private int snippetCount = 0;
    private bool isTyping = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();

        if (codeSnippets == null || codeSnippets.Count == 0) {
            codeSnippets = new List<string>
            {
                "int a = 0;", "float b = 3.14f;", "Debug.Log(\"Hello World\");", "void Start() { }",
                "if (x > y) { }", "for (int i = 0; i < 10; i++) { }", "while (true) { }",
                "GameObject.Find(\"Player\");", "Transform.position = new Vector3(0, 0, 0);",
                "Input.GetKeyDown(KeyCode.Space);", "// Comment line", "string name = \"Unity\";",
                "public class Example { }", "private void Update() { }", "AudioSource.Play();",
                "Vector3 direction = Vector3.forward;", "Time.deltaTime;", "Camera.main.transform;",
                "Rigidbody.velocity;", "Renderer.material.color;", "Quaternion.Euler(0, 90, 0);",
                "Physics.Raycast(origin, direction);", "NavMeshAgent.SetDestination(target);",
                "Animation.Play(\"Walk\");", "Debug.DrawLine(start, end);", "Application.Quit();",
                "SceneManager.LoadScene(\"MainScene\");", "Mathf.Clamp(value, min, max);",
                "UIManager.Instance.ShowPanel();", "playerHealth.TakeDamage(10);",
                "Light.intensity = 2.0f;", "AudioClip myClip;", "List<string> myList = new List<string>();",
                "Instantiate(prefab, position, rotation);", "Destroy(gameObject);", "bool isActive = true;",
                "public delegate void MyEvent();", "OnCollisionEnter(Collision collision);",
                "Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);",
                "Shader.SetGlobalColor(\"_Color\", Color.red);", "Text.text = \"Updated!\";",
                "new WaitForSeconds(1f);", "Invoke(\"MyFunction\", 2f);", "SetActive(true);",
                "transform.localScale = Vector3.one;", "ParticleSystem.Play();",
                "Event.current.mousePosition;", "GUILayout.Label(\"Label Text\");",
                "EditorGUILayout.ColorField(Color.white);", "Debug.LogError(\"An error occurred\");",
                "transform.Rotate(Vector3.up * 90);", "Material.SetFloat(\"_Glossiness\", 0.5f);",
                "SceneManager.GetActiveScene().name;", "Resources.Load<GameObject>(\"PrefabName\");",
                "Physics.IgnoreCollision(collider1, collider2);", "gameObject.layer = 8;",
                "Mathf.Lerp(a, b, t);", "Random.Range(0, 100);", "Texture2D.Apply();",
                "CanvasGroup.alpha = 1.0f;", "new Rect(0, 0, 100, 100);", "Cursor.lockState = CursorLockMode.None;",
                "AnimationCurve.Evaluate(0.5f);", "Color.Lerp(Color.red, Color.blue, 0.5f);",
                "UI.Button(\"Click Me\");", "System.DateTime.Now;", "Screen.width;",
                "Physics.gravity = new Vector3(0, -9.8f, 0);", "new Vector2(Random.value, Random.value);",
                "AudioListener.volume = 0.5f;", "playerScore += 10;"
            };
        }
    }

    void OnMouseDown() {
        if (audioSource != null) {
            audioSource.Play();
        }

        if (!isTyping && codeSnippets.Count > 0) {
            string randomSnippet = codeSnippets[Random.Range(0, codeSnippets.Count)];
            StartCoroutine(TypeText(randomSnippet));
        }
    }

    IEnumerator TypeText(string snippet) {
        isTyping = true;

        foreach (char letter in snippet) {
            textObject.text += letter;
            yield return new WaitForSeconds(0.001f);
        }

        textObject.text += "\n";
        snippetCount++;

        if (snippetCount >= 18) {
            textObject.text = "";
            snippetCount = 0;
        }

        isTyping = false;
    }
}
