using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ParticleButton : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public List<Button> buttons;
    public bool holdToEmit = false;
    public float particleSize = 1.0f;

    private ParticleSystem.MainModule particleMain;

    void Start()
    {
        if (particleSystem == null || buttons == null || buttons.Count == 0)
        {
            Debug.LogError("ParticleSystem or Buttons are not assigned.");
            return;
        }

        particleMain = particleSystem.main;
        particleMain.startSize = particleSize;

        foreach (Button button in buttons)
        {
            if (button != null)
            {
                button.onClick.AddListener(OnButtonClick);
            }
        }
    }

    void Update()
    {
        if (holdToEmit && Input.GetButton("Fire1"))
        {
            EmitParticle();
        }
    }

    void OnButtonClick()
    {
        if (!holdToEmit)
        {
            EmitParticle();
        }
    }

    void EmitParticle()
    {
        particleSystem.Emit(1);
    }
}
