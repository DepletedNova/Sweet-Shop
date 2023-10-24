using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;

namespace KitchenCandy.GDOs.Cotton
{
    public class CottonCandyProcess : CustomProcess
    {
        public override string UniqueNameID => "Cotton Candy Process";
        public override GameDataObject BasicEnablingAppliance => GetCastedGDO<GameDataObject, CottonCandyMachine>();

        public override List<(Locale, ProcessInfo)> InfoList => new()
        {
            (Locale.English, CreateProcessInfo("Candy Floss", "<sprite name=\"cotton_candy_0\">"))
        };
        public override bool CanObfuscateProgress => true;
    }
}
