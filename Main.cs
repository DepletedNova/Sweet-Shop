global using static KitchenCandy.Main;
global using static KitchenLib.Utils.GDOUtils;
global using static KitchenLib.Utils.LocalisationUtils;
global using static KitchenLib.Utils.KitchenPropertiesUtils;
using KitchenData;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Event;
using KitchenLib.Utils;
using KitchenMods;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;

namespace KitchenCandy
{
    public class Main : BaseMod
    {
        public const string NAME = "Sweet Shop";
        public const string GUID = "nova.candyshop";
        public const string VERSION = "1.0.0";

        public Main() : base(GUID, NAME, "Zoey Davis", VERSION, ">=1.0.0", Assembly.GetExecutingAssembly()) { }

        private static AssetBundle Bundle;

        private void PostActivate()
        {
            CreateMaterials();

            AddIcons();
        }

        private void BuildGameData(GameData gameData)
        {

        }

        private void CreateMaterials()
        {
            #region Candy - Heated
            var heatedcandy = MaterialUtils.CreateFlat("Candy - Heated", 0xFF5E79, overlayScale: 1f);
            heatedcandy.SetTexture("_Overlay", GetAsset<Texture2D>("HeatedCandyTex"));
            heatedcandy.SetColor("_OverlayColour", MaterialUtils.ColorFromHex(0x00E5FF));
            heatedcandy.SetVector("_OverlayTextureScale", new(2, 2, 0, 0));
            heatedcandy.SetVector("_OverlayOffset", new(0.25f, 0.25f, 0, 0));
            heatedcandy.SetInt("_HasTextureOverlay", 1);
            heatedcandy.EnableKeyword("_HASTEXTUREOVERLAY_ON");
            heatedcandy.SetInt("_TextureByUV", 1);
            heatedcandy.EnableKeyword("_TEXTUREBYUV_ON");
            heatedcandy.SetFloat("_OverlayMax", 1f);
            heatedcandy.SetFloat("_OverlayMin", 1f);
            AddMaterial(heatedcandy);
            #endregion

            #region Candy - Colorful
            var candy = MaterialUtils.CreateFlat("Candy - Colorful", 0xF4645D, overlayScale: 1f);
            candy.SetTexture("_Overlay", GetAsset<Texture2D>("CandyTex"));
            candy.SetColor("_OverlayColour", MaterialUtils.ColorFromHex(0x04C5DB));
            candy.SetVector("_OverlayTextureScale", new(1.5f, 1.5f, 0, 0));
            candy.SetVector("_OverlayOffset", new(0.25f, 0.25f, 0, 0));
            candy.SetInt("_HasTextureOverlay", 1);
            candy.EnableKeyword("_HASTEXTUREOVERLAY_ON");
            candy.SetInt("_TextureByUV", 1);
            candy.EnableKeyword("_TEXTUREBYUV_ON");
            candy.SetFloat("_OverlayMax", 1f);
            candy.SetFloat("_OverlayMin", 1f);
            AddMaterial(candy);
            #endregion

            #region Candy - Blue
            AddMaterial(MaterialUtils.CreateFlat("Candy - Blue", 0x72D0D8));
            #endregion

            #region Candy - Pink
            AddMaterial(MaterialUtils.CreateFlat("Candy - Pink", 0xEF92A1));
            #endregion

            #region Candy - Cotton
            var cotton = MaterialUtils.CreateFlat("Candy - Cotton", 0x72D0D8, overlayScale: 1f);
            cotton.SetTexture("_Overlay", GetAsset<Texture2D>("CottonCandyTex"));
            cotton.SetColor("_OverlayColour", MaterialUtils.ColorFromHex(0xEF92A1));
            cotton.SetVector("_OverlayTextureScale", new(10f, 10f, 0, 0));
            cotton.SetVector("_OverlayOffset", new(0.25f, 0.25f, 0, 0));
            cotton.SetInt("_HasTextureOverlay", 1);
            cotton.EnableKeyword("_HASTEXTUREOVERLAY_ON");
            cotton.SetInt("_TextureByUV", 1);
            cotton.EnableKeyword("_TEXTUREBYUV_ON");
            cotton.SetFloat("_OverlayMax", 1f);
            cotton.SetFloat("_OverlayMin", 1f);
            AddMaterial(cotton);
            #endregion
        }

        internal void AddIcons()
        {
            Bundle.LoadAllAssets<Texture2D>();
            Bundle.LoadAllAssets<Sprite>();

            var icons = Bundle.LoadAsset<TMP_SpriteAsset>("Icon Asset");
            icons.material = Object.Instantiate(TMP_Settings.defaultSpriteAsset.material);
            icons.material.mainTexture = Bundle.LoadAsset<Texture2D>("Icon Texture");
            TMP_Settings.defaultSpriteAsset.fallbackSpriteAssets.Add(icons);

            Log("Registered icons");
        }

        #region Registry
        protected override void OnPostActivate(Mod mod)
        {
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();

            PostActivate();

            AddGameData();

            Events.BuildGameDataEvent += (s, args) => BuildGameData(args.gamedata);
        }

        internal void AddGameData()
        {
            MethodInfo AddGDOMethod = typeof(BaseMod).GetMethod(nameof(BaseMod.AddGameDataObject));
            int counter = 0;
            Log("Registering GameDataObjects.");
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsAbstract || typeof(IWontRegister).IsAssignableFrom(type))
                    continue;

                if (!typeof(CustomGameDataObject).IsAssignableFrom(type))
                    continue;

                MethodInfo generic = AddGDOMethod.MakeGenericMethod(type);
                generic.Invoke(this, null);
                counter++;
            }
            Log($"Registered {counter} GameDataObjects.");
        }

        public interface IWontRegister { }
        #endregion

        #region Utility
        public static T GetGDO<T>(int id) where T : GameDataObject => GDOUtils.GetExistingGDO(id) as T;

        public static GameObject GetPrefab(string name) => Bundle.LoadAsset<GameObject>(name);
        public static T GetAsset<T>(string name) where T : Object => Bundle.LoadAsset<T>(name);
        #endregion
    }
}
