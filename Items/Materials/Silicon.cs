using mod1.Items.Natural;
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
    public class Silicon
    {
        // To access the TechType anywhere in the project
        public static PrefabInfo Info { get; private set; }

        public static void Register()
        {
            Atlas.Sprite icon = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "siliconicon.png"));

            Info = PrefabInfo.WithTechType("Silicon2", "Silicon", "Si, element used in many modern applications.").WithIcon(icon);
            var Prefab = new CustomPrefab(Info);

            var Obj = new CloneTemplate(Info, TechType.Nickel);

            Texture2D texture = ImageUtils.LoadTextureFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "Silicon.png"));
            Texture2D normaltexture = ImageUtils.LoadTextureFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "Silicon_normal.png"));
            Texture2D spectexture = ImageUtils.LoadTextureFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "Silicon_spec.png"));

            var modelData = new CustomModelData
            {
                CustomTexture = texture,
                CustomNormalMap = normaltexture,
                CustomSpecMap = spectexture
            };


            Obj.ModelDatas.Add(modelData);
            Prefab.SetGameObject(Obj);

            var recipe = new RecipeData
                { 
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient(Coal.Info.TechType, 4),
                        new Ingredient(TechType.Quartz, 2)
                    },
                    LinkedItems = new List<TechType>
                    {
                        Carbon_Monoxide.Info.TechType,
                        Carbon_Monoxide.Info.TechType
                    }

                };

            Prefab.SetRecipe(recipe)
                .WithFabricatorType(CraftTree.Type.Fabricator);



            // register the coal to the game
            Prefab.Register();
        }
    }
}
