using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


internal sealed class ImportMapWrapper
{
    private ImportMapDataEditorWindow _window;
    private string _mapFile;
    private Material _terrainMaterial;
    private Material _roadMaterial;
    private Material _buildingMaterial;

    public ImportMapWrapper(ImportMapDataEditorWindow window, string mapFile, 
                                                              Material terrainMaterial,
                                                              Material roadMaterial, 
                                                              Material buildingMaterial)
    {
        _window = window;
        _mapFile = mapFile;
        _terrainMaterial = terrainMaterial;
        _roadMaterial = roadMaterial;
        _buildingMaterial = buildingMaterial;
    }

    public void Import()
    {
        var mapReader = new MapReader();
        mapReader.Read(_mapFile);

        var terrainMaker = new TerrainMaker(mapReader, _terrainMaterial);
        var buildingMaker = new BuildingMaker(mapReader, _buildingMaterial);
        var roadMaker = new RoadMaker(mapReader, _roadMaterial);

        Process(buildingMaker, "Importing buildings");
        Process(roadMaker, "Importing roads");
    }

    private void Process(BaseInfrastructureMaker maker, string progressText)
    {
        float nodeCount = maker.NodeCount;
        var progress = 0f;

        foreach (var node in maker.Process())
        {
            progress = node / nodeCount;
            _window.UpdateProgress(progress, progressText);
        }
        _window.UpdateProgress(0, string.Empty);
    }
}
