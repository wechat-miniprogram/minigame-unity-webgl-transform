using TMPro;
using UnityEngine;

public class DropdownSample: MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI text = null;

	[SerializeField]
	private TMP_Dropdown dropdownWithoutPlaceholder = null;

	[SerializeField]
	private TMP_Dropdown dropdownWithPlaceholder = null;

	public void OnButtonClick()
	{
		text.text = dropdownWithPlaceholder.value > -1 ? "Selected values:\n" + dropdownWithoutPlaceholder.value + " - " + dropdownWithPlaceholder.value : "Error: Please make a selection";
	}
}
