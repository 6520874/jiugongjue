using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class LaneLinePropertyHelper : MonoBehaviour
{
    private Renderer render_prop = null;
    private GameObject real_node = null;
    private MaterialPropertyBlock mat_prop_block = null;

    public Color LineBaseColorProp;
    public float LineOpacityProp;

    public Vector4 NearCoefficientProp;
    public Vector4 FarCoefficientProp;

    public float MinPositionProp;
    public float CenterPositionProp;
    public float MaxPositionProp;

    public float LineWidthProp;
    public float GapWidthProp;

    public float SolidPercentProp;
    public float DashMoveDistanceProp;
    public float DashSolidRatioProp;
    public float DashSolidTotalLengthProp;

    public void Awake()
    {
        real_node = gameObject.transform.Find("LineSegment").gameObject;
        render_prop = real_node.GetComponent<Renderer>();
        mat_prop_block = new MaterialPropertyBlock();

        var myms = real_node.GetComponent<MeshFilter>().sharedMesh;
        myms.bounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 100));
    }

    public void Start()
    {
        mat_prop_block.SetColor("_LineBaseColor", LineBaseColorProp);
        mat_prop_block.SetFloat("_LineOpacity", LineOpacityProp);

        mat_prop_block.SetVector("_NearCoefficient", NearCoefficientProp);
        mat_prop_block.SetVector("_FarCoefficient", FarCoefficientProp);

        mat_prop_block.SetFloat("_MinPosition", MinPositionProp);
        mat_prop_block.SetFloat("_MaxPosition", MaxPositionProp);
        mat_prop_block.SetFloat("_CenterPosition", CenterPositionProp);

        mat_prop_block.SetFloat("_LineWidth", LineWidthProp);
        mat_prop_block.SetFloat("_GapWidth", GapWidthProp);

        mat_prop_block.SetFloat("_SolidPercent", SolidPercentProp);
        mat_prop_block.SetFloat("_DashMoveDistance", DashMoveDistanceProp);
        mat_prop_block.SetFloat("_DashSolidRatio", DashSolidRatioProp);
        mat_prop_block.SetFloat("_DashSolidTotalLength", DashSolidTotalLengthProp);

        UpdateLaneLineProperty();
    }

    /*
    public void Update()
    {
        mat_prop_block.SetColor("_LineBaseColor", LineBaseColorProp);
        mat_prop_block.SetFloat("_LineOpacity", LineOpacityProp);
        mat_prop_block.SetVector("_NearCoefficient", NearCoefficientProp);
        mat_prop_block.SetVector("_FarCoefficient", FarCoefficientProp);
        mat_prop_block.SetFloat("_MinPosition", MinPositionProp);
        mat_prop_block.SetFloat("_CenterPosition", CenterPositionProp);
        mat_prop_block.SetFloat("_MaxPosition", MaxPositionProp);
        mat_prop_block.SetFloat("_LineWidth", LineWidthProp);
        mat_prop_block.SetFloat("_GapWidth", GapWidthProp);
        mat_prop_block.SetFloat("_SolidPercent", SolidPercentProp);
        mat_prop_block.SetFloat("_DashMoveDistance", DashMoveDistanceProp);
        mat_prop_block.SetFloat("_DashSolidRatio", DashSolidRatioProp);
        mat_prop_block.SetFloat("_DashSolidTotalLength", DashSolidTotalLengthProp);
        UpdateLaneLineProperty();
    }
    */

    public void UpdateLaneLineProperty()
    {
        render_prop.SetPropertyBlock(mat_prop_block);
    }

    public void SetActive(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

    public void SetLineBaseColor(Color line_base_color)
    {
        LineBaseColorProp = line_base_color;
        mat_prop_block.SetColor("_LineBaseColor", LineBaseColorProp);
    }

    public void SetLineOpacity(float line_opacity)
    {
       
        LineOpacityProp = line_opacity;
        mat_prop_block.SetFloat("_LineOpacity", LineOpacityProp);
    }

    public void SetNearCoefficient(Vector4 near_coeff)
    {
        NearCoefficientProp = near_coeff;
        mat_prop_block.SetVector("_NearCoefficient", NearCoefficientProp);
    }

    public void SetFarCoefficient(Vector4 far_coeff)
    {
        FarCoefficientProp = far_coeff;
        mat_prop_block.SetVector("_FarCoefficient", FarCoefficientProp);
    }

    public void SetMinPosition(float min_pos)
    {
        MinPositionProp = min_pos;
        mat_prop_block.SetFloat("_MinPosition", MinPositionProp);
    }

    public void SetCenterPosition(float cen_pos)
    {
        CenterPositionProp = cen_pos;
        mat_prop_block.SetFloat("_CenterPosition", CenterPositionProp);
    }

    public void SetMaxPosition(float max_pos)
    {
        MaxPositionProp = max_pos;
        mat_prop_block.SetFloat("_MaxPosition", MaxPositionProp);
    }

    public void SetLineWidth(float line_width)
    {
        LineWidthProp = line_width;
        mat_prop_block.SetFloat("_LineWidth", LineWidthProp);
    }

    public void SetGapWidth(float gap_width)
    {
        GapWidthProp = gap_width;
        mat_prop_block.SetFloat("_GapWidth", GapWidthProp);
    }

    public void SetSolidPercent(float solid_percent)
    {
        SolidPercentProp = solid_percent;
        mat_prop_block.SetFloat("_SolidPercent", SolidPercentProp);
    }

    public void SetDashMoveDistance(float move_distance)
    {
        DashMoveDistanceProp = move_distance;
        mat_prop_block.SetFloat("_DashMoveDistance", DashMoveDistanceProp);
    }

    public void SetDashSolidRatio(float dash_solid_ratio)
    {
        DashSolidRatioProp = dash_solid_ratio;
        mat_prop_block.SetFloat("_DashSolidRatio", DashSolidRatioProp);
    }

    public void SetDashSolidTotalLength(float dash_solid_tlength)
    {
        DashSolidTotalLengthProp = dash_solid_tlength;
        mat_prop_block.SetFloat("_DashSolidTotalLength", DashSolidTotalLengthProp);
    }

}
