using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DirectionControl : MonoBehaviour, IPointerClickHandler
{
	[SerializeField]
	FieldVector2 direction;
	[SerializeField]
	Player playerView;

	public void OnPointerClick (PointerEventData eventData)
	{
		playerView.ChangeDirection(direction);
	}
}

