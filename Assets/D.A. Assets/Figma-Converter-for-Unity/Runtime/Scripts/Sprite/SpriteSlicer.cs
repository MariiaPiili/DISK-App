using DA_Assets.DAI;
using DA_Assets.Extensions;
using DA_Assets.FCU.Extensions;
using DA_Assets.FCU.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DA_Assets.FCU
{
    [Serializable]
    public class SpriteSlicer : MonoBehaviourLinkerRuntime<FigmaConverterUnity>
    {
        public async Task SliceSprites(List<FObject> fobjects)
        {
            foreach (FObject fobject in fobjects)
            {
                if (monoBeh.IsCancellationRequested(TokenType.Import))
                    return;

                if (!fobject.IsSprite())
                    continue;

                if (fobject.Children.IsEmpty())
                    continue;

                if (fobject.Children.Count != 9)
                    continue;

                Sprite sprite = monoBeh.SpriteProcessor.GetSprite(fobject);

                if (sprite == null)
                    continue;

                FObject child0 = fobject.Children[0];
                FObject child1 = fobject.Children[1];
                FObject child2 = fobject.Children[2];
                FObject child3 = fobject.Children[3];
                FObject child4 = fobject.Children[4];
                FObject child5 = fobject.Children[5];
                FObject child6 = fobject.Children[6];
                FObject child7 = fobject.Children[7];
                FObject child8 = fobject.Children[8];

                float imageScale = fobject.Data.Scale;

                int left = (int)(child0.Size.x * imageScale);
                int top = (int)(child0.Size.y * imageScale);
                int right = (int)(child2.Size.x * imageScale);
                int bottom = (int)(child6.Size.y * imageScale);

                Vector4 border = new Vector4(left, bottom, right, top);

                Texture2D texture = CreateMinimal9Slice(sprite, border);
                monoBeh.SpriteProcessor.SaveSprite(texture, fobject);

                sprite = monoBeh.SpriteProcessor.GetSprite(fobject);
                monoBeh.DelegateHolder.SetSpriteRects(sprite, border);
                await Task.Yield();
            }
        }

        // Creating a new sprite without the center part
        public Texture2D CreateMinimal9Slice(Sprite sourceSprite, Vector4 borders)
        {
            // Get border sizes from 9-slice settings
            float leftBorder = borders.x;
            float bottomBorder = borders.y;
            float rightBorder = borders.z;
            float topBorder = borders.w;

            // Calculate new dimensions without the center
            int newWidth = (int)(leftBorder + rightBorder);
            int newHeight = (int)(topBorder + bottomBorder);

            // Create a new texture
            Texture2D newTexture = new Texture2D(newWidth, newHeight);

            // Copy corners and sides
            // Top left corner
            Graphics.CopyTexture(sourceSprite.texture, 0, 0, 0, 0, (int)leftBorder, (int)topBorder,
                                newTexture, 0, 0, 0, 0);

            // Top right corner
            Graphics.CopyTexture(sourceSprite.texture, 0, 0,
                                sourceSprite.texture.width - (int)rightBorder, 0,
                                (int)rightBorder, (int)topBorder,
                                newTexture, 0, 0, (int)leftBorder, 0);

            // Bottom left corner
            Graphics.CopyTexture(sourceSprite.texture, 0, 0, 0,
                                sourceSprite.texture.height - (int)bottomBorder,
                                (int)leftBorder, (int)bottomBorder,
                                newTexture, 0, 0, 0, (int)topBorder);

            // Bottom right corner
            Graphics.CopyTexture(sourceSprite.texture, 0, 0,
                                sourceSprite.texture.width - (int)rightBorder,
                                sourceSprite.texture.height - (int)bottomBorder,
                                (int)rightBorder, (int)bottomBorder,
                                newTexture, 0, 0, (int)leftBorder, (int)topBorder);

            // Create and return the new sprite
            return newTexture;
        }
    }
}