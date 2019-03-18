using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorGradingLerp : PostProcessEffectSettingsLerp<ColorGrading>
{
    public GradingMode fromGradingMode;
    public GradingMode toGradingMode;
    public Texture fromExternalLut;
    public Texture toExternalLut;
    public Tonemapper fromTonemapper;
    public Tonemapper toTonemapper;
    public Vector2 toneCurveToeStrength;
    public Vector2 toneCurveToeLength;
    public Vector2 toneCurveShoulderStrength;
    public Vector2 toneCurveShoulderLength;
    public Vector2 toneCurveShoulderAngle;
    public Vector2 toneCurveGamma;
    public Texture fromLdrLut;
    public Texture toLdrLut;
    public Vector2 ldrLutContribution;
    public Vector2 temperature;
    public Vector2 tint;
    public Color fromColorFilter;
    public Color toColorFilter;
    public Vector2 hueShift;
    public Vector2 saturation;
    public Vector2 brightness;
    public Vector2 postExposure;
    public Vector2 contrast;
    public Vector2 mixerRedOutRedIn;
    public Vector2 mixerRedOutGreenIn;
    public Vector2 mixerRedOutBlueIn;
    public Vector2 mixerGreenOutRedIn;
    public Vector2 mixerGreenOutGreenIn;
    public Vector2 mixerGreenOutBlueIn;
    public Vector2 mixerBlueOutRedIn;
    public Vector2 mixerBlueOutGreenIn;
    public Vector2 mixerBlueOutBlueIn;
    public Vector4 fromLift;
    public Vector4 toLift;
    public Vector4 fromGamma;
    public Vector4 toGamma;
    public Vector4 fromGain;
    public Vector4 toGain;
    public Spline fromMasterCurve;
    public Spline toMasterCurve;
    public Spline fromRedCurve;
    public Spline toRedCurve;
    public Spline fromGreenCurve;
    public Spline toGreenCurve;
    public Spline fromBlueCurve;
    public Spline toBlueCurve;
    public Spline fromHueVsHueCurve;
    public Spline toHueVsHueCurve;
    public Spline fromHueVsSatCurve;
    public Spline toHueVsSatCurve;
    public Spline fromSatVsSatCurve;
    public Spline toSatVsSatCurve;
    public Spline fromLumVsSatCurve;
    public Spline toLumVsSatCurve;

    public ColorGradingLerp(PostProcessProfile from, PostProcessProfile to, PostProcessProfile temp) : base(from, to, temp)
    {
    }

    public override void InitializeParameters()
    {
        //gradingMode
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.gradingMode.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.gradingMode.overrideState))
        {
            m_tempSettings.gradingMode.overrideState = true;
        }
        else
        {
            m_tempSettings.gradingMode.overrideState = false;
        }
        fromGradingMode = m_fromSettings != null && m_fromSettings.active && m_fromSettings.gradingMode.overrideState ? m_fromSettings.gradingMode.value : m_tempSettings.gradingMode.value;
        toGradingMode = m_toSettings != null && m_toSettings.active && m_toSettings.gradingMode.overrideState ? m_toSettings.gradingMode.value : m_tempSettings.gradingMode.value;

        //externalLut
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.externalLut.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.externalLut.overrideState))
        {
            m_tempSettings.externalLut.overrideState = true;
        }
        else
        {
            m_tempSettings.externalLut.overrideState = false;
        }
        fromExternalLut = m_fromSettings != null && m_fromSettings.active && m_fromSettings.externalLut.overrideState ? m_fromSettings.externalLut.value : m_tempSettings.externalLut.value;
        toExternalLut = m_toSettings != null && m_toSettings.active && m_toSettings.externalLut.overrideState ? m_toSettings.externalLut.value : m_tempSettings.externalLut.value;

        //tonemapper
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.tonemapper.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.tonemapper.overrideState))
        {
            m_tempSettings.tonemapper.overrideState = true;
        }
        else
        {
            m_tempSettings.tonemapper.overrideState = false;
        }
        fromTonemapper = m_fromSettings != null && m_fromSettings.active && m_fromSettings.tonemapper.overrideState ? m_fromSettings.tonemapper.value : m_tempSettings.tonemapper.value;
        toTonemapper = m_toSettings != null && m_toSettings.active && m_toSettings.tonemapper.overrideState ? m_toSettings.tonemapper.value : m_tempSettings.tonemapper.value;

        //toneCurveToeStrength
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.toneCurveToeStrength.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.toneCurveToeStrength.overrideState))
        {
            m_tempSettings.toneCurveToeStrength.overrideState = true;
        }
        else
        {
            m_tempSettings.toneCurveToeStrength.overrideState = false;
        }
        toneCurveToeStrength.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.toneCurveToeStrength.overrideState ? m_fromSettings.toneCurveToeStrength.value : m_tempSettings.toneCurveToeStrength.value;
        toneCurveToeStrength.y = m_toSettings != null && m_toSettings.active && m_toSettings.toneCurveToeStrength.overrideState ? m_toSettings.toneCurveToeStrength.value : m_tempSettings.toneCurveToeStrength.value;

        //toneCurveToeLength
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.toneCurveToeLength.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.toneCurveToeLength.overrideState))
        {
            m_tempSettings.toneCurveToeLength.overrideState = true;
        }
        else
        {
            m_tempSettings.toneCurveToeLength.overrideState = false;
        }
        toneCurveToeLength.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.toneCurveToeLength.overrideState ? m_fromSettings.toneCurveToeLength.value : m_tempSettings.toneCurveToeLength.value;
        toneCurveToeLength.y = m_toSettings != null && m_toSettings.active && m_toSettings.toneCurveToeLength.overrideState ? m_toSettings.toneCurveToeLength.value : m_tempSettings.toneCurveToeLength.value;

        //toneCurveShoulderStrength
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.toneCurveShoulderStrength.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.toneCurveShoulderStrength.overrideState))
        {
            m_tempSettings.toneCurveShoulderStrength.overrideState = true;
        }
        else
        {
            m_tempSettings.toneCurveShoulderStrength.overrideState = false;
        }
        toneCurveShoulderStrength.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.toneCurveShoulderStrength.overrideState ? m_fromSettings.toneCurveShoulderStrength.value : m_tempSettings.toneCurveShoulderStrength.value;
        toneCurveShoulderStrength.y = m_toSettings != null && m_toSettings.active && m_toSettings.toneCurveShoulderStrength.overrideState ? m_toSettings.toneCurveShoulderStrength.value : m_tempSettings.toneCurveShoulderStrength.value;

        //toneCurveShoulderLength
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.toneCurveShoulderLength.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.toneCurveShoulderLength.overrideState))
        {
            m_tempSettings.toneCurveShoulderLength.overrideState = true;
        }
        else
        {
            m_tempSettings.toneCurveShoulderLength.overrideState = false;
        }
        toneCurveShoulderLength.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.toneCurveShoulderLength.overrideState ? m_fromSettings.toneCurveShoulderLength.value : m_tempSettings.toneCurveShoulderLength.value;
        toneCurveShoulderLength.y = m_toSettings != null && m_toSettings.active && m_toSettings.toneCurveShoulderLength.overrideState ? m_toSettings.toneCurveShoulderLength.value : m_tempSettings.toneCurveShoulderLength.value;

        //toneCurveShoulderAngle
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.toneCurveShoulderAngle.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.toneCurveShoulderAngle.overrideState))
        {
            m_tempSettings.toneCurveShoulderAngle.overrideState = true;
        }
        else
        {
            m_tempSettings.toneCurveShoulderAngle.overrideState = false;
        }
        toneCurveShoulderAngle.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.toneCurveShoulderAngle.overrideState ? m_fromSettings.toneCurveShoulderAngle.value : m_tempSettings.toneCurveShoulderAngle.value;
        toneCurveShoulderAngle.y = m_toSettings != null && m_toSettings.active && m_toSettings.toneCurveShoulderAngle.overrideState ? m_toSettings.toneCurveShoulderAngle.value : m_tempSettings.toneCurveShoulderAngle.value;

        //toneCurveGamma
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.toneCurveGamma.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.toneCurveGamma.overrideState))
        {
            m_tempSettings.toneCurveGamma.overrideState = true;
        }
        else
        {
            m_tempSettings.toneCurveGamma.overrideState = false;
        }
        toneCurveGamma.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.toneCurveGamma.overrideState ? m_fromSettings.toneCurveGamma.value : m_tempSettings.toneCurveGamma.value;
        toneCurveGamma.y = m_toSettings != null && m_toSettings.active && m_toSettings.toneCurveGamma.overrideState ? m_toSettings.toneCurveGamma.value : m_tempSettings.toneCurveGamma.value;

        //ldrLut
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.ldrLut.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.ldrLut.overrideState))
        {
            m_tempSettings.ldrLut.overrideState = true;
        }
        else
        {
            m_tempSettings.ldrLut.overrideState = false;
        }
        fromLdrLut = m_fromSettings != null && m_fromSettings.active && m_fromSettings.ldrLut.overrideState ? m_fromSettings.ldrLut.value : m_tempSettings.ldrLut.value;
        toLdrLut = m_toSettings != null && m_toSettings.active && m_toSettings.ldrLut.overrideState ? m_toSettings.ldrLut.value : m_tempSettings.ldrLut.value;

        //ldrLutContribution
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.ldrLutContribution.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.ldrLutContribution.overrideState))
        {
            m_tempSettings.ldrLutContribution.overrideState = true;
        }
        else
        {
            m_tempSettings.ldrLutContribution.overrideState = false;
        }
        ldrLutContribution.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.ldrLutContribution.overrideState ? m_fromSettings.ldrLutContribution.value : m_tempSettings.ldrLutContribution.value;
        ldrLutContribution.y = m_toSettings != null && m_toSettings.active && m_toSettings.ldrLutContribution.overrideState ? m_toSettings.ldrLutContribution.value : m_tempSettings.ldrLutContribution.value;

        //temperature
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.temperature.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.temperature.overrideState))
        {
            m_tempSettings.temperature.overrideState = true;
        }
        else
        {
            m_tempSettings.temperature.overrideState = false;
        }
        temperature.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.temperature.overrideState ? m_fromSettings.temperature.value : m_tempSettings.temperature.value;
        temperature.y = m_toSettings != null && m_toSettings.active && m_toSettings.temperature.overrideState ? m_toSettings.temperature.value : m_tempSettings.temperature.value;

        //tint
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.tint.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.tint.overrideState))
        {
            m_tempSettings.tint.overrideState = true;
        }
        else
        {
            m_tempSettings.tint.overrideState = false;
        }
        tint.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.tint.overrideState ? m_fromSettings.tint.value : m_tempSettings.tint.value;
        tint.y = m_toSettings != null && m_toSettings.active && m_toSettings.tint.overrideState ? m_toSettings.tint.value : m_tempSettings.tint.value;

        //colorFilter
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.colorFilter.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.colorFilter.overrideState))
        {
            m_tempSettings.colorFilter.overrideState = true;
        }
        else
        {
            m_tempSettings.colorFilter.overrideState = false;
        }
        fromColorFilter = m_fromSettings != null && m_fromSettings.active && m_fromSettings.colorFilter.overrideState ? m_fromSettings.colorFilter.value : m_tempSettings.colorFilter.value;
        toColorFilter = m_toSettings != null && m_toSettings.active && m_toSettings.colorFilter.overrideState ? m_toSettings.colorFilter.value : m_tempSettings.colorFilter.value;

        //hueShift
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.hueShift.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.hueShift.overrideState))
        {
            m_tempSettings.hueShift.overrideState = true;
        }
        else
        {
            m_tempSettings.hueShift.overrideState = false;
        }
        hueShift.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.hueShift.overrideState ? m_fromSettings.hueShift.value : m_tempSettings.hueShift.value;
        hueShift.y = m_toSettings != null && m_toSettings.active && m_toSettings.hueShift.overrideState ? m_toSettings.hueShift.value : m_tempSettings.hueShift.value;

        //saturation
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.saturation.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.saturation.overrideState))
        {
            m_tempSettings.saturation.overrideState = true;
        }
        else
        {
            m_tempSettings.saturation.overrideState = false;
        }
        saturation.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.saturation.overrideState ? m_fromSettings.saturation.value : m_tempSettings.saturation.value;
        saturation.y = m_toSettings != null && m_toSettings.active && m_toSettings.saturation.overrideState ? m_toSettings.saturation.value : m_tempSettings.saturation.value;

        //brightness
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.brightness.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.brightness.overrideState))
        {
            m_tempSettings.brightness.overrideState = true;
        }
        else
        {
            m_tempSettings.brightness.overrideState = false;
        }
        brightness.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.brightness.overrideState ? m_fromSettings.brightness.value : m_tempSettings.brightness.value;
        brightness.y = m_toSettings != null && m_toSettings.active && m_toSettings.brightness.overrideState ? m_toSettings.brightness.value : m_tempSettings.brightness.value;

        //postExposure
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.postExposure.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.postExposure.overrideState))
        {
            m_tempSettings.postExposure.overrideState = true;
        }
        else
        {
            m_tempSettings.postExposure.overrideState = false;
        }
        postExposure.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.postExposure.overrideState ? m_fromSettings.postExposure.value : m_tempSettings.postExposure.value;
        postExposure.y = m_toSettings != null && m_toSettings.active && m_toSettings.postExposure.overrideState ? m_toSettings.postExposure.value : m_tempSettings.postExposure.value;

        //contrast
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.contrast.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.contrast.overrideState))
        {
            m_tempSettings.contrast.overrideState = true;
        }
        else
        {
            m_tempSettings.contrast.overrideState = false;
        }
        contrast.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.contrast.overrideState ? m_fromSettings.contrast.value : m_tempSettings.contrast.value;
        contrast.y = m_toSettings != null && m_toSettings.active && m_toSettings.contrast.overrideState ? m_toSettings.contrast.value : m_tempSettings.contrast.value;

        //mixerRedOutRedIn
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerRedOutRedIn.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.mixerRedOutRedIn.overrideState))
        {
            m_tempSettings.mixerRedOutRedIn.overrideState = true;
        }
        else
        {
            m_tempSettings.mixerRedOutRedIn.overrideState = false;
        }
        mixerRedOutRedIn.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerRedOutRedIn.overrideState ? m_fromSettings.mixerRedOutRedIn.value : m_tempSettings.mixerRedOutRedIn.value;
        mixerRedOutRedIn.y = m_toSettings != null && m_toSettings.active && m_toSettings.mixerRedOutRedIn.overrideState ? m_toSettings.mixerRedOutRedIn.value : m_tempSettings.mixerRedOutRedIn.value;

        //mixerRedOutGreenIn
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerRedOutGreenIn.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.mixerRedOutGreenIn.overrideState))
        {
            m_tempSettings.mixerRedOutGreenIn.overrideState = true;
        }
        else
        {
            m_tempSettings.mixerRedOutGreenIn.overrideState = false;
        }
        mixerRedOutGreenIn.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerRedOutGreenIn.overrideState ? m_fromSettings.mixerRedOutGreenIn.value : m_tempSettings.mixerRedOutGreenIn.value;
        mixerRedOutGreenIn.y = m_toSettings != null && m_toSettings.active && m_toSettings.mixerRedOutGreenIn.overrideState ? m_toSettings.mixerRedOutGreenIn.value : m_tempSettings.mixerRedOutGreenIn.value;

        //mixerRedOutBlueIn
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerRedOutBlueIn.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.mixerRedOutBlueIn.overrideState))
        {
            m_tempSettings.mixerRedOutBlueIn.overrideState = true;
        }
        else
        {
            m_tempSettings.mixerRedOutBlueIn.overrideState = false;
        }
        mixerRedOutBlueIn.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerRedOutBlueIn.overrideState ? m_fromSettings.mixerRedOutBlueIn.value : m_tempSettings.mixerRedOutBlueIn.value;
        mixerRedOutBlueIn.y = m_toSettings != null && m_toSettings.active && m_toSettings.mixerRedOutBlueIn.overrideState ? m_toSettings.mixerRedOutBlueIn.value : m_tempSettings.mixerRedOutBlueIn.value;

        //mixerGreenOutRedIn
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerGreenOutRedIn.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.mixerGreenOutRedIn.overrideState))
        {
            m_tempSettings.mixerGreenOutRedIn.overrideState = true;
        }
        else
        {
            m_tempSettings.mixerGreenOutRedIn.overrideState = false;
        }
        mixerGreenOutRedIn.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerGreenOutRedIn.overrideState ? m_fromSettings.mixerGreenOutRedIn.value : m_tempSettings.mixerGreenOutRedIn.value;
        mixerGreenOutRedIn.y = m_toSettings != null && m_toSettings.active && m_toSettings.mixerGreenOutRedIn.overrideState ? m_toSettings.mixerGreenOutRedIn.value : m_tempSettings.mixerGreenOutRedIn.value;

        //mixerGreenOutGreenIn
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerGreenOutGreenIn.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.mixerGreenOutGreenIn.overrideState))
        {
            m_tempSettings.mixerGreenOutGreenIn.overrideState = true;
        }
        else
        {
            m_tempSettings.mixerGreenOutGreenIn.overrideState = false;
        }
        mixerGreenOutGreenIn.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerGreenOutGreenIn.overrideState ? m_fromSettings.mixerGreenOutGreenIn.value : m_tempSettings.mixerGreenOutGreenIn.value;
        mixerGreenOutGreenIn.y = m_toSettings != null && m_toSettings.active && m_toSettings.mixerGreenOutGreenIn.overrideState ? m_toSettings.mixerGreenOutGreenIn.value : m_tempSettings.mixerGreenOutGreenIn.value;

        //mixerGreenOutBlueIn
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerGreenOutBlueIn.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.mixerGreenOutBlueIn.overrideState))
        {
            m_tempSettings.mixerGreenOutBlueIn.overrideState = true;
        }
        else
        {
            m_tempSettings.mixerGreenOutBlueIn.overrideState = false;
        }
        mixerGreenOutBlueIn.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerGreenOutBlueIn.overrideState ? m_fromSettings.mixerGreenOutBlueIn.value : m_tempSettings.mixerGreenOutBlueIn.value;
        mixerGreenOutBlueIn.y = m_toSettings != null && m_toSettings.active && m_toSettings.mixerGreenOutBlueIn.overrideState ? m_toSettings.mixerGreenOutBlueIn.value : m_tempSettings.mixerGreenOutBlueIn.value;

        //mixerBlueOutRedIn
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerBlueOutRedIn.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.mixerBlueOutRedIn.overrideState))
        {
            m_tempSettings.mixerBlueOutRedIn.overrideState = true;
        }
        else
        {
            m_tempSettings.mixerBlueOutRedIn.overrideState = false;
        }
        mixerBlueOutRedIn.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerBlueOutRedIn.overrideState ? m_fromSettings.mixerBlueOutRedIn.value : m_tempSettings.mixerBlueOutRedIn.value;
        mixerBlueOutRedIn.y = m_toSettings != null && m_toSettings.active && m_toSettings.mixerBlueOutRedIn.overrideState ? m_toSettings.mixerBlueOutRedIn.value : m_tempSettings.mixerBlueOutRedIn.value;

        //mixerBlueOutGreenIn
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerBlueOutGreenIn.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.mixerBlueOutGreenIn.overrideState))
        {
            m_tempSettings.mixerBlueOutGreenIn.overrideState = true;
        }
        else
        {
            m_tempSettings.mixerBlueOutGreenIn.overrideState = false;
        }
        mixerBlueOutGreenIn.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerBlueOutGreenIn.overrideState ? m_fromSettings.mixerBlueOutGreenIn.value : m_tempSettings.mixerBlueOutGreenIn.value;
        mixerBlueOutGreenIn.y = m_toSettings != null && m_toSettings.active && m_toSettings.mixerBlueOutGreenIn.overrideState ? m_toSettings.mixerBlueOutGreenIn.value : m_tempSettings.mixerBlueOutGreenIn.value;

        //mixerBlueOutBlueIn
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerBlueOutBlueIn.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.mixerBlueOutBlueIn.overrideState))
        {
            m_tempSettings.mixerBlueOutBlueIn.overrideState = true;
        }
        else
        {
            m_tempSettings.mixerBlueOutBlueIn.overrideState = false;
        }
        mixerBlueOutBlueIn.x = m_fromSettings != null && m_fromSettings.active && m_fromSettings.mixerBlueOutBlueIn.overrideState ? m_fromSettings.mixerBlueOutBlueIn.value : m_tempSettings.mixerBlueOutBlueIn.value;
        mixerBlueOutBlueIn.y = m_toSettings != null && m_toSettings.active && m_toSettings.mixerBlueOutBlueIn.overrideState ? m_toSettings.mixerBlueOutBlueIn.value : m_tempSettings.mixerBlueOutBlueIn.value;

        //lift
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.lift.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.lift.overrideState))
        {
            m_tempSettings.lift.overrideState = true;
        }
        else
        {
            m_tempSettings.lift.overrideState = false;
        }
        fromLift = m_fromSettings != null && m_fromSettings.active && m_fromSettings.lift.overrideState ? m_fromSettings.lift.value : m_tempSettings.lift.value;
        toLift = m_toSettings != null && m_toSettings.active && m_toSettings.lift.overrideState ? m_toSettings.lift.value : m_tempSettings.lift.value;

        //gamma
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.gamma.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.gamma.overrideState))
        {
            m_tempSettings.gamma.overrideState = true;
        }
        else
        {
            m_tempSettings.gamma.overrideState = false;
        }
        fromGamma = m_fromSettings != null && m_fromSettings.active && m_fromSettings.gamma.overrideState ? m_fromSettings.gamma.value : m_tempSettings.gamma.value;
        toGamma = m_toSettings != null && m_toSettings.active && m_toSettings.gamma.overrideState ? m_toSettings.gamma.value : m_tempSettings.gamma.value;

        //gain
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.gain.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.gain.overrideState))
        {
            m_tempSettings.gain.overrideState = true;
        }
        else
        {
            m_tempSettings.gain.overrideState = false;
        }
        fromGain = m_fromSettings != null && m_fromSettings.active && m_fromSettings.gain.overrideState ? m_fromSettings.gain.value : m_tempSettings.gain.value;
        toGain = m_toSettings != null && m_toSettings.active && m_toSettings.gain.overrideState ? m_toSettings.gain.value : m_tempSettings.gain.value;

        //masterCurve
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.masterCurve.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.masterCurve.overrideState))
        {
            m_tempSettings.masterCurve.overrideState = true;
        }
        else
        {
            m_tempSettings.masterCurve.overrideState = false;
        }
        fromMasterCurve = m_fromSettings != null && m_fromSettings.active && m_fromSettings.masterCurve.overrideState ? m_fromSettings.masterCurve.value : m_tempSettings.masterCurve.value;
        toMasterCurve = m_toSettings != null && m_toSettings.active && m_toSettings.masterCurve.overrideState ? m_toSettings.masterCurve.value : m_tempSettings.masterCurve.value;

        //redCurve
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.redCurve.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.redCurve.overrideState))
        {
            m_tempSettings.redCurve.overrideState = true;
        }
        else
        {
            m_tempSettings.redCurve.overrideState = false;
        }
        fromRedCurve = m_fromSettings != null && m_fromSettings.active && m_fromSettings.redCurve.overrideState ? m_fromSettings.redCurve.value : m_tempSettings.redCurve.value;
        toRedCurve = m_toSettings != null && m_toSettings.active && m_toSettings.redCurve.overrideState ? m_toSettings.redCurve.value : m_tempSettings.redCurve.value;

        //greenCurve
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.greenCurve.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.greenCurve.overrideState))
        {
            m_tempSettings.greenCurve.overrideState = true;
        }
        else
        {
            m_tempSettings.greenCurve.overrideState = false;
        }
        fromGreenCurve = m_fromSettings != null && m_fromSettings.active && m_fromSettings.greenCurve.overrideState ? m_fromSettings.greenCurve.value : m_tempSettings.greenCurve.value;
        toGreenCurve = m_toSettings != null && m_toSettings.active && m_toSettings.greenCurve.overrideState ? m_toSettings.greenCurve.value : m_tempSettings.greenCurve.value;

        //blueCurve
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.blueCurve.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.blueCurve.overrideState))
        {
            m_tempSettings.blueCurve.overrideState = true;
        }
        else
        {
            m_tempSettings.blueCurve.overrideState = false;
        }
        fromBlueCurve = m_fromSettings != null && m_fromSettings.active && m_fromSettings.blueCurve.overrideState ? m_fromSettings.blueCurve.value : m_tempSettings.blueCurve.value;
        toBlueCurve = m_toSettings != null && m_toSettings.active && m_toSettings.blueCurve.overrideState ? m_toSettings.blueCurve.value : m_tempSettings.blueCurve.value;

        //hueVsHueCurve
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.hueVsHueCurve.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.hueVsHueCurve.overrideState))
        {
            m_tempSettings.hueVsHueCurve.overrideState = true;
        }
        else
        {
            m_tempSettings.hueVsHueCurve.overrideState = false;
        }
        fromHueVsHueCurve = m_fromSettings != null && m_fromSettings.active && m_fromSettings.hueVsHueCurve.overrideState ? m_fromSettings.hueVsHueCurve.value : m_tempSettings.hueVsHueCurve.value;
        toHueVsHueCurve = m_toSettings != null && m_toSettings.active && m_toSettings.hueVsHueCurve.overrideState ? m_toSettings.hueVsHueCurve.value : m_tempSettings.hueVsHueCurve.value;

        //hueVsSatCurve
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.hueVsSatCurve.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.hueVsSatCurve.overrideState))
        {
            m_tempSettings.hueVsSatCurve.overrideState = true;
        }
        else
        {
            m_tempSettings.hueVsSatCurve.overrideState = false;
        }
        fromHueVsSatCurve = m_fromSettings != null && m_fromSettings.active && m_fromSettings.hueVsSatCurve.overrideState ? m_fromSettings.hueVsSatCurve.value : m_tempSettings.hueVsSatCurve.value;
        toHueVsSatCurve = m_toSettings != null && m_toSettings.active && m_toSettings.hueVsSatCurve.overrideState ? m_toSettings.hueVsSatCurve.value : m_tempSettings.hueVsSatCurve.value;

        //satVsSatCurve
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.satVsSatCurve.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.satVsSatCurve.overrideState))
        {
            m_tempSettings.satVsSatCurve.overrideState = true;
        }
        else
        {
            m_tempSettings.satVsSatCurve.overrideState = false;
        }
        fromSatVsSatCurve = m_fromSettings != null && m_fromSettings.active && m_fromSettings.satVsSatCurve.overrideState ? m_fromSettings.satVsSatCurve.value : m_tempSettings.satVsSatCurve.value;
        toSatVsSatCurve = m_toSettings != null && m_toSettings.active && m_toSettings.satVsSatCurve.overrideState ? m_toSettings.satVsSatCurve.value : m_tempSettings.satVsSatCurve.value;

        //lumVsSatCurve
        if ((m_fromSettings != null && m_fromSettings.active && m_fromSettings.lumVsSatCurve.overrideState) ||
            (m_toSettings != null && m_toSettings.active && m_toSettings.lumVsSatCurve.overrideState))
        {
            m_tempSettings.lumVsSatCurve.overrideState = true;
        }
        else
        {
            m_tempSettings.lumVsSatCurve.overrideState = false;
        }
        fromLumVsSatCurve = m_fromSettings != null && m_fromSettings.active && m_fromSettings.lumVsSatCurve.overrideState ? m_fromSettings.lumVsSatCurve.value : m_tempSettings.lumVsSatCurve.value;
        toLumVsSatCurve = m_toSettings != null && m_toSettings.active && m_toSettings.lumVsSatCurve.overrideState ? m_toSettings.lumVsSatCurve.value : m_tempSettings.lumVsSatCurve.value;
    }

    public override void Lerp(float t)
    {
        if (!IsValid())
        {
            return;
        }

        m_tempSettings.gradingMode.Interp(fromGradingMode, toGradingMode, t);
        m_tempSettings.externalLut.Interp(fromExternalLut, toExternalLut, t);
        m_tempSettings.tonemapper.Interp(fromTonemapper, toTonemapper, t);
        m_tempSettings.toneCurveToeStrength.Interp(toneCurveToeStrength.x, toneCurveToeStrength.y, t);
        m_tempSettings.toneCurveToeLength.Interp(toneCurveToeLength.x, toneCurveToeLength.y, t);
        m_tempSettings.toneCurveShoulderStrength.Interp(toneCurveShoulderStrength.x, toneCurveShoulderStrength.y, t);
        m_tempSettings.toneCurveShoulderLength.Interp(toneCurveShoulderLength.x, toneCurveShoulderLength.y, t);
        m_tempSettings.toneCurveShoulderAngle.Interp(toneCurveShoulderAngle.x, toneCurveShoulderAngle.y, t);
        m_tempSettings.toneCurveGamma.Interp(toneCurveGamma.x, toneCurveGamma.y, t);
        m_tempSettings.ldrLut.Interp(fromLdrLut, toLdrLut, t);
        m_tempSettings.ldrLutContribution.Interp(ldrLutContribution.x, ldrLutContribution.y, t);
        m_tempSettings.temperature.Interp(temperature.x, temperature.y, t);
        m_tempSettings.tint.Interp(tint.x, tint.y, t);
        m_tempSettings.colorFilter.Interp(fromColorFilter, toColorFilter, t);
        m_tempSettings.hueShift.Interp(hueShift.x, hueShift.y, t);
        m_tempSettings.saturation.Interp(saturation.x, saturation.y, t);
        m_tempSettings.brightness.Interp(brightness.x, brightness.y, t);
        m_tempSettings.postExposure.Interp(postExposure.x, postExposure.y, t);
        m_tempSettings.contrast.Interp(contrast.x, contrast.y, t);
        m_tempSettings.mixerRedOutRedIn.Interp(mixerRedOutRedIn.x, mixerRedOutRedIn.y, t);
        m_tempSettings.mixerRedOutGreenIn.Interp(mixerRedOutGreenIn.x, mixerRedOutGreenIn.y, t);
        m_tempSettings.mixerRedOutBlueIn.Interp(mixerRedOutBlueIn.x, mixerRedOutBlueIn.y, t);
        m_tempSettings.mixerGreenOutRedIn.Interp(mixerGreenOutRedIn.x, mixerGreenOutRedIn.y, t);
        m_tempSettings.mixerGreenOutGreenIn.Interp(mixerGreenOutGreenIn.x, mixerGreenOutGreenIn.y, t);
        m_tempSettings.mixerGreenOutBlueIn.Interp(mixerGreenOutBlueIn.x, mixerGreenOutBlueIn.y, t);
        m_tempSettings.mixerBlueOutRedIn.Interp(mixerBlueOutRedIn.x, mixerBlueOutRedIn.y, t);
        m_tempSettings.mixerBlueOutGreenIn.Interp(mixerBlueOutGreenIn.x, mixerBlueOutGreenIn.y, t);
        m_tempSettings.mixerBlueOutBlueIn.Interp(mixerBlueOutBlueIn.x, mixerBlueOutBlueIn.y, t);
        m_tempSettings.lift.Interp(fromLift, toLift, t);
        m_tempSettings.gamma.Interp(fromGamma, toGamma, t);
        m_tempSettings.gain.Interp(fromGain, toGain, t);
        m_tempSettings.masterCurve.Interp(fromMasterCurve, toMasterCurve, t);
        m_tempSettings.redCurve.Interp(fromRedCurve, toRedCurve, t);
        m_tempSettings.greenCurve.Interp(fromGreenCurve, toGreenCurve, t);
        m_tempSettings.blueCurve.Interp(fromBlueCurve, toBlueCurve, t);
        m_tempSettings.hueVsHueCurve.Interp(fromHueVsHueCurve, toHueVsHueCurve, t);
        m_tempSettings.hueVsSatCurve.Interp(fromHueVsSatCurve, toHueVsSatCurve, t);
        m_tempSettings.satVsSatCurve.Interp(fromSatVsSatCurve, toSatVsSatCurve, t);
        m_tempSettings.lumVsSatCurve.Interp(fromLumVsSatCurve, toLumVsSatCurve, t);
    }
}
