using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgroundScript : MonoBehaviour
{
    public Transform ReferenceObject;

    public float XSpeed;

    private SpriteRenderer _baseImage;
    private List<GameObject> _images;

    private Vector2 _size;

    // Start is called before the first frame update
    void Start()
    {
        _baseImage = gameObject.GetComponent<SpriteRenderer>();
        _baseImage.enabled = false;

        _images = new List<GameObject>(3);

        for (int i = 0; i < 3; i++)
        {
            var image = new GameObject($"Image {i}");
            image.transform.parent = transform;
            var sprite = image.AddComponent<SpriteRenderer>();
            sprite.sprite = _baseImage.sprite;

            _images.Add(image);
        }

        _size = new Vector2(_baseImage.sprite.bounds.size.x, _baseImage.sprite.bounds.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        var xOffset = ReferenceObject.position.x * XSpeed;

        for (int i = 0; i < 3; i++)
        {
            var offset = _size.x * (i - 1);
            _images[i].transform.position = new Vector3(-(xOffset % _size.x) + offset, _images[i].transform.position.y, _images[i].transform.position.z);
        }
    }
}
