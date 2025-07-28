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
    public class Coal
    {
        // To access the TechType anywhere in the project
        public static PrefabInfo Info { get; private set; }

        public static void Register()
        {
            Atlas.Sprite icon = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "coal2.png"));

            Info = PrefabInfo.WithTechType("Coal2", "Coal", "Coal, rock composed mainly of Carbon.").WithIcon(icon);
            var coalPrefab = new CustomPrefab(Info);

            var coalObj = new CloneTemplate(Info, TechType.UraniniteCrystal);

            Texture2D coaltexture = ImageUtils.LoadTextureFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "Coal.png"));
            Texture2D illumtexture = ImageUtils.LoadTextureFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "Coal_illum.png"));
            Texture2D spectexture = ImageUtils.LoadTextureFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "Coal_spec.png"));

            var modelData = new CustomModelData
            {
                CustomTexture = coaltexture,
                CustomIllumMap = illumtexture,
                CustomSpecMap = spectexture
            };
 

            coalObj.ModelDatas.Add(modelData);
            coalPrefab.SetGameObject(coalObj);

            coalPrefab.SetSpawns(new BiomeData{ biome = BiomeType.CrashZone_Sand, count = 1, probability = 0.75f });
            
            coalPrefab.SetSpawns(new BiomeData { biome = BiomeType.SafeShallows_SandFlat, count = 1, probability = 0.75f });

            coalPrefab.SetSpawns(new BiomeData { biome = BiomeType.GrassyPlateaus_Sand, count = 1, probability = 0.75f });

            // register the coal to the game
            coalPrefab.Register();
        }
    }
}
