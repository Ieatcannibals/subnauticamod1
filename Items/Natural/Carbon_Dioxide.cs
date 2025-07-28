using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static LootDistributionData;

namespace mod1.Items.Natural
{
    internal class Carbon_Dioxide
    {
        public static PrefabInfo Info { get; private set; }

        public static void Register()
        {
            Atlas.Sprite icon = ImageUtils.LoadSpriteFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "carbondioxideicon.png"));

            Info = PrefabInfo.WithTechType("Carbon_Dioxide", "Carbon Dioxide", "CO_2, found in the atmosphere.").WithIcon(icon);
            var coalPrefab = new CustomPrefab(Info);

            var coalObj = new CloneTemplate(Info, TechType.HydrochloricAcid);

            coalPrefab.SetGameObject(coalObj);

            // register the coal to the game
            coalPrefab.Register();
        }
    }
}
