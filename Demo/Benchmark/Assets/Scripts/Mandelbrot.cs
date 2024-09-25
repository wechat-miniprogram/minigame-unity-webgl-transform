using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Mandelbrot : ScriptingTest
{
    public UnityEngine.UI.Image outputImage;
    Texture2D output;
    public int width = 512;
    public int height = 512;
    Color32[] colors;

    struct ComplexNumber
    {
        public float Re;
        public float Im;

        public ComplexNumber(float re, float im)
        {
            this.Re = re;
            this.Im = im;
        }

        public static ComplexNumber operator +(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Re + y.Re, x.Im + y.Im);
        }

        public static ComplexNumber operator *(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Re * y.Re - x.Im * y.Im, x.Re * y.Im + x.Im * y.Re);
        }

        public float Norm()
        {
            return Re * Re + Im * Im;
        }
    }

    const float MaxValueExtent = 2.0f;
    float scale;
    float xShift = 0;
    int MaxIterations = 20;
    int iterationCounter;

    int CalcMandelbrotSetColor(ComplexNumber c)
    {
        // from http://en.wikipedia.org/w/index.php?title=Mandelbrot_set
        const float MaxNorm = MaxValueExtent * MaxValueExtent;

        int iteration = 0;
        ComplexNumber z = new ComplexNumber();
        do
        {
            z = z * z + c;
            iteration++;
        } while (z.Norm() < MaxNorm && iteration < MaxIterations);
        iterationCounter += iteration;
        if (iteration < MaxIterations)
            return iteration;
        else
            return -1;
    }

    void GenerateBitmap()
    {
        for (int i = 0; i < height; i++)
        {
            float y = (height / 2 - i) * scale;
            for (int j = 0; j < width; j++)
            {
                float x = ((j - width / 2)) * scale + xShift;
                int col = (CalcMandelbrotSetColor(new ComplexNumber(x, y)));
                if (col == -1)
                    colors[i * width + j] = new Color32(0, 0, 0, 255);
                else
                    colors[i * width + j] = new Color32(
                        (byte)(128 + Mathf.Sin(col * 0.11f) * 127),
                        (byte)(128 + Mathf.Cos(col * 0.077f) * 127),
                        (byte)(128 + Mathf.Sin(col * 0.027f) * 127),
                        255
                    );
            }
        }
    }

    public override void UpdateTest()
    {
        if (colors == null)
        {
            //colors = new Color32[width*height];
            //output = new Texture2D(width, height, TextureFormat.ARGB32, false);
            //outputImage.sprite = output;
            scale = 2 * MaxValueExtent / Mathf.Min(width, height);
        }
        GenerateBitmap();
        score += -1 + iterationCounter / 10000;
        iterationCounter = 0;
        scale *= 0.948f;
        MaxIterations++;
        xShift -= 5.27f * scale;

        if (scale < 0.000001)
        {
            scale = 2 * MaxValueExtent / Mathf.Min(width, height);
            xShift = 0;
        }
    }

    public override void UpdateFrame()
    {
        output.SetPixels32(colors);
        output.Apply();
    }
}
