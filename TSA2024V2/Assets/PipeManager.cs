using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{

    public Material baseMaterial;
    private List<Material> createdMaterials = new List<Material>();

    public bool wheel1;
    public bool wheel2;
    public bool wheel3;
    public bool wheel4;
    public bool wheel5;
   


    // Start is called before the first frame update
    void Start()
    {
        AssignMaterialsToObjects();

    }

    void AssignMaterialsToObjects()
    {
        int index = 1;
        GameObject toAssign = GameObject.Find("Sphere " + index);

        while (toAssign != null)
        {
            Material newMat = new Material(baseMaterial);
<<<<<<< Updated upstream
            newMat.name = "Material" + index; 

            
=======
            newMat.name = "Material" + index; // Naming the material for clarity

            // Assign the new material to the object
>>>>>>> Stashed changes
            Renderer rend = toAssign.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material = newMat;
<<<<<<< Updated upstream
     
                newMat.color = Random.ColorHSV(); 
            }

 
            createdMaterials.Add(newMat);

=======
                // Optionally, customize the new material here (e.g., change color)
                newMat.color = Random.ColorHSV(); // Example: Assign a random color
            }

            // Keep track of the created material
            createdMaterials.Add(newMat);

            // Try to find the next object
>>>>>>> Stashed changes
            index++;
            toAssign = GameObject.Find("Sphere " + index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (wheel1)
        {
            for(int i = 0; i < 8; i++)
            {
                createdMaterials[i].color = Color.green;
                createdMaterials[i].EnableKeyword("_EMISSION");
                createdMaterials[i].SetColor("_EmissionColor", Color.green);

            }

            if (wheel2)
            {
                for (int i = 8; i < 24; i++)
                {
                    createdMaterials[i].color = Color.green;
                    createdMaterials[i].EnableKeyword("_EMISSION");
                    createdMaterials[i].SetColor("_EmissionColor", Color.green);

                }
                for (int i = 4; i < 8; i++)
                {
                    createdMaterials[i].color = Color.red;
                    createdMaterials[i].EnableKeyword("_EMISSION");
                    createdMaterials[i].SetColor("_EmissionColor", Color.red);

                }

                if (wheel3)
                {

                    for (int i = 24; i < 29; i++)
                    {
                        createdMaterials[i].color = Color.green;
                        createdMaterials[i].EnableKeyword("_EMISSION");
                        createdMaterials[i].SetColor("_EmissionColor", Color.green);

                    }
                    for (int i = 31; i < 36; i++)
                    {
                        createdMaterials[i].color = Color.green;
                        createdMaterials[i].EnableKeyword("_EMISSION");
                        createdMaterials[i].SetColor("_EmissionColor", Color.green);

                    }

                    for (int i = 19; i < 24; i++)
                    {
                        createdMaterials[i].color = Color.red;
                        createdMaterials[i].EnableKeyword("_EMISSION");
                        createdMaterials[i].SetColor("_EmissionColor", Color.red);

                    }

                    if (wheel4)
                    {
                        for (int i = 31; i < 36; i++)
                        {
                            createdMaterials[i].color = Color.red;
                            createdMaterials[i].EnableKeyword("_EMISSION");
                            createdMaterials[i].SetColor("_EmissionColor", Color.red);

                        }

                        for (int i = 29; i < 31; i++)
                        {
                            createdMaterials[i].color = Color.green;
                            createdMaterials[i].EnableKeyword("_EMISSION");
                            createdMaterials[i].SetColor("_EmissionColor", Color.green);

                        }
                        for (int i = 36; i < 40; i++)
                        {
                            createdMaterials[i].color = Color.green;
                            createdMaterials[i].EnableKeyword("_EMISSION");
                            createdMaterials[i].SetColor("_EmissionColor", Color.green);

                        }
                        for (int i = 44; i < 46; i++)
                        {
                            createdMaterials[i].color = Color.green;
                            createdMaterials[i].EnableKeyword("_EMISSION");
                            createdMaterials[i].SetColor("_EmissionColor", Color.green);

                        }

                        if (wheel5)
                        {
                            for (int i = 44; i < 46; i++)
                            {
                                createdMaterials[i].color = Color.red;
                                createdMaterials[i].EnableKeyword("_EMISSION");
                                createdMaterials[i].SetColor("_EmissionColor", Color.red);

                            }
                            for (int i = 40; i < 44; i++)
                            {
                                createdMaterials[i].color = Color.green;
                                createdMaterials[i].EnableKeyword("_EMISSION");
                                createdMaterials[i].SetColor("_EmissionColor", Color.green);

                            }

                        }
                        else
                        {
                            for (int i = 44; i < 46; i++)
                            {
                                createdMaterials[i].color = Color.green;
                                createdMaterials[i].EnableKeyword("_EMISSION");
                                createdMaterials[i].SetColor("_EmissionColor", Color.green);

                            }
                            for (int i = 40; i < 44; i++)
                            {
                                createdMaterials[i].color = Color.red;
                                createdMaterials[i].EnableKeyword("_EMISSION");
                                createdMaterials[i].SetColor("_EmissionColor", Color.red);

                            }
                        }

                    }
                    else
                    {
                        for (int i = 31; i < 36; i++)
                        {
                            createdMaterials[i].color = Color.green;
                            createdMaterials[i].EnableKeyword("_EMISSION");
                            createdMaterials[i].SetColor("_EmissionColor", Color.green);

                        }

                        for (int i = 29; i < 31; i++)
                        {
                            createdMaterials[i].color = Color.red;
                            createdMaterials[i].EnableKeyword("_EMISSION");
                            createdMaterials[i].SetColor("_EmissionColor", Color.red);

                        }
                        for (int i = 36; i < 40; i++)
                        {
                            createdMaterials[i].color = Color.red;
                            createdMaterials[i].EnableKeyword("_EMISSION");
                            createdMaterials[i].SetColor("_EmissionColor", Color.red);

                        }
                        for (int i = 44; i < 46; i++)
                        {
                            createdMaterials[i].color = Color.red;
                            createdMaterials[i].EnableKeyword("_EMISSION");
                            createdMaterials[i].SetColor("_EmissionColor", Color.red);

                        }
                    }


                }
                else
                {
                    for (int i = 24; i < 29; i++)
                    {
                        createdMaterials[i].color = Color.red;
                        createdMaterials[i].EnableKeyword("_EMISSION");
                        createdMaterials[i].SetColor("_EmissionColor", Color.red);

                    }
                    for (int i = 19; i < 23; i++)
                    {
                        createdMaterials[i].color = Color.green;
                        createdMaterials[i].EnableKeyword("_EMISSION");
                        createdMaterials[i].SetColor("_EmissionColor", Color.green);

                    }
                    for (int i = 31; i < 36; i++)
                    {
                        createdMaterials[i].color = Color.red;
                        createdMaterials[i].EnableKeyword("_EMISSION");
                        createdMaterials[i].SetColor("_EmissionColor", Color.red);

                    }

                }

            }
            else
            {
                for (int i = 8; i < createdMaterials.Count; i++)
                {
                    createdMaterials[i].color = Color.red;
                    createdMaterials[i].EnableKeyword("_EMISSION");
                    createdMaterials[i].SetColor("_EmissionColor", Color.red);

                }
            }

        }
        else
        {
            for (int i = 0; i < createdMaterials.Count; i++)
            {
                createdMaterials[i].color = Color.red;
                createdMaterials[i].EnableKeyword("_EMISSION");
                createdMaterials[i].SetColor("_EmissionColor", Color.red);

            }
        }
      
    }
}
