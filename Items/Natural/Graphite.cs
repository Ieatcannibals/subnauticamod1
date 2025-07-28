using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static CraftData;
using static LootDistributionData;

namespace mod1.Items.Natural
{
    internal class Graphite
    {
        public static PrefabInfo Info { get; private set; }

        public static void Register()
        {
            Atlas.Sprite icon = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "graphiteicon.png"));

            Info = PrefabInfo.WithTechType("Graphite", "Graphite", "C, a pure form of carbon used in many applications.").WithIcon(icon);
            var Prefab = new CustomPrefab(Info);

            var Obj = new CloneTemplate(Info, TechType.Copper);

            Texture2D texture = ImageUtils.LoadTextureFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "Graphite.png"));
            Texture2D spectexture = ImageUtils.LoadTextureFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "Graphite_spec.png"));

            var modelData = new CustomModelData
            {
                CustomTexture = texture,
                CustomSpecMap = spectexture
            };

            Prefab.SetSpawns(new BiomeData { biome = BiomeType.CrashZone_Sand, count = 1, probability = 0.25f });

            Obj.ModelDatas.Add(modelData);
            Prefab.SetGameObject(Obj);

            var recipe = new RecipeData
            {
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(Carbon_Monoxide.Info.TechType, 2)
                },
                LinkedItems = new List<TechType>
                {
                    Carbon_Dioxide.Info.TechType
                }

            };

            Prefab.SetRecipe(recipe)
                .WithFabricatorType(CraftTree.Type.Fabricator);

            // register the coal to the game
            Prefab.Register();
        }
    }
}
