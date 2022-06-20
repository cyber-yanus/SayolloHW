using UnityEngine;

public static class ByteToSpriteConverter
{
    public static Sprite ToSprite(this byte[] data)
    {
        var tex = new Texture2D(1,1);
        tex.LoadImage(data);

        float texWidth = tex.width;
        float texHeight = tex.height;
        
        var rect = new Rect(0, 0, texWidth, texHeight);
        var pivot = new Vector2(texWidth / 2, texHeight / 2);

        return Sprite.Create(tex, rect, pivot);
    }
}