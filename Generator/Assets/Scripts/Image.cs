/*
 * File: Image.cs
 * File Created: Friday, 24th April 2020 10:22:17 am
 * ––––––––––––––––––––––––
 * Author: Jesus Fermin, 'Pokoi', Villar  (hello@pokoidev.com)
 * ––––––––––––––––––––––––
 * MIT License
 * 
 * Copyright (c) 2020 Pokoidev
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in
 * the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 * of the Software, and to permit persons to whom the Software is furnished to do
 * so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator
{
    /**
    @brief Class to manage pixel color information. Values are storaged in 0.0 - 1.0 range
    */
    public class Pixel
    {
        public float red;
        public float green;
        public float blue;

        /** 
        @brief Creates a Pixel with 0.0 as value of all the components
        */
        public Pixel()
        {
            red = green = blue = 0.0f;
        }

        /** 
        @brief Creates a Pixel with given values in range 0 - 255
        @param r The red component in range 0 - 255
        @param g The green component in range 0 - 255
        @param b The blue component in range 0 - 255
        */
        public Pixel(byte r, byte g, byte b)
        {
            red     = (float) r / 255.0f;
            green   = (float) g / 255.0f;
            blue    = (float) b / 255.0f;
        }

        /** 
        @brief Creates a Pixel with given values in range 0.0 - 1.0
        @param r The red component in range 0.0 - 1.0
        @param g The green component in range 0.0 - 1.0
        @param b The blue component in range 0.0 - 1.0
        */
        public Pixel (float r, float g, float b)
        {
            red     = r;
            green   = g;
            blue    = b;
        }
    }

    /** 
    @brief Class to manage Image creations and transformations
    */
    public class Image 
    {
        /** 
        @brief The width of the image in pixels
        */
        int width;

        /** 
        @brief The height of the image in pixels
        */
        int height;

        /** 
        @brief The collection of pixels
        */
        Generator.Pixel[] pixels;        
        
        /** 
        @brief Creates a Image with the given pixels
        @param w The width of the image
        @param h The height of the image
        */
        public Image(int w, int h, Generator.Pixel[] p)
        {
            width   = w > 0 ? w : 0;
            height  = h > 0 ? h : 0;
            pixels  = p;
        }

        /** 
        @brief Creates a empty image of the given dimensions
        @param w The width of the image
        @param h The height of the image
        */
        public Image (int w, int h)
        {
            width   = w > 0 ? w : 0;
            height  = h > 0 ? h : 0;
            pixels  = new Generator.Pixel[w*h];
        }

        /** 
        @brief Sets a pixel in the given position
        @param x The x coordinate of the pixel
        @param y The y coordinate of the pixel
        @param pixel The pixel to replace with
        */
        public void SetPixel(int x, int y, Pixel pixel) => pixels[y * width + x] = pixel;

        /** 
        @brief Export the image as png to the given path
        @param path The path where the image will be storaged
        */
        public void Export(string path)
        {
            Texture2D original = new Texture2D (width, height);

            for(int y = 0; y < height; ++y)
            {
                for(int x = 0; x < width; ++x)
                {              
                    Color color = new Color (
                                                pixels[y*width + x].red,
                                                pixels[y*width + x].green,
                                                pixels[y*width + x].blue
                                            );

                    original.SetPixel(x, y, color);
                }
            }

            byte[] bytes = original.EncodeToPNG();
            System.IO.File.WriteAllBytes(path, bytes);
        }

        /** 
        @brief Fill the image with a given pixel
        @param fill The pixel with the color information for the fill operation
        */
        public void Fill(Generator.Pixel fill)
        {
            for(int y = 0; y < height; ++y)
            {
                for(int x = 0; x < width; ++x)
                {              
                   pixels[y*width + x] = fill;                   
                }
            }
        }

        /** 
        @brief Apply a pattern mask to the image. 1 values of the mask will be replaced with the given pixel.Adapts the pattern to the image aspect ratio
        @param pattern The mask pattern to apply
        @param positive The pixel to replace in the original image
        */
        public void ApplyPattern (byte[,] pattern, Generator.Pixel positive)
        {
            float heightRatio   = (float) pattern.GetLength(0) / (float) height;
            float widthRatio    = (float) pattern.GetLength(1) / (float) width;

            for(int y = 0; y < height; ++y)
            {
                for(int x = 0; x < width; ++x)
                {              
                   pixels[y*width + x] = pattern[ (int) (y * heightRatio) , (int) (x * widthRatio) ] == 1 ? positive : pixels[y*width + x];                    
                }
            }

        }

    }

}
