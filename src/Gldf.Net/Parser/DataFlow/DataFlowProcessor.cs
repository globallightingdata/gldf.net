using Gldf.Net.Abstract;
using Gldf.Net.Domain.Typed;
using System.Threading.Tasks.Dataflow;

namespace Gldf.Net.Parser.DataFlow;

internal class DataFlowProcessor : IParserProcessor
{
    public RootTyped Process(ParserDto parserDto)
    {
        // Mapping Elements 1→1 (map input from xml serializer to parser domain)
        var transformFiles = new TransformBlock<ParserDto, ParserDto>(FilesTransform.Map);
        var transformFilesContent = new TransformBlock<ParserDto, ParserDto>(FilesLoadTransform.Map);
        var transformControlGears = new TransformBlock<ParserDto, ParserDto>(ControlGearsTransform.Map);
        var transformSimpleGeo = new TransformBlock<ParserDto, ParserDto>(SimpleGeometryTransform.Map);
        var transformHeader = new TransformBlock<ParserDto, ParserDto>(HeaderTransform.Map);
        var transformGlobalProduct = new TransformBlock<ParserDto, ParserDto>(GlobalProductDataTransform.Map);
        var transformSensors = new TransformBlock<ParserDto, ParserDto>(SensorTransform.Map);
        var transformPhotometry = new TransformBlock<ParserDto, ParserDto>(PhotometryTransform.Map);
        var transformSpectrums = new TransformBlock<ParserDto, ParserDto>(SpectrumTransform.Map);
        var transformModelGeo = new TransformBlock<ParserDto, ParserDto>(ModelGeometryTransform.Map);
        var transformChangeableLightSources = new TransformBlock<ParserDto[], ParserDto>(ChangeableLightSourceTransform.Map);
        var transformFixedLightSources = new TransformBlock<ParserDto[], ParserDto>(FixedLightSourceTransform.Map);
        var transformEquipments = new TransformBlock<ParserDto[], ParserDto>(EquipmentTransform.Map);
        var transformEmitters = new TransformBlock<ParserDto[], ParserDto>(EmitterTransform.Map);
        var transformVariants = new TransformBlock<ParserDto[], ParserDto>(VariantTransform.Map);
        var transformLuminaire = new TransformBlock<ParserDto[], RootTyped>(LuminaireTransform.Map);

        // Broadcasting Elements => 1→n (produce input for multiple descandants)
        var broadcastContainer = new BroadcastBlock<ParserDto>(dto => dto);
        var broadcastFiles = new BroadcastBlock<ParserDto>(dto => dto);
        var broadcastLightSources = new BroadcastBlock<ParserDto[]>(dto => dto);
        var broadcastPhotometries = new BroadcastBlock<ParserDto>(dto => dto);

        // Batching Blocks => n→1 (descandants require [1,2,3,..] elements as input. Not greedy so block wait till input is complete
        var blockOptions = new GroupingDataflowBlockOptions { Greedy = false };
        var lightSourceBatchBlock = new BatchBlock<ParserDto>(3, blockOptions);
        var equipmentBatchBlock = new BatchBlock<ParserDto>(2, blockOptions);
        var emitterBatchBlock = new BatchBlock<ParserDto>(4, blockOptions);
        var variantBatchBlock = new BatchBlock<ParserDto>(3, blockOptions);
        var luminaireBatchBlock = new BatchBlock<ParserDto>(4, blockOptions);

        // Parallel layer 1: Header + Files + ControlGears + SimpleGeometry
        broadcastContainer.LinkTo(transformHeader);
        broadcastContainer.LinkTo(transformFiles);
        broadcastContainer.LinkTo(transformControlGears);
        broadcastContainer.LinkTo(transformSimpleGeo);

        // Parallel layer 2: { Files } => ProductMetaData + Sensors + Photometry + Spectrums + Modelgeo + Filecontent(byte[])
        transformFiles.LinkTo(broadcastFiles);
        broadcastFiles.LinkTo(transformGlobalProduct);
        broadcastFiles.LinkTo(transformSensors);
        broadcastFiles.LinkTo(transformPhotometry);
        broadcastFiles.LinkTo(transformSpectrums);
        broadcastFiles.LinkTo(transformModelGeo);
        broadcastFiles.LinkTo(transformFilesContent);

        // Parallel layer 3: { { Photometry + Files + Spectrums } => LightSources } => ChangeableLS + FixedLS 
        transformPhotometry.LinkTo(broadcastPhotometries);
        broadcastFiles.LinkTo(lightSourceBatchBlock);
        broadcastPhotometries.LinkTo(lightSourceBatchBlock);
        transformSpectrums.LinkTo(lightSourceBatchBlock);
        lightSourceBatchBlock.LinkTo(broadcastLightSources);
        broadcastLightSources.LinkTo(transformChangeableLightSources);
        broadcastLightSources.LinkTo(transformFixedLightSources);

        // Parallel layer 4: { ChangeableLS + ControlGear } => Equipments
        transformChangeableLightSources.LinkTo(equipmentBatchBlock);
        transformControlGears.LinkTo(equipmentBatchBlock);
        equipmentBatchBlock.LinkTo(transformEquipments);

        // Parallel layer 5: { Sensors + Photometry + FixedLS + Equipments } => Emitter
        transformSensors.LinkTo(emitterBatchBlock);
        broadcastPhotometries.LinkTo(emitterBatchBlock);
        transformFixedLightSources.LinkTo(emitterBatchBlock);
        transformEquipments.LinkTo(emitterBatchBlock);
        emitterBatchBlock.LinkTo(transformEmitters);

        // Parallel layer 6: { SimpleGeometry + Emitter + ModelGeometry } => Variant
        transformSimpleGeo.LinkTo(variantBatchBlock);
        transformEmitters.LinkTo(variantBatchBlock);
        transformModelGeo.LinkTo(variantBatchBlock);
        variantBatchBlock.LinkTo(transformVariants);

        // Parallel layer 7: { Header + GlobalProduct + Variant } => Luminaire
        transformHeader.LinkTo(luminaireBatchBlock);
        transformGlobalProduct.LinkTo(luminaireBatchBlock);
        transformVariants.LinkTo(luminaireBatchBlock);
        transformFilesContent.LinkTo(luminaireBatchBlock);

        // Parallel layer 8: Luminaire parts in ParserDto => RootTyped
        luminaireBatchBlock.LinkTo(transformLuminaire);

        broadcastContainer.Post(parserDto);

        broadcastContainer.Complete();

        return transformLuminaire.Receive();
    }
}