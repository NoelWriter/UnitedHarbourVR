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
    private Material _industrialBuildingMaterial;
    private Material _residentialBuildingMaterial;
    private Material _waterMaterial;

    public ImportMapWrapper(ImportMapDataEditorWindow window, string mapFile, 
                                                              Material terrainMaterial,
                                                              Material roadMaterial, 
                                                              Material industrialBuildingMaterial,
                                                              Material residentialBuildingMaterial,
                                                              Material waterMaterial)
    {
        _window = window;
        _mapFile = mapFile;
        _terrainMaterial = terrainMaterial;
        _roadMaterial = roadMaterial;
        _industrialBuildingMaterial = industrialBuildingMaterial;
        _residentialBuildingMaterial = residentialBuildingMaterial;
        _waterMaterial = waterMaterial;
    }

    public void Import()
    {
        var mapReader = new MapReader();
        mapReader.Read(_mapFile);

        var terrainMaker = new TerrainMaker(mapReader, _terrainMaterial);
        var roadMaker = new RoadMaker(mapReader, _roadMaterial);
        var buildingMaker = new BuildingMaker(mapReader, _industrialBuildingMaterial, _residentialBuildingMaterial);
        var waterMaker = new WaterMaker(mapReader, _waterMaterial);



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
