# ImageGenerator
 Creates random images of a desired dimensions in a few seconds.  

![alt text](https://thumbs.gfycat.com/RapidWeepyHogget-size_restricted.gif "Preview")   


## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

The project is developed in Unity environment using C#. [Unity Engine](https://unity.com/) must be installed to compile the project.

No aditional libraries are needed.


### Installing

If you don`t have git in your machine you can follow the steps given in the [git site](https://git-scm.com/).  

Once you have git installed, you can download the repo by command line typing the following line:

```
git clone https://github.com/Pokoi/ImageGenerator.git
```

And that's it. No more steps are needed.


## Compiling the project and modifying it

Into the ``` \Generator\Assets\Scripts ``` folder, some C# code files are given.  
The code works just attaching the script ``` GeneratorManager.cs ``` to a scene hierarchy gameobject. The code will be executed at the start call. 

## Data model explanation

The project includes the following classes:  
:art: *GeneratorManager*: A class that manages all the generation proccess. This class needs to be attached to the scene. Some variables are able to customize, like the image dimensions, the path where export the created images and the number of images to create. In this class you can add new patterns for the generation.    
:art: *Pixel*: A class with the color information of a pixel.    
:art: *Image*: The class that manages all the image creation and image transformation actions.   

## Add your owns patterns

The project generates images combining patterns and giving random colors to them. You can add your own patterns in the ``` void CreatedPatterns() ``` function in the GeneratorManager class. The patterns follow the structure:  
- A byte arrys array of numbers. Only "0" or "1" are expected.   
- Positions with value 0 means no paint mask; otherwise value 1 means a drawing.  
  
The patterns are adapted to the aspect ratio of the final image. It doesn't need to make a huge pattern for huge images.   

## Supported features

:flower_playing_cards: Generate random images in base of a given patterns   
:triangular_ruler: Customize image patterns  

## Screenshots of examples 

![alt text](https://github.com/Pokoi/ImageGenerator/tree/master/Generator/Assets/GeneratedImages/1.png)    
![alt text](https://github.com/Pokoi/ImageGenerator/tree/master/Generator/Assets/GeneratedImages/5.png)    
![alt text](https://github.com/Pokoi/ImageGenerator/tree/master/Generator/Assets/GeneratedImages/8.png)   
![alt text](https://github.com/Pokoi/ImageGenerator/tree/master/Generator/Assets/GeneratedImages/12.png)     


## Built With

:computer: [Unity Engine](https://unity.com/) 

## Authors

* **Jesús Fermín Villar Ramírez `Pokoidev'** - *Project development* - [GitHub profile](https://github.com/Pokoi)


## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

