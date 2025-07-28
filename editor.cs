using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using mod1.Items.Natural;
using Nautilus.Crafting;
using Nautilus.Handlers;
using System.Reflection;
using UnityEngine;

namespace mod1
{
    public class editor
    {
        private void Awake()    
        {
            RecipeData solarpanelrecipe = new RecipeData(new CraftData.Ingredient(TechType.Titanium, 7), new CraftData.Ingredient(Silicon.Info.TechType, 3), new CraftData.Ingredient(TechType.Copper, 1));
            CraftDataHandler.SetRecipeData(TechType.SolarPanel, solarpanelrecipe);


        }

    }
}