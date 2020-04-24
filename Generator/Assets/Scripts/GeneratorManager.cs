/*
 * File: GeneratorManager.cs
 * File Created: Friday, 24th April 2020 10:50:33 am
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
using UnityEditor;

namespace Generator
{
    public class GeneratorManager : MonoBehaviour
    {   
        /** The amount of images with one mask application */   
        public int simpleImages = 0;

        /** The amount of images with two mask applications */   
         public int doubleImages = 0;

        /** The amount of images with three mask application */   
        public int tripleImages = 0;

        /** The width of the image */   
        public int imageWidth = 0;

        /** The height of the image */   
        public int imageHeight = 0;

        /** The exportation path */   
        public string exportationPath = "Assets/GeneratedImages/";

        /** The collection of mask patterns to apply */   
        List<byte[,]> patterns = new List<byte[,]>();

        int exportedImagesCount = 0;

        private void Start()
        {
            CreatePatterns();

            CreateSimpleImages();
            CreateDoubleImages();
            CreateTripleImages();

            #if UNITY_EDITOR
            if(EditorApplication.isPlaying) 
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        #endif
            
        }

        /**
        @brief Add the patterns mask to the collection
        */
        public void CreatePatterns()
        {
            patterns.Add (  new byte[,] { // 0  1  2  3  4  5  6  7
                                            {1, 1, 0, 1, 1, 0, 1, 1}, // 0
                                            {1, 0, 0, 0, 0, 0, 0, 1}, // 1
                                            {0, 0, 1, 0, 0, 1, 0, 0}, // 2
                                            {0, 0, 0, 1, 1, 0, 0, 0}, // 3
                                            {0, 0, 0, 0, 0, 0, 0, 0}, // 4
                                            {0, 0, 1, 0, 0, 1, 0, 0}, // 5
                                            {1, 0, 0, 0, 0, 0, 0, 1}, // 6
                                            {1, 1, 0, 1, 1, 0, 1, 1}  // 7
                                        }
                        );

            patterns.Add (  new byte[,] { // 0  1  2  3  4  5  6  7
                                            {0, 0, 0, 0, 0, 0, 0, 0}, // 0
                                            {0, 1, 0, 1, 0, 1, 0, 1}, // 1
                                            {1, 0, 1, 0, 1, 0, 1, 0}, // 2
                                            {0, 0, 0, 0, 0, 0, 0, 0}, // 3
                                            {0, 0, 0, 0, 0, 0, 0, 0}, // 4
                                            {0, 1, 0, 1, 0, 1, 0, 1}, // 5
                                            {1, 0, 1, 0, 1, 0, 1, 0}, // 6
                                            {0, 0, 0, 0, 0, 0, 0, 0}  // 7
                                        }
                        );

            patterns.Add (  new byte[,] { // 0  1  2  3  4  5  6  7
                                            {0, 0, 0, 0, 0, 0, 0, 0}, // 0
                                            {0, 1, 1, 0, 0, 1, 1, 0}, // 1
                                            {1, 1, 1, 1, 1, 1, 1, 1}, // 2
                                            {1, 1, 1, 1, 1, 1, 1, 1}, // 3
                                            {0, 1, 1, 1, 1, 1, 1, 0}, // 4
                                            {0, 1, 1, 1, 1, 1, 1, 0}, // 5
                                            {0, 0, 1, 1, 1, 1, 0, 0}, // 6
                                            {0, 0, 0, 1, 1, 0, 0, 0}  // 7
                                        }
                        );
            
            patterns.Add (  new byte[,] { // 0  1  2  3  4  5  6  7
                                            {0, 0, 1, 1, 0, 0, 0, 0}, // 0
                                            {0, 0, 1, 1, 0, 0, 0, 0}, // 1
                                            {0, 0, 1, 1, 0, 0, 0, 0}, // 2
                                            {0, 0, 1, 1, 0, 0, 0, 0}, // 3
                                            {0, 0, 1, 1, 1, 1, 1, 1}, // 4
                                            {1, 1, 1, 1, 1, 1, 1, 1}, // 5
                                            {1, 1, 1, 1, 0, 0, 0, 0}, // 6
                                            {0, 0, 1, 1, 0, 0, 0, 0}  // 7
                                        }
                        );

            patterns.Add (  new byte[,] { // 0  1  2  3  4  5  6  7
                                            {0, 0, 0, 1, 1, 0, 0, 0}, // 0
                                            {0, 0, 0, 0, 0, 0, 0, 0}, // 1
                                            {0, 0, 0, 1, 1, 0, 0, 0}, // 2
                                            {0, 1, 0, 1, 1, 1, 0, 1}, // 3
                                            {0, 1, 0, 1, 1, 1, 0, 1}, // 4
                                            {0, 0, 0, 1, 1, 0, 0, 0}, // 5
                                            {0, 0, 0, 0, 0, 0, 0, 0}, // 6
                                            {0, 0, 0, 1, 1, 0, 0, 0}  // 7
                                        }
                        );

            patterns.Add (  new byte[,] { // 0  1  2  3  4  5  6  7
                                            {0, 0, 0, 0, 0, 0, 0, 0}, // 0
                                            {0, 1, 1, 0, 0, 1, 1, 0}, // 1
                                            {0, 1, 1, 0, 0, 1, 1, 0}, // 2
                                            {0, 0, 0, 1, 1, 0, 0, 0}, // 3
                                            {0, 0, 1, 1, 1, 1, 0, 0}, // 4
                                            {0, 0, 1, 1, 1, 1, 0, 0}, // 5
                                            {0, 0, 1, 0, 0, 1, 0, 0}, // 6
                                            {0, 0, 0, 0, 0, 0, 0, 0}  // 7
                                        }
                        );

            patterns.Add (  new byte[,] { // 0  1  2  3  4  5  6  7
                                            {1, 0, 1, 0, 1, 0, 1, 0}, // 0
                                            {0, 1, 0, 1, 0, 1, 0, 1}, // 1
                                            {1, 0, 1, 0, 1, 0, 1, 0}, // 2
                                            {0, 1, 0, 1, 0, 1, 0, 1}, // 3
                                            {1, 0, 1, 0, 1, 0, 1, 0}, // 4
                                            {0, 1, 0, 1, 0, 1, 0, 1}, // 5
                                            {1, 0, 1, 0, 1, 0, 1, 0}, // 6
                                            {0, 1, 0, 1, 0, 1, 0, 0}  // 7
                                        }
                        );

            patterns.Add (  new byte[,] { // 0  1  2  3  4  5  6  7
                                            {1, 1, 1, 1, 1, 1, 1, 1}, // 0
                                            {1, 1, 1, 0, 0, 1, 1, 1}, // 1
                                            {1, 1, 0, 0, 0, 0, 1, 1}, // 2
                                            {1, 0, 0, 0, 0, 0, 0, 1}, // 3
                                            {1, 0, 0, 0, 0, 0, 0, 1}, // 4
                                            {1, 1, 0, 0, 0, 0, 1, 1}, // 5
                                            {1, 1, 1, 0, 0, 1, 1, 1}, // 6
                                            {1, 1, 1, 1, 1, 1, 1, 1}  // 7
                                        }
                        );
                        
            
            patterns.Add (  new byte[,] { // 0  1  2  3  
                                            {1, 1, 0, 0}, // 0
                                            {1, 1, 0, 0}, // 1
                                            {0, 0, 1, 1}, // 2
                                            {0, 0, 1, 1}, // 3                                            
                                        }
                        );

            patterns.Add (  new byte[,] { // 0  1  2  3  
                                            {0, 0, 0, 0}, // 0
                                            {0, 0, 0, 0}, // 1
                                            {0, 0, 1, 1}, // 2
                                            {0, 0, 1, 1}, // 3                                            
                                        }
                        );

            patterns.Add (  new byte[,] { // 0  1  2  3  
                                            {1, 1, 0, 0}, // 0
                                            {1, 1, 0, 0}, // 1
                                            {0, 0, 0, 0}, // 2
                                            {0, 0, 0, 0}, // 3                                            
                                        }
                        );

             patterns.Add (  new byte[,] { // 0  1  2  3  
                                            {0, 1, 1, 0}, // 0
                                            {1, 0, 0, 1}, // 1
                                            {1, 0, 0, 1}, // 2
                                            {0, 1, 1, 0}, // 3                                            
                                        }
                        );

            patterns.Add (  new byte[,] { // 0  1  2  3  
                                            {1, 0, 0, 0}, // 0
                                            {0, 1, 0, 0}, // 1
                                            {0, 0, 1, 0}, // 2
                                            {0, 0, 0, 1}, // 3                                            
                                        }
                        );

            patterns.Add (  new byte[,] { // 0  1  2  3  
                                            {1, 1, 0, 0}, // 0
                                            {1, 1, 0, 0}, // 1
                                            {1, 1, 0, 0}, // 2
                                            {1, 1, 0, 0}, // 3                                            
                                        }
                        );

            patterns.Add (  new byte[,] { // 0  1  2  3  
                                            {1, 0, 1, 0}, // 0
                                            {1, 0, 1, 0}, // 1
                                            {1, 0, 1, 0}, // 2
                                            {1, 0, 1, 0}, // 3                                            
                                        }
                        );
        }
    
        public void CreateSimpleImages()
        {
            for (int i = 0; i < simpleImages; ++i)
            {
                Image img = CreateImage();
                img.ApplyPattern(patterns[Random.Range(0, patterns.Count)], RandomPixel());
                img.Export(exportationPath + exportedImagesCount + ".png");
                exportedImagesCount++;
            }
        }

        public void CreateDoubleImages()
        {
            for (int i = 0; i < doubleImages; ++i)
            {
                Image img = CreateImage();
                int firstPatternIndex = Random.Range(0, patterns.Count);
                int secondPatternIndex;
                do
                {
                  secondPatternIndex = Random.Range(0, patterns.Count);    
                } while (secondPatternIndex == firstPatternIndex);

                img.ApplyPattern(patterns[firstPatternIndex], RandomPixel());
                img.ApplyPattern(patterns[secondPatternIndex], RandomPixel());

                img.Export(exportationPath + exportedImagesCount + ".png");
                exportedImagesCount++;
            }
        }

        public void CreateTripleImages()
        {
            for (int i = 0; i < tripleImages; ++i)
            {
                Image img = CreateImage();
                int firstPatternIndex = Random.Range(0, patterns.Count);
                int secondPatternIndex;
                int thirdPatternIndex;
                
                do
                {
                  secondPatternIndex = Random.Range(0, patterns.Count);    
                } while (secondPatternIndex == firstPatternIndex);

                do
                {
                  thirdPatternIndex = Random.Range(0, patterns.Count);    
                } while (thirdPatternIndex == firstPatternIndex || thirdPatternIndex == secondPatternIndex);


                img.ApplyPattern(patterns[firstPatternIndex], RandomPixel());
                img.ApplyPattern(patterns[secondPatternIndex], RandomPixel());
                img.ApplyPattern(patterns[thirdPatternIndex], RandomPixel());
                
                img.Export(exportationPath + exportedImagesCount + ".png");
                exportedImagesCount++;
            }
        }

        public Generator.Image CreateImage()
        {
            Generator.Image img = new Generator.Image(imageWidth, imageHeight);
            img.Fill(RandomPixel());
            return img;
        }

        public Generator.Pixel RandomPixel() => new Pixel (Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f,1f));
    }



}