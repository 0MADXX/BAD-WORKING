using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material {
 
    public string name;
    public int id;
        
    public Material(string _name, int _id)
        
    { 
        name = _name;  
        id = _id;
    }
}

public class Recipe
{

    public static int MaxMaterials = 6;

    public string name;
    public int id;
    public List<int> MaterialIDs;

    public int[] materialAmounts;

    public Recipe(string _name, int _id, List<int> _MaterialIDs)
    {
        name = _name;
        id = _id;
        MaterialIDs = _MaterialIDs;

        materialAmounts = new int[MaxMaterials];

        for(int i=0; i<MaxMaterials; i++)
        {
            if (_MaterialIDs.Contains(i))
            {
                materialAmounts[i] = 1;
            } else
            {
                materialAmounts[i] = 0;
            }
        }
    }
}



public class TaskManager : MonoBehaviour
{
    public static List<Material> materials = new List<Material>();

    public static List<Recipe> recipes = new List<Recipe>();

  
    private void Start()
    {
        materials.Add(new Material("Orange Cloth", 0)); // ID #0
        materials.Add(new Material("Red Cloth", 1)); // ID #1
        materials.Add(new Material("Blue Cloth", 2)); // ID #2
        materials.Add(new Material("Orange String", 3)); // ID #3
        materials.Add(new Material("Red String", 4)); // ID #4
        materials.Add(new Material("Blue String", 5)); // ID #5

        print("RecipeBook::Start() Number of Materials Created: " + materials.Count);

        Recipe tmp;

        tmp = new Recipe("Orange Shirt", 0, new List<int>() { 0, 3 });

        recipes.Add(tmp);

        recipes.Add(new Recipe("Red Shirt", 1, new List<int>() { 1, 4 }));
        recipes.Add(new Recipe("Blue Shirt", 2, new List<int>() { 2, 5 }));
        recipes.Add(new Recipe("Brown Pants", 3, new List<int>() { 0, 5 }));

        print("RecipeBook::Start(): Number of Recipes Created: " + recipes.Count);
    }

    private void Update()
    {
        
    }


}

