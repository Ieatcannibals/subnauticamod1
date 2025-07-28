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
    internal class Carbon_Monoxide
    {
        public static PrefabInfo Info { get; private set; }

        public static void Register()
        {
            Atlas.Sprite icon = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "carbonmonoxideicon.png"));

            Info = PrefabInfo.WithTechType("Carbon_Monoxide", "Carbon Monoxide", "CO, gas dangerous to inhale.").WithIcon(icon);
            var coalPrefab = new CustomPrefab(Info);

            var coalObj = new CloneTemplate(Info, TechType.HydrochloricAcid);

            coalPrefab.SetGameObject(coalObj);

            var recipe = new RecipeData
            {
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(Carbon_Dioxide.Info.TechType, 1),
                    new Ingredient(Graphite.Info.TechType, 1)
                },
                craftAmount = 2

            };

            coalPrefab.SetRecipe(recipe)
                .WithFabricatorType(CraftTree.Type.Fabricator);

            // register the coal to the game
            coalPrefab.Register();
        }
    }
}
