using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class imageSwap : MonoBehaviour
{
    public Image[] images; // Array of images to swap
    public Image firstClickedImage; // Reference to the first clicked image
    private bool isSwapping = false; // Flag to prevent multiple swaps at once


    private void Start()
    {
        foreach (Image image in images)
        {
            Button button = image.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnImageClick(image));
            }
            else
            {
                Debug.LogWarning("Image is missing Button component: " + image.name);
            }
        }
    }
  
    public void OnImageClick(Image clickedImage)
    {
        if (firstClickedImage == null)
        {
            Debug.Log("FIRST IMAGE");
            firstClickedImage = clickedImage;
        }
        else
        {
            // Find the indices of the clicked images in the array
            int firstIndex = System.Array.IndexOf(images, firstClickedImage);
            int secondIndex = System.Array.IndexOf(images, clickedImage);

            // Check if the second image is adjacent to the first one
            if (IsAdjacent(firstIndex, secondIndex))
            {
                Debug.Log("adjacent");
                // Perform the swap
                SwapImages(firstClickedImage, clickedImage);
            }

            firstClickedImage = null; // Reset first clicked image after swap
        }
    }
    public bool IsAdjacent(int firstIndex, int secondIndex)
        {
            // Determine if the images are adjacent in the array
            int numRows = Mathf.RoundToInt(Mathf.Sqrt(images.Length));
            int firstRow = firstIndex / numRows;
            int firstCol = firstIndex % numRows;
            int secondRow = secondIndex / numRows;
            int secondCol = secondIndex % numRows;

            return Mathf.Abs(firstRow - secondRow) + Mathf.Abs(firstCol - secondCol) == 1;
        }

        public void SwapImages(Image firstImage, Image secondImage)
    {
        // Find the indices of the images in the array
        int firstIndex = System.Array.IndexOf(images, firstImage);
        int secondIndex = System.Array.IndexOf(images, secondImage);

        // Swap the sprite sources of the images
        Sprite tempSprite = firstImage.sprite;
        firstImage.sprite = secondImage.sprite;
        secondImage.sprite = tempSprite;
        Invoke("CheckMatches", 1);

        // Additional swapping logic (e.g., sprite, color, etc.) can be added here
    }

    public void CheckMatches()
    {
        // Iterate through all images
        for (int i = 0; i < images.Length; i++)
        {
            // Skip if the image is null
            if (images[i] == null)
                continue;

            // Find row and column of the current image
            int numRows = Mathf.RoundToInt(Mathf.Sqrt(images.Length));
            int row = i / numRows;
            int col = i % numRows;

            // Check matches to the right
            if (col <= numRows - 3 && images[i].sprite == images[i + 1].sprite && images[i].sprite == images[i + 2].sprite)
            {
                // Remove the sprites of the matched images
                images[i].sprite = null;
                images[i + 1].sprite = null;
                images[i + 2].sprite = null;
            }

            // Check matches below
            if (row <= numRows - 3 && images[i].sprite == images[i + numRows].sprite && images[i].sprite == images[i + numRows * 2].sprite)
            {
                // Remove the sprites of the matched images
                images[i].sprite = null;
                images[i + numRows].sprite = null;
                images[i + numRows * 2].sprite = null;
            }
        }

    }
}