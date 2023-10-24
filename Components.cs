using KitchenData;

namespace KitchenCandy
{
    public struct CCottonCandyMachine : IApplianceProperty
    {
        public bool HasCandy;
        public bool HasStick;
        public bool HasCottonCandy;
        public bool Cycling;

        public int InputCandyID;
        public int InputStickID;
        public int OutputID;
        public int ProcessID;
    }
}
