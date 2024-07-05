using System;
using UnityEngine;

public class BuildingInteraction : MonoBehaviour
{
    [SerializeField] private Canvas _buildingCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the building.");
            _buildingCanvas.GetComponent<CanvasGroup>().alpha = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left the building.");
            if (_buildingCanvas == null)
            {
                return;
            }
            _buildingCanvas.GetComponent<CanvasGroup>().alpha = 0;
        }
    }
}