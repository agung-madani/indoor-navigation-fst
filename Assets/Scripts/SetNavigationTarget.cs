using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown navigationTargetDropDown;
    [SerializeField] private List<Target> navigationTargetObjects = new List<Target>();
    [SerializeField] private Slider navigationYOffset;

    private NavMeshPath path;
    private LineRenderer line;
    private Vector3 targetPosition = Vector3.zero;

    private int currentFloor = 4;

    private bool lineToggle = false;

    private void Start()
    {
        path = new NavMeshPath();
        line = GetComponent<LineRenderer>(); // Use GetComponent directly
        line.enabled = lineToggle;
    }

    private void Update()
    {
        if (lineToggle && targetPosition != Vector3.zero)
        {
            UpdateLineRenderer();
        }
    }

    private void UpdateLineRenderer()
    {
        NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
        line.positionCount = path.corners.Length;
        Vector3[] calculatedPathAndOffset = AddLineOffset();
        line.SetPositions(calculatedPathAndOffset);
    }

    public void SetCurrentNavigationTarget(int selectedValue)
    {
        targetPosition = Vector3.zero;
        string selectedText = navigationTargetDropDown.options[selectedValue].text;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.Equals(selectedText));
        if (currentTarget != null)
        {
            if (!line.enabled) {
                ToggleVisibility();
            }
            targetPosition = currentTarget.PositionObject.transform.position;
        }
    }

    public void ToggleVisibility()
    {
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
    }

    public void ChangeActiveFloor(int floorNumber) {
        currentFloor = floorNumber;;
        SetNavigationTargetDropDownOptions(currentFloor);
    }

    private Vector3[] AddLineOffset()
    {
        if (navigationYOffset.value == 0)
        {
            return path.corners;
        }

        Vector3[] calculatedLine = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++)
        {
            calculatedLine[i] = path.corners[i] + new Vector3(0, navigationYOffset.value, 0);
        }

        return calculatedLine;
    }

    public void SetNavigationTargetDropDownOptions(int floorNumber) {
        navigationTargetDropDown.ClearOptions();
        navigationTargetDropDown.value = 0;

        if (line.enabled) {
            ToggleVisibility();
        }

        if (floorNumber == 4) {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabBasisData"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabRiset&Pengembangan"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabMatematika"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabSistemCerdas"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabRekayasaPerangkatLunak"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabSistemInformasi"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabManajemen"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("RuangPengelolaLabInformatika&Komputer"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabElektronika&Instrumentasi"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabPendidikan"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabGelombangOptika&Astrofisika"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabFisikaDasar"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("ToiletPutra4"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("ToiletPutri4"));
        }

        if (floorNumber == 3) {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabGenetika"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabEmbriologi"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabBiologiTerpadu"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabEkologiBotani"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabMikrobiologi"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabFisiologiHewan&Zoologi"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabFisiologiTumbuhan"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("RuangPenelitian"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabPendidikanLt3"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("ToiletPutra3"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("ToiletPutri3"));
        }

        if (floorNumber == 2) {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("RuangKoordPlp"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("RuangPlp&Asisten"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabInstrumenKimia"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabKimiaFisika/Organik"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabKimiaTerpadu"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("RuangRapat/LabPendidikanKimia"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("RuangKoordinator"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabKimiaAnalitik/Anorganik"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabBiokimia/Penelitian"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("ToiletPutra2"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("ToiletPutri2"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("MusholaLt2"));
        }

        if (floorNumber == 1) {
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabSistemManufakturCNC"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabSistemManufakturCIM"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("MeetingRoom"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabOptimisasi&Komp"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("EntrepreneurshipCorner"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("RuangPengelola"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("RuangWorkshopFisika"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("RuangDosenLt1"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabErgonomika"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabTermodinamika&Geofisika"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("LabFisikaModern&AtomInti"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("RuangKepalaLabTerpadu"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("ToiletPutra1"));
            navigationTargetDropDown.options.Add(new TMP_Dropdown.OptionData("ToiletPutri1"));
        }
    }
}
