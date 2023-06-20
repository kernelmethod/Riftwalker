using HarmonyLib;
using XRL.Rules;
using XRL.World;
using XRL.World.Parts.Mutation;

namespace Kernelmethod.Riftwalkers.Patches {
    [HarmonyPatch(typeof(SpacetimeVortex))]
    public class SpacetimeVortexPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(SpacetimeVortex.Vortex))]
        static bool VortexPrefix(Cell C, SpacetimeVortex __instance)
        {
            // Reference: XRL.World.Parts.Mutations/SpacetimeVortex.cs
            if (C != null)
            {
                GameObject gameObject = GameObject.create("Space-Time Vortex");
                XRL.World.Parts.Temporary temporary = gameObject.GetPart("Temporary") as XRL.World.Parts.Temporary;
                temporary.Duration = Stat.Random(15, 18);
                if (__instance.Level > 10)
                {
                    temporary.Duration += __instance.Level - 10;
                }
                C.AddObject(gameObject);
            }

            // Skip the original Vortex() function
            return false;
        }
    }
}