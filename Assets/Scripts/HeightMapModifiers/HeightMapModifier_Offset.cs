using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightMapModifier_Offset : BaseHeightMapModifier
{
    [SerializeField] float OffsetAmount;

    public override void Execute(ProcGenManager.GenerationData generationData, int biomeIndex = -1, BiomeConfigSO biome = null)
    {
        for (int y = 0; y < generationData.MapResolution; ++y)
        {
            for (int x = 0; x < generationData.MapResolution; ++x)
            {
                // skip if we have a biome and this is not our biome
                if (biomeIndex >= 0 && generationData.BiomeMap[x, y] != biomeIndex)
                    continue;
                
                // calculate the new height
                float newHeight = generationData.HeightMap[x, y] + (OffsetAmount / generationData.HeightmapScale.y);

                // blend based on strength
                generationData.HeightMap[x, y] = Mathf.Lerp(generationData.HeightMap[x, y], newHeight, Strength);
            }
        }
    }    
}
